using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QX.UpdateModel;

namespace QX.UpdateHelper
{
    public partial class DownloadConfirm : Form
    {
        List<DownloadFileInfo> downloadFileList = null;

        public DownloadConfirm(List<DownloadFileInfo> dfl)
        {
            InitializeComponent();

            downloadFileList = dfl;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            foreach (DownloadFileInfo file in this.downloadFileList)
            {
                ListViewItem item = new ListViewItem(new string[] { file.FileName, file.LastVer, file.Size.ToString() });
                this.listDownloadFile.Items.Add(item);
            }

            this.Activate();
            this.Focus();
        }
    }
}