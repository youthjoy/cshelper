using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using QX.BLL;
using QX.Framework.AutoForm;
using QX.Common.BseControl;
using QX.Model;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using QX.Common;
using QX.Shared;

namespace QX.UI.Sys
{
    public partial class ChangePass :Bse_PopForm
    {
        public ChangePass()
        {
            InitializeComponent();

            EventInit();
        }
      
        private void EventInit()
        {
            this.commonToolBar1.SaveClicked += new EventHandler(commonToolBar1_SaveClicked);
        }

        void commonToolBar1_SaveClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBox2.Text) && CurEmp != null)
            {
                if (this.textBox2.Text != this.textBox3.Text)
                {
                    Alert.Show("两次密码输入不一致!");
                    return;
                }

                string oldpwd = this.textBox1.Text;
                if (!oldpwd.Equals(CurEmp.Emp_LoginPwd))
                {
                    Alert.Show("原密码输入错误,请重新输入!");
                    return;
                }

                CurEmp.Emp_LoginPwd = this.textBox2.Text;

                var re = empInstance.UpdateEmployee(CurEmp);
                if (re)
                {
                    Alert.Show("密码更新成功!");
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                }
            }
        }

        private void ChangePass_Load(object sender, EventArgs e)
        {
            CurEmp = GetUserModel(SessionConfig.UserID);
            if (CurEmp != null)
            {
                //this.textBox1.Text = CurEmp.Emp_LoginPwd;
            }

        }

        private Bse_Employee CurEmp
        {
            get;
            set;
        }
       
        private Bll_Bse_Employee empInstance = new Bll_Bse_Employee();

        private Bse_Employee GetUserModel(string userName)
        {
            string where = string.Format(" AND Emp_LoginID='{0}'", userName);

            Bse_Employee model = empInstance.GetModel(where);

            return model;
        }
    }
}
