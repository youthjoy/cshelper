using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using QX.UpdateModel;

namespace QX.UpdateHelper
{
    public class AutoUpdater
    {
        const string FILENAME = "update.config";
        //private Config config = null;
        private bool bNeedRestart = false;

        public AutoUpdater()
        {
            //config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
        }
        /// <summary>
        /// ����°汾
        /// </summary>
        /// <exception cref="System.Net.WebException">�޷��ҵ�ָ����Դ</exception>
        /// <exception cref="System.NotSupportException">������ַ���ô���</exception>
        /// <exception cref="System.Xml.XmlException">���ص������ļ��д���</exception>
        /// <exception cref="System.ArgumentException">���ص������ļ��д���</exception>
        /// <exception cref="System.Excpetion">δ֪����</exception>
        /// <returns></returns>
        public void Update()
        {
            //if (!config.Enabled)
            //    return;
            /*
             * ����Web���������õ���ǰ���°汾���ļ��б���ʽͬ���ص�FileList.xml��
             * �뱾�ص�FileList.xml�Ƚϣ��ҵ���ͬ�汾���ļ�
             * ����һ�������ļ��б���ʼDownloadProgress
             * <UpdateFile>
             *  <File path="" url="" lastver="" size=""></File>
             * </UpdateFile>
             * pathΪ�����Ӧ�ó����Ŀ¼�����Ŀ¼λ�ã������ļ���
             */
            //WebClient client = new WebClient();

            //string strXml = client.DownloadString(config.ServerUrl);
            string path = Application.StartupPath;
            string LocalFullPath = Path.Combine(path, "update.xml");
            string ftpPath = Path.Combine(path, "ftp.xml");
            Dictionary<string, string> ftpSource = GetFtpAddr(ftpPath);
            FTP client = new FTP(new Uri(ftpSource["Addr"]), ftpSource["User"], ftpSource["Pwd"]);

            if (File.Exists(LocalFullPath))
            {
                File.Delete(LocalFullPath);
            }
            if (!client.FileExist("update.xml"))
            {
                return;
            }
            bool s = client.DownloadFile("update.xml", path, "update.xml");
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(path + "/update.xml");
            }
            catch (Exception ex)
            {

            }
            if (sr == null)
            {
                return;
            }
            string strXml = sr.ReadToEnd();

            StreamReader oldSr = new StreamReader(Application.StartupPath + "/version.xml");
            string oldXml = oldSr.ReadToEnd();
            if (!VersionCompare(strXml, oldXml))
            {
                return;
            }

            Dictionary<string, RemoteFile> listRemotFile = ParseRemoteXml(strXml);



            List<DownloadFileInfo> downloadList = new List<DownloadFileInfo>();

            //ĳЩ�ļ�������Ҫ�ˣ�ɾ��
            List<LocalFile> preDeleteFile = new List<LocalFile>();

            //foreach (LocalFile file in config.UpdateFileList)
            //{
            //    if (listRemotFile.ContainsKey(file.Path))
            //    {
            //        RemoteFile rf = listRemotFile[file.Path];
            //        if (rf.LastVer != file.LastVer)
            //        {
            //            downloadList.Add(new DownloadFileInfo(rf.Url, file.Path, rf.LastVer, rf.Size));
            //            file.LastVer = rf.LastVer;
            //            file.Size = rf.Size;

            //            if (rf.NeedRestart)
            //                bNeedRestart = true;
            //        }

            //        listRemotFile.Remove(file.Path);
            //    }
            //    else
            //    {
            //        preDeleteFile.Add(file);
            //    }
            //}

            foreach (RemoteFile file in listRemotFile.Values)
            {
                downloadList.Add(new DownloadFileInfo(file.Url, file.Path, file.LastVer, file.Size));
                //config.UpdateFileList.Add(new LocalFile(file.Path, file.LastVer, file.Size));

                if (file.NeedRestart)
                    bNeedRestart = true;
            }

            if (downloadList.Count > 0)
            {
                DownloadConfirm dc = new DownloadConfirm(downloadList);

                if (this.OnShow != null)
                    this.OnShow();

                if (DialogResult.OK == dc.ShowDialog())
                {
                    StartDownload(downloadList);
                }
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

        private void StartDownload(List<DownloadFileInfo> downloadList)
        {
            //DownloadProgress dp = new DownloadProgress(downloadList);
            //if (dp.ShowDialog() == DialogResult.OK)
            //{
            //���³ɹ�
            //config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));

            //if (bNeedRestart)
            //{

            //if (Alert.ShowIsConfirm("������Ҫ������������Ӧ�ø��£�����ȷ��������������"))
            //{
            MessageBox.Show("������Ҫ������������Ӧ�ø��£�����ȷ��������������","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Process.Start(Path.Combine(Application.StartupPath, "QX.UpdateLoader.exe"));
            Environment.Exit(0);
            //}
            //}
            //}
        }

        public bool VersionCompare(string xml, string old)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            XmlDocument document1 = new XmlDocument();
            document1.LoadXml(old);
            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            XmlNode node = document.SelectSingleNode("/root/version");
            XmlNode oldNode = document1.SelectSingleNode("/root/version");
            var s = node.Attributes["ver"].Value;
            string curVer = oldNode.Attributes["CurVer"].Value;
            int oldver = Convert.ToInt32(curVer);
            var v = Convert.ToInt32(s);
            if (oldver < v)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
        public event ShowHandler OnShow;
    }




    public delegate void ShowHandler();


}
