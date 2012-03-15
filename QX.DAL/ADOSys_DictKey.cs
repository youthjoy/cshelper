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
   public partial class ADOSys_DictKey
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Sys_DictKey对象(即:一条记录)
      /// </summary>
      public int Add(Sys_DictKey sys_DictKey)
      {
         string sql = "INSERT INTO Sys_DictKey (TABLENAME,TABLEID,ModuleCode,PrefixCode,CodeLenth) VALUES (@TABLENAME,@TABLEID,@ModuleCode,@PrefixCode,@CodeLenth)";
         if (string.IsNullOrEmpty(sys_DictKey.TABLEID))
         {
            idb.AddParameter("@TABLEID", "''");
         }
         else
         {
            idb.AddParameter("@TABLEID", sys_DictKey.TABLEID);
         }
         if (string.IsNullOrEmpty(sys_DictKey.ModuleCode))
         {
            idb.AddParameter("@ModuleCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ModuleCode", sys_DictKey.ModuleCode);
         }
         if (string.IsNullOrEmpty(sys_DictKey.PrefixCode))
         {
            idb.AddParameter("@PrefixCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PrefixCode", sys_DictKey.PrefixCode);
         }
         if (sys_DictKey.CodeLenth == 0)
         {
            idb.AddParameter("@CodeLenth", 0);
         }
         else
         {
            idb.AddParameter("@CodeLenth", sys_DictKey.CodeLenth);
         }

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加Sys_DictKey对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Sys_DictKey sys_DictKey)
      {
         string sql = "INSERT INTO Sys_DictKey (TABLENAME,TABLEID,ModuleCode,PrefixCode,CodeLenth) VALUES (@TABLENAME,@TABLEID,@ModuleCode,@PrefixCode,@CodeLenth);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(sys_DictKey.TABLEID))
         {
            idb.AddParameter("@TABLEID", "''");
         }
         else
         {
            idb.AddParameter("@TABLEID", sys_DictKey.TABLEID);
         }
         if (string.IsNullOrEmpty(sys_DictKey.ModuleCode))
         {
            idb.AddParameter("@ModuleCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ModuleCode", sys_DictKey.ModuleCode);
         }
         if (string.IsNullOrEmpty(sys_DictKey.PrefixCode))
         {
            idb.AddParameter("@PrefixCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PrefixCode", sys_DictKey.PrefixCode);
         }
         if (sys_DictKey.CodeLenth == 0)
         {
            idb.AddParameter("@CodeLenth", 0);
         }
         else
         {
            idb.AddParameter("@CodeLenth", sys_DictKey.CodeLenth);
         }

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新Sys_DictKey对象(即:一条记录
      /// </summary>
      public int Update(Sys_DictKey sys_DictKey)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Sys_DictKey       SET ");
            if(sys_DictKey.TABLEID_IsChanged){sbParameter.Append("TABLEID=@TABLEID, ");}
      if(sys_DictKey.ModuleCode_IsChanged){sbParameter.Append("ModuleCode=@ModuleCode, ");}
      if(sys_DictKey.PrefixCode_IsChanged){sbParameter.Append("PrefixCode=@PrefixCode, ");}
      if(sys_DictKey.CodeLenth_IsChanged){sbParameter.Append("CodeLenth=@CodeLenth ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and TABLENAME=@TABLENAME; " );
      string sql=sb.ToString();
         if(sys_DictKey.TABLEID_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictKey.TABLEID))
         {
            idb.AddParameter("@TABLEID", "''");
         }
         else
         {
            idb.AddParameter("@TABLEID", sys_DictKey.TABLEID);
         }
          }
         if(sys_DictKey.ModuleCode_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictKey.ModuleCode))
         {
            idb.AddParameter("@ModuleCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ModuleCode", sys_DictKey.ModuleCode);
         }
          }
         if(sys_DictKey.PrefixCode_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_DictKey.PrefixCode))
         {
            idb.AddParameter("@PrefixCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PrefixCode", sys_DictKey.PrefixCode);
         }
          }
         if(sys_DictKey.CodeLenth_IsChanged)
         {
         if (sys_DictKey.CodeLenth == 0)
         {
            idb.AddParameter("@CodeLenth", 0);
         }
         else
         {
            idb.AddParameter("@CodeLenth", sys_DictKey.CodeLenth);
         }
          }

         idb.AddParameter("@TABLENAME", sys_DictKey.TABLENAME);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除Sys_DictKey对象(即:一条记录
      /// </summary>
      public int Delete(string tABLENAME)
      {
         string sql = "DELETE Sys_DictKey WHERE 1=1  AND TABLENAME=@TABLENAME ";
         idb.AddParameter("@TABLENAME", tABLENAME);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Sys_DictKey对象(即:一条记录
      /// </summary>
      public Sys_DictKey GetByKey(string tABLENAME)
      {
         Sys_DictKey sys_DictKey = new Sys_DictKey();
         string sql = "SELECT  TABLENAME,TABLEID,ID,ModuleCode,PrefixCode,CodeLenth FROM Sys_DictKey WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND TABLENAME=@TABLENAME ";
         idb.AddParameter("@TABLENAME", tABLENAME);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["TABLENAME"] != DBNull.Value) sys_DictKey.TABLENAME = Convert.ToString(dr["TABLENAME"]);
            if (dr["TABLEID"] != DBNull.Value) sys_DictKey.TABLEID = Convert.ToString(dr["TABLEID"]);
            if (dr["ID"] != DBNull.Value) sys_DictKey.ID = Convert.ToInt32(dr["ID"]);
            if (dr["ModuleCode"] != DBNull.Value) sys_DictKey.ModuleCode = Convert.ToString(dr["ModuleCode"]);
            if (dr["PrefixCode"] != DBNull.Value) sys_DictKey.PrefixCode = Convert.ToString(dr["PrefixCode"]);
            if (dr["CodeLenth"] != DBNull.Value) sys_DictKey.CodeLenth = Convert.ToInt32(dr["CodeLenth"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return sys_DictKey;
      }
      /// <summary>
      /// 获取指定的Sys_DictKey对象集合
      /// </summary>
      public List<Sys_DictKey> GetListByWhere(string strCondition)
      {
         List<Sys_DictKey> ret = new List<Sys_DictKey>();
         string sql = "SELECT  TABLENAME,TABLEID,ID,ModuleCode,PrefixCode,CodeLenth FROM Sys_DictKey WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
         if(!string.IsNullOrEmpty(strCondition))
         {
            strCondition.Replace('\'','"'); //防sql注入
            sql += strCondition ;
         }
          sql += " ORDER BY TABLENAME DESC "; 
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_DictKey sys_DictKey = new Sys_DictKey();
            if (dr["TABLENAME"] != DBNull.Value) sys_DictKey.TABLENAME = Convert.ToString(dr["TABLENAME"]);
            if (dr["TABLEID"] != DBNull.Value) sys_DictKey.TABLEID = Convert.ToString(dr["TABLEID"]);
            if (dr["ID"] != DBNull.Value) sys_DictKey.ID = Convert.ToInt32(dr["ID"]);
            if (dr["ModuleCode"] != DBNull.Value) sys_DictKey.ModuleCode = Convert.ToString(dr["ModuleCode"]);
            if (dr["PrefixCode"] != DBNull.Value) sys_DictKey.PrefixCode = Convert.ToString(dr["PrefixCode"]);
            if (dr["CodeLenth"] != DBNull.Value) sys_DictKey.CodeLenth = Convert.ToInt32(dr["CodeLenth"]);
            ret.Add(sys_DictKey);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Sys_DictKey对象(即:一条记录
      /// </summary>
      public List<Sys_DictKey> GetAll()
      {
         List<Sys_DictKey> ret = new List<Sys_DictKey>();
         string sql = "SELECT  TABLENAME,TABLEID,ID,ModuleCode,PrefixCode,CodeLenth FROM Sys_DictKey where 1=1 AND ((Stat is null) or (Stat=0) ) order by TABLENAME desc ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_DictKey sys_DictKey = new Sys_DictKey();
            if (dr["TABLENAME"] != DBNull.Value) sys_DictKey.TABLENAME = Convert.ToString(dr["TABLENAME"]);
            if (dr["TABLEID"] != DBNull.Value) sys_DictKey.TABLEID = Convert.ToString(dr["TABLEID"]);
            if (dr["ID"] != DBNull.Value) sys_DictKey.ID = Convert.ToInt32(dr["ID"]);
            if (dr["ModuleCode"] != DBNull.Value) sys_DictKey.ModuleCode = Convert.ToString(dr["ModuleCode"]);
            if (dr["PrefixCode"] != DBNull.Value) sys_DictKey.PrefixCode = Convert.ToString(dr["PrefixCode"]);
            if (dr["CodeLenth"] != DBNull.Value) sys_DictKey.CodeLenth = Convert.ToInt32(dr["CodeLenth"]);
            ret.Add(sys_DictKey);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
