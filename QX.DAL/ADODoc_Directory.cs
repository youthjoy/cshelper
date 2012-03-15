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
   public partial class ADODoc_Directory
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Doc_Directory对象(即:一条记录)
      /// </summary>
      public int Add(Doc_Directory doc_Directory)
      {
         string sql = "INSERT INTO Doc_Directory (DD_Code,DD_Name,DD_PCode,DD_iType,Stat) VALUES (@DD_Code,@DD_Name,@DD_PCode,@DD_iType,@Stat)";
         if (string.IsNullOrEmpty(doc_Directory.DD_Code))
         {
            idb.AddParameter("@DD_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DD_Code", doc_Directory.DD_Code);
         }
         if (string.IsNullOrEmpty(doc_Directory.DD_Name))
         {
            idb.AddParameter("@DD_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DD_Name", doc_Directory.DD_Name);
         }
         if (string.IsNullOrEmpty(doc_Directory.DD_PCode))
         {
            idb.AddParameter("@DD_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DD_PCode", doc_Directory.DD_PCode);
         }
         if (doc_Directory.DD_iType == 0)
         {
            idb.AddParameter("@DD_iType", 0);
         }
         else
         {
            idb.AddParameter("@DD_iType", doc_Directory.DD_iType);
         }
         if (doc_Directory.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", doc_Directory.Stat);
         }


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
      /// 添加Doc_Directory对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Doc_Directory doc_Directory)
      {
         string sql = "INSERT INTO Doc_Directory (DD_Code,DD_Name,DD_PCode,DD_iType,Stat) VALUES (@DD_Code,@DD_Name,@DD_PCode,@DD_iType,@Stat);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(doc_Directory.DD_Code))
         {
            idb.AddParameter("@DD_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DD_Code", doc_Directory.DD_Code);
         }
         if (string.IsNullOrEmpty(doc_Directory.DD_Name))
         {
            idb.AddParameter("@DD_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DD_Name", doc_Directory.DD_Name);
         }
         if (string.IsNullOrEmpty(doc_Directory.DD_PCode))
         {
            idb.AddParameter("@DD_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DD_PCode", doc_Directory.DD_PCode);
         }
         if (doc_Directory.DD_iType == 0)
         {
            idb.AddParameter("@DD_iType", 0);
         }
         else
         {
            idb.AddParameter("@DD_iType", doc_Directory.DD_iType);
         }
         if (doc_Directory.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", doc_Directory.Stat);
         }


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
      /// 更新Doc_Directory对象(即:一条记录
      /// </summary>
      public int Update(Doc_Directory doc_Directory)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Doc_Directory       SET ");
            if(doc_Directory.DD_Code_IsChanged){sbParameter.Append("DD_Code=@DD_Code, ");}
      if(doc_Directory.DD_Name_IsChanged){sbParameter.Append("DD_Name=@DD_Name, ");}
      if(doc_Directory.DD_PCode_IsChanged){sbParameter.Append("DD_PCode=@DD_PCode, ");}
      if(doc_Directory.DD_iType_IsChanged){sbParameter.Append("DD_iType=@DD_iType, ");}
      if(doc_Directory.Stat_IsChanged){sbParameter.Append("Stat=@Stat ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and DD_ID=@DD_ID; " );
      string sql=sb.ToString();
         if(doc_Directory.DD_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(doc_Directory.DD_Code))
         {
            idb.AddParameter("@DD_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DD_Code", doc_Directory.DD_Code);
         }
          }
         if(doc_Directory.DD_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(doc_Directory.DD_Name))
         {
            idb.AddParameter("@DD_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DD_Name", doc_Directory.DD_Name);
         }
          }
         if(doc_Directory.DD_PCode_IsChanged)
         {
         if (string.IsNullOrEmpty(doc_Directory.DD_PCode))
         {
            idb.AddParameter("@DD_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DD_PCode", doc_Directory.DD_PCode);
         }
          }
         if(doc_Directory.DD_iType_IsChanged)
         {
         if (doc_Directory.DD_iType == 0)
         {
            idb.AddParameter("@DD_iType", 0);
         }
         else
         {
            idb.AddParameter("@DD_iType", doc_Directory.DD_iType);
         }
          }
         if(doc_Directory.Stat_IsChanged)
         {
         if (doc_Directory.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", doc_Directory.Stat);
         }
          }

         idb.AddParameter("@DD_ID", doc_Directory.DD_ID);


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
      /// 删除Doc_Directory对象(即:一条记录
      /// </summary>
      public int Delete(decimal dD_ID)
      {
         string sql = "DELETE Doc_Directory WHERE 1=1  AND DD_ID=@DD_ID ";
         idb.AddParameter("@DD_ID", dD_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Doc_Directory对象(即:一条记录
      /// </summary>
      public Doc_Directory GetByKey(decimal dD_ID)
      {
         Doc_Directory doc_Directory = new Doc_Directory();
         string sql = "SELECT  DD_ID,DD_Code,DD_Name,DD_PCode,DD_iType,Stat FROM Doc_Directory WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND DD_ID=@DD_ID ";
         idb.AddParameter("@DD_ID", dD_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["DD_ID"] != DBNull.Value) doc_Directory.DD_ID = Convert.ToDecimal(dr["DD_ID"]);
            if (dr["DD_Code"] != DBNull.Value) doc_Directory.DD_Code = Convert.ToString(dr["DD_Code"]);
            if (dr["DD_Name"] != DBNull.Value) doc_Directory.DD_Name = Convert.ToString(dr["DD_Name"]);
            if (dr["DD_PCode"] != DBNull.Value) doc_Directory.DD_PCode = Convert.ToString(dr["DD_PCode"]);
            if (dr["DD_iType"] != DBNull.Value) doc_Directory.DD_iType = Convert.ToInt32(dr["DD_iType"]);
            if (dr["Stat"] != DBNull.Value) doc_Directory.Stat = Convert.ToInt32(dr["Stat"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return doc_Directory;
      }
      /// <summary>
      /// 获取指定的Doc_Directory对象集合
      /// </summary>
      public List<Doc_Directory> GetListByWhere(string strCondition)
      {
         List<Doc_Directory> ret = new List<Doc_Directory>();
         string sql = "SELECT  DD_ID,DD_Code,DD_Name,DD_PCode,DD_iType,Stat FROM Doc_Directory WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Doc_Directory doc_Directory = new Doc_Directory();
            if (dr["DD_ID"] != DBNull.Value) doc_Directory.DD_ID = Convert.ToDecimal(dr["DD_ID"]);
            if (dr["DD_Code"] != DBNull.Value) doc_Directory.DD_Code = Convert.ToString(dr["DD_Code"]);
            if (dr["DD_Name"] != DBNull.Value) doc_Directory.DD_Name = Convert.ToString(dr["DD_Name"]);
            if (dr["DD_PCode"] != DBNull.Value) doc_Directory.DD_PCode = Convert.ToString(dr["DD_PCode"]);
            if (dr["DD_iType"] != DBNull.Value) doc_Directory.DD_iType = Convert.ToInt32(dr["DD_iType"]);
            if (dr["Stat"] != DBNull.Value) doc_Directory.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(doc_Directory);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Doc_Directory对象(即:一条记录
      /// </summary>
      public List<Doc_Directory> GetAll()
      {
         List<Doc_Directory> ret = new List<Doc_Directory>();
         string sql = "SELECT  DD_ID,DD_Code,DD_Name,DD_PCode,DD_iType,Stat FROM Doc_Directory where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Doc_Directory doc_Directory = new Doc_Directory();
            if (dr["DD_ID"] != DBNull.Value) doc_Directory.DD_ID = Convert.ToDecimal(dr["DD_ID"]);
            if (dr["DD_Code"] != DBNull.Value) doc_Directory.DD_Code = Convert.ToString(dr["DD_Code"]);
            if (dr["DD_Name"] != DBNull.Value) doc_Directory.DD_Name = Convert.ToString(dr["DD_Name"]);
            if (dr["DD_PCode"] != DBNull.Value) doc_Directory.DD_PCode = Convert.ToString(dr["DD_PCode"]);
            if (dr["DD_iType"] != DBNull.Value) doc_Directory.DD_iType = Convert.ToInt32(dr["DD_iType"]);
            if (dr["Stat"] != DBNull.Value) doc_Directory.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(doc_Directory);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
