using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using QX.Model;
using QX.DataAcess;

namespace QX.DAL
{
   /// <summary>
   /// 系统运行日志
   /// </summary>
   [Serializable]
   public partial class ADOSys_RunLog
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加系统运行日志 Sys_RunLog对象(即:一条记录)
      /// </summary>
      public int Add(Sys_RunLog sys_RunLog)
      {
         string sql = "INSERT INTO Sys_RunLog (Log_Date,Log_SQL,Log_Author,Log_Fun,Log_SQLParameter,Log_Error) VALUES (@Log_Date,@Log_SQL,@Log_Author,@Log_Fun,@Log_SQLParameter,@Log_Error)";
         if (sys_RunLog.Log_Date == DateTime.MinValue)
         {
            idb.AddParameter("@Log_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Date", sys_RunLog.Log_Date);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_SQL))
         {
            idb.AddParameter("@Log_SQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_SQL", sys_RunLog.Log_SQL);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_Author))
         {
            idb.AddParameter("@Log_Author", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Author", sys_RunLog.Log_Author);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_Fun))
         {
            idb.AddParameter("@Log_Fun", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Fun", sys_RunLog.Log_Fun);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_SQLParameter))
         {
            idb.AddParameter("@Log_SQLParameter", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_SQLParameter", sys_RunLog.Log_SQLParameter);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_Error))
         {
            idb.AddParameter("@Log_Error", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Error", sys_RunLog.Log_Error);
         }

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加系统运行日志 Sys_RunLog对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Sys_RunLog sys_RunLog)
      {
         string sql = "INSERT INTO Sys_RunLog (Log_Date,Log_SQL,Log_Author,Log_Fun,Log_SQLParameter,Log_Error) VALUES (@Log_Date,@Log_SQL,@Log_Author,@Log_Fun,@Log_SQLParameter,@Log_Error);SELECT @@IDENTITY AS ReturnID;";
         if (sys_RunLog.Log_Date == DateTime.MinValue)
         {
            idb.AddParameter("@Log_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Date", sys_RunLog.Log_Date);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_SQL))
         {
            idb.AddParameter("@Log_SQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_SQL", sys_RunLog.Log_SQL);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_Author))
         {
            idb.AddParameter("@Log_Author", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Author", sys_RunLog.Log_Author);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_Fun))
         {
            idb.AddParameter("@Log_Fun", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Fun", sys_RunLog.Log_Fun);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_SQLParameter))
         {
            idb.AddParameter("@Log_SQLParameter", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_SQLParameter", sys_RunLog.Log_SQLParameter);
         }
         if (string.IsNullOrEmpty(sys_RunLog.Log_Error))
         {
            idb.AddParameter("@Log_Error", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Error", sys_RunLog.Log_Error);
         }

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新系统运行日志 Sys_RunLog对象(即:一条记录
      /// </summary>
      public int Update(Sys_RunLog sys_RunLog)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Sys_RunLog       SET ");
            if(sys_RunLog.Log_Date_IsChanged){sbParameter.Append("Log_Date=@Log_Date, ");}
      if(sys_RunLog.Log_SQL_IsChanged){sbParameter.Append("Log_SQL=@Log_SQL, ");}
      if(sys_RunLog.Log_Author_IsChanged){sbParameter.Append("Log_Author=@Log_Author, ");}
      if(sys_RunLog.Log_Fun_IsChanged){sbParameter.Append("Log_Fun=@Log_Fun, ");}
      if(sys_RunLog.Log_SQLParameter_IsChanged){sbParameter.Append("Log_SQLParameter=@Log_SQLParameter, ");}
      if(sys_RunLog.Log_Error_IsChanged){sbParameter.Append("Log_Error=@Log_Error ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and Log_ID=@Log_ID; " );
      string sql=sb.ToString();
         if(sys_RunLog.Log_Date_IsChanged)
         {
         if (sys_RunLog.Log_Date == DateTime.MinValue)
         {
            idb.AddParameter("@Log_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Date", sys_RunLog.Log_Date);
         }
          }
         if(sys_RunLog.Log_SQL_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_RunLog.Log_SQL))
         {
            idb.AddParameter("@Log_SQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_SQL", sys_RunLog.Log_SQL);
         }
          }
         if(sys_RunLog.Log_Author_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_RunLog.Log_Author))
         {
            idb.AddParameter("@Log_Author", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Author", sys_RunLog.Log_Author);
         }
          }
         if(sys_RunLog.Log_Fun_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_RunLog.Log_Fun))
         {
            idb.AddParameter("@Log_Fun", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Fun", sys_RunLog.Log_Fun);
         }
          }
         if(sys_RunLog.Log_SQLParameter_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_RunLog.Log_SQLParameter))
         {
            idb.AddParameter("@Log_SQLParameter", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_SQLParameter", sys_RunLog.Log_SQLParameter);
         }
          }
         if(sys_RunLog.Log_Error_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_RunLog.Log_Error))
         {
            idb.AddParameter("@Log_Error", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Log_Error", sys_RunLog.Log_Error);
         }
          }

         idb.AddParameter("@Log_ID", sys_RunLog.Log_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除系统运行日志 Sys_RunLog对象(即:一条记录
      /// </summary>
      public int Delete(decimal log_ID)
      {
         string sql = "DELETE Sys_RunLog WHERE 1=1  AND Log_ID=@Log_ID ";
         idb.AddParameter("@Log_ID", log_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的系统运行日志 Sys_RunLog对象(即:一条记录
      /// </summary>
      public Sys_RunLog GetByKey(decimal log_ID)
      {
         Sys_RunLog sys_RunLog = new Sys_RunLog();
         string sql = "SELECT  Log_ID,Log_Date,Log_SQL,Log_Author,Log_Fun,Log_SQLParameter,Log_Error FROM Sys_RunLog WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND Log_ID=@Log_ID ";
         idb.AddParameter("@Log_ID", log_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["Log_ID"] != DBNull.Value) sys_RunLog.Log_ID = Convert.ToDecimal(dr["Log_ID"]);
            if (dr["Log_Date"] != DBNull.Value) sys_RunLog.Log_Date = Convert.ToDateTime(dr["Log_Date"]);
            if (dr["Log_SQL"] != DBNull.Value) sys_RunLog.Log_SQL = Convert.ToString(dr["Log_SQL"]);
            if (dr["Log_Author"] != DBNull.Value) sys_RunLog.Log_Author = Convert.ToString(dr["Log_Author"]);
            if (dr["Log_Fun"] != DBNull.Value) sys_RunLog.Log_Fun = Convert.ToString(dr["Log_Fun"]);
            if (dr["Log_SQLParameter"] != DBNull.Value) sys_RunLog.Log_SQLParameter = Convert.ToString(dr["Log_SQLParameter"]);
            if (dr["Log_Error"] != DBNull.Value) sys_RunLog.Log_Error = Convert.ToString(dr["Log_Error"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return sys_RunLog;
      }
      /// <summary>
      /// 获取指定的系统运行日志 Sys_RunLog对象集合
      /// </summary>
      public List<Sys_RunLog> GetListByWhere(string strCondition)
      {
         List<Sys_RunLog> ret = new List<Sys_RunLog>();
         string sql = "SELECT  Log_ID,Log_Date,Log_SQL,Log_Author,Log_Fun,Log_SQLParameter,Log_Error FROM Sys_RunLog WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Sys_RunLog sys_RunLog = new Sys_RunLog();
            if (dr["Log_ID"] != DBNull.Value) sys_RunLog.Log_ID = Convert.ToDecimal(dr["Log_ID"]);
            if (dr["Log_Date"] != DBNull.Value) sys_RunLog.Log_Date = Convert.ToDateTime(dr["Log_Date"]);
            if (dr["Log_SQL"] != DBNull.Value) sys_RunLog.Log_SQL = Convert.ToString(dr["Log_SQL"]);
            if (dr["Log_Author"] != DBNull.Value) sys_RunLog.Log_Author = Convert.ToString(dr["Log_Author"]);
            if (dr["Log_Fun"] != DBNull.Value) sys_RunLog.Log_Fun = Convert.ToString(dr["Log_Fun"]);
            if (dr["Log_SQLParameter"] != DBNull.Value) sys_RunLog.Log_SQLParameter = Convert.ToString(dr["Log_SQLParameter"]);
            if (dr["Log_Error"] != DBNull.Value) sys_RunLog.Log_Error = Convert.ToString(dr["Log_Error"]);
            ret.Add(sys_RunLog);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的系统运行日志 Sys_RunLog对象(即:一条记录
      /// </summary>
      public List<Sys_RunLog> GetAll()
      {
         List<Sys_RunLog> ret = new List<Sys_RunLog>();
         string sql = "SELECT  Log_ID,Log_Date,Log_SQL,Log_Author,Log_Fun,Log_SQLParameter,Log_Error FROM Sys_RunLog where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_RunLog sys_RunLog = new Sys_RunLog();
            if (dr["Log_ID"] != DBNull.Value) sys_RunLog.Log_ID = Convert.ToDecimal(dr["Log_ID"]);
            if (dr["Log_Date"] != DBNull.Value) sys_RunLog.Log_Date = Convert.ToDateTime(dr["Log_Date"]);
            if (dr["Log_SQL"] != DBNull.Value) sys_RunLog.Log_SQL = Convert.ToString(dr["Log_SQL"]);
            if (dr["Log_Author"] != DBNull.Value) sys_RunLog.Log_Author = Convert.ToString(dr["Log_Author"]);
            if (dr["Log_Fun"] != DBNull.Value) sys_RunLog.Log_Fun = Convert.ToString(dr["Log_Fun"]);
            if (dr["Log_SQLParameter"] != DBNull.Value) sys_RunLog.Log_SQLParameter = Convert.ToString(dr["Log_SQLParameter"]);
            if (dr["Log_Error"] != DBNull.Value) sys_RunLog.Log_Error = Convert.ToString(dr["Log_Error"]);
            ret.Add(sys_RunLog);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
