using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using QX.GenFramework.Model;
using QX.DataAcess;

namespace QX.GenFramework.ADO
{
   [Serializable]
   public partial class ADOSys_PD_GridFormat
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Sys_PD_GridFormat对象(即:一条记录)
      /// </summary>
      public int Add(Sys_PD_GridFormat sys_PD_GridFormat)
      {
         string sql = "INSERT INTO Sys_PD_GridFormat (Empl_NO,ColFor_Code,ColFor_ColName,ColFor_ColOrder,ColFor_ColWidth,Stat) VALUES (@Empl_NO,@ColFor_Code,@ColFor_ColName,@ColFor_ColOrder,@ColFor_ColWidth,@Stat)";
         if (string.IsNullOrEmpty(sys_PD_GridFormat.Empl_NO))
         {
            idb.AddParameter("@Empl_NO", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Empl_NO", sys_PD_GridFormat.Empl_NO);
         }
         if (string.IsNullOrEmpty(sys_PD_GridFormat.ColFor_Code))
         {
            idb.AddParameter("@ColFor_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ColFor_Code", sys_PD_GridFormat.ColFor_Code);
         }
         if (string.IsNullOrEmpty(sys_PD_GridFormat.ColFor_ColName))
         {
            idb.AddParameter("@ColFor_ColName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ColFor_ColName", sys_PD_GridFormat.ColFor_ColName);
         }
         if (sys_PD_GridFormat.ColFor_ColOrder == 0)
         {
            idb.AddParameter("@ColFor_ColOrder", 0);
         }
         else
         {
            idb.AddParameter("@ColFor_ColOrder", sys_PD_GridFormat.ColFor_ColOrder);
         }
         if (string.IsNullOrEmpty(sys_PD_GridFormat.ColFor_ColWidth))
         {
            idb.AddParameter("@ColFor_ColWidth", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ColFor_ColWidth", sys_PD_GridFormat.ColFor_ColWidth);
         }
         if (sys_PD_GridFormat.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_GridFormat.Stat);
         }

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加Sys_PD_GridFormat对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Sys_PD_GridFormat sys_PD_GridFormat)
      {
         string sql = "INSERT INTO Sys_PD_GridFormat (Empl_NO,ColFor_Code,ColFor_ColName,ColFor_ColOrder,ColFor_ColWidth,Stat) VALUES (@Empl_NO,@ColFor_Code,@ColFor_ColName,@ColFor_ColOrder,@ColFor_ColWidth,@Stat);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(sys_PD_GridFormat.Empl_NO))
         {
            idb.AddParameter("@Empl_NO", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Empl_NO", sys_PD_GridFormat.Empl_NO);
         }
         if (string.IsNullOrEmpty(sys_PD_GridFormat.ColFor_Code))
         {
            idb.AddParameter("@ColFor_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ColFor_Code", sys_PD_GridFormat.ColFor_Code);
         }
         if (string.IsNullOrEmpty(sys_PD_GridFormat.ColFor_ColName))
         {
            idb.AddParameter("@ColFor_ColName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ColFor_ColName", sys_PD_GridFormat.ColFor_ColName);
         }
         if (sys_PD_GridFormat.ColFor_ColOrder == 0)
         {
            idb.AddParameter("@ColFor_ColOrder", 0);
         }
         else
         {
            idb.AddParameter("@ColFor_ColOrder", sys_PD_GridFormat.ColFor_ColOrder);
         }
         if (string.IsNullOrEmpty(sys_PD_GridFormat.ColFor_ColWidth))
         {
            idb.AddParameter("@ColFor_ColWidth", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ColFor_ColWidth", sys_PD_GridFormat.ColFor_ColWidth);
         }
         if (sys_PD_GridFormat.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_GridFormat.Stat);
         }

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新Sys_PD_GridFormat对象(即:一条记录
      /// </summary>
      public int Update(Sys_PD_GridFormat sys_PD_GridFormat)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Sys_PD_GridFormat       SET ");
            if(sys_PD_GridFormat.Empl_NO_IsChanged){sbParameter.Append("Empl_NO=@Empl_NO, ");}
      if(sys_PD_GridFormat.ColFor_Code_IsChanged){sbParameter.Append("ColFor_Code=@ColFor_Code, ");}
      if(sys_PD_GridFormat.ColFor_ColName_IsChanged){sbParameter.Append("ColFor_ColName=@ColFor_ColName, ");}
      if(sys_PD_GridFormat.ColFor_ColOrder_IsChanged){sbParameter.Append("ColFor_ColOrder=@ColFor_ColOrder, ");}
      if(sys_PD_GridFormat.ColFor_ColWidth_IsChanged){sbParameter.Append("ColFor_ColWidth=@ColFor_ColWidth, ");}
      if(sys_PD_GridFormat.Stat_IsChanged){sbParameter.Append("Stat=@Stat ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and SPGF_ID=@SPGF_ID; " );
      string sql=sb.ToString();
         if(sys_PD_GridFormat.Empl_NO_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_GridFormat.Empl_NO))
         {
            idb.AddParameter("@Empl_NO", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Empl_NO", sys_PD_GridFormat.Empl_NO);
         }
          }
         if(sys_PD_GridFormat.ColFor_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_GridFormat.ColFor_Code))
         {
            idb.AddParameter("@ColFor_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ColFor_Code", sys_PD_GridFormat.ColFor_Code);
         }
          }
         if(sys_PD_GridFormat.ColFor_ColName_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_GridFormat.ColFor_ColName))
         {
            idb.AddParameter("@ColFor_ColName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ColFor_ColName", sys_PD_GridFormat.ColFor_ColName);
         }
          }
         if(sys_PD_GridFormat.ColFor_ColOrder_IsChanged)
         {
         if (sys_PD_GridFormat.ColFor_ColOrder == 0)
         {
            idb.AddParameter("@ColFor_ColOrder", 0);
         }
         else
         {
            idb.AddParameter("@ColFor_ColOrder", sys_PD_GridFormat.ColFor_ColOrder);
         }
          }
         if(sys_PD_GridFormat.ColFor_ColWidth_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_GridFormat.ColFor_ColWidth))
         {
            idb.AddParameter("@ColFor_ColWidth", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@ColFor_ColWidth", sys_PD_GridFormat.ColFor_ColWidth);
         }
          }
         if(sys_PD_GridFormat.Stat_IsChanged)
         {
         if (sys_PD_GridFormat.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_GridFormat.Stat);
         }
          }

         idb.AddParameter("@SPGF_ID", sys_PD_GridFormat.SPGF_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除Sys_PD_GridFormat对象(即:一条记录
      /// </summary>
      public int Delete(Int64 sPGF_ID)
      {
         string sql = "DELETE Sys_PD_GridFormat WHERE 1=1  AND SPGF_ID=@SPGF_ID ";
         idb.AddParameter("@SPGF_ID", sPGF_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Sys_PD_GridFormat对象(即:一条记录
      /// </summary>
      public Sys_PD_GridFormat GetByKey(Int64 sPGF_ID)
      {
         Sys_PD_GridFormat sys_PD_GridFormat = new Sys_PD_GridFormat();
         string sql = "SELECT  SPGF_ID,Empl_NO,ColFor_Code,ColFor_ColName,ColFor_ColOrder,ColFor_ColWidth,Stat FROM Sys_PD_GridFormat WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND SPGF_ID=@SPGF_ID ";
         idb.AddParameter("@SPGF_ID", sPGF_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["SPGF_ID"] != DBNull.Value) sys_PD_GridFormat.SPGF_ID = Convert.ToInt64(dr["SPGF_ID"]);
            if (dr["Empl_NO"] != DBNull.Value) sys_PD_GridFormat.Empl_NO = Convert.ToString(dr["Empl_NO"]);
            if (dr["ColFor_Code"] != DBNull.Value) sys_PD_GridFormat.ColFor_Code = Convert.ToString(dr["ColFor_Code"]);
            if (dr["ColFor_ColName"] != DBNull.Value) sys_PD_GridFormat.ColFor_ColName = Convert.ToString(dr["ColFor_ColName"]);
            if (dr["ColFor_ColOrder"] != DBNull.Value) sys_PD_GridFormat.ColFor_ColOrder = Convert.ToInt32(dr["ColFor_ColOrder"]);
            if (dr["ColFor_ColWidth"] != DBNull.Value) sys_PD_GridFormat.ColFor_ColWidth = Convert.ToString(dr["ColFor_ColWidth"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_GridFormat.Stat = Convert.ToInt32(dr["Stat"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return sys_PD_GridFormat;
      }
      /// <summary>
      /// 获取指定的Sys_PD_GridFormat对象集合
      /// </summary>
      public List<Sys_PD_GridFormat> GetListByWhere(string strCondition)
      {
         List<Sys_PD_GridFormat> ret = new List<Sys_PD_GridFormat>();
         string sql = "SELECT  SPGF_ID,Empl_NO,ColFor_Code,ColFor_ColName,ColFor_ColOrder,ColFor_ColWidth,Stat FROM Sys_PD_GridFormat WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
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
            Sys_PD_GridFormat sys_PD_GridFormat = new Sys_PD_GridFormat();
            if (dr["SPGF_ID"] != DBNull.Value) sys_PD_GridFormat.SPGF_ID = Convert.ToInt64(dr["SPGF_ID"]);
            if (dr["Empl_NO"] != DBNull.Value) sys_PD_GridFormat.Empl_NO = Convert.ToString(dr["Empl_NO"]);
            if (dr["ColFor_Code"] != DBNull.Value) sys_PD_GridFormat.ColFor_Code = Convert.ToString(dr["ColFor_Code"]);
            if (dr["ColFor_ColName"] != DBNull.Value) sys_PD_GridFormat.ColFor_ColName = Convert.ToString(dr["ColFor_ColName"]);
            if (dr["ColFor_ColOrder"] != DBNull.Value) sys_PD_GridFormat.ColFor_ColOrder = Convert.ToInt32(dr["ColFor_ColOrder"]);
            if (dr["ColFor_ColWidth"] != DBNull.Value) sys_PD_GridFormat.ColFor_ColWidth = Convert.ToString(dr["ColFor_ColWidth"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_GridFormat.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(sys_PD_GridFormat);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Sys_PD_GridFormat对象(即:一条记录
      /// </summary>
      public List<Sys_PD_GridFormat> GetAll()
      {
         List<Sys_PD_GridFormat> ret = new List<Sys_PD_GridFormat>();
         string sql = "SELECT  SPGF_ID,Empl_NO,ColFor_Code,ColFor_ColName,ColFor_ColOrder,ColFor_ColWidth,Stat FROM Sys_PD_GridFormat where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_PD_GridFormat sys_PD_GridFormat = new Sys_PD_GridFormat();
            if (dr["SPGF_ID"] != DBNull.Value) sys_PD_GridFormat.SPGF_ID = Convert.ToInt64(dr["SPGF_ID"]);
            if (dr["Empl_NO"] != DBNull.Value) sys_PD_GridFormat.Empl_NO = Convert.ToString(dr["Empl_NO"]);
            if (dr["ColFor_Code"] != DBNull.Value) sys_PD_GridFormat.ColFor_Code = Convert.ToString(dr["ColFor_Code"]);
            if (dr["ColFor_ColName"] != DBNull.Value) sys_PD_GridFormat.ColFor_ColName = Convert.ToString(dr["ColFor_ColName"]);
            if (dr["ColFor_ColOrder"] != DBNull.Value) sys_PD_GridFormat.ColFor_ColOrder = Convert.ToInt32(dr["ColFor_ColOrder"]);
            if (dr["ColFor_ColWidth"] != DBNull.Value) sys_PD_GridFormat.ColFor_ColWidth = Convert.ToString(dr["ColFor_ColWidth"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_GridFormat.Stat = Convert.ToInt32(dr["Stat"]);
            ret.Add(sys_PD_GridFormat);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
