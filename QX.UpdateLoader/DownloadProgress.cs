using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using System.Diagnostics;


using QX.UpdateModel;
using System.Xml;


namespace QX.UpdateLoader
{
    public partial class DownloadProgress : Form
    {
        private bool isFinished = false;
        private List<DownloadFileInfo> downloadFileList = null;
        private ManualResetEvent evtDownload = null;
        private ManualResetEvent evtPerDonwload = null;
        private WebClient clientDownload = null;

        private FTP Ftp;
        private Dictionary<string, RemoteFile> ParseRemoteXml(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);

            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            XmlNodeList nlist = document.SelectSingleNode("/root/updateFiles").ChildNodes;
            foreach (XmlNode node in nlist)
            {
                string path = node.Attributes["path"].Value;
                list.Add(Path.GetFileName(path), new RemoteFile(node));
            }

            return list;
        }
        public DownloadProgress()
        {
            InitializeComponent();

            //this.Load += new EventHandler(DownloadProgress_Load);
            //this.downloadFileList = downloadFileList;
        }

        void DownloadProgress_Load(object sender, EventArgs e)
        {

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isFinished && DialogResult.No == MessageBox.Show("当前正在更新，是否取消？", "自动升级", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                if (clientDownload != null)
                    clientDownload.CancelAsync();

                evtDownload.Set();
                evtPerDonwload.Set();
            }
        }

        private Dictionary<string, string> GetFtpAddr(string path)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string addr = string.Empty;
            string user = string.Empty;
            string pwd = string.Empty;

            XmlDocument document = new XmlDocument();
            document.Load(path);

            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            XmlNode node = document.SelectSingleNode("/root/ftp");
            addr = node.Attributes["addr"].Value;
            user = node.Attributes["user"].Value;
            pwd = node.Attributes["pwd"].Value;

            dict.Add("Addr", addr);
            dict.Add("User", user);
            dict.Add("Pwd", pwd);

            return dict;
        }


        private void OnFormLoad(object sender, EventArgs e)
        {
            try
            {
                List<DownloadFileInfo> downloadFileList = new List<DownloadFileInfo>();

            

                //Ftp = new FTP(new Uri("ftp://192.168.1.101"), "admin", "admin");
                string path = Application.StartupPath;

                string ftpPath = Path.Combine(path, "ftp.xml");
                Dictionary<string, string> ftpSource = GetFtpAddr(ftpPath);
                Ftp = new FTP(new Uri(ftpSource["Addr"]), ftpSource["User"], ftpSource["Pwd"]);


                string LocalFullPath = Path.Combine(path, "update.xml");
                if (!File.Exists(LocalFullPath))
                {
                    bool s = Ftp.DownloadFile("update.config", path, "update.xml");
                }

                StreamReader sr = new StreamReader(path + "/update.xml");
                string strXml = sr.ReadToEnd();
                this.downloadFileList = new List<DownloadFileInfo>();
                NewVersion = GetNewVersion(strXml);
                Dictionary<string, RemoteFile> listRemotFile = ParseRemoteXml(strXml);
                foreach (RemoteFile file in listRemotFile.Values)
                {
                    this.downloadFileList.Add(new DownloadFileInfo(file.Url, file.Path, file.LastVer, file.Size));
                    //config.UpdateFileList.Add(new LocalFile(file.Path, file.LastVer, file.Size));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }


            evtDownload = new ManualResetEvent(true);
            evtDownload.Reset();
            Thread t = new Thread(new ThreadStart(ProcDownload));
            t.Name = "download";
            t.Start();
        }

        public string NewVersion
        {
            get;
            set;
        }

        public string GetNewVersion(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);

            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            XmlNode node = document.SelectSingleNode("/root/version");

            var s = node.Attributes["ver"].Value;
            return s;
        }

        long total = 0;
        long nDownloadedTotal = 0;

        private void ProcDownload()
        {

            evtPerDonwload = new ManualResetEvent(false);

            foreach (DownloadFileInfo file in this.downloadFileList)
            {
                total += file.Size;
            }

            while (!evtDownload.WaitOne(0, false))
            {
                if (this.downloadFileList.Count == 0)
                    break;

                DownloadFileInfo file = this.downloadFileList[0];


                //Debug.WriteLine(String.Format("Start Download:{0}", file.FileName));

                this.ShowCurrentDownloadFileName(file.FileName);

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Temp/"))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Temp/");
                }

                //FTP ftp = new FTP(new Uri("ftp://192.168.1.101/"), "admin", "admin");
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Temp/" + file.FileName + ".tmp"))
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Temp/" + file.FileName + ".tmp");
                }

                var f = Ftp.DownloadFile(file.FileName, AppDomain.CurrentDomain.BaseDirectory + "/Temp", file.FileName + ".tmp");

                //DownloadFileInfo file = e.UserState as DownloadFileInfo;
                nDownloadedTotal += file.Size;
                this.SetProcessBar(0, (int)(nDownloadedTotal * 100 / total));
                //Debug.WriteLine(String.Format("Finish Download:{0}", file.FileName));
                //替换现有文件
                string newPath = file.FileFullName;
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/Temp", file.FileName);
                if (File.Exists(filePath))
                {
                    if (File.Exists(filePath + ".old"))
                        File.Delete(filePath + ".old");

                    File.Move(filePath, filePath + ".old");
                }
                try
                {
                    File.Copy(filePath + ".tmp", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.FileFullName), true);
                }
                catch (Exception ex)
                { 
                    
                }
                //继续下载其它文件
                evtPerDonwload.Set();

                //下载
                //clientDownload = new WebClient();

                //clientDownload.DownloadProgressChanged += new DownloadProgressChangedEventHandler(OnDownloadProgressChanged);
                //clientDownload.DownloadFileCompleted += new AsyncCompletedEventHandler(OnDownloadFileCompleted);

                //evtPerDonwload.Reset();

                //clientDownload.DownloadFileAsync(new Uri(file.DownloadUrl), Path.Combine(AppDomain.CurrentDomain.BaseDirectory+"/Temp", file.FileFullName + ".tmp"), file);

                //等待下载完成
                evtPerDonwload.WaitOne();

                //clientDownload.Dispose();
                //clientDownload = null;

                //移除已下载的文件
                this.downloadFileList.Remove(file);
            }

            //Debug.WriteLine("All Downloaded");

            if (this.downloadFileList.Count == 0)
                Exit(true);
            else
                Exit(false);

            evtDownload.Set();


            VersionUpdate();
        }

        public void VersionUpdate()
        {
            string path = Application.StartupPath;
            string LocalFullPath = Path.Combine(path, "version.xml");

            StreamReader sr = new StreamReader(LocalFullPath);
            string xml = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            sr = null;
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);

            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            XmlNode node = document.SelectSingleNode("/root/version");

            node.Attributes["CurVer"].Value = NewVersion;

            document.Save(LocalFullPath);


        }

        void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadFileInfo file = e.UserState as DownloadFileInfo;
            nDownloadedTotal += file.Size;
            this.SetProcessBar(0, (int)(nDownloadedTotal * 100 / total));
            //Debug.WriteLine(String.Format("Finish Download:{0}", file.FileName));
            //替换现有文件
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.FileFullName);
            if (File.Exists(filePath))
            {
                if (File.Exists(filePath + ".old"))
                    File.Delete(filePath + ".old");

                File.Move(filePath, filePath + ".old");
            }

            File.Move(filePath + ".tmp", filePath);
            //继续下载其它文件
            evtPerDonwload.Set();
        }

        void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.SetProcessBar(e.ProgressPercentage, (int)((nDownloadedTotal + e.BytesReceived) * 100 / total));
        }

        delegate void ShowCurrentDownloadFileNameCallBack(string name);
        private void ShowCurrentDownloadFileName(string name)
        {
            if (this.labelCurrentItem.InvokeRequired)
            {
                ShowCurrentDownloadFileNameCallBack cb = new ShowCurrentDownloadFileNameCallBack(ShowCurrentDownloadFileName);
                this.Invoke(cb, new object[] { name });
            }
            else
            {
                this.labelCurrentItem.Text = name;
            }
        }

        delegate void SetProcessBarCallBack(int current, int total);
        private void SetProcessBar(int current, int total)
        {
            if (this.progressBarCurrent.InvokeRequired)
            {
                SetProcessBarCallBack cb = new SetProcessBarCallBack(SetProcessBar);
                this.Invoke(cb, new object[] { current, total });
            }
            else
            {
                this.progressBarCurrent.Value = current;
                this.progressBarTotal.Value = total;
            }
        }

        delegate void ExitCallBack(bool success);
        private void Exit(bool success)
        {
            if (this.InvokeRequired)
            {
                ExitCallBack cb = new ExitCallBack(Exit);
                this.Invoke(cb, new object[] { success });
            }
            else
            {
                this.isFinished = success;
                this.DialogResult = success ? DialogResult.OK : DialogResult.Cancel;
                this.Close();
            }
        }

        private void OnCancel(object sender, EventArgs e)
        {
            evtDownload.Set();
            evtPerDonwload.Set();
        }
    }
}