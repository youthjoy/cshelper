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

namespace QX.UI.Prod
{
    public partial class ProdRepair : Bse_Form
    {


        public ProdRepair()
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

            #region 库存
            this.top_tool_bar.AddClicked += new EventHandler(top_tool_bar_AddClicked);

            this.top_tool_bar.EditClicked += new EventHandler(top_tool_bar_EditClicked);

            this.top_tool_bar.RefreshClicked += new EventHandler(top_tool_bar_RefreshClicked);

            top_tool_bar.DelClicked += new EventHandler(top_tool_bar_DelClicked);


            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();

            #endregion


        }

        void top_tool_bar_RefreshClicked(object sender, EventArgs e)
        {
            BindData();
        }

        void top_tool_bar_DelClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void top_tool_bar_EditClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Maintain comp = row.ListObject as Prod_Maintain;
                ProdRepairOp EditFrm = new ProdRepairOp(comp, OperationTypeEnum.Edit);
                EditFrm.CallBack += new ProdRepairOp.DCallBackHandler(EditFrm_CallBack);
                EditFrm.Show();
            }
        }

        void EditFrm_CallBack(bool flag)
        {
            BindData();
        }


        void top_tool_bar_AddClicked(object sender, EventArgs e)
        {
            ProdRepairOp AddFrm = new ProdRepairOp(new Prod_Maintain(), OperationTypeEnum.Add);
            AddFrm.CallBack += new ProdRepairOp.DCallBackHandler(AddFrm_CallBack);
            AddFrm.Show();
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

            var list = compInstance.GetProdMaintainList(val1, val2, val3);
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
            List<Prod_Maintain> list = new List<Prod_Maintain>();
            comGrid = gen.GenerateGrid("CList_PMaintain", this.pnlGrid, new Point(0, 0));
            comGrid.DataSource = list;
            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
    

        }

        public void BindData()
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");

            List<Prod_Maintain> list = compInstance.GetProdMaintainList(val1,val2,"");

            comGrid.DataSource = list;

        }



    }
}
