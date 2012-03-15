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
   public partial class ADOCC_Movement
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加CC_Movement对象(即:一条记录)
      /// </summary>
      public int Add(CC_Movement cC_Movement)
      {
         string sql = "INSERT INTO CC_Movement () VALUES ()";


            int Re = 0;
            //SQL日志记录
            var RunMethod = System.Reflection.MethodBase.GetCurrentMethod();
            System.Collections.Hashtable param = new System.Collections.Hashtable();
            string Ex = string.Empty;
            foreach (System.Collections.DictionaryEntry item in idb.GetParameters())
            {
                  param.Add(item.Key, item.Value);
            }

  
            try
            {
                Re = idb.ExeCmd(sql);
                Ex = Re.ToString();
            }
            catch (Exception ex)
            {
                Ex = ex.Message;
            }
            finally
            {
                SysRunLog.InsertRunSql(sql, param, RunMethod.DeclaringType +"." + RunMethod.Name,Ex);
             }            return Re;
      }
      /// <summary>
      /// 添加CC_Movement对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(CC_Movement cC_Movement)
      {
         string sql = "INSERT INTO CC_Movement () VALUES ();SELECT @@IDENTITY AS ReturnID;";


            int Re = 0;
            //SQL日志记录
            var RunMethod = System.Reflection.MethodBase.GetCurrentMethod();
            System.Collections.Hashtable param = new System.Collections.Hashtable();
            string Ex = string.Empty;
            foreach (System.Collections.DictionaryEntry item in idb.GetParameters())
            {
                  param.Add(item.Key, item.Value);
            }


            object obj=null; 
            try
            {
                obj = idb.ReturnValue(sql);
                Ex = obj.ToString();
            }
            catch (Exception ex)
            {
                Ex = ex.Message;
            }
            finally
            {
                SysRunLog.InsertRunSql(sql, param, RunMethod.DeclaringType +"." + RunMethod.Name,Ex);
            }            return obj;
      }
      /// <summary>
      /// 更新CC_Movement对象(即:一条记录
      /// </summary>
      public int Update(CC_Movement cC_Movement)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       CC_Movement       SET ");
                sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and CCM_ID=@CCM_ID; " );
      string sql=sb.ToString();

         idb.AddParameter("@CCM_ID", cC_Movement.CCM_ID);


            int Re = 0;
            //SQL日志记录
            var RunMethod = System.Reflection.MethodBase.GetCurrentMethod();
            System.Collections.Hashtable param = new System.Collections.Hashtable();
            string Ex = string.Empty;
            foreach (System.Collections.DictionaryEntry item in idb.GetParameters())
            {
                  param.Add(item.Key, item.Value);
            }

 
            try
            {
                Re = idb.ExeCmd(sql);
                Ex = Re.ToString();
            }
            catch (Exception ex)
            {
                Ex = ex.Message;
            }
            finally
            {
                SysRunLog.InsertRunSql(sql, param, RunMethod.DeclaringType +"." + RunMethod.Name,Ex);
            }            return Re;
      }
      /// <summary>
      /// 删除CC_Movement对象(即:一条记录
      /// </summary>
      public int Delete(decimal cCM_ID)
      {
         string sql = "DELETE CC_Movement WHERE 1=1  AND CCM_ID=@CCM_ID ";
         idb.AddParameter("@CCM_ID", cCM_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的CC_Movement对象(即:一条记录
      /// </summary>
      public CC_Movement GetByKey(decimal cCM_ID)
      {
         CC_Movement cC_Movement = new CC_Movement();
         string sql = "SELECT  CCM_ID FROM CC_Movement WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND CCM_ID=@CCM_ID ";
         idb.AddParameter("@CCM_ID", cCM_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["CCM_ID"] != DBNull.Value) cC_Movement.CCM_ID = Convert.ToDecimal(dr["CCM_ID"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return cC_Movement;
      }
      /// <summary>
      /// 获取指定的CC_Movement对象集合
      /// </summary>
      public List<CC_Movement> GetListByWhere(string strCondition)
      {
         List<CC_Movement> ret = new List<CC_Movement>();
         string sql = "SELECT  CCM_ID FROM CC_Movement WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
         if(!string.IsNullOrEmpty(strCondition))
         {
            strCondition.Replace('\'','"'); //防sql注入
            sql += strCondition ;
         }
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            CC_Movement cC_Movement = new CC_Movement();
            if (dr["CCM_ID"] != DBNull.Value) cC_Movement.CCM_ID = Convert.ToDecimal(dr["CCM_ID"]);
            ret.Add(cC_Movement);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的CC_Movement对象(即:一条记录
      /// </summary>
      public List<CC_Movement> GetAll()
      {
         List<CC_Movement> ret = new List<CC_Movement>();
         string sql = "SELECT  CCM_ID FROM CC_Movement where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            CC_Movement cC_Movement = new CC_Movement();
            if (dr["CCM_ID"] != DBNull.Value) cC_Movement.CCM_ID = Convert.ToDecimal(dr["CCM_ID"]);
            ret.Add(cC_Movement);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
