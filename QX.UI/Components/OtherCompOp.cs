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
using System.Runtime.Remoting.Messaging;
using QX.BLL;
using QX.Log;
using QX.Gen.Shared;
using Infragistics.Win.UltraWinEditors;
using System.IO;
using QX.GenFramework.BseControl;
using QX.GenFramework.AutoForm;
using QX.GenFramework.Helper;

namespace QX.UI.Components
{
    public partial class OtherCompOp : Bse_PopForm
    {

        public OtherCompOp()
        {
            InitializeComponent();
        }

        UltraTextEditor compNoEditor = new UltraTextEditor();

        public OtherCompOp(Prod_Components item, OperationTypeEnum op)
        {
            InitializeComponent();
            opType = op;

            GModel = item;

            this.Load += new EventHandler(Form_Load);
            this.FormClosed += new FormClosedEventHandler(CompOp_FormClosed);
            BindTopTool();
        }



        void CompOp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CallBack != null)
            {
                CallBack(true);
            }
        }



        public delegate void DCallBackHandler(bool flag);
        public event DCallBackHandler CallBack;

        Bll_File fileInstance = new Bll_File();

        private Prod_Components GModel
        {
            get;
            set;
        }

        public void BindTopTool()
        {
            ToolBarHelper tsHelper = new ToolBarHelper();

            this.top_tool_bar.SaveClicked += new EventHandler(top_tool_bar_SaveClicked);


            ToolStripButton scanBtn = tsHelper.New("扫描", QX.GenFramework.Properties.Resources.gantan, new EventHandler(scanBtn_Click));

            this.top_tool_bar.AddCustomControl(scanBtn);
        }

        private delegate CC_File StartScanDelegate(string filepath, string dcode);

        List<CC_File> CCFileList = new List<CC_File>();

        ///// <summary>
        ///// 零件文档扫描
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void scanBtn_Click(object sender, EventArgs e)
        //{
        //    UltraGridRow row = this.comGrid.ActiveRow;
        //    if (row == null)
        //    {
        //        return;
        //    }
        //    Prod_Doc doc = row.ListObject as Prod_Doc;

        //    if (string.IsNullOrEmpty(doc.PRDQ_Code))
        //    {
        //        Alert.Show("请先填写报告编号!");
        //        return;
        //    }

        //    if (doc.PRDQ_IsScan == 1 && !row.IsAddRow)
        //    {
        //        ConfirmWin confirmWin = new ConfirmWin();
        //        confirmWin.ShowDialog();
        //        if (!confirmWin.IsAllow)
        //        {
        //            Alert.Show("当前文档已扫描，不能进行重复扫描覆盖操作!");
        //            return;
        //        }
        //    }

        //    var compNoEditor = bmHelper.FindCtl<UltraTextEditor>(this.gpBse.Controls, "PRDC_CompNo");
        //    string dcode = doc.PRDQ_Code;
        //    string compNo = string.Empty;
        //    if (compNoEditor != null)
        //    {
        //        compNo = compNoEditor.Text;
        //    }
        //    string filename = compNo + "_" + dcode + "_" + DateTime.Now.ToString("yyyy-MM-dd");
        //    CC_File file = new CC_File();
        //    try
        //    {
        //        //file =StartScan(filename, dcode); 
        //        StartScan(filename, dcode);
        //        row.Appearance.BackColor = Color.Wheat;
        //        doc.PRDQ_IsScan = 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        Alert.Show(ex.Message);
        //    }
        //}

        //public void StartScan(string filename, string dcode)
        //{

        //    CC_File file;
        //    PDFHelper pdf = new PDFHelper();

        //    bool flag = true;
        //    ScanHelper scan = new ScanHelper();

        //    var list = new List<Image>();
        //    try
        //    {

        //        list = scan.StartScan();


        //        //Image img = Image.FromFile("D:\\test.png");
        //        //list.Add(img);

        //    }
        //    catch (Exception ex)
        //    {
        //        //如果发生异常则之后则后面则不再提示信息
        //        flag = false;
        //        Alert.Show(ex.Message);
        //    }

        //    if (list != null && list.Count != 0)
        //    {
        //        var templist = list.ToList();

        //        string path = LocalPath + "\\" + filename + ".pdf";

        //        MethodInvoker mi = delegate
        //        {
        //            try
        //            {
        //                pdf.MakePDF(path, templist);
        //            }
        //            catch (Exception ex)
        //            {
        //                //Alert.Show("生成文档失败");
        //            }
        //            //Alert.Show("文档生成成功!");

        //            file = new CC_File();
        //            file.CCF_DCode = dcode;
        //            file.CCF_Name = filename;
        //            file.CCF_Directory = path;

        //            list = null;

        //            CCFileList.Add(file);

        //            SavePath();

        //            Alert.Show("文档生成成功!");
        //        };

        //        mi.BeginInvoke(null, null);

        //    }
        //    else
        //    {
        //        if (flag)
        //        {
        //            Alert.Show("未找到可扫描文件请确认扫描仪是否可用!");
        //        }

        //    }



        //}

        //private void ScanCallBack(IAsyncResult ar)
        //{
        //    // first case IAsyncResult to an AsyncResult object, so we can get the
        //    // delegate that was used to call the function.
        //    AsyncResult result = (AsyncResult)ar;

        //    // grab the delegate
        //    StartScanDelegate del =
        //        (StartScanDelegate)result.AsyncDelegate;

        //    // now that we have the delegate,
        //    // we must call EndInvoke on it, so we can get all
        //    // the information about our method call.

        //    CC_File file = del.EndInvoke(result);

        //    if (file != null)
        //    {
        //        CCFileList.Add(file);
        //    }
        //}

        //public void SavePath()
        //{

        //    Bll_Doc docInstance = new Bll_Doc();

        //    try
        //    {
        //        var compNoEditor = bmHelper.FindCtl<UltraTextEditor>(this.gpBse.Controls, "PRDC_CompNo");
        //        string compno = compNoEditor.Text;
        //        string parent = compno;
        //        Bll_File fileInstance = new Bll_File();
        //        //fileInstance.GotoDirectory(".");

        //        //if (!fileInstance.ftp.DirectoryExist(parent))
        //        //{
        //        //    try
        //        //    {

        //        //        fileInstance.ftp.MakeDirectory(parent);
        //        //    }
        //        //    catch
        //        //    {
        //        //        Alert.Show("请确认网路是否通畅!");
        //        //    }
        //        //}

        //        string lastpath = GlabolConfiguration.SeverPath + "\\" + parent;

        //        if (!Directory.Exists(lastpath))
        //        {
        //            try
        //            {
        //                Directory.CreateDirectory(lastpath);

        //            }
        //            catch (Exception ex)
        //            {

        //            }

        //        }

        //        //fileInstance.ftp.GotoDirectory(parent);

        //        foreach (var file in CCFileList)
        //        {
        //            //switch (opType)
        //            //{
        //            //    ///添加零件的话  需要创建零件编号文件夹
        //            //    case OperationTypeEnum.Add:
        //            //        {
        //            //var flag = fileInstance.UploadFile(file.CCF_Directory, true);

        //            //var flag = fileInstance.ftp.UploadLocalFileWithOverWrite(file.CCF_Directory);

        //            //if (flag)
        //            //{
        //            string source = file.CCF_Directory;
        //            file.CCF_Code = docInstance.GenerateCCFileCode();
        //            file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
        //            file.CCF_iType = "Other";
        //            file.CCF_CompNo = compno;
        //            docInstance.AddCCFile(file);

        //            File.Copy(source, lastpath + "\\" + file.CCF_Name + ".pdf", true);


        //            //}
        //            //        break;
        //            //    }
        //            //case OperationTypeEnum.Edit:
        //            //    {


        //            //        var flag = fileInstance.ftp.UploadLocalFileWithOverWrite(file.CCF_Directory);
        //            //        if (flag)
        //            //        {

        //            //            file.CCF_Code = docInstance.GenerateCCFileCode();
        //            //            file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
        //            //            file.CCF_iType = "Comp";
        //            //            file.CCF_CompNo = compno;
        //            //            docInstance.AddCCFile(file);
        //            //        }

        //            //        break;
        //            //    }
        //            //}

        //        }//当前窗体对应的零件文档上传 end

        //    }
        //    catch (Exception e)
        //    {
        //        //写入数据库日志
        //        PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
        //            "", "OtherCompOp",
        //           e.Message, PlateLog.LogMessageType.Error, e);
        //    }//保存完毕后清除需要上传的文件
        //    finally
        //    {
        //        //if (CCFileList.Count != 0)
        //        //{
        //        //    SyncProdDocument();
        //        //}


        //        CCFileList = new List<CC_File>();

        //    }

        //}

        //public void SyncProdDocument()
        //{
        //    if (!string.IsNullOrEmpty(GModel.PRDC_ProdCode))
        //    {

        //        var flag = fileInstance.ftp.GotoDirectory("./" + GModel.PRDC_CompNo);
        //        if (!flag)
        //        {
        //            return;
        //        }
        //        foreach (var f in fileInstance.ftp.ListFiles())
        //        {
        //            fileInstance.ftp.CopyFileToAnotherDirectoryOverWrite(f.Name, "./" + GModel.PRDC_ProdCode + "/" + GModel.PRDC_CompNo);
        //        }

        //    }
        //}

        //public void SyncDeleteDocument(List<CC_File> list)
        //{
        //    if (!string.IsNullOrEmpty(GModel.PRDC_ProdCode))
        //    {

        //        var flag = fileInstance.ftp.GotoDirectory("./" + GModel.PRDC_ProdCode + "/" + GModel.PRDC_CompNo);
        //        if (!flag)
        //        {
        //            return;
        //        }
        //        foreach (var f in list)
        //        {
        //            if (fileInstance.ftp.FileExist(f.CCF_Name + ".pdf"))
        //            {
        //                fileInstance.ftp.DeleteFile(f.CCF_Name + ".pdf");
        //            }
        //        }

        //    }
        //}

        ///// <summary>
        ///// 当发生删除操作时，进行文件同步
        ///// </summary>
        //public void DeleteDocument()
        //{
        //    List<CC_File> deleteFile = new List<CC_File>();
        //    try
        //    {
        //        BLL.Bll_File fileInstance = new QX.BLL.Bll_File();
        //        var d = comGrid.DataSource as BindingSource;
        //        var list = d.List as List<Prod_Doc>;
        //        fileInstance.GotoDirectory("./" + GModel.PRDC_CompNo);

        //        foreach (var dd in CurrentDataSource)
        //        {
        //            //如果已经删除则同步一次文件
        //            if (list.FirstOrDefault(o => o.PRDQ_Code == dd.CCF_DCode) == null)
        //            {

        //                var flag = fileInstance.ftp.FileExist(dd.CCF_Name + ".pdf");

        //                if (flag)
        //                {
        //                    fileInstance.ftp.DeleteFile(dd.CCF_Name + ".pdf");

        //                    deleteFile.Add(dd);
        //                    compInstance.DeleteDocument(dd);

        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //写入数据库日志
        //        PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
        //            "", this.Name + "|" + this.ToString(),
        //           ex.Message, PlateLog.LogMessageType.Error, ex);
        //    }
        //    finally
        //    {

        //        SyncDeleteDocument(deleteFile);
        //    }
        //}

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

        private BLL.Bll_Comp compInstance = new QX.BLL.Bll_Comp();

        public OperationTypeEnum opType
        {
            get;
            set;
        }

        #endregion

        public List<CC_File> CurrentDataSource
        {
            get;
            set;
        }

        //private Bll_Comp compInstance = new Bll_Comp();

        //本地存储路径
        public string LocalPath = string.Empty;
        private bool IsDeleted = false;

        void Form_Load(object sender, EventArgs e)
        {
            LocalPath = QX.Helper.XmlHelper.GetConfig("LocalPath");

            InitData();

            BindData();

            var comCode = bmHelper.FindCtl<UltraCombo>(this.gpBse.Controls, "PRDC_CompCode");
            if (comCode != null)
            {
                comCode.ValueChanged += new EventHandler(comCode_ValueChanged);
            }

            compNoEditor = bmHelper.FindCtl<UltraTextEditor>(this.gpBse.Controls, "PRDC_CompNo");
        }

        void comCode_ValueChanged(object sender, EventArgs e)
        {
            var uCom = (UltraCombo)sender;
            string val = uCom.Text;
            if (!string.IsNullOrEmpty(val))
            {
                List<Tpl_ReqDoc> dlist = LoadReqDoc(val);
                foreach (var d in dlist)
                {
                    UltraGridRow nrow = comGrid.DisplayLayout.Bands[0].AddNew();
                    nrow.Cells["PRDQ_IsNeed"].Value = d.TPRD_IsReq;
                    nrow.Cells["PRDQ_Name"].Value = d.TPRD_Name;
                }
            }
        }



        public List<Tpl_ReqDoc> LoadReqDoc(string code)
        {
            return compInstance.GetReqDocByComp(code);
        }

        public void InitData()
        {
            formHelper.GenerateForm("CForm_OtherDoc", this.gpBse, new Point(20, 20));

            gen.GenerateColumn("CList_OtherContent", comGrid, new Point(0, 0));

            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            comGrid.InitializeRow += new InitializeRowEventHandler(comGrid_InitializeRow);
            comGrid.AfterRowsDeleted += new EventHandler(comGrid_AfterRowsDeleted);
            comGrid.DoubleClickRow += new DoubleClickRowEventHandler(comGrid_DoubleClickRow);
            List<Prod_Doc> list = new List<Prod_Doc>();

            comGrid.DataSource = list;

            switch (opType)
            {
                case OperationTypeEnum.Add:
                    GModel.PRDC_CompNo = compInstance.GeneratePCompCode();
                    bmHelper.BindModelToControl<Prod_Components>(GModel, this.gpBse.Controls, "");
                    break;
                case OperationTypeEnum.Edit:
                    bmHelper.BindModelToControl<Prod_Components>(GModel, this.gpBse.Controls, "");
                    break;
                case OperationTypeEnum.Look:
                    top_tool_bar.SetButtonEnabled("save", false, true);
                    gen.SetGridReadOnly(comGrid, true);
                    break;
            }

        }

        void comGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UltraGridRow row = e.Row;
            if (row.Cells["CCF_Directory"].Value != null)
            {
                OpenFile(row.Cells["CCF_Directory"].Value.ToString());
            }
        }

        public void OpenFile(string path)
        {
            try
            {
                FileHelper.OpenFile(path);
            }
            catch (Exception e)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "OtherCompOp",
                   e.Message, PlateLog.LogMessageType.Error, e);
            }
        }

        void comGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            UltraGridRow row = e.Row;
            Prod_Doc doc = row.ListObject as Prod_Doc;
            if (doc.PRDQ_IsScan == 1)
            {
                row.Appearance.BackColor = Color.Wheat;
            }
        }

        void comGrid_AfterRowsDeleted(object sender, EventArgs e)
        {
            IsDeleted = true;
        }

        public void BindData()
        {
            bmHelper.BindModelToControl<Prod_Components>(GModel, this.gpBse.Controls, "");

            List<Prod_Doc> list = compInstance.GetProdDocByComp(GModel.PRDC_CompNo);
            List<CC_File> fileList = compInstance.GetCCFileListByComp(GModel.PRDC_CompNo);
            CurrentDataSource = fileList.ToList();
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
                    bmHelper.BindControlToModel<Prod_Components>(GModel, this.gpBse.Controls, "");
                    GModel.PRDC_iType = iTypeEnum.OtherComp.ToString();
                    var re = compInstance.AddComp(GModel);
                    //列表数据保存
                    SaveGrid();

                    if (re > 0)
                    {

                        GModel.PRDC_ID = re;
                        opType = OperationTypeEnum.Edit;
                        bmHelper.BindModelToControl<Prod_Components>(GModel, this.gpBse.Controls, "");

                    }
                    break;
                case OperationTypeEnum.Edit:
                    bmHelper.BindControlToModel<Prod_Components>(GModel, this.gpBse.Controls, "");

                    flag = compInstance.UpdateComp(GModel);
                    SaveGrid();
                    break;
                case OperationTypeEnum.Look:

                    break;
            }



            return flag;

        }

        /// <summary>
        /// 保存
        /// </summary>
        public void SaveGrid()
        {
            List<Prod_Doc> list = new List<Prod_Doc>();

            foreach (var row in comGrid.Rows)
            {
                Prod_Doc doc = row.ListObject as Prod_Doc;
                if (string.IsNullOrEmpty(doc.PRDQ_iType))
                {
                    doc.PRDQ_iType = iTypeEnum.Comp.ToString();
                }

                list.Add(doc);
            }

            compInstance.AddOrUpdateCDoc(GModel, list);

            //MethodInvoker mi = new MethodInvoker(this.SavePath);
            //mi.BeginInvoke(null, null);
        }


        /// <summary>
        /// 零件文档扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void scanBtn_Click(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
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

            if (doc.PRDQ_IsScan == 1 && !row.IsAddRow)
            {
                ConfirmWin confirmWin = new ConfirmWin();
                confirmWin.ShowDialog();
                if (!confirmWin.IsAllow)
                {
                    Alert.Show("当前文档已扫描，不能进行重复扫描覆盖操作!");
                    return;
                }
            }


            string dcode = doc.PRDQ_Code;
            string compNo = string.Empty;
            if (compNoEditor != null)
            {
                compNo = compNoEditor.Text;
            }
            string filename = compNo + "_" + dcode + "_" + DateTime.Now.ToString("yyyy-MM-dd");
            CC_File file = new CC_File();
            try
            {
                //file =StartScan(filename, dcode); 
                StartScan(filename, dcode);
                row.Appearance.BackColor = Color.Wheat;
                doc.PRDQ_IsScan = 1;
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }

            //if (file != null)
            //{
            //    //if (doc.PRDQ_ID != 0)
            //    //{
            //    //    file.Stat = 0;
            //    //}
            //    //CCFileList.Add(file);


            //}
        }


        #region 扫描

        ScanHelper scan = new ScanHelper();

        public void StartScan(string filename, string dcode)
        {

            //ScanHelperXP scan = new ScanHelperXP();
            CC_File file;
            PDFHelper pdf = new PDFHelper();

            bool flag = true;

            var list = new List<Image>();
            try
            {
              
                    list = scan.StartScan();
       


                //Image img = Image.FromFile("D:\\test.png");
                //list.Add(img);
                //Image img2 = Image.FromFile("D:\\2.bmp");
                //list.Add(img2);
                //Image img3 = Image.FromFile("D:\\2.bmp");
                //list.Add(img3);
                //Image img4 = Image.FromFile("D:\\2.bmp");
                //list.Add(img4);
                //Image img5 = Image.FromFile("D:\\2.bmp");
                //list.Add(img5);

            }
            catch (Exception ex)
            {
                //如果发生异常则之后则后面则不再提示信息
                flag = false;
                Alert.Show(ex.Message);
            }

            if (list != null && list.Count != 0)
            {
                var templist = list.ToList();

                string path = LocalPath + "\\" + filename + ".pdf";

                MethodInvoker mi = delegate
                {
                    try
                    {
                        pdf.MakePDF(path, templist);
                    }
                    catch (Exception ex)
                    {
                        //Alert.Show("生成文档失败");
                    }
                    //Alert.Show("文档生成成功!");

                    file = new CC_File();
                    file.CCF_DCode = dcode;
                    file.CCF_Name = filename;
                    file.CCF_Directory = path;

                    list = null;

                    CCFileList.Add(file);

                    SavePath();

                    Alert.Show("文档生成成功!");
                };

                mi.BeginInvoke(null, null);

            }
            else
            {
                if (flag)
                {
                    Alert.Show("未找到可扫描文件请确认扫描仪是否可用!");
                }

            }


        }

        private void ScanCallBack(IAsyncResult ar)
        {
            // first case IAsyncResult to an AsyncResult object, so we can get the
            // delegate that was used to call the function.
            AsyncResult result = (AsyncResult)ar;

            // grab the delegate
            StartScanDelegate del =
                (StartScanDelegate)result.AsyncDelegate;

            // now that we have the delegate,
            // we must call EndInvoke on it, so we can get all
            // the information about our method call.

            CC_File file = del.EndInvoke(result);

            if (file != null)
            {
                CCFileList.Add(file);
            }
        }

        public void SavePath()
        {

            Bll_Doc docInstance = new Bll_Doc();

            try
            {
                string compno = compNoEditor.Text;
                string parent = compno;
                Bll_File fileInstance = new Bll_File();
                //fileInstance.GotoDirectory(".");

                //if (!fileInstance.ftp.DirectoryExist(parent))
                //{
                //    try
                //    {

                //        fileInstance.ftp.MakeDirectory(parent);
                //    }
                //    catch
                //    {
                //        Alert.Show("请确认网路是否通畅!");
                //    }
                //}

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

                //fileInstance.ftp.GotoDirectory(parent);

                foreach (var file in CCFileList)
                {
                    //switch (opType)
                    //{
                    //    ///添加零件的话  需要创建零件编号文件夹
                    //    case OperationTypeEnum.Add:
                    //        {
                    //var flag = fileInstance.UploadFile(file.CCF_Directory, true);

                    //var flag = fileInstance.ftp.UploadLocalFileWithOverWrite(file.CCF_Directory);

                    //if (flag)
                    //{
                    string source = file.CCF_Directory;
                    file.CCF_Code = docInstance.GenerateCCFileCode();
                    file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
                    file.CCF_iType = "Other";
                    file.CCF_CompNo = compno;
                    docInstance.AddCCFile(file);

                    File.Copy(source, lastpath + "\\" + file.CCF_Name + ".pdf", true);


                    //}
                    //        break;
                    //    }
                    //case OperationTypeEnum.Edit:
                    //    {


                    //        var flag = fileInstance.ftp.UploadLocalFileWithOverWrite(file.CCF_Directory);
                    //        if (flag)
                    //        {

                    //            file.CCF_Code = docInstance.GenerateCCFileCode();
                    //            file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
                    //            file.CCF_iType = "Comp";
                    //            file.CCF_CompNo = compno;
                    //            docInstance.AddCCFile(file);
                    //        }

                    //        break;
                    //    }
                    //}

                }//当前窗体对应的零件文档上传 end

            }
            catch (Exception e)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "OtherCompOp",
                   e.Message, PlateLog.LogMessageType.Error, e);
            }//保存完毕后清除需要上传的文件
            finally
            {
                if (CCFileList.Count != 0)
                {
                    //SyncProdDocument();
                }


                CCFileList = new List<CC_File>();

            }

            //if (IsDeleted)
            //{
            //    DeleteDocument();
            //}
        }

       

        #endregion
    }
}
