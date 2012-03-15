using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QX.Model;
using QX.Common.BseControl;

namespace QX.UI.Components
{
    public partial class ConfirmWin : Bse_PopForm
    {
        public ConfirmWin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            MapList = mapInstance.GetMap("MPassword");
        }

        public bool IsAllow
        {
            get;
            set;
        }

        List<Sys_Map> MapList
        {
            get;
            set;
        }

        public delegate void DCallBackHandler(bool flag);
        public event DCallBackHandler CallBack;


        BLL.Bll_SysMap mapInstance = new QX.BLL.Bll_SysMap(); 
        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;

            if (MapList.FirstOrDefault(o => o.Map_Object == text) != null)
            {
                IsAllow = true;
                this.Close();
            }
            else
            {
                IsAllow = false;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsAllow = false;
            this.Close();
        }
    }
}
