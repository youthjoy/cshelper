using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QX.GenFramework.Menu;
using System.Threading;
using QX.UI;

namespace QX.UI
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
            this.MdiChildActivate += new EventHandler(MainFrame_MdiChildActivate);
            this.tabForms.SelectedIndexChanged += new EventHandler(tabForms_SelectedIndexChanged);
            this.Load += new EventHandler(MainFrame_Load);
        }

        void MainFrame_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.MaximizeBox = true;
            MethodInvoker mInvoker = new MethodInvoker(this.InitMenu);

            F_Logon logFrm = new F_Logon(mInvoker);
            logFrm.Name = "Login";
            logFrm.MdiParent = this;
            logFrm.Show();

        }

        private void MainFrame_MdiChildActivate(object sender, EventArgs e)
        {
         

            if (this.ActiveMdiChild == null)
            {
                tabForms.Visible = false; // If no any child form, hide tabControl
            }
            else
            {
                if (this.ActiveMdiChild.Name == "Login")
                {
                    return;
                }
                //需要新建
                var flag = false;

                this.ActiveMdiChild.WindowState = FormWindowState.Maximized; // Child form always maximized
                var curData = this.ActiveMdiChild.Tag as MenuData;
                //遍历主窗口上的所有子菜单
                for (int i = 0; i < this.tabForms.TabCount; i++)
                {
                    var mData = (tabForms.TabPages[i].Tag as Form).Name;
                    if (mData == curData.ItemId)
                    {
                        this.tabForms.SelectedIndex = i;
                        //this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;
                    // this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);

                }
                // If child form is new and no has tabPage, create new tabPage
                //if (this.ActiveMdiChild.Tag == null)
                //{
                // Add a tabPage to tabControl with child form caption

                //}

                ///只要窗体激活，均把tabs显示出来
                if (!tabForms.Visible)
                {
                    tabForms.Visible = true;
                }
            }
        }

        // If child form closed, remove tabPage
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            var curData = sender as Form;
            //((sender as Form).in as TabPage).Dispose();
            for (int i = 0; i < this.tabForms.TabCount; i++)
            {
                var mData = (tabForms.TabPages[i].Tag as Form);
                if (curData.Name == mData.Name)
                {
                    var tab = tabForms.TabPages[i];
                    tab.Dispose();
                }
            }
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabForms.SelectedTab != null) && (tabForms.SelectedTab.Tag != null))
                (tabForms.SelectedTab.Tag as Form).Select();
        }

        public void CheckUpdate()
        {

        }

        public void InitData()
        {
            //MenuHelper mHelper = new MenuHelper(this, this.menuStrip1, new MethodInvoker(this.InvokeProgress));



            

            #region 登录信息初始化
            //Label lab = new Label();
            //lab.Width = 235;
            //lab.Top = 5;
            //lab.Text = string.Format("当前登录人:{0} 部门: {1}", SessionConfig.EmpName, SessionConfig.DeptName);
            //if (tsLogin.InvokeRequired)
            //{
            //    MethodInvoker mm = delegate
            //    {
            //        this.tsLogin.Controls.Add(lab);
            //    };

            //    this.Invoke(mm);
            //}
            //else
            //{
            //    this.tsLogin.Controls.Add(lab);
            //}
            #endregion

            #region 通用数据源

            //MethodInvoker mData = delegate
            //{
            //    ComData data = new ComData();
            //    data.SetPositionMap();

            //    data.SetMessage();
            //};
            //mData.BeginInvoke(null, null);
            #endregion
        }

        public void InitMenu()
        {
            MenuHelper mHelper = new MenuHelper(this, this.menuStrip1, null);
            //this.StartPosition = FormStartPosition.CenterScreen;
           // this.WindowState = FormWindowState.Maximized;
        }
    }
}
