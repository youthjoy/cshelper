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
   public partial class ADOTpl_Components
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Tpl_Components对象(即:一条记录)
      /// </summary>
      public int Add(Tpl_Components tpl_Components)
      {
         string sql = "INSERT INTO Tpl_Components (TPLC_Code,TPLC_Name,TPLC_Cat,TPLC_Tec,TPLC_Raw,TPLC_Plant,TPLC_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@TPLC_Code,@TPLC_Name,@TPLC_Cat,@TPLC_Tec,@TPLC_Raw,@TPLC_Plant,@TPLC_iType,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime)";
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Code))
         {
            idb.AddParameter("@TPLC_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Code", tpl_Components.TPLC_Code);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Name))
         {
            idb.AddParameter("@TPLC_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Name", tpl_Components.TPLC_Name);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Cat))
         {
            idb.AddParameter("@TPLC_Cat", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Cat", tpl_Components.TPLC_Cat);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Tec))
         {
            idb.AddParameter("@TPLC_Tec", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Tec", tpl_Components.TPLC_Tec);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Raw))
         {
            idb.AddParameter("@TPLC_Raw", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Raw", tpl_Components.TPLC_Raw);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Plant))
         {
            idb.AddParameter("@TPLC_Plant", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Plant", tpl_Components.TPLC_Plant);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_iType))
         {
            idb.AddParameter("@TPLC_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_iType", tpl_Components.TPLC_iType);
         }
         if (tpl_Components.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", tpl_Components.Stat);
         }
         if (string.IsNullOrEmpty(tpl_Components.Creator))
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", tpl_Components.Creator);
         }
         if (tpl_Components.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", tpl_Components.CreateTime);
         }
         if (tpl_Components.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", tpl_Components.UpdateTime);
         }
         if (tpl_Components.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", tpl_Components.DeleteTime);
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
      /// 添加Tpl_Components对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Tpl_Components tpl_Components)
      {
         string sql = "INSERT INTO Tpl_Components (TPLC_Code,TPLC_Name,TPLC_Cat,TPLC_Tec,TPLC_Raw,TPLC_Plant,TPLC_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime) VALUES (@TPLC_Code,@TPLC_Name,@TPLC_Cat,@TPLC_Tec,@TPLC_Raw,@TPLC_Plant,@TPLC_iType,@Stat,@Creator,@CreateTime,@UpdateTime,@DeleteTime);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Code))
         {
            idb.AddParameter("@TPLC_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Code", tpl_Components.TPLC_Code);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Name))
         {
            idb.AddParameter("@TPLC_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Name", tpl_Components.TPLC_Name);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Cat))
         {
            idb.AddParameter("@TPLC_Cat", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Cat", tpl_Components.TPLC_Cat);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Tec))
         {
            idb.AddParameter("@TPLC_Tec", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Tec", tpl_Components.TPLC_Tec);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Raw))
         {
            idb.AddParameter("@TPLC_Raw", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Raw", tpl_Components.TPLC_Raw);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Plant))
         {
            idb.AddParameter("@TPLC_Plant", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Plant", tpl_Components.TPLC_Plant);
         }
         if (string.IsNullOrEmpty(tpl_Components.TPLC_iType))
         {
            idb.AddParameter("@TPLC_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_iType", tpl_Components.TPLC_iType);
         }
         if (tpl_Components.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", tpl_Components.Stat);
         }
         if (string.IsNullOrEmpty(tpl_Components.Creator))
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", tpl_Components.Creator);
         }
         if (tpl_Components.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", tpl_Components.CreateTime);
         }
         if (tpl_Components.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", tpl_Components.UpdateTime);
         }
         if (tpl_Components.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", tpl_Components.DeleteTime);
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
      /// 更新Tpl_Components对象(即:一条记录
      /// </summary>
      public int Update(Tpl_Components tpl_Components)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Tpl_Components       SET ");
            if(tpl_Components.TPLC_Code_IsChanged){sbParameter.Append("TPLC_Code=@TPLC_Code, ");}
      if(tpl_Components.TPLC_Name_IsChanged){sbParameter.Append("TPLC_Name=@TPLC_Name, ");}
      if(tpl_Components.TPLC_Cat_IsChanged){sbParameter.Append("TPLC_Cat=@TPLC_Cat, ");}
      if(tpl_Components.TPLC_Tec_IsChanged){sbParameter.Append("TPLC_Tec=@TPLC_Tec, ");}
      if(tpl_Components.TPLC_Raw_IsChanged){sbParameter.Append("TPLC_Raw=@TPLC_Raw, ");}
      if(tpl_Components.TPLC_Plant_IsChanged){sbParameter.Append("TPLC_Plant=@TPLC_Plant, ");}
      if(tpl_Components.TPLC_iType_IsChanged){sbParameter.Append("TPLC_iType=@TPLC_iType, ");}
      if(tpl_Components.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(tpl_Components.Creator_IsChanged){sbParameter.Append("Creator=@Creator, ");}
      if(tpl_Components.CreateTime_IsChanged){sbParameter.Append("CreateTime=@CreateTime, ");}
      if(tpl_Components.UpdateTime_IsChanged){sbParameter.Append("UpdateTime=@UpdateTime, ");}
      if(tpl_Components.DeleteTime_IsChanged){sbParameter.Append("DeleteTime=@DeleteTime ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and TPLC_ID=@TPLC_ID; " );
      string sql=sb.ToString();
         if(tpl_Components.TPLC_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Code))
         {
            idb.AddParameter("@TPLC_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Code", tpl_Components.TPLC_Code);
         }
          }
         if(tpl_Components.TPLC_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Name))
         {
            idb.AddParameter("@TPLC_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Name", tpl_Components.TPLC_Name);
         }
          }
         if(tpl_Components.TPLC_Cat_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Cat))
         {
            idb.AddParameter("@TPLC_Cat", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Cat", tpl_Components.TPLC_Cat);
         }
          }
         if(tpl_Components.TPLC_Tec_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Tec))
         {
            idb.AddParameter("@TPLC_Tec", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Tec", tpl_Components.TPLC_Tec);
         }
          }
         if(tpl_Components.TPLC_Raw_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Raw))
         {
            idb.AddParameter("@TPLC_Raw", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Raw", tpl_Components.TPLC_Raw);
         }
          }
         if(tpl_Components.TPLC_Plant_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_Components.TPLC_Plant))
         {
            idb.AddParameter("@TPLC_Plant", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_Plant", tpl_Components.TPLC_Plant);
         }
          }
         if(tpl_Components.TPLC_iType_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_Components.TPLC_iType))
         {
            idb.AddParameter("@TPLC_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@TPLC_iType", tpl_Components.TPLC_iType);
         }
          }
         if(tpl_Components.Stat_IsChanged)
         {
         if (tpl_Components.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", tpl_Components.Stat);
         }
          }
         if(tpl_Components.Creator_IsChanged)
         {
         if (string.IsNullOrEmpty(tpl_Components.Creator))
         {
            idb.AddParameter("@Creator", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Creator", tpl_Components.Creator);
         }
          }
         if(tpl_Components.CreateTime_IsChanged)
         {
         if (tpl_Components.CreateTime == DateTime.MinValue)
         {
            idb.AddParameter("@CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CreateTime", tpl_Components.CreateTime);
         }
          }
         if(tpl_Components.UpdateTime_IsChanged)
         {
         if (tpl_Components.UpdateTime == DateTime.MinValue)
         {
            idb.AddParameter("@UpdateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@UpdateTime", tpl_Components.UpdateTime);
         }
          }
         if(tpl_Components.DeleteTime_IsChanged)
         {
         if (tpl_Components.DeleteTime == DateTime.MinValue)
         {
            idb.AddParameter("@DeleteTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DeleteTime", tpl_Components.DeleteTime);
         }
          }

         idb.AddParameter("@TPLC_ID", tpl_Components.TPLC_ID);


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
      /// 删除Tpl_Components对象(即:一条记录
      /// </summary>
      public int Delete(decimal tPLC_ID)
      {
         string sql = "DELETE Tpl_Components WHERE 1=1  AND TPLC_ID=@TPLC_ID ";
         idb.AddParameter("@TPLC_ID", tPLC_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Tpl_Components对象(即:一条记录
      /// </summary>
      public Tpl_Components GetByKey(decimal tPLC_ID)
      {
         Tpl_Components tpl_Components = new Tpl_Components();
         string sql = "SELECT  TPLC_ID,TPLC_Code,TPLC_Name,TPLC_Cat,TPLC_Tec,TPLC_Raw,TPLC_Plant,TPLC_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Tpl_Components WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND TPLC_ID=@TPLC_ID ";
         idb.AddParameter("@TPLC_ID", tPLC_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["TPLC_ID"] != DBNull.Value) tpl_Components.TPLC_ID = Convert.ToDecimal(dr["TPLC_ID"]);
            if (dr["TPLC_Code"] != DBNull.Value) tpl_Components.TPLC_Code = Convert.ToString(dr["TPLC_Code"]);
            if (dr["TPLC_Name"] != DBNull.Value) tpl_Components.TPLC_Name = Convert.ToString(dr["TPLC_Name"]);
            if (dr["TPLC_Cat"] != DBNull.Value) tpl_Components.TPLC_Cat = Convert.ToString(dr["TPLC_Cat"]);
            if (dr["TPLC_Tec"] != DBNull.Value) tpl_Components.TPLC_Tec = Convert.ToString(dr["TPLC_Tec"]);
            if (dr["TPLC_Raw"] != DBNull.Value) tpl_Components.TPLC_Raw = Convert.ToString(dr["TPLC_Raw"]);
            if (dr["TPLC_Plant"] != DBNull.Value) tpl_Components.TPLC_Plant = Convert.ToString(dr["TPLC_Plant"]);
            if (dr["TPLC_iType"] != DBNull.Value) tpl_Components.TPLC_iType = Convert.ToString(dr["TPLC_iType"]);
            if (dr["Stat"] != DBNull.Value) tpl_Components.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) tpl_Components.Creator = Convert.ToString(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) tpl_Components.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) tpl_Components.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) tpl_Components.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return tpl_Components;
      }
      /// <summary>
      /// 获取指定的Tpl_Components对象集合
      /// </summary>
      public List<Tpl_Components> GetListByWhere(string strCondition)
      {
         List<Tpl_Components> ret = new List<Tpl_Components>();
         string sql = "SELECT  TPLC_ID,TPLC_Code,TPLC_Name,TPLC_Cat,TPLC_Tec,TPLC_Raw,TPLC_Plant,TPLC_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Tpl_Components WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Tpl_Components tpl_Components = new Tpl_Components();
            if (dr["TPLC_ID"] != DBNull.Value) tpl_Components.TPLC_ID = Convert.ToDecimal(dr["TPLC_ID"]);
            if (dr["TPLC_Code"] != DBNull.Value) tpl_Components.TPLC_Code = Convert.ToString(dr["TPLC_Code"]);
            if (dr["TPLC_Name"] != DBNull.Value) tpl_Components.TPLC_Name = Convert.ToString(dr["TPLC_Name"]);
            if (dr["TPLC_Cat"] != DBNull.Value) tpl_Components.TPLC_Cat = Convert.ToString(dr["TPLC_Cat"]);
            if (dr["TPLC_Tec"] != DBNull.Value) tpl_Components.TPLC_Tec = Convert.ToString(dr["TPLC_Tec"]);
            if (dr["TPLC_Raw"] != DBNull.Value) tpl_Components.TPLC_Raw = Convert.ToString(dr["TPLC_Raw"]);
            if (dr["TPLC_Plant"] != DBNull.Value) tpl_Components.TPLC_Plant = Convert.ToString(dr["TPLC_Plant"]);
            if (dr["TPLC_iType"] != DBNull.Value) tpl_Components.TPLC_iType = Convert.ToString(dr["TPLC_iType"]);
            if (dr["Stat"] != DBNull.Value) tpl_Components.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) tpl_Components.Creator = Convert.ToString(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) tpl_Components.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) tpl_Components.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) tpl_Components.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(tpl_Components);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Tpl_Components对象(即:一条记录
      /// </summary>
      public List<Tpl_Components> GetAll()
      {
         List<Tpl_Components> ret = new List<Tpl_Components>();
         string sql = "SELECT  TPLC_ID,TPLC_Code,TPLC_Name,TPLC_Cat,TPLC_Tec,TPLC_Raw,TPLC_Plant,TPLC_iType,Stat,Creator,CreateTime,UpdateTime,DeleteTime FROM Tpl_Components where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Tpl_Components tpl_Components = new Tpl_Components();
            if (dr["TPLC_ID"] != DBNull.Value) tpl_Components.TPLC_ID = Convert.ToDecimal(dr["TPLC_ID"]);
            if (dr["TPLC_Code"] != DBNull.Value) tpl_Components.TPLC_Code = Convert.ToString(dr["TPLC_Code"]);
            if (dr["TPLC_Name"] != DBNull.Value) tpl_Components.TPLC_Name = Convert.ToString(dr["TPLC_Name"]);
            if (dr["TPLC_Cat"] != DBNull.Value) tpl_Components.TPLC_Cat = Convert.ToString(dr["TPLC_Cat"]);
            if (dr["TPLC_Tec"] != DBNull.Value) tpl_Components.TPLC_Tec = Convert.ToString(dr["TPLC_Tec"]);
            if (dr["TPLC_Raw"] != DBNull.Value) tpl_Components.TPLC_Raw = Convert.ToString(dr["TPLC_Raw"]);
            if (dr["TPLC_Plant"] != DBNull.Value) tpl_Components.TPLC_Plant = Convert.ToString(dr["TPLC_Plant"]);
            if (dr["TPLC_iType"] != DBNull.Value) tpl_Components.TPLC_iType = Convert.ToString(dr["TPLC_iType"]);
            if (dr["Stat"] != DBNull.Value) tpl_Components.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Creator"] != DBNull.Value) tpl_Components.Creator = Convert.ToString(dr["Creator"]);
            if (dr["CreateTime"] != DBNull.Value) tpl_Components.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            if (dr["UpdateTime"] != DBNull.Value) tpl_Components.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            if (dr["DeleteTime"] != DBNull.Value) tpl_Components.DeleteTime = Convert.ToDateTime(dr["DeleteTime"]);
            ret.Add(tpl_Components);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
