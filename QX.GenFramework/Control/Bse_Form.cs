using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QX.GenFramework.BseControl
{
    public class Bse_Form : Form
    {
        public Bse_Form()
        {
            //InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            //IsEdited = true;
            //this.FormClosing += new FormClosingEventHandler(Bse_Form_FormClosing);
            this.Load += new EventHandler(Bse_Form_Load);
        }

        void Bse_Form_Load(object sender, EventArgs e)
        {
            Init();
        }

        protected void Init()
        {
            this.WindowState = FormWindowState.Maximized;
            IsEdited = false;
            this.FormClosing += new FormClosingEventHandler(Bse_Form_FormClosing);
        }

        void Bse_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsEdited)
            {
                if (!Alert.ShowIsConfirm("确定放弃保存当前编辑数据，关闭该窗口?"))
                {
                      e.Cancel = true;
                }
            }
        }

        public bool IsEdited
        {
            get;
            set;
        }

        public void CloseForm()
        {
            if (IsEdited)
            {
                if (Alert.ShowIsConfirm("确定放弃保存当前编辑数据，关闭该窗口?"))
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Bse_Form
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "Bse_Form";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Bse_Form_KeyUp);
            this.ResumeLayout(false);

        }

        private void Bse_Form_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F4)
            //{
            //    SystemInformationHelp helper = new SystemInformationHelp(sender);
            //    helper.Show();
            //    return;
            //}
        }
    }
}
