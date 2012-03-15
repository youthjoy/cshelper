using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class ProdOut : UserControl
    {
        public ProdOut()
        {
            InitializeComponent();

            BindTopTool();
        }

        public void BindTopTool()
        {
            this.tbGrid.SearchClicked += new EventHandler(tbGrid_SearchClicked);
            this.tbGrid.AddSearchAllModule();
            this.tbGrid.RefreshClicked += new EventHandler(tbGrid_RefreshClicked);
            this.tbGrid.EditClicked+=new EventHandler(tbGrid_EditClicked);
            this.tbGrid.LookClicked += new EventHandler(tbGrid_LookClicked);
        }

        void tbGrid_EditClicked(object sender, EventArgs e)
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


        void tbGrid_LookClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Pool comp = row.ListObject as Prod_Pool;
                ProdIO EditFrm = new ProdIO(comp, OperationTypeEnum.Look);
                
                EditFrm.Show();
            }
        }

        UltraGrid comGrid = new UltraGrid();

        GridHelper gen;

        private BLL.Bll_Prod pdInstance;

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
            List<Prod_Pool> list = pdInstance.GetOutProdCompList(val1, val2, val3);
            comGrid.DataSource = list;
        }

        public void BindData()
        {
            
            List<Prod_Pool> list = pdInstance.GetOutProdCompList();
            comGrid.DataSource = list;
        }
    }
}
