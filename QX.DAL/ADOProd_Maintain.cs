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
   public partial class ADOProd_Maintain
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Prod_Maintain对象(即:一条记录)
      /// </summary>
      public int Add(Prod_Maintain prod_Maintain)
      {
         string sql = "INSERT INTO Prod_Maintain (PRM_Code,PRM_ProdCode,PRM_Bak,PRM_Udef1,PRM_Udef2,PRM_Udef3,PRM_Udef4,PRM_Udef5,PRM_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@PRM_Code,@PRM_ProdCode,@PRM_Bak,@PRM_Udef1,@PRM_Udef2,@PRM_Udef3,@PRM_Udef4,@PRM_Udef5,@PRM_iType,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime)";
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Code))
         {
            idb.AddParameter("@PRM_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Code", prod_Maintain.PRM_Code);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_ProdCode))
         {
            idb.AddParameter("@PRM_ProdCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_ProdCode", prod_Maintain.PRM_ProdCode);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Bak))
         {
            idb.AddParameter("@PRM_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Bak", prod_Maintain.PRM_Bak);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef1))
         {
            idb.AddParameter("@PRM_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef1", prod_Maintain.PRM_Udef1);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef2))
         {
            idb.AddParameter("@PRM_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef2", prod_Maintain.PRM_Udef2);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef3))
         {
            idb.AddParameter("@PRM_Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef3", prod_Maintain.PRM_Udef3);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef4))
         {
            idb.AddParameter("@PRM_Udef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef4", prod_Maintain.PRM_Udef4);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef5))
         {
            idb.AddParameter("@PRM_Udef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef5", prod_Maintain.PRM_Udef5);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_iType))
         {
            idb.AddParameter("@PRM_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_iType", prod_Maintain.PRM_iType);
         }
         if (prod_Maintain.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Maintain.Stat);
         }
         if (prod_Maintain.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Maintain.Creator);
         }
         if (prod_Maintain.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Maintain.CreateTime);
         }
         if (prod_Maintain.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Maintain.UpdateTime);
         }
         if (prod_Maintain.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Maintain.DeleteTime);
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
      /// 添加Prod_Maintain对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Prod_Maintain prod_Maintain)
      {
         string sql = "INSERT INTO Prod_Maintain (PRM_Code,PRM_ProdCode,PRM_Bak,PRM_Udef1,PRM_Udef2,PRM_Udef3,PRM_Udef4,PRM_Udef5,PRM_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@PRM_Code,@PRM_ProdCode,@PRM_Bak,@PRM_Udef1,@PRM_Udef2,@PRM_Udef3,@PRM_Udef4,@PRM_Udef5,@PRM_iType,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Code))
         {
            idb.AddParameter("@PRM_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Code", prod_Maintain.PRM_Code);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_ProdCode))
         {
            idb.AddParameter("@PRM_ProdCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_ProdCode", prod_Maintain.PRM_ProdCode);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Bak))
         {
            idb.AddParameter("@PRM_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Bak", prod_Maintain.PRM_Bak);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef1))
         {
            idb.AddParameter("@PRM_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef1", prod_Maintain.PRM_Udef1);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef2))
         {
            idb.AddParameter("@PRM_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef2", prod_Maintain.PRM_Udef2);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef3))
         {
            idb.AddParameter("@PRM_Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef3", prod_Maintain.PRM_Udef3);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef4))
         {
            idb.AddParameter("@PRM_Udef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef4", prod_Maintain.PRM_Udef4);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef5))
         {
            idb.AddParameter("@PRM_Udef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef5", prod_Maintain.PRM_Udef5);
         }
         if (string.IsNullOrEmpty(prod_Maintain.PRM_iType))
         {
            idb.AddParameter("@PRM_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_iType", prod_Maintain.PRM_iType);
         }
         if (prod_Maintain.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Maintain.Stat);
         }
         if (prod_Maintain.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Maintain.Creator);
         }
         if (prod_Maintain.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Maintain.CreateTime);
         }
         if (prod_Maintain.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Maintain.UpdateTime);
         }
         if (prod_Maintain.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Maintain.DeleteTime);
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
      /// 更新Prod_Maintain对象(即:一条记录
      /// </summary>
      public int Update(Prod_Maintain prod_Maintain)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Prod_Maintain       SET ");
            if(prod_Maintain.PRM_Code_IsChanged){sbParameter.Append("PRM_Code=@PRM_Code, ");}
      if(prod_Maintain.PRM_ProdCode_IsChanged){sbParameter.Append("PRM_ProdCode=@PRM_ProdCode, ");}
      if(prod_Maintain.PRM_Bak_IsChanged){sbParameter.Append("PRM_Bak=@PRM_Bak, ");}
      if(prod_Maintain.PRM_Udef1_IsChanged){sbParameter.Append("PRM_Udef1=@PRM_Udef1, ");}
      if(prod_Maintain.PRM_Udef2_IsChanged){sbParameter.Append("PRM_Udef2=@PRM_Udef2, ");}
      if(prod_Maintain.PRM_Udef3_IsChanged){sbParameter.Append("PRM_Udef3=@PRM_Udef3, ");}
      if(prod_Maintain.PRM_Udef4_IsChanged){sbParameter.Append("PRM_Udef4=@PRM_Udef4, ");}
      if(prod_Maintain.PRM_Udef5_IsChanged){sbParameter.Append("PRM_Udef5=@PRM_Udef5, ");}
      if(prod_Maintain.PRM_iType_IsChanged){sbParameter.Append("PRM_iType=@PRM_iType, ");}
      if(prod_Maintain.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(prod_Maintain.Creator_IsChanged){sbParameter.Append("Creator=@Creator, ");}
      if(prod_Maintain.CreateTime_IsChanged){sbParameter.Append("CreateTime=@CreateTime, ");}
      if(prod_Maintain.UpdateTime_IsChanged){sbParameter.Append("UpdateTime=@UpdateTime, ");}
      if(prod_Maintain.DeleteTime_IsChanged){sbParameter.Append("DeleteTime=@DeleteTime ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and PRM_ID=@PRM_ID; " );
      string sql=sb.ToString();
         if(prod_Maintain.PRM_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Code))
         {
            idb.AddParameter("@PRM_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Code", prod_Maintain.PRM_Code);
         }
          }
         if(prod_Maintain.PRM_ProdCode_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Maintain.PRM_ProdCode))
         {
            idb.AddParameter("@PRM_ProdCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_ProdCode", prod_Maintain.PRM_ProdCode);
         }
          }
         if(prod_Maintain.PRM_Bak_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Bak))
         {
            idb.AddParameter("@PRM_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Bak", prod_Maintain.PRM_Bak);
         }
          }
         if(prod_Maintain.PRM_Udef1_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef1))
         {
            idb.AddParameter("@PRM_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef1", prod_Maintain.PRM_Udef1);
         }
          }
         if(prod_Maintain.PRM_Udef2_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef2))
         {
            idb.AddParameter("@PRM_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef2", prod_Maintain.PRM_Udef2);
         }
          }
         if(prod_Maintain.PRM_Udef3_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef3))
         {
            idb.AddParameter("@PRM_Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef3", prod_Maintain.PRM_Udef3);
         }
          }
         if(prod_Maintain.PRM_Udef4_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef4))
         {
            idb.AddParameter("@PRM_Udef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef4", prod_Maintain.PRM_Udef4);
         }
          }
         if(prod_Maintain.PRM_Udef5_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Maintain.PRM_Udef5))
         {
            idb.AddParameter("@PRM_Udef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_Udef5", prod_Maintain.PRM_Udef5);
         }
          }
         if(prod_Maintain.PRM_iType_IsChanged)
         {
         if (string.IsNullOrEmpty(prod_Maintain.PRM_iType))
         {
            idb.AddParameter("@PRM_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@PRM_iType", prod_Maintain.PRM_iType);
         }
          }
         if(prod_Maintain.Stat_IsChanged)
         {
         if (prod_Maintain.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", prod_Maintain.Stat);
         }
          }
         if(prod_Maintain.Creator_IsChanged)
         {
         if (prod_Maintain.Creator == DateTime.MinValue)
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", prod_Maintain.Creator);
         }
          }
         if(prod_Maintain.CreateTime_IsChanged)
         {
         if (prod_Maintain.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", prod_Maintain.CreateTime);
         }
          }
         if(prod_Maintain.UpdateTime_IsChanged)
         {
         if (prod_Maintain.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", prod_Maintain.UpdateTime);
         }
          }
         if(prod_Maintain.DeleteTime_IsChanged)
         {
         if (prod_Maintain.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", prod_Maintain.DeleteTime);
         }
          }

         idb.AddParameter("@PRM_ID", prod_Maintain.PRM_ID);


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
      /// 删除Prod_Maintain对象(即:一条记录
      /// </summary>
      public int Delete(decimal pRM_ID)
      {
         string sql = "DELETE Prod_Maintain WHERE 1=1  AND PRM_ID=@PRM_ID ";
         idb.AddParameter("@PRM_ID", pRM_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Prod_Maintain对象(即:一条记录
      /// </summary>
      public Prod_Maintain GetByKey(decimal pRM_ID)
      {
         Prod_Maintain prod_Maintain = new Prod_Maintain();
         string sql = "SELECT  PRM_ID,PRM_Code,PRM_ProdCode,PRM_Bak,PRM_Udef1,PRM_Udef2,PRM_Udef3,PRM_Udef4,PRM_Udef5,PRM_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Prod_Maintain WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND PRM_ID=@PRM_ID ";
         idb.AddParameter("@PRM_ID", pRM_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["PRM_ID"] != DBNull.Value) prod_Maintain.PRM_ID = Convert.ToDecimal(dr["PRM_ID"]);
            if (dr["PRM_Code"] != DBNull.Value) prod_Maintain.PRM_Code = Convert.ToString(dr["PRM_Code"]);
            if (dr["PRM_ProdCode"] != DBNull.Value) prod_Maintain.PRM_ProdCode = Convert.ToString(dr["PRM_ProdCode"]);
            if (dr["PRM_Bak"] != DBNull.Value) prod_Maintain.PRM_Bak = Convert.ToString(dr["PRM_Bak"]);
            if (dr["PRM_Udef1"] != DBNull.Value) prod_Maintain.PRM_Udef1 = Convert.ToString(dr["PRM_Udef1"]);
            if (dr["PRM_Udef2"] != DBNull.Value) prod_Maintain.PRM_Udef2 = Convert.ToString(dr["PRM_Udef2"]);
            if (dr["PRM_Udef3"] != DBNull.Value) prod_Maintain.PRM_Udef3 = Convert.ToString(dr["PRM_Udef3"]);
            if (dr["PRM_Udef4"] != DBNull.Value) prod_Maintain.PRM_Udef4 = Convert.ToString(dr["PRM_Udef4"]);
            if (dr["PRM_Udef5"] != DBNull.Value) prod_Maintain.PRM_Udef5 = Convert.ToString(dr["PRM_Udef5"]);
            if (dr["PRM_iType"] != DBNull.Value) prod_Maintain.PRM_iType = Convert.ToString(dr["PRM_iType"]);
            if (dr["Stat"] != DBNull.Value) prod_Maintain.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Maintain.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Maintain.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Maintain.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Maintain.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return prod_Maintain;
      }
      /// <summary>
      /// 获取指定的Prod_Maintain对象集合
      /// </summary>
      public List<Prod_Maintain> GetListByWhere(string strCondition)
      {
         List<Prod_Maintain> ret = new List<Prod_Maintain>();
         string sql = "SELECT  PRM_ID,PRM_Code,PRM_ProdCode,PRM_Bak,PRM_Udef1,PRM_Udef2,PRM_Udef3,PRM_Udef4,PRM_Udef5,PRM_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Prod_Maintain WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Prod_Maintain prod_Maintain = new Prod_Maintain();
            if (dr["PRM_ID"] != DBNull.Value) prod_Maintain.PRM_ID = Convert.ToDecimal(dr["PRM_ID"]);
            if (dr["PRM_Code"] != DBNull.Value) prod_Maintain.PRM_Code = Convert.ToString(dr["PRM_Code"]);
            if (dr["PRM_ProdCode"] != DBNull.Value) prod_Maintain.PRM_ProdCode = Convert.ToString(dr["PRM_ProdCode"]);
            if (dr["PRM_Bak"] != DBNull.Value) prod_Maintain.PRM_Bak = Convert.ToString(dr["PRM_Bak"]);
            if (dr["PRM_Udef1"] != DBNull.Value) prod_Maintain.PRM_Udef1 = Convert.ToString(dr["PRM_Udef1"]);
            if (dr["PRM_Udef2"] != DBNull.Value) prod_Maintain.PRM_Udef2 = Convert.ToString(dr["PRM_Udef2"]);
            if (dr["PRM_Udef3"] != DBNull.Value) prod_Maintain.PRM_Udef3 = Convert.ToString(dr["PRM_Udef3"]);
            if (dr["PRM_Udef4"] != DBNull.Value) prod_Maintain.PRM_Udef4 = Convert.ToString(dr["PRM_Udef4"]);
            if (dr["PRM_Udef5"] != DBNull.Value) prod_Maintain.PRM_Udef5 = Convert.ToString(dr["PRM_Udef5"]);
            if (dr["PRM_iType"] != DBNull.Value) prod_Maintain.PRM_iType = Convert.ToString(dr["PRM_iType"]);
            if (dr["Stat"] != DBNull.Value) prod_Maintain.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Maintain.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Maintain.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Maintain.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Maintain.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(prod_Maintain);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Prod_Maintain对象(即:一条记录
      /// </summary>
      public List<Prod_Maintain> GetAll()
      {
         List<Prod_Maintain> ret = new List<Prod_Maintain>();
         string sql = "SELECT  PRM_ID,PRM_Code,PRM_ProdCode,PRM_Bak,PRM_Udef1,PRM_Udef2,PRM_Udef3,PRM_Udef4,PRM_Udef5,PRM_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Prod_Maintain where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Prod_Maintain prod_Maintain = new Prod_Maintain();
            if (dr["PRM_ID"] != DBNull.Value) prod_Maintain.PRM_ID = Convert.ToDecimal(dr["PRM_ID"]);
            if (dr["PRM_Code"] != DBNull.Value) prod_Maintain.PRM_Code = Convert.ToString(dr["PRM_Code"]);
            if (dr["PRM_ProdCode"] != DBNull.Value) prod_Maintain.PRM_ProdCode = Convert.ToString(dr["PRM_ProdCode"]);
            if (dr["PRM_Bak"] != DBNull.Value) prod_Maintain.PRM_Bak = Convert.ToString(dr["PRM_Bak"]);
            if (dr["PRM_Udef1"] != DBNull.Value) prod_Maintain.PRM_Udef1 = Convert.ToString(dr["PRM_Udef1"]);
            if (dr["PRM_Udef2"] != DBNull.Value) prod_Maintain.PRM_Udef2 = Convert.ToString(dr["PRM_Udef2"]);
            if (dr["PRM_Udef3"] != DBNull.Value) prod_Maintain.PRM_Udef3 = Convert.ToString(dr["PRM_Udef3"]);
            if (dr["PRM_Udef4"] != DBNull.Value) prod_Maintain.PRM_Udef4 = Convert.ToString(dr["PRM_Udef4"]);
            if (dr["PRM_Udef5"] != DBNull.Value) prod_Maintain.PRM_Udef5 = Convert.ToString(dr["PRM_Udef5"]);
            if (dr["PRM_iType"] != DBNull.Value) prod_Maintain.PRM_iType = Convert.ToString(dr["PRM_iType"]);
            if (dr["Stat"] != DBNull.Value) prod_Maintain.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) prod_Maintain.Creator = Convert.ToDateTime(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) prod_Maintain.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) prod_Maintain.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) prod_Maintain.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(prod_Maintain);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
