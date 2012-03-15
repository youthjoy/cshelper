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
   public partial class ADOProd_Doc
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Prod_Doc对象(即:一条记录)
      /// </summary>
      public int Add(Prod_Doc prod_Doc)
      {
         string sql = "INSERT INTO Prod_Doc (PRDQ_Code,PRDQ_CompNo,PRDQ_CompCode,PRDQ_CompName,PRDQ_Name,PRDQ_Type,PRDQ_iType,PRDQ_Date,PRDQ_Owner,PRDQ_Plant,PRDQ_Result,PRDQ_FCode,PRDQ_FReso,PRDQ_FOpi,PRDQ_FDeC,PRDQ_Bak,PRDQ_FDate,PRDQ_IsScan,PRDQ_IsNeed,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@PRDQ_Code,@PRDQ_CompNo,@PRDQ_CompCode,@PRDQ_CompName,@PRDQ_Name,@PRDQ_Type,@PRDQ_iType,@PRDQ_Date,@PRDQ_Owner,@PRDQ_Plant,@PRDQ_Result,@PRDQ_FCode,@PRDQ_FReso,@PRDQ_FOpi,@PRDQ_FDeC,@PRDQ_Bak,@PRDQ_FDate,@PRDQ_IsScan,@PRDQ_IsNeed,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime)";
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Code))
         {
            idb.AddParameter("@PRDQ_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Code", prod_Doc.PRDQ_Code);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_CompNo))
         {
            idb.AddParameter("@PRDQ_CompNo", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_CompNo", prod_Doc.PRDQ_CompNo);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_CompCode))
         {
            idb.AddParameter("@PRDQ_CompCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_CompCode", prod_Doc.PRDQ_CompCode);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_CompName))
         {
            idb.AddParameter("@PRDQ_CompName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_CompName", prod_Doc.PRDQ_CompName);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Name))
         {
            idb.AddParameter("@PRDQ_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Name", prod_Doc.PRDQ_Name);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Type))
         {
            idb.AddParameter("@PRDQ_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Type", prod_Doc.PRDQ_Type);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_iType))
         {
            idb.AddParameter("@PRDQ_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_iType", prod_Doc.PRDQ_iType);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Date))
         {
            idb.AddParameter("@PRDQ_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Date", prod_Doc.PRDQ_Date);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Owner))
         {
            idb.AddParameter("@PRDQ_Owner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Owner", prod_Doc.PRDQ_Owner);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Plant))
         {
            idb.AddParameter("@PRDQ_Plant", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Plant", prod_Doc.PRDQ_Plant);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Result))
         {
            idb.AddParameter("@PRDQ_Result", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Result", prod_Doc.PRDQ_Result);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FCode))
         {
            idb.AddParameter("@PRDQ_FCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FCode", prod_Doc.PRDQ_FCode);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FReso))
         {
            idb.AddParameter("@PRDQ_FReso", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FReso", prod_Doc.PRDQ_FReso);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FOpi))
         {
            idb.AddParameter("@PRDQ_FOpi", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FOpi", prod_Doc.PRDQ_FOpi);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FDeC))
         {
            idb.AddParameter("@PRDQ_FDeC", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FDeC", prod_Doc.PRDQ_FDeC);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Bak))
         {
            idb.AddParameter("@PRDQ_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Bak", prod_Doc.PRDQ_Bak);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FDate))
         {
            idb.AddParameter("@PRDQ_FDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FDate", prod_Doc.PRDQ_FDate);
         }
         if (prod_Doc.PRDQ_IsScan == 0)
         {
            idb.AddParameter("@PRDQ_IsScan", 0);
         }
         else
         {
            idb.AddParameter("@PRDQ_IsScan", prod_Doc.PRDQ_IsScan);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_IsNeed))
         {
            idb.AddParameter("@PRDQ_IsNeed", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_IsNeed", prod_Doc.PRDQ_IsNeed);
         }
         if (prod_Doc.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Doc.Stat);
         }
         if (prod_Doc.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Doc.Creator);
         }
         if (prod_Doc.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Doc.CreateTime);
         }
         if (prod_Doc.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Doc.UpdateTime);
         }
         if (prod_Doc.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Doc.DeleteTime);
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
      /// 添加Prod_Doc对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Prod_Doc prod_Doc)
      {
         string sql = "INSERT INTO Prod_Doc (PRDQ_Code,PRDQ_CompNo,PRDQ_CompCode,PRDQ_CompName,PRDQ_Name,PRDQ_Type,PRDQ_iType,PRDQ_Date,PRDQ_Owner,PRDQ_Plant,PRDQ_Result,PRDQ_FCode,PRDQ_FReso,PRDQ_FOpi,PRDQ_FDeC,PRDQ_Bak,PRDQ_FDate,PRDQ_IsScan,PRDQ_IsNeed,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@PRDQ_Code,@PRDQ_CompNo,@PRDQ_CompCode,@PRDQ_CompName,@PRDQ_Name,@PRDQ_Type,@PRDQ_iType,@PRDQ_Date,@PRDQ_Owner,@PRDQ_Plant,@PRDQ_Result,@PRDQ_FCode,@PRDQ_FReso,@PRDQ_FOpi,@PRDQ_FDeC,@PRDQ_Bak,@PRDQ_FDate,@PRDQ_IsScan,@PRDQ_IsNeed,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Code))
         {
            idb.AddParameter("@PRDQ_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Code", prod_Doc.PRDQ_Code);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_CompNo))
         {
            idb.AddParameter("@PRDQ_CompNo", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_CompNo", prod_Doc.PRDQ_CompNo);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_CompCode))
         {
            idb.AddParameter("@PRDQ_CompCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_CompCode", prod_Doc.PRDQ_CompCode);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_CompName))
         {
            idb.AddParameter("@PRDQ_CompName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_CompName", prod_Doc.PRDQ_CompName);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Name))
         {
            idb.AddParameter("@PRDQ_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Name", prod_Doc.PRDQ_Name);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Type))
         {
            idb.AddParameter("@PRDQ_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Type", prod_Doc.PRDQ_Type);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_iType))
         {
            idb.AddParameter("@PRDQ_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_iType", prod_Doc.PRDQ_iType);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Date))
         {
            idb.AddParameter("@PRDQ_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Date", prod_Doc.PRDQ_Date);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Owner))
         {
            idb.AddParameter("@PRDQ_Owner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Owner", prod_Doc.PRDQ_Owner);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Plant))
         {
            idb.AddParameter("@PRDQ_Plant", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Plant", prod_Doc.PRDQ_Plant);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Result))
         {
            idb.AddParameter("@PRDQ_Result", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Result", prod_Doc.PRDQ_Result);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FCode))
         {
            idb.AddParameter("@PRDQ_FCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FCode", prod_Doc.PRDQ_FCode);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FReso))
         {
            idb.AddParameter("@PRDQ_FReso", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FReso", prod_Doc.PRDQ_FReso);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FOpi))
         {
            idb.AddParameter("@PRDQ_FOpi", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FOpi", prod_Doc.PRDQ_FOpi);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FDeC))
         {
            idb.AddParameter("@PRDQ_FDeC", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FDeC", prod_Doc.PRDQ_FDeC);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Bak))
         {
            idb.AddParameter("@PRDQ_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Bak", prod_Doc.PRDQ_Bak);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FDate))
         {
            idb.AddParameter("@PRDQ_FDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FDate", prod_Doc.PRDQ_FDate);
         }
         if (prod_Doc.PRDQ_IsScan == 0)
         {
            idb.AddParameter("@PRDQ_IsScan", 0);
         }
         else
         {
            idb.AddParameter("@PRDQ_IsScan", prod_Doc.PRDQ_IsScan);
         }
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_IsNeed))
         {
            idb.AddParameter("@PRDQ_IsNeed", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_IsNeed", prod_Doc.PRDQ_IsNeed);
         }
         if (prod_Doc.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Doc.Stat);
         }
         if (prod_Doc.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Doc.Creator);
         }
         if (prod_Doc.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Doc.CreateTime);
         }
         if (prod_Doc.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Doc.UpdateTime);
         }
         if (prod_Doc.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Doc.DeleteTime);
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
      /// 更新Prod_Doc对象(即:一条记录
      /// </summary>
      public int Update(Prod_Doc prod_Doc)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Prod_Doc       SET ");
            if(prod_Doc.PRDQ_Code_IsChanged){sbParameter.Append("PRDQ_Code=@PRDQ_Code, ");}
      if(prod_Doc.PRDQ_CompNo_IsChanged){sbParameter.Append("PRDQ_CompNo=@PRDQ_CompNo, ");}
      if(prod_Doc.PRDQ_CompCode_IsChanged){sbParameter.Append("PRDQ_CompCode=@PRDQ_CompCode, ");}
      if(prod_Doc.PRDQ_CompName_IsChanged){sbParameter.Append("PRDQ_CompName=@PRDQ_CompName, ");}
      if(prod_Doc.PRDQ_Name_IsChanged){sbParameter.Append("PRDQ_Name=@PRDQ_Name, ");}
      if(prod_Doc.PRDQ_Type_IsChanged){sbParameter.Append("PRDQ_Type=@PRDQ_Type, ");}
      if(prod_Doc.PRDQ_iType_IsChanged){sbParameter.Append("PRDQ_iType=@PRDQ_iType, ");}
      if(prod_Doc.PRDQ_Date_IsChanged){sbParameter.Append("PRDQ_Date=@PRDQ_Date, ");}
      if(prod_Doc.PRDQ_Owner_IsChanged){sbParameter.Append("PRDQ_Owner=@PRDQ_Owner, ");}
      if(prod_Doc.PRDQ_Plant_IsChanged){sbParameter.Append("PRDQ_Plant=@PRDQ_Plant, ");}
      if(prod_Doc.PRDQ_Result_IsChanged){sbParameter.Append("PRDQ_Result=@PRDQ_Result, ");}
      if(prod_Doc.PRDQ_FCode_IsChanged){sbParameter.Append("PRDQ_FCode=@PRDQ_FCode, ");}
      if(prod_Doc.PRDQ_FReso_IsChanged){sbParameter.Append("PRDQ_FReso=@PRDQ_FReso, ");}
      if(prod_Doc.PRDQ_FOpi_IsChanged){sbParameter.Append("PRDQ_FOpi=@PRDQ_FOpi, ");}
      if(prod_Doc.PRDQ_FDeC_IsChanged){sbParameter.Append("PRDQ_FDeC=@PRDQ_FDeC, ");}
      if(prod_Doc.PRDQ_Bak_IsChanged){sbParameter.Append("PRDQ_Bak=@PRDQ_Bak, ");}
      if(prod_Doc.PRDQ_FDate_IsChanged){sbParameter.Append("PRDQ_FDate=@PRDQ_FDate, ");}
      if(prod_Doc.PRDQ_IsScan_IsChanged){sbParameter.Append("PRDQ_IsScan=@PRDQ_IsScan, ");}
      if(prod_Doc.PRDQ_IsNeed_IsChanged){sbParameter.Append("PRDQ_IsNeed=@PRDQ_IsNeed, ");}
      if(prod_Doc.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(prod_Doc.Creator_IsChanged){sbParameter.Append("Creator=@Creator, ");}
      if(prod_Doc.CreateTime_IsChanged){sbParameter.Append("CreateTime=@CreateTime, ");}
      if(prod_Doc.UpdateTime_IsChanged){sbParameter.Append("UpdateTime=@UpdateTime, ");}
      if(prod_Doc.DeleteTime_IsChanged){sbParameter.Append("DeleteTime=@DeleteTime ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and PRDQ_ID=@PRDQ_ID; " );
      string sql=sb.ToString();
         if(prod_Doc.PRDQ_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Code))
         {
            idb.AddParameter("@PRDQ_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Code", prod_Doc.PRDQ_Code);
         }
          }
         if(prod_Doc.PRDQ_CompNo_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_CompNo))
         {
            idb.AddParameter("@PRDQ_CompNo", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_CompNo", prod_Doc.PRDQ_CompNo);
         }
          }
         if(prod_Doc.PRDQ_CompCode_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_CompCode))
         {
            idb.AddParameter("@PRDQ_CompCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_CompCode", prod_Doc.PRDQ_CompCode);
         }
          }
         if(prod_Doc.PRDQ_CompName_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_CompName))
         {
            idb.AddParameter("@PRDQ_CompName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_CompName", prod_Doc.PRDQ_CompName);
         }
          }
         if(prod_Doc.PRDQ_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Name))
         {
            idb.AddParameter("@PRDQ_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Name", prod_Doc.PRDQ_Name);
         }
          }
         if(prod_Doc.PRDQ_Type_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Type))
         {
            idb.AddParameter("@PRDQ_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Type", prod_Doc.PRDQ_Type);
         }
          }
         if(prod_Doc.PRDQ_iType_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_iType))
         {
            idb.AddParameter("@PRDQ_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_iType", prod_Doc.PRDQ_iType);
         }
          }
         if(prod_Doc.PRDQ_Date_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Date))
         {
            idb.AddParameter("@PRDQ_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Date", prod_Doc.PRDQ_Date);
         }
          }
         if(prod_Doc.PRDQ_Owner_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Owner))
         {
            idb.AddParameter("@PRDQ_Owner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Owner", prod_Doc.PRDQ_Owner);
         }
          }
         if(prod_Doc.PRDQ_Plant_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Plant))
         {
            idb.AddParameter("@PRDQ_Plant", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Plant", prod_Doc.PRDQ_Plant);
         }
          }
         if(prod_Doc.PRDQ_Result_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Result))
         {
            idb.AddParameter("@PRDQ_Result", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Result", prod_Doc.PRDQ_Result);
         }
          }
         if(prod_Doc.PRDQ_FCode_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FCode))
         {
            idb.AddParameter("@PRDQ_FCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FCode", prod_Doc.PRDQ_FCode);
         }
          }
         if(prod_Doc.PRDQ_FReso_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FReso))
         {
            idb.AddParameter("@PRDQ_FReso", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FReso", prod_Doc.PRDQ_FReso);
         }
          }
         if(prod_Doc.PRDQ_FOpi_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FOpi))
         {
            idb.AddParameter("@PRDQ_FOpi", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FOpi", prod_Doc.PRDQ_FOpi);
         }
          }
         if(prod_Doc.PRDQ_FDeC_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FDeC))
         {
            idb.AddParameter("@PRDQ_FDeC", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FDeC", prod_Doc.PRDQ_FDeC);
         }
          }
         if(prod_Doc.PRDQ_Bak_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_Bak))
         {
            idb.AddParameter("@PRDQ_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_Bak", prod_Doc.PRDQ_Bak);
         }
          }
         if(prod_Doc.PRDQ_FDate_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_FDate))
         {
            idb.AddParameter("@PRDQ_FDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_FDate", prod_Doc.PRDQ_FDate);
         }
          }
         if(prod_Doc.PRDQ_IsScan_IsChanged)
         {
         if (prod_Doc.PRDQ_IsScan == 0)
         {
            idb.AddParameter("@PRDQ_IsScan", 0);
         }
         else
         {
            idb.AddParameter("@PRDQ_IsScan", prod_Doc.PRDQ_IsScan);
         }
          }
         if(prod_Doc.PRDQ_IsNeed_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Doc.PRDQ_IsNeed))
         {
            idb.AddParameter("@PRDQ_IsNeed", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRDQ_IsNeed", prod_Doc.PRDQ_IsNeed);
         }
          }
         if(prod_Doc.Stat_IsChanged)
         {
         if (prod_Doc.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Doc.Stat);
         }
          }
         if(prod_Doc.Creator_IsChanged)
         {
         if (prod_Doc.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Doc.Creator);
         }
          }
         if(prod_Doc.CreateTime_IsChanged)
         {
         if (prod_Doc.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Doc.CreateTime);
         }
          }
         if(prod_Doc.UpdateTime_IsChanged)
         {
         if (prod_Doc.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Doc.UpdateTime);
         }
          }
         if(prod_Doc.DeleteTime_IsChanged)
         {
         if (prod_Doc.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Doc.DeleteTime);
         }
          }

         idb.AddParameter("@PRDQ_ID", prod_Doc.PRDQ_ID);


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
      /// 删除Prod_Doc对象(即:一条记录
      /// </summary>
      public int Delete(decimal pRDQ_ID)
      {
         string sql = "DELETE Prod_Doc WHERE 1=1  AND PRDQ_ID=@PRDQ_ID ";
         idb.AddParameter("@PRDQ_ID", pRDQ_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Prod_Doc对象(即:一条记录
      /// </summary>
      public Prod_Doc GetByKey(decimal pRDQ_ID)
      {
         Prod_Doc prod_Doc = new Prod_Doc();
         string sql = "SELECT  PRDQ_ID,PRDQ_Code,PRDQ_CompNo,PRDQ_CompCode,PRDQ_CompName,PRDQ_Name,PRDQ_Type,PRDQ_iType,PRDQ_Date,PRDQ_Owner,PRDQ_Plant,PRDQ_Result,PRDQ_FCode,PRDQ_FReso,PRDQ_FOpi,PRDQ_FDeC,PRDQ_Bak,PRDQ_FDate,PRDQ_IsScan,PRDQ_IsNeed,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Prod_Doc WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND PRDQ_ID=@PRDQ_ID ";
         idb.AddParameter("@PRDQ_ID", pRDQ_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["PRDQ_ID"] != DBNull.Value) prod_Doc.PRDQ_ID = Convert.ToDecimal(dr["PRDQ_ID"]);
            if (dr["PRDQ_Code"] != DBNull.Value) prod_Doc.PRDQ_Code = Convert.ToString(dr["PRDQ_Code"]);
            if (dr["PRDQ_CompNo"] != DBNull.Value) prod_Doc.PRDQ_CompNo = Convert.ToString(dr["PRDQ_CompNo"]);
            if (dr["PRDQ_CompCode"] != DBNull.Value) prod_Doc.PRDQ_CompCode = Convert.ToString(dr["PRDQ_CompCode"]);
            if (dr["PRDQ_CompName"] != DBNull.Value) prod_Doc.PRDQ_CompName = Convert.ToString(dr["PRDQ_CompName"]);
            if (dr["PRDQ_Name"] != DBNull.Value) prod_Doc.PRDQ_Name = Convert.ToString(dr["PRDQ_Name"]);
            if (dr["PRDQ_Type"] != DBNull.Value) prod_Doc.PRDQ_Type = Convert.ToString(dr["PRDQ_Type"]);
            if (dr["PRDQ_iType"] != DBNull.Value) prod_Doc.PRDQ_iType = Convert.ToString(dr["PRDQ_iType"]);
            if (dr["PRDQ_Date"] != DBNull.Value) prod_Doc.PRDQ_Date = Convert.ToString(dr["PRDQ_Date"]);
            if (dr["PRDQ_Owner"] != DBNull.Value) prod_Doc.PRDQ_Owner = Convert.ToString(dr["PRDQ_Owner"]);
            if (dr["PRDQ_Plant"] != DBNull.Value) prod_Doc.PRDQ_Plant = Convert.ToString(dr["PRDQ_Plant"]);
            if (dr["PRDQ_Result"] != DBNull.Value) prod_Doc.PRDQ_Result = Convert.ToString(dr["PRDQ_Result"]);
            if (dr["PRDQ_FCode"] != DBNull.Value) prod_Doc.PRDQ_FCode = Convert.ToString(dr["PRDQ_FCode"]);
            if (dr["PRDQ_FReso"] != DBNull.Value) prod_Doc.PRDQ_FReso = Convert.ToString(dr["PRDQ_FReso"]);
            if (dr["PRDQ_FOpi"] != DBNull.Value) prod_Doc.PRDQ_FOpi = Convert.ToString(dr["PRDQ_FOpi"]);
            if (dr["PRDQ_FDeC"] != DBNull.Value) prod_Doc.PRDQ_FDeC = Convert.ToString(dr["PRDQ_FDeC"]);
            if (dr["PRDQ_Bak"] != DBNull.Value) prod_Doc.PRDQ_Bak = Convert.ToString(dr["PRDQ_Bak"]);
            if (dr["PRDQ_FDate"] != DBNull.Value) prod_Doc.PRDQ_FDate = Convert.ToString(dr["PRDQ_FDate"]);
            if (dr["PRDQ_IsScan"] != DBNull.Value) prod_Doc.PRDQ_IsScan = Convert.ToInt32(dr["PRDQ_IsScan"]);
            if (dr["PRDQ_IsNeed"] != DBNull.Value) prod_Doc.PRDQ_IsNeed = Convert.ToString(dr["PRDQ_IsNeed"]);
            if (dr["Stat"] != DBNull.Value) prod_Doc.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Doc.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Doc.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Doc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Doc.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return prod_Doc;
      }
      /// <summary>
      /// 获取指定的Prod_Doc对象集合
      /// </summary>
      public List<Prod_Doc> GetListByWhere(string strCondition)
      {
         List<Prod_Doc> ret = new List<Prod_Doc>();
         string sql = "SELECT  PRDQ_ID,PRDQ_Code,PRDQ_CompNo,PRDQ_CompCode,PRDQ_CompName,PRDQ_Name,PRDQ_Type,PRDQ_iType,PRDQ_Date,PRDQ_Owner,PRDQ_Plant,PRDQ_Result,PRDQ_FCode,PRDQ_FReso,PRDQ_FOpi,PRDQ_FDeC,PRDQ_Bak,PRDQ_FDate,PRDQ_IsScan,PRDQ_IsNeed,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Prod_Doc WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Prod_Doc prod_Doc = new Prod_Doc();
            if (dr["PRDQ_ID"] != DBNull.Value) prod_Doc.PRDQ_ID = Convert.ToDecimal(dr["PRDQ_ID"]);
            if (dr["PRDQ_Code"] != DBNull.Value) prod_Doc.PRDQ_Code = Convert.ToString(dr["PRDQ_Code"]);
            if (dr["PRDQ_CompNo"] != DBNull.Value) prod_Doc.PRDQ_CompNo = Convert.ToString(dr["PRDQ_CompNo"]);
            if (dr["PRDQ_CompCode"] != DBNull.Value) prod_Doc.PRDQ_CompCode = Convert.ToString(dr["PRDQ_CompCode"]);
            if (dr["PRDQ_CompName"] != DBNull.Value) prod_Doc.PRDQ_CompName = Convert.ToString(dr["PRDQ_CompName"]);
            if (dr["PRDQ_Name"] != DBNull.Value) prod_Doc.PRDQ_Name = Convert.ToString(dr["PRDQ_Name"]);
            if (dr["PRDQ_Type"] != DBNull.Value) prod_Doc.PRDQ_Type = Convert.ToString(dr["PRDQ_Type"]);
            if (dr["PRDQ_iType"] != DBNull.Value) prod_Doc.PRDQ_iType = Convert.ToString(dr["PRDQ_iType"]);
            if (dr["PRDQ_Date"] != DBNull.Value) prod_Doc.PRDQ_Date = Convert.ToString(dr["PRDQ_Date"]);
            if (dr["PRDQ_Owner"] != DBNull.Value) prod_Doc.PRDQ_Owner = Convert.ToString(dr["PRDQ_Owner"]);
            if (dr["PRDQ_Plant"] != DBNull.Value) prod_Doc.PRDQ_Plant = Convert.ToString(dr["PRDQ_Plant"]);
            if (dr["PRDQ_Result"] != DBNull.Value) prod_Doc.PRDQ_Result = Convert.ToString(dr["PRDQ_Result"]);
            if (dr["PRDQ_FCode"] != DBNull.Value) prod_Doc.PRDQ_FCode = Convert.ToString(dr["PRDQ_FCode"]);
            if (dr["PRDQ_FReso"] != DBNull.Value) prod_Doc.PRDQ_FReso = Convert.ToString(dr["PRDQ_FReso"]);
            if (dr["PRDQ_FOpi"] != DBNull.Value) prod_Doc.PRDQ_FOpi = Convert.ToString(dr["PRDQ_FOpi"]);
            if (dr["PRDQ_FDeC"] != DBNull.Value) prod_Doc.PRDQ_FDeC = Convert.ToString(dr["PRDQ_FDeC"]);
            if (dr["PRDQ_Bak"] != DBNull.Value) prod_Doc.PRDQ_Bak = Convert.ToString(dr["PRDQ_Bak"]);
            if (dr["PRDQ_FDate"] != DBNull.Value) prod_Doc.PRDQ_FDate = Convert.ToString(dr["PRDQ_FDate"]);
            if (dr["PRDQ_IsScan"] != DBNull.Value) prod_Doc.PRDQ_IsScan = Convert.ToInt32(dr["PRDQ_IsScan"]);
            if (dr["PRDQ_IsNeed"] != DBNull.Value) prod_Doc.PRDQ_IsNeed = Convert.ToString(dr["PRDQ_IsNeed"]);
            if (dr["Stat"] != DBNull.Value) prod_Doc.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Doc.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Doc.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Doc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Doc.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(prod_Doc);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Prod_Doc对象(即:一条记录
      /// </summary>
      public List<Prod_Doc> GetAll()
      {
         List<Prod_Doc> ret = new List<Prod_Doc>();
         string sql = "SELECT  PRDQ_ID,PRDQ_Code,PRDQ_CompNo,PRDQ_CompCode,PRDQ_CompName,PRDQ_Name,PRDQ_Type,PRDQ_iType,PRDQ_Date,PRDQ_Owner,PRDQ_Plant,PRDQ_Result,PRDQ_FCode,PRDQ_FReso,PRDQ_FOpi,PRDQ_FDeC,PRDQ_Bak,PRDQ_FDate,PRDQ_IsScan,PRDQ_IsNeed,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Prod_Doc where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Prod_Doc prod_Doc = new Prod_Doc();
            if (dr["PRDQ_ID"] != DBNull.Value) prod_Doc.PRDQ_ID = Convert.ToDecimal(dr["PRDQ_ID"]);
            if (dr["PRDQ_Code"] != DBNull.Value) prod_Doc.PRDQ_Code = Convert.ToString(dr["PRDQ_Code"]);
            if (dr["PRDQ_CompNo"] != DBNull.Value) prod_Doc.PRDQ_CompNo = Convert.ToString(dr["PRDQ_CompNo"]);
            if (dr["PRDQ_CompCode"] != DBNull.Value) prod_Doc.PRDQ_CompCode = Convert.ToString(dr["PRDQ_CompCode"]);
            if (dr["PRDQ_CompName"] != DBNull.Value) prod_Doc.PRDQ_CompName = Convert.ToString(dr["PRDQ_CompName"]);
            if (dr["PRDQ_Name"] != DBNull.Value) prod_Doc.PRDQ_Name = Convert.ToString(dr["PRDQ_Name"]);
            if (dr["PRDQ_Type"] != DBNull.Value) prod_Doc.PRDQ_Type = Convert.ToString(dr["PRDQ_Type"]);
            if (dr["PRDQ_iType"] != DBNull.Value) prod_Doc.PRDQ_iType = Convert.ToString(dr["PRDQ_iType"]);
            if (dr["PRDQ_Date"] != DBNull.Value) prod_Doc.PRDQ_Date = Convert.ToString(dr["PRDQ_Date"]);
            if (dr["PRDQ_Owner"] != DBNull.Value) prod_Doc.PRDQ_Owner = Convert.ToString(dr["PRDQ_Owner"]);
            if (dr["PRDQ_Plant"] != DBNull.Value) prod_Doc.PRDQ_Plant = Convert.ToString(dr["PRDQ_Plant"]);
            if (dr["PRDQ_Result"] != DBNull.Value) prod_Doc.PRDQ_Result = Convert.ToString(dr["PRDQ_Result"]);
            if (dr["PRDQ_FCode"] != DBNull.Value) prod_Doc.PRDQ_FCode = Convert.ToString(dr["PRDQ_FCode"]);
            if (dr["PRDQ_FReso"] != DBNull.Value) prod_Doc.PRDQ_FReso = Convert.ToString(dr["PRDQ_FReso"]);
            if (dr["PRDQ_FOpi"] != DBNull.Value) prod_Doc.PRDQ_FOpi = Convert.ToString(dr["PRDQ_FOpi"]);
            if (dr["PRDQ_FDeC"] != DBNull.Value) prod_Doc.PRDQ_FDeC = Convert.ToString(dr["PRDQ_FDeC"]);
            if (dr["PRDQ_Bak"] != DBNull.Value) prod_Doc.PRDQ_Bak = Convert.ToString(dr["PRDQ_Bak"]);
            if (dr["PRDQ_FDate"] != DBNull.Value) prod_Doc.PRDQ_FDate = Convert.ToString(dr["PRDQ_FDate"]);
            if (dr["PRDQ_IsScan"] != DBNull.Value) prod_Doc.PRDQ_IsScan = Convert.ToInt32(dr["PRDQ_IsScan"]);
            if (dr["PRDQ_IsNeed"] != DBNull.Value) prod_Doc.PRDQ_IsNeed = Convert.ToString(dr["PRDQ_IsNeed"]);
            if (dr["Stat"] != DBNull.Value) prod_Doc.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Doc.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Doc.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Doc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Doc.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(prod_Doc);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
