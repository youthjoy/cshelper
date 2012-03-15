using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QX.GenFramework.BseControl;

using QX.GenFramework;
using QX.GenFramework.AutoForm;
using Infragistics.Win.UltraWinGrid;
using QX.Model;
using QX.GenFramework.Helper;
using QX.Helper;
using QX.Log;
using QX.Shared;

namespace QX.UI.Components
{
    /// <summary>
    /// 零件管理
    /// </summary>
    public partial class CompDoc : Bse_Form
    {
        public CompDoc()
        {
            InitializeComponent();
            BindTopTool();
            this.Load += new EventHandler(Form_Load);
        }

        void CompDoc_Load(object sender, EventArgs e)
        {
            this.Text = "零件质量文档管理";
        }



        #region 操作句柄
        private GridHelper gen = new GridHelper();

        private BLL.Bll_Comp compInstance = new QX.BLL.Bll_Comp();

        UltraGrid comGrid = new UltraGrid();

        #endregion

        #region 工具条

        private void BindTopTool()
        {
            //ToolBarHelper tsHelper = new ToolBarHelper();

            //ToolStripButton docReq = tsHelper.New("关联文档", QX.GenFramework.Properties.Resources.compedit, new EventHandler(docReq_Click));

            //this.top_tool_bar.AddCustomControl(docReq);

            ToolBarHelper tsHelper = new ToolBarHelper();

            this.top_tool_bar.AddClicked += new EventHandler(top_tool_bar_AddClicked);

            this.top_tool_bar.EditClicked += new EventHandler(top_tool_bar_EditClicked);

            this.top_tool_bar.RefreshClicked += new EventHandler(top_tool_bar_RefreshClicked);

            this.top_tool_bar.LookClicked += new EventHandler(top_tool_bar_LookClicked);

            top_tool_bar.DelClicked += new EventHandler(top_tool_bar_DelClicked);


            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();

            ToolStripButton batchBtn = tsHelper.New("批量零件编号生成", QX.GenFramework.Properties.Resources.batch, new EventHandler(batchBtn_Click));

            //batchBtn.Click += new EventHandler(batchBtn_Click);
            this.top_tool_bar.AddCustomControl(batchBtn);



            ToolStripButton batchScanBtn = tsHelper.New("批量扫描", QX.GenFramework.Properties.Resources.batch, new EventHandler(batchScanBtn_Click));
            //batchScanBtn.Click += new EventHandler(batchScanBtn_Click);
            //batchBtn.Click += new EventHandler(batchBtn_Click);
            this.top_tool_bar.AddCustomControl(batchScanBtn);
        }

        void batchScanBtn_Click(object sender, EventArgs e)
        {
            List<Prod_Components> list=new List<Prod_Components>();
            foreach (var r in this.comGrid.Selected.Rows)
            {
                Prod_Components p = r.ListObject as Prod_Components;
                list.Add(p);
            }

            if (list.Count > 0)
            {
                //BatchScan bsFrm = new BatchScan(list, OperationTypeEnum.Add);
                //bsFrm.Show();
            }
            else
            {
                Alert.Show("请选择要批量扫描的零件!");
            }
        }

        void batchBtn_Click(object sender, EventArgs e)
        {
            BatchComp bCompFrm = new BatchComp();
            bCompFrm.CallBack += new BatchComp.DCallBackHandler(bCompFrm_CallBack);
            bCompFrm.ShowDialog();
        }

        void bCompFrm_CallBack(bool flag)
        {
            BindData();
        }
        void top_tool_bar_LookClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Components comp = row.ListObject as Prod_Components;
                CompMange EditFrm = new CompMange(comp, OperationTypeEnum.Look);
                EditFrm.CallBack += new CompMange.DCallBackHandler(EditFrm_CallBack);
                EditFrm.Show();
            }
        }


        void top_tool_bar_RefreshClicked(object sender, EventArgs e)
        {
            BindData();
        }

        void top_tool_bar_DelClicked(object sender, EventArgs e)
        {
            var rows = this.comGrid.Selected.Rows;
            if (rows.Count == 0)
            {
                UltraGridRow row = this.comGrid.ActiveRow;
                if (row != null)
                {
                    rows.Add(row);
                }
            }
            if (rows.Count == 0)
            {
                Alert.Show("请选中要删除的行!");
                return;
            }

            if (Alert.ShowIsConfirm("确定删除该零件吗?"))
            {
                StringBuilder sb = new StringBuilder();
                ConfirmWin confirmWin = new ConfirmWin();
                confirmWin.Text = "零件删除确认界面";
                confirmWin.ShowDialog();
                if (!confirmWin.IsAllow)
                {
                    Alert.Show("你没有删除该零件的权限!");
                    return;
                }
                else
                {
                    List<Prod_Components> list = new List<Prod_Components>();

                  
                    foreach (var r in rows)
                    {

                        Prod_Components comp = r.ListObject as Prod_Components;
                        compInstance.DeleteDocByComp(comp);
                        if (!compInstance.CompDelete(comp))
                        {
                            sb.Append(comp.PRDC_CompNo).Append(",");
                        }
                        list.Add(comp);
                    }

                    if (sb.ToString().Length == 0)
                    {


                        Alert.Show("数据更新成功!");
                    }
                    else
                    {

                        Alert.Show(string.Format("以下零件未能成功删除!{0}", sb.ToString().TrimEnd(',')));
                    }

                    MethodInvoker mi = delegate
                    {
                        foreach (var c in list)
                        {
                            DeleteFolder(c.PRDC_CompNo);
                        }
                    };

                    mi.BeginInvoke(null, null);

                    BindData();
                }
            }

            //UltraGridRow row = this.comGrid.ActiveRow;
            //if (row != null)
            //{
            //    ConfirmWin confirmWin = new ConfirmWin();
            //    confirmWin.Text = "零件删除确认界面";
            //    confirmWin.ShowDialog();
            //    if (!confirmWin.IsAllow)
            //    {
            //        Alert.Show("你没有删除该零件的权限!");
            //        return;
            //    }
            //    else
            //    {

            //        Prod_Components comp = row.ListObject as Prod_Components;
            //        compInstance.DeleteDocByComp(comp);
            //        compInstance.CompDelete(comp);

            //        MethodInvoker mi = delegate
            //        {
            //            DeleteFolder(comp.PRDC_CompNo);
            //        };

            //        mi.BeginInvoke(null, null);
            //        Alert.Show("删除成功!");
            //        BindData();
            //    }
            //}
        }

        public void DeleteFolder(string folder)
        {
            try
            {
                BLL.Bll_File fileInstance = new QX.BLL.Bll_File();

                if (fileInstance.ftp.DirectoryExist(folder))
                {
                    var flag = fileInstance.ftp.RenameDirectory(folder, folder + "_trash");
                }
            }
            catch (Exception ex)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "ProdMain",
                   ex.Message, PlateLog.LogMessageType.Error, ex);
            }
        }

        void top_tool_bar_EditClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Components comp = row.ListObject as Prod_Components;
                CompMange EditFrm = new CompMange(comp, OperationTypeEnum.Edit);
                EditFrm.CallBack += new CompMange.DCallBackHandler(EditFrm_CallBack);
                EditFrm.Show();
            }
        }

        void EditFrm_CallBack(bool flag)
        {
            BindData();
        }


        void top_tool_bar_AddClicked(object sender, EventArgs e)
        {
            //CompMange frmAdd = new CompMange(new Prod_Components(), OperationTypeEnum.Add);
            //frmAdd.CallBack += new CompMange.DCallBackHandler(frmAdd_CallBack);
            //frmAdd.Show();
        }

        void frmAdd_CallBack(bool flag)
        {
            BindData();
        }

        void docReq_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void top_tool_bar_SearchClicked(object sender, EventArgs e)
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");
            string val3 = this.top_tool_bar.GetSearchValue("Key", "Text");

            List<Prod_Components> list = compInstance.GetPComponentsList(val1, val2, val3);

            comGrid.DataSource = list;
        }

        #endregion


        void Form_Load(object sender, EventArgs e)
        {
            InitControl();
            //BindData();
        }

        public void InitControl()
        {
            List<Prod_Components> list = new List<Prod_Components>();
            comGrid = gen.GenerateGrid("CList_Components", this.pnlGrid, new Point(0, 0));

            //comGrid.DisplayLayout.LoadStyle = LoadStyle.LoadOnDemand;


            comGrid.DataSource = list;
            comGrid.DoubleClickRow += new DoubleClickRowEventHandler(comGrid_DoubleClickRow);
            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;

        }

        void comGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //双击查看
            top_tool_bar_LookClicked(null, null);
        }

        public void BindData()
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");

            List<Prod_Components> list = compInstance.GetPComponentsList(val1, val2, "").ToList();

            comGrid.DataSource = list;
        }
    }
}
