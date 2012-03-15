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
   /// 审核阶段用户
   /// </summary>
   [Serializable]
   public partial class ADOVerify_Users
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加审核阶段用户 Verify_Users对象(即:一条记录)
      /// </summary>
      public int Add(Verify_Users verify_Users)
      {
         string sql = "INSERT INTO Verify_Users (VU_VerifyNode_Code,VU_User,VU_UserName,VU_Dept,VU_DeptName,VU_Duty,VU_VerifyTempldate_Code,Stat) VALUES (@VU_VerifyNode_Code,@VU_User,@VU_UserName,@VU_Dept,@VU_DeptName,@VU_Duty,@VU_VerifyTempldate_Code,@Stat)";
         if (string.IsNullOrEmpty(verify_Users.VU_VerifyNode_Code))
         {
            idb.AddParameter("@VU_VerifyNode_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_VerifyNode_Code", verify_Users.VU_VerifyNode_Code);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_User))
         {
            idb.AddParameter("@VU_User", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_User", verify_Users.VU_User);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_UserName))
         {
            idb.AddParameter("@VU_UserName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_UserName", verify_Users.VU_UserName);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_Dept))
         {
            idb.AddParameter("@VU_Dept", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_Dept", verify_Users.VU_Dept);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_DeptName))
         {
            idb.AddParameter("@VU_DeptName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_DeptName", verify_Users.VU_DeptName);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_Duty))
         {
            idb.AddParameter("@VU_Duty", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_Duty", verify_Users.VU_Duty);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_VerifyTempldate_Code))
         {
            idb.AddParameter("@VU_VerifyTempldate_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_VerifyTempldate_Code", verify_Users.VU_VerifyTempldate_Code);
         }
         if (verify_Users.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verify_Users.Stat);
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
      /// 添加审核阶段用户 Verify_Users对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Verify_Users verify_Users)
      {
         string sql = "INSERT INTO Verify_Users (VU_VerifyNode_Code,VU_User,VU_UserName,VU_Dept,VU_DeptName,VU_Duty,VU_VerifyTempldate_Code,Stat) VALUES (@VU_VerifyNode_Code,@VU_User,@VU_UserName,@VU_Dept,@VU_DeptName,@VU_Duty,@VU_VerifyTempldate_Code,@Stat);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(verify_Users.VU_VerifyNode_Code))
         {
            idb.AddParameter("@VU_VerifyNode_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_VerifyNode_Code", verify_Users.VU_VerifyNode_Code);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_User))
         {
            idb.AddParameter("@VU_User", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_User", verify_Users.VU_User);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_UserName))
         {
            idb.AddParameter("@VU_UserName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_UserName", verify_Users.VU_UserName);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_Dept))
         {
            idb.AddParameter("@VU_Dept", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_Dept", verify_Users.VU_Dept);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_DeptName))
         {
            idb.AddParameter("@VU_DeptName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_DeptName", verify_Users.VU_DeptName);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_Duty))
         {
            idb.AddParameter("@VU_Duty", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_Duty", verify_Users.VU_Duty);
         }
         if (string.IsNullOrEmpty(verify_Users.VU_VerifyTempldate_Code))
         {
            idb.AddParameter("@VU_VerifyTempldate_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_VerifyTempldate_Code", verify_Users.VU_VerifyTempldate_Code);
         }
         if (verify_Users.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verify_Users.Stat);
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
      /// 更新审核阶段用户 Verify_Users对象(即:一条记录
      /// </summary>
      public int Update(Verify_Users verify_Users)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Verify_Users       SET ");
            if(verify_Users.VU_VerifyNode_Code_IsChanged){sbParameter.Append("VU_VerifyNode_Code=@VU_VerifyNode_Code, ");}
      if(verify_Users.VU_User_IsChanged){sbParameter.Append("VU_User=@VU_User, ");}
      if(verify_Users.VU_UserName_IsChanged){sbParameter.Append("VU_UserName=@VU_UserName, ");}
      if(verify_Users.VU_Dept_IsChanged){sbParameter.Append("VU_Dept=@VU_Dept, ");}
      if(verify_Users.VU_DeptName_IsChanged){sbParameter.Append("VU_DeptName=@VU_DeptName, ");}
      if(verify_Users.VU_Duty_IsChanged){sbParameter.Append("VU_Duty=@VU_Duty, ");}
      if(verify_Users.VU_VerifyTempldate_Code_IsChanged){sbParameter.Append("VU_VerifyTempldate_Code=@VU_VerifyTempldate_Code, ");}
      if(verify_Users.Stat_IsChanged){sbParameter.Append("Stat=@Stat ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and VU_ID=@VU_ID; " );
      string sql=sb.ToString();
         if(verify_Users.VU_VerifyNode_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Users.VU_VerifyNode_Code))
         {
            idb.AddParameter("@VU_VerifyNode_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_VerifyNode_Code", verify_Users.VU_VerifyNode_Code);
         }
          }
         if(verify_Users.VU_User_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Users.VU_User))
         {
            idb.AddParameter("@VU_User", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_User", verify_Users.VU_User);
         }
          }
         if(verify_Users.VU_UserName_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Users.VU_UserName))
         {
            idb.AddParameter("@VU_UserName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_UserName", verify_Users.VU_UserName);
         }
          }
         if(verify_Users.VU_Dept_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Users.VU_Dept))
         {
            idb.AddParameter("@VU_Dept", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_Dept", verify_Users.VU_Dept);
         }
          }
         if(verify_Users.VU_DeptName_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Users.VU_DeptName))
         {
            idb.AddParameter("@VU_DeptName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_DeptName", verify_Users.VU_DeptName);
         }
          }
         if(verify_Users.VU_Duty_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Users.VU_Duty))
         {
            idb.AddParameter("@VU_Duty", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_Duty", verify_Users.VU_Duty);
         }
          }
         if(verify_Users.VU_VerifyTempldate_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_Users.VU_VerifyTempldate_Code))
         {
            idb.AddParameter("@VU_VerifyTempldate_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VU_VerifyTempldate_Code", verify_Users.VU_VerifyTempldate_Code);
         }
          }
         if(verify_Users.Stat_IsChanged)
         {
         if (verify_Users.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verify_Users.Stat);
         }
          }

         idb.AddParameter("@VU_ID", verify_Users.VU_ID);


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
      /// 删除审核阶段用户 Verify_Users对象(即:一条记录
      /// </summary>
      public int Delete(decimal vU_ID)
      {
         string sql = "DELETE Verify_Users WHERE 1=1  AND VU_ID=@VU_ID ";
         idb.AddParameter("@VU_ID", vU_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的审核阶段用户 Verify_Users对象(即:一条记录
      /// </summary>
      public Verify_Users GetByKey(decimal vU_ID)
      {
         Verify_Users verify_Users = new Verify_Users();
         string sql = "SELECT  VU_ID,VU_VerifyNode_Code,VU_User,VU_UserName,VU_Dept,VU_DeptName,VU_Duty,VU_VerifyTempldate_Code,Stat FROM Verify_Users WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND VU_ID=@VU_ID ";
         idb.AddParameter("@VU_ID", vU_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["VU_ID"] != DBNull.Value) verify_Users.VU_ID = Convert.ToDecimal(dr["VU_ID"]);
            if (dr["VU_VerifyNode_Code"] != DBNull.Value) verify_Users.VU_VerifyNode_Code = Convert.ToString(dr["VU_VerifyNode_Code"]);
            if (dr["VU_User"] != DBNull.Value) verify_Users.VU_User = Convert.ToString(dr["VU_User"]);
            if (dr["VU_UserName"] != DBNull.Value) verify_Users.VU_UserName = Convert.ToString(dr["VU_UserName"]);
            if (dr["VU_Dept"] != DBNull.Value) verify_Users.VU_Dept = Convert.ToString(dr["VU_Dept"]);
            if (dr["VU_DeptName"] != DBNull.Value) verify_Users.VU_DeptName = Convert.ToString(dr["VU_DeptName"]);
            if (dr["VU_Duty"] != DBNull.Value) verify_Users.VU_Duty = Convert.ToString(dr["VU_Duty"]);
            if (dr["VU_VerifyTempldate_Code"] != DBNull.Value) verify_Users.VU_VerifyTempldate_Code = Convert.ToString(dr["VU_VerifyTempldate_Code"]);
            if (dr["Stat"] != DBNull.Value) verify_Users.Stat = Convert.ToInt32(dr["Stat"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return verify_Users;
      }
      /// <summary>
      /// 获取指定的审核阶段用户 Verify_Users对象集合
      /// </summary>
      public List<Verify_Users> GetListByWhere(string strCondition)
      {
         List<Verify_Users> ret = new List<Verify_Users>();
         string sql = "SELECT  VU_ID,VU_VerifyNode_Code,VU_User,VU_UserName,VU_Dept,VU_DeptName,VU_Duty,VU_VerifyTempldate_Code,Stat FROM Verify_Users WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Verify_Users verify_Users = new Verify_Users();
            if (dr["VU_ID"] != DBNull.Value) verify_Users.VU_ID = Convert.ToDecimal(dr["VU_ID"]);
            if (dr["VU_VerifyNode_Code"] != DBNull.Value) verify_Users.VU_VerifyNode_Code = Convert.ToString(dr["VU_VerifyNode_Code"]);
            if (dr["VU_User"] != DBNull.Value) verify_Users.VU_User = Convert.ToString(dr["VU_User"]);
            if (dr["VU_UserName"] != DBNull.Value) verify_Users.VU_UserName = Convert.ToString(dr["VU_UserName"]);
            if (dr["VU_Dept"] != DBNull.Value) verify_Users.VU_Dept = Convert.ToString(dr["VU_Dept"]);
            if (dr["VU_DeptName"] != DBNull.Value) verify_Users.VU_DeptName = Convert.ToString(dr["VU_DeptName"]);
            if (dr["VU_Duty"] != DBNull.Value) verify_Users.VU_Duty = Convert.ToString(dr["VU_Duty"]);
            if (dr["VU_VerifyTempldate_Code"] != DBNull.Value) verify_Users.VU_VerifyTempldate_Code = Convert.ToString(dr["VU_VerifyTempldate_Code"]);
            if (dr["Stat"] != DBNull.Value) verify_Users.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(verify_Users);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的审核阶段用户 Verify_Users对象(即:一条记录
      /// </summary>
      public List<Verify_Users> GetAll()
      {
         List<Verify_Users> ret = new List<Verify_Users>();
         string sql = "SELECT  VU_ID,VU_VerifyNode_Code,VU_User,VU_UserName,VU_Dept,VU_DeptName,VU_Duty,VU_VerifyTempldate_Code,Stat FROM Verify_Users where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Verify_Users verify_Users = new Verify_Users();
            if (dr["VU_ID"] != DBNull.Value) verify_Users.VU_ID = Convert.ToDecimal(dr["VU_ID"]);
            if (dr["VU_VerifyNode_Code"] != DBNull.Value) verify_Users.VU_VerifyNode_Code = Convert.ToString(dr["VU_VerifyNode_Code"]);
            if (dr["VU_User"] != DBNull.Value) verify_Users.VU_User = Convert.ToString(dr["VU_User"]);
            if (dr["VU_UserName"] != DBNull.Value) verify_Users.VU_UserName = Convert.ToString(dr["VU_UserName"]);
            if (dr["VU_Dept"] != DBNull.Value) verify_Users.VU_Dept = Convert.ToString(dr["VU_Dept"]);
            if (dr["VU_DeptName"] != DBNull.Value) verify_Users.VU_DeptName = Convert.ToString(dr["VU_DeptName"]);
            if (dr["VU_Duty"] != DBNull.Value) verify_Users.VU_Duty = Convert.ToString(dr["VU_Duty"]);
            if (dr["VU_VerifyTempldate_Code"] != DBNull.Value) verify_Users.VU_VerifyTempldate_Code = Convert.ToString(dr["VU_VerifyTempldate_Code"]);
            if (dr["Stat"] != DBNull.Value) verify_Users.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(verify_Users);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
