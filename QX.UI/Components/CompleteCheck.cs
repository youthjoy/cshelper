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
using QX.BLL;
using System.IO;

namespace QX.UI.Components
{
    public partial class CompleteCheck : Bse_Form
    {
        private BLL.Bll_Doc dcInstance = new QX.BLL.Bll_Doc();

        private BLL.Bll_File fileInstance = new QX.BLL.Bll_File();

        public CompleteCheck()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);

            BindTopTool();
        }

        #region 操作句柄

        private GridHelper gen = new GridHelper();

        private BLL.Bll_Prod prodInstance = new QX.BLL.Bll_Prod();

        private BLL.Bll_Comp compInstance = new Bll_Comp();

        UltraGrid comGrid = new UltraGrid();

        UltraGrid prodGrid = new UltraGrid();

        /// <summary>
        /// 所有成品列表
        /// </summary>
        UltraGrid allGrid = new UltraGrid();

        #endregion

        #region 工具条


        ComboBox comboStat = new ComboBox();


        private void BindTopTool()
        {

            #region 库存


            this.top_tool_bar.LookClicked += new EventHandler(top_tool_bar_LookClicked);
            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();

            //ToolStripControlHost comboStatHost = new ToolStripControlHost(comboStat);
            //comboStatHost.Margin = new Padding(5, 0, 0, 0);

            this.top_tool_bar2.SearchClicked += new EventHandler(top_tool_bar2_SearchClicked);
            this.top_tool_bar2.LookClicked += new EventHandler(top_tool_bar2_LookClicked);
            this.top_tool_bar2.AddSearchAllModule();

            #endregion
        }

        void top_tool_bar2_LookClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.prodGrid.ActiveRow;
            if (row != null)
            {
                string code = row.Cells["PRDC_CompNo"].Value.ToString();
                Prod_Components comp = prodInstance.GetComponentModel(code);
                CompMange compFrm = new CompMange(comp, OperationTypeEnum.Look);
                compFrm.ShowDialog();
            }
        }

        void top_tool_bar_LookClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                string code = row.Cells["PRDC_CompNo"].Value.ToString();
                Prod_Components comp = prodInstance.GetComponentModel(code);
                CompMange compFrm = new CompMange(comp, OperationTypeEnum.Look);
                compFrm.ShowDialog();
            }
        }

        void top_tool_bar2_SearchClicked(object sender, EventArgs e)
        {
            string val1 = this.top_tool_bar2.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar2.GetSearchValue("eDate", "Date");
            string val3 = this.top_tool_bar2.GetSearchValue("Key", "Text");

            string where = string.Format(" AND CreateTime between '{1}' and '{2}' and (PRDC_ProdCode like '%{0}%' OR PRDC_CompCode like '%{0}%' OR PRDC_CompName like '%{0}%' OR PRDC_CompNo like '%{0}%') ", val3, val1, val2);

            DataTable dt = new BLL.Bll_Comm().ListViewData(string.Format("select * from VRpt_ProdCheck where 1=1 {0}",where));
            prodGrid.DataSource = dt;
        }

     

        void top_tool_bar_RefreshClicked(object sender, EventArgs e)
        {
            top_tool_bar_SearchClicked(null, null);
        }

        void top_tool_bar_SearchClicked(object sender, EventArgs e)
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");
            string val3 = this.top_tool_bar.GetSearchValue("Key", "Text");
            string where = string.Format(" AND CreateTime between '{1}' and '{2}' and (PRDC_ProdCode like '%{0}%' OR PRDC_CompCode like '%{0}%' OR PRDC_CompName like '%{0}%' OR PRDC_CompNo like '%{0}%') ", val3,val1,val2);
            DataTable dt = new BLL.Bll_Comm().ListViewData(string.Format("select * from VRpt_CompCheck where 1=1 {0} ",where));
            comGrid.DataSource = dt;
        }

        #endregion

        void Form_Load(object sender, EventArgs e)
        {
            InitControl();

            BindData();
        }

        public void InitControl()
        {
            comGrid = gen.GenerateGrid("CList_CompleteCheck", this.pnlDoc, new Point(0, 0));
            
            DataTable dt = new BLL.Bll_Comm().ListViewData(string.Format("select * from VRpt_CompCheck where 1>2 "));
            comGrid.DataSource = dt;

            prodGrid = gen.GenerateGrid("CList_ProdCheck", this.panel1, new Point(0, 0));
            
            DataTable dt1 = new BLL.Bll_Comm().ListViewData(string.Format("select * from VRpt_ProdCheck where 1>2 "));
            prodGrid.DataSource = dt1;
        }
    
        public void BindData()
        {
            //List<Prod_Pool> list = compInstance.GetInProdCompList();

            //comGrid.DataSource = list;

            //List<Prod_Pool> list1 = compInstance.GetAllProdCompList();
            //allGrid.DataSource = list1;
        }


    }
}
