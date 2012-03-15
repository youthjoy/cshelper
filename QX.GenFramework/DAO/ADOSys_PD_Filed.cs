using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using QX.DataAcess;
using QX.GenFramework.Model;

namespace QX.GenFramework.ADO
{
   [Serializable]
   public partial class ADOSys_PD_Filed
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Sys_PD_Filed对象(即:一条记录)
      /// </summary>
      public int Add(Sys_PD_Filed sys_PD_Filed)
      {
         string sql = "INSERT INTO Sys_PD_Filed (DCP_ModuleName,DCP_ControlID,DCP_Label,DCP_ControlType,DCP_Type,DCP_Style,DCP_Order,DCP_IsHidden,DCP_IsReadonly,DCP_Udef1,DCP_Udef2,DCP_PageName,DCP_CreateTime,DCP_Model,DCP_RefSQL,DCP_RefBack,DCP_RefValue,DCP_RefCode,DCP_TX,DCP_TY,DCP_TI,DCP_Height,DCP_PControl,DCP_CControl,Stat,DCP_IsSummary,DCP_IsFilter) VALUES (@DCP_ModuleName,@DCP_ControlID,@DCP_Label,@DCP_ControlType,@DCP_Type,@DCP_Style,@DCP_Order,@DCP_IsHidden,@DCP_IsReadonly,@DCP_Udef1,@DCP_Udef2,@DCP_PageName,@DCP_CreateTime,@DCP_Model,@DCP_RefSQL,@DCP_RefBack,@DCP_RefValue,@DCP_RefCode,@DCP_TX,@DCP_TY,@DCP_TI,@DCP_Height,@DCP_PControl,@DCP_CControl,@Stat,@DCP_IsSummary,@DCP_IsFilter)";
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_ModuleName))
         {
            idb.AddParameter("@DCP_ModuleName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_ModuleName", sys_PD_Filed.DCP_ModuleName);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_ControlID))
         {
            idb.AddParameter("@DCP_ControlID", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_ControlID", sys_PD_Filed.DCP_ControlID);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Label))
         {
            idb.AddParameter("@DCP_Label", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Label", sys_PD_Filed.DCP_Label);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_ControlType))
         {
            idb.AddParameter("@DCP_ControlType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_ControlType", sys_PD_Filed.DCP_ControlType);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Type))
         {
            idb.AddParameter("@DCP_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Type", sys_PD_Filed.DCP_Type);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Style))
         {
            idb.AddParameter("@DCP_Style", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Style", sys_PD_Filed.DCP_Style);
         }
         if (sys_PD_Filed.DCP_Order == 0)
         {
            idb.AddParameter("@DCP_Order", 0);
         }
         else
         {
            idb.AddParameter("@DCP_Order", sys_PD_Filed.DCP_Order);
         }
         if (sys_PD_Filed.DCP_IsHidden == 0)
         {
            idb.AddParameter("@DCP_IsHidden", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsHidden", sys_PD_Filed.DCP_IsHidden);
         }
         if (sys_PD_Filed.DCP_IsReadonly == 0)
         {
            idb.AddParameter("@DCP_IsReadonly", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsReadonly", sys_PD_Filed.DCP_IsReadonly);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Udef1))
         {
            idb.AddParameter("@DCP_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Udef1", sys_PD_Filed.DCP_Udef1);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Udef2))
         {
            idb.AddParameter("@DCP_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Udef2", sys_PD_Filed.DCP_Udef2);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_PageName))
         {
            idb.AddParameter("@DCP_PageName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_PageName", sys_PD_Filed.DCP_PageName);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_CreateTime))
         {
            idb.AddParameter("@DCP_CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_CreateTime", sys_PD_Filed.DCP_CreateTime);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Model))
         {
            idb.AddParameter("@DCP_Model", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Model", sys_PD_Filed.DCP_Model);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefSQL))
         {
            idb.AddParameter("@DCP_RefSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefSQL", sys_PD_Filed.DCP_RefSQL);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefBack))
         {
            idb.AddParameter("@DCP_RefBack", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefBack", sys_PD_Filed.DCP_RefBack);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefValue))
         {
            idb.AddParameter("@DCP_RefValue", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefValue", sys_PD_Filed.DCP_RefValue);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefCode))
         {
            idb.AddParameter("@DCP_RefCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefCode", sys_PD_Filed.DCP_RefCode);
         }
         if (sys_PD_Filed.DCP_TX == 0)
         {
            idb.AddParameter("@DCP_TX", 0);
         }
         else
         {
            idb.AddParameter("@DCP_TX", sys_PD_Filed.DCP_TX);
         }
         if (sys_PD_Filed.DCP_TY == 0)
         {
            idb.AddParameter("@DCP_TY", 0);
         }
         else
         {
            idb.AddParameter("@DCP_TY", sys_PD_Filed.DCP_TY);
         }
         if (sys_PD_Filed.DCP_TI == 0)
         {
            idb.AddParameter("@DCP_TI", 0);
         }
         else
         {
            idb.AddParameter("@DCP_TI", sys_PD_Filed.DCP_TI);
         }
         if (sys_PD_Filed.DCP_Height == 0)
         {
            idb.AddParameter("@DCP_Height", 0);
         }
         else
         {
            idb.AddParameter("@DCP_Height", sys_PD_Filed.DCP_Height);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_PControl))
         {
            idb.AddParameter("@DCP_PControl", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_PControl", sys_PD_Filed.DCP_PControl);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_CControl))
         {
            idb.AddParameter("@DCP_CControl", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_CControl", sys_PD_Filed.DCP_CControl);
         }
         if (sys_PD_Filed.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_Filed.Stat);
         }
         if (sys_PD_Filed.DCP_IsSummary == 0)
         {
            idb.AddParameter("@DCP_IsSummary", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsSummary", sys_PD_Filed.DCP_IsSummary);
         }
         if (sys_PD_Filed.DCP_IsFilter == 0)
         {
            idb.AddParameter("@DCP_IsFilter", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsFilter", sys_PD_Filed.DCP_IsFilter);
         }

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 添加Sys_PD_Filed对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Sys_PD_Filed sys_PD_Filed)
      {
         string sql = "INSERT INTO Sys_PD_Filed (DCP_ModuleName,DCP_ControlID,DCP_Label,DCP_ControlType,DCP_Type,DCP_Style,DCP_Order,DCP_IsHidden,DCP_IsReadonly,DCP_Udef1,DCP_Udef2,DCP_PageName,DCP_CreateTime,DCP_Model,DCP_RefSQL,DCP_RefBack,DCP_RefValue,DCP_RefCode,DCP_TX,DCP_TY,DCP_TI,DCP_Height,DCP_PControl,DCP_CControl,Stat,DCP_IsSummary,DCP_IsFilter) VALUES (@DCP_ModuleName,@DCP_ControlID,@DCP_Label,@DCP_ControlType,@DCP_Type,@DCP_Style,@DCP_Order,@DCP_IsHidden,@DCP_IsReadonly,@DCP_Udef1,@DCP_Udef2,@DCP_PageName,@DCP_CreateTime,@DCP_Model,@DCP_RefSQL,@DCP_RefBack,@DCP_RefValue,@DCP_RefCode,@DCP_TX,@DCP_TY,@DCP_TI,@DCP_Height,@DCP_PControl,@DCP_CControl,@Stat,@DCP_IsSummary,@DCP_IsFilter);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_ModuleName))
         {
            idb.AddParameter("@DCP_ModuleName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_ModuleName", sys_PD_Filed.DCP_ModuleName);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_ControlID))
         {
            idb.AddParameter("@DCP_ControlID", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_ControlID", sys_PD_Filed.DCP_ControlID);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Label))
         {
            idb.AddParameter("@DCP_Label", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Label", sys_PD_Filed.DCP_Label);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_ControlType))
         {
            idb.AddParameter("@DCP_ControlType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_ControlType", sys_PD_Filed.DCP_ControlType);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Type))
         {
            idb.AddParameter("@DCP_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Type", sys_PD_Filed.DCP_Type);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Style))
         {
            idb.AddParameter("@DCP_Style", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Style", sys_PD_Filed.DCP_Style);
         }
         if (sys_PD_Filed.DCP_Order == 0)
         {
            idb.AddParameter("@DCP_Order", 0);
         }
         else
         {
            idb.AddParameter("@DCP_Order", sys_PD_Filed.DCP_Order);
         }
         if (sys_PD_Filed.DCP_IsHidden == 0)
         {
            idb.AddParameter("@DCP_IsHidden", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsHidden", sys_PD_Filed.DCP_IsHidden);
         }
         if (sys_PD_Filed.DCP_IsReadonly == 0)
         {
            idb.AddParameter("@DCP_IsReadonly", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsReadonly", sys_PD_Filed.DCP_IsReadonly);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Udef1))
         {
            idb.AddParameter("@DCP_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Udef1", sys_PD_Filed.DCP_Udef1);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Udef2))
         {
            idb.AddParameter("@DCP_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Udef2", sys_PD_Filed.DCP_Udef2);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_PageName))
         {
            idb.AddParameter("@DCP_PageName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_PageName", sys_PD_Filed.DCP_PageName);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_CreateTime))
         {
            idb.AddParameter("@DCP_CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_CreateTime", sys_PD_Filed.DCP_CreateTime);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Model))
         {
            idb.AddParameter("@DCP_Model", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Model", sys_PD_Filed.DCP_Model);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefSQL))
         {
            idb.AddParameter("@DCP_RefSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefSQL", sys_PD_Filed.DCP_RefSQL);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefBack))
         {
            idb.AddParameter("@DCP_RefBack", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefBack", sys_PD_Filed.DCP_RefBack);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefValue))
         {
            idb.AddParameter("@DCP_RefValue", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefValue", sys_PD_Filed.DCP_RefValue);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefCode))
         {
            idb.AddParameter("@DCP_RefCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefCode", sys_PD_Filed.DCP_RefCode);
         }
         if (sys_PD_Filed.DCP_TX == 0)
         {
            idb.AddParameter("@DCP_TX", 0);
         }
         else
         {
            idb.AddParameter("@DCP_TX", sys_PD_Filed.DCP_TX);
         }
         if (sys_PD_Filed.DCP_TY == 0)
         {
            idb.AddParameter("@DCP_TY", 0);
         }
         else
         {
            idb.AddParameter("@DCP_TY", sys_PD_Filed.DCP_TY);
         }
         if (sys_PD_Filed.DCP_TI == 0)
         {
            idb.AddParameter("@DCP_TI", 0);
         }
         else
         {
            idb.AddParameter("@DCP_TI", sys_PD_Filed.DCP_TI);
         }
         if (sys_PD_Filed.DCP_Height == 0)
         {
            idb.AddParameter("@DCP_Height", 0);
         }
         else
         {
            idb.AddParameter("@DCP_Height", sys_PD_Filed.DCP_Height);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_PControl))
         {
            idb.AddParameter("@DCP_PControl", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_PControl", sys_PD_Filed.DCP_PControl);
         }
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_CControl))
         {
            idb.AddParameter("@DCP_CControl", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_CControl", sys_PD_Filed.DCP_CControl);
         }
         if (sys_PD_Filed.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_Filed.Stat);
         }
         if (sys_PD_Filed.DCP_IsSummary == 0)
         {
            idb.AddParameter("@DCP_IsSummary", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsSummary", sys_PD_Filed.DCP_IsSummary);
         }
         if (sys_PD_Filed.DCP_IsFilter == 0)
         {
            idb.AddParameter("@DCP_IsFilter", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsFilter", sys_PD_Filed.DCP_IsFilter);
         }

         return idb.ReturnValue(sql);
      }
      /// <summary>
      /// 更新Sys_PD_Filed对象(即:一条记录
      /// </summary>
      public int Update(Sys_PD_Filed sys_PD_Filed)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Sys_PD_Filed       SET ");
            if(sys_PD_Filed.DCP_ModuleName_IsChanged){sbParameter.Append("DCP_ModuleName=@DCP_ModuleName, ");}
      if(sys_PD_Filed.DCP_ControlID_IsChanged){sbParameter.Append("DCP_ControlID=@DCP_ControlID, ");}
      if(sys_PD_Filed.DCP_Label_IsChanged){sbParameter.Append("DCP_Label=@DCP_Label, ");}
      if(sys_PD_Filed.DCP_ControlType_IsChanged){sbParameter.Append("DCP_ControlType=@DCP_ControlType, ");}
      if(sys_PD_Filed.DCP_Type_IsChanged){sbParameter.Append("DCP_Type=@DCP_Type, ");}
      if(sys_PD_Filed.DCP_Style_IsChanged){sbParameter.Append("DCP_Style=@DCP_Style, ");}
      if(sys_PD_Filed.DCP_Order_IsChanged){sbParameter.Append("DCP_Order=@DCP_Order, ");}
      if(sys_PD_Filed.DCP_IsHidden_IsChanged){sbParameter.Append("DCP_IsHidden=@DCP_IsHidden, ");}
      if(sys_PD_Filed.DCP_IsReadonly_IsChanged){sbParameter.Append("DCP_IsReadonly=@DCP_IsReadonly, ");}
      if(sys_PD_Filed.DCP_Udef1_IsChanged){sbParameter.Append("DCP_Udef1=@DCP_Udef1, ");}
      if(sys_PD_Filed.DCP_Udef2_IsChanged){sbParameter.Append("DCP_Udef2=@DCP_Udef2, ");}
      if(sys_PD_Filed.DCP_PageName_IsChanged){sbParameter.Append("DCP_PageName=@DCP_PageName, ");}
      if(sys_PD_Filed.DCP_CreateTime_IsChanged){sbParameter.Append("DCP_CreateTime=@DCP_CreateTime, ");}
      if(sys_PD_Filed.DCP_Model_IsChanged){sbParameter.Append("DCP_Model=@DCP_Model, ");}
      if(sys_PD_Filed.DCP_RefSQL_IsChanged){sbParameter.Append("DCP_RefSQL=@DCP_RefSQL, ");}
      if(sys_PD_Filed.DCP_RefBack_IsChanged){sbParameter.Append("DCP_RefBack=@DCP_RefBack, ");}
      if(sys_PD_Filed.DCP_RefValue_IsChanged){sbParameter.Append("DCP_RefValue=@DCP_RefValue, ");}
      if(sys_PD_Filed.DCP_RefCode_IsChanged){sbParameter.Append("DCP_RefCode=@DCP_RefCode, ");}
      if(sys_PD_Filed.DCP_TX_IsChanged){sbParameter.Append("DCP_TX=@DCP_TX, ");}
      if(sys_PD_Filed.DCP_TY_IsChanged){sbParameter.Append("DCP_TY=@DCP_TY, ");}
      if(sys_PD_Filed.DCP_TI_IsChanged){sbParameter.Append("DCP_TI=@DCP_TI, ");}
      if(sys_PD_Filed.DCP_Height_IsChanged){sbParameter.Append("DCP_Height=@DCP_Height, ");}
      if(sys_PD_Filed.DCP_PControl_IsChanged){sbParameter.Append("DCP_PControl=@DCP_PControl, ");}
      if(sys_PD_Filed.DCP_CControl_IsChanged){sbParameter.Append("DCP_CControl=@DCP_CControl, ");}
      if(sys_PD_Filed.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(sys_PD_Filed.DCP_IsSummary_IsChanged){sbParameter.Append("DCP_IsSummary=@DCP_IsSummary, ");}
      if(sys_PD_Filed.DCP_IsFilter_IsChanged){sbParameter.Append("DCP_IsFilter=@DCP_IsFilter ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and DCP_ID=@DCP_ID; " );
      string sql=sb.ToString();
         if(sys_PD_Filed.DCP_ModuleName_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_ModuleName))
         {
            idb.AddParameter("@DCP_ModuleName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_ModuleName", sys_PD_Filed.DCP_ModuleName);
         }
          }
         if(sys_PD_Filed.DCP_ControlID_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_ControlID))
         {
            idb.AddParameter("@DCP_ControlID", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_ControlID", sys_PD_Filed.DCP_ControlID);
         }
          }
         if(sys_PD_Filed.DCP_Label_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Label))
         {
            idb.AddParameter("@DCP_Label", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Label", sys_PD_Filed.DCP_Label);
         }
          }
         if(sys_PD_Filed.DCP_ControlType_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_ControlType))
         {
            idb.AddParameter("@DCP_ControlType", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_ControlType", sys_PD_Filed.DCP_ControlType);
         }
          }
         if(sys_PD_Filed.DCP_Type_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Type))
         {
            idb.AddParameter("@DCP_Type", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Type", sys_PD_Filed.DCP_Type);
         }
          }
         if(sys_PD_Filed.DCP_Style_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Style))
         {
            idb.AddParameter("@DCP_Style", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Style", sys_PD_Filed.DCP_Style);
         }
          }
         if(sys_PD_Filed.DCP_Order_IsChanged)
         {
         if (sys_PD_Filed.DCP_Order == 0)
         {
            idb.AddParameter("@DCP_Order", 0);
         }
         else
         {
            idb.AddParameter("@DCP_Order", sys_PD_Filed.DCP_Order);
         }
          }
         if(sys_PD_Filed.DCP_IsHidden_IsChanged)
         {
         if (sys_PD_Filed.DCP_IsHidden == 0)
         {
            idb.AddParameter("@DCP_IsHidden", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsHidden", sys_PD_Filed.DCP_IsHidden);
         }
          }
         if(sys_PD_Filed.DCP_IsReadonly_IsChanged)
         {
         if (sys_PD_Filed.DCP_IsReadonly == 0)
         {
            idb.AddParameter("@DCP_IsReadonly", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsReadonly", sys_PD_Filed.DCP_IsReadonly);
         }
          }
         if(sys_PD_Filed.DCP_Udef1_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Udef1))
         {
            idb.AddParameter("@DCP_Udef1", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Udef1", sys_PD_Filed.DCP_Udef1);
         }
          }
         if(sys_PD_Filed.DCP_Udef2_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Udef2))
         {
            idb.AddParameter("@DCP_Udef2", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Udef2", sys_PD_Filed.DCP_Udef2);
         }
          }
         if(sys_PD_Filed.DCP_PageName_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_PageName))
         {
            idb.AddParameter("@DCP_PageName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_PageName", sys_PD_Filed.DCP_PageName);
         }
          }
         if(sys_PD_Filed.DCP_CreateTime_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_CreateTime))
         {
            idb.AddParameter("@DCP_CreateTime", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_CreateTime", sys_PD_Filed.DCP_CreateTime);
         }
          }
         if(sys_PD_Filed.DCP_Model_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_Model))
         {
            idb.AddParameter("@DCP_Model", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_Model", sys_PD_Filed.DCP_Model);
         }
          }
         if(sys_PD_Filed.DCP_RefSQL_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefSQL))
         {
            idb.AddParameter("@DCP_RefSQL", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefSQL", sys_PD_Filed.DCP_RefSQL);
         }
          }
         if(sys_PD_Filed.DCP_RefBack_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefBack))
         {
            idb.AddParameter("@DCP_RefBack", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefBack", sys_PD_Filed.DCP_RefBack);
         }
          }
         if(sys_PD_Filed.DCP_RefValue_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefValue))
         {
            idb.AddParameter("@DCP_RefValue", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefValue", sys_PD_Filed.DCP_RefValue);
         }
          }
         if(sys_PD_Filed.DCP_RefCode_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_RefCode))
         {
            idb.AddParameter("@DCP_RefCode", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_RefCode", sys_PD_Filed.DCP_RefCode);
         }
          }
         if(sys_PD_Filed.DCP_TX_IsChanged)
         {
         if (sys_PD_Filed.DCP_TX == 0)
         {
            idb.AddParameter("@DCP_TX", 0);
         }
         else
         {
            idb.AddParameter("@DCP_TX", sys_PD_Filed.DCP_TX);
         }
          }
         if(sys_PD_Filed.DCP_TY_IsChanged)
         {
         if (sys_PD_Filed.DCP_TY == 0)
         {
            idb.AddParameter("@DCP_TY", 0);
         }
         else
         {
            idb.AddParameter("@DCP_TY", sys_PD_Filed.DCP_TY);
         }
          }
         if(sys_PD_Filed.DCP_TI_IsChanged)
         {
         if (sys_PD_Filed.DCP_TI == 0)
         {
            idb.AddParameter("@DCP_TI", 0);
         }
         else
         {
            idb.AddParameter("@DCP_TI", sys_PD_Filed.DCP_TI);
         }
          }
         if(sys_PD_Filed.DCP_Height_IsChanged)
         {
         if (sys_PD_Filed.DCP_Height == 0)
         {
            idb.AddParameter("@DCP_Height", 0);
         }
         else
         {
            idb.AddParameter("@DCP_Height", sys_PD_Filed.DCP_Height);
         }
          }
         if(sys_PD_Filed.DCP_PControl_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_PControl))
         {
            idb.AddParameter("@DCP_PControl", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_PControl", sys_PD_Filed.DCP_PControl);
         }
          }
         if(sys_PD_Filed.DCP_CControl_IsChanged)
         {
         if (string.IsNullOrEmpty(sys_PD_Filed.DCP_CControl))
         {
            idb.AddParameter("@DCP_CControl", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@DCP_CControl", sys_PD_Filed.DCP_CControl);
         }
          }
         if(sys_PD_Filed.Stat_IsChanged)
         {
         if (sys_PD_Filed.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", sys_PD_Filed.Stat);
         }
          }
         if(sys_PD_Filed.DCP_IsSummary_IsChanged)
         {
         if (sys_PD_Filed.DCP_IsSummary == 0)
         {
            idb.AddParameter("@DCP_IsSummary", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsSummary", sys_PD_Filed.DCP_IsSummary);
         }
          }
         if(sys_PD_Filed.DCP_IsFilter_IsChanged)
         {
         if (sys_PD_Filed.DCP_IsFilter == 0)
         {
            idb.AddParameter("@DCP_IsFilter", 0);
         }
         else
         {
            idb.AddParameter("@DCP_IsFilter", sys_PD_Filed.DCP_IsFilter);
         }
          }

         idb.AddParameter("@DCP_ID", sys_PD_Filed.DCP_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 删除Sys_PD_Filed对象(即:一条记录
      /// </summary>
      public int Delete(decimal dCP_ID)
      {
         string sql = "DELETE Sys_PD_Filed WHERE 1=1  AND DCP_ID=@DCP_ID ";
         idb.AddParameter("@DCP_ID", dCP_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Sys_PD_Filed对象(即:一条记录
      /// </summary>
      public Sys_PD_Filed GetByKey(decimal dCP_ID)
      {
         Sys_PD_Filed sys_PD_Filed = new Sys_PD_Filed();
         string sql = "SELECT  DCP_ID,DCP_ModuleName,DCP_ControlID,DCP_Label,DCP_ControlType,DCP_Type,DCP_Style,DCP_Order,DCP_IsHidden,DCP_IsReadonly,DCP_Udef1,DCP_Udef2,DCP_PageName,DCP_CreateTime,DCP_Model,DCP_RefSQL,DCP_RefBack,DCP_RefValue,DCP_RefCode,DCP_TX,DCP_TY,DCP_TI,DCP_Height,DCP_PControl,DCP_CControl,Stat,DCP_IsSummary,DCP_IsFilter FROM Sys_PD_Filed WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND DCP_ID=@DCP_ID ";
         idb.AddParameter("@DCP_ID", dCP_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["DCP_ID"] != DBNull.Value) sys_PD_Filed.DCP_ID = Convert.ToDecimal(dr["DCP_ID"]);
            if (dr["DCP_ModuleName"] != DBNull.Value) sys_PD_Filed.DCP_ModuleName = Convert.ToString(dr["DCP_ModuleName"]);
            if (dr["DCP_ControlID"] != DBNull.Value) sys_PD_Filed.DCP_ControlID = Convert.ToString(dr["DCP_ControlID"]);
            if (dr["DCP_Label"] != DBNull.Value) sys_PD_Filed.DCP_Label = Convert.ToString(dr["DCP_Label"]);
            if (dr["DCP_ControlType"] != DBNull.Value) sys_PD_Filed.DCP_ControlType = Convert.ToString(dr["DCP_ControlType"]);
            if (dr["DCP_Type"] != DBNull.Value) sys_PD_Filed.DCP_Type = Convert.ToString(dr["DCP_Type"]);
            if (dr["DCP_Style"] != DBNull.Value) sys_PD_Filed.DCP_Style = Convert.ToString(dr["DCP_Style"]);
            if (dr["DCP_Order"] != DBNull.Value) sys_PD_Filed.DCP_Order = Convert.ToInt32(dr["DCP_Order"]);
            if (dr["DCP_IsHidden"] != DBNull.Value) sys_PD_Filed.DCP_IsHidden = Convert.ToInt32(dr["DCP_IsHidden"]);
            if (dr["DCP_IsReadonly"] != DBNull.Value) sys_PD_Filed.DCP_IsReadonly = Convert.ToInt32(dr["DCP_IsReadonly"]);
            if (dr["DCP_Udef1"] != DBNull.Value) sys_PD_Filed.DCP_Udef1 = Convert.ToString(dr["DCP_Udef1"]);
            if (dr["DCP_Udef2"] != DBNull.Value) sys_PD_Filed.DCP_Udef2 = Convert.ToString(dr["DCP_Udef2"]);
            if (dr["DCP_PageName"] != DBNull.Value) sys_PD_Filed.DCP_PageName = Convert.ToString(dr["DCP_PageName"]);
            if (dr["DCP_CreateTime"] != DBNull.Value) sys_PD_Filed.DCP_CreateTime = Convert.ToString(dr["DCP_CreateTime"]);
            if (dr["DCP_Model"] != DBNull.Value) sys_PD_Filed.DCP_Model = Convert.ToString(dr["DCP_Model"]);
            if (dr["DCP_RefSQL"] != DBNull.Value) sys_PD_Filed.DCP_RefSQL = Convert.ToString(dr["DCP_RefSQL"]);
            if (dr["DCP_RefBack"] != DBNull.Value) sys_PD_Filed.DCP_RefBack = Convert.ToString(dr["DCP_RefBack"]);
            if (dr["DCP_RefValue"] != DBNull.Value) sys_PD_Filed.DCP_RefValue = Convert.ToString(dr["DCP_RefValue"]);
            if (dr["DCP_RefCode"] != DBNull.Value) sys_PD_Filed.DCP_RefCode = Convert.ToString(dr["DCP_RefCode"]);
            if (dr["DCP_TX"] != DBNull.Value) sys_PD_Filed.DCP_TX = Convert.ToInt32(dr["DCP_TX"]);
            if (dr["DCP_TY"] != DBNull.Value) sys_PD_Filed.DCP_TY = Convert.ToInt32(dr["DCP_TY"]);
            if (dr["DCP_TI"] != DBNull.Value) sys_PD_Filed.DCP_TI = Convert.ToInt32(dr["DCP_TI"]);
            if (dr["DCP_Height"] != DBNull.Value) sys_PD_Filed.DCP_Height = Convert.ToInt32(dr["DCP_Height"]);
            if (dr["DCP_PControl"] != DBNull.Value) sys_PD_Filed.DCP_PControl = Convert.ToString(dr["DCP_PControl"]);
            if (dr["DCP_CControl"] != DBNull.Value) sys_PD_Filed.DCP_CControl = Convert.ToString(dr["DCP_CControl"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_Filed.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["DCP_IsSummary"] != DBNull.Value) sys_PD_Filed.DCP_IsSummary = Convert.ToInt32(dr["DCP_IsSummary"]);
            if (dr["DCP_IsFilter"] != DBNull.Value) sys_PD_Filed.DCP_IsFilter = Convert.ToInt32(dr["DCP_IsFilter"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return sys_PD_Filed;
      }
      /// <summary>
      /// 获取指定的Sys_PD_Filed对象集合
      /// </summary>
      public List<Sys_PD_Filed> GetListByWhere(string strCondition)
      {
         List<Sys_PD_Filed> ret = new List<Sys_PD_Filed>();
         string sql = "SELECT  DCP_ID,DCP_ModuleName,DCP_ControlID,DCP_Label,DCP_ControlType,DCP_Type,DCP_Style,DCP_Order,DCP_IsHidden,DCP_IsReadonly,DCP_Udef1,DCP_Udef2,DCP_PageName,DCP_CreateTime,DCP_Model,DCP_RefSQL,DCP_RefBack,DCP_RefValue,DCP_RefCode,DCP_TX,DCP_TY,DCP_TI,DCP_Height,DCP_PControl,DCP_CControl,Stat,DCP_IsSummary,DCP_IsFilter FROM Sys_PD_Filed WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
         if(!string.IsNullOrEmpty(strCondition))
         {
            strCondition.Replace('\'','"'); //防sql注入
            sql += strCondition ;
         }
          //sql += " ORDER BY DCP_ID DESC "; 
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_PD_Filed sys_PD_Filed = new Sys_PD_Filed();
            if (dr["DCP_ID"] != DBNull.Value) sys_PD_Filed.DCP_ID = Convert.ToDecimal(dr["DCP_ID"]);
            if (dr["DCP_ModuleName"] != DBNull.Value) sys_PD_Filed.DCP_ModuleName = Convert.ToString(dr["DCP_ModuleName"]);
            if (dr["DCP_ControlID"] != DBNull.Value) sys_PD_Filed.DCP_ControlID = Convert.ToString(dr["DCP_ControlID"]);
            if (dr["DCP_Label"] != DBNull.Value) sys_PD_Filed.DCP_Label = Convert.ToString(dr["DCP_Label"]);
            if (dr["DCP_ControlType"] != DBNull.Value) sys_PD_Filed.DCP_ControlType = Convert.ToString(dr["DCP_ControlType"]);
            if (dr["DCP_Type"] != DBNull.Value) sys_PD_Filed.DCP_Type = Convert.ToString(dr["DCP_Type"]);
            if (dr["DCP_Style"] != DBNull.Value) sys_PD_Filed.DCP_Style = Convert.ToString(dr["DCP_Style"]);
            if (dr["DCP_Order"] != DBNull.Value) sys_PD_Filed.DCP_Order = Convert.ToInt32(dr["DCP_Order"]);
            if (dr["DCP_IsHidden"] != DBNull.Value) sys_PD_Filed.DCP_IsHidden = Convert.ToInt32(dr["DCP_IsHidden"]);
            if (dr["DCP_IsReadonly"] != DBNull.Value) sys_PD_Filed.DCP_IsReadonly = Convert.ToInt32(dr["DCP_IsReadonly"]);
            if (dr["DCP_Udef1"] != DBNull.Value) sys_PD_Filed.DCP_Udef1 = Convert.ToString(dr["DCP_Udef1"]);
            if (dr["DCP_Udef2"] != DBNull.Value) sys_PD_Filed.DCP_Udef2 = Convert.ToString(dr["DCP_Udef2"]);
            if (dr["DCP_PageName"] != DBNull.Value) sys_PD_Filed.DCP_PageName = Convert.ToString(dr["DCP_PageName"]);
            if (dr["DCP_CreateTime"] != DBNull.Value) sys_PD_Filed.DCP_CreateTime = Convert.ToString(dr["DCP_CreateTime"]);
            if (dr["DCP_Model"] != DBNull.Value) sys_PD_Filed.DCP_Model = Convert.ToString(dr["DCP_Model"]);
            if (dr["DCP_RefSQL"] != DBNull.Value) sys_PD_Filed.DCP_RefSQL = Convert.ToString(dr["DCP_RefSQL"]);
            if (dr["DCP_RefBack"] != DBNull.Value) sys_PD_Filed.DCP_RefBack = Convert.ToString(dr["DCP_RefBack"]);
            if (dr["DCP_RefValue"] != DBNull.Value) sys_PD_Filed.DCP_RefValue = Convert.ToString(dr["DCP_RefValue"]);
            if (dr["DCP_RefCode"] != DBNull.Value) sys_PD_Filed.DCP_RefCode = Convert.ToString(dr["DCP_RefCode"]);
            if (dr["DCP_TX"] != DBNull.Value) sys_PD_Filed.DCP_TX = Convert.ToInt32(dr["DCP_TX"]);
            if (dr["DCP_TY"] != DBNull.Value) sys_PD_Filed.DCP_TY = Convert.ToInt32(dr["DCP_TY"]);
            if (dr["DCP_TI"] != DBNull.Value) sys_PD_Filed.DCP_TI = Convert.ToInt32(dr["DCP_TI"]);
            if (dr["DCP_Height"] != DBNull.Value) sys_PD_Filed.DCP_Height = Convert.ToInt32(dr["DCP_Height"]);
            if (dr["DCP_PControl"] != DBNull.Value) sys_PD_Filed.DCP_PControl = Convert.ToString(dr["DCP_PControl"]);
            if (dr["DCP_CControl"] != DBNull.Value) sys_PD_Filed.DCP_CControl = Convert.ToString(dr["DCP_CControl"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_Filed.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["DCP_IsSummary"] != DBNull.Value) sys_PD_Filed.DCP_IsSummary = Convert.ToInt32(dr["DCP_IsSummary"]);
            if (dr["DCP_IsFilter"] != DBNull.Value) sys_PD_Filed.DCP_IsFilter = Convert.ToInt32(dr["DCP_IsFilter"]);
            ret.Add(sys_PD_Filed);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Sys_PD_Filed对象(即:一条记录
      /// </summary>
      public List<Sys_PD_Filed> GetAll()
      {
         List<Sys_PD_Filed> ret = new List<Sys_PD_Filed>();
         string sql = "SELECT  DCP_ID,DCP_ModuleName,DCP_ControlID,DCP_Label,DCP_ControlType,DCP_Type,DCP_Style,DCP_Order,DCP_IsHidden,DCP_IsReadonly,DCP_Udef1,DCP_Udef2,DCP_PageName,DCP_CreateTime,DCP_Model,DCP_RefSQL,DCP_RefBack,DCP_RefValue,DCP_RefCode,DCP_TX,DCP_TY,DCP_TI,DCP_Height,DCP_PControl,DCP_CControl,Stat,DCP_IsSummary,DCP_IsFilter FROM Sys_PD_Filed where 1=1 AND ((Stat is null) or (Stat=0) ) order by DCP_ID desc ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Sys_PD_Filed sys_PD_Filed = new Sys_PD_Filed();
            if (dr["DCP_ID"] != DBNull.Value) sys_PD_Filed.DCP_ID = Convert.ToDecimal(dr["DCP_ID"]);
            if (dr["DCP_ModuleName"] != DBNull.Value) sys_PD_Filed.DCP_ModuleName = Convert.ToString(dr["DCP_ModuleName"]);
            if (dr["DCP_ControlID"] != DBNull.Value) sys_PD_Filed.DCP_ControlID = Convert.ToString(dr["DCP_ControlID"]);
            if (dr["DCP_Label"] != DBNull.Value) sys_PD_Filed.DCP_Label = Convert.ToString(dr["DCP_Label"]);
            if (dr["DCP_ControlType"] != DBNull.Value) sys_PD_Filed.DCP_ControlType = Convert.ToString(dr["DCP_ControlType"]);
            if (dr["DCP_Type"] != DBNull.Value) sys_PD_Filed.DCP_Type = Convert.ToString(dr["DCP_Type"]);
            if (dr["DCP_Style"] != DBNull.Value) sys_PD_Filed.DCP_Style = Convert.ToString(dr["DCP_Style"]);
            if (dr["DCP_Order"] != DBNull.Value) sys_PD_Filed.DCP_Order = Convert.ToInt32(dr["DCP_Order"]);
            if (dr["DCP_IsHidden"] != DBNull.Value) sys_PD_Filed.DCP_IsHidden = Convert.ToInt32(dr["DCP_IsHidden"]);
            if (dr["DCP_IsReadonly"] != DBNull.Value) sys_PD_Filed.DCP_IsReadonly = Convert.ToInt32(dr["DCP_IsReadonly"]);
            if (dr["DCP_Udef1"] != DBNull.Value) sys_PD_Filed.DCP_Udef1 = Convert.ToString(dr["DCP_Udef1"]);
            if (dr["DCP_Udef2"] != DBNull.Value) sys_PD_Filed.DCP_Udef2 = Convert.ToString(dr["DCP_Udef2"]);
            if (dr["DCP_PageName"] != DBNull.Value) sys_PD_Filed.DCP_PageName = Convert.ToString(dr["DCP_PageName"]);
            if (dr["DCP_CreateTime"] != DBNull.Value) sys_PD_Filed.DCP_CreateTime = Convert.ToString(dr["DCP_CreateTime"]);
            if (dr["DCP_Model"] != DBNull.Value) sys_PD_Filed.DCP_Model = Convert.ToString(dr["DCP_Model"]);
            if (dr["DCP_RefSQL"] != DBNull.Value) sys_PD_Filed.DCP_RefSQL = Convert.ToString(dr["DCP_RefSQL"]);
            if (dr["DCP_RefBack"] != DBNull.Value) sys_PD_Filed.DCP_RefBack = Convert.ToString(dr["DCP_RefBack"]);
            if (dr["DCP_RefValue"] != DBNull.Value) sys_PD_Filed.DCP_RefValue = Convert.ToString(dr["DCP_RefValue"]);
            if (dr["DCP_RefCode"] != DBNull.Value) sys_PD_Filed.DCP_RefCode = Convert.ToString(dr["DCP_RefCode"]);
            if (dr["DCP_TX"] != DBNull.Value) sys_PD_Filed.DCP_TX = Convert.ToInt32(dr["DCP_TX"]);
            if (dr["DCP_TY"] != DBNull.Value) sys_PD_Filed.DCP_TY = Convert.ToInt32(dr["DCP_TY"]);
            if (dr["DCP_TI"] != DBNull.Value) sys_PD_Filed.DCP_TI = Convert.ToInt32(dr["DCP_TI"]);
            if (dr["DCP_Height"] != DBNull.Value) sys_PD_Filed.DCP_Height = Convert.ToInt32(dr["DCP_Height"]);
            if (dr["DCP_PControl"] != DBNull.Value) sys_PD_Filed.DCP_PControl = Convert.ToString(dr["DCP_PControl"]);
            if (dr["DCP_CControl"] != DBNull.Value) sys_PD_Filed.DCP_CControl = Convert.ToString(dr["DCP_CControl"]);
            if (dr["Stat"] != DBNull.Value) sys_PD_Filed.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["DCP_IsSummary"] != DBNull.Value) sys_PD_Filed.DCP_IsSummary = Convert.ToInt32(dr["DCP_IsSummary"]);
            if (dr["DCP_IsFilter"] != DBNull.Value) sys_PD_Filed.DCP_IsFilter = Convert.ToInt32(dr["DCP_IsFilter"]);
            ret.Add(sys_PD_Filed);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
