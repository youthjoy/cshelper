using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QX.GenFramework.BseControl
{
    public partial class Bse_PopForm : Form
    {
        public bool isAudit = false;

        public Bse_PopForm()
        {
            //InitializeComponent();
            //this.FormClosing += new FormClosingEventHandler(F_BasicPop_FormClosing);
            //IsEdited = true;

            //this.Load += new EventHandler(Bse_PopForm_Load);
        }

        void Bse_PopForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        public bool IsFix = false;
        

        public void Init()
        {
            Init(false);
        }

        public void Init(bool isAllowKeyup)
        {

            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            if (IsFix)
            {
                this.MinimizeBox = false;
                this.MaximizeBox = false;
            }
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (isAllowKeyup)
            {
                this.KeyPreview = true;

                this.KeyUp += new KeyEventHandler(Bse_PopForm_KeyUp);
            }
        }


        public bool IsEdited
        {
            get;
            set;
        }

        void Bse_PopForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        void F_BasicPop_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (IsEdited)
            //{
            //    if (!Alert.ShowIsConfirm("未保存数据将会丢失，确定关闭该窗口吗?"))
            //    {
            //        e.Cancel = true;
            //        return;
            //    }

            //}

            if (isAudit == false)
            {
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void Bse_PopForm_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                //SystemInformationHelp helper = new SystemInformationHelp(sender);
                //helper.Show();
                //return;
            }
        }
    }
}
