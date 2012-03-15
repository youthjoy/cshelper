using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.GenFramework.Helper;
using System.IO;


namespace QX.BLL
{
    public class Bll_File
    {
        public FTP ftp;

        public Bll_File()
        {
           var address= QX.Helper.XmlHelper.GetConfig("FtpAddress");
           var username = QX.Helper.XmlHelper.GetConfig("UserName");
           var password = QX.Helper.XmlHelper.GetConfig("Password");
           ftp = new FTP(new Uri(address), username, password);
            
        }

        public bool DownloadFile(string localpath, string remotepath)
        {
            string path = Path.GetDirectoryName(remotepath);
            ftp.GotoDirectory("." + path);
            string filename = Path.GetFileName(remotepath);
            return ftp.DownloadFile(filename, localpath);
        }



        public void UploadNewFile(string path,string localpath)
        {
            ftp.UploadFileAsync(localpath);
          
        }

        public bool UploadFile(string local,bool overwrite)
        {
            
            return ftp.UploadFile(local, overwrite);
        }

        public void UploadComponents(string path, string localpath)
        { 
           
        }

        public void UploadProd(string path, string localpath)
        { 
           
        }

        public FileStruct[] GetListDirectoryAndFile()
        {
             var list=ftp.ListFilesAndDirectories();
             return list;
        }

        public void GotoDirectory(string dname)
        {
             var flag=ftp.GotoDirectory(dname);
        }

        public void ComSubDerectory(string name)
        {
            var flag = ftp.EnterOneSubDirectory(name);
        }

        public void ComeUpLevel()
        {
            var flag = ftp.ComeoutDirectory();
        }

    }
}
