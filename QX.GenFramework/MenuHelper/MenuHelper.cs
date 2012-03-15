using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
using QX.GenFramework;
using QX.GenFramework.Utils;
using QX.GenFramework.DAO;

namespace QX.GenFramework.Menu
{
    public class MenuData
    {
        public string FormName
        {
            get;
            set;
        }
        /// <summary>
        /// 所属程序集合
        /// </summary>
        public string AssemblyName
        {
            get;
            set;
        }

        public string FormText
        {
            get;
            set;
        }

        public string ParentId
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ExtParameter
        {
            get;
            set;
        }

        public string IsLevel
        {
            get;
            set;
        }
    }


    public class MenuHelper
    {
        private Form parentForm = null;

        private MenuStrip menuStrip = null;

        private MethodInvoker MInvoker;

        /// <summary>
        /// 权限钩子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public delegate bool DCallBackHandler(object sender, string data);

        public event DCallBackHandler CallBack;

        public MenuHelper(Form thisForm, MenuStrip menu, MethodInvoker _mInvoker)
        {

            parentForm = thisForm;
            menuStrip = menu;

            MInvoker = _mInvoker;

            StyleInit();

            //List<Sys_UserPermission> list = new Bll_Permission().GetUserPermission(SessionConfig.UserCode);
            //PermissionSource = list;
            CreateMenu("");
        }


        private void StyleInit()
        {
            menuStrip.RenderMode = ToolStripRenderMode.Professional;
        }




        /// <summary>
        /// 动态创建菜单
        /// </summary>
        private void CreateMenu(string menuContent)
        {
            //定义一个主菜单
            MenuStrip mainMenu = menuStrip;
            DataTable dt = new DataTable();
            dt = new CommHelper().ListViewData("select * from sys_csmenu where isnull(stat,0)=0 order by cmenu_order");
            //ds.ReadXml(Path.Combine(Application.StartupPath, "..\\..\\Menu\\MenuSource.xml"));
            //ds.ReadXml(Environment.CurrentDirectory + "\\Menu\\MenuSource.xml");
            DataView dv = dt.DefaultView;
            //通过DataView来过滤数据首先得到最顶层的菜单
            dv.RowFilter = "CMenu_PCode is NULL";
            for (int i = 0; i < dv.Count; i++)
            {
                //创建一个菜单项
                ToolStripMenuItem topMenu = new ToolStripMenuItem();
                //给菜单赋Text值。也就是在界面上看到的值。
                topMenu.Text = dv[i]["CMenu_Name"].ToString();
                topMenu.Name = dv[i]["CMenu_Code"].ToString();

                //if (PermissionSource.FirstOrDefault(o => o.FunctionCode == topMenu.Name) == null)
                //{
                //    continue;
                //}
                if (CallBack != null && !CallBack(topMenu, topMenu.Name))
                {
                    continue;
                }

                //如果是有下级菜单则通过CreateSubMenu方法来创建下级菜单
                if (Convert.ToInt16(dv[i]["CMenu_IsModule"]) == 1)
                {
                    //以ref的方式将顶层菜单传递参数，因为他可以在赋值后再回传。
                    CreateSubMenu(ref topMenu, dv[i]["CMenu_Code"].ToString(), dt);
                }
                //显示应用程序中已打开的 MDI 子窗体列表的菜单项
                //mainMenu.MdiWindowListItem = topMenu;

                //将递归附加好的菜单加到菜单根项上。
                if (mainMenu.InvokeRequired)
                {
                    MethodInvoker mi = delegate
                    {  //将递归附加好的菜单加到菜单根项上。
                        mainMenu.Items.Add(topMenu);
                    };
                    mainMenu.Invoke(mi);
                }
                else
                {
                    mainMenu.Items.Add(topMenu);
                }
            }

            ToolStripMenuItem exitMenu = new ToolStripMenuItem();
            //mainMenu.Dock = DockStyle.Top;
            //将窗体的MainMenuStrip梆定为mainMenu.
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 创建子菜单
        /// </summary>
        /// <param name="topMenu">父菜单项</param>
        /// <param name="ItemID">父菜单的ID</param>
        /// <param name="dt">所有菜单数据集</param>
        private void CreateSubMenu(ref ToolStripMenuItem topMenu, string ItemID, DataTable dt)
        {
            DataView dv = new DataView(dt);
            //过滤出当前父菜单下在所有子菜单数据(仅为下一层的)
            dv.RowFilter = "CMenu_PCode=" + ItemID.ToString();

            for (int i = 0; i < dv.Count; i++)
            {
                //创建子菜单项
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Text = dv[i]["CMenu_Name"].ToString();
                subMenu.Name = dv[i]["CMenu_Code"].ToString();
                //如果还有子菜单则继续递归加载。
                if (TypeConverter.ObjectToInt(dv[i]["CMenu_IsModule"]) == 1)
                {
                    //递归调用
                    CreateSubMenu(ref subMenu, dv[i]["CMenu_Code"].ToString(), dt);
                }
                else
                {
                    //扩展属性可以加任何想要的值。这里用formName属性来加载窗体。

                    MenuData md = new MenuData();
                    if (dv[i]["CMenu_Path"] != null)
                    {
                        md.FormName = dv[i]["CMenu_Path"].ToString();
                    }
                    if (dv[i]["CMenu_Code"] != null)
                    {
                        md.ItemId = dv[i]["CMenu_Code"].ToString();
                    }
                    if (dv[i]["CMenu_Name"] != null)
                    {
                        md.FormText = dv[i]["CMenu_Name"].ToString();
                    }
                    if (dv[i]["CMenu_PCode"] != null)
                    {
                        md.ParentId = dv[i]["CMenu_PCode"].ToString();
                    }
                    if (dv[i]["CMenu_Assembly"] != null)
                    {
                        md.AssemblyName = dv[i]["CMenu_Assembly"].ToString();
                    }
                    if (dv[i]["CMenu_ExtParameter"] != null)
                    {
                        md.ExtParameter = dv[i]["CMenu_ExtParameter"].ToString();
                    }
                    if (dv[i]["CMenu_Level"] != null)
                    {
                        md.IsLevel = dv[i]["CMenu_Level"].ToString();
                    }
                    subMenu.Tag = md;

                    //给没有子菜单的菜单项加事件。
                    subMenu.Click += new EventHandler(subMenu_Click);
                }

                //将菜单加到顶层菜单下。
                topMenu.DropDownItems.Add(subMenu);
            }
        }


        /// <summary>
        /// 菜单单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void subMenu_Click(object sender, EventArgs e)
        {
            //tag属性在这里有用到。
            MenuData md = ((ToolStripMenuItem)sender).Tag as MenuData;
            if (md != null)
            {
                string FormName = md.FormName;

                CreateFormInstance(FormName, md.ItemId, md);
            }
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 创建form实例。
        /// </summary>
        /// <param name="formName">form的类名</param>
        private void CreateFormInstance(string formName, string id, MenuData md)
        {
            bool flag = false;


            //遍历主窗口上的所有子菜单
            for (int i = 0; i < this.parentForm.MdiChildren.Length; i++)
            {
                //如果所点的窗口被打开则重新激活
                var mData = this.parentForm.MdiChildren[i].Tag as MenuData;
                if (mData != null && mData.ItemId.ToLower() == id.ToLower())
                {
                    this.parentForm.MdiChildren[i].Activate();
                    this.parentForm.MdiChildren[i].Show();
                    this.parentForm.MdiChildren[i].WindowState = FormWindowState.Normal;
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                try
                {

                    //if (CustCache.Instance[formName] != null)
                    //{
                    //    Form frms = (Form)CustCache.Instance[formName];
                    //    //tag属性要重新写一次
                    //    frms.Tag = formName.ToString();
                    //    frms.MdiParent = parentForm;
                    //    frms.Show();
                    //}
                    //else
                    //{


                    if (MInvoker != null)
                    {
                        //parentForm.BeginInvoke(MInvoker);
                        MInvoker.BeginInvoke(null, null);
                    }

                    //如果不存在则用反射创建form窗体实例。
                    Assembly asm = Assembly.Load(md.AssemblyName);//程序集名
                    object frmObj = null;
                    Type type = asm.GetType(md.AssemblyName + "." + formName);
                    //frmObj = asm.CreateInstance("BC.UI." + formName);//程序集+form的类名。
                    if (md != null && string.IsNullOrEmpty(md.ExtParameter))
                    {
                        frmObj = Activator.CreateInstance(type, null);//程序集+form的类名。
                    }
                    else
                    {
                        object[] re = { md.ExtParameter };
                        frmObj = Activator.CreateInstance(type, re);//程序集+form的类名。
                    }

                    //CustCache.Instance.Add(formName,frmObj);

                    Form frms = (Form)frmObj;

                    if (md.IsLevel == "0")
                    {
                        //frms.Tag = formName.ToString();
                        frms.Tag = md;
                        frms.Name = md.ItemId;
                        frms.Text = md.FormText;
                        frms.Show();
                    }
                    else
                    {
                        //tag属性要重新写一次
                        frms.Tag = md;
                        frms.Text = md.FormText;
                        frms.Name = md.ItemId;
                        //frms.Tag = formName.ToString();
                        frms.MdiParent = parentForm;
                        frms.Show();
                    }
                    //}

                }
                catch (Exception e)
                {
                    //throw e;
                }
            }
        }
    }
}
