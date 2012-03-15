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
using System.IO;
using QX.BLL;
using System.Runtime.Remoting.Messaging;
using QX.Log;
using QX.Shared;
using Infragistics.Win.UltraWinEditors;
using QX.UI.Prod.Control;

namespace QX.UI.Prod
{
    /// <summary>
    /// 添加库存信息
    /// </summary>
    public partial class ProdIO : Bse_PopForm
    {
        public ProdIO()
        {
            InitializeComponent();
        }

        public ProdIO(Prod_Pool item, OperationTypeEnum op)
        {
            InitializeComponent();
            opType = op;

            GModel = item;

            this.Load += new EventHandler(Form_Load);
            this.FormClosed += new FormClosedEventHandler(ProdIO_FormClosed);
            BindTopTool();
        }

        private bool IsChanged = false;

        void ProdIO_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (CallBack != null && IsChanged)
            {
                CallBack(true);
            }

        }

        public delegate void DCallBackHandler(bool flag);
        public event DCallBackHandler CallBack;

        List<Prod_Components> CurrentSource
        {
            get;
            set;
        }

        /// <summary>
        /// 是否发生删除操作
        /// </summary>
        private bool IsDeleted
        {
            get;
            set;
        }

        /// <summary>
        /// 成品信息
        /// </summary>
        private Prod_Pool GModel
        {
            get;
            set;
        }
        ToolStripButton scanBtn;
        public void BindTopTool()
        {
            this.top_tool_bar.SaveClicked += new EventHandler(top_tool_bar_SaveClicked);
            ToolBarHelper tsHelper = new ToolBarHelper();
            scanBtn = tsHelper.New("扫描", QX.GenFramework.Properties.Resources.gantan, new EventHandler(scanBtn_Click));

            this.top_tool_barProd.AddCustomControl(scanBtn);


          
        }

        void scanRepairBtn_Click(object sender, EventArgs e)
        {
            UltraGridRow row = this.repairGrid.ActiveRow;
            if (row == null)
            {
                return;
            }
            Prod_Maintain doc = row.ListObject as Prod_Maintain;

            if (string.IsNullOrEmpty(doc.PRM_Code))
            {
                Alert.Show("请先填写报告编号!");
                return;
            }

            string dcode = doc.PRM_Code;
            var com = bmHelper.FindCtl<UltraTextEditor>(this.gpBse.Controls, "PRP_ProdCode");
            string prodcode = string.Empty;
            if (com != null)
            {
                prodcode = com.Text;
            }

            if (string.IsNullOrEmpty(prodcode))
            {
                Alert.Show("请先输入成品编号!");
                return;
            }

            string filename = prodcode + "_" + dcode + "_" + DateTime.Now.ToString("yyyy-MM-dd");
            CC_File file = new CC_File();
            try
            {
                StartScan(filename, dcode);
                row.Appearance.BackColor = Color.Wheat;
                
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        //本地存储路径
        public string LocalPath = string.Empty;

        /// <summary>
        /// 零件文档扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void scanBtn_Click(object sender, EventArgs e)
        {
            UltraGridRow row = this.prodDocGrid.ActiveRow;
            if (row == null)
            {
                return;
            }
            Prod_Doc doc = row.ListObject as Prod_Doc;

            if (string.IsNullOrEmpty(doc.PRDQ_Code))
            {
                Alert.Show("请先填写报告编号!");
                return;
            }

            string dcode = doc.PRDQ_Code;
            var com = bmHelper.FindCtl<UltraTextEditor>(this.gpBse.Controls, "PRP_ProdCode");
            string prodcode = string.Empty;
            if (com != null)
            {
                prodcode = com.Text;
            }

            if (string.IsNullOrEmpty(prodcode))
            {
                Alert.Show("请先输入成品编号!");
                return;
            }

            string filename = prodcode + "_" + dcode + "_" + DateTime.Now.ToString("yyyy-MM-dd");
            CC_File file = new CC_File();
            try
            {
                StartScan(filename, dcode);
                row.Appearance.BackColor = Color.Wheat;
                doc.PRDQ_IsScan = 1;
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        ScanHelper scan = new ScanHelper();

        public void StartScan(string filename, string dcode)
        {

            bool flag = true;
            CC_File file;
            PDFHelper pdf = new PDFHelper();
            List<Image> list = new List<Image>();
            try
            {
                //Image img = Image.FromFile("D:\\test.png");
                //list.Add(img);
                list = scan.StartScan();


            }
            catch (Exception ex)
            {
                flag = false;
                Alert.Show(ex.Message);
            }

            if (list != null && list.Count != 0)
            {

                var templist = list.ToList();
                //string path = Path.Combine(LocalPath, filename + ".pdf");
                string path = LocalPath + "\\" + filename + ".pdf";
                MethodInvoker mi = delegate
                {
                    try
                    {
                        pdf.MakePDF(path, templist);
                    }
                    catch
                    { }

                    //AutoClosedMessageBox.Show(" 文档生成成功!", " 提示", 15, 2000);
                    file = new CC_File();
                    file.CCF_DCode = dcode;
                    file.CCF_Name = filename;
                    file.CCF_iType = "Prod";
                    file.CCF_Directory = path;

                    list = null;
                    CCFileList.Add(file);
                    SavePath();

                    Alert.Show("文档生成成功!");
                };

                mi.BeginInvoke(null, null);

                //GC.Collect();

                //return file;

            }
            else
            {
                if (flag)
                {
                    Alert.Show("请确认是否已把扫描文档放到Feeder");
                }
                //return null;
            }


        }

        void top_tool_bar_SaveClicked(object sender, EventArgs e)
        {
            if (SaveData())
            {
                IsChanged = true;
                Alert.Show("数据更新完成!");
            }
        }

        #region 操作句柄
        private GridHelper gen = new GridHelper();

        FormHelper formHelper = new FormHelper();

        BindModelHelper bmHelper = new BindModelHelper();

        private BLL.Bll_Prod compInstance = new QX.BLL.Bll_Prod();

        public OperationTypeEnum opType
        {
            get;
            set;
        }
        //文档列表
        UltraGrid DocGrid = new UltraGrid();

        //维修列表
        UltraGrid repairGrid = new UltraGrid();

        UltraGrid prodDocGrid = new UltraGrid();

        List<CC_File> CCFileList = new List<CC_File>();
        #endregion

        UltraTextEditor compNoEditor = new UltraTextEditor();

        //UltraTextEditor compNoEditor = new UltraTextEditor();

        void Form_Load(object sender, EventArgs e)
        {
            LocalPath = QX.Helper.XmlHelper.GetConfig("LocalPath");

            InitData();

            BindData();

            compNoEditor = bmHelper.FindCtl<UltraTextEditor>(this.gpBse.Controls, "PRP_ProdCode");

            if (opType == OperationTypeEnum.Edit || opType == OperationTypeEnum.Look)
            {

                if (compNoEditor != null)
                {
                    //compNoEditor = compNo;
                    compNoEditor.KeyDown += new KeyEventHandler(comCode_KeyDown);

                }
            }

        }

        void comCode_KeyDown(object sender, KeyEventArgs e)
        {
            UltraTextEditor compNoEditor = (UltraTextEditor)sender;
            if (e.KeyCode == Keys.Enter)
            {
                string compNO = compNoEditor.Text;
                Prod_Pool comp = compInstance.GetProdPoolModel(compNO);
                if (comp != null)
                {
                    GModel = comp;
                    bmHelper.BindModelToControl<Prod_Pool>(GModel, this.gpBse.Controls, "");
                    comGrid.DataSource = new List<Prod_Components>();

                    DocGrid.DataSource = new List<Prod_Doc>();

                    prodDocGrid.DataSource = new List<Prod_Doc>();
                    repairGrid.DataSource = new List<Prod_Maintain>();
                    BindData();
                }
                else
                {
                    if (Alert.ShowIsConfirm("您输入的零件编码不存在,是否需要新建?"))
                    {
                        GModel.PRP_ProdCode = compNoEditor.Text;
                        opType = OperationTypeEnum.Add;
                        this.top_tool_bar.SetButtonEnabled("Save", true, true);
                        scanBtn.Enabled = true;
                        gen.SetGridReadOnly(comGrid, false);
                        comGrid.DataSource = new List<Prod_Components>();

                        DocGrid.DataSource = new List<Prod_Doc>();
                        repairGrid.DataSource = new List<Prod_Maintain>();
                        prodDocGrid.DataSource = new List<Prod_Doc>();

                        BindData();

                    }
                    else
                    {
                        compNoEditor.Text = GModel.PRP_ProdCode;
                    }
                }
            }
        }


        public void InitData()
        {
            IsDeleted = false;
            formHelper.GenerateForm("CForm_PPool", this.gpBse, new Point(20, 20));

            gen.GenerateColumn("CList_PC", comGrid, new Point(0, 0));
            //comGrid.BeforeRowDeactivate += new CancelEventHandler(comGrid_BeforeRowDeactivate);
            comGrid.BeforeEnterEditMode += new CancelEventHandler(comGrid_BeforeEnterEditMode);
            comGrid.AfterRowActivate += new EventHandler(comGrid_AfterRowActivate);
            comGrid.CellChange += new CellEventHandler(comGrid_CellChange);
            comGrid.AfterRowsDeleted += new EventHandler(comGrid_AfterRowsDeleted);
            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;

            List<Prod_Components> list = new List<Prod_Components>();

            comGrid.DataSource = list;

            DocGrid = gen.GenerateGrid("CList_PDoc", this.splitContainer1.Panel2, new Point(0, 0));
            DocGrid.DoubleClickRow += new DoubleClickRowEventHandler(DocGrid_DoubleClickRow);
            List<Prod_Doc> dList = new List<Prod_Doc>();
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = dList;
            DocGrid.DataSource = dataSource;



            #region 维修
            List<Prod_Maintain> dd = new List<Prod_Maintain>();
            repairGrid = gen.GenerateGrid("CList_PMaintain", pnlRepair, new Point(0, 0));
            repairGrid.DoubleClickRow += new DoubleClickRowEventHandler(repairGrid_DoubleClickRow);
            repairGrid.DataSource = dd;
            #endregion

            #region 成品文档

            prodDocGrid = gen.GenerateGrid("CList_ProdDoc", this.panel1, new Point(0, 0));
            prodDocGrid.DoubleClickRow += new DoubleClickRowEventHandler(prodDocGrid_DoubleClickRow);
            prodDocGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            List<Prod_Doc> pdlist = new List<Prod_Doc>();
            prodDocGrid.DataSource = pdlist;

            #endregion

            switch (opType)
            {
                case OperationTypeEnum.Add:
                    GModel.PRP_Type = "增速齿轮箱";
                    //GModel.PRP_ProdCode = compInstance.GenerateProdCode();
                    bmHelper.BindModelToControl<Prod_Pool>(GModel, this.gpBse.Controls, "");
                    break;
                case OperationTypeEnum.Edit:
                    bmHelper.BindModelToControl<Prod_Pool>(GModel, this.gpBse.Controls, "");
                    break;
                case OperationTypeEnum.Look:
                    top_tool_bar.SetButtonEnabled("save", false, true);
                    gen.SetGridReadOnly(comGrid, true);
                    break;
            }

        }

        void repairGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //UltraGridRow row = e.Row;
            //Prod_Doc doc = row.ListObject as Prod_Doc;
            //if (doc != null)
            //{
            //    OpenFile(doc.CCF_Directory, doc.PRDQ_CompNo);
            //}
            Prod_Maintain row = e.Row.ListObject as Prod_Maintain;
            ProdRepairOp op = new ProdRepairOp(row, OperationTypeEnum.Edit);
            op.CallBack += new ProdRepairOp.DCallBackHandler(op_CallBack);
            op.Show();
        }

        void op_CallBack(bool flag)
        {
            List<Prod_Maintain> list1 = compInstance.GetProdMaintainListByProdCode(GModel.PRP_ProdCode);
            repairGrid.DataSource = list1;
        }

        void comGrid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            UltraGridCell cell = this.comGrid.ActiveCell;
            if (cell != null && cell.Column.Key.Equals("PRDC_CompNo"))
            {
                CompSel compSel = new CompSel();
                compSel.CallBack += new CompSel.DCallBackHandler(compSel_CallBack);
                compSel.ShowDialog();
                e.Cancel = true;
            }
        }

        void compSel_CallBack(bool flag, List<Prod_Components> list)
        {
            if (flag)
            {
                var exsistSource = new List<Prod_Components>();
                foreach (var r in comGrid.Rows)
                {
                    var d = r.ListObject as Prod_Components;
                    exsistSource.Add(d);
                }

                List<Prod_Components> moreComp = new List<Prod_Components>();

                UltraGridRow arow = this.comGrid.ActiveRow;
                Prod_Components p = list[0];

                PropertyDescriptorCollection pc = TypeDescriptor.GetProperties(typeof(Prod_Components));

                //是否底部需要添加行
                bool flage = true;

                if (exsistSource.Exists(o => o.PRDC_CompNo == p.PRDC_CompNo))
                {
                    flage = false;
                    moreComp = list.Where(o => o.PRDC_ID != p.PRDC_ID).ToList();
                }
                else if (arow != null && arow.IsAddRow)
                {
                    var c = list[0];


                    foreach (UltraGridCell cell in arow.Cells)
                    {
                        if (cell.Column.IsBound)
                        {
                            object value = pc[cell.Column.Key].GetValue(c);
                            if (value != null)
                            {
                                arow.Cells[cell.Column.Key].Value = value;
                            }
                        }
                    }
                    //arow.Cells["PRDC_CompNo"].Value = c.PRDC_CompNo;
                    //arow.Cells["PRDC_CompCode"].Value = c.PRDC_CompCode;
                    //arow.Cells["PRDC_CompName"].Value = c.PRDC_CompName;
                    //arow.Cells["PRDC_Raw"].Value = c.PRDC_Raw;
                    //arow.Cells["PRDC_RecDate"].Value = c.PRDC_RecDate;
                    //arow.Cells["PRDC_SampleDate"].Value = c.PRDC_SampleDate;
                    moreComp = list.Where(o => o.PRDC_ID != c.PRDC_ID).ToList();

                }
                else
                {
                    moreComp = list;
                }

                foreach (var c in moreComp)
                {
                    if (exsistSource.Exists(o => o.PRDC_CompNo == c.PRDC_CompNo))
                    {
                        continue;
                    }

                    UltraGridRow row = this.comGrid.DisplayLayout.Bands[0].AddNew();

                    foreach (UltraGridCell cell in row.Cells)
                    {
                        if (cell.Column.IsBound)
                        {
                            object value = pc[cell.Column.Key].GetValue(c);
                            if (value != null)
                            {
                                row.Cells[cell.Column.Key].Value = value;
                            }
                        }
                    }


                    //row.Cells["PRDC_CompNo"].Value = c.PRDC_CompNo;
                    //row.Cells["PRDC_CompCode"].Value = c.PRDC_CompCode;
                    //row.Cells["PRDC_CompName"].Value = c.PRDC_CompName;
                    //row.Cells["PRDC_Raw"].Value = c.PRDC_Raw;
                    //row.Cells["PRDC_RecDate"].Value = c.PRDC_RecDate;
                    //row.Cells["PRDC_SampleDate"].Value = c.PRDC_SampleDate;

                }
                if (flage)
                {
                    this.comGrid.DisplayLayout.Bands[0].AddNew();
                }
            }
        }

        void prodDocGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UltraGridRow row = e.Row;
            Prod_Doc doc = row.ListObject as Prod_Doc;
            if (doc != null)
            {
                OpenFile(doc.CCF_Directory, doc.PRDQ_CompNo);
            }
        }

        void DocGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UltraGridRow row = e.Row;
            Prod_Doc doc = row.ListObject as Prod_Doc;
            if (doc != null)
            {
                OpenFile(doc.CCF_Directory, doc.PRDQ_CompNo);
            }
        }

        void comGrid_AfterRowsDeleted(object sender, EventArgs e)
        {
            IsDeleted = true;
        }

        void comGrid_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "PRDC_CompNo")
            {
                var d = e.Cell.Value;
                if (d != null)
                {
                    string code = d.ToString();
                    Prod_Components p = compInstance.GetComponentsModel(code);

                    BindComponentsRow(p, e.Cell.Row);
                    var list = GetTDocList(code);
                    LoadTDoc(list);
                }
            }
        }

        private void BindComponentsRow(Prod_Components p, UltraGridRow row)
        {
            PropertyDescriptorCollection pp = TypeDescriptor.GetProperties(typeof(Prod_Components));
            foreach (UltraGridCell c in row.Cells)
            {
                if (pp[c.Column.Key].GetValue(p) != null)
                {
                    c.Value = pp[c.Column.Key].GetValue(p);
                }
            }
        }

        /// <summary>
        /// 文档信息绑定
        /// </summary>
        /// <param name="list"></param>
        private void LoadTDoc(List<Prod_Doc> list)
        {
            DocGrid.DataSource = list;
        }

        //零件操作句柄
        private BLL.Bll_Comp cpInstance = new QX.BLL.Bll_Comp();

        /// <summary>
        /// 获取文档相关列表信息
        /// </summary>
        /// <param name="compCode"></param>
        /// <returns></returns>
        private List<Prod_Doc> GetTDocList(string compCode)
        {
            List<Prod_Doc> list = cpInstance.GetProdDocByCompForProd(compCode);
            return list;
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

        /// <summary>
        /// 零件关联文档数据绑定
        /// </summary>
        /// <param name="comp"></param>
        public void BindDocData(Prod_Components comp)
        {
            if (comp != null)
            {
                var list = compInstance.GetProdDocByCompForProd(comp.PRDC_CompNo);
                BindingSource dataSource = new BindingSource();
                if (list != null)
                {
                    dataSource.DataSource = list;
                }
                else
                {
                    dataSource.DataSource = new List<Prod_Doc>();
                }

                DocGrid.DataSource = dataSource;
            }
        }

        #region 暂时不适用
        //void comGrid_BeforeRowDeactivate(object sender, CancelEventArgs e)
        //{
        //    UltraGridRow row = this.comGrid.ActiveRow;
        //    if (row != null)
        //    {
        //        //List<Prod_Doc> list = new List<Prod_Doc>();
        //        //Prod_Components comp = row.ListObject as Prod_Components;
        //        //foreach (var r in this.DocGrid.Rows)
        //        //{
        //        //    Prod_Doc doc = r.ListObject as Prod_Doc;
        //        //    list.Add(doc);
        //        //}
        //        //UltraGridRow row = this.comGrid.ActiveRow;
        //        //SaveDoc();
        //    }
        //}

        //public void SaveDoc()
        //{
        //    UltraGridRow row = this.comGrid.ActiveRow;
        //    if (row != null)
        //    {
        //        List<Prod_Doc> list = new List<Prod_Doc>();
        //        Prod_Components comp = row.ListObject as Prod_Components;

        //        if (comp == null)
        //        {
        //            return;
        //        }
        //        foreach (var r in this.DocGrid.Rows)
        //        {
        //            Prod_Doc doc = r.ListObject as Prod_Doc;
        //            list.Add(doc);
        //        }

        //        compInstance.AddOrUpdatePDoc(comp, list);
        //    }
        //}

        //public void SaveDoc(UltraGridRow row)
        //{
        //    //UltraGridRow row = this.comGrid.ActiveRow;
        //    if (row != null)
        //    {
        //        List<Prod_Doc> list = new List<Prod_Doc>();
        //        Prod_Components comp = row.ListObject as Prod_Components;
        //        foreach (var r in this.DocGrid.Rows)
        //        {
        //            Prod_Doc doc = r.ListObject as Prod_Doc;
        //            list.Add(doc);
        //        }
        //        compInstance.AddOrUpdatePDoc(comp, list);
        //    }
        //}
        #endregion

        /// <summary>
        /// 成品信息绑定
        /// </summary>
        public void BindData()
        {
            bmHelper.BindModelToControl<Prod_Pool>(GModel, this.gpBse.Controls, "");

            List<Prod_Components> list = compInstance.GetPCompByProd(GModel.PRP_ProdCode);
            CurrentSource = list.ToList();
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = list;
            comGrid.DataSource = dataSource;

            ///成品维修情况
            List<Prod_Maintain> list1 = compInstance.GetProdMaintainListByProdCode(GModel.PRP_ProdCode);
            repairGrid.DataSource = list1;

            //成品文档
            List<Prod_Doc> list2 = compInstance.GetDocByProdCode(GModel.PRP_ProdCode);
            //CurrentSource = list.ToList();
            BindingSource dataSource2 = new BindingSource();
            dataSource2.DataSource = list2;
            this.prodDocGrid.DataSource = dataSource2;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public bool SaveData()
        {
            bool flag = true;
            switch (opType)
            {
                case OperationTypeEnum.Add:
                    bmHelper.BindControlToModel<Prod_Pool>(GModel, this.gpBse.Controls, "");

                    if (string.IsNullOrEmpty(GModel.PRP_ProdCode))
                    {
                        Alert.Show("成品编号不能为空!");
                        return false;
                    }

                    //新添加的成品都是入库状态
                    GModel.PRP_iType = ProdStat.In.ToString();

                    var re = compInstance.AddProd(GModel);

                    if (re > 0)
                    {

                        GModel.PRP_ID = re;
                        opType = OperationTypeEnum.Edit;
                        bmHelper.BindModelToControl<Prod_Pool>(GModel, this.gpBse.Controls, "");
                        //bmHelper.ClearControl<PC_CPlan>(GModel, this.gpOther.Controls, "");
                    }


                    break;
                case OperationTypeEnum.Edit:
                    bmHelper.BindControlToModel<Prod_Pool>(GModel, this.gpBse.Controls, "");

                    flag = compInstance.PCUpdate(GModel);

                    break;
                case OperationTypeEnum.Look:

                    break;
            }
            SaveGrid();
            SaveProdDocGrid();
            MethodInvoker mi = new MethodInvoker(this.SyncDocument);
            mi.BeginInvoke(new AsyncCallback(SyncCallBack), null);

            //如果存在删除操作，则进行数据同步
            if (IsDeleted)
            {
                MethodInvoker mik = new MethodInvoker(DeleteDocument);
                mik.BeginInvoke(null, null);
            }

            return flag;

        }

        public void SyncCallBack(IAsyncResult ar)
        {
            // first case IAsyncResult to an AsyncResult object, so we can get the
            // delegate that was used to call the function.
            AsyncResult result = (AsyncResult)ar;

            // grab the delegate
            MethodInvoker del =
                (MethodInvoker)result.AsyncDelegate;

            // now that we have the delegate,
            // we must call EndInvoke on it, so we can get all
            // the information about our method call.
            try
            {
                del.EndInvoke(result);
            }
            catch (Exception ex)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "ProdIO",
                   ex.Message, PlateLog.LogMessageType.Error, ex);
            }

        }
        /// <summary>
        /// 文档同步（对于添加的文档）
        /// </summary>
        public void SyncDocument()
        {

            try
            {
                //BLL.Bll_File fileInstance = new QX.BLL.Bll_File();
                Bll_Doc docInstance = new Bll_Doc();

                //建立成品文件夹（是否存在）
                if (!fileInstance.ftp.DirectoryExist(GModel.PRP_ProdCode))
                {
                    try
                    {
                        fileInstance.ftp.MakeDirectory(GModel.PRP_ProdCode);
                    }
                    catch (Exception ex)
                    {
                        //写入数据库日志
                        PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                            "", "ProdIO",
                           ex.Message, PlateLog.LogMessageType.Error, ex);
                    }
                }
                ///获取文档列表
                var cclist = compInstance.GetCCFileListByComp(PCompList);

                string basePath = "./" + GModel.PRP_ProdCode;

                //移动相应的零件文档到该成品文件夹（先建立零件文件夹->移动文件）
                foreach (var c in PCompList)
                {
                    string compPath = c.PRDC_CompNo;
                    string remotePath = basePath + "/" + compPath;

                    //使当前目录置于成品文件夹中
                    fileInstance.GotoDirectory(basePath);
                    //对应的成品文件夹中该零件编号文件夹是否存在，不存在则创建
                    if (!fileInstance.ftp.DirectoryExist(compPath))
                    {
                        try
                        {
                            //创建零件编号文件夹
                            fileInstance.ftp.MakeDirectory(compPath);
                        }
                        catch (Exception ee)
                        {  //写入数据库日志
                            PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                                "", "ProdIO 写入零件",
                               ee.Message, PlateLog.LogMessageType.Error, ee);

                        }
                    }
                    //进入零件原文档存储目录
                    fileInstance.GotoDirectory("./" + compPath);
                    var templist = cclist.Where(o => o.CCF_CompNo == c.PRDC_CompNo);
                    foreach (var f in templist)
                    {
                        string name = Path.GetFileName(f.CCF_Directory);

                        fileInstance.ftp.CopyFileToAnotherDirectoryOverWrite(name, remotePath);
                        //把零件对应的存储目录更新一遍（融入到相应成品文件夹中）
                        //f.CCF_Directory = "/" + GModel.PRP_ProdCode+f.CCF_Directory;
                        //docInstance.UpdateCCFile(f);

                    }
                }
            }
            catch (Exception ex)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "ProdIO",
                   ex.Message, PlateLog.LogMessageType.Error, ex);
            }
        }


        /// <summary>
        /// 当发生删除操作时，进行文件同步
        /// </summary>


        private List<Prod_Components> PCompList
        {
            get;
            set;
        }


        public void SaveGrid()
        {
            //List<Prod_Components> list = new List<Prod_Components>();
            PCompList = null;
            PCompList = new List<Prod_Components>();


            foreach (var row in comGrid.Rows)
            {
                Prod_Components doc = row.ListObject as Prod_Components;
                if (PCompList.FirstOrDefault(o => o.PRDC_CompNo == doc.PRDC_CompNo) != null)
                {
                    continue;
                }
                PCompList.Add(doc);
            }

            compInstance.AddOrUpdatePComponents(GModel, PCompList);


        }

        public void SaveProdDocGrid()
        {

            List<Prod_Doc> list = new List<Prod_Doc>();


            foreach (var row in this.prodDocGrid.Rows)
            {
                Prod_Doc doc = row.ListObject as Prod_Doc;
                if (string.IsNullOrEmpty(doc.PRDQ_iType))
                {
                    doc.PRDQ_iType = "Prod";
                }


                list.Add(doc);
            }

            compInstance.AddOrUpdateCDoc(GModel, list);



            //MethodInvoker mi = new MethodInvoker(this.SavePath);
            //mi.BeginInvoke(null, null);

        }

        Bll_File fileInstance = new Bll_File();

        public void SavePath()
        {

            Bll_Doc docInstance = new Bll_Doc();
            Bll_File fileInstance1 = new Bll_File();

            try
            {
                string parent = compNoEditor.Text;
                string lastpath = GlabolConfiguration.SeverPath + "\\" + parent;
                if (!Directory.Exists(lastpath))
                {
                    try
                    {
                        Directory.CreateDirectory(lastpath);

                    }
                    catch (Exception ex)
                    {

                    }

                }


                foreach (var file in CCFileList)
                {
                    string source = file.CCF_Directory;
                    file.CCF_Code = docInstance.GenerateCCFileCode();
                    file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
                    file.CCF_iType = "Prod";
                    file.CCF_CompNo = parent;
                    docInstance.AddCCFile(file);

                    File.Copy(source, lastpath + "\\" + file.CCF_Name + ".pdf", true);

                }

                //fileInstance1.GotoDirectory(".");
                //if (!fileInstance1.ftp.DirectoryExist(parent))
                //{
                //    try
                //    {
                //        fileInstance1.ftp.MakeDirectory(parent);
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}

                //fileInstance1.ftp.GotoDirectory(parent);


                //foreach (var file in CCFileList)
                //{
                //    switch (opType)
                //    {

                //        case OperationTypeEnum.Add:
                //            {
                //                var flag = fileInstance1.ftp.UploadLocalFileWithOverWrite(file.CCF_Directory);

                //                if (flag)
                //                {

                //                    file.CCF_Code = docInstance.GenerateCCFileCode();
                //                    file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
                //                    file.CCF_iType = "Prod";
                //                    file.CCF_CompNo = parent;
                //                    docInstance.AddCCFile(file);
                //                }
                //                break;
                //            }
                //        case OperationTypeEnum.Edit:
                //            {


                //                var flag = fileInstance1.ftp.UploadLocalFileWithOverWrite(file.CCF_Directory);

                //                if (flag)
                //                {

                //                    file.CCF_Code = docInstance.GenerateCCFileCode();
                //                    file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
                //                    file.CCF_iType = "Prod";
                //                    file.CCF_CompNo = parent;
                //                    docInstance.AddCCFile(file);
                //                }

                //                break;
                //            }
                //    }

                //}//当前窗体对应的零件文档上传


            }
            catch (Exception e)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "ProdIO",
                   e.Message, PlateLog.LogMessageType.Error, e);
            }//保存完毕后清除需要上传的文件
            finally
            {

                CCFileList = new List<CC_File>();
            }

            //if (IsDeleted)
            //{
            //    DeleteDocument();
            //}
        }

        public List<CC_File> CurrentDataSource
        {
            get;
            set;
        }

        /// <summary>
        /// 当发生删除操作时，进行文件同步
        /// </summary>
        public void DeleteDocument()
        {
            List<CC_File> deleteFile = new List<CC_File>();
            try
            {
                BLL.Bll_File fileInstance = new QX.BLL.Bll_File();
                var d = this.prodDocGrid.DataSource as BindingSource;
                var list = d.List as List<Prod_Doc>;
                fileInstance.GotoDirectory("./" + GModel.PRP_ProdCode);

                foreach (var dd in CurrentDataSource)
                {
                    //如果已经删除则同步一次文件
                    if (list.FirstOrDefault(o => o.PRDQ_Code == dd.CCF_DCode) == null)
                    {

                        var flag = fileInstance.ftp.FileExist(dd.CCF_Name + ".pdf");

                        if (flag)
                        {
                            fileInstance.ftp.DeleteFile(dd.CCF_Name + ".pdf");

                            deleteFile.Add(dd);
                            compInstance.DeleteDocument(dd);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "ProdIO",
                   ex.Message, PlateLog.LogMessageType.Error, ex);
            }
            finally
            {
            }
        }

        public void OpenFile(string path, string folder)
        {

            MethodInvoker mi = delegate
            {
                try
                {
                    FileHelper.OpenFile(path);
                }
                catch (Exception e)
                {
                    //写入数据库日志
                    PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                        "", "ProdIO",
                       e.Message, PlateLog.LogMessageType.Error, e);
                }
                //string temppath = path;
                //string remoteFileName = Path.GetFileName(temppath);
                //Bll_File fileInstance = new Bll_File();
                //try
                //{
                //    fileInstance.ftp.GotoDirectory(".");
                //    if (fileInstance.ftp.DirectoryExist(folder))
                //    {
                //        fileInstance.ftp.GotoDirectory(folder);
                //        if (fileInstance.ftp.FileExist(remoteFileName))
                //        {
                //            string basePath = QX.Helper.XmlHelper.GetConfig("LocalPath");
                //            string filename = Path.Combine(basePath, remoteFileName);
                //            if (File.Exists(filename))
                //            {
                //                File.Delete(filename);
                //            }
                //            fileInstance.ftp.DownloadFile(remoteFileName, basePath);

                //            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                //            proc.StartInfo.FileName = Path.Combine(basePath, remoteFileName);
                //            ////打开资源管理器
                //            //proc.StartInfo.Arguments = @"/select,"+path;
                //            //选中"这个路径的"这个程序,即记事本
                //            proc.Start();
                //        }
                //        else
                //        {
                //            Alert.Show("未找到与当前选中行对应的文档!");
                //        }

                //    }
                //}

                //catch (Exception e)
                //{
                //    //写入数据库日志
                //    PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                //        "", "ProdIO",
                //       e.Message, PlateLog.LogMessageType.Error, e);
                //}

            };

            mi.BeginInvoke(null, null);

            //           打开文件夹： sfd为SaveFileDialog的实例
            //System.Diagnostics.Process.Start("explorer.exe",sfd.FileName.Substring(0,sfd.FileName.LastIndexOf(@"\")));
            //System.Diagnostics.Process.Start("explorer.exe", "/select,"+path);

        }

    }
}
