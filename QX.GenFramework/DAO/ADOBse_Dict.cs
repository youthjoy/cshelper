using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using QX.GenFramework.Model;
using QX.DataAcess;

namespace QX.GenFramework.ADO
{
   /// <summary>
   /// 数据字典
   /// </summary>
   [Serializable]
   public partial class ADOBse_Dict
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加数据字典 Bse_Dict对象(即:一条记录)
      /// </summary>
      public int Add(Bse_Dict bse_Dict)
      {
         string sql = "INSERT INTO Bse_Dict (Dict_Key,Dict_Code,Dict_Name,Dict_PCode,Dict_PName,Dict_Desp,Dict_SCode,Dict_Bak,Dict_UDef1,Dict_UDef2,Dict_UDef3,Dict_UDef4,Dict_UDef5,Dict_Level,Dict_IsEditable,Stat,Dict_Order) VALUES (@Dict_Key,@Dict_Code,@Dict_Name,@Dict_PCode,@Dict_PName,@Dict_Desp,@Dict_SCode,@Dict_Bak,@Dict_UDef1,@Dict_UDef2,@Dict_UDef3,@Dict_UDef4,@Dict_UDef5,@Dict_Level,@Dict_IsEditable,@Stat,@Dict_Order)";
         if (string.IsNullOrEmpty(bse_Dict.Dict_Key))
         {
            idb.AddParameter("@Dict_Key", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Key", bse_Dict.Dict_Key);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_Code))
         {
            idb.AddParameter("@Dict_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Code", bse_Dict.Dict_Code);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_Name))
         {
            idb.AddParameter("@Dict_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Name", bse_Dict.Dict_Name);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_PCode))
         {
            idb.AddParameter("@Dict_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_PCode", bse_Dict.Dict_PCode);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_PName))
         {
            idb.AddParameter("@Dict_PName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_PName", bse_Dict.Dict_PName);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_Desp))
         {
            idb.AddParameter("@Dict_Desp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Desp", bse_Dict.Dict_Desp);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_SCode))
         {
            idb.AddParameter("@Dict_SCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_SCode", bse_Dict.Dict_SCode);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_Bak))
         {
            idb.AddParameter("@Dict_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Bak", bse_Dict.Dict_Bak);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef1))
         {
            idb.AddParameter("@Dict_UDef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef1", bse_Dict.Dict_UDef1);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef2))
         {
            idb.AddParameter("@Dict_UDef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef2", bse_Dict.Dict_UDef2);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef3))
         {
            idb.AddParameter("@Dict_UDef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef3", bse_Dict.Dict_UDef3);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef4))
         {
            idb.AddParameter("@Dict_UDef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef4", bse_Dict.Dict_UDef4);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef5))
         {
            idb.AddParameter("@Dict_UDef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef5", bse_Dict.Dict_UDef5);
         }
         if (bse_Dict.Dict_Level == 0)
         {
            idb.AddParameter("@Dict_Level", 0);
         }
         else
         {
            idb.AddParameter("@Dict_Level", bse_Dict.Dict_Level);
         }
         if (bse_Dict.Dict_IsEditable == 0)
         {
            idb.AddParameter("@Dict_IsEditable", 0);
         }
         else
         {
            idb.AddParameter("@Dict_IsEditable", bse_Dict.Dict_IsEditable);
         }
         if (bse_Dict.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", bse_Dict.Stat);
         }
         if (bse_Dict.Dict_Order == 0)
         {
            idb.AddParameter("@Dict_Order", 0);
         }
         else
         {
            idb.AddParameter("@Dict_Order", bse_Dict.Dict_Order);
         }

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加数据字典 Bse_Dict对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Bse_Dict bse_Dict)
      {
         string sql = "INSERT INTO Bse_Dict (Dict_Key,Dict_Code,Dict_Name,Dict_PCode,Dict_PName,Dict_Desp,Dict_SCode,Dict_Bak,Dict_UDef1,Dict_UDef2,Dict_UDef3,Dict_UDef4,Dict_UDef5,Dict_Level,Dict_IsEditable,Stat,Dict_Order) VALUES (@Dict_Key,@Dict_Code,@Dict_Name,@Dict_PCode,@Dict_PName,@Dict_Desp,@Dict_SCode,@Dict_Bak,@Dict_UDef1,@Dict_UDef2,@Dict_UDef3,@Dict_UDef4,@Dict_UDef5,@Dict_Level,@Dict_IsEditable,@Stat,@Dict_Order);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(bse_Dict.Dict_Key))
         {
            idb.AddParameter("@Dict_Key", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Key", bse_Dict.Dict_Key);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_Code))
         {
            idb.AddParameter("@Dict_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Code", bse_Dict.Dict_Code);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_Name))
         {
            idb.AddParameter("@Dict_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Name", bse_Dict.Dict_Name);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_PCode))
         {
            idb.AddParameter("@Dict_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_PCode", bse_Dict.Dict_PCode);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_PName))
         {
            idb.AddParameter("@Dict_PName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_PName", bse_Dict.Dict_PName);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_Desp))
         {
            idb.AddParameter("@Dict_Desp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Desp", bse_Dict.Dict_Desp);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_SCode))
         {
            idb.AddParameter("@Dict_SCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_SCode", bse_Dict.Dict_SCode);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_Bak))
         {
            idb.AddParameter("@Dict_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Bak", bse_Dict.Dict_Bak);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef1))
         {
            idb.AddParameter("@Dict_UDef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef1", bse_Dict.Dict_UDef1);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef2))
         {
            idb.AddParameter("@Dict_UDef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef2", bse_Dict.Dict_UDef2);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef3))
         {
            idb.AddParameter("@Dict_UDef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef3", bse_Dict.Dict_UDef3);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef4))
         {
            idb.AddParameter("@Dict_UDef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef4", bse_Dict.Dict_UDef4);
         }
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef5))
         {
            idb.AddParameter("@Dict_UDef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef5", bse_Dict.Dict_UDef5);
         }
         if (bse_Dict.Dict_Level == 0)
         {
            idb.AddParameter("@Dict_Level", 0);
         }
         else
         {
            idb.AddParameter("@Dict_Level", bse_Dict.Dict_Level);
         }
         if (bse_Dict.Dict_IsEditable == 0)
         {
            idb.AddParameter("@Dict_IsEditable", 0);
         }
         else
         {
            idb.AddParameter("@Dict_IsEditable", bse_Dict.Dict_IsEditable);
         }
         if (bse_Dict.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", bse_Dict.Stat);
         }
         if (bse_Dict.Dict_Order == 0)
         {
            idb.AddParameter("@Dict_Order", 0);
         }
         else
         {
            idb.AddParameter("@Dict_Order", bse_Dict.Dict_Order);
         }

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新数据字典 Bse_Dict对象(即:一条记录
      /// </summary>
      public int Update(Bse_Dict bse_Dict)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Bse_Dict       SET ");
            if(bse_Dict.Dict_Key_IsChanged){sbParameter.Append("Dict_Key=@Dict_Key, ");}
      if(bse_Dict.Dict_Code_IsChanged){sbParameter.Append("Dict_Code=@Dict_Code, ");}
      if(bse_Dict.Dict_Name_IsChanged){sbParameter.Append("Dict_Name=@Dict_Name, ");}
      if(bse_Dict.Dict_PCode_IsChanged){sbParameter.Append("Dict_PCode=@Dict_PCode, ");}
      if(bse_Dict.Dict_PName_IsChanged){sbParameter.Append("Dict_PName=@Dict_PName, ");}
      if(bse_Dict.Dict_Desp_IsChanged){sbParameter.Append("Dict_Desp=@Dict_Desp, ");}
      if(bse_Dict.Dict_SCode_IsChanged){sbParameter.Append("Dict_SCode=@Dict_SCode, ");}
      if(bse_Dict.Dict_Bak_IsChanged){sbParameter.Append("Dict_Bak=@Dict_Bak, ");}
      if(bse_Dict.Dict_UDef1_IsChanged){sbParameter.Append("Dict_UDef1=@Dict_UDef1, ");}
      if(bse_Dict.Dict_UDef2_IsChanged){sbParameter.Append("Dict_UDef2=@Dict_UDef2, ");}
      if(bse_Dict.Dict_UDef3_IsChanged){sbParameter.Append("Dict_UDef3=@Dict_UDef3, ");}
      if(bse_Dict.Dict_UDef4_IsChanged){sbParameter.Append("Dict_UDef4=@Dict_UDef4, ");}
      if(bse_Dict.Dict_UDef5_IsChanged){sbParameter.Append("Dict_UDef5=@Dict_UDef5, ");}
      if(bse_Dict.Dict_Level_IsChanged){sbParameter.Append("Dict_Level=@Dict_Level, ");}
      if(bse_Dict.Dict_IsEditable_IsChanged){sbParameter.Append("Dict_IsEditable=@Dict_IsEditable, ");}
      if(bse_Dict.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(bse_Dict.Dict_Order_IsChanged){sbParameter.Append("Dict_Order=@Dict_Order ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and Dict_ID=@Dict_ID; " );
      string sql=sb.ToString();
         if(bse_Dict.Dict_Key_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_Key))
         {
            idb.AddParameter("@Dict_Key", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Key", bse_Dict.Dict_Key);
         }
          }
         if(bse_Dict.Dict_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_Code))
         {
            idb.AddParameter("@Dict_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Code", bse_Dict.Dict_Code);
         }
          }
         if(bse_Dict.Dict_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_Name))
         {
            idb.AddParameter("@Dict_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Name", bse_Dict.Dict_Name);
         }
          }
         if(bse_Dict.Dict_PCode_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_PCode))
         {
            idb.AddParameter("@Dict_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_PCode", bse_Dict.Dict_PCode);
         }
          }
         if(bse_Dict.Dict_PName_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_PName))
         {
            idb.AddParameter("@Dict_PName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_PName", bse_Dict.Dict_PName);
         }
          }
         if(bse_Dict.Dict_Desp_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_Desp))
         {
            idb.AddParameter("@Dict_Desp", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Desp", bse_Dict.Dict_Desp);
         }
          }
         if(bse_Dict.Dict_SCode_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_SCode))
         {
            idb.AddParameter("@Dict_SCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_SCode", bse_Dict.Dict_SCode);
         }
          }
         if(bse_Dict.Dict_Bak_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_Bak))
         {
            idb.AddParameter("@Dict_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_Bak", bse_Dict.Dict_Bak);
         }
          }
         if(bse_Dict.Dict_UDef1_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef1))
         {
            idb.AddParameter("@Dict_UDef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef1", bse_Dict.Dict_UDef1);
         }
          }
         if(bse_Dict.Dict_UDef2_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef2))
         {
            idb.AddParameter("@Dict_UDef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef2", bse_Dict.Dict_UDef2);
         }
          }
         if(bse_Dict.Dict_UDef3_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef3))
         {
            idb.AddParameter("@Dict_UDef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef3", bse_Dict.Dict_UDef3);
         }
          }
         if(bse_Dict.Dict_UDef4_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef4))
         {
            idb.AddParameter("@Dict_UDef4", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef4", bse_Dict.Dict_UDef4);
         }
          }
         if(bse_Dict.Dict_UDef5_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Dict.Dict_UDef5))
         {
            idb.AddParameter("@Dict_UDef5", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Dict_UDef5", bse_Dict.Dict_UDef5);
         }
          }
         if(bse_Dict.Dict_Level_IsChanged)
         {
         if (bse_Dict.Dict_Level == 0)
         {
            idb.AddParameter("@Dict_Level", 0);
         }
         else
         {
            idb.AddParameter("@Dict_Level", bse_Dict.Dict_Level);
         }
          }
         if(bse_Dict.Dict_IsEditable_IsChanged)
         {
         if (bse_Dict.Dict_IsEditable == 0)
         {
            idb.AddParameter("@Dict_IsEditable", 0);
         }
         else
         {
            idb.AddParameter("@Dict_IsEditable", bse_Dict.Dict_IsEditable);
         }
          }
         if(bse_Dict.Stat_IsChanged)
         {
         if (bse_Dict.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", bse_Dict.Stat);
         }
          }
         if(bse_Dict.Dict_Order_IsChanged)
         {
         if (bse_Dict.Dict_Order == 0)
         {
            idb.AddParameter("@Dict_Order", 0);
         }
         else
         {
            idb.AddParameter("@Dict_Order", bse_Dict.Dict_Order);
         }
          }

         idb.AddParameter("@Dict_ID", bse_Dict.Dict_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除数据字典 Bse_Dict对象(即:一条记录
      /// </summary>
      public int Delete(decimal dict_ID)
      {
         string sql = "DELETE Bse_Dict WHERE 1=1  AND Dict_ID=@Dict_ID ";
         idb.AddParameter("@Dict_ID", dict_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的数据字典 Bse_Dict对象(即:一条记录
      /// </summary>
      public Bse_Dict GetByKey(decimal dict_ID)
      {
         Bse_Dict bse_Dict = new Bse_Dict();
         string sql = "SELECT  Dict_ID,Dict_Key,Dict_Code,Dict_Name,Dict_PCode,Dict_PName,Dict_Desp,Dict_SCode,Dict_Bak,Dict_UDef1,Dict_UDef2,Dict_UDef3,Dict_UDef4,Dict_UDef5,Dict_Level,Dict_IsEditable,Stat,Dict_Order FROM Bse_Dict WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND Dict_ID=@Dict_ID ";
         idb.AddParameter("@Dict_ID", dict_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["Dict_ID"] != DBNull.Value) bse_Dict.Dict_ID = Convert.ToDecimal(dr["Dict_ID"]);
            if (dr["Dict_Key"] != DBNull.Value) bse_Dict.Dict_Key = Convert.ToString(dr["Dict_Key"]);
            if (dr["Dict_Code"] != DBNull.Value) bse_Dict.Dict_Code = Convert.ToString(dr["Dict_Code"]);
            if (dr["Dict_Name"] != DBNull.Value) bse_Dict.Dict_Name = Convert.ToString(dr["Dict_Name"]);
            if (dr["Dict_PCode"] != DBNull.Value) bse_Dict.Dict_PCode = Convert.ToString(dr["Dict_PCode"]);
            if (dr["Dict_PName"] != DBNull.Value) bse_Dict.Dict_PName = Convert.ToString(dr["Dict_PName"]);
            if (dr["Dict_Desp"] != DBNull.Value) bse_Dict.Dict_Desp = Convert.ToString(dr["Dict_Desp"]);
            if (dr["Dict_SCode"] != DBNull.Value) bse_Dict.Dict_SCode = Convert.ToString(dr["Dict_SCode"]);
            if (dr["Dict_Bak"] != DBNull.Value) bse_Dict.Dict_Bak = Convert.ToString(dr["Dict_Bak"]);
            if (dr["Dict_UDef1"] != DBNull.Value) bse_Dict.Dict_UDef1 = Convert.ToString(dr["Dict_UDef1"]);
            if (dr["Dict_UDef2"] != DBNull.Value) bse_Dict.Dict_UDef2 = Convert.ToString(dr["Dict_UDef2"]);
            if (dr["Dict_UDef3"] != DBNull.Value) bse_Dict.Dict_UDef3 = Convert.ToString(dr["Dict_UDef3"]);
            if (dr["Dict_UDef4"] != DBNull.Value) bse_Dict.Dict_UDef4 = Convert.ToString(dr["Dict_UDef4"]);
            if (dr["Dict_UDef5"] != DBNull.Value) bse_Dict.Dict_UDef5 = Convert.ToString(dr["Dict_UDef5"]);
            if (dr["Dict_Level"] != DBNull.Value) bse_Dict.Dict_Level = Convert.ToInt32(dr["Dict_Level"]);
            if (dr["Dict_IsEditable"] != DBNull.Value) bse_Dict.Dict_IsEditable = Convert.ToInt32(dr["Dict_IsEditable"]);
            if (dr["Stat"] != DBNull.Value) bse_Dict.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Dict_Order"] != DBNull.Value) bse_Dict.Dict_Order = Convert.ToInt32(dr["Dict_Order"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return bse_Dict;
      }
      /// <summary>
      /// 获取指定的数据字典 Bse_Dict对象集合
      /// </summary>
      public List<Bse_Dict> GetListByWhere(string strCondition)
      {
         List<Bse_Dict> ret = new List<Bse_Dict>();
         string sql = "SELECT  Dict_ID,Dict_Key,Dict_Code,Dict_Name,Dict_PCode,Dict_PName,Dict_Desp,Dict_SCode,Dict_Bak,Dict_UDef1,Dict_UDef2,Dict_UDef3,Dict_UDef4,Dict_UDef5,Dict_Level,Dict_IsEditable,Stat,Dict_Order FROM Bse_Dict WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Bse_Dict bse_Dict = new Bse_Dict();
            if (dr["Dict_ID"] != DBNull.Value) bse_Dict.Dict_ID = Convert.ToDecimal(dr["Dict_ID"]);
            if (dr["Dict_Key"] != DBNull.Value) bse_Dict.Dict_Key = Convert.ToString(dr["Dict_Key"]);
            if (dr["Dict_Code"] != DBNull.Value) bse_Dict.Dict_Code = Convert.ToString(dr["Dict_Code"]);
            if (dr["Dict_Name"] != DBNull.Value) bse_Dict.Dict_Name = Convert.ToString(dr["Dict_Name"]);
            if (dr["Dict_PCode"] != DBNull.Value) bse_Dict.Dict_PCode = Convert.ToString(dr["Dict_PCode"]);
            if (dr["Dict_PName"] != DBNull.Value) bse_Dict.Dict_PName = Convert.ToString(dr["Dict_PName"]);
            if (dr["Dict_Desp"] != DBNull.Value) bse_Dict.Dict_Desp = Convert.ToString(dr["Dict_Desp"]);
            if (dr["Dict_SCode"] != DBNull.Value) bse_Dict.Dict_SCode = Convert.ToString(dr["Dict_SCode"]);
            if (dr["Dict_Bak"] != DBNull.Value) bse_Dict.Dict_Bak = Convert.ToString(dr["Dict_Bak"]);
            if (dr["Dict_UDef1"] != DBNull.Value) bse_Dict.Dict_UDef1 = Convert.ToString(dr["Dict_UDef1"]);
            if (dr["Dict_UDef2"] != DBNull.Value) bse_Dict.Dict_UDef2 = Convert.ToString(dr["Dict_UDef2"]);
            if (dr["Dict_UDef3"] != DBNull.Value) bse_Dict.Dict_UDef3 = Convert.ToString(dr["Dict_UDef3"]);
            if (dr["Dict_UDef4"] != DBNull.Value) bse_Dict.Dict_UDef4 = Convert.ToString(dr["Dict_UDef4"]);
            if (dr["Dict_UDef5"] != DBNull.Value) bse_Dict.Dict_UDef5 = Convert.ToString(dr["Dict_UDef5"]);
            if (dr["Dict_Level"] != DBNull.Value) bse_Dict.Dict_Level = Convert.ToInt32(dr["Dict_Level"]);
            if (dr["Dict_IsEditable"] != DBNull.Value) bse_Dict.Dict_IsEditable = Convert.ToInt32(dr["Dict_IsEditable"]);
            if (dr["Stat"] != DBNull.Value) bse_Dict.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Dict_Order"] != DBNull.Value) bse_Dict.Dict_Order = Convert.ToInt32(dr["Dict_Order"]);
            ret.Add(bse_Dict);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的数据字典 Bse_Dict对象(即:一条记录
      /// </summary>
      public List<Bse_Dict> GetAll()
      {
         List<Bse_Dict> ret = new List<Bse_Dict>();
         string sql = "SELECT  Dict_ID,Dict_Key,Dict_Code,Dict_Name,Dict_PCode,Dict_PName,Dict_Desp,Dict_SCode,Dict_Bak,Dict_UDef1,Dict_UDef2,Dict_UDef3,Dict_UDef4,Dict_UDef5,Dict_Level,Dict_IsEditable,Stat,Dict_Order FROM Bse_Dict where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Bse_Dict bse_Dict = new Bse_Dict();
            if (dr["Dict_ID"] != DBNull.Value) bse_Dict.Dict_ID = Convert.ToDecimal(dr["Dict_ID"]);
            if (dr["Dict_Key"] != DBNull.Value) bse_Dict.Dict_Key = Convert.ToString(dr["Dict_Key"]);
            if (dr["Dict_Code"] != DBNull.Value) bse_Dict.Dict_Code = Convert.ToString(dr["Dict_Code"]);
            if (dr["Dict_Name"] != DBNull.Value) bse_Dict.Dict_Name = Convert.ToString(dr["Dict_Name"]);
            if (dr["Dict_PCode"] != DBNull.Value) bse_Dict.Dict_PCode = Convert.ToString(dr["Dict_PCode"]);
            if (dr["Dict_PName"] != DBNull.Value) bse_Dict.Dict_PName = Convert.ToString(dr["Dict_PName"]);
            if (dr["Dict_Desp"] != DBNull.Value) bse_Dict.Dict_Desp = Convert.ToString(dr["Dict_Desp"]);
            if (dr["Dict_SCode"] != DBNull.Value) bse_Dict.Dict_SCode = Convert.ToString(dr["Dict_SCode"]);
            if (dr["Dict_Bak"] != DBNull.Value) bse_Dict.Dict_Bak = Convert.ToString(dr["Dict_Bak"]);
            if (dr["Dict_UDef1"] != DBNull.Value) bse_Dict.Dict_UDef1 = Convert.ToString(dr["Dict_UDef1"]);
            if (dr["Dict_UDef2"] != DBNull.Value) bse_Dict.Dict_UDef2 = Convert.ToString(dr["Dict_UDef2"]);
            if (dr["Dict_UDef3"] != DBNull.Value) bse_Dict.Dict_UDef3 = Convert.ToString(dr["Dict_UDef3"]);
            if (dr["Dict_UDef4"] != DBNull.Value) bse_Dict.Dict_UDef4 = Convert.ToString(dr["Dict_UDef4"]);
            if (dr["Dict_UDef5"] != DBNull.Value) bse_Dict.Dict_UDef5 = Convert.ToString(dr["Dict_UDef5"]);
            if (dr["Dict_Level"] != DBNull.Value) bse_Dict.Dict_Level = Convert.ToInt32(dr["Dict_Level"]);
            if (dr["Dict_IsEditable"] != DBNull.Value) bse_Dict.Dict_IsEditable = Convert.ToInt32(dr["Dict_IsEditable"]);
            if (dr["Stat"] != DBNull.Value) bse_Dict.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Dict_Order"] != DBNull.Value) bse_Dict.Dict_Order = Convert.ToInt32(dr["Dict_Order"]);
            ret.Add(bse_Dict);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
