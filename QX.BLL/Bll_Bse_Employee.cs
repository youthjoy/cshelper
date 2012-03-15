using System;
using System.Collections.Generic;
using System.Text;
using QX.DAL;
using QX.Model;
using QX.GenFramework;
using System.Linq;
using QX.GenFramework.Helper;
namespace QX.BLL
{
    public class Bll_Bse_Employee
    {
        private ADOBse_Employee instance = new ADOBse_Employee();
        //private ADOBse_EmployeeExt eInstance = new ADOBse_EmployeeExt();
        /// <summary>
        /// 获取所有的员工
        /// </summary>
        /// <returns></returns>
        public List<Bse_Employee> GetAllEmployee()
        {
            //string where = string.Format("  and isnull(Emp_LoginID,'')<>'{0}'", GlobalConfiguration.Admin);
            List<Bse_Employee> list = instance.GetAll();
            return list;
        }


       
        /// <summary>
        /// 根据条件获取员工
        /// </summary>
        /// <returns></returns>
        public List<Bse_Employee> GetEmpByDept(string where)
        {
            List<Bse_Employee> list = instance.GetListByWhere(string.Format(" and  isnull(Emp_LoginID,'')<>'{1}'  AND ((Emp_Dept_Code='{0}') or (Emp_Dept_Code in (SELECT     Dept_Code FROM  Bse_Department WHERE     (Dept_PCode = '{0}'))))", where.Replace("'", " ").Trim(), GlobalConfiguration.Admin));
            return list;
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertEmployee(Bse_Employee model)
        {
            //model.Emp_Code = GenerateEmpCode();

            bool result = false;
            int _result = instance.Add(model);
            if (_result > 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 生成员工编码
        /// </summary>
        /// <returns></returns>
        //public string GenerateEmpCode()
        //{
        //    var val = new Bll_Comm().GetMax("Bse_Employee", "Emp_ID");
        //    int re=Common.C_Class.Utils.TypeConverter.ObjectToInt(val)+1;
        //    return re.ToString();

        //}


        /// <summary>
        /// '获取实体
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Bse_Employee GetModel(string condition)
        {
            List<Bse_Employee> list = instance.GetListByWhere(condition);
            Bse_Employee model = new Bse_Employee();
            if (list != null && list.Count > 0)
            {
                model = list[0];
            }
            return model;
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployee(Bse_Employee model)
        {
            bool result = false;
            int _result = instance.Update(model);
            if (_result > 0)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteEmployee(Bse_Employee model)
        {
            bool result = false;
            model.Stat = 1;
            int _result = instance.Update(model);
            if (_result > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
