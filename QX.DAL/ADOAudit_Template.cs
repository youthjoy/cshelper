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
   /// 审核模板列表
   /// </summary>
   [Serializable]
   public partial class ADOAudit_Template
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加审核模板列表 Audit_Template对象(即:一条记录)
      /// </summary>
      public int Add(Audit_Template audit_Template)
      {
         string sql = "INSERT INTO Audit_Template (Template_Code,Template_Key,Template_Name,Template_Remark,Stat,Template_Table,Template_Column,Template_ColumnType,Template_CheckSQL) VALUES (@Template_Code,@Template_Key,@Template_Name,@Template_Remark,@Stat,@Template_Table,@Template_Column,@Template_ColumnType,@Template_CheckSQL)";
         if (string.IsNullOrEmpty(audit_Template.Template_Code))
         {
            idb.AddParameter("@Template_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Code", audit_Template.Template_Code);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Key))
         {
            idb.AddParameter("@Template_Key", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Key", audit_Template.Template_Key);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Name))
         {
            idb.AddParameter("@Template_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Name", audit_Template.Template_Name);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Remark))
         {
            idb.AddParameter("@Template_Remark", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Remark", audit_Template.Template_Remark);
         }
         if (audit_Template.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", audit_Template.Stat);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Table))
         {
            idb.AddParameter("@Template_Table", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Table", audit_Template.Template_Table);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Column))
         {
            idb.AddParameter("@Template_Column", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Column", audit_Template.Template_Column);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_ColumnType))
         {
            idb.AddParameter("@Template_ColumnType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_ColumnType", audit_Template.Template_ColumnType);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_CheckSQL))
         {
            idb.AddParameter("@Template_CheckSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_CheckSQL", audit_Template.Template_CheckSQL);
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
      /// 添加审核模板列表 Audit_Template对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Audit_Template audit_Template)
      {
         string sql = "INSERT INTO Audit_Template (Template_Code,Template_Key,Template_Name,Template_Remark,Stat,Template_Table,Template_Column,Template_ColumnType,Template_CheckSQL) VALUES (@Template_Code,@Template_Key,@Template_Name,@Template_Remark,@Stat,@Template_Table,@Template_Column,@Template_ColumnType,@Template_CheckSQL);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(audit_Template.Template_Code))
         {
            idb.AddParameter("@Template_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Code", audit_Template.Template_Code);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Key))
         {
            idb.AddParameter("@Template_Key", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Key", audit_Template.Template_Key);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Name))
         {
            idb.AddParameter("@Template_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Name", audit_Template.Template_Name);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Remark))
         {
            idb.AddParameter("@Template_Remark", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Remark", audit_Template.Template_Remark);
         }
         if (audit_Template.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", audit_Template.Stat);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Table))
         {
            idb.AddParameter("@Template_Table", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Table", audit_Template.Template_Table);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_Column))
         {
            idb.AddParameter("@Template_Column", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Column", audit_Template.Template_Column);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_ColumnType))
         {
            idb.AddParameter("@Template_ColumnType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_ColumnType", audit_Template.Template_ColumnType);
         }
         if (string.IsNullOrEmpty(audit_Template.Template_CheckSQL))
         {
            idb.AddParameter("@Template_CheckSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_CheckSQL", audit_Template.Template_CheckSQL);
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
      /// 更新审核模板列表 Audit_Template对象(即:一条记录
      /// </summary>
      public int Update(Audit_Template audit_Template)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Audit_Template       SET ");
            if(audit_Template.Template_Code_IsChanged){sbParameter.Append("Template_Code=@Template_Code, ");}
      if(audit_Template.Template_Key_IsChanged){sbParameter.Append("Template_Key=@Template_Key, ");}
      if(audit_Template.Template_Name_IsChanged){sbParameter.Append("Template_Name=@Template_Name, ");}
      if(audit_Template.Template_Remark_IsChanged){sbParameter.Append("Template_Remark=@Template_Remark, ");}
      if(audit_Template.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(audit_Template.Template_Table_IsChanged){sbParameter.Append("Template_Table=@Template_Table, ");}
      if(audit_Template.Template_Column_IsChanged){sbParameter.Append("Template_Column=@Template_Column, ");}
      if(audit_Template.Template_ColumnType_IsChanged){sbParameter.Append("Template_ColumnType=@Template_ColumnType, ");}
      if(audit_Template.Template_CheckSQL_IsChanged){sbParameter.Append("Template_CheckSQL=@Template_CheckSQL ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and Template_ID=@Template_ID; " );
      string sql=sb.ToString();
         if(audit_Template.Template_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(audit_Template.Template_Code))
         {
            idb.AddParameter("@Template_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Code", audit_Template.Template_Code);
         }
          }
         if(audit_Template.Template_Key_IsChanged)
         {
         if (string.IsNullOrEmpty(audit_Template.Template_Key))
         {
            idb.AddParameter("@Template_Key", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Key", audit_Template.Template_Key);
         }
          }
         if(audit_Template.Template_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(audit_Template.Template_Name))
         {
            idb.AddParameter("@Template_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Name", audit_Template.Template_Name);
         }
          }
         if(audit_Template.Template_Remark_IsChanged)
         {
         if (string.IsNullOrEmpty(audit_Template.Template_Remark))
         {
            idb.AddParameter("@Template_Remark", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Remark", audit_Template.Template_Remark);
         }
          }
         if(audit_Template.Stat_IsChanged)
         {
         if (audit_Template.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", audit_Template.Stat);
         }
          }
         if(audit_Template.Template_Table_IsChanged)
         {
         if (string.IsNullOrEmpty(audit_Template.Template_Table))
         {
            idb.AddParameter("@Template_Table", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Table", audit_Template.Template_Table);
         }
          }
         if(audit_Template.Template_Column_IsChanged)
         {
         if (string.IsNullOrEmpty(audit_Template.Template_Column))
         {
            idb.AddParameter("@Template_Column", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_Column", audit_Template.Template_Column);
         }
          }
         if(audit_Template.Template_ColumnType_IsChanged)
         {
         if (string.IsNullOrEmpty(audit_Template.Template_ColumnType))
         {
            idb.AddParameter("@Template_ColumnType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_ColumnType", audit_Template.Template_ColumnType);
         }
          }
         if(audit_Template.Template_CheckSQL_IsChanged)
         {
         if (string.IsNullOrEmpty(audit_Template.Template_CheckSQL))
         {
            idb.AddParameter("@Template_CheckSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Template_CheckSQL", audit_Template.Template_CheckSQL);
         }
          }

         idb.AddParameter("@Template_ID", audit_Template.Template_ID);


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
      /// 删除审核模板列表 Audit_Template对象(即:一条记录
      /// </summary>
      public int Delete(decimal template_ID)
      {
         string sql = "DELETE Audit_Template WHERE 1=1  AND Template_ID=@Template_ID ";
         idb.AddParameter("@Template_ID", template_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的审核模板列表 Audit_Template对象(即:一条记录
      /// </summary>
      public Audit_Template GetByKey(decimal template_ID)
      {
         Audit_Template audit_Template = new Audit_Template();
         string sql = "SELECT  Template_ID,Template_Code,Template_Key,Template_Name,Template_Remark,Stat,Template_Table,Template_Column,Template_ColumnType,Template_CheckSQL FROM Audit_Template WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND Template_ID=@Template_ID ";
         idb.AddParameter("@Template_ID", template_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["Template_ID"] != DBNull.Value) audit_Template.Template_ID = Convert.ToDecimal(dr["Template_ID"]);
            if (dr["Template_Code"] != DBNull.Value) audit_Template.Template_Code = Convert.ToString(dr["Template_Code"]);
            if (dr["Template_Key"] != DBNull.Value) audit_Template.Template_Key = Convert.ToString(dr["Template_Key"]);
            if (dr["Template_Name"] != DBNull.Value) audit_Template.Template_Name = Convert.ToString(dr["Template_Name"]);
            if (dr["Template_Remark"] != DBNull.Value) audit_Template.Template_Remark = Convert.ToString(dr["Template_Remark"]);
            if (dr["Stat"] != DBNull.Value) audit_Template.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Template_Table"] != DBNull.Value) audit_Template.Template_Table = Convert.ToString(dr["Template_Table"]);
            if (dr["Template_Column"] != DBNull.Value) audit_Template.Template_Column = Convert.ToString(dr["Template_Column"]);
            if (dr["Template_ColumnType"] != DBNull.Value) audit_Template.Template_ColumnType = Convert.ToString(dr["Template_ColumnType"]);
            if (dr["Template_CheckSQL"] != DBNull.Value) audit_Template.Template_CheckSQL = Convert.ToString(dr["Template_CheckSQL"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return audit_Template;
      }
      /// <summary>
      /// 获取指定的审核模板列表 Audit_Template对象集合
      /// </summary>
      public List<Audit_Template> GetListByWhere(string strCondition)
      {
         List<Audit_Template> ret = new List<Audit_Template>();
         string sql = "SELECT  Template_ID,Template_Code,Template_Key,Template_Name,Template_Remark,Stat,Template_Table,Template_Column,Template_ColumnType,Template_CheckSQL FROM Audit_Template WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Audit_Template audit_Template = new Audit_Template();
            if (dr["Template_ID"] != DBNull.Value) audit_Template.Template_ID = Convert.ToDecimal(dr["Template_ID"]);
            if (dr["Template_Code"] != DBNull.Value) audit_Template.Template_Code = Convert.ToString(dr["Template_Code"]);
            if (dr["Template_Key"] != DBNull.Value) audit_Template.Template_Key = Convert.ToString(dr["Template_Key"]);
            if (dr["Template_Name"] != DBNull.Value) audit_Template.Template_Name = Convert.ToString(dr["Template_Name"]);
            if (dr["Template_Remark"] != DBNull.Value) audit_Template.Template_Remark = Convert.ToString(dr["Template_Remark"]);
            if (dr["Stat"] != DBNull.Value) audit_Template.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Template_Table"] != DBNull.Value) audit_Template.Template_Table = Convert.ToString(dr["Template_Table"]);
            if (dr["Template_Column"] != DBNull.Value) audit_Template.Template_Column = Convert.ToString(dr["Template_Column"]);
            if (dr["Template_ColumnType"] != DBNull.Value) audit_Template.Template_ColumnType = Convert.ToString(dr["Template_ColumnType"]);
            if (dr["Template_CheckSQL"] != DBNull.Value) audit_Template.Template_CheckSQL = Convert.ToString(dr["Template_CheckSQL"]);
            ret.Add(audit_Template);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的审核模板列表 Audit_Template对象(即:一条记录
      /// </summary>
      public List<Audit_Template> GetAll()
      {
         List<Audit_Template> ret = new List<Audit_Template>();
         string sql = "SELECT  Template_ID,Template_Code,Template_Key,Template_Name,Template_Remark,Stat,Template_Table,Template_Column,Template_ColumnType,Template_CheckSQL FROM Audit_Template where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Audit_Template audit_Template = new Audit_Template();
            if (dr["Template_ID"] != DBNull.Value) audit_Template.Template_ID = Convert.ToDecimal(dr["Template_ID"]);
            if (dr["Template_Code"] != DBNull.Value) audit_Template.Template_Code = Convert.ToString(dr["Template_Code"]);
            if (dr["Template_Key"] != DBNull.Value) audit_Template.Template_Key = Convert.ToString(dr["Template_Key"]);
            if (dr["Template_Name"] != DBNull.Value) audit_Template.Template_Name = Convert.ToString(dr["Template_Name"]);
            if (dr["Template_Remark"] != DBNull.Value) audit_Template.Template_Remark = Convert.ToString(dr["Template_Remark"]);
            if (dr["Stat"] != DBNull.Value) audit_Template.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Template_Table"] != DBNull.Value) audit_Template.Template_Table = Convert.ToString(dr["Template_Table"]);
            if (dr["Template_Column"] != DBNull.Value) audit_Template.Template_Column = Convert.ToString(dr["Template_Column"]);
            if (dr["Template_ColumnType"] != DBNull.Value) audit_Template.Template_ColumnType = Convert.ToString(dr["Template_ColumnType"]);
            if (dr["Template_CheckSQL"] != DBNull.Value) audit_Template.Template_CheckSQL = Convert.ToString(dr["Template_CheckSQL"]);
            ret.Add(audit_Template);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
