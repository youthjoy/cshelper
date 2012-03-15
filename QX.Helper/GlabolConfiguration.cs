using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QX.Helper
{
    public class GlabolConfiguration
    {
        public static readonly string BaseDirectory = Path.GetDirectoryName(Application.ExecutablePath);

        public static readonly string SeverPath = "\\\\192.168.1.100\\ftp";
    }
}
