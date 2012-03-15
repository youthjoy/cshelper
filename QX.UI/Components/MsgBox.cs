using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QX.UI.Comm
{
    public partial class MsgBox : Form
    {
        public MsgBox(string msg)
        {
            InitializeComponent();
            //this.uteSystemInformation.texta
            this.uteSystemInformation.Text = msg;
            
            this.StartPosition = FormStartPosition.CenterScreen;

            this.MaximizeBox = false;
        }


    }
}
