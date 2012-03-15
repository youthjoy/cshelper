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
   public partial class ADOCC_File
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加CC_File对象(即:一条记录)
      /// </summary>
      public int Add(CC_File cC_File)
      {
         string sql = "INSERT INTO CC_File (CCF_Code,CCF_DCode,CCF_CompNo,CCF_Name,CCF_iType,CCF_Directory,CCF_Bak,CCF_DownTime,CCF_RCount,CCF_RDirectory,CCF_ROwner,CCF_RDate,CCF_RBak,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@CCF_Code,@CCF_DCode,@CCF_CompNo,@CCF_Name,@CCF_iType,@CCF_Directory,@CCF_Bak,@CCF_DownTime,@CCF_RCount,@CCF_RDirectory,@CCF_ROwner,@CCF_RDate,@CCF_RBak,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime)";
         if (string.IsNullOrEmpty(cC_File.CCF_Code))
         {
            idb.AddParameter("@CCF_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Code", cC_File.CCF_Code);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_DCode))
         {
            idb.AddParameter("@CCF_DCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_DCode", cC_File.CCF_DCode);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_CompNo))
         {
            idb.AddParameter("@CCF_CompNo", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_CompNo", cC_File.CCF_CompNo);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_Name))
         {
            idb.AddParameter("@CCF_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Name", cC_File.CCF_Name);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_iType))
         {
            idb.AddParameter("@CCF_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_iType", cC_File.CCF_iType);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_Directory))
         {
            idb.AddParameter("@CCF_Directory", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Directory", cC_File.CCF_Directory);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_Bak))
         {
            idb.AddParameter("@CCF_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Bak", cC_File.CCF_Bak);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_DownTime))
         {
            idb.AddParameter("@CCF_DownTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_DownTime", cC_File.CCF_DownTime);
         }
         if (cC_File.CCF_RCount == 0)
         {
            idb.AddParameter("@CCF_RCount", 0);
         }
         else
         {
            idb.AddParameter("@CCF_RCount", cC_File.CCF_RCount);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_RDirectory))
         {
            idb.AddParameter("@CCF_RDirectory", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_RDirectory", cC_File.CCF_RDirectory);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_ROwner))
         {
            idb.AddParameter("@CCF_ROwner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_ROwner", cC_File.CCF_ROwner);
         }
         if (cC_File.CCF_RDate == DateTime.MinValue)
         {
            idb.AddParameter("@CCF_RDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_RDate", cC_File.CCF_RDate);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_RBak))
         {
            idb.AddParameter("@CCF_RBak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_RBak", cC_File.CCF_RBak);
         }
         if (cC_File.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", cC_File.Stat);
         }
         if (cC_File.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", cC_File.Creator);
         }
         if (cC_File.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", cC_File.CreateTime);
         }
         if (cC_File.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", cC_File.UpdateTime);
         }
         if (cC_File.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", cC_File.DeleteTime);
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
      /// 添加CC_File对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(CC_File cC_File)
      {
         string sql = "INSERT INTO CC_File (CCF_Code,CCF_DCode,CCF_CompNo,CCF_Name,CCF_iType,CCF_Directory,CCF_Bak,CCF_DownTime,CCF_RCount,CCF_RDirectory,CCF_ROwner,CCF_RDate,CCF_RBak,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@CCF_Code,@CCF_DCode,@CCF_CompNo,@CCF_Name,@CCF_iType,@CCF_Directory,@CCF_Bak,@CCF_DownTime,@CCF_RCount,@CCF_RDirectory,@CCF_ROwner,@CCF_RDate,@CCF_RBak,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(cC_File.CCF_Code))
         {
            idb.AddParameter("@CCF_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Code", cC_File.CCF_Code);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_DCode))
         {
            idb.AddParameter("@CCF_DCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_DCode", cC_File.CCF_DCode);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_CompNo))
         {
            idb.AddParameter("@CCF_CompNo", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_CompNo", cC_File.CCF_CompNo);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_Name))
         {
            idb.AddParameter("@CCF_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Name", cC_File.CCF_Name);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_iType))
         {
            idb.AddParameter("@CCF_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_iType", cC_File.CCF_iType);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_Directory))
         {
            idb.AddParameter("@CCF_Directory", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Directory", cC_File.CCF_Directory);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_Bak))
         {
            idb.AddParameter("@CCF_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Bak", cC_File.CCF_Bak);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_DownTime))
         {
            idb.AddParameter("@CCF_DownTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_DownTime", cC_File.CCF_DownTime);
         }
         if (cC_File.CCF_RCount == 0)
         {
            idb.AddParameter("@CCF_RCount", 0);
         }
         else
         {
            idb.AddParameter("@CCF_RCount", cC_File.CCF_RCount);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_RDirectory))
         {
            idb.AddParameter("@CCF_RDirectory", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_RDirectory", cC_File.CCF_RDirectory);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_ROwner))
         {
            idb.AddParameter("@CCF_ROwner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_ROwner", cC_File.CCF_ROwner);
         }
         if (cC_File.CCF_RDate == DateTime.MinValue)
         {
            idb.AddParameter("@CCF_RDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_RDate", cC_File.CCF_RDate);
         }
         if (string.IsNullOrEmpty(cC_File.CCF_RBak))
         {
            idb.AddParameter("@CCF_RBak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_RBak", cC_File.CCF_RBak);
         }
         if (cC_File.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", cC_File.Stat);
         }
         if (cC_File.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", cC_File.Creator);
         }
         if (cC_File.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", cC_File.CreateTime);
         }
         if (cC_File.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", cC_File.UpdateTime);
         }
         if (cC_File.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", cC_File.DeleteTime);
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
      /// 更新CC_File对象(即:一条记录
      /// </summary>
      public int Update(CC_File cC_File)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       CC_File       SET ");
            if(cC_File.CCF_Code_IsChanged){sbParameter.Append("CCF_Code=@CCF_Code, ");}
      if(cC_File.CCF_DCode_IsChanged){sbParameter.Append("CCF_DCode=@CCF_DCode, ");}
      if(cC_File.CCF_CompNo_IsChanged){sbParameter.Append("CCF_CompNo=@CCF_CompNo, ");}
      if(cC_File.CCF_Name_IsChanged){sbParameter.Append("CCF_Name=@CCF_Name, ");}
      if(cC_File.CCF_iType_IsChanged){sbParameter.Append("CCF_iType=@CCF_iType, ");}
      if(cC_File.CCF_Directory_IsChanged){sbParameter.Append("CCF_Directory=@CCF_Directory, ");}
      if(cC_File.CCF_Bak_IsChanged){sbParameter.Append("CCF_Bak=@CCF_Bak, ");}
      if(cC_File.CCF_DownTime_IsChanged){sbParameter.Append("CCF_DownTime=@CCF_DownTime, ");}
      if(cC_File.CCF_RCount_IsChanged){sbParameter.Append("CCF_RCount=@CCF_RCount, ");}
      if(cC_File.CCF_RDirectory_IsChanged){sbParameter.Append("CCF_RDirectory=@CCF_RDirectory, ");}
      if(cC_File.CCF_ROwner_IsChanged){sbParameter.Append("CCF_ROwner=@CCF_ROwner, ");}
      if(cC_File.CCF_RDate_IsChanged){sbParameter.Append("CCF_RDate=@CCF_RDate, ");}
      if(cC_File.CCF_RBak_IsChanged){sbParameter.Append("CCF_RBak=@CCF_RBak, ");}
      if(cC_File.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(cC_File.Creator_IsChanged){sbParameter.Append("Creator=@Creator, ");}
      if(cC_File.CreateTime_IsChanged){sbParameter.Append("CreateTime=@CreateTime, ");}
      if(cC_File.UpdateTime_IsChanged){sbParameter.Append("UpdateTime=@UpdateTime, ");}
      if(cC_File.DeleteTime_IsChanged){sbParameter.Append("DeleteTime=@DeleteTime ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and CCF_ID=@CCF_ID; " );
      string sql=sb.ToString();
         if(cC_File.CCF_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_Code))
         {
            idb.AddParameter("@CCF_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Code", cC_File.CCF_Code);
         }
          }
         if(cC_File.CCF_DCode_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_DCode))
         {
            idb.AddParameter("@CCF_DCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_DCode", cC_File.CCF_DCode);
         }
          }
         if(cC_File.CCF_CompNo_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_CompNo))
         {
            idb.AddParameter("@CCF_CompNo", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_CompNo", cC_File.CCF_CompNo);
         }
          }
         if(cC_File.CCF_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_Name))
         {
            idb.AddParameter("@CCF_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Name", cC_File.CCF_Name);
         }
          }
         if(cC_File.CCF_iType_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_iType))
         {
            idb.AddParameter("@CCF_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_iType", cC_File.CCF_iType);
         }
          }
         if(cC_File.CCF_Directory_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_Directory))
         {
            idb.AddParameter("@CCF_Directory", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Directory", cC_File.CCF_Directory);
         }
          }
         if(cC_File.CCF_Bak_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_Bak))
         {
            idb.AddParameter("@CCF_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_Bak", cC_File.CCF_Bak);
         }
          }
         if(cC_File.CCF_DownTime_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_DownTime))
         {
            idb.AddParameter("@CCF_DownTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_DownTime", cC_File.CCF_DownTime);
         }
          }
         if(cC_File.CCF_RCount_IsChanged)
         {
         if (cC_File.CCF_RCount == 0)
         {
            idb.AddParameter("@CCF_RCount", 0);
         }
         else
         {
            idb.AddParameter("@CCF_RCount", cC_File.CCF_RCount);
         }
          }
         if(cC_File.CCF_RDirectory_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_RDirectory))
         {
            idb.AddParameter("@CCF_RDirectory", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_RDirectory", cC_File.CCF_RDirectory);
         }
          }
         if(cC_File.CCF_ROwner_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_ROwner))
         {
            idb.AddParameter("@CCF_ROwner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_ROwner", cC_File.CCF_ROwner);
         }
          }
         if(cC_File.CCF_RDate_IsChanged)
         {
         if (cC_File.CCF_RDate == DateTime.MinValue)
         {
            idb.AddParameter("@CCF_RDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_RDate", cC_File.CCF_RDate);
         }
          }
         if(cC_File.CCF_RBak_IsChanged)
         {
         if (string.IsNullOrEmpty(cC_File.CCF_RBak))
         {
            idb.AddParameter("@CCF_RBak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CCF_RBak", cC_File.CCF_RBak);
         }
          }
         if(cC_File.Stat_IsChanged)
         {
         if (cC_File.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", cC_File.Stat);
         }
          }
         if(cC_File.Creator_IsChanged)
         {
         if (cC_File.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", cC_File.Creator);
         }
          }
         if(cC_File.CreateTime_IsChanged)
         {
         if (cC_File.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", cC_File.CreateTime);
         }
          }
         if(cC_File.UpdateTime_IsChanged)
         {
         if (cC_File.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", cC_File.UpdateTime);
         }
          }
         if(cC_File.DeleteTime_IsChanged)
         {
         if (cC_File.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", cC_File.DeleteTime);
         }
          }

         idb.AddParameter("@CCF_ID", cC_File.CCF_ID);


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
      /// 删除CC_File对象(即:一条记录
      /// </summary>
      public int Delete(decimal cCF_ID)
      {
         string sql = "DELETE CC_File WHERE 1=1  AND CCF_ID=@CCF_ID ";
         idb.AddParameter("@CCF_ID", cCF_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的CC_File对象(即:一条记录
      /// </summary>
      public CC_File GetByKey(decimal cCF_ID)
      {
         CC_File cC_File = new CC_File();
         string sql = "SELECT  CCF_ID,CCF_Code,CCF_DCode,CCF_CompNo,CCF_Name,CCF_iType,CCF_Directory,CCF_Bak,CCF_DownTime,CCF_RCount,CCF_RDirectory,CCF_ROwner,CCF_RDate,CCF_RBak,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM CC_File WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND CCF_ID=@CCF_ID ";
         idb.AddParameter("@CCF_ID", cCF_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["CCF_ID"] != DBNull.Value) cC_File.CCF_ID = Convert.ToDecimal(dr["CCF_ID"]);
            if (dr["CCF_Code"] != DBNull.Value) cC_File.CCF_Code = Convert.ToString(dr["CCF_Code"]);
            if (dr["CCF_DCode"] != DBNull.Value) cC_File.CCF_DCode = Convert.ToString(dr["CCF_DCode"]);
            if (dr["CCF_CompNo"] != DBNull.Value) cC_File.CCF_CompNo = Convert.ToString(dr["CCF_CompNo"]);
            if (dr["CCF_Name"] != DBNull.Value) cC_File.CCF_Name = Convert.ToString(dr["CCF_Name"]);
            if (dr["CCF_iType"] != DBNull.Value) cC_File.CCF_iType = Convert.ToString(dr["CCF_iType"]);
            if (dr["CCF_Directory"] != DBNull.Value) cC_File.CCF_Directory = Convert.ToString(dr["CCF_Directory"]);
            if (dr["CCF_Bak"] != DBNull.Value) cC_File.CCF_Bak = Convert.ToString(dr["CCF_Bak"]);
            if (dr["CCF_DownTime"] != DBNull.Value) cC_File.CCF_DownTime = Convert.ToString(dr["CCF_DownTime"]);
            if (dr["CCF_RCount"] != DBNull.Value) cC_File.CCF_RCount = Convert.ToInt32(dr["CCF_RCount"]);
            if (dr["CCF_RDirectory"] != DBNull.Value) cC_File.CCF_RDirectory = Convert.ToString(dr["CCF_RDirectory"]);
            if (dr["CCF_ROwner"] != DBNull.Value) cC_File.CCF_ROwner = Convert.ToString(dr["CCF_ROwner"]);
            if (dr["CCF_RDate"] != DBNull.Value) cC_File.CCF_RDate = Convert.ToDateTime(dr["CCF_RDate"]);
            if (dr["CCF_RBak"] != DBNull.Value) cC_File.CCF_RBak = Convert.ToString(dr["CCF_RBak"]);
            if (dr["Stat"] != DBNull.Value) cC_File.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) cC_File.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) cC_File.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) cC_File.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) cC_File.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return cC_File;
      }
      /// <summary>
      /// 获取指定的CC_File对象集合
      /// </summary>
      public List<CC_File> GetListByWhere(string strCondition)
      {
         List<CC_File> ret = new List<CC_File>();
         string sql = "SELECT  CCF_ID,CCF_Code,CCF_DCode,CCF_CompNo,CCF_Name,CCF_iType,CCF_Directory,CCF_Bak,CCF_DownTime,CCF_RCount,CCF_RDirectory,CCF_ROwner,CCF_RDate,CCF_RBak,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM CC_File WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            CC_File cC_File = new CC_File();
            if (dr["CCF_ID"] != DBNull.Value) cC_File.CCF_ID = Convert.ToDecimal(dr["CCF_ID"]);
            if (dr["CCF_Code"] != DBNull.Value) cC_File.CCF_Code = Convert.ToString(dr["CCF_Code"]);
            if (dr["CCF_DCode"] != DBNull.Value) cC_File.CCF_DCode = Convert.ToString(dr["CCF_DCode"]);
            if (dr["CCF_CompNo"] != DBNull.Value) cC_File.CCF_CompNo = Convert.ToString(dr["CCF_CompNo"]);
            if (dr["CCF_Name"] != DBNull.Value) cC_File.CCF_Name = Convert.ToString(dr["CCF_Name"]);
            if (dr["CCF_iType"] != DBNull.Value) cC_File.CCF_iType = Convert.ToString(dr["CCF_iType"]);
            if (dr["CCF_Directory"] != DBNull.Value) cC_File.CCF_Directory = Convert.ToString(dr["CCF_Directory"]);
            if (dr["CCF_Bak"] != DBNull.Value) cC_File.CCF_Bak = Convert.ToString(dr["CCF_Bak"]);
            if (dr["CCF_DownTime"] != DBNull.Value) cC_File.CCF_DownTime = Convert.ToString(dr["CCF_DownTime"]);
            if (dr["CCF_RCount"] != DBNull.Value) cC_File.CCF_RCount = Convert.ToInt32(dr["CCF_RCount"]);
            if (dr["CCF_RDirectory"] != DBNull.Value) cC_File.CCF_RDirectory = Convert.ToString(dr["CCF_RDirectory"]);
            if (dr["CCF_ROwner"] != DBNull.Value) cC_File.CCF_ROwner = Convert.ToString(dr["CCF_ROwner"]);
            if (dr["CCF_RDate"] != DBNull.Value) cC_File.CCF_RDate = Convert.ToDateTime(dr["CCF_RDate"]);
            if (dr["CCF_RBak"] != DBNull.Value) cC_File.CCF_RBak = Convert.ToString(dr["CCF_RBak"]);
            if (dr["Stat"] != DBNull.Value) cC_File.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) cC_File.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) cC_File.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) cC_File.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) cC_File.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(cC_File);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的CC_File对象(即:一条记录
      /// </summary>
      public List<CC_File> GetAll()
      {
         List<CC_File> ret = new List<CC_File>();
         string sql = "SELECT  CCF_ID,CCF_Code,CCF_DCode,CCF_CompNo,CCF_Name,CCF_iType,CCF_Directory,CCF_Bak,CCF_DownTime,CCF_RCount,CCF_RDirectory,CCF_ROwner,CCF_RDate,CCF_RBak,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM CC_File where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            CC_File cC_File = new CC_File();
            if (dr["CCF_ID"] != DBNull.Value) cC_File.CCF_ID = Convert.ToDecimal(dr["CCF_ID"]);
            if (dr["CCF_Code"] != DBNull.Value) cC_File.CCF_Code = Convert.ToString(dr["CCF_Code"]);
            if (dr["CCF_DCode"] != DBNull.Value) cC_File.CCF_DCode = Convert.ToString(dr["CCF_DCode"]);
            if (dr["CCF_CompNo"] != DBNull.Value) cC_File.CCF_CompNo = Convert.ToString(dr["CCF_CompNo"]);
            if (dr["CCF_Name"] != DBNull.Value) cC_File.CCF_Name = Convert.ToString(dr["CCF_Name"]);
            if (dr["CCF_iType"] != DBNull.Value) cC_File.CCF_iType = Convert.ToString(dr["CCF_iType"]);
            if (dr["CCF_Directory"] != DBNull.Value) cC_File.CCF_Directory = Convert.ToString(dr["CCF_Directory"]);
            if (dr["CCF_Bak"] != DBNull.Value) cC_File.CCF_Bak = Convert.ToString(dr["CCF_Bak"]);
            if (dr["CCF_DownTime"] != DBNull.Value) cC_File.CCF_DownTime = Convert.ToString(dr["CCF_DownTime"]);
            if (dr["CCF_RCount"] != DBNull.Value) cC_File.CCF_RCount = Convert.ToInt32(dr["CCF_RCount"]);
            if (dr["CCF_RDirectory"] != DBNull.Value) cC_File.CCF_RDirectory = Convert.ToString(dr["CCF_RDirectory"]);
            if (dr["CCF_ROwner"] != DBNull.Value) cC_File.CCF_ROwner = Convert.ToString(dr["CCF_ROwner"]);
            if (dr["CCF_RDate"] != DBNull.Value) cC_File.CCF_RDate = Convert.ToDateTime(dr["CCF_RDate"]);
            if (dr["CCF_RBak"] != DBNull.Value) cC_File.CCF_RBak = Convert.ToString(dr["CCF_RBak"]);
            if (dr["Stat"] != DBNull.Value) cC_File.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) cC_File.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) cC_File.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) cC_File.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) cC_File.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(cC_File);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
