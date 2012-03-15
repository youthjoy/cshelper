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
   public partial class ADOProd_Pool
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Prod_Pool对象(即:一条记录)
      /// </summary>
      public int Add(Prod_Pool prod_Pool)
      {
         string sql = "INSERT INTO Prod_Pool (PRP_ProdCode,PRP_Type,PRP_Name,PRP_iType,PRP_IOwner,PRP_IDate,PRP_IBak,PRP_OOwner,PRP_OCust,PRP_ODate,PRP_OCust1,PRP_OBak,PRP_IsChange,Stat,Creator,CreateTime,UpdateTime,DeleteTime,PRP_Udef1,PRP_Udef2,PRP_Udef3) VALUES (@PRP_ProdCode,@PRP_Type,@PRP_Name,@PRP_iType,@PRP_IOwner,@PRP_IDate,@PRP_IBak,@PRP_OOwner,@PRP_OCust,@PRP_ODate,@PRP_OCust1,@PRP_OBak,@PRP_IsChange,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime,@PRP_Udef1,@PRP_Udef2,@PRP_Udef3)";
         if (string.IsNullOrEmpty(prod_Pool.PRP_ProdCode))
         {
            idb.AddParameter("@PRP_ProdCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_ProdCode", prod_Pool.PRP_ProdCode);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Type))
         {
            idb.AddParameter("@PRP_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Type", prod_Pool.PRP_Type);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Name))
         {
            idb.AddParameter("@PRP_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Name", prod_Pool.PRP_Name);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_iType))
         {
            idb.AddParameter("@PRP_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_iType", prod_Pool.PRP_iType);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_IOwner))
         {
            idb.AddParameter("@PRP_IOwner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_IOwner", prod_Pool.PRP_IOwner);
         }
         if (prod_Pool.PRP_IDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRP_IDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_IDate", prod_Pool.PRP_IDate);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_IBak))
         {
            idb.AddParameter("@PRP_IBak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_IBak", prod_Pool.PRP_IBak);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_OOwner))
         {
            idb.AddParameter("@PRP_OOwner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OOwner", prod_Pool.PRP_OOwner);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_OCust))
         {
            idb.AddParameter("@PRP_OCust", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OCust", prod_Pool.PRP_OCust);
         }
         if (prod_Pool.PRP_ODate == DateTime.MinValue)
         {
            idb.AddParameter("@PRP_ODate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_ODate", prod_Pool.PRP_ODate);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_OCust1))
         {
            idb.AddParameter("@PRP_OCust1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OCust1", prod_Pool.PRP_OCust1);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_OBak))
         {
            idb.AddParameter("@PRP_OBak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OBak", prod_Pool.PRP_OBak);
         }
         if (prod_Pool.PRP_IsChange == 0)
         {
            idb.AddParameter("@PRP_IsChange", 0);
         }
         else
         {
            idb.AddParameter("@PRP_IsChange", prod_Pool.PRP_IsChange);
         }
         if (prod_Pool.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Pool.Stat);
         }
         if (string.IsNullOrEmpty(prod_Pool.Creator))
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Pool.Creator);
         }
         if (prod_Pool.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Pool.CreateTime);
         }
         if (prod_Pool.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Pool.UpdateTime);
         }
         if (prod_Pool.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Pool.DeleteTime);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Udef1))
         {
            idb.AddParameter("@PRP_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Udef1", prod_Pool.PRP_Udef1);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Udef2))
         {
            idb.AddParameter("@PRP_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Udef2", prod_Pool.PRP_Udef2);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Udef3))
         {
            idb.AddParameter("@PRP_Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Udef3", prod_Pool.PRP_Udef3);
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
      /// 添加Prod_Pool对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Prod_Pool prod_Pool)
      {
         string sql = "INSERT INTO Prod_Pool (PRP_ProdCode,PRP_Type,PRP_Name,PRP_iType,PRP_IOwner,PRP_IDate,PRP_IBak,PRP_OOwner,PRP_OCust,PRP_ODate,PRP_OCust1,PRP_OBak,PRP_IsChange,Stat,Creator,CreateTime,UpdateTime,DeleteTime,PRP_Udef1,PRP_Udef2,PRP_Udef3) VALUES (@PRP_ProdCode,@PRP_Type,@PRP_Name,@PRP_iType,@PRP_IOwner,@PRP_IDate,@PRP_IBak,@PRP_OOwner,@PRP_OCust,@PRP_ODate,@PRP_OCust1,@PRP_OBak,@PRP_IsChange,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime,@PRP_Udef1,@PRP_Udef2,@PRP_Udef3);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(prod_Pool.PRP_ProdCode))
         {
            idb.AddParameter("@PRP_ProdCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_ProdCode", prod_Pool.PRP_ProdCode);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Type))
         {
            idb.AddParameter("@PRP_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Type", prod_Pool.PRP_Type);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Name))
         {
            idb.AddParameter("@PRP_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Name", prod_Pool.PRP_Name);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_iType))
         {
            idb.AddParameter("@PRP_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_iType", prod_Pool.PRP_iType);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_IOwner))
         {
            idb.AddParameter("@PRP_IOwner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_IOwner", prod_Pool.PRP_IOwner);
         }
         if (prod_Pool.PRP_IDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRP_IDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_IDate", prod_Pool.PRP_IDate);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_IBak))
         {
            idb.AddParameter("@PRP_IBak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_IBak", prod_Pool.PRP_IBak);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_OOwner))
         {
            idb.AddParameter("@PRP_OOwner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OOwner", prod_Pool.PRP_OOwner);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_OCust))
         {
            idb.AddParameter("@PRP_OCust", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OCust", prod_Pool.PRP_OCust);
         }
         if (prod_Pool.PRP_ODate == DateTime.MinValue)
         {
            idb.AddParameter("@PRP_ODate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_ODate", prod_Pool.PRP_ODate);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_OCust1))
         {
            idb.AddParameter("@PRP_OCust1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OCust1", prod_Pool.PRP_OCust1);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_OBak))
         {
            idb.AddParameter("@PRP_OBak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OBak", prod_Pool.PRP_OBak);
         }
         if (prod_Pool.PRP_IsChange == 0)
         {
            idb.AddParameter("@PRP_IsChange", 0);
         }
         else
         {
            idb.AddParameter("@PRP_IsChange", prod_Pool.PRP_IsChange);
         }
         if (prod_Pool.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Pool.Stat);
         }
         if (string.IsNullOrEmpty(prod_Pool.Creator))
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Pool.Creator);
         }
         if (prod_Pool.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Pool.CreateTime);
         }
         if (prod_Pool.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Pool.UpdateTime);
         }
         if (prod_Pool.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Pool.DeleteTime);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Udef1))
         {
            idb.AddParameter("@PRP_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Udef1", prod_Pool.PRP_Udef1);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Udef2))
         {
            idb.AddParameter("@PRP_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Udef2", prod_Pool.PRP_Udef2);
         }
         if (string.IsNullOrEmpty(prod_Pool.PRP_Udef3))
         {
            idb.AddParameter("@PRP_Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Udef3", prod_Pool.PRP_Udef3);
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
      /// 更新Prod_Pool对象(即:一条记录
      /// </summary>
      public int Update(Prod_Pool prod_Pool)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Prod_Pool       SET ");
            if(prod_Pool.PRP_ProdCode_IsChanged){sbParameter.Append("PRP_ProdCode=@PRP_ProdCode, ");}
      if(prod_Pool.PRP_Type_IsChanged){sbParameter.Append("PRP_Type=@PRP_Type, ");}
      if(prod_Pool.PRP_Name_IsChanged){sbParameter.Append("PRP_Name=@PRP_Name, ");}
      if(prod_Pool.PRP_iType_IsChanged){sbParameter.Append("PRP_iType=@PRP_iType, ");}
      if(prod_Pool.PRP_IOwner_IsChanged){sbParameter.Append("PRP_IOwner=@PRP_IOwner, ");}
      if(prod_Pool.PRP_IDate_IsChanged){sbParameter.Append("PRP_IDate=@PRP_IDate, ");}
      if(prod_Pool.PRP_IBak_IsChanged){sbParameter.Append("PRP_IBak=@PRP_IBak, ");}
      if(prod_Pool.PRP_OOwner_IsChanged){sbParameter.Append("PRP_OOwner=@PRP_OOwner, ");}
      if(prod_Pool.PRP_OCust_IsChanged){sbParameter.Append("PRP_OCust=@PRP_OCust, ");}
      if(prod_Pool.PRP_ODate_IsChanged){sbParameter.Append("PRP_ODate=@PRP_ODate, ");}
      if(prod_Pool.PRP_OCust1_IsChanged){sbParameter.Append("PRP_OCust1=@PRP_OCust1, ");}
      if(prod_Pool.PRP_OBak_IsChanged){sbParameter.Append("PRP_OBak=@PRP_OBak, ");}
      if(prod_Pool.PRP_IsChange_IsChanged){sbParameter.Append("PRP_IsChange=@PRP_IsChange, ");}
      if(prod_Pool.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(prod_Pool.Creator_IsChanged){sbParameter.Append("Creator=@Creator, ");}
      if(prod_Pool.CreateTime_IsChanged){sbParameter.Append("CreateTime=@CreateTime, ");}
      if(prod_Pool.UpdateTime_IsChanged){sbParameter.Append("UpdateTime=@UpdateTime, ");}
      if(prod_Pool.DeleteTime_IsChanged){sbParameter.Append("DeleteTime=@DeleteTime, ");}
      if(prod_Pool.PRP_Udef1_IsChanged){sbParameter.Append("PRP_Udef1=@PRP_Udef1, ");}
      if(prod_Pool.PRP_Udef2_IsChanged){sbParameter.Append("PRP_Udef2=@PRP_Udef2, ");}
      if(prod_Pool.PRP_Udef3_IsChanged){sbParameter.Append("PRP_Udef3=@PRP_Udef3 ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and PRP_ID=@PRP_ID; " );
      string sql=sb.ToString();
         if(prod_Pool.PRP_ProdCode_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_ProdCode))
         {
            idb.AddParameter("@PRP_ProdCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_ProdCode", prod_Pool.PRP_ProdCode);
         }
          }
         if(prod_Pool.PRP_Type_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_Type))
         {
            idb.AddParameter("@PRP_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Type", prod_Pool.PRP_Type);
         }
          }
         if(prod_Pool.PRP_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_Name))
         {
            idb.AddParameter("@PRP_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Name", prod_Pool.PRP_Name);
         }
          }
         if(prod_Pool.PRP_iType_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_iType))
         {
            idb.AddParameter("@PRP_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_iType", prod_Pool.PRP_iType);
         }
          }
         if(prod_Pool.PRP_IOwner_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_IOwner))
         {
            idb.AddParameter("@PRP_IOwner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_IOwner", prod_Pool.PRP_IOwner);
         }
          }
         if(prod_Pool.PRP_IDate_IsChanged)
         {
         if (prod_Pool.PRP_IDate == DateTime.MinValue)
         {
            idb.AddParameter("@PRP_IDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_IDate", prod_Pool.PRP_IDate);
         }
          }
         if(prod_Pool.PRP_IBak_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_IBak))
         {
            idb.AddParameter("@PRP_IBak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_IBak", prod_Pool.PRP_IBak);
         }
          }
         if(prod_Pool.PRP_OOwner_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_OOwner))
         {
            idb.AddParameter("@PRP_OOwner", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OOwner", prod_Pool.PRP_OOwner);
         }
          }
         if(prod_Pool.PRP_OCust_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_OCust))
         {
            idb.AddParameter("@PRP_OCust", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OCust", prod_Pool.PRP_OCust);
         }
          }
         if(prod_Pool.PRP_ODate_IsChanged)
         {
         if (prod_Pool.PRP_ODate == DateTime.MinValue)
         {
            idb.AddParameter("@PRP_ODate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_ODate", prod_Pool.PRP_ODate);
         }
          }
         if(prod_Pool.PRP_OCust1_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_OCust1))
         {
            idb.AddParameter("@PRP_OCust1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OCust1", prod_Pool.PRP_OCust1);
         }
          }
         if(prod_Pool.PRP_OBak_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_OBak))
         {
            idb.AddParameter("@PRP_OBak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_OBak", prod_Pool.PRP_OBak);
         }
          }
         if(prod_Pool.PRP_IsChange_IsChanged)
         {
         if (prod_Pool.PRP_IsChange == 0)
         {
            idb.AddParameter("@PRP_IsChange", 0);
         }
         else
         {
            idb.AddParameter("@PRP_IsChange", prod_Pool.PRP_IsChange);
         }
          }
         if(prod_Pool.Stat_IsChanged)
         {
         if (prod_Pool.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Pool.Stat);
         }
          }
         if(prod_Pool.Creator_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.Creator))
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Pool.Creator);
         }
          }
         if(prod_Pool.CreateTime_IsChanged)
         {
         if (prod_Pool.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Pool.CreateTime);
         }
          }
         if(prod_Pool.UpdateTime_IsChanged)
         {
         if (prod_Pool.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Pool.UpdateTime);
         }
          }
         if(prod_Pool.DeleteTime_IsChanged)
         {
         if (prod_Pool.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Pool.DeleteTime);
         }
          }
         if(prod_Pool.PRP_Udef1_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_Udef1))
         {
            idb.AddParameter("@PRP_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Udef1", prod_Pool.PRP_Udef1);
         }
          }
         if(prod_Pool.PRP_Udef2_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_Udef2))
         {
            idb.AddParameter("@PRP_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Udef2", prod_Pool.PRP_Udef2);
         }
          }
         if(prod_Pool.PRP_Udef3_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Pool.PRP_Udef3))
         {
            idb.AddParameter("@PRP_Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRP_Udef3", prod_Pool.PRP_Udef3);
         }
          }

         idb.AddParameter("@PRP_ID", prod_Pool.PRP_ID);


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
      /// 删除Prod_Pool对象(即:一条记录
      /// </summary>
      public int Delete(decimal pRP_ID)
      {
         string sql = "DELETE Prod_Pool WHERE 1=1  AND PRP_ID=@PRP_ID ";
         idb.AddParameter("@PRP_ID", pRP_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Prod_Pool对象(即:一条记录
      /// </summary>
      public Prod_Pool GetByKey(decimal pRP_ID)
      {
         Prod_Pool prod_Pool = new Prod_Pool();
         string sql = "SELECT  PRP_ID,PRP_ProdCode,PRP_Type,PRP_Name,PRP_iType,PRP_IOwner,PRP_IDate,PRP_IBak,PRP_OOwner,PRP_OCust,PRP_ODate,PRP_OCust1,PRP_OBak,PRP_IsChange,Stat,Creator,CreateTime,UpdateTime,DeleteTime,PRP_Udef1,PRP_Udef2,PRP_Udef3 FROM Prod_Pool WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND PRP_ID=@PRP_ID ";
         idb.AddParameter("@PRP_ID", pRP_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["PRP_ID"] != DBNull.Value) prod_Pool.PRP_ID = Convert.ToDecimal(dr["PRP_ID"]);
            if (dr["PRP_ProdCode"] != DBNull.Value) prod_Pool.PRP_ProdCode = Convert.ToString(dr["PRP_ProdCode"]);
            if (dr["PRP_Type"] != DBNull.Value) prod_Pool.PRP_Type = Convert.ToString(dr["PRP_Type"]);
            if (dr["PRP_Name"] != DBNull.Value) prod_Pool.PRP_Name = Convert.ToString(dr["PRP_Name"]);
            if (dr["PRP_iType"] != DBNull.Value) prod_Pool.PRP_iType = Convert.ToString(dr["PRP_iType"]);
            if (dr["PRP_IOwner"] != DBNull.Value) prod_Pool.PRP_IOwner = Convert.ToString(dr["PRP_IOwner"]);
            if (dr["PRP_IDate"] != DBNull.Value) prod_Pool.PRP_IDate = Convert.ToDateTime(dr["PRP_IDate"]);
            if (dr["PRP_IBak"] != DBNull.Value) prod_Pool.PRP_IBak = Convert.ToString(dr["PRP_IBak"]);
            if (dr["PRP_OOwner"] != DBNull.Value) prod_Pool.PRP_OOwner = Convert.ToString(dr["PRP_OOwner"]);
            if (dr["PRP_OCust"] != DBNull.Value) prod_Pool.PRP_OCust = Convert.ToString(dr["PRP_OCust"]);
            if (dr["PRP_ODate"] != DBNull.Value) prod_Pool.PRP_ODate = Convert.ToDateTime(dr["PRP_ODate"]);
            if (dr["PRP_OCust1"] != DBNull.Value) prod_Pool.PRP_OCust1 = Convert.ToString(dr["PRP_OCust1"]);
            if (dr["PRP_OBak"] != DBNull.Value) prod_Pool.PRP_OBak = Convert.ToString(dr["PRP_OBak"]);
            if (dr["PRP_IsChange"] != DBNull.Value) prod_Pool.PRP_IsChange = Convert.ToInt32(dr["PRP_IsChange"]);
            if (dr["Stat"] != DBNull.Value) prod_Pool.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Pool.Creator = Convert.ToString(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Pool.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Pool.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Pool.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            if (dr["PRP_Udef1"] != DBNull.Value) prod_Pool.PRP_Udef1 = Convert.ToString(dr["PRP_Udef1"]);
            if (dr["PRP_Udef2"] != DBNull.Value) prod_Pool.PRP_Udef2 = Convert.ToString(dr["PRP_Udef2"]);
            if (dr["PRP_Udef3"] != DBNull.Value) prod_Pool.PRP_Udef3 = Convert.ToString(dr["PRP_Udef3"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return prod_Pool;
      }
      /// <summary>
      /// 获取指定的Prod_Pool对象集合
      /// </summary>
      public List<Prod_Pool> GetListByWhere(string strCondition)
      {
         List<Prod_Pool> ret = new List<Prod_Pool>();
         string sql = "SELECT  PRP_ID,PRP_ProdCode,PRP_Type,PRP_Name,PRP_iType,PRP_IOwner,PRP_IDate,PRP_IBak,PRP_OOwner,PRP_OCust,PRP_ODate,PRP_OCust1,PRP_OBak,PRP_IsChange,Stat,Creator,CreateTime,UpdateTime,DeleteTime,PRP_Udef1,PRP_Udef2,PRP_Udef3 FROM Prod_Pool WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Prod_Pool prod_Pool = new Prod_Pool();
            if (dr["PRP_ID"] != DBNull.Value) prod_Pool.PRP_ID = Convert.ToDecimal(dr["PRP_ID"]);
            if (dr["PRP_ProdCode"] != DBNull.Value) prod_Pool.PRP_ProdCode = Convert.ToString(dr["PRP_ProdCode"]);
            if (dr["PRP_Type"] != DBNull.Value) prod_Pool.PRP_Type = Convert.ToString(dr["PRP_Type"]);
            if (dr["PRP_Name"] != DBNull.Value) prod_Pool.PRP_Name = Convert.ToString(dr["PRP_Name"]);
            if (dr["PRP_iType"] != DBNull.Value) prod_Pool.PRP_iType = Convert.ToString(dr["PRP_iType"]);
            if (dr["PRP_IOwner"] != DBNull.Value) prod_Pool.PRP_IOwner = Convert.ToString(dr["PRP_IOwner"]);
            if (dr["PRP_IDate"] != DBNull.Value) prod_Pool.PRP_IDate = Convert.ToDateTime(dr["PRP_IDate"]);
            if (dr["PRP_IBak"] != DBNull.Value) prod_Pool.PRP_IBak = Convert.ToString(dr["PRP_IBak"]);
            if (dr["PRP_OOwner"] != DBNull.Value) prod_Pool.PRP_OOwner = Convert.ToString(dr["PRP_OOwner"]);
            if (dr["PRP_OCust"] != DBNull.Value) prod_Pool.PRP_OCust = Convert.ToString(dr["PRP_OCust"]);
            if (dr["PRP_ODate"] != DBNull.Value) prod_Pool.PRP_ODate = Convert.ToDateTime(dr["PRP_ODate"]);
            if (dr["PRP_OCust1"] != DBNull.Value) prod_Pool.PRP_OCust1 = Convert.ToString(dr["PRP_OCust1"]);
            if (dr["PRP_OBak"] != DBNull.Value) prod_Pool.PRP_OBak = Convert.ToString(dr["PRP_OBak"]);
            if (dr["PRP_IsChange"] != DBNull.Value) prod_Pool.PRP_IsChange = Convert.ToInt32(dr["PRP_IsChange"]);
            if (dr["Stat"] != DBNull.Value) prod_Pool.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Pool.Creator = Convert.ToString(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Pool.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Pool.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Pool.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            if (dr["PRP_Udef1"] != DBNull.Value) prod_Pool.PRP_Udef1 = Convert.ToString(dr["PRP_Udef1"]);
            if (dr["PRP_Udef2"] != DBNull.Value) prod_Pool.PRP_Udef2 = Convert.ToString(dr["PRP_Udef2"]);
            if (dr["PRP_Udef3"] != DBNull.Value) prod_Pool.PRP_Udef3 = Convert.ToString(dr["PRP_Udef3"]);
            ret.Add(prod_Pool);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Prod_Pool对象(即:一条记录
      /// </summary>
      public List<Prod_Pool> GetAll()
      {
         List<Prod_Pool> ret = new List<Prod_Pool>();
         string sql = "SELECT  PRP_ID,PRP_ProdCode,PRP_Type,PRP_Name,PRP_iType,PRP_IOwner,PRP_IDate,PRP_IBak,PRP_OOwner,PRP_OCust,PRP_ODate,PRP_OCust1,PRP_OBak,PRP_IsChange,Stat,Creator,CreateTime,UpdateTime,DeleteTime,PRP_Udef1,PRP_Udef2,PRP_Udef3 FROM Prod_Pool where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Prod_Pool prod_Pool = new Prod_Pool();
            if (dr["PRP_ID"] != DBNull.Value) prod_Pool.PRP_ID = Convert.ToDecimal(dr["PRP_ID"]);
            if (dr["PRP_ProdCode"] != DBNull.Value) prod_Pool.PRP_ProdCode = Convert.ToString(dr["PRP_ProdCode"]);
            if (dr["PRP_Type"] != DBNull.Value) prod_Pool.PRP_Type = Convert.ToString(dr["PRP_Type"]);
            if (dr["PRP_Name"] != DBNull.Value) prod_Pool.PRP_Name = Convert.ToString(dr["PRP_Name"]);
            if (dr["PRP_iType"] != DBNull.Value) prod_Pool.PRP_iType = Convert.ToString(dr["PRP_iType"]);
            if (dr["PRP_IOwner"] != DBNull.Value) prod_Pool.PRP_IOwner = Convert.ToString(dr["PRP_IOwner"]);
            if (dr["PRP_IDate"] != DBNull.Value) prod_Pool.PRP_IDate = Convert.ToDateTime(dr["PRP_IDate"]);
            if (dr["PRP_IBak"] != DBNull.Value) prod_Pool.PRP_IBak = Convert.ToString(dr["PRP_IBak"]);
            if (dr["PRP_OOwner"] != DBNull.Value) prod_Pool.PRP_OOwner = Convert.ToString(dr["PRP_OOwner"]);
            if (dr["PRP_OCust"] != DBNull.Value) prod_Pool.PRP_OCust = Convert.ToString(dr["PRP_OCust"]);
            if (dr["PRP_ODate"] != DBNull.Value) prod_Pool.PRP_ODate = Convert.ToDateTime(dr["PRP_ODate"]);
            if (dr["PRP_OCust1"] != DBNull.Value) prod_Pool.PRP_OCust1 = Convert.ToString(dr["PRP_OCust1"]);
            if (dr["PRP_OBak"] != DBNull.Value) prod_Pool.PRP_OBak = Convert.ToString(dr["PRP_OBak"]);
            if (dr["PRP_IsChange"] != DBNull.Value) prod_Pool.PRP_IsChange = Convert.ToInt32(dr["PRP_IsChange"]);
            if (dr["Stat"] != DBNull.Value) prod_Pool.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Pool.Creator = Convert.ToString(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Pool.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Pool.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Pool.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            if (dr["PRP_Udef1"] != DBNull.Value) prod_Pool.PRP_Udef1 = Convert.ToString(dr["PRP_Udef1"]);
            if (dr["PRP_Udef2"] != DBNull.Value) prod_Pool.PRP_Udef2 = Convert.ToString(dr["PRP_Udef2"]);
            if (dr["PRP_Udef3"] != DBNull.Value) prod_Pool.PRP_Udef3 = Convert.ToString(dr["PRP_Udef3"]);
            ret.Add(prod_Pool);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
