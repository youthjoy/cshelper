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
using Infragistics.Win.UltraWinGrid;
using QX.Model;
using QX.GenFramework.Helper;
using QX.BLL;
using System.IO;
using QX.Log;
using QX.GenFramework.AutoForm;

namespace QX.UI.Document
{
    public partial class DocChange : Bse_Form
    {


        private BLL.Bll_Doc dcInstance = new QX.BLL.Bll_Doc();

        private BLL.Bll_File fileInstance = new QX.BLL.Bll_File();


        public DocChange()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);

            BindTopTool();
        }

        #region 操作句柄

        private GridHelper gen = new GridHelper();

        private BLL.Bll_Prod compInstance = new QX.BLL.Bll_Prod();

        /// <summary>
        /// 未转储
        /// </summary>
        UltraGrid comGrid = new UltraGrid();
        /// <summary>
        /// 已转储
        /// </summary>
        UltraGrid changedGrid = new UltraGrid();

        /// <summary>
        /// 所有成品列表
        /// </summary>
        UltraGrid allGrid = new UltraGrid();

        #endregion

        #region 工具条

        string currentFilePath = string.Empty;

        private void BindTopTool()
        {
            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();
            ToolBarHelper tsHelper = new ToolBarHelper();
            ToolStripButton btnDownload = tsHelper.New("转储", QX.GenFramework.Properties.Resources.import, new EventHandler(btnDownload_Click));
            this.top_tool_bar.AddCustomControl(8, btnDownload);
            ToolStripButton openBtn = tsHelper.New("浏览", QX.GenFramework.Properties.Resources.look, new EventHandler(openBtn_Click));
            //this.top_tool_bar.AddCustomControl(openBtn);
            //openBtn.Click += new EventHandler(openBtn_Click);

            this.top_tool_bar.RefreshClicked += new EventHandler(top_tool_bar_RefreshClicked);


            this.top_tool_bar1.SearchClicked += new EventHandler(top_tool_bar1_SearchClicked);
            this.top_tool_bar1.AddSearchAllModule();

            ToolStripButton btnDownload1 = tsHelper.New("转储", QX.GenFramework.Properties.Resources.import, new EventHandler(btnDownload_Click1));
            this.top_tool_bar1.AddCustomControl(8, btnDownload1);

            this.top_tool_bar1.RefreshClicked += new EventHandler(top_tool_bar1_RefreshClicked);

        }

        void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog1 = new OpenFileDialog();
            if (DialogResult.OK == dialog1.ShowDialog())
            {
                
            }
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

        private void AddCustomColForChanged()
        {
            if (!changedGrid.DisplayLayout.Bands[0].Columns.Exists("checkbox"))
            {
                var col = changedGrid.DisplayLayout.Bands[0].Columns.Add("checkbox", "");
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
                changedGrid.DisplayLayout.Bands[0].Columns.Remove("checkbox");
                var col = changedGrid.DisplayLayout.Bands[0].Columns.Add("checkbox", "");
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

        /// <summary>
        /// 获取选中的行
        /// </summary>
        /// <returns></returns>
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

        private List<Prod_Pool> GetGridCheckBoxDataForChanged()
        {
            List<Prod_Pool> list = new List<Prod_Pool>();

            foreach (UltraGridRow r in this.changedGrid.DisplayLayout.Rows)
            {

                if (r.Cells["checkbox"].Value != null && r.Cells["checkbox"].Value.ToString() == "True")
                {
                    Prod_Pool planProd = r.ListObject as Prod_Pool;
                    list.Add(planProd);
                }
            }

            return list;
        }


        private Bll_Comp cpInstance = new Bll_Comp();
        void btnDownload_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (DialogResult.OK == dialog.ShowDialog())
            {
                StringBuilder sb = new StringBuilder();
                string path = dialog.SelectedPath;
                currentFilePath = path;
                Bll_File fileInstance = new Bll_File();

                List<Prod_Pool> list = GetGridCheckBoxData();
                
                if (list.Count == 0)
                {
                    Alert.Show("请选择要转储的成品!");
                    return;
                }
                string currentFile = string.Empty; 
                foreach (var l in list)
                {
                    List<Prod_Components> compList = compInstance.GetPCompByProd(l.PRP_ProdCode);
                   

                    if (!Directory.Exists(l.PRP_ProdCode))
                    {
                        Directory.CreateDirectory(l.PRP_ProdCode);
                    }
                    try
                    {
                       

                        //成品文件夹
                        fileInstance.ftp.GotoDirectory("./" + l.PRP_ProdCode);

                        foreach (var f in fileInstance.ftp.ListFilesAndDirectories())
                        {

                            if (f.IsDirectory)
                            {
                                //零件文件夹
                                string tem = Path.Combine(path, l.PRP_ProdCode + "/" + f.Name);
                                string prodpath = Path.Combine(path, l.PRP_ProdCode);
                                //如果是文件夹则判断是否是关联的零件
                                if (!compList.Exists(o => o.PRDC_CompNo == f.Name))
                                {
                                    continue;
                                }

                                if (!string.IsNullOrEmpty(prodpath)&&!Directory.Exists(prodpath))
                                {
                                    Directory.CreateDirectory(prodpath);
                                }
                                
                                //如果本地不存在改文件夹则创建
                                if (!Directory.Exists(tem))
                                {
                                    Directory.CreateDirectory(tem);
                                }
                                fileInstance.ftp.GotoDirectory("./" + l.PRP_ProdCode + "/" + f.Name);
                                //创建文件夹成功
                                if (Directory.Exists(tem))
                                {
                                    foreach (var ff in fileInstance.ftp.ListFiles())
                                    {
                                        currentFile = ff.Name;
                                        if (File.Exists(Path.Combine(tem, currentFile)))
                                        {
                                            File.Delete(Path.Combine(tem, currentFile));
                                        }
                                        fileInstance.ftp.DownloadFile(ff.Name, tem);

                                    }
                                }


                            }
                            else
                            {
                                currentFile = f.Name;
                                string tem = Path.Combine(path, l.PRP_ProdCode);
                                
                                if (File.Exists(Path.Combine(tem, currentFile)))
                                {

                                    File.Delete(Path.Combine(tem, currentFile));
                                }
                                fileInstance.ftp.DownloadFile(f.Name, tem);

                            }
                        }
                        compInstance.SetProdChange(l);

                    }//如果发生异常则抛弃此次循环
                    catch (Exception ex)
                    {
                        //写入数据库日志
                        PlateLog.WriteError(QX.Gen.Shared.SessionConfig.UserID, QX.Gen.Shared.SessionConfig.UserName,
                            "", this.Name + "|" + this.ToString(),
                           ex.Message, PlateLog.LogMessageType.Error, ex);
                        sb.Append(currentFile).Append(",");
                        continue;
                    }
                }//end foreach

                string result = sb.ToString().TrimEnd(',');

                if (!string.IsNullOrEmpty(result))
                {
                    Alert.Show(string.Format("以下文件未能下载成功:{0}", result));
                }
                else
                {
                    Alert.Show("转储成功!");
                    BindData();
                }

            }
        }


        void btnDownload_Click1(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (DialogResult.OK == dialog.ShowDialog())
            {
                StringBuilder sb = new StringBuilder();
                string path = dialog.SelectedPath;
                Bll_File fileInstance = new Bll_File();

                List<Prod_Pool> list = GetGridCheckBoxDataForChanged();
                if (list.Count == 0)
                {
                    Alert.Show("请选择要转储的成品!");
                    return;
                }
                string currentFile = string.Empty; ;
                foreach (var l in list)
                {
                    if (!Directory.Exists(l.PRP_ProdCode))
                    {
                        Directory.CreateDirectory(l.PRP_ProdCode);
                    }
                    try
                    {
                        //成品文件夹
                        fileInstance.ftp.GotoDirectory("./" + l.PRP_ProdCode);

                        foreach (var f in fileInstance.ftp.ListFilesAndDirectories())
                        {
                            if (f.IsDirectory)
                            {
                                string tem = Path.Combine(path, l.PRP_ProdCode + "/" + f.Name);
                                if (!Directory.Exists(tem))
                                {
                                    Directory.CreateDirectory(tem);
                                }
                                fileInstance.ftp.GotoDirectory("./" + l.PRP_ProdCode + "/" + f.Name);
                                //创建文件夹成功
                                if (Directory.Exists(tem))
                                {
                                    foreach (var ff in fileInstance.ftp.ListFiles())
                                    {
                                        currentFile = ff.Name;
                                        if (File.Exists(Path.Combine(tem, currentFile)))
                                        {

                                            File.Delete(Path.Combine(tem, currentFile));
                                        }
                                        fileInstance.ftp.DownloadFile(ff.Name, tem);

                                    }
                                }


                            }
                        }
                        compInstance.SetProdChange(l);

                    }//如果发生异常则抛弃此次循环
                    catch (Exception ex)
                    {
                        //写入数据库日志
                        PlateLog.WriteError(QX.Gen.Shared.SessionConfig.UserID, QX.Gen.Shared.SessionConfig.UserName,
                            "", this.Name + "|" + this.ToString(),
                           ex.Message, PlateLog.LogMessageType.Error, ex);
                        sb.Append(currentFile).Append(",");
                        continue;
                    }
                }//end foreach

                string result = sb.ToString().TrimEnd(',');

                if (!string.IsNullOrEmpty(result))
                {
                    Alert.Show(string.Format("以下文件未能下载成功:{0}", result));
                }
                else
                {
                    Alert.Show("转储成功!");
                    BindData();
                }

            }
        }

        #region 待转储
        void top_tool_bar_RefreshClicked(object sender, EventArgs e)
        {
            BindData();
        }

        void top_tool_bar_SearchClicked(object sender, EventArgs e)
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");
            string val3 = this.top_tool_bar.GetSearchValue("Key", "Text");

            var source = compInstance.GetChangeProdCompList(val1, val2, val3);
            comGrid.DataSource = source;

            AddCustomCol();
        }
        #endregion

        #region 已转储

        void top_tool_bar1_RefreshClicked(object sender, EventArgs e)
        {
            top_tool_bar_SearchClicked(null, null);
        }


        void top_tool_bar1_SearchClicked(object sender, EventArgs e)
        {
            string val1 = this.top_tool_bar1.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar1.GetSearchValue("eDate", "Date");
            string val3 = this.top_tool_bar1.GetSearchValue("Key", "Text");

            var source = compInstance.GetChangedProdCompList(val1, val2, val3);
            changedGrid.DataSource = source;
        }
        #endregion

        #endregion


        void Form_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData();
        }

        public void InitControl()
        {

            List<Prod_Pool> list = new List<Prod_Pool>();
            comGrid = gen.GenerateGrid("CList_POut", this.pnlDoc, new Point(0, 0));
            comGrid.DataSource = list;
            //comGrid.DoubleClickRow += new DoubleClickRowEventHandler(comGrid_DoubleClickRow);
            List<Prod_Pool> list1 = new List<Prod_Pool>();
            changedGrid = gen.GenerateGrid("CList_POut", this.pnlChange, new Point(0, 0));
            changedGrid.DataSource = list1;
        }



        public void BindData()
        {
            List<Prod_Pool> list = compInstance.GetChangeProdCompList();

            comGrid.DataSource = list;

            AddCustomCol();

            List<Prod_Pool> list1 = compInstance.GetChangedProdCompList();

            changedGrid.DataSource = list1;

            AddCustomColForChanged();
        }



        public void OpenFile(string path, string folder)
        {

            MethodInvoker mi = delegate
            {
                string temppath = path;
                string remoteFileName = Path.GetFileName(temppath);
                Bll_File fileInstance = new Bll_File();

                try
                {
                    fileInstance.ftp.GotoDirectory(".");
                    if (fileInstance.ftp.DirectoryExist(folder))
                    {
                        fileInstance.ftp.GotoDirectory(folder);
                        if (fileInstance.ftp.FileExist(remoteFileName))
                        {
                            string basePath = QX.Helper.XmlHelper.GetConfig("LocalPath");
                            string filename = Path.Combine(basePath, remoteFileName);
                            if (File.Exists(filename))
                            {
                                File.Delete(filename);
                            }
                            fileInstance.ftp.DownloadFile(remoteFileName, basePath);

                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = Path.Combine(basePath, remoteFileName);
                            ////打开资源管理器
                            //proc.StartInfo.Arguments = @"/select,"+path;
                            //选中"这个路径的"这个程序,即记事本
                            proc.Start();
                        }
                        else
                        {
                            Alert.Show("未找到与当前选中行对应的文档!");
                        }

                    }
                }
                catch (Exception ex)
                { 
                   
                }

            };

            mi.BeginInvoke(null, null);

            //           打开文件夹： sfd为SaveFileDialog的实例
            //System.Diagnostics.Process.Start("explorer.exe",sfd.FileName.Substring(0,sfd.FileName.LastIndexOf(@"\")));
            //System.Diagnostics.Process.Start("explorer.exe", "/select,"+path);

        }
    }
}
