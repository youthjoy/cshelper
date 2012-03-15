using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class ProdAll : UserControl
    {

        public ProdAll()
        {
            InitializeComponent();

            BindTopTool();
        }

        public void BindTopTool()
        {
            this.tbGrid.SearchClicked += new EventHandler(tbGrid_SearchClicked);
            this.tbGrid.AddSearchAllModule();
            this.tbGrid.RefreshClicked += new EventHandler(tbGrid_RefreshClicked);

            this.tbGrid.LookClicked += new EventHandler(tbGrid_LookClicked);
            ToolBarHelper tsHelper=new ToolBarHelper();
            ToolStripButton repairBtn = tsHelper.New("维修", QX.GenFramework.Properties.Resources.batch, new EventHandler(repairBtn_Click));
            //repairBtn.Click += new EventHandler(repairBtn_Click);
            this.tbGrid.AddCustomControl(repairBtn);
        }

        void repairBtn_Click(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Pool p = row.ListObject as Prod_Pool;
                ProdRepairOp prOp = new ProdRepairOp(p,OperationTypeEnum.Add);
                prOp.Show();
            }
        }

        void tbGrid_LookClicked(object sender, EventArgs e)
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

        public void AddCustomBtn(ToolStripItem item,int index)
        { 
           this.tbGrid.AddCustomControl(index,item);
        }

        UltraGrid comGrid = new UltraGrid();

        GridHelper gen;

        private BLL.Bll_Prod pdInstance;

        public UltraGridRow GetActiveRow()
        {
            return this.comGrid.ActiveRow;
        }

        public void InitControl()
        {
            gen = new GridHelper();

            pdInstance=new QX.BLL.Bll_Prod();
            comGrid = gen.GenerateGrid("CList_POut", this.pnlGrid, new Point(0, 0));
            List<Prod_Pool> list = new List<Prod_Pool>();
            comGrid.DataSource = list;

            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
        }

        void tbGrid_RefreshClicked(object sender, EventArgs e)
        {
            BindData();
        }

        void tbGrid_SearchClicked(object sender, EventArgs e)
        {
            string val1 = this.tbGrid.GetSearchValue("bDate", "Date");
            string val2 = this.tbGrid.GetSearchValue("eDate", "Date");
            string val3 = this.tbGrid.GetSearchValue("Key", "Text");

            List<Prod_Pool> list = pdInstance.GetAllProdCompList(val1, val2, val3);

            comGrid.DataSource = list;
        }

        public void BindData()
        {
            string val1 = this.tbGrid.GetSearchValue("bDate", "Date");
            string val2 = this.tbGrid.GetSearchValue("eDate", "Date");
            List<Prod_Pool> list = pdInstance.GetAllProdCompList(val1,val2,"");
            comGrid.DataSource = list;
        }
    }
}
