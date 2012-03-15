using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QX.Helper;
using QX.GenFramework.BseControl;
using System.IO;

namespace QX.UI.Sys
{
    public partial class ServiceConfig : Bse_PopForm
    {
        public ServiceConfig()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new EventHandler(ServiceConfig_Load);
        }

        void ServiceConfig_Load(object sender, EventArgs e)
        {
            string path= XmlHelper.GetConfig("LocalPath");
            this.textBox1.Text = path;

            if (!Directory.Exists(path))
            {
                Alert.Show("您配置的文件夹路径在该计算机上不存在 ！");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
            {
                string path = folderBrowserDialog1.SelectedPath;
                XmlHelper.UpdateConfig("LocalPath", path);

                this.textBox1.Text = path;
            }
        }
    }
}
