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
using QX.Shared;
using QX.Log;
using QX.BLL;
using System.IO;
using QX.UI.Components;
using Infragistics.Win.UltraWinEditors;

namespace QX.UI.Prod
{
    public partial class ProdRepairOp : Form
    {



        public ProdRepairOp(Prod_Maintain item, OperationTypeEnum op)
        {
            InitializeComponent();
            opType = op;

            GModel = item;

            this.Load += new EventHandler(Form_Load);
            this.FormClosed += new FormClosedEventHandler(ProdIO_FormClosed);
            BindTopTool();
        }

        public ProdRepairOp(Prod_Pool item, OperationTypeEnum op)
        {
            InitializeComponent();
            opType = op;

            GModel = new Prod_Maintain();
            GModel.PRM_ProdCode = item.PRP_ProdCode;

            this.Load += new EventHandler(Form_Load);
            this.FormClosed += new FormClosedEventHandler(ProdIO_FormClosed);
            BindTopTool();
        }

        void ProdIO_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (CallBack != null)
            {
                CallBack(true);
            }

        }

        public delegate void DCallBackHandler(bool flag);
        public event DCallBackHandler CallBack;

        private Prod_Maintain GModel
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

            this.top_tool_bar.AddCustomControl(scanBtn);
        }

        UltraGrid prodDocGrid = new UltraGrid();

        //本地存储路径
        public string LocalPath = string.Empty;

        private List<CC_File> CCFileList = new List<CC_File>();

        ScanHelper scan = new ScanHelper();

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

            if (doc.PRDQ_IsScan == 1)
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

            //string filename = GModel.PRM_Code + "_" + dcode + "_" + DateTime.Now.ToString("yyyy-MM-dd");

            //var file = StartScan(filename, dcode);

            //if (file != null)
            //{
            //    if (doc.PRDQ_ID != 0)
            //    {
            //        file.Stat = 1;
            //    }
            //    CCFileList.Add(file);

            //    Alert.Show("扫描完成!");

            //    row.Appearance.BackColor = Color.Wheat;
            //    doc.PRDQ_IsScan = 1;
            //}

            var com = bmHelper.FindCtl<UltraTextEditor>(this.pnlGrid.Controls, "PRM_Code");
            string prodcode = com.Text;
            if (string.IsNullOrEmpty(prodcode))
            {
                Alert.Show("请输入编号!");
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

        //public CC_File StartScan(string filename, string dcode)
        //{

        //    ScanHelper scan = new ScanHelper();
        //    CC_File file;
        //    PDFHelper pdf = new PDFHelper();
        //    var list = scan.StartScan();
        //    if (list != null && list.Count != 0)
        //    {

        //        pdf.MakePDF(LocalPath + filename + ".pdf", list);

        //        file = new CC_File();
        //        file.CCF_DCode = dcode;
        //        file.CCF_Name = filename;
        //        file.CCF_iType = "Prod";
        //        file.CCF_Directory = LocalPath + filename + ".pdf";
        //        return file;

        //    }
        //    else
        //    {

        //        Alert.Show("请确认是否已把扫描文档放到Feeder");
        //        return null;
        //    }


        //}

        public void StartScan(string filename, string dcode)
        {

            bool flag = true;
            CC_File file;
            PDFHelper pdf = new PDFHelper();
            List<Image> list = new List<Image>();
            try
            {
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
                    file.CCF_iType = "ProdRepair";
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

        public void SavePath()
        {

            Bll_Doc docInstance = new Bll_Doc();
            Bll_File fileInstance1 = new Bll_File();

            try
            {
                var com = bmHelper.FindCtl<UltraCombo>(this.pnlGrid.Controls, "PRM_ProdCode");
                string parent = com.Value.ToString();

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
                    file.CCF_iType = "ProdRepair";
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
        }

        public void InitData()
        {
            formHelper.GenerateForm("CForm_PMaintain", this.pnlGrid, new Point(20, 20));

            prodDocGrid = gen.GenerateGrid("CList_DocRepair", this.panel1, new Point(0, 0));
            prodDocGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            prodDocGrid.DoubleClickRow += new DoubleClickRowEventHandler(prodDocGrid_DoubleClickRow);
            List<Prod_Doc> list = new List<Prod_Doc>();
            prodDocGrid.DataSource = list;

            switch (opType)
            {
                case OperationTypeEnum.Add:
                    GModel.PRM_Code = compInstance.GenereateProdRepairCode();
                    bmHelper.BindModelToControl<Prod_Maintain>(GModel, this.pnlGrid.Controls, "");
                    break;
                case OperationTypeEnum.Edit:
                    bmHelper.BindModelToControl<Prod_Maintain>(GModel, this.pnlGrid.Controls, "");
                    break;
                case OperationTypeEnum.Look:
                    this.top_tool_bar.SetButtonEnabled("save", false, true);
                    scanBtn.Enabled = false;
                    this.prodDocGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
                    break;
            }

        }

        void prodDocGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //UltraGridRow row = e.Row;

            //Prod_Doc doc = row.ListObject as Prod_Doc;
            //bmHelper.BindModelToControl<Prod_Maintain>(GModel, this.pnlGrid.Controls, "");
            //OpenFile(doc.CCF_Directory, GModel.PRM_ProdCode);

            UltraGridRow row = e.Row;
            Prod_Doc doc = row.ListObject as Prod_Doc;
            if (doc != null)
            {
                OpenFile(doc.CCF_Directory, doc.PRDQ_CompNo);
            }
        }






        public void BindData()
        {
            bmHelper.BindModelToControl<Prod_Maintain>(GModel, this.pnlGrid.Controls, "");
            List<Prod_Doc> list1 = compInstance.GetDocByRepair(GModel.PRM_Code);
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = list1;
            prodDocGrid.DataSource = dataSource;
        }

        public bool SaveData()
        {
            bool flag = true;

            bmHelper.BindControlToModel<Prod_Maintain>(GModel, this.pnlGrid.Controls, "");
            if (string.IsNullOrEmpty(GModel.PRM_ProdCode))
            {
                Alert.Show("成品编号不能为空!");
                return false;
            }

            switch (opType)
            {
                case OperationTypeEnum.Add:

                    //新添加的成品都是入库状态
                    //GModel.PRP_iType = ProdStat.In.ToString();

                    var re = compInstance.AddPRepair(GModel);

                    if (re > 0)
                    {

                        GModel.PRM_ID = re;
                        opType = OperationTypeEnum.Edit;
                        bmHelper.BindModelToControl<Prod_Maintain>(GModel, this.pnlGrid.Controls, "");
                        //bmHelper.ClearControl<PC_CPlan>(GModel, this.gpOther.Controls, "");
                    }


                    break;
                case OperationTypeEnum.Edit:
                    //bmHelper.BindControlToModel<Prod_Maintain>(GModel, this.pnlGrid.Controls, "");

                    flag = compInstance.PRepairUpdate(GModel);

                    break;
                case OperationTypeEnum.Look:

                    break;
            }

            SaveProdDocGrid();

            return flag;

        }


        public void SaveProdDocGrid()
        {

            List<Prod_Doc> list = new List<Prod_Doc>();


            foreach (var row in this.prodDocGrid.Rows)
            {
                Prod_Doc doc = row.ListObject as Prod_Doc;
                //if (string.IsNullOrEmpty(doc.PRDQ_iType))
                //{
                doc.PRDQ_iType = "Repiar";
                //}


                list.Add(doc);
            }

            compInstance.AddOrUpdateCDoc(GModel, list);



            MethodInvoker mi = new MethodInvoker(this.SavePath);
            mi.BeginInvoke(null, null);

        }

        private bool IsDeleted = false;

        //public void SavePath()
        //{
        //    Bll_File fileInstance = new Bll_File();

        //    Bll_Doc docInstance = new Bll_Doc();

        //    string parent = GModel.PRM_ProdCode;
        //    try
        //    {
        //        fileInstance.GotoDirectory(".");
        //        if (!fileInstance.ftp.DirectoryExist(parent))
        //        {
        //            fileInstance.ftp.MakeDirectory(parent);

        //        }

        //        fileInstance.ftp.GotoDirectory(parent);



        //        foreach (var file in CCFileList)
        //        {
        //            switch (opType)
        //            {

        //                case OperationTypeEnum.Add:
        //                    {
        //                        var flag = fileInstance.UploadFile(file.CCF_Directory, true);
        //                        if (flag)
        //                        {

        //                            file.CCF_Code = docInstance.GenerateCCFileCode();
        //                            file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
        //                            file.CCF_iType = "Repiar";
        //                            file.CCF_CompNo = GModel.PRM_Code;
        //                            docInstance.AddCCFile(file);
        //                        }
        //                        break;
        //                    }
        //                case OperationTypeEnum.Edit:
        //                    {


        //                        var flag = fileInstance.UploadFile(file.CCF_Directory, true);
        //                        if (flag)
        //                        {

        //                            file.CCF_Code = docInstance.GenerateCCFileCode();
        //                            file.CCF_Directory = "/" + parent + "/" + file.CCF_Name + ".pdf";
        //                            file.CCF_iType = "Repiar";
        //                            file.CCF_CompNo = GModel.PRM_Code;
        //                            docInstance.AddCCFile(file);
        //                        }

        //                        break;
        //                    }
        //            }

        //        }//当前窗体对应的零件文档上传


        //    }
        //    catch (Exception e)
        //    {
        //        //写入数据库日志
        //        PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
        //            "", this.Name + "|" + this.ToString(),
        //           e.Message, PlateLog.LogMessageType.Error, e);
        //    }//保存完毕后清除需要上传的文件
        //    finally
        //    {

        //        CCFileList = new List<CC_File>();
        //    }

        //    if (IsDeleted)
        //    {
        //        DeleteDocument();
        //    }
        //}

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
                fileInstance.GotoDirectory("./" + GModel.PRM_Code);

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
                    "", this.Name + "|" + this.ToString(),
                   ex.Message, PlateLog.LogMessageType.Error, ex);
            }
            finally
            {
            }
        }

        /// <summary>
        /// 文件
        /// </summary>
        /// <param name="path">文件服务器上文件的FTP全地址</param>
        /// <param name="folder">所属文件夹</param>
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

                //string basePath = QX.Helper.XmlHelper.GetConfig("LocalPath");
                //try
                //{
                //    fileInstance.ftp.GotoDirectory(".");
                //    if (fileInstance.ftp.DirectoryExist(folder))
                //    {
                //        fileInstance.ftp.GotoDirectory(folder);
                //        if (fileInstance.ftp.FileExist(remoteFileName))
                //        {

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
                //        else if (File.Exists(Path.Combine(basePath, remoteFileName)))
                //        {
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
                //    else
                //    {
                //        if (File.Exists(Path.Combine(basePath, remoteFileName)))
                //        {
                //            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                //            proc.StartInfo.FileName = Path.Combine(basePath, remoteFileName);
                //            ////打开资源管理器
                //            //proc.StartInfo.Arguments = @"/select,"+path;
                //            //选中"这个路径的"这个程序,即记事本
                //            proc.Start();
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{ 
                   
                //}
            };

            mi.BeginInvoke(null, null);

            //           打开文件夹： sfd为SaveFileDialog的实例
            //System.Diagnostics.Process.Start("explorer.exe",sfd.FileName.Substring(0,sfd.FileName.LastIndexOf(@"\")));
            //System.Diagnostics.Process.Start("explorer.exe", "/select,"+path);

        }

    }
}
