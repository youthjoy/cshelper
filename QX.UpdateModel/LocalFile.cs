using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace QX.UpdateModel
{
    public class LocalFile
    {
        private string path = "";
        private string lastver = "";
        private int size = 0;

        [XmlAttribute("path")]
        public string Path { get { return path; } set { path = value; } }
        [XmlAttribute("lastver")]
        public string LastVer { get { return lastver; } set { lastver = value; } }
        [XmlAttribute("size")]
        public int Size { get { return size; } set { size = value; } }

        public LocalFile(string path, string ver, int size)
        {
            this.path = path;
            this.lastver = ver;
            this.size = size;
        }

        public LocalFile()
        {
        }

    }
}
