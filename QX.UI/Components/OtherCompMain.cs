using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QX.GenFramework;
using QX.GenFramework.AutoForm;
using Infragistics.Win.UltraWinGrid;
using QX.Model;
using QX.GenFramework.Helper;
using QX.Helper;
using QX.GenFramework.BseControl;

namespace QX.UI.Components
{
    public partial class OtherCompMain : Bse_Form
    {


        public OtherCompMain()
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

            //top_tool_bar.DelClicked += new EventHandler(top_tool_bar_DelClicked);


            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();



        }

        void top_tool_bar_LookClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Components comp = row.ListObject as Prod_Components;
                OtherCompOp EditFrm = new OtherCompOp(comp, OperationTypeEnum.Look);
                //EditFrm.CallBack += new CompMange.DCallBackHandler(EditFrm_CallBack);
                EditFrm.Show();
            }
        }


        void top_tool_bar_RefreshClicked(object sender, EventArgs e)
        {
            BindData();
        }


        void top_tool_bar_EditClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Components comp = row.ListObject as Prod_Components;
                OtherCompOp EditFrm = new OtherCompOp(comp, OperationTypeEnum.Edit);
                EditFrm.CallBack += new OtherCompOp.DCallBackHandler(EditFrm_CallBack);
                EditFrm.Show();
            }
        }

        void EditFrm_CallBack(bool flag)
        {
            BindData();
        }


        void top_tool_bar_AddClicked(object sender, EventArgs e)
        {


            OtherCompOp frmAdd = new OtherCompOp(new Prod_Components(), OperationTypeEnum.Add);
            frmAdd.CallBack += new OtherCompOp.DCallBackHandler(frmAdd_CallBack);
            frmAdd.Show();
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

            List<Prod_Components> list = compInstance.GetOtherComponentsList(val1, val2, val3);

            comGrid.DataSource = list;
        }

        #endregion


        void Form_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData();
        }

        public void InitControl()
        {
            List<Prod_Components> list = new List<Prod_Components>();
            comGrid = gen.GenerateGrid("CList_OtherDoc", this.pnlGrid, new Point(0, 0));
            comGrid.DataSource = list;
            comGrid.DoubleClickRow += new DoubleClickRowEventHandler(comGrid_DoubleClickRow);
            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;

        }

        void comGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.top_tool_bar_LookClicked(null, null);
        }

        public void BindData()
        {
            List<Prod_Components> list = compInstance.GetOtherComponentsList();

            comGrid.DataSource = list;
        }
    }
}

