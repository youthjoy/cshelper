using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.Model;
using System.Data.SqlClient;
using System.Data;

namespace QX.DAL
{
    public partial class ADOProd_Doc
    {
        /// <summary>
        /// 获取指定的Prod_Doc对象集合
        /// </summary>
        public List<Prod_Doc> GetListByWhereExtend(string strCondition)
        {
            List<Prod_Doc> ret = new List<Prod_Doc>();
            string sql = "SELECT  PRDQ_ID,PRDQ_Code,PRDQ_CompNo,PRDQ_CompCode,PRDQ_CompName,PRDQ_Name,PRDQ_Type,PRDQ_iType,PRDQ_Date,PRDQ_Owner,PRDQ_Plant,PRDQ_Result,PRDQ_FCode,PRDQ_FReso,PRDQ_FOpi,PRDQ_FDeC,PRDQ_Bak,PRDQ_FDate,PRDQ_IsScan,PRDQ_IsNeed,Stat,Creator,CreateTime,UpdateTime,DeleteTime,isnull((select top 1 CCF_Directory from cc_file where isnull(stat,0)=0 and CCF_DCode=PRDQ_Code order by CCF_ID Desc),'') CCF_Directory FROM Prod_Doc WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
                    Prod_Doc prod_Doc = new Prod_Doc();
                    if (dr["PRDQ_ID"] != DBNull.Value) prod_Doc.PRDQ_ID = Convert.ToDecimal(dr["PRDQ_ID"]);
                    if (dr["PRDQ_Code"] != DBNull.Value) prod_Doc.PRDQ_Code = Convert.ToString(dr["PRDQ_Code"]);
                    if (dr["PRDQ_CompNo"] != DBNull.Value) prod_Doc.PRDQ_CompNo = Convert.ToString(dr["PRDQ_CompNo"]);
                    if (dr["PRDQ_CompCode"] != DBNull.Value) prod_Doc.PRDQ_CompCode = Convert.ToString(dr["PRDQ_CompCode"]);
                    if (dr["PRDQ_CompName"] != DBNull.Value) prod_Doc.PRDQ_CompName = Convert.ToString(dr["PRDQ_CompName"]);
                    if (dr["PRDQ_Name"] != DBNull.Value) prod_Doc.PRDQ_Name = Convert.ToString(dr["PRDQ_Name"]);
                    if (dr["PRDQ_Type"] != DBNull.Value) prod_Doc.PRDQ_Type = Convert.ToString(dr["PRDQ_Type"]);
                    if (dr["PRDQ_iType"] != DBNull.Value) prod_Doc.PRDQ_iType = Convert.ToString(dr["PRDQ_iType"]);
                    if (dr["PRDQ_Date"] != DBNull.Value) prod_Doc.PRDQ_Date = Convert.ToString(dr["PRDQ_Date"]);
                    if (dr["PRDQ_Owner"] != DBNull.Value) prod_Doc.PRDQ_Owner = Convert.ToString(dr["PRDQ_Owner"]);
                    if (dr["PRDQ_Plant"] != DBNull.Value) prod_Doc.PRDQ_Plant = Convert.ToString(dr["PRDQ_Plant"]);
                    if (dr["PRDQ_Result"] != DBNull.Value) prod_Doc.PRDQ_Result = Convert.ToString(dr["PRDQ_Result"]);
                    if (dr["PRDQ_FCode"] != DBNull.Value) prod_Doc.PRDQ_FCode = Convert.ToString(dr["PRDQ_FCode"]);
                    if (dr["PRDQ_FReso"] != DBNull.Value) prod_Doc.PRDQ_FReso = Convert.ToString(dr["PRDQ_FReso"]);
                    if (dr["PRDQ_FOpi"] != DBNull.Value) prod_Doc.PRDQ_FOpi = Convert.ToString(dr["PRDQ_FOpi"]);
                    if (dr["PRDQ_FDeC"] != DBNull.Value) prod_Doc.PRDQ_FDeC = Convert.ToString(dr["PRDQ_FDeC"]);
                    if (dr["PRDQ_Bak"] != DBNull.Value) prod_Doc.PRDQ_Bak = Convert.ToString(dr["PRDQ_Bak"]);
                    if (dr["PRDQ_FDate"] != DBNull.Value) prod_Doc.PRDQ_FDate = Convert.ToString(dr["PRDQ_FDate"]);
                    if (dr["PRDQ_IsScan"] != DBNull.Value) prod_Doc.PRDQ_IsScan = Convert.ToInt32(dr["PRDQ_IsScan"]);
                    if (dr["PRDQ_IsNeed"] != DBNull.Value) prod_Doc.PRDQ_IsNeed = Convert.ToString(dr["PRDQ_IsNeed"]);
                    if (dr["Stat"] != DBNull.Value) prod_Doc.Stat = Convert.ToInt32(dr["Stat"]);
                    if (dr["Creator"] != DBNull.Value) prod_Doc.Creator = Convert.ToDateTime(dr["Creator"]);
                    if (dr["CreateTime"] != DBNull.Value) prod_Doc.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    if (dr["UpdateTime"] != DBNull.Value) prod_Doc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
                    if (dr["DeleteTime"] != DBNull.Value) prod_Doc.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);

                    //扩展
                    if (dr["CCF_Directory"] != DBNull.Value) prod_Doc.CCF_Directory = dr["CCF_Directory"].ToString();

                    ret.Add(prod_Doc);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); } }
            return ret;
        }
    }
}
