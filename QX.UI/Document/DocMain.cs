using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QX.GenFramework.Helper;
using Infragistics.Win.UltraWinGrid;
using QX.Model;
using QX.GenFramework.BseControl;

namespace QX.UI.Document
{
    public partial class DocMain : Bse_Form
    {
        public DocMain()
        {
            InitializeComponent();

            BindTopTool();

            this.Load += new EventHandler(DocMain_Load);
        }

        public void BindTopTool()
        {
            ToolBarHelper tsHelper = new ToolBarHelper();
            ToolStripButton scanDocBtn = tsHelper.New("关联文档", QX.GenFramework.Properties.Resources.batch, new EventHandler(scanDocBtn_Click));
            //ucProdAll.AddCustomBtn(scanDocBtn, 7);
        }

        void scanDocBtn_Click(object sender, EventArgs e)
        {
           // UltraGridRow row = ucProdAll.GetActiveRow();
            //if (row != null)
            //{
            //    Prod_Pool p = row.ListObject as Prod_Pool;
            //    DocScan docScanFrm = new DocScan(p);
            //    docScanFrm.Show();
            //}
        }

        void DocMain_Load(object sender, EventArgs e)
        {
            
        }
    }
}
