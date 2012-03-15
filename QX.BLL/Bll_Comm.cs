using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    public class Bll_Comm
    {

        private ADOComm instance = new ADOComm();

        private ADOSys_Map MapInstance = new ADOSys_Map();

        public List<Sys_Map> GetMapData(string module)
        {
            string where = string.Format(" AND Map_Module='{0}'",module);
            return MapInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取自增编码
        /// </summary>
        /// <param name="NameSapce"></param>
        /// <returns></returns>
        public string GenerateCode(string NameSapce)
        {
            return instance.GetTableKeyCode(NameSapce);
        }


        public object GetCount(string tableName, string where)
        {
            return instance.GetCount(tableName, where);
        }

        public DataTable ExcuteProc(string procName, IDbDataParameter[] para)
        {
            return instance.ExcuteProc(procName, para);
        }


        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DataTable ListViewData(string sql)
        {
            return instance.ExcuteSql(sql);
        }

        /// <summary>
        /// 自增编码-单据(连续编号)
        /// </summary>
        /// <param name="CompanyCode">公司编码</param>
        /// <param name="Module">模块编码</param>
        /// <returns></returns>
        public  string GetTableKeyForPU(string CompanyCode, string Module)
        {
            //ADOSys_Config_Refer instance = new ADOSys_Config_Refer();
            SqlParameter x1 = new SqlParameter("@CompanyCode", SqlDbType.VarChar, 20);
            x1.Value = CompanyCode == null ? "" : CompanyCode;

            SqlParameter x2 = new SqlParameter("@ModuleCode", SqlDbType.VarChar, 20);
            x2.Value = Module;

            SqlParameter x3 = new SqlParameter("@GeneralType", SqlDbType.VarChar, 20);
            x3.Value = "";

            SqlParameter x4 = new SqlParameter("@code", SqlDbType.VarChar, 20);
            x4.Direction = ParameterDirection.Output;

            SqlParameter[] param = new SqlParameter[] { x1, x2, x3, x4 };
            IDbDataParameter[] parames = param as IDbDataParameter[];
            DataTable dt = instance.ExcuteProc("qx_sp_compcode", parames);
            return dt.Rows[0][0].ToString();
        }


        public string GetTableKey(string CompanyCode, string Module)
        {
            
            SqlParameter x1 = new SqlParameter("@CompanyCode", SqlDbType.VarChar, 20);
            x1.Value = CompanyCode == null ? "" : CompanyCode;

            SqlParameter x2 = new SqlParameter("@ModuleCode", SqlDbType.VarChar, 20);
            x2.Value = Module;

            SqlParameter x3 = new SqlParameter("@GeneralType", SqlDbType.VarChar, 20);
            x3.Value = DBNull.Value;

            SqlParameter x4 = new SqlParameter("@code", SqlDbType.VarChar, 20);
            x4.Direction = ParameterDirection.Output;

            SqlParameter[] param = new SqlParameter[] { x1, x2, x3, x4 };
            IDbDataParameter[] parames = param as IDbDataParameter[];
            DataTable dt = instance.ExcuteProc("qx_sp_compcode", parames);
            return dt.Rows[0][0].ToString();
        }


        public DataTable ExcuteProc(string procName)
        {
            return instance.ExcuteProc(procName);
        }

        ///// <summary>
        ///// 获取依赖映射的信息
        ///// </summary>
        ///// <param name="RefDepend_Code"></param>
        ///// <param name="Module"></param>
        ///// <returns></returns>
        //public static Sys_Rec_RefDepend CommRefDepend(string RefDepend_Code)
        //{
        //    ADOSys_Rec_RefDepend instance = new ADOSys_Rec_RefDepend();
        //    var list = instance.GetListByWhere(" and RefDepend_Code='" + RefDepend_Code + "'  and isnull(RefDepend_ConfFlag,0) = 1");
        //    if (list != null && list.Count > 0)
        //    {
        //        return list[0];
        //    }

        //    return null;
        //}

    }
}
