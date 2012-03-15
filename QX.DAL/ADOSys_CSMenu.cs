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
   public partial class ADOSys_CSMenu
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Sys_CSMenu对象(即:一条记录)
      /// </summary>
      public int Add(Sys_CSMenu sys_CSMenu)
      {
         string sql = "INSERT INTO Sys_CSMenu (CMenu_Name,CMenu_Code,CMenu_PCode,CMenu_Path,CMenu_IsModule,CMenu_ExtParameter,CMenu_iType,CMenu_Image,CMenu_Level,Stat,CMenu_Udef1,CMenu_Udef2,CMenu_Udef3,CMenu_Order) VALUES (@CMenu_Name,@CMenu_Code,@CMenu_PCode,@CMenu_Path,@CMenu_IsModule,@CMenu_ExtParameter,@CMenu_iType,@CMenu_Image,@CMenu_Level,@Stat,@CMenu_Udef1,@CMenu_Udef2,@CMenu_Udef3,@CMenu_Order)";
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Name))
         {
            idb.AddParameter("@CMenu_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Name", sys_CSMenu.CMenu_Name);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Code))
         {
            idb.AddParameter("@CMenu_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Code", sys_CSMenu.CMenu_Code);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_PCode))
         {
            idb.AddParameter("@CMenu_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_PCode", sys_CSMenu.CMenu_PCode);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Path))
         {
            idb.AddParameter("@CMenu_Path", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Path", sys_CSMenu.CMenu_Path);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_IsModule))
         {
            idb.AddParameter("@CMenu_IsModule", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_IsModule", sys_CSMenu.CMenu_IsModule);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_ExtParameter))
         {
            idb.AddParameter("@CMenu_ExtParameter", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_ExtParameter", sys_CSMenu.CMenu_ExtParameter);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_iType))
         {
            idb.AddParameter("@CMenu_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_iType", sys_CSMenu.CMenu_iType);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Image))
         {
            idb.AddParameter("@CMenu_Image", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Image", sys_CSMenu.CMenu_Image);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Level))
         {
            idb.AddParameter("@CMenu_Level", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Level", sys_CSMenu.CMenu_Level);
         }
         if (sys_CSMenu.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_CSMenu.Stat);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Udef1))
         {
            idb.AddParameter("@CMenu_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Udef1", sys_CSMenu.CMenu_Udef1);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Udef2))
         {
            idb.AddParameter("@CMenu_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Udef2", sys_CSMenu.CMenu_Udef2);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Udef3))
         {
            idb.AddParameter("@CMenu_Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Udef3", sys_CSMenu.CMenu_Udef3);
         }
         if (sys_CSMenu.CMenu_Order == 0)
         {
            idb.AddParameter("@CMenu_Order", 0);
         }
         else
         {
            idb.AddParameter("@CMenu_Order", sys_CSMenu.CMenu_Order);
         }

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加Sys_CSMenu对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Sys_CSMenu sys_CSMenu)
      {
         string sql = "INSERT INTO Sys_CSMenu (CMenu_Name,CMenu_Code,CMenu_PCode,CMenu_Path,CMenu_IsModule,CMenu_ExtParameter,CMenu_iType,CMenu_Image,CMenu_Level,Stat,CMenu_Udef1,CMenu_Udef2,CMenu_Udef3,CMenu_Order) VALUES (@CMenu_Name,@CMenu_Code,@CMenu_PCode,@CMenu_Path,@CMenu_IsModule,@CMenu_ExtParameter,@CMenu_iType,@CMenu_Image,@CMenu_Level,@Stat,@CMenu_Udef1,@CMenu_Udef2,@CMenu_Udef3,@CMenu_Order);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Name))
         {
            idb.AddParameter("@CMenu_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Name", sys_CSMenu.CMenu_Name);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Code))
         {
            idb.AddParameter("@CMenu_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Code", sys_CSMenu.CMenu_Code);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_PCode))
         {
            idb.AddParameter("@CMenu_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_PCode", sys_CSMenu.CMenu_PCode);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Path))
         {
            idb.AddParameter("@CMenu_Path", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Path", sys_CSMenu.CMenu_Path);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_IsModule))
         {
            idb.AddParameter("@CMenu_IsModule", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_IsModule", sys_CSMenu.CMenu_IsModule);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_ExtParameter))
         {
            idb.AddParameter("@CMenu_ExtParameter", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_ExtParameter", sys_CSMenu.CMenu_ExtParameter);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_iType))
         {
            idb.AddParameter("@CMenu_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_iType", sys_CSMenu.CMenu_iType);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Image))
         {
            idb.AddParameter("@CMenu_Image", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Image", sys_CSMenu.CMenu_Image);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Level))
         {
            idb.AddParameter("@CMenu_Level", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Level", sys_CSMenu.CMenu_Level);
         }
         if (sys_CSMenu.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_CSMenu.Stat);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Udef1))
         {
            idb.AddParameter("@CMenu_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Udef1", sys_CSMenu.CMenu_Udef1);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Udef2))
         {
            idb.AddParameter("@CMenu_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Udef2", sys_CSMenu.CMenu_Udef2);
         }
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Udef3))
         {
            idb.AddParameter("@CMenu_Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Udef3", sys_CSMenu.CMenu_Udef3);
         }
         if (sys_CSMenu.CMenu_Order == 0)
         {
            idb.AddParameter("@CMenu_Order", 0);
         }
         else
         {
            idb.AddParameter("@CMenu_Order", sys_CSMenu.CMenu_Order);
         }

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新Sys_CSMenu对象(即:一条记录
      /// </summary>
      public int Update(Sys_CSMenu sys_CSMenu)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Sys_CSMenu       SET ");
            if(sys_CSMenu.CMenu_Name_IsChanged){sbParameter.Append("CMenu_Name=@CMenu_Name, ");}
      if(sys_CSMenu.CMenu_Code_IsChanged){sbParameter.Append("CMenu_Code=@CMenu_Code, ");}
      if(sys_CSMenu.CMenu_PCode_IsChanged){sbParameter.Append("CMenu_PCode=@CMenu_PCode, ");}
      if(sys_CSMenu.CMenu_Path_IsChanged){sbParameter.Append("CMenu_Path=@CMenu_Path, ");}
      if(sys_CSMenu.CMenu_IsModule_IsChanged){sbParameter.Append("CMenu_IsModule=@CMenu_IsModule, ");}
      if(sys_CSMenu.CMenu_ExtParameter_IsChanged){sbParameter.Append("CMenu_ExtParameter=@CMenu_ExtParameter, ");}
      if(sys_CSMenu.CMenu_iType_IsChanged){sbParameter.Append("CMenu_iType=@CMenu_iType, ");}
      if(sys_CSMenu.CMenu_Image_IsChanged){sbParameter.Append("CMenu_Image=@CMenu_Image, ");}
      if(sys_CSMenu.CMenu_Level_IsChanged){sbParameter.Append("CMenu_Level=@CMenu_Level, ");}
      if(sys_CSMenu.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(sys_CSMenu.CMenu_Udef1_IsChanged){sbParameter.Append("CMenu_Udef1=@CMenu_Udef1, ");}
      if(sys_CSMenu.CMenu_Udef2_IsChanged){sbParameter.Append("CMenu_Udef2=@CMenu_Udef2, ");}
      if(sys_CSMenu.CMenu_Udef3_IsChanged){sbParameter.Append("CMenu_Udef3=@CMenu_Udef3, ");}
      if(sys_CSMenu.CMenu_Order_IsChanged){sbParameter.Append("CMenu_Order=@CMenu_Order ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and CMenu_ID=@CMenu_ID; " );
      string sql=sb.ToString();
         if(sys_CSMenu.CMenu_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Name))
         {
            idb.AddParameter("@CMenu_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Name", sys_CSMenu.CMenu_Name);
         }
          }
         if(sys_CSMenu.CMenu_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Code))
         {
            idb.AddParameter("@CMenu_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Code", sys_CSMenu.CMenu_Code);
         }
          }
         if(sys_CSMenu.CMenu_PCode_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_PCode))
         {
            idb.AddParameter("@CMenu_PCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_PCode", sys_CSMenu.CMenu_PCode);
         }
          }
         if(sys_CSMenu.CMenu_Path_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Path))
         {
            idb.AddParameter("@CMenu_Path", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Path", sys_CSMenu.CMenu_Path);
         }
          }
         if(sys_CSMenu.CMenu_IsModule_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_IsModule))
         {
            idb.AddParameter("@CMenu_IsModule", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_IsModule", sys_CSMenu.CMenu_IsModule);
         }
          }
         if(sys_CSMenu.CMenu_ExtParameter_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_ExtParameter))
         {
            idb.AddParameter("@CMenu_ExtParameter", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_ExtParameter", sys_CSMenu.CMenu_ExtParameter);
         }
          }
         if(sys_CSMenu.CMenu_iType_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_iType))
         {
            idb.AddParameter("@CMenu_iType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_iType", sys_CSMenu.CMenu_iType);
         }
          }
         if(sys_CSMenu.CMenu_Image_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Image))
         {
            idb.AddParameter("@CMenu_Image", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Image", sys_CSMenu.CMenu_Image);
         }
          }
         if(sys_CSMenu.CMenu_Level_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Level))
         {
            idb.AddParameter("@CMenu_Level", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Level", sys_CSMenu.CMenu_Level);
         }
          }
         if(sys_CSMenu.Stat_IsChanged)
         {
         if (sys_CSMenu.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_CSMenu.Stat);
         }
          }
         if(sys_CSMenu.CMenu_Udef1_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Udef1))
         {
            idb.AddParameter("@CMenu_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Udef1", sys_CSMenu.CMenu_Udef1);
         }
          }
         if(sys_CSMenu.CMenu_Udef2_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Udef2))
         {
            idb.AddParameter("@CMenu_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Udef2", sys_CSMenu.CMenu_Udef2);
         }
          }
         if(sys_CSMenu.CMenu_Udef3_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_CSMenu.CMenu_Udef3))
         {
            idb.AddParameter("@CMenu_Udef3", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@CMenu_Udef3", sys_CSMenu.CMenu_Udef3);
         }
          }
         if(sys_CSMenu.CMenu_Order_IsChanged)
         {
         if (sys_CSMenu.CMenu_Order == 0)
         {
            idb.AddParameter("@CMenu_Order", 0);
         }
         else
         {
            idb.AddParameter("@CMenu_Order", sys_CSMenu.CMenu_Order);
         }
          }

         idb.AddParameter("@CMenu_ID", sys_CSMenu.CMenu_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除Sys_CSMenu对象(即:一条记录
      /// </summary>
      public int Delete(decimal cMenu_ID)
      {
         string sql = "DELETE Sys_CSMenu WHERE 1=1  AND CMenu_ID=@CMenu_ID ";
         idb.AddParameter("@CMenu_ID", cMenu_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Sys_CSMenu对象(即:一条记录
      /// </summary>
      public Sys_CSMenu GetByKey(decimal cMenu_ID)
      {
         Sys_CSMenu sys_CSMenu = new Sys_CSMenu();
         string sql = "SELECT  CMenu_ID,CMenu_Name,CMenu_Code,CMenu_PCode,CMenu_Path,CMenu_IsModule,CMenu_ExtParameter,CMenu_iType,CMenu_Image,CMenu_Level,Stat,CMenu_Udef1,CMenu_Udef2,CMenu_Udef3,CMenu_Order FROM Sys_CSMenu WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND CMenu_ID=@CMenu_ID ";
         idb.AddParameter("@CMenu_ID", cMenu_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["CMenu_ID"] != DBNull.Value) sys_CSMenu.CMenu_ID = Convert.ToDecimal(dr["CMenu_ID"]);
            if (dr["CMenu_Name"] != DBNull.Value) sys_CSMenu.CMenu_Name = Convert.ToString(dr["CMenu_Name"]);
            if (dr["CMenu_Code"] != DBNull.Value) sys_CSMenu.CMenu_Code = Convert.ToString(dr["CMenu_Code"]);
            if (dr["CMenu_PCode"] != DBNull.Value) sys_CSMenu.CMenu_PCode = Convert.ToString(dr["CMenu_PCode"]);
            if (dr["CMenu_Path"] != DBNull.Value) sys_CSMenu.CMenu_Path = Convert.ToString(dr["CMenu_Path"]);
            if (dr["CMenu_IsModule"] != DBNull.Value) sys_CSMenu.CMenu_IsModule = Convert.ToString(dr["CMenu_IsModule"]);
            if (dr["CMenu_ExtParameter"] != DBNull.Value) sys_CSMenu.CMenu_ExtParameter = Convert.ToString(dr["CMenu_ExtParameter"]);
            if (dr["CMenu_iType"] != DBNull.Value) sys_CSMenu.CMenu_iType = Convert.ToString(dr["CMenu_iType"]);
            if (dr["CMenu_Image"] != DBNull.Value) sys_CSMenu.CMenu_Image = Convert.ToString(dr["CMenu_Image"]);
            if (dr["CMenu_Level"] != DBNull.Value) sys_CSMenu.CMenu_Level = Convert.ToString(dr["CMenu_Level"]);
            if (dr["Stat"] != DBNull.Value) sys_CSMenu.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["CMenu_Udef1"] != DBNull.Value) sys_CSMenu.CMenu_Udef1 = Convert.ToString(dr["CMenu_Udef1"]);
            if (dr["CMenu_Udef2"] != DBNull.Value) sys_CSMenu.CMenu_Udef2 = Convert.ToString(dr["CMenu_Udef2"]);
            if (dr["CMenu_Udef3"] != DBNull.Value) sys_CSMenu.CMenu_Udef3 = Convert.ToString(dr["CMenu_Udef3"]);
            if (dr["CMenu_Order"] != DBNull.Value) sys_CSMenu.CMenu_Order = Convert.ToInt32(dr["CMenu_Order"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return sys_CSMenu;
      }
      /// <summary>
      /// 获取指定的Sys_CSMenu对象集合
      /// </summary>
      public List<Sys_CSMenu> GetListByWhere(string strCondition)
      {
         List<Sys_CSMenu> ret = new List<Sys_CSMenu>();
         string sql = "SELECT  CMenu_ID,CMenu_Name,CMenu_Code,CMenu_PCode,CMenu_Path,CMenu_IsModule,CMenu_ExtParameter,CMenu_iType,CMenu_Image,CMenu_Level,Stat,CMenu_Udef1,CMenu_Udef2,CMenu_Udef3,CMenu_Order FROM Sys_CSMenu WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
         if(!string.IsNullOrEmpty(strCondition))
         {
            strCondition.Replace('\'','"'); //防sql注入
            sql += strCondition ;
         }
          sql += " ORDER BY CMenu_ID DESC "; 
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_CSMenu sys_CSMenu = new Sys_CSMenu();
            if (dr["CMenu_ID"] != DBNull.Value) sys_CSMenu.CMenu_ID = Convert.ToDecimal(dr["CMenu_ID"]);
            if (dr["CMenu_Name"] != DBNull.Value) sys_CSMenu.CMenu_Name = Convert.ToString(dr["CMenu_Name"]);
            if (dr["CMenu_Code"] != DBNull.Value) sys_CSMenu.CMenu_Code = Convert.ToString(dr["CMenu_Code"]);
            if (dr["CMenu_PCode"] != DBNull.Value) sys_CSMenu.CMenu_PCode = Convert.ToString(dr["CMenu_PCode"]);
            if (dr["CMenu_Path"] != DBNull.Value) sys_CSMenu.CMenu_Path = Convert.ToString(dr["CMenu_Path"]);
            if (dr["CMenu_IsModule"] != DBNull.Value) sys_CSMenu.CMenu_IsModule = Convert.ToString(dr["CMenu_IsModule"]);
            if (dr["CMenu_ExtParameter"] != DBNull.Value) sys_CSMenu.CMenu_ExtParameter = Convert.ToString(dr["CMenu_ExtParameter"]);
            if (dr["CMenu_iType"] != DBNull.Value) sys_CSMenu.CMenu_iType = Convert.ToString(dr["CMenu_iType"]);
            if (dr["CMenu_Image"] != DBNull.Value) sys_CSMenu.CMenu_Image = Convert.ToString(dr["CMenu_Image"]);
            if (dr["CMenu_Level"] != DBNull.Value) sys_CSMenu.CMenu_Level = Convert.ToString(dr["CMenu_Level"]);
            if (dr["Stat"] != DBNull.Value) sys_CSMenu.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["CMenu_Udef1"] != DBNull.Value) sys_CSMenu.CMenu_Udef1 = Convert.ToString(dr["CMenu_Udef1"]);
            if (dr["CMenu_Udef2"] != DBNull.Value) sys_CSMenu.CMenu_Udef2 = Convert.ToString(dr["CMenu_Udef2"]);
            if (dr["CMenu_Udef3"] != DBNull.Value) sys_CSMenu.CMenu_Udef3 = Convert.ToString(dr["CMenu_Udef3"]);
            if (dr["CMenu_Order"] != DBNull.Value) sys_CSMenu.CMenu_Order = Convert.ToInt32(dr["CMenu_Order"]);
            ret.Add(sys_CSMenu);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Sys_CSMenu对象(即:一条记录
      /// </summary>
      public List<Sys_CSMenu> GetAll()
      {
         List<Sys_CSMenu> ret = new List<Sys_CSMenu>();
         string sql = "SELECT  CMenu_ID,CMenu_Name,CMenu_Code,CMenu_PCode,CMenu_Path,CMenu_IsModule,CMenu_ExtParameter,CMenu_iType,CMenu_Image,CMenu_Level,Stat,CMenu_Udef1,CMenu_Udef2,CMenu_Udef3,CMenu_Order FROM Sys_CSMenu where 1=1 AND ((Stat is null) or (Stat=0) ) order by CMenu_ID desc ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_CSMenu sys_CSMenu = new Sys_CSMenu();
            if (dr["CMenu_ID"] != DBNull.Value) sys_CSMenu.CMenu_ID = Convert.ToDecimal(dr["CMenu_ID"]);
            if (dr["CMenu_Name"] != DBNull.Value) sys_CSMenu.CMenu_Name = Convert.ToString(dr["CMenu_Name"]);
            if (dr["CMenu_Code"] != DBNull.Value) sys_CSMenu.CMenu_Code = Convert.ToString(dr["CMenu_Code"]);
            if (dr["CMenu_PCode"] != DBNull.Value) sys_CSMenu.CMenu_PCode = Convert.ToString(dr["CMenu_PCode"]);
            if (dr["CMenu_Path"] != DBNull.Value) sys_CSMenu.CMenu_Path = Convert.ToString(dr["CMenu_Path"]);
            if (dr["CMenu_IsModule"] != DBNull.Value) sys_CSMenu.CMenu_IsModule = Convert.ToString(dr["CMenu_IsModule"]);
            if (dr["CMenu_ExtParameter"] != DBNull.Value) sys_CSMenu.CMenu_ExtParameter = Convert.ToString(dr["CMenu_ExtParameter"]);
            if (dr["CMenu_iType"] != DBNull.Value) sys_CSMenu.CMenu_iType = Convert.ToString(dr["CMenu_iType"]);
            if (dr["CMenu_Image"] != DBNull.Value) sys_CSMenu.CMenu_Image = Convert.ToString(dr["CMenu_Image"]);
            if (dr["CMenu_Level"] != DBNull.Value) sys_CSMenu.CMenu_Level = Convert.ToString(dr["CMenu_Level"]);
            if (dr["Stat"] != DBNull.Value) sys_CSMenu.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["CMenu_Udef1"] != DBNull.Value) sys_CSMenu.CMenu_Udef1 = Convert.ToString(dr["CMenu_Udef1"]);
            if (dr["CMenu_Udef2"] != DBNull.Value) sys_CSMenu.CMenu_Udef2 = Convert.ToString(dr["CMenu_Udef2"]);
            if (dr["CMenu_Udef3"] != DBNull.Value) sys_CSMenu.CMenu_Udef3 = Convert.ToString(dr["CMenu_Udef3"]);
            if (dr["CMenu_Order"] != DBNull.Value) sys_CSMenu.CMenu_Order = Convert.ToInt32(dr["CMenu_Order"]);
            ret.Add(sys_CSMenu);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
