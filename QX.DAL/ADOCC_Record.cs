using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using QX.Model;
using QX.DataAcess;

namespace QX.DAL
{
   [Serializable]
   public partial class ADOCC_Record
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加CC_Record对象(即:一条记录)
      /// </summary>
      public int Add(CC_Record cC_Record)
      {
         string sql = "INSERT INTO CC_Record () VALUES ()";

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加CC_Record对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(CC_Record cC_Record)
      {
         string sql = "INSERT INTO CC_Record () VALUES ();SELECT @@IDENTITY AS ReturnID;";

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新CC_Record对象(即:一条记录
      /// </summary>
      public int Update(CC_Record cC_Record)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       CC_Record       SET ");
                sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and CCR_ID=@CCR_ID; " );
      string sql=sb.ToString();

         idb.AddParameter("@CCR_ID", cC_Record.CCR_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除CC_Record对象(即:一条记录
      /// </summary>
      public int Delete(decimal cCR_ID)
      {
         string sql = "DELETE CC_Record WHERE 1=1  AND CCR_ID=@CCR_ID ";
         idb.AddParameter("@CCR_ID", cCR_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的CC_Record对象(即:一条记录
      /// </summary>
      public CC_Record GetByKey(decimal cCR_ID)
      {
         CC_Record cC_Record = new CC_Record();
         string sql = "SELECT  CCR_ID FROM CC_Record WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND CCR_ID=@CCR_ID ";
         idb.AddParameter("@CCR_ID", cCR_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["CCR_ID"] != DBNull.Value) cC_Record.CCR_ID = Convert.ToDecimal(dr["CCR_ID"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return cC_Record;
      }
      /// <summary>
      /// 获取指定的CC_Record对象集合
      /// </summary>
      public List<CC_Record> GetListByWhere(string strCondition)
      {
         List<CC_Record> ret = new List<CC_Record>();
         string sql = "SELECT  CCR_ID FROM CC_Record WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
         if(!string.IsNullOrEmpty(strCondition))
         {
            strCondition.Replace('\'','"'); //防sql注入
            sql += strCondition ;
         }
          sql += " ORDER BY CCR_ID DESC "; 
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            CC_Record cC_Record = new CC_Record();
            if (dr["CCR_ID"] != DBNull.Value) cC_Record.CCR_ID = Convert.ToDecimal(dr["CCR_ID"]);
            ret.Add(cC_Record);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的CC_Record对象(即:一条记录
      /// </summary>
      public List<CC_Record> GetAll()
      {
         List<CC_Record> ret = new List<CC_Record>();
         string sql = "SELECT  CCR_ID FROM CC_Record where 1=1 AND ((Stat is null) or (Stat=0) ) order by CCR_ID desc ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            CC_Record cC_Record = new CC_Record();
            if (dr["CCR_ID"] != DBNull.Value) cC_Record.CCR_ID = Convert.ToDecimal(dr["CCR_ID"]);
            ret.Add(cC_Record);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
