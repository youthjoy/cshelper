using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.GenFramework.Model
{
   [Serializable]
   public partial class Sys_PD_GridFormat
   {
      private Int64 sPGF_ID;
      private bool sPGF_ID_IsChanged=false;
      public Int64 SPGF_ID
      {
         get{ return sPGF_ID; }
         set{ sPGF_ID = value; sPGF_ID_IsChanged=true; }
      }
      public bool SPGF_ID_IsChanged
      {
         get{ return sPGF_ID_IsChanged; }
         set{ sPGF_ID_IsChanged = value; }
      }
      private string empl_NO;
      private bool empl_NO_IsChanged=false;
      public string Empl_NO
      {
         get{ return empl_NO; }
         set{ empl_NO = value; empl_NO_IsChanged=true; }
      }
      public bool Empl_NO_IsChanged
      {
         get{ return empl_NO_IsChanged; }
         set{ empl_NO_IsChanged = value; }
      }
      private string colFor_Code;
      private bool colFor_Code_IsChanged=false;
      public string ColFor_Code
      {
         get{ return colFor_Code; }
         set{ colFor_Code = value; colFor_Code_IsChanged=true; }
      }
      public bool ColFor_Code_IsChanged
      {
         get{ return colFor_Code_IsChanged; }
         set{ colFor_Code_IsChanged = value; }
      }
      private string colFor_ColName;
      private bool colFor_ColName_IsChanged=false;
      public string ColFor_ColName
      {
         get{ return colFor_ColName; }
         set{ colFor_ColName = value; colFor_ColName_IsChanged=true; }
      }
      public bool ColFor_ColName_IsChanged
      {
         get{ return colFor_ColName_IsChanged; }
         set{ colFor_ColName_IsChanged = value; }
      }
      private int colFor_ColOrder;
      private bool colFor_ColOrder_IsChanged=false;
      public int ColFor_ColOrder
      {
         get{ return colFor_ColOrder; }
         set{ colFor_ColOrder = value; colFor_ColOrder_IsChanged=true; }
      }
      public bool ColFor_ColOrder_IsChanged
      {
         get{ return colFor_ColOrder_IsChanged; }
         set{ colFor_ColOrder_IsChanged = value; }
      }
      private string colFor_ColWidth;
      private bool colFor_ColWidth_IsChanged=false;
      public string ColFor_ColWidth
      {
         get{ return colFor_ColWidth; }
         set{ colFor_ColWidth = value; colFor_ColWidth_IsChanged=true; }
      }
      public bool ColFor_ColWidth_IsChanged
      {
         get{ return colFor_ColWidth_IsChanged; }
         set{ colFor_ColWidth_IsChanged = value; }
      }
      private int stat;
      private bool stat_IsChanged=false;
      public int Stat
      {
         get{ return stat; }
         set{ stat = value; stat_IsChanged=true; }
      }
      public bool Stat_IsChanged
      {
         get{ return stat_IsChanged; }
         set{ stat_IsChanged = value; }
      }
   }
}
