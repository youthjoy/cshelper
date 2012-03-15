using System;
using System.Collections.Generic;
using System.Text;
using QX.DAL;
using QX.Model;
using System.Data;
using QX.GenFramework.Utils;

namespace QX.BLL
{
    public class DeptCodeEnum
    {
        /// <summary>
        /// 生技处
        /// </summary>
        public static string ProductDept = "D007";
        /// <summary>
        /// 经营处
        /// </summary>
        public static string BussinessDept = "D008";
    }

    public class Bll_Dept
    {
        private ADOBse_Department instance = new ADOBse_Department();

        /// <summary>
        /// 获取所有的部门信息
        /// </summary>
        /// <returns></returns>
        public List<Bse_Department> GetAllDept()
        {
            List<Bse_Department> list = instance.GetAll();
            return list;
        }
        /// <summary>
        /// 生成部门编码
        /// </summary>
        /// <returns></returns>
        public string GenerateDeptCode()
        {
            return new Bll_Comm().GenerateCode("Bse_Department");
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertDept(Bse_Department model)
        {
            int _result = 0;
            try
            {
              
                _result = TypeConverter.ObjectToInt(instance.AddWithReturn(model));

                if (_result > 0)
                {
                    //result = true;
                }
            }
            catch (Exception)
            {
                
            }

            return _result;
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="strCondition"></param>
        /// <returns></returns>
        public Bse_Department GetDeptModel(string strCondition)
        {
            List<Bse_Department> list = instance.GetListByWhere(strCondition);
            Bse_Department model = new Bse_Department();
            if (list != null && list.Count > 0)
            {
                model = list[0];
            }
            return model;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateDept(Bse_Department model)
        {
            bool result = false;
            int _rseult = instance.Update(model);
            if (_rseult > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 逻辑删除数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteDept(string Dept_Code)
        {
            bool result = false;
            List<Bse_Department> list = instance.GetListByWhere(" AND Dept_Code='" + Dept_Code + "'");
            if (list.Count > 0)
            {
                Bse_Department model = list[0];
                model.Stat = 1;
                int _rseult = instance.Update(model);
                if (_rseult > 0)
                {
                    result = true;
                }
            }
            return result;
        }

    }
}
