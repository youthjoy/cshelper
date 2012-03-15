using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using QX.GenFramework.Model;
using QX.DataAcess;
using QX.GenFramework.Model;

namespace QX.GenFramework.ADO
{
   [Serializable]
   public partial class ADOSys_PD_Module
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Sys_PD_Module对象(即:一条记录)
      /// </summary>
      public int Add(Sys_PD_Module sys_PD_Module)
      {
         string sql = "INSERT INTO Sys_PD_Module (SPM_Module,SPM_LPrefix,SPM_Name,SPM_LX,SPM_LY,SPM_TX,SPM_TY,SPM_LI,SPM_TI,SPM_CNum,SPM_TPrefix,SPM_Height,SPM_Form1,SPM_Form2,Stat,SPM_IsSummary,SPM_IsFilter) VALUES (@SPM_Module,@SPM_LPrefix,@SPM_Name,@SPM_LX,@SPM_LY,@SPM_TX,@SPM_TY,@SPM_LI,@SPM_TI,@SPM_CNum,@SPM_TPrefix,@SPM_Height,@SPM_Form1,@SPM_Form2,@Stat,@SPM_IsSummary,@SPM_IsFilter)";
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Module))
         {
            idb.AddParameter("@SPM_Module", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Module", sys_PD_Module.SPM_Module);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_LPrefix))
         {
            idb.AddParameter("@SPM_LPrefix", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_LPrefix", sys_PD_Module.SPM_LPrefix);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Name))
         {
            idb.AddParameter("@SPM_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Name", sys_PD_Module.SPM_Name);
         }
         if (sys_PD_Module.SPM_LX == 0)
         {
            idb.AddParameter("@SPM_LX", 0);
         }
         else
         {
            idb.AddParameter("@SPM_LX", sys_PD_Module.SPM_LX);
         }
         if (sys_PD_Module.SPM_LY == 0)
         {
            idb.AddParameter("@SPM_LY", 0);
         }
         else
         {
            idb.AddParameter("@SPM_LY", sys_PD_Module.SPM_LY);
         }
         if (sys_PD_Module.SPM_TX == 0)
         {
            idb.AddParameter("@SPM_TX", 0);
         }
         else
         {
            idb.AddParameter("@SPM_TX", sys_PD_Module.SPM_TX);
         }
         if (sys_PD_Module.SPM_TY == 0)
         {
            idb.AddParameter("@SPM_TY", 0);
         }
         else
         {
            idb.AddParameter("@SPM_TY", sys_PD_Module.SPM_TY);
         }
         if (sys_PD_Module.SPM_LI == 0)
         {
            idb.AddParameter("@SPM_LI", 0);
         }
         else
         {
            idb.AddParameter("@SPM_LI", sys_PD_Module.SPM_LI);
         }
         if (sys_PD_Module.SPM_TI == 0)
         {
            idb.AddParameter("@SPM_TI", 0);
         }
         else
         {
            idb.AddParameter("@SPM_TI", sys_PD_Module.SPM_TI);
         }
         if (sys_PD_Module.SPM_CNum == 0)
         {
            idb.AddParameter("@SPM_CNum", 0);
         }
         else
         {
            idb.AddParameter("@SPM_CNum", sys_PD_Module.SPM_CNum);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_TPrefix))
         {
            idb.AddParameter("@SPM_TPrefix", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_TPrefix", sys_PD_Module.SPM_TPrefix);
         }
         if (sys_PD_Module.SPM_Height == 0)
         {
            idb.AddParameter("@SPM_Height", 0);
         }
         else
         {
            idb.AddParameter("@SPM_Height", sys_PD_Module.SPM_Height);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Form1))
         {
            idb.AddParameter("@SPM_Form1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Form1", sys_PD_Module.SPM_Form1);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Form2))
         {
            idb.AddParameter("@SPM_Form2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Form2", sys_PD_Module.SPM_Form2);
         }
         if (sys_PD_Module.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_Module.Stat);
         }
         if (sys_PD_Module.SPM_IsSummary == 0)
         {
            idb.AddParameter("@SPM_IsSummary", 0);
         }
         else
         {
            idb.AddParameter("@SPM_IsSummary", sys_PD_Module.SPM_IsSummary);
         }
         if (sys_PD_Module.SPM_IsFilter == 0)
         {
            idb.AddParameter("@SPM_IsFilter", 0);
         }
         else
         {
            idb.AddParameter("@SPM_IsFilter", sys_PD_Module.SPM_IsFilter);
         }

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加Sys_PD_Module对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Sys_PD_Module sys_PD_Module)
      {
         string sql = "INSERT INTO Sys_PD_Module (SPM_Module,SPM_LPrefix,SPM_Name,SPM_LX,SPM_LY,SPM_TX,SPM_TY,SPM_LI,SPM_TI,SPM_CNum,SPM_TPrefix,SPM_Height,SPM_Form1,SPM_Form2,Stat,SPM_IsSummary,SPM_IsFilter) VALUES (@SPM_Module,@SPM_LPrefix,@SPM_Name,@SPM_LX,@SPM_LY,@SPM_TX,@SPM_TY,@SPM_LI,@SPM_TI,@SPM_CNum,@SPM_TPrefix,@SPM_Height,@SPM_Form1,@SPM_Form2,@Stat,@SPM_IsSummary,@SPM_IsFilter);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Module))
         {
            idb.AddParameter("@SPM_Module", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Module", sys_PD_Module.SPM_Module);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_LPrefix))
         {
            idb.AddParameter("@SPM_LPrefix", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_LPrefix", sys_PD_Module.SPM_LPrefix);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Name))
         {
            idb.AddParameter("@SPM_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Name", sys_PD_Module.SPM_Name);
         }
         if (sys_PD_Module.SPM_LX == 0)
         {
            idb.AddParameter("@SPM_LX", 0);
         }
         else
         {
            idb.AddParameter("@SPM_LX", sys_PD_Module.SPM_LX);
         }
         if (sys_PD_Module.SPM_LY == 0)
         {
            idb.AddParameter("@SPM_LY", 0);
         }
         else
         {
            idb.AddParameter("@SPM_LY", sys_PD_Module.SPM_LY);
         }
         if (sys_PD_Module.SPM_TX == 0)
         {
            idb.AddParameter("@SPM_TX", 0);
         }
         else
         {
            idb.AddParameter("@SPM_TX", sys_PD_Module.SPM_TX);
         }
         if (sys_PD_Module.SPM_TY == 0)
         {
            idb.AddParameter("@SPM_TY", 0);
         }
         else
         {
            idb.AddParameter("@SPM_TY", sys_PD_Module.SPM_TY);
         }
         if (sys_PD_Module.SPM_LI == 0)
         {
            idb.AddParameter("@SPM_LI", 0);
         }
         else
         {
            idb.AddParameter("@SPM_LI", sys_PD_Module.SPM_LI);
         }
         if (sys_PD_Module.SPM_TI == 0)
         {
            idb.AddParameter("@SPM_TI", 0);
         }
         else
         {
            idb.AddParameter("@SPM_TI", sys_PD_Module.SPM_TI);
         }
         if (sys_PD_Module.SPM_CNum == 0)
         {
            idb.AddParameter("@SPM_CNum", 0);
         }
         else
         {
            idb.AddParameter("@SPM_CNum", sys_PD_Module.SPM_CNum);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_TPrefix))
         {
            idb.AddParameter("@SPM_TPrefix", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_TPrefix", sys_PD_Module.SPM_TPrefix);
         }
         if (sys_PD_Module.SPM_Height == 0)
         {
            idb.AddParameter("@SPM_Height", 0);
         }
         else
         {
            idb.AddParameter("@SPM_Height", sys_PD_Module.SPM_Height);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Form1))
         {
            idb.AddParameter("@SPM_Form1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Form1", sys_PD_Module.SPM_Form1);
         }
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Form2))
         {
            idb.AddParameter("@SPM_Form2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Form2", sys_PD_Module.SPM_Form2);
         }
         if (sys_PD_Module.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_Module.Stat);
         }
         if (sys_PD_Module.SPM_IsSummary == 0)
         {
            idb.AddParameter("@SPM_IsSummary", 0);
         }
         else
         {
            idb.AddParameter("@SPM_IsSummary", sys_PD_Module.SPM_IsSummary);
         }
         if (sys_PD_Module.SPM_IsFilter == 0)
         {
            idb.AddParameter("@SPM_IsFilter", 0);
         }
         else
         {
            idb.AddParameter("@SPM_IsFilter", sys_PD_Module.SPM_IsFilter);
         }

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新Sys_PD_Module对象(即:一条记录
      /// </summary>
      public int Update(Sys_PD_Module sys_PD_Module)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Sys_PD_Module       SET ");
            if(sys_PD_Module.SPM_Module_IsChanged){sbParameter.Append("SPM_Module=@SPM_Module, ");}
      if(sys_PD_Module.SPM_LPrefix_IsChanged){sbParameter.Append("SPM_LPrefix=@SPM_LPrefix, ");}
      if(sys_PD_Module.SPM_Name_IsChanged){sbParameter.Append("SPM_Name=@SPM_Name, ");}
      if(sys_PD_Module.SPM_LX_IsChanged){sbParameter.Append("SPM_LX=@SPM_LX, ");}
      if(sys_PD_Module.SPM_LY_IsChanged){sbParameter.Append("SPM_LY=@SPM_LY, ");}
      if(sys_PD_Module.SPM_TX_IsChanged){sbParameter.Append("SPM_TX=@SPM_TX, ");}
      if(sys_PD_Module.SPM_TY_IsChanged){sbParameter.Append("SPM_TY=@SPM_TY, ");}
      if(sys_PD_Module.SPM_LI_IsChanged){sbParameter.Append("SPM_LI=@SPM_LI, ");}
      if(sys_PD_Module.SPM_TI_IsChanged){sbParameter.Append("SPM_TI=@SPM_TI, ");}
      if(sys_PD_Module.SPM_CNum_IsChanged){sbParameter.Append("SPM_CNum=@SPM_CNum, ");}
      if(sys_PD_Module.SPM_TPrefix_IsChanged){sbParameter.Append("SPM_TPrefix=@SPM_TPrefix, ");}
      if(sys_PD_Module.SPM_Height_IsChanged){sbParameter.Append("SPM_Height=@SPM_Height, ");}
      if(sys_PD_Module.SPM_Form1_IsChanged){sbParameter.Append("SPM_Form1=@SPM_Form1, ");}
      if(sys_PD_Module.SPM_Form2_IsChanged){sbParameter.Append("SPM_Form2=@SPM_Form2, ");}
      if(sys_PD_Module.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(sys_PD_Module.SPM_IsSummary_IsChanged){sbParameter.Append("SPM_IsSummary=@SPM_IsSummary, ");}
      if(sys_PD_Module.SPM_IsFilter_IsChanged){sbParameter.Append("SPM_IsFilter=@SPM_IsFilter ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and SPM_ID=@SPM_ID; " );
      string sql=sb.ToString();
         if(sys_PD_Module.SPM_Module_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Module))
         {
            idb.AddParameter("@SPM_Module", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Module", sys_PD_Module.SPM_Module);
         }
          }
         if(sys_PD_Module.SPM_LPrefix_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_LPrefix))
         {
            idb.AddParameter("@SPM_LPrefix", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_LPrefix", sys_PD_Module.SPM_LPrefix);
         }
          }
         if(sys_PD_Module.SPM_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Name))
         {
            idb.AddParameter("@SPM_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Name", sys_PD_Module.SPM_Name);
         }
          }
         if(sys_PD_Module.SPM_LX_IsChanged)
         {
         if (sys_PD_Module.SPM_LX == 0)
         {
            idb.AddParameter("@SPM_LX", 0);
         }
         else
         {
            idb.AddParameter("@SPM_LX", sys_PD_Module.SPM_LX);
         }
          }
         if(sys_PD_Module.SPM_LY_IsChanged)
         {
         if (sys_PD_Module.SPM_LY == 0)
         {
            idb.AddParameter("@SPM_LY", 0);
         }
         else
         {
            idb.AddParameter("@SPM_LY", sys_PD_Module.SPM_LY);
         }
          }
         if(sys_PD_Module.SPM_TX_IsChanged)
         {
         if (sys_PD_Module.SPM_TX == 0)
         {
            idb.AddParameter("@SPM_TX", 0);
         }
         else
         {
            idb.AddParameter("@SPM_TX", sys_PD_Module.SPM_TX);
         }
          }
         if(sys_PD_Module.SPM_TY_IsChanged)
         {
         if (sys_PD_Module.SPM_TY == 0)
         {
            idb.AddParameter("@SPM_TY", 0);
         }
         else
         {
            idb.AddParameter("@SPM_TY", sys_PD_Module.SPM_TY);
         }
          }
         if(sys_PD_Module.SPM_LI_IsChanged)
         {
         if (sys_PD_Module.SPM_LI == 0)
         {
            idb.AddParameter("@SPM_LI", 0);
         }
         else
         {
            idb.AddParameter("@SPM_LI", sys_PD_Module.SPM_LI);
         }
          }
         if(sys_PD_Module.SPM_TI_IsChanged)
         {
         if (sys_PD_Module.SPM_TI == 0)
         {
            idb.AddParameter("@SPM_TI", 0);
         }
         else
         {
            idb.AddParameter("@SPM_TI", sys_PD_Module.SPM_TI);
         }
          }
         if(sys_PD_Module.SPM_CNum_IsChanged)
         {
         if (sys_PD_Module.SPM_CNum == 0)
         {
            idb.AddParameter("@SPM_CNum", 0);
         }
         else
         {
            idb.AddParameter("@SPM_CNum", sys_PD_Module.SPM_CNum);
         }
          }
         if(sys_PD_Module.SPM_TPrefix_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_TPrefix))
         {
            idb.AddParameter("@SPM_TPrefix", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_TPrefix", sys_PD_Module.SPM_TPrefix);
         }
          }
         if(sys_PD_Module.SPM_Height_IsChanged)
         {
         if (sys_PD_Module.SPM_Height == 0)
         {
            idb.AddParameter("@SPM_Height", 0);
         }
         else
         {
            idb.AddParameter("@SPM_Height", sys_PD_Module.SPM_Height);
         }
          }
         if(sys_PD_Module.SPM_Form1_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Form1))
         {
            idb.AddParameter("@SPM_Form1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Form1", sys_PD_Module.SPM_Form1);
         }
          }
         if(sys_PD_Module.SPM_Form2_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Module.SPM_Form2))
         {
            idb.AddParameter("@SPM_Form2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@SPM_Form2", sys_PD_Module.SPM_Form2);
         }
          }
         if(sys_PD_Module.Stat_IsChanged)
         {
         if (sys_PD_Module.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_Module.Stat);
         }
          }
         if(sys_PD_Module.SPM_IsSummary_IsChanged)
         {
         if (sys_PD_Module.SPM_IsSummary == 0)
         {
            idb.AddParameter("@SPM_IsSummary", 0);
         }
         else
         {
            idb.AddParameter("@SPM_IsSummary", sys_PD_Module.SPM_IsSummary);
         }
          }
         if(sys_PD_Module.SPM_IsFilter_IsChanged)
         {
         if (sys_PD_Module.SPM_IsFilter == 0)
         {
            idb.AddParameter("@SPM_IsFilter", 0);
         }
         else
         {
            idb.AddParameter("@SPM_IsFilter", sys_PD_Module.SPM_IsFilter);
         }
          }

         idb.AddParameter("@SPM_ID", sys_PD_Module.SPM_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除Sys_PD_Module对象(即:一条记录
      /// </summary>
      public int Delete(decimal sPM_ID)
      {
         string sql = "DELETE Sys_PD_Module WHERE 1=1  AND SPM_ID=@SPM_ID ";
         idb.AddParameter("@SPM_ID", sPM_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Sys_PD_Module对象(即:一条记录
      /// </summary>
      public Sys_PD_Module GetByKey(decimal sPM_ID)
      {
         Sys_PD_Module sys_PD_Module = new Sys_PD_Module();
         string sql = "SELECT  SPM_ID,SPM_Module,SPM_LPrefix,SPM_Name,SPM_LX,SPM_LY,SPM_TX,SPM_TY,SPM_LI,SPM_TI,SPM_CNum,SPM_TPrefix,SPM_Height,SPM_Form1,SPM_Form2,Stat,SPM_IsSummary,SPM_IsFilter FROM Sys_PD_Module WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND SPM_ID=@SPM_ID ";
         idb.AddParameter("@SPM_ID", sPM_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["SPM_ID"] != DBNull.Value) sys_PD_Module.SPM_ID = Convert.ToDecimal(dr["SPM_ID"]);
            if (dr["SPM_Module"] != DBNull.Value) sys_PD_Module.SPM_Module = Convert.ToString(dr["SPM_Module"]);
            if (dr["SPM_LPrefix"] != DBNull.Value) sys_PD_Module.SPM_LPrefix = Convert.ToString(dr["SPM_LPrefix"]);
            if (dr["SPM_Name"] != DBNull.Value) sys_PD_Module.SPM_Name = Convert.ToString(dr["SPM_Name"]);
            if (dr["SPM_LX"] != DBNull.Value) sys_PD_Module.SPM_LX = Convert.ToInt32(dr["SPM_LX"]);
            if (dr["SPM_LY"] != DBNull.Value) sys_PD_Module.SPM_LY = Convert.ToInt32(dr["SPM_LY"]);
            if (dr["SPM_TX"] != DBNull.Value) sys_PD_Module.SPM_TX = Convert.ToInt32(dr["SPM_TX"]);
            if (dr["SPM_TY"] != DBNull.Value) sys_PD_Module.SPM_TY = Convert.ToInt32(dr["SPM_TY"]);
            if (dr["SPM_LI"] != DBNull.Value) sys_PD_Module.SPM_LI = Convert.ToInt32(dr["SPM_LI"]);
            if (dr["SPM_TI"] != DBNull.Value) sys_PD_Module.SPM_TI = Convert.ToInt32(dr["SPM_TI"]);
            if (dr["SPM_CNum"] != DBNull.Value) sys_PD_Module.SPM_CNum = Convert.ToInt32(dr["SPM_CNum"]);
            if (dr["SPM_TPrefix"] != DBNull.Value) sys_PD_Module.SPM_TPrefix = Convert.ToString(dr["SPM_TPrefix"]);
            if (dr["SPM_Height"] != DBNull.Value) sys_PD_Module.SPM_Height = Convert.ToInt32(dr["SPM_Height"]);
            if (dr["SPM_Form1"] != DBNull.Value) sys_PD_Module.SPM_Form1 = Convert.ToString(dr["SPM_Form1"]);
            if (dr["SPM_Form2"] != DBNull.Value) sys_PD_Module.SPM_Form2 = Convert.ToString(dr["SPM_Form2"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_Module.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["SPM_IsSummary"] != DBNull.Value) sys_PD_Module.SPM_IsSummary = Convert.ToInt32(dr["SPM_IsSummary"]);
            if (dr["SPM_IsFilter"] != DBNull.Value) sys_PD_Module.SPM_IsFilter = Convert.ToInt32(dr["SPM_IsFilter"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return sys_PD_Module;
      }
      /// <summary>
      /// 获取指定的Sys_PD_Module对象集合
      /// </summary>
      public List<Sys_PD_Module> GetListByWhere(string strCondition)
      {
         List<Sys_PD_Module> ret = new List<Sys_PD_Module>();
         string sql = "SELECT  SPM_ID,SPM_Module,SPM_LPrefix,SPM_Name,SPM_LX,SPM_LY,SPM_TX,SPM_TY,SPM_LI,SPM_TI,SPM_CNum,SPM_TPrefix,SPM_Height,SPM_Form1,SPM_Form2,Stat,SPM_IsSummary,SPM_IsFilter FROM Sys_PD_Module WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
         if(!string.IsNullOrEmpty(strCondition))
         {
            strCondition.Replace('\'','"'); //防sql注入
            sql += strCondition ;
         }
          //sql += " ORDER BY SPM_ID DESC "; 
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_PD_Module sys_PD_Module = new Sys_PD_Module();
            if (dr["SPM_ID"] != DBNull.Value) sys_PD_Module.SPM_ID = Convert.ToDecimal(dr["SPM_ID"]);
            if (dr["SPM_Module"] != DBNull.Value) sys_PD_Module.SPM_Module = Convert.ToString(dr["SPM_Module"]);
            if (dr["SPM_LPrefix"] != DBNull.Value) sys_PD_Module.SPM_LPrefix = Convert.ToString(dr["SPM_LPrefix"]);
            if (dr["SPM_Name"] != DBNull.Value) sys_PD_Module.SPM_Name = Convert.ToString(dr["SPM_Name"]);
            if (dr["SPM_LX"] != DBNull.Value) sys_PD_Module.SPM_LX = Convert.ToInt32(dr["SPM_LX"]);
            if (dr["SPM_LY"] != DBNull.Value) sys_PD_Module.SPM_LY = Convert.ToInt32(dr["SPM_LY"]);
            if (dr["SPM_TX"] != DBNull.Value) sys_PD_Module.SPM_TX = Convert.ToInt32(dr["SPM_TX"]);
            if (dr["SPM_TY"] != DBNull.Value) sys_PD_Module.SPM_TY = Convert.ToInt32(dr["SPM_TY"]);
            if (dr["SPM_LI"] != DBNull.Value) sys_PD_Module.SPM_LI = Convert.ToInt32(dr["SPM_LI"]);
            if (dr["SPM_TI"] != DBNull.Value) sys_PD_Module.SPM_TI = Convert.ToInt32(dr["SPM_TI"]);
            if (dr["SPM_CNum"] != DBNull.Value) sys_PD_Module.SPM_CNum = Convert.ToInt32(dr["SPM_CNum"]);
            if (dr["SPM_TPrefix"] != DBNull.Value) sys_PD_Module.SPM_TPrefix = Convert.ToString(dr["SPM_TPrefix"]);
            if (dr["SPM_Height"] != DBNull.Value) sys_PD_Module.SPM_Height = Convert.ToInt32(dr["SPM_Height"]);
            if (dr["SPM_Form1"] != DBNull.Value) sys_PD_Module.SPM_Form1 = Convert.ToString(dr["SPM_Form1"]);
            if (dr["SPM_Form2"] != DBNull.Value) sys_PD_Module.SPM_Form2 = Convert.ToString(dr["SPM_Form2"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_Module.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["SPM_IsSummary"] != DBNull.Value) sys_PD_Module.SPM_IsSummary = Convert.ToInt32(dr["SPM_IsSummary"]);
            if (dr["SPM_IsFilter"] != DBNull.Value) sys_PD_Module.SPM_IsFilter = Convert.ToInt32(dr["SPM_IsFilter"]);
            ret.Add(sys_PD_Module);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Sys_PD_Module对象(即:一条记录
      /// </summary>
      public List<Sys_PD_Module> GetAll()
      {
         List<Sys_PD_Module> ret = new List<Sys_PD_Module>();
         string sql = "SELECT  SPM_ID,SPM_Module,SPM_LPrefix,SPM_Name,SPM_LX,SPM_LY,SPM_TX,SPM_TY,SPM_LI,SPM_TI,SPM_CNum,SPM_TPrefix,SPM_Height,SPM_Form1,SPM_Form2,Stat,SPM_IsSummary,SPM_IsFilter FROM Sys_PD_Module where 1=1 AND ((Stat is null) or (Stat=0) ) order by SPM_ID desc ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_PD_Module sys_PD_Module = new Sys_PD_Module();
            if (dr["SPM_ID"] != DBNull.Value) sys_PD_Module.SPM_ID = Convert.ToDecimal(dr["SPM_ID"]);
            if (dr["SPM_Module"] != DBNull.Value) sys_PD_Module.SPM_Module = Convert.ToString(dr["SPM_Module"]);
            if (dr["SPM_LPrefix"] != DBNull.Value) sys_PD_Module.SPM_LPrefix = Convert.ToString(dr["SPM_LPrefix"]);
            if (dr["SPM_Name"] != DBNull.Value) sys_PD_Module.SPM_Name = Convert.ToString(dr["SPM_Name"]);
            if (dr["SPM_LX"] != DBNull.Value) sys_PD_Module.SPM_LX = Convert.ToInt32(dr["SPM_LX"]);
            if (dr["SPM_LY"] != DBNull.Value) sys_PD_Module.SPM_LY = Convert.ToInt32(dr["SPM_LY"]);
            if (dr["SPM_TX"] != DBNull.Value) sys_PD_Module.SPM_TX = Convert.ToInt32(dr["SPM_TX"]);
            if (dr["SPM_TY"] != DBNull.Value) sys_PD_Module.SPM_TY = Convert.ToInt32(dr["SPM_TY"]);
            if (dr["SPM_LI"] != DBNull.Value) sys_PD_Module.SPM_LI = Convert.ToInt32(dr["SPM_LI"]);
            if (dr["SPM_TI"] != DBNull.Value) sys_PD_Module.SPM_TI = Convert.ToInt32(dr["SPM_TI"]);
            if (dr["SPM_CNum"] != DBNull.Value) sys_PD_Module.SPM_CNum = Convert.ToInt32(dr["SPM_CNum"]);
            if (dr["SPM_TPrefix"] != DBNull.Value) sys_PD_Module.SPM_TPrefix = Convert.ToString(dr["SPM_TPrefix"]);
            if (dr["SPM_Height"] != DBNull.Value) sys_PD_Module.SPM_Height = Convert.ToInt32(dr["SPM_Height"]);
            if (dr["SPM_Form1"] != DBNull.Value) sys_PD_Module.SPM_Form1 = Convert.ToString(dr["SPM_Form1"]);
            if (dr["SPM_Form2"] != DBNull.Value) sys_PD_Module.SPM_Form2 = Convert.ToString(dr["SPM_Form2"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_Module.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["SPM_IsSummary"] != DBNull.Value) sys_PD_Module.SPM_IsSummary = Convert.ToInt32(dr["SPM_IsSummary"]);
            if (dr["SPM_IsFilter"] != DBNull.Value) sys_PD_Module.SPM_IsFilter = Convert.ToInt32(dr["SPM_IsFilter"]);
            ret.Add(sys_PD_Module);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
