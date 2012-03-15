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
   /// 审核阶段信息
   /// </summary>
   [Serializable]
   public partial class ADOVerify_Nodes
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加审核阶段信息 Verify_Nodes对象(即:一条记录)
      /// </summary>
      public int Add(Verify_Nodes verify_Nodes)
      {
         string sql = "INSERT INTO Verify_Nodes (VerifyNode_Code,VerifyNode_Name,VerifyNode_Remark,VerifyNode_AuditNum,Stat) VALUES (@VerifyNode_Code,@VerifyNode_Name,@VerifyNode_Remark,@VerifyNode_AuditNum,@Stat)";
         if (string.IsNullOrEmpty(verify_Nodes.VerifyNode_Code))
         {
            idb.AddParameter("@VerifyNode_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VerifyNode_Code", verify_Nodes.VerifyNode_Code);
         }
         if (string.IsNullOrEmpty(verify_Nodes.VerifyNode_Name))
         {
            idb.AddParameter("@VerifyNode_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VerifyNode_Name", verify_Nodes.VerifyNode_Name);
         }
         if (string.IsNullOrEmpty(verify_Nodes.VerifyNode_Remark))
         {
            idb.AddParameter("@VerifyNode_Remark", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VerifyNode_Remark", verify_Nodes.VerifyNode_Remark);
         }
         if (verify_Nodes.VerifyNode_AuditNum == 0)
         {
            idb.AddParameter("@VerifyNode_AuditNum", 0);
         }
         else
         {
            idb.AddParameter("@VerifyNode_AuditNum", verify_Nodes.VerifyNode_AuditNum);
         }
         if (verify_Nodes.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verify_Nodes.Stat);
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
      /// 添加审核阶段信息 Verify_Nodes对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Verify_Nodes verify_Nodes)
      {
         string sql = "INSERT INTO Verify_Nodes (VerifyNode_Code,VerifyNode_Name,VerifyNode_Remark,VerifyNode_AuditNum,Stat) VALUES (@VerifyNode_Code,@VerifyNode_Name,@VerifyNode_Remark,@VerifyNode_AuditNum,@Stat);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(verify_Nodes.VerifyNode_Code))
         {
            idb.AddParameter("@VerifyNode_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VerifyNode_Code", verify_Nodes.VerifyNode_Code);
         }
         if (string.IsNullOrEmpty(verify_Nodes.VerifyNode_Name))
         {
            idb.AddParameter("@VerifyNode_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VerifyNode_Name", verify_Nodes.VerifyNode_Name);
         }
         if (string.IsNullOrEmpty(verify_Nodes.VerifyNode_Remark))
         {
            idb.AddParameter("@VerifyNode_Remark", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VerifyNode_Remark", verify_Nodes.VerifyNode_Remark);
         }
         if (verify_Nodes.VerifyNode_AuditNum == 0)
         {
            idb.AddParameter("@VerifyNode_AuditNum", 0);
         }
         else
         {
            idb.AddParameter("@VerifyNode_AuditNum", verify_Nodes.VerifyNode_AuditNum);
         }
         if (verify_Nodes.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verify_Nodes.Stat);
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
      /// 更新审核阶段信息 Verify_Nodes对象(即:一条记录
      /// </summary>
      public int Update(Verify_Nodes verify_Nodes)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Verify_Nodes       SET ");
            if(verify_Nodes.VerifyNode_Code_IsChanged){sbParameter.Append("VerifyNode_Code=@VerifyNode_Code, ");}
      if(verify_Nodes.VerifyNode_Name_IsChanged){sbParameter.Append("VerifyNode_Name=@VerifyNode_Name, ");}
      if(verify_Nodes.VerifyNode_Remark_IsChanged){sbParameter.Append("VerifyNode_Remark=@VerifyNode_Remark, ");}
      if(verify_Nodes.VerifyNode_AuditNum_IsChanged){sbParameter.Append("VerifyNode_AuditNum=@VerifyNode_AuditNum, ");}
      if(verify_Nodes.Stat_IsChanged){sbParameter.Append("Stat=@Stat ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and VerifyNode_ID=@VerifyNode_ID; " );
      string sql=sb.ToString();
         if(verify_Nodes.VerifyNode_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Nodes.VerifyNode_Code))
         {
            idb.AddParameter("@VerifyNode_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VerifyNode_Code", verify_Nodes.VerifyNode_Code);
         }
          }
         if(verify_Nodes.VerifyNode_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Nodes.VerifyNode_Name))
         {
            idb.AddParameter("@VerifyNode_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VerifyNode_Name", verify_Nodes.VerifyNode_Name);
         }
          }
         if(verify_Nodes.VerifyNode_Remark_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Nodes.VerifyNode_Remark))
         {
            idb.AddParameter("@VerifyNode_Remark", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VerifyNode_Remark", verify_Nodes.VerifyNode_Remark);
         }
          }
         if(verify_Nodes.VerifyNode_AuditNum_IsChanged)
         {
         if (verify_Nodes.VerifyNode_AuditNum == 0)
         {
            idb.AddParameter("@VerifyNode_AuditNum", 0);
         }
         else
         {
            idb.AddParameter("@VerifyNode_AuditNum", verify_Nodes.VerifyNode_AuditNum);
         }
          }
         if(verify_Nodes.Stat_IsChanged)
         {
         if (verify_Nodes.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verify_Nodes.Stat);
         }
          }

         idb.AddParameter("@VerifyNode_ID", verify_Nodes.VerifyNode_ID);


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
      /// 删除审核阶段信息 Verify_Nodes对象(即:一条记录
      /// </summary>
      public int Delete(decimal verifyNode_ID)
      {
         string sql = "DELETE Verify_Nodes WHERE 1=1  AND VerifyNode_ID=@VerifyNode_ID ";
         idb.AddParameter("@VerifyNode_ID", verifyNode_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的审核阶段信息 Verify_Nodes对象(即:一条记录
      /// </summary>
      public Verify_Nodes GetByKey(decimal verifyNode_ID)
      {
         Verify_Nodes verify_Nodes = new Verify_Nodes();
         string sql = "SELECT  VerifyNode_ID,VerifyNode_Code,VerifyNode_Name,VerifyNode_Remark,VerifyNode_AuditNum,Stat FROM Verify_Nodes WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND VerifyNode_ID=@VerifyNode_ID ";
         idb.AddParameter("@VerifyNode_ID", verifyNode_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["VerifyNode_ID"] != DBNull.Value) verify_Nodes.VerifyNode_ID = Convert.ToDecimal(dr["VerifyNode_ID"]);
            if (dr["VerifyNode_Code"] != DBNull.Value) verify_Nodes.VerifyNode_Code = Convert.ToString(dr["VerifyNode_Code"]);
            if (dr["VerifyNode_Name"] != DBNull.Value) verify_Nodes.VerifyNode_Name = Convert.ToString(dr["VerifyNode_Name"]);
            if (dr["VerifyNode_Remark"] != DBNull.Value) verify_Nodes.VerifyNode_Remark = Convert.ToString(dr["VerifyNode_Remark"]);
            if (dr["VerifyNode_AuditNum"] != DBNull.Value) verify_Nodes.VerifyNode_AuditNum = Convert.ToInt32(dr["VerifyNode_AuditNum"]);
            if (dr["Stat"] != DBNull.Value) verify_Nodes.Stat = Convert.ToInt32(dr["Stat"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return verify_Nodes;
      }
      /// <summary>
      /// 获取指定的审核阶段信息 Verify_Nodes对象集合
      /// </summary>
      public List<Verify_Nodes> GetListByWhere(string strCondition)
      {
         List<Verify_Nodes> ret = new List<Verify_Nodes>();
         string sql = "SELECT  VerifyNode_ID,VerifyNode_Code,VerifyNode_Name,VerifyNode_Remark,VerifyNode_AuditNum,Stat FROM Verify_Nodes WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Verify_Nodes verify_Nodes = new Verify_Nodes();
            if (dr["VerifyNode_ID"] != DBNull.Value) verify_Nodes.VerifyNode_ID = Convert.ToDecimal(dr["VerifyNode_ID"]);
            if (dr["VerifyNode_Code"] != DBNull.Value) verify_Nodes.VerifyNode_Code = Convert.ToString(dr["VerifyNode_Code"]);
            if (dr["VerifyNode_Name"] != DBNull.Value) verify_Nodes.VerifyNode_Name = Convert.ToString(dr["VerifyNode_Name"]);
            if (dr["VerifyNode_Remark"] != DBNull.Value) verify_Nodes.VerifyNode_Remark = Convert.ToString(dr["VerifyNode_Remark"]);
            if (dr["VerifyNode_AuditNum"] != DBNull.Value) verify_Nodes.VerifyNode_AuditNum = Convert.ToInt32(dr["VerifyNode_AuditNum"]);
            if (dr["Stat"] != DBNull.Value) verify_Nodes.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(verify_Nodes);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的审核阶段信息 Verify_Nodes对象(即:一条记录
      /// </summary>
      public List<Verify_Nodes> GetAll()
      {
         List<Verify_Nodes> ret = new List<Verify_Nodes>();
         string sql = "SELECT  VerifyNode_ID,VerifyNode_Code,VerifyNode_Name,VerifyNode_Remark,VerifyNode_AuditNum,Stat FROM Verify_Nodes where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Verify_Nodes verify_Nodes = new Verify_Nodes();
            if (dr["VerifyNode_ID"] != DBNull.Value) verify_Nodes.VerifyNode_ID = Convert.ToDecimal(dr["VerifyNode_ID"]);
            if (dr["VerifyNode_Code"] != DBNull.Value) verify_Nodes.VerifyNode_Code = Convert.ToString(dr["VerifyNode_Code"]);
            if (dr["VerifyNode_Name"] != DBNull.Value) verify_Nodes.VerifyNode_Name = Convert.ToString(dr["VerifyNode_Name"]);
            if (dr["VerifyNode_Remark"] != DBNull.Value) verify_Nodes.VerifyNode_Remark = Convert.ToString(dr["VerifyNode_Remark"]);
            if (dr["VerifyNode_AuditNum"] != DBNull.Value) verify_Nodes.VerifyNode_AuditNum = Convert.ToInt32(dr["VerifyNode_AuditNum"]);
            if (dr["Stat"] != DBNull.Value) verify_Nodes.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(verify_Nodes);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
