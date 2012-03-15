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
using System.Runtime.Remoting.Messaging;
using QX.BLL;
using QX.Log;
using QX.GenFramework.Shared;
using System.IO;
using System.Diagnostics;
using Infragistics.Win.UltraWinEditors;
using QX.UI.Comm;

namespace QX.UI.Components
{
    /// <summary>
    /// 零件维护
    /// </summary>
    public partial class CompMange : Bse_PopForm
    {

        public CompMange()
        {
            InitializeComponent();
        }

        UltraTextEditor compNoEditor = new UltraTextEditor();
        public CompMange(Prod_Components item, OperationTypeEnum op)
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
                ///如果不是查看状态 则关闭窗口进行刷新
                if (opType != OperationTypeEnum.Look)
                {
                    CallBack(true);
                }
            }
        }



        public delegate void DCallBackHandler(bool flag);
        public event DCallBackHandler CallBack;

        //Bll_File fileInstance = new Bll_File();


        /// <summary>
        /// 零件文档
        /// </summary>
        UltraGrid comGrid = new UltraGrid();


        UltraGrid otherCompGrid = new UltraGrid();

        private Prod_Components GModel
        {
            get;
            set;
        }

        ToolStripButton scanBtn;

        ComboBox comboStat = new ComboBox();

        public void BindTopTool()
        {
            ToolBarHelper tsHelper = new ToolBarHelper();

            this.top_tool_bar.SaveClicked += new EventHandler(top_tool_bar_SaveClicked);


            scanBtn = tsHelper.New("扫描", QX.GenFramework.Properties.Resources.gantan, new EventHandler(scanBtn_Click));

            this.top_tool_bar.AddCustomControl(scanBtn);

            Bll_Bse_Dict dcInstance = new Bll_Bse_Dict();
            List<Bse_Dict> list = dcInstance.GetDictByKey("ScanMode");

            comboStat.DataSource = list;
            comboStat.DisplayMember = "Dict_Name";
            comboStat.ValueMember = "Dict_Code";
            comboStat.Tag = list;



            ToolStripControlHost comboStatHost = new ToolStripControlHost(comboStat);
            comboStatHost.Margin = new Padding(5, 0, 0, 0);
            this.top_tool_bar.AddCustomControl(6, comboStatHost);


        }

        private delegate CC_File StartScanDelegate(string filepath, string dcode);

        List<CC_File> CCFileList = new List<CC_File>();

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
                if (comboStat.SelectedValue != null && comboStat.SelectedValue.ToString() == "Duplex")
                {
                    list = scan.StartScan(1);
                }
                else
                {
                    list = scan.StartScan();
                }


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

                    SaveDictionary();

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
                    string source = file.CCF_Directory;
                    file.CCF_Code = docInstance.GenerateCCFileCode();
                    file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
                    file.CCF_iType = "Comp";
                    file.CCF_CompNo = parent;
                    docInstance.AddCCFile(file);
                    File.Copy(source, lastpath + "\\" + file.CCF_Name + ".pdf", true);

                }//当前窗体对应的零件文档上传 end

                foreach (var cc in CCFileList)
                {
                    SaveRefPath(cc);
                }
            }
            catch (Exception e)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "CompManage",
                   e.Message, PlateLog.LogMessageType.Error, e);
            }//保存完毕后清除需要上传的文件
            finally
            {
                if (CCFileList.Count != 0)
                {
                    SyncProdDocument();
                }


                CCFileList = new List<CC_File>();

            }

            //if (IsDeleted)
            //{
            //    DeleteDocument();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cc">当前文档</param>
        public void SaveRefPath(CC_File cc)
        {
            Bll_File fileInstance = new Bll_File();
            //如果存在该文档
            if (RefCompList.Keys.Contains(cc.CCF_DCode))
            {
                var compList = RefCompList[cc.CCF_DCode];

                foreach (var comp in compList)
                {
                    string lastpath = GlabolConfiguration.SeverPath + "\\" + comp.PRDC_CompNo;
                    if (!Directory.Exists(lastpath))
                    {
                        try
                        {
                            Directory.CreateDirectory(lastpath);
                        }
                        catch (Exception ex)
                        {
                            //写入数据库日志
                            PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                                "", "CompManage 多零件同步",
                               ex.Message, PlateLog.LogMessageType.Error, ex);
                        }
                    }
                    //fileInstance.ftp.GotoDirectory(".");

                    //if (!fileInstance.ftp.DirectoryExist(comp.PRDC_CompNo))
                    //{
                    //    fileInstance.ftp.MakeDirectory(comp.PRDC_CompNo);
                    //}

                    //fileInstance.ftp.GotoDirectory("." + Path.GetDirectoryName(cc.CCF_Directory));

                    //var flag = fileInstance.ftp.CopyFileToAnotherDirectoryOverWrite(Path.GetFileName(cc.CCF_Directory), "./" + comp.PRDC_CompNo);

                    File.Copy(GlabolConfiguration.SeverPath + cc.CCF_Directory.Replace('/', '\\'), lastpath + "\\" + cc.CCF_Name + ".pdf");

                }
            }
        }

        //public void SyncProdDocument()
        //{
        //    Bll_File fileInstance = new Bll_File();
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
        public void SyncProdDocument()
        {

            Bll_File fileInstance = new Bll_File();
            if (!string.IsNullOrEmpty(GModel.PRDC_ProdCode))
            {
                string parent = GModel.PRDC_CompNo;
                //共享文件目标路径(零件)
                string lastpath = GlabolConfiguration.SeverPath + "\\" + parent;

                string descPath = GlabolConfiguration.SeverPath + "\\" + GModel.PRDC_ProdCode + "\\" + parent;

                if (!Directory.Exists(descPath))
                {
                    try
                    {
                        Directory.CreateDirectory(lastpath);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                CopyFile(lastpath, descPath);

            }
        }

        public void CopyFile(string srcPath, string aimPath)
        {
            if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
            {
                aimPath += Path.DirectorySeparatorChar;
            }

            //判断目标目录是否存在
            if (!Directory.Exists(aimPath))
            {
                Directory.CreateDirectory(aimPath);
            }

            //得到源目录的文件列表
            string[] fileList = Directory.GetFileSystemEntries(srcPath);

            //遍历所有文件和目录
            foreach (string file in fileList)
            {
                //先当初目录处理如果存在这个目录就递归copy该目录下面的文件
                if (Directory.Exists(file))
                {
                    CopyFile(file, aimPath + Path.GetFileName(file));
                }
                else
                {
                    File.Copy(file, aimPath + Path.GetFileName(file), true);
                }

            }
        }

        public void SyncDeleteDocument(List<CC_File> list)
        {
            Bll_File fileInstance = new Bll_File();
            try
            {
                if (!string.IsNullOrEmpty(GModel.PRDC_ProdCode))
                {

                    var flag = fileInstance.ftp.GotoDirectory("./" + GModel.PRDC_ProdCode + "/" + GModel.PRDC_CompNo);
                    if (!flag)
                    {
                        return;
                    }
                    foreach (var f in list)
                    {
                        if (fileInstance.ftp.FileExist(f.CCF_Name + ".pdf"))
                        {
                            fileInstance.ftp.DeleteFile(f.CCF_Name + ".pdf");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "CompManage",
                   ex.Message, PlateLog.LogMessageType.Error, ex);
            }
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
                var d = comGrid.DataSource as BindingSource;
                var list = d.List as List<Prod_Doc>;
                fileInstance.GotoDirectory("./" + GModel.PRDC_CompNo);
                //与原数据源对比 
                foreach (var dd in CurrentDataSource)
                {
                    //如果已经删除则同步一次文件
                    if (list.FirstOrDefault(o => o.PRDQ_Code == dd.CCF_DCode) == null)
                    {
                        List<Prod_Doc> ll = compInstance.GetPDocBySelf(dd.CCF_DCode);
                        if (ll.Count != 1)
                        {
                            continue;
                        }
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
                    "", "CompManage",
                   ex.Message, PlateLog.LogMessageType.Error, ex);
            }
            finally
            {

                SyncDeleteDocument(deleteFile);
            }
        }

        #endregion

        void confirmWin_CallBack(bool flag)
        {

        }

        

        void top_tool_bar_SaveClicked(object sender, EventArgs e)
        {
            if (SaveData())
            {
                //this.Close();
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

        private List<Prod_Components> ExsistComponentSource
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
            //Stopwatch watch = new Stopwatch();
            //watch.Start();

            InitData();

            BindData();

            BindEvent();

            var comCode = bmHelper.FindCtl<UltraCombo>(this.gpBse.Controls, "PRDC_CompCode");

            if (comCode != null)
            {
                //comCode.ValueChanged += new EventHandler(comCode_ValueChanged);
                comCode.KeyDown += new KeyEventHandler(comCode_KeyDown);
            }

            compNoEditor = bmHelper.FindCtl<UltraTextEditor>(this.gpBse.Controls, "PRDC_CompNo");

            if (opType == OperationTypeEnum.Edit || opType == OperationTypeEnum.Look)
            {

                if (compNoEditor != null)
                {
                    //compNoEditor = compNo;
                    compNoEditor.KeyDown += new KeyEventHandler(comNoedito_KeyDown);

                }
            }

            ExsistComponentSource = compInstance.GetPComponentsList();
            //watch.Stop();

            //MessageBox.Show(watch.Elapsed.ToString());
        }



        /// <summary>
        /// 零件编号 回车事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comNoedito_KeyDown(object sender, KeyEventArgs e)
        {
            UltraTextEditor compNoEditor = (UltraTextEditor)sender;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string compNO = compNoEditor.Text;
                    Prod_Components comp = compInstance.GetCompModel(compNO);
                    if (comp != null)
                    {
                        GModel = comp;
                        bmHelper.BindModelToControl<Prod_Components>(GModel, this.gpBse.Controls, "");
                        comGrid.DataSource = new List<Prod_Doc>();
                        otherCompGrid.DataSource = new List<Prod_Components>();
                        BindData();
                    }
                    else
                    {
                        if (Alert.ShowIsConfirm("您输入的零件编码不存在,是否需要新建?"))
                        {
                            GModel.PRDC_CompNo = compNoEditor.Text;
                            opType = OperationTypeEnum.Add;
                            this.top_tool_bar.SetButtonEnabled("Save", true, true);
                            scanBtn.Enabled = true;
                            gen.SetGridReadOnly(comGrid, false);
                            comGrid.DataSource = new List<Prod_Doc>();
                            otherCompGrid.DataSource = new List<Prod_Components>();
                            BindData();
                            var comCode = bmHelper.FindCtl<UltraCombo>(this.gpBse.Controls, "PRDC_CompCode");
                            comCode_KeyDown(comCode, null);
                        }
                        else
                        {
                            compNoEditor.Text = GModel.PRDC_CompNo;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //写入数据库日志
                    PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                        "", "CompManage",
                       ex.Message, PlateLog.LogMessageType.Error, ex);
                }
            }
        }

        /// <summary>
        /// 零件图号 回车事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var uCom = (UltraCombo)sender;
                string val = uCom.Text;
                if (!string.IsNullOrEmpty(val))
                {
                    try
                    {
                        List<Tpl_ReqDoc> dlist = LoadReqDoc(val);
                        comGrid.EventManager.SetEnabled(EventGroups.AllEvents, false);
                        Bll_Bse_Dict dictInstance = new Bll_Bse_Dict();
                        comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
                        var dictList = dictInstance.GetDictByKey("DocType");
                        foreach (var d in dlist)
                        {
                            UltraGridRow nrow = comGrid.DisplayLayout.Bands[0].AddNew();
                            nrow.Cells["PRDQ_IsNeed"].Value = d.TPRD_IsReq;
                            var dict = dictList.FirstOrDefault(o => o.Dict_Code == d.TPRD_Type);

                            nrow.Cells["PRDQ_Name"].Value = dict.Dict_Name + "报告";
                            nrow.Cells["PRDQ_Type"].Value = d.TPRD_Type;
                            nrow.Cells["PRDQ_Date"].Value = DateTime.Now;
                            nrow.Cells["PRDQ_Owner"].Value = SessionConfig.UserName;
                            nrow.Cells["PRDQ_Result"].Value = "Check";

                        }

                        uCom.Focus();

                        comGrid.EventManager.SetEnabled(EventGroups.AllEvents, true);
                    }
                    catch (Exception ex)
                    {
                        //写入数据库日志
                        PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                            "", "CompManage",
                           ex.Message, PlateLog.LogMessageType.Error, ex);
                    }
                }
            }
        }

        public List<Tpl_ReqDoc> LoadReqDoc(string code)
        {
            return compInstance.GetReqDocByComp(code);
        }

        public void InitData()
        {
            formHelper.GenerateForm("CForm_PComponents", this.gpBse, new Point(20, 20));

            comGrid = gen.GenerateGrid("CList_CompDoc", this.panel1, new Point(0, 0));

            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            //comGrid.InitializeRow += new InitializeRowEventHandler(comGrid_InitializeRow);
            //comGrid.AfterRowsDeleted += new EventHandler(comGrid_AfterRowsDeleted);
            //comGrid.AfterRowActivate += new EventHandler(comGrid_AfterRowActivate);
            //comGrid.BeforeRowDeactivate += new CancelEventHandler(comGrid_BeforeRowDeactivate);
            //comGrid.DoubleClickRow += new DoubleClickRowEventHandler(comGrid_DoubleClickRow);
            List<Prod_Doc> list = new List<Prod_Doc>();
            comGrid.DataSource = list;

            List<Prod_Components> list1 = new List<Prod_Components>();
            otherCompGrid = gen.GenerateGrid("CList_RefComp", this.panel2, new Point(0, 0));

            BindingSource dataSourc = new BindingSource();
            dataSourc.DataSource = list1;
            otherCompGrid.DataSource = dataSourc;

            otherCompGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;

            //otherCompGrid.BeforeEnterEditMode += new CancelEventHandler(otherCompGrid_BeforeEnterEditMode);
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
                    scanBtn.Enabled = false;
                    gen.SetGridReadOnly(comGrid, true);
                    break;
            }

        }

        public void BindEvent()
        {
            comGrid.InitializeRow += new InitializeRowEventHandler(comGrid_InitializeRow);
            comGrid.AfterRowsDeleted += new EventHandler(comGrid_AfterRowsDeleted);
            comGrid.AfterRowActivate += new EventHandler(comGrid_AfterRowActivate);
            comGrid.BeforeRowDeactivate += new CancelEventHandler(comGrid_BeforeRowDeactivate);
            comGrid.DoubleClickRow += new DoubleClickRowEventHandler(comGrid_DoubleClickRow);

            //关联零件
            otherCompGrid.BeforeEnterEditMode += new CancelEventHandler(otherCompGrid_BeforeEnterEditMode);
        }

        void otherCompGrid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row == null)
            {
                Alert.Show("请先选择相应的文档!");
                return;
            }
            Prod_Doc doc = row.ListObject as Prod_Doc;
            if (string.IsNullOrEmpty(doc.PRDQ_Code))
            {
                Alert.Show("请输入文档编号后在生成关联零件编号!");
                e.Cancel = true;
            }
        }

        void comGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Prod_Doc doc = row.ListObject as Prod_Doc;
                CC_File file = CurrentDataSource.OrderByDescending(o => o.CCF_ID).FirstOrDefault(o => o.CCF_DCode == doc.PRDQ_Code);
                if (file != null)
                {
                    OpenFile(file.CCF_Directory);
                }
                else
                {
                    Alert.Show("当前文档是否已丢失或不存在，请确认！");
                }
            }
        }



        public void OpenFile(string path)
        {

            MethodInvoker mi = delegate
            {
                string temppath = path;
                string remoteFileName = Path.GetFileName(temppath);
                //Bll_File fileInstance = new Bll_File();

                //fileInstance.ftp.GotoDirectory("./" + GModel.PRDC_CompNo);
                //string basePath = QX.Helper.XmlHelper.GetConfig("LocalPath");
                //if (fileInstance.ftp.FileExist(remoteFileName))
                //{

                //    string filename = Path.Combine(basePath, remoteFileName);
                //    if (File.Exists(filename))
                //    {

                //        File.Delete(filename);
                //    }
                //    fileInstance.ftp.DownloadFile(remoteFileName, basePath);

                //    Process proc = new Process();
                //    proc.StartInfo.FileName = Path.Combine(basePath, remoteFileName);
                //    ////打开资源管理器
                //    //proc.StartInfo.Arguments = @"/select,"+path;
                //    //选中"这个路径的"这个程序,即记事本
                //    proc.Start();
                //}
                //else
                //{
                try
                {
                    Process proc = new Process();
                    //proc.StartInfo.FileName = "\\\\192.168.1.100\\ftp" + path.Replace('/', '\\');
                    proc.StartInfo.FileName = GlabolConfiguration.SeverPath + path.Replace('/', '\\');
                    ////打开资源管理器
                    //proc.StartInfo.Arguments = @"/select,"+path;
                    //选中"这个路径的"这个程序,即记事本
                    proc.Start();
                }
                catch (Exception e)
                {
                    //写入数据库日志
                    PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                        "", "CompManage",
                       e.Message, PlateLog.LogMessageType.Error, e);
                }
                //}

            };

            mi.BeginInvoke(null, null);

            //           打开文件夹： sfd为SaveFileDialog的实例
            //System.Diagnostics.Process.Start("explorer.exe",sfd.FileName.Substring(0,sfd.FileName.LastIndexOf(@"\")));
            //System.Diagnostics.Process.Start("explorer.exe", "/select,"+path);

        }

        Dictionary<string, List<Prod_Components>> InitRefCompList
        {
            get;
            set;
        }

        Dictionary<string, List<Prod_Components>> RefCompList
        {
            get;
            set;
        }

        void comGrid_BeforeRowDeactivate(object sender, CancelEventArgs e)
        {
            SaveDictionary();
        }

        /// <summary>
        /// 多零件参考保存(事件)
        /// </summary>
        public void SaveDictionary()
        {
            if (OperationTypeEnum.Look == opType)
            {
                return;
            }

            UltraGridRow row = this.comGrid.ActiveRow;

            if (row != null)
            {
                Prod_Doc doc = row.ListObject as Prod_Doc;
                if (doc == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(doc.PRDQ_Code))
                {
                    //Alert.Show("请输入文档编号");
                    return;
                }
                List<Prod_Components> list = new List<Prod_Components>();
                foreach (var r in this.otherCompGrid.Rows)
                {
                    Prod_Components c = r.ListObject as Prod_Components;

                    if (c.PRDC_CompNo != GModel.PRDC_CompNo && list.FirstOrDefault(o => o.PRDC_CompNo == c.PRDC_CompNo) == null)
                    {
                        list.Add(c);
                        //如果关联的零件编号不存在则自动插入该零件
                        if (ExsistComponentSource.FirstOrDefault(o => o.PRDC_CompNo == c.PRDC_CompNo) == null)
                        {
                            var temp = compInstance.GetCompModel(c.PRDC_CompNo);
                            if (temp != null)
                            {
                                continue;
                            }
                            Prod_Components comp = new Prod_Components();
                            comp.PRDC_CompCode = GModel.PRDC_CompCode;
                            comp.PRDC_CompName = GModel.PRDC_CompName;
                            comp.CreateTime = DateTime.Now;
                            comp.PRDC_Tec1 = GModel.PRDC_Tec1;
                            comp.PRDC_Tec2 = GModel.PRDC_Tec2;
                            comp.PRDC_Tec3 = GModel.PRDC_Tec3;
                            comp.PRDC_CompNo = c.PRDC_CompNo;
                            comp.PRDC_iType = iTypeEnum.Comp.ToString();
                            compInstance.AddComp(comp);
                        }
                    }
                }
                //if (list.Count != 0)
                //{
                //如果存在该该文档相关的信息则重新设置参考零件
                if (RefCompList.Keys.Contains(doc.PRDQ_Code))
                {
                    RefCompList[doc.PRDQ_Code] = list;
                }
                else
                {
                    RefCompList.Add(doc.PRDQ_Code, list);
                }
                //}
            }
        }

        /// <summary>
        /// 多零件参考保存(最后)
        /// </summary>
        public void SaveDictionaryFinal()
        {
            if (OperationTypeEnum.Look == opType)
            {
                return;
            }

            UltraGridRow row = this.comGrid.ActiveRow;

            if (row != null)
            {
                Prod_Doc doc = row.ListObject as Prod_Doc;

                if (doc == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(doc.PRDQ_Code))
                {
                    //Alert.Show("请输入文档编号");
                    return;
                }

                List<Prod_Components> list = new List<Prod_Components>();
                foreach (var r in this.otherCompGrid.Rows)
                {
                    Prod_Components c = r.ListObject as Prod_Components;
                    if (c.PRDC_CompNo != GModel.PRDC_CompNo && list.FirstOrDefault(o => o.PRDC_CompNo == c.PRDC_CompNo) == null)
                    {
                        list.Add(c);

                        //如果关联的零件编号不存在则自动插入该零件
                        if (ExsistComponentSource.FirstOrDefault(o => o.PRDC_CompNo == c.PRDC_CompNo) == null)
                        {

                            var temp = compInstance.GetCompModel(c.PRDC_CompNo);
                            if (temp != null)
                            {
                                continue;
                            }
                            Prod_Components comp = new Prod_Components();
                            comp.PRDC_CompCode = GModel.PRDC_CompCode;
                            comp.PRDC_CompName = GModel.PRDC_CompName;
                            comp.CreateTime = DateTime.Now;
                            comp.PRDC_Tec1 = GModel.PRDC_Tec1;
                            comp.PRDC_Tec2 = GModel.PRDC_Tec2;
                            comp.PRDC_Tec3 = GModel.PRDC_Tec3;
                            comp.PRDC_CompNo = c.PRDC_CompNo;
                            comp.PRDC_iType = iTypeEnum.Comp.ToString();
                            comp.PRDC_RecDate = DateTime.Now;
                            var re = compInstance.InsertComp(comp);
                        }
                    }
                }

                //如果存在该该文档相关的信息则重新设置参考零件
                if (RefCompList.Keys.Contains(doc.PRDQ_Code))
                {
                    RefCompList[doc.PRDQ_Code] = list;
                }
                else
                {
                    RefCompList.Add(doc.PRDQ_Code, list);
                }
                //}
            }
        }


        void comGrid_AfterRowActivate(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;

            if (row != null)
            {
                Prod_Doc doc = row.ListObject as Prod_Doc;
                if (doc == null)
                {
                    return;
                }
                if (doc.PRDQ_Code != null && RefCompList.Keys.Contains(doc.PRDQ_Code))
                {
                    List<Prod_Components> list = RefCompList[doc.PRDQ_Code];

                    BindingSource source = new BindingSource();
                    source.DataSource = list.Distinct().ToList();
                    this.otherCompGrid.DataSource = source;
                }
                else
                {
                    List<Prod_Components> list = new List<Prod_Components>();

                    BindingSource source = new BindingSource();
                    source.DataSource = list;
                    this.otherCompGrid.DataSource = source;
                }
            }
        }

        void comGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            UltraGridRow row = e.Row;
            Prod_Doc doc = row.ListObject as Prod_Doc;
            if (doc != null && doc.PRDQ_IsScan == 1)
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

            if (list.Count > 0)
            {
                RefCompList = compInstance.GetCompDocByRefDoc(list, GModel.PRDC_CompNo);
                InitRefCompList = compInstance.GetCompDocByRefDoc(list, GModel.PRDC_CompNo);
            }
            else
            {
                InitRefCompList = new Dictionary<string, List<Prod_Components>>();
                RefCompList = new Dictionary<string, List<Prod_Components>>();
            }
        }


        //public void BindAllData()
        //{
        //    bmHelper.BindModelToControl<Prod_Components>(GModel, this.gpBse.Controls, "");

        //    List<Prod_Doc> list = compInstance.GetProdDocByComp(GModel.PRDC_CompNo);
        //    List<CC_File> fileList = compInstance.GetCCFileListByComp(GModel.PRDC_CompNo);
        //    CurrentDataSource = fileList.ToList();
        //    BindingSource dataSource = new BindingSource();
        //    dataSource.DataSource = list;
        //    comGrid.DataSource = dataSource;

        //    if (list.Count > 0)
        //    {
        //        RefCompList = compInstance.GetCompDocByRefDoc(list, GModel.PRDC_CompNo);
        //        InitRefCompList = compInstance.GetCompDocByRefDoc(list, GModel.PRDC_CompNo);
        //    }
        //    else
        //    {
        //        InitRefCompList = new Dictionary<string, List<Prod_Components>>();
        //        RefCompList = new Dictionary<string, List<Prod_Components>>();
        //    }
        //}

        public bool SaveData()
        {
            bool flag = true;
            try
            {
                switch (opType)
                {
                    case OperationTypeEnum.Add:

                        bmHelper.BindControlToModel<Prod_Components>(GModel, this.gpBse.Controls, "");

                        GModel.PRDC_iType = iTypeEnum.Comp.ToString();

                        if (string.IsNullOrEmpty(GModel.PRDC_CompNo))
                        {
                            Alert.Show("零件编号不能为空,请确认后重新输入!");
                            return false;
                        }

                        if (compInstance.GetCompModel(GModel.PRDC_CompNo) != null)
                        {
                            Alert.Show("当前零件编号已存在,请确认后重新输入!");
                            return false;
                        }

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

            }
            catch (Exception e)
            {
                //写入数据库日志
                PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                    "", "CompManage",
                   e.Message, PlateLog.LogMessageType.Error, e);
            }
            return flag;

        }

        /// <summary>
        /// 保存
        /// </summary>
        public void SaveGrid()
        {
            ///保存列表数据前，先更新保存一次关联零件信息
            SaveDictionaryFinal();

            List<Prod_Doc> list = new List<Prod_Doc>();

            foreach (var row in comGrid.Rows)
            {
                Prod_Doc doc = row.ListObject as Prod_Doc;

                if (string.IsNullOrEmpty(doc.PRDQ_iType))
                {
                    doc.PRDQ_iType = iTypeEnum.Comp.ToString();
                }

                if (!string.IsNullOrEmpty(doc.PRDQ_Code))
                {
                    ///多零件同步
                    if (RefCompList.Keys.Contains(doc.PRDQ_Code))
                    {
                        //如果零件关联的数量发生变化则分别处理
                        if (InitRefCompList.Keys.Contains(doc.PRDQ_Code))
                        {
                            //doc.PRDQ_IsScan = 1;
                            compInstance.AddOrUpdateCDocForRef(doc, RefCompList[doc.PRDQ_Code], InitRefCompList[doc.PRDQ_Code]);
                        }
                        else
                        {
                            //doc.PRDQ_IsScan = 1;
                            //存在删除操作
                            compInstance.AddOrUpdateCDocForRef(doc, RefCompList[doc.PRDQ_Code]);
                        }
                    }
                }


                list.Add(doc);
            }


            compInstance.AddOrUpdateCDoc(GModel, list);




            if (IsDeleted)
            {
                MethodInvoker mi = new MethodInvoker(this.DeleteDocument);
                mi.BeginInvoke(null, null);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UltraGridRow crow = this.comGrid.ActiveRow;
            if (crow == null)
            {
                Alert.Show("请选择文档后在生成关联零件编号!");
                return;
            }
            Prod_Doc doc = crow.ListObject as Prod_Doc;
            if (string.IsNullOrEmpty(doc.PRDQ_Code))
            {
                Alert.Show("请输入文档编号后在生成关联零件编号!");
                return;
            }

            string prefix = this.txtPrefix.Text;

            int len = Common.Utils.TypeConverter.ObjectToInt(this.txtLen.Text);

            if (string.IsNullOrEmpty(this.txtStart.Text))
            {
                Alert.Show("请输入起始编号!");
                return;
            }
            if (string.IsNullOrEmpty(this.txtEnd.Text))
            {
                Alert.Show("请输入结束编号!");
                return;
            }
            int start = QX.Common.Utils.TypeConverter.ObjectToInt(this.txtStart.Text);
            int end = QX.Common.Utils.TypeConverter.ObjectToInt(this.txtEnd.Text);
            for (int i = start; i <= end; i++)
            {

                UltraGridRow row = otherCompGrid.DisplayLayout.Bands[0].AddNew();

                string temp = string.Empty;
                if (len != 0)
                {
                    temp = i.ToString().PadLeft(len, '0');
                }
                else
                {
                    temp = i.ToString();
                }
                string result = prefix + temp;

                row.Cells["PRDC_CompNo"].Value = result;
            }

        }

    }
}
