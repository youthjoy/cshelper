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
using QX.BLL;
using System.IO;
using QX.UI.Components;
using QX.Log;
using QX.Shared;

namespace QX.UI.Document
{
    public partial class DocOtherQuery : Bse_Form
    {
   

         private BLL.Bll_Doc dcInstance = new QX.BLL.Bll_Doc();

        private BLL.Bll_File fileInstance = new QX.BLL.Bll_File();

        void DocQuery_Load(object sender, EventArgs e)
        {
            //BuildTree();
        }


        public DocOtherQuery()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);

            BindTopTool();
        }

        #region 操作句柄

        private GridHelper gen = new GridHelper();

        private BLL.Bll_Prod compInstance = new QX.BLL.Bll_Prod();

        UltraGrid comGrid = new UltraGrid();
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
            
           
            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();
            this.top_tool_bar.LookClicked += new EventHandler(top_tool_bar_LookClicked);
            //ToolStripControlHost comboStatHost = new ToolStripControlHost(comboStat);
            //comboStatHost.Margin = new Padding(5, 0, 0, 0);
            //this.top_tool_bar.AddCustomControl(6, comboStatHost);
            ToolBarHelper tsHelper = new ToolBarHelper();
            ToolStripButton btnDownload = tsHelper.New("下载", QX.GenFramework.Properties.Resources.import, new EventHandler(btnDownload_Click));
            
            this.top_tool_bar.AddCustomControl(9, btnDownload);
            #endregion


        }

        void top_tool_bar_LookClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                string code = row.Cells["PRDC_CompNo"].Value.ToString();
                var model=compInstance.GetComponentModel(code);
                OtherCompOp frmOp = new OtherCompOp(model, OperationTypeEnum.Look);
                frmOp.ShowDialog();
            }
        }

        void btnDownload_Click(object sender, EventArgs e)
        {
            if (this.comGrid.Rows.Count == 0)
            {
                return;
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (DialogResult.OK == dialog.ShowDialog())
            {
                string path = dialog.SelectedPath;
                Bll_File fileInstance = new Bll_File();
                StringBuilder sb = new StringBuilder();
                foreach (var row in this.comGrid.Rows)
                {
                    var obj = row.Cells["CCF_Directory"].Value;
                    //string filename = string.Empty;
                    try
                    {

                        if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                        {
                            continue;
                        }
                        //string remotepath = Path.GetDirectoryName(obj.ToString());
                        //fileInstance.GotoDirectory("." + remotepath);
                        //string file =Path.GetFileName(obj.ToString());
                        fileInstance.DownloadFile(path, obj.ToString());
                    }
                    catch (Exception ex)
                    {
                        if (obj != null)
                        {
                            string file = Path.GetFileName(obj.ToString());
                            sb.Append(file).Append(",");
                        }
                    }
                }

                if (sb.Length != 0)
                {
                    string message = string.Format("以下文件未能成功下载:{0}", sb.ToString().Trim(','));
                    Alert.Show(message);
                }
                else
                {
                    Alert.Show("文档已完成下载!");
                }

            }
        }

        void top_tool_bar_RefreshClicked(object sender, EventArgs e)
        {
            BindData();
        }

        void top_tool_bar_DelClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void top_tool_bar_EditClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                //Prod_Pool comp = row.ListObject as Prod_Pool;
                //ProdIO EditFrm = new ProdIO(comp, OperationTypeEnum.Edit);
                //EditFrm.CallBack += new ProdIO.DCallBackHandler(EditFrm_CallBack);
                //EditFrm.Show();
            }
        }

        void EditFrm_CallBack(bool flag)
        {
            BindData();
        }


        void top_tool_bar_AddClicked(object sender, EventArgs e)
        {
            //ProdIO AddFrm = new ProdIO(new Prod_Pool(), OperationTypeEnum.Add);
            //AddFrm.CallBack += new ProdIO.DCallBackHandler(AddFrm_CallBack);
            //AddFrm.Show();
            //CompOp frmAdd = new CompOp(new Tpl_Components(), OperationTypeEnum.Add);
            //frmAdd.CallBack += new CompOp.DCallBackHandler(frmAdd_CallBack);
            //frmAdd.Show();
        }

        void AddFrm_CallBack(bool flag)
        {
            BindData();
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
            var obj = comboStat.SelectedValue;
            string where = string.Empty;
            if (obj == null)
            {
                where = string.Format(" AND  CreateTime between '{1}' AND '{2}' AND ( PRDC_ProdCode like '%{0}%' OR PRDC_CompNo like '%{0}%' OR PRDC_CompCode like '%{0}%') ", val3,val1,val2);

                DataTable dt = new DataTable();
                dt = new BLL.Bll_Comm().ListViewData(string.Format("select * from VRpt_OtherQuery where 1=1 {0}", where));
                comGrid.DataSource = dt;
            }
            else
            {
                string type = obj.ToString();
                switch (type)
                {
                    case "SearchComp":
                        where = string.Format("AND  CreateTime between '{1}' AND '{2}' AND PRDC_CompCode like '%{0}%'", val3,val1,val2);
                        break;
                    case "SearchPComp":
                        where = string.Format("AND  CreateTime between '{1}' AND '{2}' AND PRDC_CompNo like '%{0}%'", val3,val1,val2);
                        break;
                    case "SearchProdCode":
                        where = string.Format("AND  CreateTime between '{1}' AND '{2}' AND PRDC_ProdCode like '%{0}%' ", val3,val1,val2);
                        break;
                    default:
                        where = string.Format("AND  CreateTime between '{1}' AND '{2}' AND ( PRDC_ProdCode like '%{0}%' OR PRDC_CompNo like '%{0}%' OR PRDC_CompCode like '%{0}%') ", val3,val1,val2);
                        break;
                }

                DataTable dt = new DataTable();
                dt = new BLL.Bll_Comm().ListViewData(string.Format("select * from VRpt_OtherQuery where 1=1 {0}", where));

                comGrid.DataSource = dt;
            }
        }

        #endregion


        void Form_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData();


        }

        public void InitControl()
        {
            //List<Prod_Pool> list = new List<Prod_Pool>();
            //comGrid = gen.GenerateGrid("CList_PPool", this.pnlGrid, new Point(0, 0));
            //comGrid.DataSource = list;
            //comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            //List<Prod_Pool> list1 = new List<Prod_Pool>();
            //this.allGrid = gen.GenerateGrid("CList_POut", this.pnlAll, new Point(0, 0));
            //allGrid.DataSource = list1;
            comGrid = gen.GenerateGrid("CList_QueryOther", this.pnlDoc, new Point(0, 0));
            comGrid.DoubleClickRow += new DoubleClickRowEventHandler(comGrid_DoubleClickRow);
            DataTable dt = new BLL.Bll_Comm().ListViewData(string.Format("select * from VRpt_OtherQuery where 1>2 "));
            comGrid.DataSource = dt;
        }

        void comGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UltraGridRow row = e.Row;
            if (row.Cells["CCF_Directory"].Value != null)
            {
                OpenFile(row.Cells["CCF_Directory"].Value.ToString(), row.Cells["PRDC_CompNo"].Value.ToString());
            }
        }

        public void BindData()
        {
            //List<Prod_Pool> list = compInstance.GetInProdCompList();

            //comGrid.DataSource = list;

            //List<Prod_Pool> list1 = compInstance.GetAllProdCompList();
            //allGrid.DataSource = list1;
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
                        "", "DocOtherQuery",
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
                //catch (Exception ex)
                //{
                //    //写入数据库日志
                //    PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                //        "", this.Name + "|" + this.ToString(),
                //       ex.Message, PlateLog.LogMessageType.Error, ex);
                //    Alert.Show("请确认网络是连通或文档已上传服务器!");
                //}
            };

            mi.BeginInvoke(null, null);

            //           打开文件夹： sfd为SaveFileDialog的实例
            //System.Diagnostics.Process.Start("explorer.exe",sfd.FileName.Substring(0,sfd.FileName.LastIndexOf(@"\")));
            //System.Diagnostics.Process.Start("explorer.exe", "/select,"+path);

        }
    }
}
