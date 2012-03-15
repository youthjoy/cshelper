using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QX.GenFramework.AutoForm;
//using BC.Common.Helper;
using QX.Model;
using QX.BLL;
using QX.GenFramework.BseControl;
using QX.GenFramework.Helper;
using System.IO;
//using BC.Shared;

namespace QX.UI
{
    public partial class F_Logon : Form
    {
        public F_Logon()
        {
            InitializeComponent();
        }

        public F_Logon(MethodInvoker mi)
        {
            InitializeComponent();

            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            mInvoker = mi;

            this.Load += new EventHandler(F_LogOn_Load);

            this.FormClosed += new FormClosedEventHandler(F_LogOn_FormClosed);
        }

        private MethodInvoker mInvoker;

        private void InitData()
        {
            FormHelper gen = new FormHelper();

            //gen.GenerateForm("FLogin", this.groupBox1, new Point(6, 20));

        }

        private void F_LogOn_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Login();
        }


        private Bse_Employee GetUserModel(string userName)
        {

            Bse_Employee model = loginInstance.GetUserModel(userName);

            return model;
        }

        private BindModelHelper bmHelper = new BindModelHelper();

        private Bll_Login loginInstance = new Bll_Login();

        //private Bll_UserPermission peInstance = new Bll_UserPermission();

        private Bse_Employee CurEmp = new Bse_Employee();

        private void Login()
        {
            string userName = this.txtUserName.Text.Trim();

            string password = this.txtPassword.Text.Trim();

            LoginResultEnum re = loginInstance.CheckLogin(userName, password, out CurEmp);
            Bll_File fileInstance=new Bll_File();
            switch (re)
            {
                case LoginResultEnum.Success:
                    bool isCon = true;
                    //try
                    //{
                    //    var re1 = fileInstance.ftp.DirectoryExist("Test");
                    //}
                    //catch (Exception ex)
                    //{
                    //    isCon = false;
                    //}

                    //if (isCon)
                    //{

                        Success();
                    //}
                    //else
                    //{
                    //    Alert.Show("请确认当前网络是否连通或FTP服务器已开启!");
                    //}
                    break;
                case LoginResultEnum.InValidName:
                    Alert.Show("用户名无效!");
                    break;
                case LoginResultEnum.InValidPwd:
                    Alert.Show("密码输入错误!");
                    break;
                case LoginResultEnum.NoExsist:
                    Alert.Show("当前用户已失效!");
                    break;
                case LoginResultEnum.Fail:
                    Alert.Show("登录出现异常,请查证后重新登录!");
                    break;
            }

        }

        private void Success()
        {
            QX.Shared.SessionConfig.UserID = CurEmp.Emp_LoginID;
            QX.Shared.SessionConfig.UserName = CurEmp.Emp_Name;
            
            //BC.Shared.SessionConfig.UserID = CurEmp.Stuff_Code;
            //BC.Shared.SessionConfig.UserName = CurEmp.Stuff_UserName;
            //BC.Shared.SessionConfig.EmpName = CurEmp.Stuff_Name;
            //BC.Shared.SessionConfig.UserCode = CurEmp.Stuff_Code;
            //BC.Shared.SessionConfig.DeptCode = CurEmp.Stuff_DepCode;
            //BC.Shared.SessionConfig.DeptName = CurEmp.Stuff_DepName;
            //BC.Shared.SessionConfig.CompanyCode = CurEmp.CompanyCode;
            //BC.Shared.SessionConfig.CompanyName = CurEmp.CompanyName;
            //if (BC.Shared.SessionConfig.UserID == GlobalConfiguration.Admin || peInstance.IsAdmin(CurEmp.Stuff_Code))
            //{
            //    BC.Shared.SessionConfig.IsAdmin = true;
            //    List<Sys_Function> list = peInstance.GetAllFunctionList();
            //    SessionConfig.PermissionList = list;
            //}
            //else
            //{
            //    BC.Shared.SessionConfig.IsAdmin = false;
            //    List<Sys_UserPermission> list = new Bll_Permission().GetUserPermission(SessionConfig.UserID);
            //    var temp = from p in list select new Sys_Function { Fun_Code = p.PU_FunCode,Fun_UDef1=p.FunctionCode };
            //    SessionConfig.PermissionList=temp.ToList();
            ////}
            mInvoker.BeginInvoke(null, null);



            this.Hide();

            
        }

        private void F_LogOn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
