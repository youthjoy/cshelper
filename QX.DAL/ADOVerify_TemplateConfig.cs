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
   /// 审核模板配置表
   /// </summary>
   [Serializable]
   public partial class ADOVerify_TemplateConfig
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加审核模板配置表 Verify_TemplateConfig对象(即:一条记录)
      /// </summary>
      public int Add(Verify_TemplateConfig verify_TemplateConfig)
      {
         string sql = "INSERT INTO Verify_TemplateConfig (VT_Template_Code,VT_Key,VT_VerifyNode_Code,VT_VerifyNode_Name,Flag,VT_VerifyNode_Order,VT_VerifyNode_Back,VT_VerifyNode_BackName,VT_Remark,Stat,VT_AcSum,VT_AcNodeName,VT_AcNodeCode) VALUES (@VT_Template_Code,@VT_Key,@VT_VerifyNode_Code,@VT_VerifyNode_Name,@Flag,@VT_VerifyNode_Order,@VT_VerifyNode_Back,@VT_VerifyNode_BackName,@VT_Remark,@Stat,@VT_AcSum,@VT_AcNodeName,@VT_AcNodeCode)";
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_Template_Code))
         {
            idb.AddParameter("@VT_Template_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_Template_Code", verify_TemplateConfig.VT_Template_Code);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_Key))
         {
            idb.AddParameter("@VT_Key", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_Key", verify_TemplateConfig.VT_Key);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_Code))
         {
            idb.AddParameter("@VT_VerifyNode_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Code", verify_TemplateConfig.VT_VerifyNode_Code);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_Name))
         {
            idb.AddParameter("@VT_VerifyNode_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Name", verify_TemplateConfig.VT_VerifyNode_Name);
         }
         if (verify_TemplateConfig.Flag == 0)
         {
            idb.AddParameter("@Flag", 0);
         }
         else
         {
            idb.AddParameter("@Flag", verify_TemplateConfig.Flag);
         }
         if (verify_TemplateConfig.VT_VerifyNode_Order == 0)
         {
            idb.AddParameter("@VT_VerifyNode_Order", 0);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Order", verify_TemplateConfig.VT_VerifyNode_Order);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_Back))
         {
            idb.AddParameter("@VT_VerifyNode_Back", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Back", verify_TemplateConfig.VT_VerifyNode_Back);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_BackName))
         {
            idb.AddParameter("@VT_VerifyNode_BackName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_BackName", verify_TemplateConfig.VT_VerifyNode_BackName);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_Remark))
         {
            idb.AddParameter("@VT_Remark", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_Remark", verify_TemplateConfig.VT_Remark);
         }
         if (verify_TemplateConfig.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verify_TemplateConfig.Stat);
         }
         if (verify_TemplateConfig.VT_AcSum == 0)
         {
            idb.AddParameter("@VT_AcSum", 0);
         }
         else
         {
            idb.AddParameter("@VT_AcSum", verify_TemplateConfig.VT_AcSum);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_AcNodeName))
         {
            idb.AddParameter("@VT_AcNodeName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_AcNodeName", verify_TemplateConfig.VT_AcNodeName);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_AcNodeCode))
         {
            idb.AddParameter("@VT_AcNodeCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_AcNodeCode", verify_TemplateConfig.VT_AcNodeCode);
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
      /// 添加审核模板配置表 Verify_TemplateConfig对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Verify_TemplateConfig verify_TemplateConfig)
      {
         string sql = "INSERT INTO Verify_TemplateConfig (VT_Template_Code,VT_Key,VT_VerifyNode_Code,VT_VerifyNode_Name,Flag,VT_VerifyNode_Order,VT_VerifyNode_Back,VT_VerifyNode_BackName,VT_Remark,Stat,VT_AcSum,VT_AcNodeName,VT_AcNodeCode) VALUES (@VT_Template_Code,@VT_Key,@VT_VerifyNode_Code,@VT_VerifyNode_Name,@Flag,@VT_VerifyNode_Order,@VT_VerifyNode_Back,@VT_VerifyNode_BackName,@VT_Remark,@Stat,@VT_AcSum,@VT_AcNodeName,@VT_AcNodeCode);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_Template_Code))
         {
            idb.AddParameter("@VT_Template_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_Template_Code", verify_TemplateConfig.VT_Template_Code);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_Key))
         {
            idb.AddParameter("@VT_Key", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_Key", verify_TemplateConfig.VT_Key);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_Code))
         {
            idb.AddParameter("@VT_VerifyNode_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Code", verify_TemplateConfig.VT_VerifyNode_Code);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_Name))
         {
            idb.AddParameter("@VT_VerifyNode_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Name", verify_TemplateConfig.VT_VerifyNode_Name);
         }
         if (verify_TemplateConfig.Flag == 0)
         {
            idb.AddParameter("@Flag", 0);
         }
         else
         {
            idb.AddParameter("@Flag", verify_TemplateConfig.Flag);
         }
         if (verify_TemplateConfig.VT_VerifyNode_Order == 0)
         {
            idb.AddParameter("@VT_VerifyNode_Order", 0);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Order", verify_TemplateConfig.VT_VerifyNode_Order);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_Back))
         {
            idb.AddParameter("@VT_VerifyNode_Back", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Back", verify_TemplateConfig.VT_VerifyNode_Back);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_BackName))
         {
            idb.AddParameter("@VT_VerifyNode_BackName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_BackName", verify_TemplateConfig.VT_VerifyNode_BackName);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_Remark))
         {
            idb.AddParameter("@VT_Remark", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_Remark", verify_TemplateConfig.VT_Remark);
         }
         if (verify_TemplateConfig.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verify_TemplateConfig.Stat);
         }
         if (verify_TemplateConfig.VT_AcSum == 0)
         {
            idb.AddParameter("@VT_AcSum", 0);
         }
         else
         {
            idb.AddParameter("@VT_AcSum", verify_TemplateConfig.VT_AcSum);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_AcNodeName))
         {
            idb.AddParameter("@VT_AcNodeName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_AcNodeName", verify_TemplateConfig.VT_AcNodeName);
         }
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_AcNodeCode))
         {
            idb.AddParameter("@VT_AcNodeCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_AcNodeCode", verify_TemplateConfig.VT_AcNodeCode);
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
      /// 更新审核模板配置表 Verify_TemplateConfig对象(即:一条记录
      /// </summary>
      public int Update(Verify_TemplateConfig verify_TemplateConfig)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Verify_TemplateConfig       SET ");
            if(verify_TemplateConfig.VT_Template_Code_IsChanged){sbParameter.Append("VT_Template_Code=@VT_Template_Code, ");}
      if(verify_TemplateConfig.VT_Key_IsChanged){sbParameter.Append("VT_Key=@VT_Key, ");}
      if(verify_TemplateConfig.VT_VerifyNode_Code_IsChanged){sbParameter.Append("VT_VerifyNode_Code=@VT_VerifyNode_Code, ");}
      if(verify_TemplateConfig.VT_VerifyNode_Name_IsChanged){sbParameter.Append("VT_VerifyNode_Name=@VT_VerifyNode_Name, ");}
      if(verify_TemplateConfig.Flag_IsChanged){sbParameter.Append("Flag=@Flag, ");}
      if(verify_TemplateConfig.VT_VerifyNode_Order_IsChanged){sbParameter.Append("VT_VerifyNode_Order=@VT_VerifyNode_Order, ");}
      if(verify_TemplateConfig.VT_VerifyNode_Back_IsChanged){sbParameter.Append("VT_VerifyNode_Back=@VT_VerifyNode_Back, ");}
      if(verify_TemplateConfig.VT_VerifyNode_BackName_IsChanged){sbParameter.Append("VT_VerifyNode_BackName=@VT_VerifyNode_BackName, ");}
      if(verify_TemplateConfig.VT_Remark_IsChanged){sbParameter.Append("VT_Remark=@VT_Remark, ");}
      if(verify_TemplateConfig.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(verify_TemplateConfig.VT_AcSum_IsChanged){sbParameter.Append("VT_AcSum=@VT_AcSum, ");}
      if(verify_TemplateConfig.VT_AcNodeName_IsChanged){sbParameter.Append("VT_AcNodeName=@VT_AcNodeName, ");}
      if(verify_TemplateConfig.VT_AcNodeCode_IsChanged){sbParameter.Append("VT_AcNodeCode=@VT_AcNodeCode ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and VT_ID=@VT_ID; " );
      string sql=sb.ToString();
         if(verify_TemplateConfig.VT_Template_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_Template_Code))
         {
            idb.AddParameter("@VT_Template_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_Template_Code", verify_TemplateConfig.VT_Template_Code);
         }
          }
         if(verify_TemplateConfig.VT_Key_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_Key))
         {
            idb.AddParameter("@VT_Key", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_Key", verify_TemplateConfig.VT_Key);
         }
          }
         if(verify_TemplateConfig.VT_VerifyNode_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_Code))
         {
            idb.AddParameter("@VT_VerifyNode_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Code", verify_TemplateConfig.VT_VerifyNode_Code);
         }
          }
         if(verify_TemplateConfig.VT_VerifyNode_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_Name))
         {
            idb.AddParameter("@VT_VerifyNode_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Name", verify_TemplateConfig.VT_VerifyNode_Name);
         }
          }
         if(verify_TemplateConfig.Flag_IsChanged)
         {
         if (verify_TemplateConfig.Flag == 0)
         {
            idb.AddParameter("@Flag", 0);
         }
         else
         {
            idb.AddParameter("@Flag", verify_TemplateConfig.Flag);
         }
          }
         if(verify_TemplateConfig.VT_VerifyNode_Order_IsChanged)
         {
         if (verify_TemplateConfig.VT_VerifyNode_Order == 0)
         {
            idb.AddParameter("@VT_VerifyNode_Order", 0);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Order", verify_TemplateConfig.VT_VerifyNode_Order);
         }
          }
         if(verify_TemplateConfig.VT_VerifyNode_Back_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_Back))
         {
            idb.AddParameter("@VT_VerifyNode_Back", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_Back", verify_TemplateConfig.VT_VerifyNode_Back);
         }
          }
         if(verify_TemplateConfig.VT_VerifyNode_BackName_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_VerifyNode_BackName))
         {
            idb.AddParameter("@VT_VerifyNode_BackName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_VerifyNode_BackName", verify_TemplateConfig.VT_VerifyNode_BackName);
         }
          }
         if(verify_TemplateConfig.VT_Remark_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_Remark))
         {
            idb.AddParameter("@VT_Remark", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_Remark", verify_TemplateConfig.VT_Remark);
         }
          }
         if(verify_TemplateConfig.Stat_IsChanged)
         {
         if (verify_TemplateConfig.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", verify_TemplateConfig.Stat);
         }
          }
         if(verify_TemplateConfig.VT_AcSum_IsChanged)
         {
         if (verify_TemplateConfig.VT_AcSum == 0)
         {
            idb.AddParameter("@VT_AcSum", 0);
         }
         else
         {
            idb.AddParameter("@VT_AcSum", verify_TemplateConfig.VT_AcSum);
         }
          }
         if(verify_TemplateConfig.VT_AcNodeName_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_AcNodeName))
         {
            idb.AddParameter("@VT_AcNodeName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_AcNodeName", verify_TemplateConfig.VT_AcNodeName);
         }
          }
         if(verify_TemplateConfig.VT_AcNodeCode_IsChanged)
         {
         if (string.IsNullOrEmpty(verify_TemplateConfig.VT_AcNodeCode))
         {
            idb.AddParameter("@VT_AcNodeCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@VT_AcNodeCode", verify_TemplateConfig.VT_AcNodeCode);
         }
          }

         idb.AddParameter("@VT_ID", verify_TemplateConfig.VT_ID);


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
      /// 删除审核模板配置表 Verify_TemplateConfig对象(即:一条记录
      /// </summary>
      public int Delete(decimal vT_ID)
      {
         string sql = "DELETE Verify_TemplateConfig WHERE 1=1  AND VT_ID=@VT_ID ";
         idb.AddParameter("@VT_ID", vT_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的审核模板配置表 Verify_TemplateConfig对象(即:一条记录
      /// </summary>
      public Verify_TemplateConfig GetByKey(decimal vT_ID)
      {
         Verify_TemplateConfig verify_TemplateConfig = new Verify_TemplateConfig();
         string sql = "SELECT  VT_ID,VT_Template_Code,VT_Key,VT_VerifyNode_Code,VT_VerifyNode_Name,Flag,VT_VerifyNode_Order,VT_VerifyNode_Back,VT_VerifyNode_BackName,VT_Remark,Stat,VT_AcSum,VT_AcNodeName,VT_AcNodeCode FROM Verify_TemplateConfig WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND VT_ID=@VT_ID ";
         idb.AddParameter("@VT_ID", vT_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["VT_ID"] != DBNull.Value) verify_TemplateConfig.VT_ID = Convert.ToDecimal(dr["VT_ID"]);
            if (dr["VT_Template_Code"] != DBNull.Value) verify_TemplateConfig.VT_Template_Code = Convert.ToString(dr["VT_Template_Code"]);
            if (dr["VT_Key"] != DBNull.Value) verify_TemplateConfig.VT_Key = Convert.ToString(dr["VT_Key"]);
            if (dr["VT_VerifyNode_Code"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Code = Convert.ToString(dr["VT_VerifyNode_Code"]);
            if (dr["VT_VerifyNode_Name"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Name = Convert.ToString(dr["VT_VerifyNode_Name"]);
            if (dr["Flag"] != DBNull.Value) verify_TemplateConfig.Flag = Convert.ToInt32(dr["Flag"]);
            if (dr["VT_VerifyNode_Order"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Order = Convert.ToInt32(dr["VT_VerifyNode_Order"]);
            if (dr["VT_VerifyNode_Back"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Back = Convert.ToString(dr["VT_VerifyNode_Back"]);
            if (dr["VT_VerifyNode_BackName"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_BackName = Convert.ToString(dr["VT_VerifyNode_BackName"]);
            if (dr["VT_Remark"] != DBNull.Value) verify_TemplateConfig.VT_Remark = Convert.ToString(dr["VT_Remark"]);
            if (dr["Stat"] != DBNull.Value) verify_TemplateConfig.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["VT_AcSum"] != DBNull.Value) verify_TemplateConfig.VT_AcSum = Convert.ToDecimal(dr["VT_AcSum"]);
            if (dr["VT_AcNodeName"] != DBNull.Value) verify_TemplateConfig.VT_AcNodeName = Convert.ToString(dr["VT_AcNodeName"]);
            if (dr["VT_AcNodeCode"] != DBNull.Value) verify_TemplateConfig.VT_AcNodeCode = Convert.ToString(dr["VT_AcNodeCode"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return verify_TemplateConfig;
      }
      /// <summary>
      /// 获取指定的审核模板配置表 Verify_TemplateConfig对象集合
      /// </summary>
      public List<Verify_TemplateConfig> GetListByWhere(string strCondition)
      {
         List<Verify_TemplateConfig> ret = new List<Verify_TemplateConfig>();
         string sql = "SELECT  VT_ID,VT_Template_Code,VT_Key,VT_VerifyNode_Code,VT_VerifyNode_Name,Flag,VT_VerifyNode_Order,VT_VerifyNode_Back,VT_VerifyNode_BackName,VT_Remark,Stat,VT_AcSum,VT_AcNodeName,VT_AcNodeCode FROM Verify_TemplateConfig WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Verify_TemplateConfig verify_TemplateConfig = new Verify_TemplateConfig();
            if (dr["VT_ID"] != DBNull.Value) verify_TemplateConfig.VT_ID = Convert.ToDecimal(dr["VT_ID"]);
            if (dr["VT_Template_Code"] != DBNull.Value) verify_TemplateConfig.VT_Template_Code = Convert.ToString(dr["VT_Template_Code"]);
            if (dr["VT_Key"] != DBNull.Value) verify_TemplateConfig.VT_Key = Convert.ToString(dr["VT_Key"]);
            if (dr["VT_VerifyNode_Code"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Code = Convert.ToString(dr["VT_VerifyNode_Code"]);
            if (dr["VT_VerifyNode_Name"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Name = Convert.ToString(dr["VT_VerifyNode_Name"]);
            if (dr["Flag"] != DBNull.Value) verify_TemplateConfig.Flag = Convert.ToInt32(dr["Flag"]);
            if (dr["VT_VerifyNode_Order"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Order = Convert.ToInt32(dr["VT_VerifyNode_Order"]);
            if (dr["VT_VerifyNode_Back"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Back = Convert.ToString(dr["VT_VerifyNode_Back"]);
            if (dr["VT_VerifyNode_BackName"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_BackName = Convert.ToString(dr["VT_VerifyNode_BackName"]);
            if (dr["VT_Remark"] != DBNull.Value) verify_TemplateConfig.VT_Remark = Convert.ToString(dr["VT_Remark"]);
            if (dr["Stat"] != DBNull.Value) verify_TemplateConfig.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["VT_AcSum"] != DBNull.Value) verify_TemplateConfig.VT_AcSum = Convert.ToDecimal(dr["VT_AcSum"]);
            if (dr["VT_AcNodeName"] != DBNull.Value) verify_TemplateConfig.VT_AcNodeName = Convert.ToString(dr["VT_AcNodeName"]);
            if (dr["VT_AcNodeCode"] != DBNull.Value) verify_TemplateConfig.VT_AcNodeCode = Convert.ToString(dr["VT_AcNodeCode"]);
            ret.Add(verify_TemplateConfig);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的审核模板配置表 Verify_TemplateConfig对象(即:一条记录
      /// </summary>
      public List<Verify_TemplateConfig> GetAll()
      {
         List<Verify_TemplateConfig> ret = new List<Verify_TemplateConfig>();
         string sql = "SELECT  VT_ID,VT_Template_Code,VT_Key,VT_VerifyNode_Code,VT_VerifyNode_Name,Flag,VT_VerifyNode_Order,VT_VerifyNode_Back,VT_VerifyNode_BackName,VT_Remark,Stat,VT_AcSum,VT_AcNodeName,VT_AcNodeCode FROM Verify_TemplateConfig where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Verify_TemplateConfig verify_TemplateConfig = new Verify_TemplateConfig();
            if (dr["VT_ID"] != DBNull.Value) verify_TemplateConfig.VT_ID = Convert.ToDecimal(dr["VT_ID"]);
            if (dr["VT_Template_Code"] != DBNull.Value) verify_TemplateConfig.VT_Template_Code = Convert.ToString(dr["VT_Template_Code"]);
            if (dr["VT_Key"] != DBNull.Value) verify_TemplateConfig.VT_Key = Convert.ToString(dr["VT_Key"]);
            if (dr["VT_VerifyNode_Code"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Code = Convert.ToString(dr["VT_VerifyNode_Code"]);
            if (dr["VT_VerifyNode_Name"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Name = Convert.ToString(dr["VT_VerifyNode_Name"]);
            if (dr["Flag"] != DBNull.Value) verify_TemplateConfig.Flag = Convert.ToInt32(dr["Flag"]);
            if (dr["VT_VerifyNode_Order"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Order = Convert.ToInt32(dr["VT_VerifyNode_Order"]);
            if (dr["VT_VerifyNode_Back"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_Back = Convert.ToString(dr["VT_VerifyNode_Back"]);
            if (dr["VT_VerifyNode_BackName"] != DBNull.Value) verify_TemplateConfig.VT_VerifyNode_BackName = Convert.ToString(dr["VT_VerifyNode_BackName"]);
            if (dr["VT_Remark"] != DBNull.Value) verify_TemplateConfig.VT_Remark = Convert.ToString(dr["VT_Remark"]);
            if (dr["Stat"] != DBNull.Value) verify_TemplateConfig.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["VT_AcSum"] != DBNull.Value) verify_TemplateConfig.VT_AcSum = Convert.ToDecimal(dr["VT_AcSum"]);
            if (dr["VT_AcNodeName"] != DBNull.Value) verify_TemplateConfig.VT_AcNodeName = Convert.ToString(dr["VT_AcNodeName"]);
            if (dr["VT_AcNodeCode"] != DBNull.Value) verify_TemplateConfig.VT_AcNodeCode = Convert.ToString(dr["VT_AcNodeCode"]);
            ret.Add(verify_TemplateConfig);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
