using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using QX.GenFramework.Model;
using QX.DataAcess;

namespace QX.GenFramework.ADO
{
   [Serializable]
   public partial class ADOSys_PD_RefModule
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Sys_PD_RefModule对象(即:一条记录)
      /// </summary>
      public int Add(Sys_PD_RefModule sys_PD_RefModule)
      {
         string sql = "INSERT INTO Sys_PD_RefModule (SPR_RefModule,SPR_RefSQL,SPR_RefValue,SPR_RefData,SPR_UDef1,SPR_UDef2,SPR_UDef3,SPR_UDef4,SPR_UDef5,Stat) VALUES (@SPR_RefModule,@SPR_RefSQL,@SPR_RefValue,@SPR_RefData,@SPR_UDef1,@SPR_UDef2,@SPR_UDef3,@SPR_UDef4,@SPR_UDef5,@Stat)";
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefModule))
         {
            idb.AddParameter("@SPR_RefModule", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefModule", sys_PD_RefModule.SPR_RefModule);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefSQL))
         {
            idb.AddParameter("@SPR_RefSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefSQL", sys_PD_RefModule.SPR_RefSQL);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefValue))
         {
            idb.AddParameter("@SPR_RefValue", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefValue", sys_PD_RefModule.SPR_RefValue);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefData))
         {
            idb.AddParameter("@SPR_RefData", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefData", sys_PD_RefModule.SPR_RefData);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef1))
         {
            idb.AddParameter("@SPR_UDef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef1", sys_PD_RefModule.SPR_UDef1);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef2))
         {
            idb.AddParameter("@SPR_UDef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef2", sys_PD_RefModule.SPR_UDef2);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef3))
         {
            idb.AddParameter("@SPR_UDef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef3", sys_PD_RefModule.SPR_UDef3);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef4))
         {
            idb.AddParameter("@SPR_UDef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef4", sys_PD_RefModule.SPR_UDef4);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef5))
         {
            idb.AddParameter("@SPR_UDef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef5", sys_PD_RefModule.SPR_UDef5);
         }
         if (sys_PD_RefModule.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_RefModule.Stat);
         }

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加Sys_PD_RefModule对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Sys_PD_RefModule sys_PD_RefModule)
      {
         string sql = "INSERT INTO Sys_PD_RefModule (SPR_RefModule,SPR_RefSQL,SPR_RefValue,SPR_RefData,SPR_UDef1,SPR_UDef2,SPR_UDef3,SPR_UDef4,SPR_UDef5,Stat) VALUES (@SPR_RefModule,@SPR_RefSQL,@SPR_RefValue,@SPR_RefData,@SPR_UDef1,@SPR_UDef2,@SPR_UDef3,@SPR_UDef4,@SPR_UDef5,@Stat);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefModule))
         {
            idb.AddParameter("@SPR_RefModule", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefModule", sys_PD_RefModule.SPR_RefModule);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefSQL))
         {
            idb.AddParameter("@SPR_RefSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefSQL", sys_PD_RefModule.SPR_RefSQL);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefValue))
         {
            idb.AddParameter("@SPR_RefValue", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefValue", sys_PD_RefModule.SPR_RefValue);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefData))
         {
            idb.AddParameter("@SPR_RefData", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefData", sys_PD_RefModule.SPR_RefData);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef1))
         {
            idb.AddParameter("@SPR_UDef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef1", sys_PD_RefModule.SPR_UDef1);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef2))
         {
            idb.AddParameter("@SPR_UDef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef2", sys_PD_RefModule.SPR_UDef2);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef3))
         {
            idb.AddParameter("@SPR_UDef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef3", sys_PD_RefModule.SPR_UDef3);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef4))
         {
            idb.AddParameter("@SPR_UDef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef4", sys_PD_RefModule.SPR_UDef4);
         }
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef5))
         {
            idb.AddParameter("@SPR_UDef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef5", sys_PD_RefModule.SPR_UDef5);
         }
         if (sys_PD_RefModule.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_RefModule.Stat);
         }

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新Sys_PD_RefModule对象(即:一条记录
      /// </summary>
      public int Update(Sys_PD_RefModule sys_PD_RefModule)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Sys_PD_RefModule       SET ");
            if(sys_PD_RefModule.SPR_RefModule_IsChanged){sbParameter.Append("SPR_RefModule=@SPR_RefModule, ");}
      if(sys_PD_RefModule.SPR_RefSQL_IsChanged){sbParameter.Append("SPR_RefSQL=@SPR_RefSQL, ");}
      if(sys_PD_RefModule.SPR_RefValue_IsChanged){sbParameter.Append("SPR_RefValue=@SPR_RefValue, ");}
      if(sys_PD_RefModule.SPR_RefData_IsChanged){sbParameter.Append("SPR_RefData=@SPR_RefData, ");}
      if(sys_PD_RefModule.SPR_UDef1_IsChanged){sbParameter.Append("SPR_UDef1=@SPR_UDef1, ");}
      if(sys_PD_RefModule.SPR_UDef2_IsChanged){sbParameter.Append("SPR_UDef2=@SPR_UDef2, ");}
      if(sys_PD_RefModule.SPR_UDef3_IsChanged){sbParameter.Append("SPR_UDef3=@SPR_UDef3, ");}
      if(sys_PD_RefModule.SPR_UDef4_IsChanged){sbParameter.Append("SPR_UDef4=@SPR_UDef4, ");}
      if(sys_PD_RefModule.SPR_UDef5_IsChanged){sbParameter.Append("SPR_UDef5=@SPR_UDef5, ");}
      if(sys_PD_RefModule.Stat_IsChanged){sbParameter.Append("Stat=@Stat ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and SPR_ID=@SPR_ID; " );
      string sql=sb.ToString();
         if(sys_PD_RefModule.SPR_RefModule_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefModule))
         {
            idb.AddParameter("@SPR_RefModule", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefModule", sys_PD_RefModule.SPR_RefModule);
         }
          }
         if(sys_PD_RefModule.SPR_RefSQL_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefSQL))
         {
            idb.AddParameter("@SPR_RefSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefSQL", sys_PD_RefModule.SPR_RefSQL);
         }
          }
         if(sys_PD_RefModule.SPR_RefValue_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefValue))
         {
            idb.AddParameter("@SPR_RefValue", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefValue", sys_PD_RefModule.SPR_RefValue);
         }
          }
         if(sys_PD_RefModule.SPR_RefData_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_RefData))
         {
            idb.AddParameter("@SPR_RefData", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_RefData", sys_PD_RefModule.SPR_RefData);
         }
          }
         if(sys_PD_RefModule.SPR_UDef1_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef1))
         {
            idb.AddParameter("@SPR_UDef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef1", sys_PD_RefModule.SPR_UDef1);
         }
          }
         if(sys_PD_RefModule.SPR_UDef2_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef2))
         {
            idb.AddParameter("@SPR_UDef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef2", sys_PD_RefModule.SPR_UDef2);
         }
          }
         if(sys_PD_RefModule.SPR_UDef3_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef3))
         {
            idb.AddParameter("@SPR_UDef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef3", sys_PD_RefModule.SPR_UDef3);
         }
          }
         if(sys_PD_RefModule.SPR_UDef4_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef4))
         {
            idb.AddParameter("@SPR_UDef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef4", sys_PD_RefModule.SPR_UDef4);
         }
          }
         if(sys_PD_RefModule.SPR_UDef5_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_RefModule.SPR_UDef5))
         {
            idb.AddParameter("@SPR_UDef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPR_UDef5", sys_PD_RefModule.SPR_UDef5);
         }
          }
         if(sys_PD_RefModule.Stat_IsChanged)
         {
         if (sys_PD_RefModule.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_RefModule.Stat);
         }
          }

         idb.AddParameter("@SPR_ID", sys_PD_RefModule.SPR_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除Sys_PD_RefModule对象(即:一条记录
      /// </summary>
      public int Delete(Int64 sPR_ID)
      {
         string sql = "DELETE Sys_PD_RefModule WHERE 1=1  AND SPR_ID=@SPR_ID ";
         idb.AddParameter("@SPR_ID", sPR_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Sys_PD_RefModule对象(即:一条记录
      /// </summary>
      public Sys_PD_RefModule GetByKey(Int64 sPR_ID)
      {
         Sys_PD_RefModule sys_PD_RefModule = new Sys_PD_RefModule();
         string sql = "SELECT  SPR_ID,SPR_RefModule,SPR_RefSQL,SPR_RefValue,SPR_RefData,SPR_UDef1,SPR_UDef2,SPR_UDef3,SPR_UDef4,SPR_UDef5,Stat FROM Sys_PD_RefModule WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND SPR_ID=@SPR_ID ";
         idb.AddParameter("@SPR_ID", sPR_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["SPR_ID"] != DBNull.Value) sys_PD_RefModule.SPR_ID = Convert.ToInt64(dr["SPR_ID"]);
            if (dr["SPR_RefModule"] != DBNull.Value) sys_PD_RefModule.SPR_RefModule = Convert.ToString(dr["SPR_RefModule"]);
            if (dr["SPR_RefSQL"] != DBNull.Value) sys_PD_RefModule.SPR_RefSQL = Convert.ToString(dr["SPR_RefSQL"]);
            if (dr["SPR_RefValue"] != DBNull.Value) sys_PD_RefModule.SPR_RefValue = Convert.ToString(dr["SPR_RefValue"]);
            if (dr["SPR_RefData"] != DBNull.Value) sys_PD_RefModule.SPR_RefData = Convert.ToString(dr["SPR_RefData"]);
            if (dr["SPR_UDef1"] != DBNull.Value) sys_PD_RefModule.SPR_UDef1 = Convert.ToString(dr["SPR_UDef1"]);
            if (dr["SPR_UDef2"] != DBNull.Value) sys_PD_RefModule.SPR_UDef2 = Convert.ToString(dr["SPR_UDef2"]);
            if (dr["SPR_UDef3"] != DBNull.Value) sys_PD_RefModule.SPR_UDef3 = Convert.ToString(dr["SPR_UDef3"]);
            if (dr["SPR_UDef4"] != DBNull.Value) sys_PD_RefModule.SPR_UDef4 = Convert.ToString(dr["SPR_UDef4"]);
            if (dr["SPR_UDef5"] != DBNull.Value) sys_PD_RefModule.SPR_UDef5 = Convert.ToString(dr["SPR_UDef5"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_RefModule.Stat = Convert.ToInt32(dr["Stat"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return sys_PD_RefModule;
      }
      /// <summary>
      /// 获取指定的Sys_PD_RefModule对象集合
      /// </summary>
      public List<Sys_PD_RefModule> GetListByWhere(string strCondition)
      {
         List<Sys_PD_RefModule> ret = new List<Sys_PD_RefModule>();
         string sql = "SELECT  SPR_ID,SPR_RefModule,SPR_RefSQL,SPR_RefValue,SPR_RefData,SPR_UDef1,SPR_UDef2,SPR_UDef3,SPR_UDef4,SPR_UDef5,Stat FROM Sys_PD_RefModule WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Sys_PD_RefModule sys_PD_RefModule = new Sys_PD_RefModule();
            if (dr["SPR_ID"] != DBNull.Value) sys_PD_RefModule.SPR_ID = Convert.ToInt64(dr["SPR_ID"]);
            if (dr["SPR_RefModule"] != DBNull.Value) sys_PD_RefModule.SPR_RefModule = Convert.ToString(dr["SPR_RefModule"]);
            if (dr["SPR_RefSQL"] != DBNull.Value) sys_PD_RefModule.SPR_RefSQL = Convert.ToString(dr["SPR_RefSQL"]);
            if (dr["SPR_RefValue"] != DBNull.Value) sys_PD_RefModule.SPR_RefValue = Convert.ToString(dr["SPR_RefValue"]);
            if (dr["SPR_RefData"] != DBNull.Value) sys_PD_RefModule.SPR_RefData = Convert.ToString(dr["SPR_RefData"]);
            if (dr["SPR_UDef1"] != DBNull.Value) sys_PD_RefModule.SPR_UDef1 = Convert.ToString(dr["SPR_UDef1"]);
            if (dr["SPR_UDef2"] != DBNull.Value) sys_PD_RefModule.SPR_UDef2 = Convert.ToString(dr["SPR_UDef2"]);
            if (dr["SPR_UDef3"] != DBNull.Value) sys_PD_RefModule.SPR_UDef3 = Convert.ToString(dr["SPR_UDef3"]);
            if (dr["SPR_UDef4"] != DBNull.Value) sys_PD_RefModule.SPR_UDef4 = Convert.ToString(dr["SPR_UDef4"]);
            if (dr["SPR_UDef5"] != DBNull.Value) sys_PD_RefModule.SPR_UDef5 = Convert.ToString(dr["SPR_UDef5"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_RefModule.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(sys_PD_RefModule);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Sys_PD_RefModule对象(即:一条记录
      /// </summary>
      public List<Sys_PD_RefModule> GetAll()
      {
         List<Sys_PD_RefModule> ret = new List<Sys_PD_RefModule>();
         string sql = "SELECT  SPR_ID,SPR_RefModule,SPR_RefSQL,SPR_RefValue,SPR_RefData,SPR_UDef1,SPR_UDef2,SPR_UDef3,SPR_UDef4,SPR_UDef5,Stat FROM Sys_PD_RefModule where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_PD_RefModule sys_PD_RefModule = new Sys_PD_RefModule();
            if (dr["SPR_ID"] != DBNull.Value) sys_PD_RefModule.SPR_ID = Convert.ToInt64(dr["SPR_ID"]);
            if (dr["SPR_RefModule"] != DBNull.Value) sys_PD_RefModule.SPR_RefModule = Convert.ToString(dr["SPR_RefModule"]);
            if (dr["SPR_RefSQL"] != DBNull.Value) sys_PD_RefModule.SPR_RefSQL = Convert.ToString(dr["SPR_RefSQL"]);
            if (dr["SPR_RefValue"] != DBNull.Value) sys_PD_RefModule.SPR_RefValue = Convert.ToString(dr["SPR_RefValue"]);
            if (dr["SPR_RefData"] != DBNull.Value) sys_PD_RefModule.SPR_RefData = Convert.ToString(dr["SPR_RefData"]);
            if (dr["SPR_UDef1"] != DBNull.Value) sys_PD_RefModule.SPR_UDef1 = Convert.ToString(dr["SPR_UDef1"]);
            if (dr["SPR_UDef2"] != DBNull.Value) sys_PD_RefModule.SPR_UDef2 = Convert.ToString(dr["SPR_UDef2"]);
            if (dr["SPR_UDef3"] != DBNull.Value) sys_PD_RefModule.SPR_UDef3 = Convert.ToString(dr["SPR_UDef3"]);
            if (dr["SPR_UDef4"] != DBNull.Value) sys_PD_RefModule.SPR_UDef4 = Convert.ToString(dr["SPR_UDef4"]);
            if (dr["SPR_UDef5"] != DBNull.Value) sys_PD_RefModule.SPR_UDef5 = Convert.ToString(dr["SPR_UDef5"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_RefModule.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(sys_PD_RefModule);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
