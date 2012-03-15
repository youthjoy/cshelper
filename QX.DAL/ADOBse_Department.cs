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
   /// 部门信息维护
   /// </summary>
   [Serializable]
   public partial class ADOBse_Department
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加部门信息维护 Bse_Department对象(即:一条记录)
      /// </summary>
      public int Add(Bse_Department bse_Department)
      {
         string sql = "INSERT INTO Bse_Department (Dept_Code,Dept_Name,Dept_PCode,Dept_PName,Dept_Owner,Dept_OwnerName,Dept_OTel,Dept_OMob,Dept_Num,Dept_IsLeaf,Dept_Level,Dept_SimpleCode,Dept_SimpleName,Stat,Dept_Stat,Dept_Desp,Dept_Bak,Dept_Date) VALUES (@Dept_Code,@Dept_Name,@Dept_PCode,@Dept_PName,@Dept_Owner,@Dept_OwnerName,@Dept_OTel,@Dept_OMob,@Dept_Num,@Dept_IsLeaf,@Dept_Level,@Dept_SimpleCode,@Dept_SimpleName,@Stat,@Dept_Stat,@Dept_Desp,@Dept_Bak,@Dept_Date)";
         if (string.IsNullOrEmpty(bse_Department.Dept_Code))
         {
            idb.AddParameter("@Dept_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Code", bse_Department.Dept_Code);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Name))
         {
            idb.AddParameter("@Dept_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Name", bse_Department.Dept_Name);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_PCode))
         {
            idb.AddParameter("@Dept_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_PCode", bse_Department.Dept_PCode);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_PName))
         {
            idb.AddParameter("@Dept_PName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_PName", bse_Department.Dept_PName);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Owner))
         {
            idb.AddParameter("@Dept_Owner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Owner", bse_Department.Dept_Owner);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_OwnerName))
         {
            idb.AddParameter("@Dept_OwnerName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_OwnerName", bse_Department.Dept_OwnerName);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_OTel))
         {
            idb.AddParameter("@Dept_OTel", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_OTel", bse_Department.Dept_OTel);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_OMob))
         {
            idb.AddParameter("@Dept_OMob", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_OMob", bse_Department.Dept_OMob);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Num))
         {
            idb.AddParameter("@Dept_Num", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Num", bse_Department.Dept_Num);
         }
         if (bse_Department.Dept_IsLeaf == 0)
         {
            idb.AddParameter("@Dept_IsLeaf", 0);
         }
         else
         {
            idb.AddParameter("@Dept_IsLeaf", bse_Department.Dept_IsLeaf);
         }
         if (bse_Department.Dept_Level == 0)
         {
            idb.AddParameter("@Dept_Level", 0);
         }
         else
         {
            idb.AddParameter("@Dept_Level", bse_Department.Dept_Level);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_SimpleCode))
         {
            idb.AddParameter("@Dept_SimpleCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_SimpleCode", bse_Department.Dept_SimpleCode);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_SimpleName))
         {
            idb.AddParameter("@Dept_SimpleName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_SimpleName", bse_Department.Dept_SimpleName);
         }
         if (bse_Department.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", bse_Department.Stat);
         }
         if (bse_Department.Dept_Stat == 0)
         {
            idb.AddParameter("@Dept_Stat", 0);
         }
         else
         {
            idb.AddParameter("@Dept_Stat", bse_Department.Dept_Stat);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Desp))
         {
            idb.AddParameter("@Dept_Desp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Desp", bse_Department.Dept_Desp);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Bak))
         {
            idb.AddParameter("@Dept_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Bak", bse_Department.Dept_Bak);
         }
         if (bse_Department.Dept_Date == DateTime.MinValue)
         {
            idb.AddParameter("@Dept_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Date", bse_Department.Dept_Date);
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
      /// 添加部门信息维护 Bse_Department对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Bse_Department bse_Department)
      {
         string sql = "INSERT INTO Bse_Department (Dept_Code,Dept_Name,Dept_PCode,Dept_PName,Dept_Owner,Dept_OwnerName,Dept_OTel,Dept_OMob,Dept_Num,Dept_IsLeaf,Dept_Level,Dept_SimpleCode,Dept_SimpleName,Stat,Dept_Stat,Dept_Desp,Dept_Bak,Dept_Date) VALUES (@Dept_Code,@Dept_Name,@Dept_PCode,@Dept_PName,@Dept_Owner,@Dept_OwnerName,@Dept_OTel,@Dept_OMob,@Dept_Num,@Dept_IsLeaf,@Dept_Level,@Dept_SimpleCode,@Dept_SimpleName,@Stat,@Dept_Stat,@Dept_Desp,@Dept_Bak,@Dept_Date);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(bse_Department.Dept_Code))
         {
            idb.AddParameter("@Dept_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Code", bse_Department.Dept_Code);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Name))
         {
            idb.AddParameter("@Dept_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Name", bse_Department.Dept_Name);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_PCode))
         {
            idb.AddParameter("@Dept_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_PCode", bse_Department.Dept_PCode);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_PName))
         {
            idb.AddParameter("@Dept_PName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_PName", bse_Department.Dept_PName);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Owner))
         {
            idb.AddParameter("@Dept_Owner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Owner", bse_Department.Dept_Owner);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_OwnerName))
         {
            idb.AddParameter("@Dept_OwnerName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_OwnerName", bse_Department.Dept_OwnerName);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_OTel))
         {
            idb.AddParameter("@Dept_OTel", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_OTel", bse_Department.Dept_OTel);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_OMob))
         {
            idb.AddParameter("@Dept_OMob", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_OMob", bse_Department.Dept_OMob);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Num))
         {
            idb.AddParameter("@Dept_Num", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Num", bse_Department.Dept_Num);
         }
         if (bse_Department.Dept_IsLeaf == 0)
         {
            idb.AddParameter("@Dept_IsLeaf", 0);
         }
         else
         {
            idb.AddParameter("@Dept_IsLeaf", bse_Department.Dept_IsLeaf);
         }
         if (bse_Department.Dept_Level == 0)
         {
            idb.AddParameter("@Dept_Level", 0);
         }
         else
         {
            idb.AddParameter("@Dept_Level", bse_Department.Dept_Level);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_SimpleCode))
         {
            idb.AddParameter("@Dept_SimpleCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_SimpleCode", bse_Department.Dept_SimpleCode);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_SimpleName))
         {
            idb.AddParameter("@Dept_SimpleName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_SimpleName", bse_Department.Dept_SimpleName);
         }
         if (bse_Department.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", bse_Department.Stat);
         }
         if (bse_Department.Dept_Stat == 0)
         {
            idb.AddParameter("@Dept_Stat", 0);
         }
         else
         {
            idb.AddParameter("@Dept_Stat", bse_Department.Dept_Stat);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Desp))
         {
            idb.AddParameter("@Dept_Desp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Desp", bse_Department.Dept_Desp);
         }
         if (string.IsNullOrEmpty(bse_Department.Dept_Bak))
         {
            idb.AddParameter("@Dept_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Bak", bse_Department.Dept_Bak);
         }
         if (bse_Department.Dept_Date == DateTime.MinValue)
         {
            idb.AddParameter("@Dept_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Date", bse_Department.Dept_Date);
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
      /// 更新部门信息维护 Bse_Department对象(即:一条记录
      /// </summary>
      public int Update(Bse_Department bse_Department)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Bse_Department       SET ");
            if(bse_Department.Dept_Code_IsChanged){sbParameter.Append("Dept_Code=@Dept_Code, ");}
      if(bse_Department.Dept_Name_IsChanged){sbParameter.Append("Dept_Name=@Dept_Name, ");}
      if(bse_Department.Dept_PCode_IsChanged){sbParameter.Append("Dept_PCode=@Dept_PCode, ");}
      if(bse_Department.Dept_PName_IsChanged){sbParameter.Append("Dept_PName=@Dept_PName, ");}
      if(bse_Department.Dept_Owner_IsChanged){sbParameter.Append("Dept_Owner=@Dept_Owner, ");}
      if(bse_Department.Dept_OwnerName_IsChanged){sbParameter.Append("Dept_OwnerName=@Dept_OwnerName, ");}
      if(bse_Department.Dept_OTel_IsChanged){sbParameter.Append("Dept_OTel=@Dept_OTel, ");}
      if(bse_Department.Dept_OMob_IsChanged){sbParameter.Append("Dept_OMob=@Dept_OMob, ");}
      if(bse_Department.Dept_Num_IsChanged){sbParameter.Append("Dept_Num=@Dept_Num, ");}
      if(bse_Department.Dept_IsLeaf_IsChanged){sbParameter.Append("Dept_IsLeaf=@Dept_IsLeaf, ");}
      if(bse_Department.Dept_Level_IsChanged){sbParameter.Append("Dept_Level=@Dept_Level, ");}
      if(bse_Department.Dept_SimpleCode_IsChanged){sbParameter.Append("Dept_SimpleCode=@Dept_SimpleCode, ");}
      if(bse_Department.Dept_SimpleName_IsChanged){sbParameter.Append("Dept_SimpleName=@Dept_SimpleName, ");}
      if(bse_Department.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(bse_Department.Dept_Stat_IsChanged){sbParameter.Append("Dept_Stat=@Dept_Stat, ");}
      if(bse_Department.Dept_Desp_IsChanged){sbParameter.Append("Dept_Desp=@Dept_Desp, ");}
      if(bse_Department.Dept_Bak_IsChanged){sbParameter.Append("Dept_Bak=@Dept_Bak, ");}
      if(bse_Department.Dept_Date_IsChanged){sbParameter.Append("Dept_Date=@Dept_Date ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and Dept_ID=@Dept_ID; " );
      string sql=sb.ToString();
         if(bse_Department.Dept_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_Code))
         {
            idb.AddParameter("@Dept_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Code", bse_Department.Dept_Code);
         }
          }
         if(bse_Department.Dept_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_Name))
         {
            idb.AddParameter("@Dept_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Name", bse_Department.Dept_Name);
         }
          }
         if(bse_Department.Dept_PCode_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_PCode))
         {
            idb.AddParameter("@Dept_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_PCode", bse_Department.Dept_PCode);
         }
          }
         if(bse_Department.Dept_PName_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_PName))
         {
            idb.AddParameter("@Dept_PName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_PName", bse_Department.Dept_PName);
         }
          }
         if(bse_Department.Dept_Owner_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_Owner))
         {
            idb.AddParameter("@Dept_Owner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Owner", bse_Department.Dept_Owner);
         }
          }
         if(bse_Department.Dept_OwnerName_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_OwnerName))
         {
            idb.AddParameter("@Dept_OwnerName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_OwnerName", bse_Department.Dept_OwnerName);
         }
          }
         if(bse_Department.Dept_OTel_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_OTel))
         {
            idb.AddParameter("@Dept_OTel", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_OTel", bse_Department.Dept_OTel);
         }
          }
         if(bse_Department.Dept_OMob_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_OMob))
         {
            idb.AddParameter("@Dept_OMob", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_OMob", bse_Department.Dept_OMob);
         }
          }
         if(bse_Department.Dept_Num_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_Num))
         {
            idb.AddParameter("@Dept_Num", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Num", bse_Department.Dept_Num);
         }
          }
         if(bse_Department.Dept_IsLeaf_IsChanged)
         {
         if (bse_Department.Dept_IsLeaf == 0)
         {
            idb.AddParameter("@Dept_IsLeaf", 0);
         }
         else
         {
            idb.AddParameter("@Dept_IsLeaf", bse_Department.Dept_IsLeaf);
         }
          }
         if(bse_Department.Dept_Level_IsChanged)
         {
         if (bse_Department.Dept_Level == 0)
         {
            idb.AddParameter("@Dept_Level", 0);
         }
         else
         {
            idb.AddParameter("@Dept_Level", bse_Department.Dept_Level);
         }
          }
         if(bse_Department.Dept_SimpleCode_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_SimpleCode))
         {
            idb.AddParameter("@Dept_SimpleCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_SimpleCode", bse_Department.Dept_SimpleCode);
         }
          }
         if(bse_Department.Dept_SimpleName_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_SimpleName))
         {
            idb.AddParameter("@Dept_SimpleName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_SimpleName", bse_Department.Dept_SimpleName);
         }
          }
         if(bse_Department.Stat_IsChanged)
         {
         if (bse_Department.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", bse_Department.Stat);
         }
          }
         if(bse_Department.Dept_Stat_IsChanged)
         {
         if (bse_Department.Dept_Stat == 0)
         {
            idb.AddParameter("@Dept_Stat", 0);
         }
         else
         {
            idb.AddParameter("@Dept_Stat", bse_Department.Dept_Stat);
         }
          }
         if(bse_Department.Dept_Desp_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_Desp))
         {
            idb.AddParameter("@Dept_Desp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Desp", bse_Department.Dept_Desp);
         }
          }
         if(bse_Department.Dept_Bak_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Department.Dept_Bak))
         {
            idb.AddParameter("@Dept_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Bak", bse_Department.Dept_Bak);
         }
          }
         if(bse_Department.Dept_Date_IsChanged)
         {
         if (bse_Department.Dept_Date == DateTime.MinValue)
         {
            idb.AddParameter("@Dept_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dept_Date", bse_Department.Dept_Date);
         }
          }

         idb.AddParameter("@Dept_ID", bse_Department.Dept_ID);


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
      /// 删除部门信息维护 Bse_Department对象(即:一条记录
      /// </summary>
      public int Delete(Int64 dept_ID)
      {
         string sql = "DELETE Bse_Department WHERE 1=1  AND Dept_ID=@Dept_ID ";
         idb.AddParameter("@Dept_ID", dept_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的部门信息维护 Bse_Department对象(即:一条记录
      /// </summary>
      public Bse_Department GetByKey(Int64 dept_ID)
      {
         Bse_Department bse_Department = new Bse_Department();
         string sql = "SELECT  Dept_ID,Dept_Code,Dept_Name,Dept_PCode,Dept_PName,Dept_Owner,Dept_OwnerName,Dept_OTel,Dept_OMob,Dept_Num,Dept_IsLeaf,Dept_Level,Dept_SimpleCode,Dept_SimpleName,Stat,Dept_Stat,Dept_Desp,Dept_Bak,Dept_Date FROM Bse_Department WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND Dept_ID=@Dept_ID ";
         idb.AddParameter("@Dept_ID", dept_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["Dept_ID"] != DBNull.Value) bse_Department.Dept_ID = Convert.ToInt64(dr["Dept_ID"]);
            if (dr["Dept_Code"] != DBNull.Value) bse_Department.Dept_Code = Convert.ToString(dr["Dept_Code"]);
            if (dr["Dept_Name"] != DBNull.Value) bse_Department.Dept_Name = Convert.ToString(dr["Dept_Name"]);
            if (dr["Dept_PCode"] != DBNull.Value) bse_Department.Dept_PCode = Convert.ToString(dr["Dept_PCode"]);
            if (dr["Dept_PName"] != DBNull.Value) bse_Department.Dept_PName = Convert.ToString(dr["Dept_PName"]);
            if (dr["Dept_Owner"] != DBNull.Value) bse_Department.Dept_Owner = Convert.ToString(dr["Dept_Owner"]);
            if (dr["Dept_OwnerName"] != DBNull.Value) bse_Department.Dept_OwnerName = Convert.ToString(dr["Dept_OwnerName"]);
            if (dr["Dept_OTel"] != DBNull.Value) bse_Department.Dept_OTel = Convert.ToString(dr["Dept_OTel"]);
            if (dr["Dept_OMob"] != DBNull.Value) bse_Department.Dept_OMob = Convert.ToString(dr["Dept_OMob"]);
            if (dr["Dept_Num"] != DBNull.Value) bse_Department.Dept_Num = Convert.ToString(dr["Dept_Num"]);
            if (dr["Dept_IsLeaf"] != DBNull.Value) bse_Department.Dept_IsLeaf = Convert.ToInt32(dr["Dept_IsLeaf"]);
            if (dr["Dept_Level"] != DBNull.Value) bse_Department.Dept_Level = Convert.ToInt32(dr["Dept_Level"]);
            if (dr["Dept_SimpleCode"] != DBNull.Value) bse_Department.Dept_SimpleCode = Convert.ToString(dr["Dept_SimpleCode"]);
            if (dr["Dept_SimpleName"] != DBNull.Value) bse_Department.Dept_SimpleName = Convert.ToString(dr["Dept_SimpleName"]);
            if (dr["Stat"] != DBNull.Value) bse_Department.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Dept_Stat"] != DBNull.Value) bse_Department.Dept_Stat = Convert.ToInt32(dr["Dept_Stat"]);
            if (dr["Dept_Desp"] != DBNull.Value) bse_Department.Dept_Desp = Convert.ToString(dr["Dept_Desp"]);
            if (dr["Dept_Bak"] != DBNull.Value) bse_Department.Dept_Bak = Convert.ToString(dr["Dept_Bak"]);
            if (dr["Dept_Date"] != DBNull.Value) bse_Department.Dept_Date = Convert.ToDateTime(dr["Dept_Date"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return bse_Department;
      }
      /// <summary>
      /// 获取指定的部门信息维护 Bse_Department对象集合
      /// </summary>
      public List<Bse_Department> GetListByWhere(string strCondition)
      {
         List<Bse_Department> ret = new List<Bse_Department>();
         string sql = "SELECT  Dept_ID,Dept_Code,Dept_Name,Dept_PCode,Dept_PName,Dept_Owner,Dept_OwnerName,Dept_OTel,Dept_OMob,Dept_Num,Dept_IsLeaf,Dept_Level,Dept_SimpleCode,Dept_SimpleName,Stat,Dept_Stat,Dept_Desp,Dept_Bak,Dept_Date FROM Bse_Department WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Bse_Department bse_Department = new Bse_Department();
            if (dr["Dept_ID"] != DBNull.Value) bse_Department.Dept_ID = Convert.ToInt64(dr["Dept_ID"]);
            if (dr["Dept_Code"] != DBNull.Value) bse_Department.Dept_Code = Convert.ToString(dr["Dept_Code"]);
            if (dr["Dept_Name"] != DBNull.Value) bse_Department.Dept_Name = Convert.ToString(dr["Dept_Name"]);
            if (dr["Dept_PCode"] != DBNull.Value) bse_Department.Dept_PCode = Convert.ToString(dr["Dept_PCode"]);
            if (dr["Dept_PName"] != DBNull.Value) bse_Department.Dept_PName = Convert.ToString(dr["Dept_PName"]);
            if (dr["Dept_Owner"] != DBNull.Value) bse_Department.Dept_Owner = Convert.ToString(dr["Dept_Owner"]);
            if (dr["Dept_OwnerName"] != DBNull.Value) bse_Department.Dept_OwnerName = Convert.ToString(dr["Dept_OwnerName"]);
            if (dr["Dept_OTel"] != DBNull.Value) bse_Department.Dept_OTel = Convert.ToString(dr["Dept_OTel"]);
            if (dr["Dept_OMob"] != DBNull.Value) bse_Department.Dept_OMob = Convert.ToString(dr["Dept_OMob"]);
            if (dr["Dept_Num"] != DBNull.Value) bse_Department.Dept_Num = Convert.ToString(dr["Dept_Num"]);
            if (dr["Dept_IsLeaf"] != DBNull.Value) bse_Department.Dept_IsLeaf = Convert.ToInt32(dr["Dept_IsLeaf"]);
            if (dr["Dept_Level"] != DBNull.Value) bse_Department.Dept_Level = Convert.ToInt32(dr["Dept_Level"]);
            if (dr["Dept_SimpleCode"] != DBNull.Value) bse_Department.Dept_SimpleCode = Convert.ToString(dr["Dept_SimpleCode"]);
            if (dr["Dept_SimpleName"] != DBNull.Value) bse_Department.Dept_SimpleName = Convert.ToString(dr["Dept_SimpleName"]);
            if (dr["Stat"] != DBNull.Value) bse_Department.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Dept_Stat"] != DBNull.Value) bse_Department.Dept_Stat = Convert.ToInt32(dr["Dept_Stat"]);
            if (dr["Dept_Desp"] != DBNull.Value) bse_Department.Dept_Desp = Convert.ToString(dr["Dept_Desp"]);
            if (dr["Dept_Bak"] != DBNull.Value) bse_Department.Dept_Bak = Convert.ToString(dr["Dept_Bak"]);
            if (dr["Dept_Date"] != DBNull.Value) bse_Department.Dept_Date = Convert.ToDateTime(dr["Dept_Date"]);
            ret.Add(bse_Department);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的部门信息维护 Bse_Department对象(即:一条记录
      /// </summary>
      public List<Bse_Department> GetAll()
      {
         List<Bse_Department> ret = new List<Bse_Department>();
         string sql = "SELECT  Dept_ID,Dept_Code,Dept_Name,Dept_PCode,Dept_PName,Dept_Owner,Dept_OwnerName,Dept_OTel,Dept_OMob,Dept_Num,Dept_IsLeaf,Dept_Level,Dept_SimpleCode,Dept_SimpleName,Stat,Dept_Stat,Dept_Desp,Dept_Bak,Dept_Date FROM Bse_Department where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Bse_Department bse_Department = new Bse_Department();
            if (dr["Dept_ID"] != DBNull.Value) bse_Department.Dept_ID = Convert.ToInt64(dr["Dept_ID"]);
            if (dr["Dept_Code"] != DBNull.Value) bse_Department.Dept_Code = Convert.ToString(dr["Dept_Code"]);
            if (dr["Dept_Name"] != DBNull.Value) bse_Department.Dept_Name = Convert.ToString(dr["Dept_Name"]);
            if (dr["Dept_PCode"] != DBNull.Value) bse_Department.Dept_PCode = Convert.ToString(dr["Dept_PCode"]);
            if (dr["Dept_PName"] != DBNull.Value) bse_Department.Dept_PName = Convert.ToString(dr["Dept_PName"]);
            if (dr["Dept_Owner"] != DBNull.Value) bse_Department.Dept_Owner = Convert.ToString(dr["Dept_Owner"]);
            if (dr["Dept_OwnerName"] != DBNull.Value) bse_Department.Dept_OwnerName = Convert.ToString(dr["Dept_OwnerName"]);
            if (dr["Dept_OTel"] != DBNull.Value) bse_Department.Dept_OTel = Convert.ToString(dr["Dept_OTel"]);
            if (dr["Dept_OMob"] != DBNull.Value) bse_Department.Dept_OMob = Convert.ToString(dr["Dept_OMob"]);
            if (dr["Dept_Num"] != DBNull.Value) bse_Department.Dept_Num = Convert.ToString(dr["Dept_Num"]);
            if (dr["Dept_IsLeaf"] != DBNull.Value) bse_Department.Dept_IsLeaf = Convert.ToInt32(dr["Dept_IsLeaf"]);
            if (dr["Dept_Level"] != DBNull.Value) bse_Department.Dept_Level = Convert.ToInt32(dr["Dept_Level"]);
            if (dr["Dept_SimpleCode"] != DBNull.Value) bse_Department.Dept_SimpleCode = Convert.ToString(dr["Dept_SimpleCode"]);
            if (dr["Dept_SimpleName"] != DBNull.Value) bse_Department.Dept_SimpleName = Convert.ToString(dr["Dept_SimpleName"]);
            if (dr["Stat"] != DBNull.Value) bse_Department.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Dept_Stat"] != DBNull.Value) bse_Department.Dept_Stat = Convert.ToInt32(dr["Dept_Stat"]);
            if (dr["Dept_Desp"] != DBNull.Value) bse_Department.Dept_Desp = Convert.ToString(dr["Dept_Desp"]);
            if (dr["Dept_Bak"] != DBNull.Value) bse_Department.Dept_Bak = Convert.ToString(dr["Dept_Bak"]);
            if (dr["Dept_Date"] != DBNull.Value) bse_Department.Dept_Date = Convert.ToDateTime(dr["Dept_Date"]);
            ret.Add(bse_Department);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
