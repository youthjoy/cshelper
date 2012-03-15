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
   /// 审核流程记录表
   /// </summary>
   [Serializable]
   public partial class ADOVerifyProcess_Records
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加审核流程记录表 VerifyProcess_Records对象(即:一条记录)
      /// </summary>
      public int Add(VerifyProcess_Records verifyProcess_Records)
      {
         string sql = "INSERT INTO VerifyProcess_Records (VRecord_Code,Module_Code,Record_ID,VRecord_VCode,VRecord_Owner,VRecord_Date,VRecord_Opinion,VRecord_Flag,VRecord_UDef1,VRecord_UDef2,VRecord_UDef3,VRecord_UDef4,VRecord_UDef5,VRecord_UDef6,Stat) VALUES (@VRecord_Code,@Module_Code,@Record_ID,@VRecord_VCode,@VRecord_Owner,@VRecord_Date,@VRecord_Opinion,@VRecord_Flag,@VRecord_UDef1,@VRecord_UDef2,@VRecord_UDef3,@VRecord_UDef4,@VRecord_UDef5,@VRecord_UDef6,@Stat)";
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Code))
         {
            idb.AddParameter("@VRecord_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Code", verifyProcess_Records.VRecord_Code);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.Module_Code))
         {
            idb.AddParameter("@Module_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Module_Code", verifyProcess_Records.Module_Code);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.Record_ID))
         {
            idb.AddParameter("@Record_ID", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Record_ID", verifyProcess_Records.Record_ID);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_VCode))
         {
            idb.AddParameter("@VRecord_VCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_VCode", verifyProcess_Records.VRecord_VCode);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Owner))
         {
            idb.AddParameter("@VRecord_Owner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Owner", verifyProcess_Records.VRecord_Owner);
         }
         if (verifyProcess_Records.VRecord_Date == DateTime.MinValue)
         {
            idb.AddParameter("@VRecord_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Date", verifyProcess_Records.VRecord_Date);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Opinion))
         {
            idb.AddParameter("@VRecord_Opinion", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Opinion", verifyProcess_Records.VRecord_Opinion);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Flag))
         {
            idb.AddParameter("@VRecord_Flag", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Flag", verifyProcess_Records.VRecord_Flag);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef1))
         {
            idb.AddParameter("@VRecord_UDef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef1", verifyProcess_Records.VRecord_UDef1);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef2))
         {
            idb.AddParameter("@VRecord_UDef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef2", verifyProcess_Records.VRecord_UDef2);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef3))
         {
            idb.AddParameter("@VRecord_UDef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef3", verifyProcess_Records.VRecord_UDef3);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef4))
         {
            idb.AddParameter("@VRecord_UDef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef4", verifyProcess_Records.VRecord_UDef4);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef5))
         {
            idb.AddParameter("@VRecord_UDef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef5", verifyProcess_Records.VRecord_UDef5);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef6))
         {
            idb.AddParameter("@VRecord_UDef6", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef6", verifyProcess_Records.VRecord_UDef6);
         }
         if (verifyProcess_Records.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verifyProcess_Records.Stat);
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
      /// 添加审核流程记录表 VerifyProcess_Records对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(VerifyProcess_Records verifyProcess_Records)
      {
         string sql = "INSERT INTO VerifyProcess_Records (VRecord_Code,Module_Code,Record_ID,VRecord_VCode,VRecord_Owner,VRecord_Date,VRecord_Opinion,VRecord_Flag,VRecord_UDef1,VRecord_UDef2,VRecord_UDef3,VRecord_UDef4,VRecord_UDef5,VRecord_UDef6,Stat) VALUES (@VRecord_Code,@Module_Code,@Record_ID,@VRecord_VCode,@VRecord_Owner,@VRecord_Date,@VRecord_Opinion,@VRecord_Flag,@VRecord_UDef1,@VRecord_UDef2,@VRecord_UDef3,@VRecord_UDef4,@VRecord_UDef5,@VRecord_UDef6,@Stat);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Code))
         {
            idb.AddParameter("@VRecord_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Code", verifyProcess_Records.VRecord_Code);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.Module_Code))
         {
            idb.AddParameter("@Module_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Module_Code", verifyProcess_Records.Module_Code);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.Record_ID))
         {
            idb.AddParameter("@Record_ID", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Record_ID", verifyProcess_Records.Record_ID);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_VCode))
         {
            idb.AddParameter("@VRecord_VCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_VCode", verifyProcess_Records.VRecord_VCode);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Owner))
         {
            idb.AddParameter("@VRecord_Owner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Owner", verifyProcess_Records.VRecord_Owner);
         }
         if (verifyProcess_Records.VRecord_Date == DateTime.MinValue)
         {
            idb.AddParameter("@VRecord_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Date", verifyProcess_Records.VRecord_Date);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Opinion))
         {
            idb.AddParameter("@VRecord_Opinion", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Opinion", verifyProcess_Records.VRecord_Opinion);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Flag))
         {
            idb.AddParameter("@VRecord_Flag", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Flag", verifyProcess_Records.VRecord_Flag);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef1))
         {
            idb.AddParameter("@VRecord_UDef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef1", verifyProcess_Records.VRecord_UDef1);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef2))
         {
            idb.AddParameter("@VRecord_UDef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef2", verifyProcess_Records.VRecord_UDef2);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef3))
         {
            idb.AddParameter("@VRecord_UDef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef3", verifyProcess_Records.VRecord_UDef3);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef4))
         {
            idb.AddParameter("@VRecord_UDef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef4", verifyProcess_Records.VRecord_UDef4);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef5))
         {
            idb.AddParameter("@VRecord_UDef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef5", verifyProcess_Records.VRecord_UDef5);
         }
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef6))
         {
            idb.AddParameter("@VRecord_UDef6", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef6", verifyProcess_Records.VRecord_UDef6);
         }
         if (verifyProcess_Records.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verifyProcess_Records.Stat);
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
      /// 更新审核流程记录表 VerifyProcess_Records对象(即:一条记录
      /// </summary>
      public int Update(VerifyProcess_Records verifyProcess_Records)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       VerifyProcess_Records       SET ");
            if(verifyProcess_Records.VRecord_Code_IsChanged){sbParameter.Append("VRecord_Code=@VRecord_Code, ");}
      if(verifyProcess_Records.Module_Code_IsChanged){sbParameter.Append("Module_Code=@Module_Code, ");}
      if(verifyProcess_Records.Record_ID_IsChanged){sbParameter.Append("Record_ID=@Record_ID, ");}
      if(verifyProcess_Records.VRecord_VCode_IsChanged){sbParameter.Append("VRecord_VCode=@VRecord_VCode, ");}
      if(verifyProcess_Records.VRecord_Owner_IsChanged){sbParameter.Append("VRecord_Owner=@VRecord_Owner, ");}
      if(verifyProcess_Records.VRecord_Date_IsChanged){sbParameter.Append("VRecord_Date=@VRecord_Date, ");}
      if(verifyProcess_Records.VRecord_Opinion_IsChanged){sbParameter.Append("VRecord_Opinion=@VRecord_Opinion, ");}
      if(verifyProcess_Records.VRecord_Flag_IsChanged){sbParameter.Append("VRecord_Flag=@VRecord_Flag, ");}
      if(verifyProcess_Records.VRecord_UDef1_IsChanged){sbParameter.Append("VRecord_UDef1=@VRecord_UDef1, ");}
      if(verifyProcess_Records.VRecord_UDef2_IsChanged){sbParameter.Append("VRecord_UDef2=@VRecord_UDef2, ");}
      if(verifyProcess_Records.VRecord_UDef3_IsChanged){sbParameter.Append("VRecord_UDef3=@VRecord_UDef3, ");}
      if(verifyProcess_Records.VRecord_UDef4_IsChanged){sbParameter.Append("VRecord_UDef4=@VRecord_UDef4, ");}
      if(verifyProcess_Records.VRecord_UDef5_IsChanged){sbParameter.Append("VRecord_UDef5=@VRecord_UDef5, ");}
      if(verifyProcess_Records.VRecord_UDef6_IsChanged){sbParameter.Append("VRecord_UDef6=@VRecord_UDef6, ");}
      if(verifyProcess_Records.Stat_IsChanged){sbParameter.Append("Stat=@Stat ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and VRecord_ID=@VRecord_ID; " );
      string sql=sb.ToString();
         if(verifyProcess_Records.VRecord_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Code))
         {
            idb.AddParameter("@VRecord_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Code", verifyProcess_Records.VRecord_Code);
         }
          }
         if(verifyProcess_Records.Module_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.Module_Code))
         {
            idb.AddParameter("@Module_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Module_Code", verifyProcess_Records.Module_Code);
         }
          }
         if(verifyProcess_Records.Record_ID_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.Record_ID))
         {
            idb.AddParameter("@Record_ID", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Record_ID", verifyProcess_Records.Record_ID);
         }
          }
         if(verifyProcess_Records.VRecord_VCode_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_VCode))
         {
            idb.AddParameter("@VRecord_VCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_VCode", verifyProcess_Records.VRecord_VCode);
         }
          }
         if(verifyProcess_Records.VRecord_Owner_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Owner))
         {
            idb.AddParameter("@VRecord_Owner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Owner", verifyProcess_Records.VRecord_Owner);
         }
          }
         if(verifyProcess_Records.VRecord_Date_IsChanged)
         {
         if (verifyProcess_Records.VRecord_Date == DateTime.MinValue)
         {
            idb.AddParameter("@VRecord_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Date", verifyProcess_Records.VRecord_Date);
         }
          }
         if(verifyProcess_Records.VRecord_Opinion_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Opinion))
         {
            idb.AddParameter("@VRecord_Opinion", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Opinion", verifyProcess_Records.VRecord_Opinion);
         }
          }
         if(verifyProcess_Records.VRecord_Flag_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_Flag))
         {
            idb.AddParameter("@VRecord_Flag", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_Flag", verifyProcess_Records.VRecord_Flag);
         }
          }
         if(verifyProcess_Records.VRecord_UDef1_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef1))
         {
            idb.AddParameter("@VRecord_UDef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef1", verifyProcess_Records.VRecord_UDef1);
         }
          }
         if(verifyProcess_Records.VRecord_UDef2_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef2))
         {
            idb.AddParameter("@VRecord_UDef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef2", verifyProcess_Records.VRecord_UDef2);
         }
          }
         if(verifyProcess_Records.VRecord_UDef3_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef3))
         {
            idb.AddParameter("@VRecord_UDef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef3", verifyProcess_Records.VRecord_UDef3);
         }
          }
         if(verifyProcess_Records.VRecord_UDef4_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef4))
         {
            idb.AddParameter("@VRecord_UDef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef4", verifyProcess_Records.VRecord_UDef4);
         }
          }
         if(verifyProcess_Records.VRecord_UDef5_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef5))
         {
            idb.AddParameter("@VRecord_UDef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef5", verifyProcess_Records.VRecord_UDef5);
         }
          }
         if(verifyProcess_Records.VRecord_UDef6_IsChanged)
         {
         if (string.IsNullOrEmpty(verifyProcess_Records.VRecord_UDef6))
         {
            idb.AddParameter("@VRecord_UDef6", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VRecord_UDef6", verifyProcess_Records.VRecord_UDef6);
         }
          }
         if(verifyProcess_Records.Stat_IsChanged)
         {
         if (verifyProcess_Records.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verifyProcess_Records.Stat);
         }
          }

         idb.AddParameter("@VRecord_ID", verifyProcess_Records.VRecord_ID);


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
      /// 删除审核流程记录表 VerifyProcess_Records对象(即:一条记录
      /// </summary>
      public int Delete(decimal vRecord_ID)
      {
         string sql = "DELETE VerifyProcess_Records WHERE 1=1  AND VRecord_ID=@VRecord_ID ";
         idb.AddParameter("@VRecord_ID", vRecord_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的审核流程记录表 VerifyProcess_Records对象(即:一条记录
      /// </summary>
      public VerifyProcess_Records GetByKey(decimal vRecord_ID)
      {
         VerifyProcess_Records verifyProcess_Records = new VerifyProcess_Records();
         string sql = "SELECT  VRecord_ID,VRecord_Code,Module_Code,Record_ID,VRecord_VCode,VRecord_Owner,VRecord_Date,VRecord_Opinion,VRecord_Flag,VRecord_UDef1,VRecord_UDef2,VRecord_UDef3,VRecord_UDef4,VRecord_UDef5,VRecord_UDef6,Stat FROM VerifyProcess_Records WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND VRecord_ID=@VRecord_ID ";
         idb.AddParameter("@VRecord_ID", vRecord_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["VRecord_ID"] != DBNull.Value) verifyProcess_Records.VRecord_ID = Convert.ToDecimal(dr["VRecord_ID"]);
            if (dr["VRecord_Code"] != DBNull.Value) verifyProcess_Records.VRecord_Code = Convert.ToString(dr["VRecord_Code"]);
            if (dr["Module_Code"] != DBNull.Value) verifyProcess_Records.Module_Code = Convert.ToString(dr["Module_Code"]);
            if (dr["Record_ID"] != DBNull.Value) verifyProcess_Records.Record_ID = Convert.ToString(dr["Record_ID"]);
            if (dr["VRecord_VCode"] != DBNull.Value) verifyProcess_Records.VRecord_VCode = Convert.ToString(dr["VRecord_VCode"]);
            if (dr["VRecord_Owner"] != DBNull.Value) verifyProcess_Records.VRecord_Owner = Convert.ToString(dr["VRecord_Owner"]);
            if (dr["VRecord_Date"] != DBNull.Value) verifyProcess_Records.VRecord_Date = Convert.ToDateTime(dr["VRecord_Date"]);
            if (dr["VRecord_Opinion"] != DBNull.Value) verifyProcess_Records.VRecord_Opinion = Convert.ToString(dr["VRecord_Opinion"]);
            if (dr["VRecord_Flag"] != DBNull.Value) verifyProcess_Records.VRecord_Flag = Convert.ToString(dr["VRecord_Flag"]);
            if (dr["VRecord_UDef1"] != DBNull.Value) verifyProcess_Records.VRecord_UDef1 = Convert.ToString(dr["VRecord_UDef1"]);
            if (dr["VRecord_UDef2"] != DBNull.Value) verifyProcess_Records.VRecord_UDef2 = Convert.ToString(dr["VRecord_UDef2"]);
            if (dr["VRecord_UDef3"] != DBNull.Value) verifyProcess_Records.VRecord_UDef3 = Convert.ToString(dr["VRecord_UDef3"]);
            if (dr["VRecord_UDef4"] != DBNull.Value) verifyProcess_Records.VRecord_UDef4 = Convert.ToString(dr["VRecord_UDef4"]);
            if (dr["VRecord_UDef5"] != DBNull.Value) verifyProcess_Records.VRecord_UDef5 = Convert.ToString(dr["VRecord_UDef5"]);
            if (dr["VRecord_UDef6"] != DBNull.Value) verifyProcess_Records.VRecord_UDef6 = Convert.ToString(dr["VRecord_UDef6"]);
            if (dr["Stat"] != DBNull.Value) verifyProcess_Records.Stat = Convert.ToInt32(dr["Stat"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return verifyProcess_Records;
      }
      /// <summary>
      /// 获取指定的审核流程记录表 VerifyProcess_Records对象集合
      /// </summary>
      public List<VerifyProcess_Records> GetListByWhere(string strCondition)
      {
         List<VerifyProcess_Records> ret = new List<VerifyProcess_Records>();
         string sql = "SELECT  VRecord_ID,VRecord_Code,Module_Code,Record_ID,VRecord_VCode,VRecord_Owner,VRecord_Date,VRecord_Opinion,VRecord_Flag,VRecord_UDef1,VRecord_UDef2,VRecord_UDef3,VRecord_UDef4,VRecord_UDef5,VRecord_UDef6,Stat FROM VerifyProcess_Records WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            VerifyProcess_Records verifyProcess_Records = new VerifyProcess_Records();
            if (dr["VRecord_ID"] != DBNull.Value) verifyProcess_Records.VRecord_ID = Convert.ToDecimal(dr["VRecord_ID"]);
            if (dr["VRecord_Code"] != DBNull.Value) verifyProcess_Records.VRecord_Code = Convert.ToString(dr["VRecord_Code"]);
            if (dr["Module_Code"] != DBNull.Value) verifyProcess_Records.Module_Code = Convert.ToString(dr["Module_Code"]);
            if (dr["Record_ID"] != DBNull.Value) verifyProcess_Records.Record_ID = Convert.ToString(dr["Record_ID"]);
            if (dr["VRecord_VCode"] != DBNull.Value) verifyProcess_Records.VRecord_VCode = Convert.ToString(dr["VRecord_VCode"]);
            if (dr["VRecord_Owner"] != DBNull.Value) verifyProcess_Records.VRecord_Owner = Convert.ToString(dr["VRecord_Owner"]);
            if (dr["VRecord_Date"] != DBNull.Value) verifyProcess_Records.VRecord_Date = Convert.ToDateTime(dr["VRecord_Date"]);
            if (dr["VRecord_Opinion"] != DBNull.Value) verifyProcess_Records.VRecord_Opinion = Convert.ToString(dr["VRecord_Opinion"]);
            if (dr["VRecord_Flag"] != DBNull.Value) verifyProcess_Records.VRecord_Flag = Convert.ToString(dr["VRecord_Flag"]);
            if (dr["VRecord_UDef1"] != DBNull.Value) verifyProcess_Records.VRecord_UDef1 = Convert.ToString(dr["VRecord_UDef1"]);
            if (dr["VRecord_UDef2"] != DBNull.Value) verifyProcess_Records.VRecord_UDef2 = Convert.ToString(dr["VRecord_UDef2"]);
            if (dr["VRecord_UDef3"] != DBNull.Value) verifyProcess_Records.VRecord_UDef3 = Convert.ToString(dr["VRecord_UDef3"]);
            if (dr["VRecord_UDef4"] != DBNull.Value) verifyProcess_Records.VRecord_UDef4 = Convert.ToString(dr["VRecord_UDef4"]);
            if (dr["VRecord_UDef5"] != DBNull.Value) verifyProcess_Records.VRecord_UDef5 = Convert.ToString(dr["VRecord_UDef5"]);
            if (dr["VRecord_UDef6"] != DBNull.Value) verifyProcess_Records.VRecord_UDef6 = Convert.ToString(dr["VRecord_UDef6"]);
            if (dr["Stat"] != DBNull.Value) verifyProcess_Records.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(verifyProcess_Records);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的审核流程记录表 VerifyProcess_Records对象(即:一条记录
      /// </summary>
      public List<VerifyProcess_Records> GetAll()
      {
         List<VerifyProcess_Records> ret = new List<VerifyProcess_Records>();
         string sql = "SELECT  VRecord_ID,VRecord_Code,Module_Code,Record_ID,VRecord_VCode,VRecord_Owner,VRecord_Date,VRecord_Opinion,VRecord_Flag,VRecord_UDef1,VRecord_UDef2,VRecord_UDef3,VRecord_UDef4,VRecord_UDef5,VRecord_UDef6,Stat FROM VerifyProcess_Records where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            VerifyProcess_Records verifyProcess_Records = new VerifyProcess_Records();
            if (dr["VRecord_ID"] != DBNull.Value) verifyProcess_Records.VRecord_ID = Convert.ToDecimal(dr["VRecord_ID"]);
            if (dr["VRecord_Code"] != DBNull.Value) verifyProcess_Records.VRecord_Code = Convert.ToString(dr["VRecord_Code"]);
            if (dr["Module_Code"] != DBNull.Value) verifyProcess_Records.Module_Code = Convert.ToString(dr["Module_Code"]);
            if (dr["Record_ID"] != DBNull.Value) verifyProcess_Records.Record_ID = Convert.ToString(dr["Record_ID"]);
            if (dr["VRecord_VCode"] != DBNull.Value) verifyProcess_Records.VRecord_VCode = Convert.ToString(dr["VRecord_VCode"]);
            if (dr["VRecord_Owner"] != DBNull.Value) verifyProcess_Records.VRecord_Owner = Convert.ToString(dr["VRecord_Owner"]);
            if (dr["VRecord_Date"] != DBNull.Value) verifyProcess_Records.VRecord_Date = Convert.ToDateTime(dr["VRecord_Date"]);
            if (dr["VRecord_Opinion"] != DBNull.Value) verifyProcess_Records.VRecord_Opinion = Convert.ToString(dr["VRecord_Opinion"]);
            if (dr["VRecord_Flag"] != DBNull.Value) verifyProcess_Records.VRecord_Flag = Convert.ToString(dr["VRecord_Flag"]);
            if (dr["VRecord_UDef1"] != DBNull.Value) verifyProcess_Records.VRecord_UDef1 = Convert.ToString(dr["VRecord_UDef1"]);
            if (dr["VRecord_UDef2"] != DBNull.Value) verifyProcess_Records.VRecord_UDef2 = Convert.ToString(dr["VRecord_UDef2"]);
            if (dr["VRecord_UDef3"] != DBNull.Value) verifyProcess_Records.VRecord_UDef3 = Convert.ToString(dr["VRecord_UDef3"]);
            if (dr["VRecord_UDef4"] != DBNull.Value) verifyProcess_Records.VRecord_UDef4 = Convert.ToString(dr["VRecord_UDef4"]);
            if (dr["VRecord_UDef5"] != DBNull.Value) verifyProcess_Records.VRecord_UDef5 = Convert.ToString(dr["VRecord_UDef5"]);
            if (dr["VRecord_UDef6"] != DBNull.Value) verifyProcess_Records.VRecord_UDef6 = Convert.ToString(dr["VRecord_UDef6"]);
            if (dr["Stat"] != DBNull.Value) verifyProcess_Records.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(verifyProcess_Records);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
