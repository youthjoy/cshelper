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


namespace QX.UI.Document
{
    public partial class DocScan : Bse_PopForm
    {

        public DocScan()
        {
            InitializeComponent();
        }

        public DocScan(Prod_Pool item)
        {
            InitializeComponent();


            GModel = item;

            this.Load += new EventHandler(Form_Load);
            this.FormClosed += new FormClosedEventHandler(ProdIO_FormClosed);
            BindTopTool();
        }

        #region 图号及文档模板

        void ProdIO_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (CallBack != null)
            {
                CallBack(true);
            }

        }

        public delegate void DCallBackHandler(bool flag);
        public event DCallBackHandler CallBack;

        private Prod_Pool GModel
        {
            get;
            set;
        }

        

        public void BindTopTool()
        {
            this.top_tool_bar.SaveClicked += new EventHandler(top_tool_bar_SaveClicked);
        }

        void top_tool_bar_SaveClicked(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Alert.Show("数据更新完成!");
            }
        }

        #region 操作句柄
        private GridHelper gen = new GridHelper();

        FormHelper formHelper = new FormHelper();

        BindModelHelper bmHelper = new BindModelHelper();

        private BLL.Bll_Prod compInstance = new QX.BLL.Bll_Prod();

        private BLL.Bll_Doc docInstance = new QX.BLL.Bll_Doc();

        public OperationTypeEnum opType
        {
            get;
            set;
        }

        UltraGrid DocGrid = new UltraGrid();

        #endregion


        void Form_Load(object sender, EventArgs e)
        {
            InitData();

            BindData();

            BindDocTopTool();
            InitDocControl();
        }

        public void InitData()
        {
            //formHelper.GenerateForm("CForm_PPool", this.gpBse, new Point(20, 20));

            gen.GenerateColumn("CList_PC", comGrid, new Point(0, 0));
            comGrid.BeforeRowDeactivate += new CancelEventHandler(comGrid_BeforeRowDeactivate);
            comGrid.AfterRowActivate += new EventHandler(comGrid_AfterRowActivate);

            DocGrid = gen.GenerateGrid("CList_PDoc", this.splitContainer1.Panel2, new Point(0, 0));
            DocGrid.AfterRowActivate += new EventHandler(DocGrid_AfterRowActivate);
            List<Prod_Doc> dList = new List<Prod_Doc>();
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = dList;
            DocGrid.DataSource = dataSource;

            List<Prod_Components> list = new List<Prod_Components>();

            comGrid.DataSource = list;

            switch (opType)
            {
                case OperationTypeEnum.Add:
                    //GModel.PRP_ProdCode = compInstance.GenerateProdCode();
                    //bmHelper.BindModelToControl<Prod_Pool>(GModel, this.gpBse.Controls, "");
                    break;
                case OperationTypeEnum.Edit:
                    //bmHelper.BindModelToControl<Prod_Pool>(GModel, this.gpBse.Controls, "");
                    break;
            }

        }

        void DocGrid_AfterRowActivate(object sender, EventArgs e)
        {
            UltraGridRow row = this.DocGrid.ActiveRow;
            if (row != null)
            {
                Prod_Doc pc = row.ListObject as Prod_Doc;
                List<CC_File> list = docInstance.GetFileList(pc.PRDQ_Code);

                BindingSource dataSource = new BindingSource();
                dataSource.DataSource = list;
                refGrid.DataSource = list;
            }
        }

        void comGrid_AfterRowActivate(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Components comp = row.ListObject as Prod_Components;
                BindDocData(comp);
            }
        }

        public void BindDocData(Prod_Components comp)
        {
            if (comp != null)
            {
                var list = compInstance.GetDocByComponents(comp.PRDC_CompNo);
                BindingSource dataSource = new BindingSource();
                dataSource.DataSource = list;
                DocGrid.DataSource = dataSource;
            }
        }



        void comGrid_BeforeRowDeactivate(object sender, CancelEventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                SaveDoc();
            }
        }

        public void SaveDoc()
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                List<Prod_Doc> list = new List<Prod_Doc>();
                Prod_Components comp = row.ListObject as Prod_Components;

                if (comp == null)
                {
                    return;
                }

                foreach (var r in this.DocGrid.Rows)
                {
                    Prod_Doc doc = r.ListObject as Prod_Doc;
                    list.Add(doc);
                }

                compInstance.AddOrUpdatePDoc(comp, list);
            }
        }



        public void BindData()
        {
            List<Prod_Components> list = compInstance.GetPCompByProd(GModel.PRP_ProdCode);
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = list;
            comGrid.DataSource = dataSource;
        }

        public bool SaveData()
        {
            bool flag = true;
            switch (opType)
            {
                case OperationTypeEnum.Add:
                    //bmHelper.BindControlToModel<Prod_Pool>(GModel, this.gpBse.Controls, "");

                    //新添加的成品都是入库状态
                    GModel.PRP_iType = ProdStat.In.ToString();

                    var re = compInstance.AddProd(GModel);

                    if (re > 0)
                    {

                        GModel.PRP_ID = re;
                        opType = OperationTypeEnum.Edit;
                        //bmHelper.BindModelToControl<Prod_Pool>(GModel, this.gpBse.Controls, "");
                        //bmHelper.ClearControl<PC_CPlan>(GModel, this.gpOther.Controls, "");
                    }


                    break;
                case OperationTypeEnum.Edit:
                    //bmHelper.BindControlToModel<Prod_Pool>(GModel, this.gpBse.Controls, "");

                    flag = compInstance.PCUpdate(GModel);

                    break;
                case OperationTypeEnum.Look:

                    break;
            }
            SaveGrid();
            SaveDoc();
            return flag;

        }

        public void SaveGrid()
        {
            List<Prod_Components> list = new List<Prod_Components>();
            foreach (var row in comGrid.Rows)
            {
                Prod_Components doc = row.ListObject as Prod_Components;
                list.Add(doc);
            }

            compInstance.AddOrUpdatePComponents(GModel, list);
        }


        #endregion


        #region 文档存储信息

        UltraGrid refGrid = new UltraGrid();

        private BLL.Bll_File fileInstance = new QX.BLL.Bll_File();

        public void BindDocTopTool()
        {
            ToolBarHelper tsHelper = new ToolBarHelper();
            ToolStripButton scanRefBtn = tsHelper.New("扫描", QX.GenFramework.Properties.Resources.gantan, new EventHandler(scanBtn_Click));

            this.top_cctool_bar.AddCustomControl(scanRefBtn);
        }

        BLL.Bll_File fileHandler = new QX.BLL.Bll_File();

        /// <summary>
        /// 关联文档下载查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void scanBtn_Click(object sender, EventArgs e)
        {
            UltraGridRow row = this.DocGrid.ActiveRow;
            if (row == null)
            {
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path=dialog.FileName;
                CC_File file = row.ListObject as CC_File;

                fileHandler.DownloadFile(path, file.CCF_Directory);
            }
        }

        public void InitDocControl()
        {
            refGrid = gen.GenerateGrid("CList_CCFile", this.panel1, new Point(0, 0));
            List<CC_File> list = new List<CC_File>();

            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = list;
            refGrid.DataSource = dataSource;
        }


        public void BindDocData()
        {
            List<CC_File> list = compInstance.GetCCFileListByDCode("");

            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = list;
            refGrid.DataSource = dataSource;
        }


        #endregion
    }
}
