using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using QX.DataAcess;

namespace QX.DAL
{
    public class ADOComm
    {
        private IDBOperator idb = DBOperator.GetInstance();

        /// <summary>
        /// 获取编码
        /// </summary>
        /// <param name="sTable"></param>
        /// <returns></returns>
        public string GetTableKeyCode(string sTable)
        {
            SqlParameter x1 = new SqlParameter("@sTable", SqlDbType.NChar, 40);
            x1.Value = sTable.Trim();
            SqlParameter[] param = new SqlParameter[] { x1 };
            IDbDataParameter[] parames = param as IDbDataParameter[];
            DataTable dt =idb.RunProcReturnDatatable("findnewid", parames);
            return dt.Rows[0][0].ToString();
        }

        /// <summary>
        /// 获取某个表某个字段最大值
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public object GetMax(string tableName, string col)
        {
            string sql = string.Format(@"SELECT
	isnull(Max({0}),0)
FROM
	{1} WHERE 1=1", col, tableName);

            return idb.ReturnValue(sql);
        } 
        
        /// <summary>
        /// 根据条件获取某个表的相关记录数
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public object GetCount(string tableName, string where)
        {
            string sql = string.Format(@"SELECT
	count(1)
FROM
	{0} WHERE 1=1 {1}",tableName,where);

            return idb.ReturnValue(sql);
        }

        /// <summary>
        /// 通用执行存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parames"></param>
        /// <returns></returns>
        public DataTable ExcuteProc(string procName, params IDbDataParameter[] parames)
        {
            //SqlParameter x1 = new SqlParameter("@sTable", SqlDbType.NChar, 40);
            //x1.Value = sTable.Trim();
            //SqlParameter[] param = new SqlParameter[] { x1 };
            //IDbDataParameter[] parames = param as IDbDataParameter[];
            DataTable dt = idb.RunProcReturnDatatable(procName, parames);
            return dt;
        }

        public DataTable ExcuteProc(string procName)
        {
            //SqlParameter x1 = new SqlParameter("@sTable", SqlDbType.NChar, 40);
            //x1.Value = sTable.Trim();
            //SqlParameter[] param = new SqlParameter[] { x1 };
            //IDbDataParameter[] parames = param as IDbDataParameter[];
            DataTable dt = idb.RunProcReturnDatatable(procName);
            return dt;
        }


        public DataTable ExcuteSql(string sql)
        {
            //SqlParameter x1 = new SqlParameter("@sTable", SqlDbType.NChar, 40);
            //x1.Value = sTable.Trim();
            //SqlParameter[] param = new SqlParameter[] { x1 };
            //IDbDataParameter[] parames = param as IDbDataParameter[];
            DataTable dt = idb.ReturnDataTable(sql);
            return dt;
        }


        public DataTable GetInitialRecords(string tplCode,string opType)
        {
            DataTable dt = idb.RunProcReturnDatatable("qx_tech_InitialRecord", new List<SqlParameter>() { new SqlParameter("@tplCode", tplCode), new SqlParameter("@tplType",opType) }.ToArray());
            return dt;
        }

        public DataTable GetInitialORecords(string tplCode, string opType)
        {
            DataTable dt = idb.RunProcReturnDatatable("qx_tech_OpenRecord", new List<SqlParameter>() { new SqlParameter("@tplCode", tplCode), new SqlParameter("@tplType", opType) }.ToArray());
            return dt;
        }


        public DataTable GetInitialERecords(string tplCode, string opType)
        {
            DataTable dt = idb.RunProcReturnDatatable("qx_tech_EquRecord", new List<SqlParameter>() { new SqlParameter("@tplCode", tplCode), new SqlParameter("@tplType", opType) }.ToArray());
            return dt;
        }
    }
}
