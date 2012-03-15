using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.Model;

namespace QX.Shared
{
    public sealed  class SessionConfig
    {
        private static string _UserId;
        public static string UserID
        {
            get { return _UserId; }
            set { _UserId = value; }
        }


        public static string CompanyCode
        {
            get;
            set;
        }

        public static string CompanyName
        {
            get;
            set;
        }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public static string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public static string EmpName
        {
            get;
            set;
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public static string DeptName
        {
            get;
            set;
        }


        /// <summary>
        /// 员工编号
        /// </summary>
        public static string UserCode
        {
            get;
            set;
        }

        /// <summary>
        /// 部门编码
        /// </summary>
        public static string DeptCode
        {
            get;
            set;
        }

        public static bool IsAdmin
        {
            get;
            set;
        }



        public static int ProductPlanInterval
        {
            get
            {
                return 5000;
            }
        }
        public static int ProductPlanListInterval
        {
            get
            {
                return 5000;
            }
        }



        #region 通用数据源

        public static List<Sys_Map> PositionMapSource
        {
            get;
            set;
        }

        #endregion
    }
}
