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

namespace QX.UI.Prod
{
    public partial class ProdInOp : Bse_Form
    {

        public ProdInOp()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);

            BindTopTool();
        }

        #region 操作句柄
        private GridHelper gen = new GridHelper();

        private BLL.Bll_Prod compInstance = new QX.BLL.Bll_Prod();

        UltraGrid comGrid = new UltraGrid();

        

        #endregion

        #region 工具条

        private void BindTopTool()
        {
            ToolBarHelper tsHelper = new ToolBarHelper();

            ToolStripButton outBtn = tsHelper.New("出库", QX.GenFramework.Properties.Resources.compedit, new EventHandler(outBtn_Click));
            
            this.top_tool_bar.AddCustomControl(outBtn);

            this.top_tool_bar.RefreshClicked+=new EventHandler(top_tool_bar_RefreshClicked);

            //this.top_tool_bar.AddClicked += new EventHandler(top_tool_bar_AddClicked);

            //this.top_tool_bar.EditClicked += new EventHandler(top_tool_bar_EditClicked);

            //this.top_tool_bar.RefreshClicked += new EventHandler(top_tool_bar_RefreshClicked);

            //top_tool_bar.DelClicked += new EventHandler(top_tool_bar_DelClicked);


            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();
            
        }

        void outBtn_Click(object sender, EventArgs e)
        {
            List<Prod_Pool> list = GetGridCheckBoxData();
            if (list.Count == 0)
            {
                Alert.Show("请选择要出库的成品!");
            }
            else
            {
                compInstance.SetProdListOut(list);
                Alert.Show("数据更新完成!");
                BindData();
            }
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
            //UltraGridRow row = this.comGrid.ActiveRow;
            //if (row != null)
            //{
            //    Tpl_Components comp = row.ListObject as Tpl_Components;
            //    CompOp EditFrm = new CompOp(comp, OperationTypeEnum.Edit);
            //    EditFrm.CallBack += new CompOp.DCallBackHandler(EditFrm_CallBack);
            //    EditFrm.Show();
            //}
        }

        void EditFrm_CallBack(bool flag)
        {
           BindData();
        }


        void top_tool_bar_AddClicked(object sender, EventArgs e)
        {


            //CompOp frmAdd = new CompOp(new Tpl_Components(), OperationTypeEnum.Add);
            //frmAdd.CallBack += new CompOp.DCallBackHandler(frmAdd_CallBack);
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


            List<Prod_Pool> list = compInstance.GetInProdCompList(val1, val2, val3);
            comGrid.DataSource = list;
            AddCustomCol();
        }
        #endregion

        void Form_Load(object sender, EventArgs e)
        {
            InitControl();
            //BindData();

            ucProdOut.InitControl();
            //ucProdOut.BindData();

            prodAll.InitControl();
            //prodAll.BindData();
        }
        #region 当前成品



        public void InitControl()
        {
            //当前库存 
            List<Prod_Pool> list = new List<Prod_Pool>();
            comGrid = gen.GenerateGrid("CList_POut", this.pnlGrid, new Point(0, 0));
            comGrid.DataSource = list;

            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
        }

        private void AddCustomCol()
        {
            if (!comGrid.DisplayLayout.Bands[0].Columns.Exists("checkbox"))
            {
                var col = comGrid.DisplayLayout.Bands[0].Columns.Add("checkbox", "");
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                //col.Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                col.DataType = typeof(bool);
                col.DefaultCellValue = false;
                col.Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                col.Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
                col.Header.VisiblePosition = 0;
                col.CellClickAction = CellClickAction.Edit;

            }
            else
            {
                comGrid.DisplayLayout.Bands[0].Columns.Remove("checkbox");
                var col = comGrid.DisplayLayout.Bands[0].Columns.Add("checkbox", "");
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                //col.Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                col.DataType = typeof(bool);
                col.DefaultCellValue = false;
                col.Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                col.Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
                col.Header.VisiblePosition = 0;
                col.CellClickAction = CellClickAction.Edit;
            }
        }


        private List<Prod_Pool> GetGridCheckBoxData()
        {
            List<Prod_Pool> list = new List<Prod_Pool>();

            foreach (UltraGridRow r in this.comGrid.DisplayLayout.Rows)
            {

                if (r.Cells["checkbox"].Value != null && r.Cells["checkbox"].Value.ToString() == "True")
                {
                    Prod_Pool planProd = r.ListObject as Prod_Pool;
                    list.Add(planProd);
                }
            }

            return list;
        }

        public void BindData()
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");

            List<Prod_Pool> list = compInstance.GetInProdCompList(val1,val2,"");

            comGrid.DataSource = list;

            AddCustomCol();
        }

        #endregion
    }
}
