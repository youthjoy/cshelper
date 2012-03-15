using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DAL;
using QX.Model;
using QX.DataAcess;
using System.Data.SqlClient;
using System.Data;
namespace QX.DAL
{
    public partial class ADOCC_File
    {
        public List<CC_File> GetListByWhereExtend(string strCondition)
        {
            List<CC_File> ret = new List<CC_File>();
            string sql = "SELECT  CCF_ID,CCF_Code,CCF_DCode,CCF_CompNo,CCF_Name,CCF_iType,CCF_Directory,CCF_Bak,CCF_DownTime,CCF_RCount,CCF_RDirectory,CCF_ROwner,CCF_RDate,CCF_RBak,cc.Stat,cc.Creator,cc.CreateTime,cc.UpdateTime,cc.DeleteTime FROM CC_File cc JOIN Prod_Doc pp on pp.PRDQ_Code=CCF_DCode WHERE 1=1 AND ((cc.Stat is null) or (cc.Stat=0) ) ";
            if (!string.IsNullOrEmpty(strCondition))
            {
                strCondition.Replace('\'', '"'); //防sql注入
                sql += strCondition;
            }
            SqlDataReader dr = null;
            try
            {
                dr = (SqlDataReader)idb.ReturnReader(sql);
                while (dr.Read())
                {
                    CC_File cC_File = new CC_File();
                    if (dr["CCF_ID"] != DBNull.Value) cC_File.CCF_ID = Convert.ToDecimal(dr["CCF_ID"]);
                    if (dr["CCF_Code"] != DBNull.Value) cC_File.CCF_Code = Convert.ToString(dr["CCF_Code"]);
                    if (dr["CCF_DCode"] != DBNull.Value) cC_File.CCF_DCode = Convert.ToString(dr["CCF_DCode"]);
                    if (dr["CCF_CompNo"] != DBNull.Value) cC_File.CCF_CompNo = Convert.ToString(dr["CCF_CompNo"]);
                    if (dr["CCF_Name"] != DBNull.Value) cC_File.CCF_Name = Convert.ToString(dr["CCF_Name"]);
                    if (dr["CCF_iType"] != DBNull.Value) cC_File.CCF_iType = Convert.ToString(dr["CCF_iType"]);
                    if (dr["CCF_Directory"] != DBNull.Value) cC_File.CCF_Directory = Convert.ToString(dr["CCF_Directory"]);
                    if (dr["CCF_Bak"] != DBNull.Value) cC_File.CCF_Bak = Convert.ToString(dr["CCF_Bak"]);
                    if (dr["CCF_DownTime"] != DBNull.Value) cC_File.CCF_DownTime = Convert.ToString(dr["CCF_DownTime"]);
                    if (dr["CCF_RCount"] != DBNull.Value) cC_File.CCF_RCount = Convert.ToInt32(dr["CCF_RCount"]);
                    if (dr["CCF_RDirectory"] != DBNull.Value) cC_File.CCF_RDirectory = Convert.ToString(dr["CCF_RDirectory"]);
                    if (dr["CCF_ROwner"] != DBNull.Value) cC_File.CCF_ROwner = Convert.ToString(dr["CCF_ROwner"]);
                    if (dr["CCF_RDate"] != DBNull.Value) cC_File.CCF_RDate = Convert.ToDateTime(dr["CCF_RDate"]);
                    if (dr["CCF_RBak"] != DBNull.Value) cC_File.CCF_RBak = Convert.ToString(dr["CCF_RBak"]);
                    if (dr["Stat"] != DBNull.Value) cC_File.Stat = Convert.ToInt32(dr["Stat"]);
                    if (dr["Creator"] != DBNull.Value) cC_File.Creator = Convert.ToDateTime(dr["Creator"]);
                    if (dr["CreateTime"] != DBNull.Value) cC_File.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    if (dr["UpdateTime"] != DBNull.Value) cC_File.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
                    if (dr["DeleteTime"] != DBNull.Value) cC_File.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
                    ret.Add(cC_File);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); } }
            return ret;
        }
    }
}
