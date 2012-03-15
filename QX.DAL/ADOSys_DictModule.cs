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
   public partial class ADOSys_DictModule
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Sys_DictModule对象(即:一条记录)
      /// </summary>
      public int Add(Sys_DictModule sys_DictModule)
      {
         string sql = "INSERT INTO Sys_DictModule (ModuleCode,IsCompany,CodeLength,ChildLength,TableName,CodeField,FilterSQL,Udef1,Udef2,Udef3,Udef4,Udef5,Stat) VALUES (@ModuleCode,@IsCompany,@CodeLength,@ChildLength,@TableName,@CodeField,@FilterSQL,@Udef1,@Udef2,@Udef3,@Udef4,@Udef5,@Stat)";
         if (string.IsNullOrEmpty(sys_DictModule.ModuleCode))
         {
            idb.AddParameter("@ModuleCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ModuleCode", sys_DictModule.ModuleCode);
         }
         if (sys_DictModule.IsCompany == false)
         {
            idb.AddParameter("@IsCompany", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@IsCompany", sys_DictModule.IsCompany);
         }
         if (sys_DictModule.CodeLength == 0)
         {
            idb.AddParameter("@CodeLength", 0);
         }
         else
         {
            idb.AddParameter("@CodeLength", sys_DictModule.CodeLength);
         }
         if (sys_DictModule.ChildLength == 0)
         {
            idb.AddParameter("@ChildLength", 0);
         }
         else
         {
            idb.AddParameter("@ChildLength", sys_DictModule.ChildLength);
         }
         if (string.IsNullOrEmpty(sys_DictModule.TableName))
         {
            idb.AddParameter("@TableName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TableName", sys_DictModule.TableName);
         }
         if (string.IsNullOrEmpty(sys_DictModule.CodeField))
         {
            idb.AddParameter("@CodeField", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CodeField", sys_DictModule.CodeField);
         }
         if (string.IsNullOrEmpty(sys_DictModule.FilterSQL))
         {
            idb.AddParameter("@FilterSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@FilterSQL", sys_DictModule.FilterSQL);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef1))
         {
            idb.AddParameter("@Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef1", sys_DictModule.Udef1);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef2))
         {
            idb.AddParameter("@Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef2", sys_DictModule.Udef2);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef3))
         {
            idb.AddParameter("@Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef3", sys_DictModule.Udef3);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef4))
         {
            idb.AddParameter("@Udef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef4", sys_DictModule.Udef4);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef5))
         {
            idb.AddParameter("@Udef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef5", sys_DictModule.Udef5);
         }
         if (sys_DictModule.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_DictModule.Stat);
         }

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加Sys_DictModule对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Sys_DictModule sys_DictModule)
      {
         string sql = "INSERT INTO Sys_DictModule (ModuleCode,IsCompany,CodeLength,ChildLength,TableName,CodeField,FilterSQL,Udef1,Udef2,Udef3,Udef4,Udef5,Stat) VALUES (@ModuleCode,@IsCompany,@CodeLength,@ChildLength,@TableName,@CodeField,@FilterSQL,@Udef1,@Udef2,@Udef3,@Udef4,@Udef5,@Stat);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(sys_DictModule.ModuleCode))
         {
            idb.AddParameter("@ModuleCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ModuleCode", sys_DictModule.ModuleCode);
         }
         if (sys_DictModule.IsCompany == false)
         {
            idb.AddParameter("@IsCompany", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@IsCompany", sys_DictModule.IsCompany);
         }
         if (sys_DictModule.CodeLength == 0)
         {
            idb.AddParameter("@CodeLength", 0);
         }
         else
         {
            idb.AddParameter("@CodeLength", sys_DictModule.CodeLength);
         }
         if (sys_DictModule.ChildLength == 0)
         {
            idb.AddParameter("@ChildLength", 0);
         }
         else
         {
            idb.AddParameter("@ChildLength", sys_DictModule.ChildLength);
         }
         if (string.IsNullOrEmpty(sys_DictModule.TableName))
         {
            idb.AddParameter("@TableName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TableName", sys_DictModule.TableName);
         }
         if (string.IsNullOrEmpty(sys_DictModule.CodeField))
         {
            idb.AddParameter("@CodeField", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CodeField", sys_DictModule.CodeField);
         }
         if (string.IsNullOrEmpty(sys_DictModule.FilterSQL))
         {
            idb.AddParameter("@FilterSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@FilterSQL", sys_DictModule.FilterSQL);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef1))
         {
            idb.AddParameter("@Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef1", sys_DictModule.Udef1);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef2))
         {
            idb.AddParameter("@Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef2", sys_DictModule.Udef2);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef3))
         {
            idb.AddParameter("@Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef3", sys_DictModule.Udef3);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef4))
         {
            idb.AddParameter("@Udef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef4", sys_DictModule.Udef4);
         }
         if (string.IsNullOrEmpty(sys_DictModule.Udef5))
         {
            idb.AddParameter("@Udef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef5", sys_DictModule.Udef5);
         }
         if (sys_DictModule.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_DictModule.Stat);
         }

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新Sys_DictModule对象(即:一条记录
      /// </summary>
      public int Update(Sys_DictModule sys_DictModule)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Sys_DictModule       SET ");
            if(sys_DictModule.ModuleCode_IsChanged){sbParameter.Append("ModuleCode=@ModuleCode, ");}
      if(sys_DictModule.IsCompany_IsChanged){sbParameter.Append("IsCompany=@IsCompany, ");}
      if(sys_DictModule.CodeLength_IsChanged){sbParameter.Append("CodeLength=@CodeLength, ");}
      if(sys_DictModule.ChildLength_IsChanged){sbParameter.Append("ChildLength=@ChildLength, ");}
      if(sys_DictModule.TableName_IsChanged){sbParameter.Append("TableName=@TableName, ");}
      if(sys_DictModule.CodeField_IsChanged){sbParameter.Append("CodeField=@CodeField, ");}
      if(sys_DictModule.FilterSQL_IsChanged){sbParameter.Append("FilterSQL=@FilterSQL, ");}
      if(sys_DictModule.Udef1_IsChanged){sbParameter.Append("Udef1=@Udef1, ");}
      if(sys_DictModule.Udef2_IsChanged){sbParameter.Append("Udef2=@Udef2, ");}
      if(sys_DictModule.Udef3_IsChanged){sbParameter.Append("Udef3=@Udef3, ");}
      if(sys_DictModule.Udef4_IsChanged){sbParameter.Append("Udef4=@Udef4, ");}
      if(sys_DictModule.Udef5_IsChanged){sbParameter.Append("Udef5=@Udef5, ");}
      if(sys_DictModule.Stat_IsChanged){sbParameter.Append("Stat=@Stat ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and ID=@ID; " );
      string sql=sb.ToString();
         if(sys_DictModule.ModuleCode_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictModule.ModuleCode))
         {
            idb.AddParameter("@ModuleCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ModuleCode", sys_DictModule.ModuleCode);
         }
          }
         if(sys_DictModule.IsCompany_IsChanged)
         {
         if (sys_DictModule.IsCompany == false)
         {
            idb.AddParameter("@IsCompany", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@IsCompany", sys_DictModule.IsCompany);
         }
          }
         if(sys_DictModule.CodeLength_IsChanged)
         {
         if (sys_DictModule.CodeLength == 0)
         {
            idb.AddParameter("@CodeLength", 0);
         }
         else
         {
            idb.AddParameter("@CodeLength", sys_DictModule.CodeLength);
         }
          }
         if(sys_DictModule.ChildLength_IsChanged)
         {
         if (sys_DictModule.ChildLength == 0)
         {
            idb.AddParameter("@ChildLength", 0);
         }
         else
         {
            idb.AddParameter("@ChildLength", sys_DictModule.ChildLength);
         }
          }
         if(sys_DictModule.TableName_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictModule.TableName))
         {
            idb.AddParameter("@TableName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TableName", sys_DictModule.TableName);
         }
          }
         if(sys_DictModule.CodeField_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictModule.CodeField))
         {
            idb.AddParameter("@CodeField", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CodeField", sys_DictModule.CodeField);
         }
          }
         if(sys_DictModule.FilterSQL_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictModule.FilterSQL))
         {
            idb.AddParameter("@FilterSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@FilterSQL", sys_DictModule.FilterSQL);
         }
          }
         if(sys_DictModule.Udef1_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictModule.Udef1))
         {
            idb.AddParameter("@Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef1", sys_DictModule.Udef1);
         }
          }
         if(sys_DictModule.Udef2_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictModule.Udef2))
         {
            idb.AddParameter("@Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef2", sys_DictModule.Udef2);
         }
          }
         if(sys_DictModule.Udef3_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictModule.Udef3))
         {
            idb.AddParameter("@Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef3", sys_DictModule.Udef3);
         }
          }
         if(sys_DictModule.Udef4_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictModule.Udef4))
         {
            idb.AddParameter("@Udef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef4", sys_DictModule.Udef4);
         }
          }
         if(sys_DictModule.Udef5_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictModule.Udef5))
         {
            idb.AddParameter("@Udef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Udef5", sys_DictModule.Udef5);
         }
          }
         if(sys_DictModule.Stat_IsChanged)
         {
         if (sys_DictModule.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_DictModule.Stat);
         }
          }

         idb.AddParameter("@ID", sys_DictModule.ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除Sys_DictModule对象(即:一条记录
      /// </summary>
      public int Delete(Int64 iD)
      {
         string sql = "DELETE Sys_DictModule WHERE 1=1  AND ID=@ID ";
         idb.AddParameter("@ID", iD);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Sys_DictModule对象(即:一条记录
      /// </summary>
      public Sys_DictModule GetByKey(Int64 iD)
      {
         Sys_DictModule sys_DictModule = new Sys_DictModule();
         string sql = "SELECT  ID,ModuleCode,IsCompany,CodeLength,ChildLength,TableName,CodeField,FilterSQL,Udef1,Udef2,Udef3,Udef4,Udef5,Stat FROM Sys_DictModule WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND ID=@ID ";
         idb.AddParameter("@ID", iD);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["ID"] != DBNull.Value) sys_DictModule.ID = Convert.ToInt64(dr["ID"]);
            if (dr["ModuleCode"] != DBNull.Value) sys_DictModule.ModuleCode = Convert.ToString(dr["ModuleCode"]);
            if (dr["IsCompany"] != DBNull.Value) sys_DictModule.IsCompany = Convert.ToBoolean(dr["IsCompany"]);
            if (dr["CodeLength"] != DBNull.Value) sys_DictModule.CodeLength = Convert.ToInt32(dr["CodeLength"]);
            if (dr["ChildLength"] != DBNull.Value) sys_DictModule.ChildLength = Convert.ToInt32(dr["ChildLength"]);
            if (dr["TableName"] != DBNull.Value) sys_DictModule.TableName = Convert.ToString(dr["TableName"]);
            if (dr["CodeField"] != DBNull.Value) sys_DictModule.CodeField = Convert.ToString(dr["CodeField"]);
            if (dr["FilterSQL"] != DBNull.Value) sys_DictModule.FilterSQL = Convert.ToString(dr["FilterSQL"]);
            if (dr["Udef1"] != DBNull.Value) sys_DictModule.Udef1 = Convert.ToString(dr["Udef1"]);
            if (dr["Udef2"] != DBNull.Value) sys_DictModule.Udef2 = Convert.ToString(dr["Udef2"]);
            if (dr["Udef3"] != DBNull.Value) sys_DictModule.Udef3 = Convert.ToString(dr["Udef3"]);
            if (dr["Udef4"] != DBNull.Value) sys_DictModule.Udef4 = Convert.ToString(dr["Udef4"]);
            if (dr["Udef5"] != DBNull.Value) sys_DictModule.Udef5 = Convert.ToString(dr["Udef5"]);
            if (dr["Stat"] != DBNull.Value) sys_DictModule.Stat = Convert.ToInt32(dr["Stat"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return sys_DictModule;
      }
      /// <summary>
      /// 获取指定的Sys_DictModule对象集合
      /// </summary>
      public List<Sys_DictModule> GetListByWhere(string strCondition)
      {
         List<Sys_DictModule> ret = new List<Sys_DictModule>();
         string sql = "SELECT  ID,ModuleCode,IsCompany,CodeLength,ChildLength,TableName,CodeField,FilterSQL,Udef1,Udef2,Udef3,Udef4,Udef5,Stat FROM Sys_DictModule WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
         if(!string.IsNullOrEmpty(strCondition))
         {
            strCondition.Replace('\'','"'); //防sql注入
            sql += strCondition ;
         }
          sql += " ORDER BY ID DESC "; 
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_DictModule sys_DictModule = new Sys_DictModule();
            if (dr["ID"] != DBNull.Value) sys_DictModule.ID = Convert.ToInt64(dr["ID"]);
            if (dr["ModuleCode"] != DBNull.Value) sys_DictModule.ModuleCode = Convert.ToString(dr["ModuleCode"]);
            if (dr["IsCompany"] != DBNull.Value) sys_DictModule.IsCompany = Convert.ToBoolean(dr["IsCompany"]);
            if (dr["CodeLength"] != DBNull.Value) sys_DictModule.CodeLength = Convert.ToInt32(dr["CodeLength"]);
            if (dr["ChildLength"] != DBNull.Value) sys_DictModule.ChildLength = Convert.ToInt32(dr["ChildLength"]);
            if (dr["TableName"] != DBNull.Value) sys_DictModule.TableName = Convert.ToString(dr["TableName"]);
            if (dr["CodeField"] != DBNull.Value) sys_DictModule.CodeField = Convert.ToString(dr["CodeField"]);
            if (dr["FilterSQL"] != DBNull.Value) sys_DictModule.FilterSQL = Convert.ToString(dr["FilterSQL"]);
            if (dr["Udef1"] != DBNull.Value) sys_DictModule.Udef1 = Convert.ToString(dr["Udef1"]);
            if (dr["Udef2"] != DBNull.Value) sys_DictModule.Udef2 = Convert.ToString(dr["Udef2"]);
            if (dr["Udef3"] != DBNull.Value) sys_DictModule.Udef3 = Convert.ToString(dr["Udef3"]);
            if (dr["Udef4"] != DBNull.Value) sys_DictModule.Udef4 = Convert.ToString(dr["Udef4"]);
            if (dr["Udef5"] != DBNull.Value) sys_DictModule.Udef5 = Convert.ToString(dr["Udef5"]);
            if (dr["Stat"] != DBNull.Value) sys_DictModule.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(sys_DictModule);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Sys_DictModule对象(即:一条记录
      /// </summary>
      public List<Sys_DictModule> GetAll()
      {
         List<Sys_DictModule> ret = new List<Sys_DictModule>();
         string sql = "SELECT  ID,ModuleCode,IsCompany,CodeLength,ChildLength,TableName,CodeField,FilterSQL,Udef1,Udef2,Udef3,Udef4,Udef5,Stat FROM Sys_DictModule where 1=1 AND ((Stat is null) or (Stat=0) ) order by ID desc ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_DictModule sys_DictModule = new Sys_DictModule();
            if (dr["ID"] != DBNull.Value) sys_DictModule.ID = Convert.ToInt64(dr["ID"]);
            if (dr["ModuleCode"] != DBNull.Value) sys_DictModule.ModuleCode = Convert.ToString(dr["ModuleCode"]);
            if (dr["IsCompany"] != DBNull.Value) sys_DictModule.IsCompany = Convert.ToBoolean(dr["IsCompany"]);
            if (dr["CodeLength"] != DBNull.Value) sys_DictModule.CodeLength = Convert.ToInt32(dr["CodeLength"]);
            if (dr["ChildLength"] != DBNull.Value) sys_DictModule.ChildLength = Convert.ToInt32(dr["ChildLength"]);
            if (dr["TableName"] != DBNull.Value) sys_DictModule.TableName = Convert.ToString(dr["TableName"]);
            if (dr["CodeField"] != DBNull.Value) sys_DictModule.CodeField = Convert.ToString(dr["CodeField"]);
            if (dr["FilterSQL"] != DBNull.Value) sys_DictModule.FilterSQL = Convert.ToString(dr["FilterSQL"]);
            if (dr["Udef1"] != DBNull.Value) sys_DictModule.Udef1 = Convert.ToString(dr["Udef1"]);
            if (dr["Udef2"] != DBNull.Value) sys_DictModule.Udef2 = Convert.ToString(dr["Udef2"]);
            if (dr["Udef3"] != DBNull.Value) sys_DictModule.Udef3 = Convert.ToString(dr["Udef3"]);
            if (dr["Udef4"] != DBNull.Value) sys_DictModule.Udef4 = Convert.ToString(dr["Udef4"]);
            if (dr["Udef5"] != DBNull.Value) sys_DictModule.Udef5 = Convert.ToString(dr["Udef5"]);
            if (dr["Stat"] != DBNull.Value) sys_DictModule.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(sys_DictModule);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
