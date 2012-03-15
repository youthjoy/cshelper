using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace QX.UpdateModel
{
    public class DownloadFileInfo
    {
        string downloadUrl = "";
        string fileName = "";
        string lastver = "";
        int size = 0;

        /// <summary>
        /// 要从哪里下载文件
        /// </summary>
        public string DownloadUrl { get { return downloadUrl; } }
        /// <summary>
        /// 下载完成后要放到哪里去
        /// </summary>
        public string FileFullName { get { return fileName; } }
        public string FileName { get { return Path.GetFileName(FileFullName); } }
        public string LastVer { get { return lastver; } set { lastver = value; } }
        public int Size { get { return size; } }

        public DownloadFileInfo(string url, string name, string ver, int size)
        {
            this.downloadUrl = url;
            this.fileName = name;
            this.lastver = ver;
            this.size = size;
        }
    }
}
