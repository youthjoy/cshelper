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
   /// 零件基本信息
   /// </summary>
   [Serializable]
   public partial class ADOProd_Components
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加零件基本信息 Prod_Components对象(即:一条记录)
      /// </summary>
      public int Add(Prod_Components prod_Components)
      {
         string sql = "INSERT INTO Prod_Components (PRDC_CompNo,PRDC_CompCode,PRDC_CompName,PRDC_Raw,PRDC_Supp,PRDC_RecDate,PRDC_FinishDate,PRDC_SampleDate,PRDC_VerifyResult,PRDC_iType,PRDC_Tec1,PRDC_Tec2,PRDC_Tec3,PRDC_Tec4,PRDC_Tec5,PRDC_Tec6,PRDC_Tec7,PRDC_Tec8,PRDC_Tec9,PRDC_Tec10,PRDC_ProdCode,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@PRDC_CompNo,@PRDC_CompCode,@PRDC_CompName,@PRDC_Raw,@PRDC_Supp,@PRDC_RecDate,@PRDC_FinishDate,@PRDC_SampleDate,@PRDC_VerifyResult,@PRDC_iType,@PRDC_Tec1,@PRDC_Tec2,@PRDC_Tec3,@PRDC_Tec4,@PRDC_Tec5,@PRDC_Tec6,@PRDC_Tec7,@PRDC_Tec8,@PRDC_Tec9,@PRDC_Tec10,@PRDC_ProdCode,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime)";
         if (string.IsNullOrEmpty(prod_Components.PRDC_CompNo))
         {
            idb.AddParameter("@PRDC_CompNo", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_CompNo", prod_Components.PRDC_CompNo);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_CompCode))
         {
            idb.AddParameter("@PRDC_CompCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_CompCode", prod_Components.PRDC_CompCode);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_CompName))
         {
            idb.AddParameter("@PRDC_CompName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_CompName", prod_Components.PRDC_CompName);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Raw))
         {
            idb.AddParameter("@PRDC_Raw", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Raw", prod_Components.PRDC_Raw);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Supp))
         {
            idb.AddParameter("@PRDC_Supp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Supp", prod_Components.PRDC_Supp);
         }
         if (prod_Components.PRDC_RecDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRDC_RecDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_RecDate", prod_Components.PRDC_RecDate);
         }
         if (prod_Components.PRDC_FinishDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRDC_FinishDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_FinishDate", prod_Components.PRDC_FinishDate);
         }
         if (prod_Components.PRDC_SampleDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRDC_SampleDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_SampleDate", prod_Components.PRDC_SampleDate);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_VerifyResult))
         {
            idb.AddParameter("@PRDC_VerifyResult", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_VerifyResult", prod_Components.PRDC_VerifyResult);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_iType))
         {
            idb.AddParameter("@PRDC_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_iType", prod_Components.PRDC_iType);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec1))
         {
            idb.AddParameter("@PRDC_Tec1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec1", prod_Components.PRDC_Tec1);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec2))
         {
            idb.AddParameter("@PRDC_Tec2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec2", prod_Components.PRDC_Tec2);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec3))
         {
            idb.AddParameter("@PRDC_Tec3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec3", prod_Components.PRDC_Tec3);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec4))
         {
            idb.AddParameter("@PRDC_Tec4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec4", prod_Components.PRDC_Tec4);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec5))
         {
            idb.AddParameter("@PRDC_Tec5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec5", prod_Components.PRDC_Tec5);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec6))
         {
            idb.AddParameter("@PRDC_Tec6", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec6", prod_Components.PRDC_Tec6);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec7))
         {
            idb.AddParameter("@PRDC_Tec7", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec7", prod_Components.PRDC_Tec7);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec8))
         {
            idb.AddParameter("@PRDC_Tec8", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec8", prod_Components.PRDC_Tec8);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec9))
         {
            idb.AddParameter("@PRDC_Tec9", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec9", prod_Components.PRDC_Tec9);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec10))
         {
            idb.AddParameter("@PRDC_Tec10", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec10", prod_Components.PRDC_Tec10);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_ProdCode))
         {
            idb.AddParameter("@PRDC_ProdCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_ProdCode", prod_Components.PRDC_ProdCode);
         }
         if (prod_Components.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Components.Stat);
         }
         if (prod_Components.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Components.Creator);
         }
         if (prod_Components.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Components.CreateTime);
         }
         if (prod_Components.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Components.UpdateTime);
         }
         if (prod_Components.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Components.DeleteTime);
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
      /// 添加零件基本信息 Prod_Components对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Prod_Components prod_Components)
      {
         string sql = "INSERT INTO Prod_Components (PRDC_CompNo,PRDC_CompCode,PRDC_CompName,PRDC_Raw,PRDC_Supp,PRDC_RecDate,PRDC_FinishDate,PRDC_SampleDate,PRDC_VerifyResult,PRDC_iType,PRDC_Tec1,PRDC_Tec2,PRDC_Tec3,PRDC_Tec4,PRDC_Tec5,PRDC_Tec6,PRDC_Tec7,PRDC_Tec8,PRDC_Tec9,PRDC_Tec10,PRDC_ProdCode,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@PRDC_CompNo,@PRDC_CompCode,@PRDC_CompName,@PRDC_Raw,@PRDC_Supp,@PRDC_RecDate,@PRDC_FinishDate,@PRDC_SampleDate,@PRDC_VerifyResult,@PRDC_iType,@PRDC_Tec1,@PRDC_Tec2,@PRDC_Tec3,@PRDC_Tec4,@PRDC_Tec5,@PRDC_Tec6,@PRDC_Tec7,@PRDC_Tec8,@PRDC_Tec9,@PRDC_Tec10,@PRDC_ProdCode,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(prod_Components.PRDC_CompNo))
         {
            idb.AddParameter("@PRDC_CompNo", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_CompNo", prod_Components.PRDC_CompNo);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_CompCode))
         {
            idb.AddParameter("@PRDC_CompCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_CompCode", prod_Components.PRDC_CompCode);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_CompName))
         {
            idb.AddParameter("@PRDC_CompName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_CompName", prod_Components.PRDC_CompName);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Raw))
         {
            idb.AddParameter("@PRDC_Raw", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Raw", prod_Components.PRDC_Raw);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Supp))
         {
            idb.AddParameter("@PRDC_Supp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Supp", prod_Components.PRDC_Supp);
         }
         if (prod_Components.PRDC_RecDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRDC_RecDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_RecDate", prod_Components.PRDC_RecDate);
         }
         if (prod_Components.PRDC_FinishDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRDC_FinishDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_FinishDate", prod_Components.PRDC_FinishDate);
         }
         if (prod_Components.PRDC_SampleDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRDC_SampleDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_SampleDate", prod_Components.PRDC_SampleDate);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_VerifyResult))
         {
            idb.AddParameter("@PRDC_VerifyResult", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_VerifyResult", prod_Components.PRDC_VerifyResult);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_iType))
         {
            idb.AddParameter("@PRDC_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_iType", prod_Components.PRDC_iType);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec1))
         {
            idb.AddParameter("@PRDC_Tec1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec1", prod_Components.PRDC_Tec1);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec2))
         {
            idb.AddParameter("@PRDC_Tec2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec2", prod_Components.PRDC_Tec2);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec3))
         {
            idb.AddParameter("@PRDC_Tec3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec3", prod_Components.PRDC_Tec3);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec4))
         {
            idb.AddParameter("@PRDC_Tec4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec4", prod_Components.PRDC_Tec4);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec5))
         {
            idb.AddParameter("@PRDC_Tec5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec5", prod_Components.PRDC_Tec5);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec6))
         {
            idb.AddParameter("@PRDC_Tec6", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec6", prod_Components.PRDC_Tec6);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec7))
         {
            idb.AddParameter("@PRDC_Tec7", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec7", prod_Components.PRDC_Tec7);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec8))
         {
            idb.AddParameter("@PRDC_Tec8", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec8", prod_Components.PRDC_Tec8);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec9))
         {
            idb.AddParameter("@PRDC_Tec9", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec9", prod_Components.PRDC_Tec9);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec10))
         {
            idb.AddParameter("@PRDC_Tec10", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec10", prod_Components.PRDC_Tec10);
         }
         if (string.IsNullOrEmpty(prod_Components.PRDC_ProdCode))
         {
            idb.AddParameter("@PRDC_ProdCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_ProdCode", prod_Components.PRDC_ProdCode);
         }
         if (prod_Components.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Components.Stat);
         }
         if (prod_Components.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Components.Creator);
         }
         if (prod_Components.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Components.CreateTime);
         }
         if (prod_Components.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Components.UpdateTime);
         }
         if (prod_Components.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Components.DeleteTime);
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
      /// 更新零件基本信息 Prod_Components对象(即:一条记录
      /// </summary>
      public int Update(Prod_Components prod_Components)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Prod_Components       SET ");
            if(prod_Components.PRDC_CompNo_IsChanged){sbParameter.Append("PRDC_CompNo=@PRDC_CompNo, ");}
      if(prod_Components.PRDC_CompCode_IsChanged){sbParameter.Append("PRDC_CompCode=@PRDC_CompCode, ");}
      if(prod_Components.PRDC_CompName_IsChanged){sbParameter.Append("PRDC_CompName=@PRDC_CompName, ");}
      if(prod_Components.PRDC_Raw_IsChanged){sbParameter.Append("PRDC_Raw=@PRDC_Raw, ");}
      if(prod_Components.PRDC_Supp_IsChanged){sbParameter.Append("PRDC_Supp=@PRDC_Supp, ");}
      if(prod_Components.PRDC_RecDate_IsChanged){sbParameter.Append("PRDC_RecDate=@PRDC_RecDate, ");}
      if(prod_Components.PRDC_FinishDate_IsChanged){sbParameter.Append("PRDC_FinishDate=@PRDC_FinishDate, ");}
      if(prod_Components.PRDC_SampleDate_IsChanged){sbParameter.Append("PRDC_SampleDate=@PRDC_SampleDate, ");}
      if(prod_Components.PRDC_VerifyResult_IsChanged){sbParameter.Append("PRDC_VerifyResult=@PRDC_VerifyResult, ");}
      if(prod_Components.PRDC_iType_IsChanged){sbParameter.Append("PRDC_iType=@PRDC_iType, ");}
      if(prod_Components.PRDC_Tec1_IsChanged){sbParameter.Append("PRDC_Tec1=@PRDC_Tec1, ");}
      if(prod_Components.PRDC_Tec2_IsChanged){sbParameter.Append("PRDC_Tec2=@PRDC_Tec2, ");}
      if(prod_Components.PRDC_Tec3_IsChanged){sbParameter.Append("PRDC_Tec3=@PRDC_Tec3, ");}
      if(prod_Components.PRDC_Tec4_IsChanged){sbParameter.Append("PRDC_Tec4=@PRDC_Tec4, ");}
      if(prod_Components.PRDC_Tec5_IsChanged){sbParameter.Append("PRDC_Tec5=@PRDC_Tec5, ");}
      if(prod_Components.PRDC_Tec6_IsChanged){sbParameter.Append("PRDC_Tec6=@PRDC_Tec6, ");}
      if(prod_Components.PRDC_Tec7_IsChanged){sbParameter.Append("PRDC_Tec7=@PRDC_Tec7, ");}
      if(prod_Components.PRDC_Tec8_IsChanged){sbParameter.Append("PRDC_Tec8=@PRDC_Tec8, ");}
      if(prod_Components.PRDC_Tec9_IsChanged){sbParameter.Append("PRDC_Tec9=@PRDC_Tec9, ");}
      if(prod_Components.PRDC_Tec10_IsChanged){sbParameter.Append("PRDC_Tec10=@PRDC_Tec10, ");}
      if(prod_Components.PRDC_ProdCode_IsChanged){sbParameter.Append("PRDC_ProdCode=@PRDC_ProdCode, ");}
      if(prod_Components.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(prod_Components.Creator_IsChanged){sbParameter.Append("Creator=@Creator, ");}
      if(prod_Components.CreateTime_IsChanged){sbParameter.Append("CreateTime=@CreateTime, ");}
      if(prod_Components.UpdateTime_IsChanged){sbParameter.Append("UpdateTime=@UpdateTime, ");}
      if(prod_Components.DeleteTime_IsChanged){sbParameter.Append("DeleteTime=@DeleteTime ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and PRDC_ID=@PRDC_ID; " );
      string sql=sb.ToString();
         if(prod_Components.PRDC_CompNo_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_CompNo))
         {
            idb.AddParameter("@PRDC_CompNo", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_CompNo", prod_Components.PRDC_CompNo);
         }
          }
         if(prod_Components.PRDC_CompCode_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_CompCode))
         {
            idb.AddParameter("@PRDC_CompCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_CompCode", prod_Components.PRDC_CompCode);
         }
          }
         if(prod_Components.PRDC_CompName_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_CompName))
         {
            idb.AddParameter("@PRDC_CompName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_CompName", prod_Components.PRDC_CompName);
         }
          }
         if(prod_Components.PRDC_Raw_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Raw))
         {
            idb.AddParameter("@PRDC_Raw", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Raw", prod_Components.PRDC_Raw);
         }
          }
         if(prod_Components.PRDC_Supp_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Supp))
         {
            idb.AddParameter("@PRDC_Supp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Supp", prod_Components.PRDC_Supp);
         }
          }
         if(prod_Components.PRDC_RecDate_IsChanged)
         {
         if (prod_Components.PRDC_RecDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRDC_RecDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_RecDate", prod_Components.PRDC_RecDate);
         }
          }
         if(prod_Components.PRDC_FinishDate_IsChanged)
         {
         if (prod_Components.PRDC_FinishDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRDC_FinishDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_FinishDate", prod_Components.PRDC_FinishDate);
         }
          }
         if(prod_Components.PRDC_SampleDate_IsChanged)
         {
         if (prod_Components.PRDC_SampleDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRDC_SampleDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_SampleDate", prod_Components.PRDC_SampleDate);
         }
          }
         if(prod_Components.PRDC_VerifyResult_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_VerifyResult))
         {
            idb.AddParameter("@PRDC_VerifyResult", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_VerifyResult", prod_Components.PRDC_VerifyResult);
         }
          }
         if(prod_Components.PRDC_iType_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_iType))
         {
            idb.AddParameter("@PRDC_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_iType", prod_Components.PRDC_iType);
         }
          }
         if(prod_Components.PRDC_Tec1_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec1))
         {
            idb.AddParameter("@PRDC_Tec1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec1", prod_Components.PRDC_Tec1);
         }
          }
         if(prod_Components.PRDC_Tec2_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec2))
         {
            idb.AddParameter("@PRDC_Tec2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec2", prod_Components.PRDC_Tec2);
         }
          }
         if(prod_Components.PRDC_Tec3_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec3))
         {
            idb.AddParameter("@PRDC_Tec3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec3", prod_Components.PRDC_Tec3);
         }
          }
         if(prod_Components.PRDC_Tec4_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec4))
         {
            idb.AddParameter("@PRDC_Tec4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec4", prod_Components.PRDC_Tec4);
         }
          }
         if(prod_Components.PRDC_Tec5_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec5))
         {
            idb.AddParameter("@PRDC_Tec5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec5", prod_Components.PRDC_Tec5);
         }
          }
         if(prod_Components.PRDC_Tec6_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec6))
         {
            idb.AddParameter("@PRDC_Tec6", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec6", prod_Components.PRDC_Tec6);
         }
          }
         if(prod_Components.PRDC_Tec7_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec7))
         {
            idb.AddParameter("@PRDC_Tec7", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec7", prod_Components.PRDC_Tec7);
         }
          }
         if(prod_Components.PRDC_Tec8_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec8))
         {
            idb.AddParameter("@PRDC_Tec8", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec8", prod_Components.PRDC_Tec8);
         }
          }
         if(prod_Components.PRDC_Tec9_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec9))
         {
            idb.AddParameter("@PRDC_Tec9", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec9", prod_Components.PRDC_Tec9);
         }
          }
         if(prod_Components.PRDC_Tec10_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_Tec10))
         {
            idb.AddParameter("@PRDC_Tec10", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_Tec10", prod_Components.PRDC_Tec10);
         }
          }
         if(prod_Components.PRDC_ProdCode_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Components.PRDC_ProdCode))
         {
            idb.AddParameter("@PRDC_ProdCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDC_ProdCode", prod_Components.PRDC_ProdCode);
         }
          }
         if(prod_Components.Stat_IsChanged)
         {
         if (prod_Components.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Components.Stat);
         }
          }
         if(prod_Components.Creator_IsChanged)
         {
         if (prod_Components.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Components.Creator);
         }
          }
         if(prod_Components.CreateTime_IsChanged)
         {
         if (prod_Components.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Components.CreateTime);
         }
          }
         if(prod_Components.UpdateTime_IsChanged)
         {
         if (prod_Components.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Components.UpdateTime);
         }
          }
         if(prod_Components.DeleteTime_IsChanged)
         {
         if (prod_Components.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Components.DeleteTime);
         }
          }

         idb.AddParameter("@PRDC_ID", prod_Components.PRDC_ID);


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
      /// 删除零件基本信息 Prod_Components对象(即:一条记录
      /// </summary>
      public int Delete(decimal pRDC_ID)
      {
         string sql = "DELETE Prod_Components WHERE 1=1  AND PRDC_ID=@PRDC_ID ";
         idb.AddParameter("@PRDC_ID", pRDC_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的零件基本信息 Prod_Components对象(即:一条记录
      /// </summary>
      public Prod_Components GetByKey(decimal pRDC_ID)
      {
         Prod_Components prod_Components = new Prod_Components();
         string sql = "SELECT  PRDC_ID,PRDC_CompNo,PRDC_CompCode,PRDC_CompName,PRDC_Raw,PRDC_Supp,PRDC_RecDate,PRDC_FinishDate,PRDC_SampleDate,PRDC_VerifyResult,PRDC_iType,PRDC_Tec1,PRDC_Tec2,PRDC_Tec3,PRDC_Tec4,PRDC_Tec5,PRDC_Tec6,PRDC_Tec7,PRDC_Tec8,PRDC_Tec9,PRDC_Tec10,PRDC_ProdCode,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Prod_Components WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND PRDC_ID=@PRDC_ID ";
         idb.AddParameter("@PRDC_ID", pRDC_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["PRDC_ID"] != DBNull.Value) prod_Components.PRDC_ID = Convert.ToDecimal(dr["PRDC_ID"]);
            if (dr["PRDC_CompNo"] != DBNull.Value) prod_Components.PRDC_CompNo = Convert.ToString(dr["PRDC_CompNo"]);
            if (dr["PRDC_CompCode"] != DBNull.Value) prod_Components.PRDC_CompCode = Convert.ToString(dr["PRDC_CompCode"]);
            if (dr["PRDC_CompName"] != DBNull.Value) prod_Components.PRDC_CompName = Convert.ToString(dr["PRDC_CompName"]);
            if (dr["PRDC_Raw"] != DBNull.Value) prod_Components.PRDC_Raw = Convert.ToString(dr["PRDC_Raw"]);
            if (dr["PRDC_Supp"] != DBNull.Value) prod_Components.PRDC_Supp = Convert.ToString(dr["PRDC_Supp"]);
            if (dr["PRDC_RecDate"] != DBNull.Value) prod_Components.PRDC_RecDate = Convert.ToDateTime(dr["PRDC_RecDate"]);
            if (dr["PRDC_FinishDate"] != DBNull.Value) prod_Components.PRDC_FinishDate = Convert.ToDateTime(dr["PRDC_FinishDate"]);
            if (dr["PRDC_SampleDate"] != DBNull.Value) prod_Components.PRDC_SampleDate = Convert.ToDateTime(dr["PRDC_SampleDate"]);
            if (dr["PRDC_VerifyResult"] != DBNull.Value) prod_Components.PRDC_VerifyResult = Convert.ToString(dr["PRDC_VerifyResult"]);
            if (dr["PRDC_iType"] != DBNull.Value) prod_Components.PRDC_iType = Convert.ToString(dr["PRDC_iType"]);
            if (dr["PRDC_Tec1"] != DBNull.Value) prod_Components.PRDC_Tec1 = Convert.ToString(dr["PRDC_Tec1"]);
            if (dr["PRDC_Tec2"] != DBNull.Value) prod_Components.PRDC_Tec2 = Convert.ToString(dr["PRDC_Tec2"]);
            if (dr["PRDC_Tec3"] != DBNull.Value) prod_Components.PRDC_Tec3 = Convert.ToString(dr["PRDC_Tec3"]);
            if (dr["PRDC_Tec4"] != DBNull.Value) prod_Components.PRDC_Tec4 = Convert.ToString(dr["PRDC_Tec4"]);
            if (dr["PRDC_Tec5"] != DBNull.Value) prod_Components.PRDC_Tec5 = Convert.ToString(dr["PRDC_Tec5"]);
            if (dr["PRDC_Tec6"] != DBNull.Value) prod_Components.PRDC_Tec6 = Convert.ToString(dr["PRDC_Tec6"]);
            if (dr["PRDC_Tec7"] != DBNull.Value) prod_Components.PRDC_Tec7 = Convert.ToString(dr["PRDC_Tec7"]);
            if (dr["PRDC_Tec8"] != DBNull.Value) prod_Components.PRDC_Tec8 = Convert.ToString(dr["PRDC_Tec8"]);
            if (dr["PRDC_Tec9"] != DBNull.Value) prod_Components.PRDC_Tec9 = Convert.ToString(dr["PRDC_Tec9"]);
            if (dr["PRDC_Tec10"] != DBNull.Value) prod_Components.PRDC_Tec10 = Convert.ToString(dr["PRDC_Tec10"]);
            if (dr["PRDC_ProdCode"] != DBNull.Value) prod_Components.PRDC_ProdCode = Convert.ToString(dr["PRDC_ProdCode"]);
            if (dr["Stat"] != DBNull.Value) prod_Components.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Components.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Components.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Components.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Components.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return prod_Components;
      }
      /// <summary>
      /// 获取指定的零件基本信息 Prod_Components对象集合
      /// </summary>
      public List<Prod_Components> GetListByWhere(string strCondition)
      {
         List<Prod_Components> ret = new List<Prod_Components>();
         string sql = "SELECT  PRDC_ID,PRDC_CompNo,PRDC_CompCode,PRDC_CompName,PRDC_Raw,PRDC_Supp,PRDC_RecDate,PRDC_FinishDate,PRDC_SampleDate,PRDC_VerifyResult,PRDC_iType,PRDC_Tec1,PRDC_Tec2,PRDC_Tec3,PRDC_Tec4,PRDC_Tec5,PRDC_Tec6,PRDC_Tec7,PRDC_Tec8,PRDC_Tec9,PRDC_Tec10,PRDC_ProdCode,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Prod_Components WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Prod_Components prod_Components = new Prod_Components();
            if (dr["PRDC_ID"] != DBNull.Value) prod_Components.PRDC_ID = Convert.ToDecimal(dr["PRDC_ID"]);
            if (dr["PRDC_CompNo"] != DBNull.Value) prod_Components.PRDC_CompNo = Convert.ToString(dr["PRDC_CompNo"]);
            if (dr["PRDC_CompCode"] != DBNull.Value) prod_Components.PRDC_CompCode = Convert.ToString(dr["PRDC_CompCode"]);
            if (dr["PRDC_CompName"] != DBNull.Value) prod_Components.PRDC_CompName = Convert.ToString(dr["PRDC_CompName"]);
            if (dr["PRDC_Raw"] != DBNull.Value) prod_Components.PRDC_Raw = Convert.ToString(dr["PRDC_Raw"]);
            if (dr["PRDC_Supp"] != DBNull.Value) prod_Components.PRDC_Supp = Convert.ToString(dr["PRDC_Supp"]);
            if (dr["PRDC_RecDate"] != DBNull.Value) prod_Components.PRDC_RecDate = Convert.ToDateTime(dr["PRDC_RecDate"]);
            if (dr["PRDC_FinishDate"] != DBNull.Value) prod_Components.PRDC_FinishDate = Convert.ToDateTime(dr["PRDC_FinishDate"]);
            if (dr["PRDC_SampleDate"] != DBNull.Value) prod_Components.PRDC_SampleDate = Convert.ToDateTime(dr["PRDC_SampleDate"]);
            if (dr["PRDC_VerifyResult"] != DBNull.Value) prod_Components.PRDC_VerifyResult = Convert.ToString(dr["PRDC_VerifyResult"]);
            if (dr["PRDC_iType"] != DBNull.Value) prod_Components.PRDC_iType = Convert.ToString(dr["PRDC_iType"]);
            if (dr["PRDC_Tec1"] != DBNull.Value) prod_Components.PRDC_Tec1 = Convert.ToString(dr["PRDC_Tec1"]);
            if (dr["PRDC_Tec2"] != DBNull.Value) prod_Components.PRDC_Tec2 = Convert.ToString(dr["PRDC_Tec2"]);
            if (dr["PRDC_Tec3"] != DBNull.Value) prod_Components.PRDC_Tec3 = Convert.ToString(dr["PRDC_Tec3"]);
            if (dr["PRDC_Tec4"] != DBNull.Value) prod_Components.PRDC_Tec4 = Convert.ToString(dr["PRDC_Tec4"]);
            if (dr["PRDC_Tec5"] != DBNull.Value) prod_Components.PRDC_Tec5 = Convert.ToString(dr["PRDC_Tec5"]);
            if (dr["PRDC_Tec6"] != DBNull.Value) prod_Components.PRDC_Tec6 = Convert.ToString(dr["PRDC_Tec6"]);
            if (dr["PRDC_Tec7"] != DBNull.Value) prod_Components.PRDC_Tec7 = Convert.ToString(dr["PRDC_Tec7"]);
            if (dr["PRDC_Tec8"] != DBNull.Value) prod_Components.PRDC_Tec8 = Convert.ToString(dr["PRDC_Tec8"]);
            if (dr["PRDC_Tec9"] != DBNull.Value) prod_Components.PRDC_Tec9 = Convert.ToString(dr["PRDC_Tec9"]);
            if (dr["PRDC_Tec10"] != DBNull.Value) prod_Components.PRDC_Tec10 = Convert.ToString(dr["PRDC_Tec10"]);
            if (dr["PRDC_ProdCode"] != DBNull.Value) prod_Components.PRDC_ProdCode = Convert.ToString(dr["PRDC_ProdCode"]);
            if (dr["Stat"] != DBNull.Value) prod_Components.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Components.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Components.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Components.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Components.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(prod_Components);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的零件基本信息 Prod_Components对象(即:一条记录
      /// </summary>
      public List<Prod_Components> GetAll()
      {
         List<Prod_Components> ret = new List<Prod_Components>();
         string sql = "SELECT  PRDC_ID,PRDC_CompNo,PRDC_CompCode,PRDC_CompName,PRDC_Raw,PRDC_Supp,PRDC_RecDate,PRDC_FinishDate,PRDC_SampleDate,PRDC_VerifyResult,PRDC_iType,PRDC_Tec1,PRDC_Tec2,PRDC_Tec3,PRDC_Tec4,PRDC_Tec5,PRDC_Tec6,PRDC_Tec7,PRDC_Tec8,PRDC_Tec9,PRDC_Tec10,PRDC_ProdCode,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Prod_Components where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Prod_Components prod_Components = new Prod_Components();
            if (dr["PRDC_ID"] != DBNull.Value) prod_Components.PRDC_ID = Convert.ToDecimal(dr["PRDC_ID"]);
            if (dr["PRDC_CompNo"] != DBNull.Value) prod_Components.PRDC_CompNo = Convert.ToString(dr["PRDC_CompNo"]);
            if (dr["PRDC_CompCode"] != DBNull.Value) prod_Components.PRDC_CompCode = Convert.ToString(dr["PRDC_CompCode"]);
            if (dr["PRDC_CompName"] != DBNull.Value) prod_Components.PRDC_CompName = Convert.ToString(dr["PRDC_CompName"]);
            if (dr["PRDC_Raw"] != DBNull.Value) prod_Components.PRDC_Raw = Convert.ToString(dr["PRDC_Raw"]);
            if (dr["PRDC_Supp"] != DBNull.Value) prod_Components.PRDC_Supp = Convert.ToString(dr["PRDC_Supp"]);
            if (dr["PRDC_RecDate"] != DBNull.Value) prod_Components.PRDC_RecDate = Convert.ToDateTime(dr["PRDC_RecDate"]);
            if (dr["PRDC_FinishDate"] != DBNull.Value) prod_Components.PRDC_FinishDate = Convert.ToDateTime(dr["PRDC_FinishDate"]);
            if (dr["PRDC_SampleDate"] != DBNull.Value) prod_Components.PRDC_SampleDate = Convert.ToDateTime(dr["PRDC_SampleDate"]);
            if (dr["PRDC_VerifyResult"] != DBNull.Value) prod_Components.PRDC_VerifyResult = Convert.ToString(dr["PRDC_VerifyResult"]);
            if (dr["PRDC_iType"] != DBNull.Value) prod_Components.PRDC_iType = Convert.ToString(dr["PRDC_iType"]);
            if (dr["PRDC_Tec1"] != DBNull.Value) prod_Components.PRDC_Tec1 = Convert.ToString(dr["PRDC_Tec1"]);
            if (dr["PRDC_Tec2"] != DBNull.Value) prod_Components.PRDC_Tec2 = Convert.ToString(dr["PRDC_Tec2"]);
            if (dr["PRDC_Tec3"] != DBNull.Value) prod_Components.PRDC_Tec3 = Convert.ToString(dr["PRDC_Tec3"]);
            if (dr["PRDC_Tec4"] != DBNull.Value) prod_Components.PRDC_Tec4 = Convert.ToString(dr["PRDC_Tec4"]);
            if (dr["PRDC_Tec5"] != DBNull.Value) prod_Components.PRDC_Tec5 = Convert.ToString(dr["PRDC_Tec5"]);
            if (dr["PRDC_Tec6"] != DBNull.Value) prod_Components.PRDC_Tec6 = Convert.ToString(dr["PRDC_Tec6"]);
            if (dr["PRDC_Tec7"] != DBNull.Value) prod_Components.PRDC_Tec7 = Convert.ToString(dr["PRDC_Tec7"]);
            if (dr["PRDC_Tec8"] != DBNull.Value) prod_Components.PRDC_Tec8 = Convert.ToString(dr["PRDC_Tec8"]);
            if (dr["PRDC_Tec9"] != DBNull.Value) prod_Components.PRDC_Tec9 = Convert.ToString(dr["PRDC_Tec9"]);
            if (dr["PRDC_Tec10"] != DBNull.Value) prod_Components.PRDC_Tec10 = Convert.ToString(dr["PRDC_Tec10"]);
            if (dr["PRDC_ProdCode"] != DBNull.Value) prod_Components.PRDC_ProdCode = Convert.ToString(dr["PRDC_ProdCode"]);
            if (dr["Stat"] != DBNull.Value) prod_Components.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Components.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Components.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Components.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Components.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(prod_Components);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
