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
   public partial class ADOTpl_ReqDoc
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Tpl_ReqDoc对象(即:一条记录)
      /// </summary>
      public int Add(Tpl_ReqDoc tpl_ReqDoc)
      {
         string sql = "INSERT INTO Tpl_ReqDoc (TPRD_Code,TPRD_CompCode,TPRD_CompName,TPRD_Type,TPRD_Name,TPRD_IsReq,TPRD_Exp,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@TPRD_Code,@TPRD_CompCode,@TPRD_CompName,@TPRD_Type,@TPRD_Name,@TPRD_IsReq,@TPRD_Exp,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime)";
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Code))
         {
            idb.AddParameter("@TPRD_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Code", tpl_ReqDoc.TPRD_Code);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_CompCode))
         {
            idb.AddParameter("@TPRD_CompCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_CompCode", tpl_ReqDoc.TPRD_CompCode);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_CompName))
         {
            idb.AddParameter("@TPRD_CompName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_CompName", tpl_ReqDoc.TPRD_CompName);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Type))
         {
            idb.AddParameter("@TPRD_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Type", tpl_ReqDoc.TPRD_Type);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Name))
         {
            idb.AddParameter("@TPRD_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Name", tpl_ReqDoc.TPRD_Name);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_IsReq))
         {
            idb.AddParameter("@TPRD_IsReq", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_IsReq", tpl_ReqDoc.TPRD_IsReq);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Exp))
         {
            idb.AddParameter("@TPRD_Exp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Exp", tpl_ReqDoc.TPRD_Exp);
         }
         if (tpl_ReqDoc.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", tpl_ReqDoc.Stat);
         }
         if (tpl_ReqDoc.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", tpl_ReqDoc.Creator);
         }
         if (tpl_ReqDoc.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", tpl_ReqDoc.CreateTime);
         }
         if (tpl_ReqDoc.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", tpl_ReqDoc.UpdateTime);
         }
         if (tpl_ReqDoc.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", tpl_ReqDoc.DeleteTime);
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
      /// 添加Tpl_ReqDoc对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Tpl_ReqDoc tpl_ReqDoc)
      {
         string sql = "INSERT INTO Tpl_ReqDoc (TPRD_Code,TPRD_CompCode,TPRD_CompName,TPRD_Type,TPRD_Name,TPRD_IsReq,TPRD_Exp,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@TPRD_Code,@TPRD_CompCode,@TPRD_CompName,@TPRD_Type,@TPRD_Name,@TPRD_IsReq,@TPRD_Exp,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Code))
         {
            idb.AddParameter("@TPRD_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Code", tpl_ReqDoc.TPRD_Code);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_CompCode))
         {
            idb.AddParameter("@TPRD_CompCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_CompCode", tpl_ReqDoc.TPRD_CompCode);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_CompName))
         {
            idb.AddParameter("@TPRD_CompName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_CompName", tpl_ReqDoc.TPRD_CompName);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Type))
         {
            idb.AddParameter("@TPRD_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Type", tpl_ReqDoc.TPRD_Type);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Name))
         {
            idb.AddParameter("@TPRD_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Name", tpl_ReqDoc.TPRD_Name);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_IsReq))
         {
            idb.AddParameter("@TPRD_IsReq", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_IsReq", tpl_ReqDoc.TPRD_IsReq);
         }
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Exp))
         {
            idb.AddParameter("@TPRD_Exp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Exp", tpl_ReqDoc.TPRD_Exp);
         }
         if (tpl_ReqDoc.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", tpl_ReqDoc.Stat);
         }
         if (tpl_ReqDoc.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", tpl_ReqDoc.Creator);
         }
         if (tpl_ReqDoc.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", tpl_ReqDoc.CreateTime);
         }
         if (tpl_ReqDoc.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", tpl_ReqDoc.UpdateTime);
         }
         if (tpl_ReqDoc.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", tpl_ReqDoc.DeleteTime);
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
      /// 更新Tpl_ReqDoc对象(即:一条记录
      /// </summary>
      public int Update(Tpl_ReqDoc tpl_ReqDoc)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Tpl_ReqDoc       SET ");
            if(tpl_ReqDoc.TPRD_Code_IsChanged){sbParameter.Append("TPRD_Code=@TPRD_Code, ");}
      if(tpl_ReqDoc.TPRD_CompCode_IsChanged){sbParameter.Append("TPRD_CompCode=@TPRD_CompCode, ");}
      if(tpl_ReqDoc.TPRD_CompName_IsChanged){sbParameter.Append("TPRD_CompName=@TPRD_CompName, ");}
      if(tpl_ReqDoc.TPRD_Type_IsChanged){sbParameter.Append("TPRD_Type=@TPRD_Type, ");}
      if(tpl_ReqDoc.TPRD_Name_IsChanged){sbParameter.Append("TPRD_Name=@TPRD_Name, ");}
      if(tpl_ReqDoc.TPRD_IsReq_IsChanged){sbParameter.Append("TPRD_IsReq=@TPRD_IsReq, ");}
      if(tpl_ReqDoc.TPRD_Exp_IsChanged){sbParameter.Append("TPRD_Exp=@TPRD_Exp, ");}
      if(tpl_ReqDoc.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(tpl_ReqDoc.Creator_IsChanged){sbParameter.Append("Creator=@Creator, ");}
      if(tpl_ReqDoc.CreateTime_IsChanged){sbParameter.Append("CreateTime=@CreateTime, ");}
      if(tpl_ReqDoc.UpdateTime_IsChanged){sbParameter.Append("UpdateTime=@UpdateTime, ");}
      if(tpl_ReqDoc.DeleteTime_IsChanged){sbParameter.Append("DeleteTime=@DeleteTime ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and TPRD_ID=@TPRD_ID; " );
      string sql=sb.ToString();
         if(tpl_ReqDoc.TPRD_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Code))
         {
            idb.AddParameter("@TPRD_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Code", tpl_ReqDoc.TPRD_Code);
         }
          }
         if(tpl_ReqDoc.TPRD_CompCode_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_CompCode))
         {
            idb.AddParameter("@TPRD_CompCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_CompCode", tpl_ReqDoc.TPRD_CompCode);
         }
          }
         if(tpl_ReqDoc.TPRD_CompName_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_CompName))
         {
            idb.AddParameter("@TPRD_CompName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_CompName", tpl_ReqDoc.TPRD_CompName);
         }
          }
         if(tpl_ReqDoc.TPRD_Type_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Type))
         {
            idb.AddParameter("@TPRD_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Type", tpl_ReqDoc.TPRD_Type);
         }
          }
         if(tpl_ReqDoc.TPRD_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Name))
         {
            idb.AddParameter("@TPRD_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Name", tpl_ReqDoc.TPRD_Name);
         }
          }
         if(tpl_ReqDoc.TPRD_IsReq_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_IsReq))
         {
            idb.AddParameter("@TPRD_IsReq", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_IsReq", tpl_ReqDoc.TPRD_IsReq);
         }
          }
         if(tpl_ReqDoc.TPRD_Exp_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_ReqDoc.TPRD_Exp))
         {
            idb.AddParameter("@TPRD_Exp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPRD_Exp", tpl_ReqDoc.TPRD_Exp);
         }
          }
         if(tpl_ReqDoc.Stat_IsChanged)
         {
         if (tpl_ReqDoc.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", tpl_ReqDoc.Stat);
         }
          }
         if(tpl_ReqDoc.Creator_IsChanged)
         {
         if (tpl_ReqDoc.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", tpl_ReqDoc.Creator);
         }
          }
         if(tpl_ReqDoc.CreateTime_IsChanged)
         {
         if (tpl_ReqDoc.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", tpl_ReqDoc.CreateTime);
         }
          }
         if(tpl_ReqDoc.UpdateTime_IsChanged)
         {
         if (tpl_ReqDoc.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", tpl_ReqDoc.UpdateTime);
         }
          }
         if(tpl_ReqDoc.DeleteTime_IsChanged)
         {
         if (tpl_ReqDoc.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", tpl_ReqDoc.DeleteTime);
         }
          }

         idb.AddParameter("@TPRD_ID", tpl_ReqDoc.TPRD_ID);


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
      /// 删除Tpl_ReqDoc对象(即:一条记录
      /// </summary>
      public int Delete(decimal tPRD_ID)
      {
         string sql = "DELETE Tpl_ReqDoc WHERE 1=1  AND TPRD_ID=@TPRD_ID ";
         idb.AddParameter("@TPRD_ID", tPRD_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Tpl_ReqDoc对象(即:一条记录
      /// </summary>
      public Tpl_ReqDoc GetByKey(decimal tPRD_ID)
      {
         Tpl_ReqDoc tpl_ReqDoc = new Tpl_ReqDoc();
         string sql = "SELECT  TPRD_ID,TPRD_Code,TPRD_CompCode,TPRD_CompName,TPRD_Type,TPRD_Name,TPRD_IsReq,TPRD_Exp,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Tpl_ReqDoc WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND TPRD_ID=@TPRD_ID ";
         idb.AddParameter("@TPRD_ID", tPRD_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["TPRD_ID"] != DBNull.Value) tpl_ReqDoc.TPRD_ID = Convert.ToDecimal(dr["TPRD_ID"]);
            if (dr["TPRD_Code"] != DBNull.Value) tpl_ReqDoc.TPRD_Code = Convert.ToString(dr["TPRD_Code"]);
            if (dr["TPRD_CompCode"] != DBNull.Value) tpl_ReqDoc.TPRD_CompCode = Convert.ToString(dr["TPRD_CompCode"]);
            if (dr["TPRD_CompName"] != DBNull.Value) tpl_ReqDoc.TPRD_CompName = Convert.ToString(dr["TPRD_CompName"]);
            if (dr["TPRD_Type"] != DBNull.Value) tpl_ReqDoc.TPRD_Type = Convert.ToString(dr["TPRD_Type"]);
            if (dr["TPRD_Name"] != DBNull.Value) tpl_ReqDoc.TPRD_Name = Convert.ToString(dr["TPRD_Name"]);
            if (dr["TPRD_IsReq"] != DBNull.Value) tpl_ReqDoc.TPRD_IsReq = Convert.ToString(dr["TPRD_IsReq"]);
            if (dr["TPRD_Exp"] != DBNull.Value) tpl_ReqDoc.TPRD_Exp = Convert.ToString(dr["TPRD_Exp"]);
            if (dr["Stat"] != DBNull.Value) tpl_ReqDoc.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) tpl_ReqDoc.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) tpl_ReqDoc.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) tpl_ReqDoc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) tpl_ReqDoc.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return tpl_ReqDoc;
      }
      /// <summary>
      /// 获取指定的Tpl_ReqDoc对象集合
      /// </summary>
      public List<Tpl_ReqDoc> GetListByWhere(string strCondition)
      {
         List<Tpl_ReqDoc> ret = new List<Tpl_ReqDoc>();
         string sql = "SELECT  TPRD_ID,TPRD_Code,TPRD_CompCode,TPRD_CompName,TPRD_Type,TPRD_Name,TPRD_IsReq,TPRD_Exp,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Tpl_ReqDoc WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Tpl_ReqDoc tpl_ReqDoc = new Tpl_ReqDoc();
            if (dr["TPRD_ID"] != DBNull.Value) tpl_ReqDoc.TPRD_ID = Convert.ToDecimal(dr["TPRD_ID"]);
            if (dr["TPRD_Code"] != DBNull.Value) tpl_ReqDoc.TPRD_Code = Convert.ToString(dr["TPRD_Code"]);
            if (dr["TPRD_CompCode"] != DBNull.Value) tpl_ReqDoc.TPRD_CompCode = Convert.ToString(dr["TPRD_CompCode"]);
            if (dr["TPRD_CompName"] != DBNull.Value) tpl_ReqDoc.TPRD_CompName = Convert.ToString(dr["TPRD_CompName"]);
            if (dr["TPRD_Type"] != DBNull.Value) tpl_ReqDoc.TPRD_Type = Convert.ToString(dr["TPRD_Type"]);
            if (dr["TPRD_Name"] != DBNull.Value) tpl_ReqDoc.TPRD_Name = Convert.ToString(dr["TPRD_Name"]);
            if (dr["TPRD_IsReq"] != DBNull.Value) tpl_ReqDoc.TPRD_IsReq = Convert.ToString(dr["TPRD_IsReq"]);
            if (dr["TPRD_Exp"] != DBNull.Value) tpl_ReqDoc.TPRD_Exp = Convert.ToString(dr["TPRD_Exp"]);
            if (dr["Stat"] != DBNull.Value) tpl_ReqDoc.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) tpl_ReqDoc.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) tpl_ReqDoc.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) tpl_ReqDoc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) tpl_ReqDoc.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(tpl_ReqDoc);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Tpl_ReqDoc对象(即:一条记录
      /// </summary>
      public List<Tpl_ReqDoc> GetAll()
      {
         List<Tpl_ReqDoc> ret = new List<Tpl_ReqDoc>();
         string sql = "SELECT  TPRD_ID,TPRD_Code,TPRD_CompCode,TPRD_CompName,TPRD_Type,TPRD_Name,TPRD_IsReq,TPRD_Exp,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Tpl_ReqDoc where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Tpl_ReqDoc tpl_ReqDoc = new Tpl_ReqDoc();
            if (dr["TPRD_ID"] != DBNull.Value) tpl_ReqDoc.TPRD_ID = Convert.ToDecimal(dr["TPRD_ID"]);
            if (dr["TPRD_Code"] != DBNull.Value) tpl_ReqDoc.TPRD_Code = Convert.ToString(dr["TPRD_Code"]);
            if (dr["TPRD_CompCode"] != DBNull.Value) tpl_ReqDoc.TPRD_CompCode = Convert.ToString(dr["TPRD_CompCode"]);
            if (dr["TPRD_CompName"] != DBNull.Value) tpl_ReqDoc.TPRD_CompName = Convert.ToString(dr["TPRD_CompName"]);
            if (dr["TPRD_Type"] != DBNull.Value) tpl_ReqDoc.TPRD_Type = Convert.ToString(dr["TPRD_Type"]);
            if (dr["TPRD_Name"] != DBNull.Value) tpl_ReqDoc.TPRD_Name = Convert.ToString(dr["TPRD_Name"]);
            if (dr["TPRD_IsReq"] != DBNull.Value) tpl_ReqDoc.TPRD_IsReq = Convert.ToString(dr["TPRD_IsReq"]);
            if (dr["TPRD_Exp"] != DBNull.Value) tpl_ReqDoc.TPRD_Exp = Convert.ToString(dr["TPRD_Exp"]);
            if (dr["Stat"] != DBNull.Value) tpl_ReqDoc.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) tpl_ReqDoc.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) tpl_ReqDoc.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) tpl_ReqDoc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) tpl_ReqDoc.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(tpl_ReqDoc);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
