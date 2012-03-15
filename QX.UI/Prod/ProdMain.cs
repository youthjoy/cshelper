using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QX.Common.BseControl;
using QX.Gen;
using QX.GenFramework;
using QX.Framework;
using QX.Framework.AutoForm;
using Infragistics.Win.UltraWinGrid;
using QX.Model;
using QX.Common.Helper;
using QX.Helper;
using QX.UI.Components;
using QX.Log;
using QX.Shared;

namespace QX.UI.Prod
{
    public partial class ProdMain : Bse_Form
    {


        public ProdMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);

            BindTopTool();

            
        }

        #region 操作句柄
        private GridHelper gen = new GridHelper();

        private BLL.Bll_Prod compInstance = new QX.BLL.Bll_Prod();

        UltraGrid comGrid = new UltraGrid();
        /// <summary>
        /// 所有成品列表
        /// </summary>
        UltraGrid allGrid = new UltraGrid();

        #endregion

        #region 工具条

        private void BindTopTool()
        {

            #region 工具条
            this.top_tool_bar.AddClicked += new EventHandler(top_tool_bar_AddClicked);

            this.top_tool_bar.EditClicked += new EventHandler(top_tool_bar_EditClicked);

            this.top_tool_bar.RefreshClicked += new EventHandler(top_tool_bar_RefreshClicked);
            this.top_tool_bar.LookClicked += new EventHandler(top_tool_bar_LookClicked);
            top_tool_bar.DelClicked += new EventHandler(top_tool_bar_DelClicked);

            //top_tool_bar.LookClicked += new EventHandler(top_tool_bar_QueryClicked);
            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();

            #endregion

            ToolBarHelper tsHelper = new ToolBarHelper();
            ToolStripButton batchBtn = tsHelper.New("批量成品编号生成", QX.GenFramework.Properties.Resources.batch, new EventHandler(batchBtn_Click));

            //batchBtn.Click += new EventHandler(batchBtn_Click);
            this.top_tool_bar.AddCustomControl(batchBtn);
        }

        void top_tool_bar_LookClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Pool comp = row.ListObject as Prod_Pool;
                ProdIO EditFrm = new ProdIO(comp, OperationTypeEnum.Look);
                //EditFrm.CallBack += new ProdIO.DCallBackHandler(EditFrm_CallBack);
                EditFrm.Show();
            }
        }

        void batchBtn_Click(object sender, EventArgs e)
        {
            BatchProd bCompFrm = new BatchProd();
            bCompFrm.CallBack += new BatchProd.DCallBackHandler(bCompFrm_CallBack);
            bCompFrm.ShowDialog();
        }

        void bCompFrm_CallBack(bool flag)
        {
            BindData();
        }

        void top_tool_bar_QueryClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Pool comp = row.ListObject as Prod_Pool;
                ProdIO EditFrm = new ProdIO(comp, OperationTypeEnum.Look);
                //EditFrm.CallBack += new ProdIO.DCallBackHandler(EditFrm_CallBack);
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

            if (Alert.ShowIsConfirm("确定删除该成品吗?"))
            {
                StringBuilder sb = new StringBuilder();
                ConfirmWin confirmWin = new ConfirmWin();
                confirmWin.Text = "成品删除确认界面";
                confirmWin.ShowDialog();
                if (!confirmWin.IsAllow)
                {
                    Alert.Show("你没有删除该成品的权限!");
                    return;
                }
                else
                {
                    List<Prod_Pool> list = new List<Prod_Pool>();
                 
                    foreach (var r in rows)
                    {

                        Prod_Pool prod = r.ListObject as Prod_Pool;
                        compInstance.DeleteCompByProd(prod);

                        if (!compInstance.PCDelete(prod))
                        {
                            sb.Append(prod.PRP_ProdCode).Append(",");
                        }

                        list.Add(prod);
                    }

                    if (sb.ToString().Length == 0)
                    {

                        Alert.Show("数据更新成功!");
                    }
                    else
                    {

                        Alert.Show(string.Format("以下成品未能成功删除!{0}", sb.ToString().TrimEnd(',')));
                    }

                    MethodInvoker mi = delegate
                    {
                        foreach (var c in list)
                        {
                            DeleteFolder(c.PRP_ProdCode);
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
            //    confirmWin.Text = "成品删除确认界面";
            //    confirmWin.ShowDialog();
            //    if (!confirmWin.IsAllow)
            //    {
            //        Alert.Show("你没有删除该成品的权限!");
            //        return;
            //    }
            //    else
            //    {
                    

            //        Prod_Pool prod = row.ListObject as Prod_Pool;

            //        compInstance.DeleteCompByProd(prod);
            //        compInstance.PCDelete(prod);

            //        MethodInvoker mi = delegate
            //        {
            //            DeleteFolder(prod.PRP_ProdCode);
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
                    fileInstance.ftp.RenameDirectory(folder, folder + "_trash");
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
                Prod_Pool comp = row.ListObject as Prod_Pool;
                ProdIO EditFrm = new ProdIO(comp, OperationTypeEnum.Edit);
                EditFrm.CallBack += new ProdIO.DCallBackHandler(EditFrm_CallBack);
                EditFrm.Show();
            }
        }

        void EditFrm_CallBack(bool flag)
        {
           BindData();
        }


        void top_tool_bar_AddClicked(object sender, EventArgs e)
        {
            ProdIO AddFrm = new ProdIO(new Prod_Pool(), OperationTypeEnum.Add);
            AddFrm.CallBack += new ProdIO.DCallBackHandler(AddFrm_CallBack);
            AddFrm.Show();
            //CompOp frmAdd = new CompOp(new Tpl_Components(), OperationTypeEnum.Add);
            //frmAdd.CallBack += new CompOp.DCallBackHandler(frmAdd_CallBack);
            //frmAdd.Show();
        }

        void AddFrm_CallBack(bool flag)
        {
            BindData();
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

            List<Prod_Pool> list = compInstance.GetInProdCompList(val1,val2,val3);

            comGrid.DataSource = list;
        }
        #endregion

        void Form_Load(object sender, EventArgs e)
        {
            InitControl();
            //BindData();

            prodAll.InitControl();
            prodAll.BindData();
        }

        public void InitControl()
        {
            List<Prod_Pool> list = new List<Prod_Pool>();
            comGrid = gen.GenerateGrid("CList_PPool", this.pnlGrid, new Point(0, 0));
            comGrid.DataSource = list;
            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            comGrid.DoubleClickRow += new DoubleClickRowEventHandler(comGrid_DoubleClickRow);
            //List<Prod_Pool> list1 = new List<Prod_Pool>();
            //this.allGrid = gen.GenerateGrid("CList_POut", this.pnlAll, new Point(0, 0));
            //allGrid.DataSource = list1;

        }

        void comGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            top_tool_bar_LookClicked(null,null);
        }

        public void BindData()
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");

            List<Prod_Pool> list = compInstance.GetInProdCompList(val1,val2,"").OrderByDescending(o=>o.PRP_ID).ToList();

            comGrid.DataSource = list;

            //List<Prod_Pool> list1 = compInstance.GetAllProdCompList();
            //allGrid.DataSource = list1;
        }
    }
}
