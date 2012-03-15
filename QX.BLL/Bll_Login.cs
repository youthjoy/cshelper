using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;
using QX.GenFramework.Helper;
namespace QX.BLL
{
    public enum LoginResultEnum
    {
        Success,
        Fail,
        InValidPwd,
        /// <summary>
        /// 用户名无效
        /// </summary>
        InValidName,
        /// <summary>
        /// 不存在用户
        /// </summary>
        NoExsist,
    }

    public class Bll_Login
    {


        Bll_Bse_Employee empInstance = new Bll_Bse_Employee();

        public LoginResultEnum CheckLogin(string userName, string password, out Bse_Employee model)
        {
            LoginResultEnum re = LoginResultEnum.Fail;
            model = new Bse_Employee();
            try
            {

                //判断用户名是否存在
                model = GetUserModel(userName);
                if (model != null)
                {
                    //if (model.Emp_CanLogin != "Yes")
                    //{
                    //    re = LoginResultEnum.NoExsist;
                    //}
                    //密码有效性验证
                    if (password.Equals(model.Emp_LoginPwd))
                    {
                        re = LoginResultEnum.Success;
                    }
                    else
                    {
                        re = LoginResultEnum.InValidPwd;
                    }

                }
                else
                {
                    re = LoginResultEnum.NoExsist;
                }
            }
            catch (Exception e)
            {
                //Alert.Show(e.Message);
                re = LoginResultEnum.Fail;
            }
            //权限

            return re;
        }

        public Bse_Employee GetUserModel(string userName)
        {
            string where = string.Format(" AND Emp_LoginID='{0}'", userName);

            Bse_Employee model = empInstance.GetModel(where);

            return model;
        }
    }
}
