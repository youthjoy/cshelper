using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Sys_CSMenu
   {
      private decimal cMenu_ID;
      private bool cMenu_ID_IsChanged=false;
      public decimal CMenu_ID
      {
         get{ return cMenu_ID; }
         set{ cMenu_ID = value; cMenu_ID_IsChanged=true; }
      }
      public bool CMenu_ID_IsChanged
      {
         get{ return cMenu_ID_IsChanged; }
         set{ cMenu_ID_IsChanged = value; }
      }
      private string cMenu_Name;
      private bool cMenu_Name_IsChanged=false;
      public string CMenu_Name
      {
         get{ return cMenu_Name; }
         set{ cMenu_Name = value; cMenu_Name_IsChanged=true; }
      }
      public bool CMenu_Name_IsChanged
      {
         get{ return cMenu_Name_IsChanged; }
         set{ cMenu_Name_IsChanged = value; }
      }
      private string cMenu_Code;
      private bool cMenu_Code_IsChanged=false;
      public string CMenu_Code
      {
         get{ return cMenu_Code; }
         set{ cMenu_Code = value; cMenu_Code_IsChanged=true; }
      }
      public bool CMenu_Code_IsChanged
      {
         get{ return cMenu_Code_IsChanged; }
         set{ cMenu_Code_IsChanged = value; }
      }
      private string cMenu_PCode;
      private bool cMenu_PCode_IsChanged=false;
      public string CMenu_PCode
      {
         get{ return cMenu_PCode; }
         set{ cMenu_PCode = value; cMenu_PCode_IsChanged=true; }
      }
      public bool CMenu_PCode_IsChanged
      {
         get{ return cMenu_PCode_IsChanged; }
         set{ cMenu_PCode_IsChanged = value; }
      }
      private string cMenu_Path;
      private bool cMenu_Path_IsChanged=false;
      public string CMenu_Path
      {
         get{ return cMenu_Path; }
         set{ cMenu_Path = value; cMenu_Path_IsChanged=true; }
      }
      public bool CMenu_Path_IsChanged
      {
         get{ return cMenu_Path_IsChanged; }
         set{ cMenu_Path_IsChanged = value; }
      }
      private string cMenu_IsModule;
      private bool cMenu_IsModule_IsChanged=false;
      public string CMenu_IsModule
      {
         get{ return cMenu_IsModule; }
         set{ cMenu_IsModule = value; cMenu_IsModule_IsChanged=true; }
      }
      public bool CMenu_IsModule_IsChanged
      {
         get{ return cMenu_IsModule_IsChanged; }
         set{ cMenu_IsModule_IsChanged = value; }
      }
      private string cMenu_ExtParameter;
      private bool cMenu_ExtParameter_IsChanged=false;
      public string CMenu_ExtParameter
      {
         get{ return cMenu_ExtParameter; }
         set{ cMenu_ExtParameter = value; cMenu_ExtParameter_IsChanged=true; }
      }
      public bool CMenu_ExtParameter_IsChanged
      {
         get{ return cMenu_ExtParameter_IsChanged; }
         set{ cMenu_ExtParameter_IsChanged = value; }
      }
      private string cMenu_iType;
      private bool cMenu_iType_IsChanged=false;
      public string CMenu_iType
      {
         get{ return cMenu_iType; }
         set{ cMenu_iType = value; cMenu_iType_IsChanged=true; }
      }
      public bool CMenu_iType_IsChanged
      {
         get{ return cMenu_iType_IsChanged; }
         set{ cMenu_iType_IsChanged = value; }
      }
      private string cMenu_Image;
      private bool cMenu_Image_IsChanged=false;
      public string CMenu_Image
      {
         get{ return cMenu_Image; }
         set{ cMenu_Image = value; cMenu_Image_IsChanged=true; }
      }
      public bool CMenu_Image_IsChanged
      {
         get{ return cMenu_Image_IsChanged; }
         set{ cMenu_Image_IsChanged = value; }
      }
      private string cMenu_Level;
      private bool cMenu_Level_IsChanged=false;
      public string CMenu_Level
      {
         get{ return cMenu_Level; }
         set{ cMenu_Level = value; cMenu_Level_IsChanged=true; }
      }
      public bool CMenu_Level_IsChanged
      {
         get{ return cMenu_Level_IsChanged; }
         set{ cMenu_Level_IsChanged = value; }
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
      private string cMenu_Udef1;
      private bool cMenu_Udef1_IsChanged=false;
      public string CMenu_Udef1
      {
         get{ return cMenu_Udef1; }
         set{ cMenu_Udef1 = value; cMenu_Udef1_IsChanged=true; }
      }
      public bool CMenu_Udef1_IsChanged
      {
         get{ return cMenu_Udef1_IsChanged; }
         set{ cMenu_Udef1_IsChanged = value; }
      }
      private string cMenu_Udef2;
      private bool cMenu_Udef2_IsChanged=false;
      public string CMenu_Udef2
      {
         get{ return cMenu_Udef2; }
         set{ cMenu_Udef2 = value; cMenu_Udef2_IsChanged=true; }
      }
      public bool CMenu_Udef2_IsChanged
      {
         get{ return cMenu_Udef2_IsChanged; }
         set{ cMenu_Udef2_IsChanged = value; }
      }
      private string cMenu_Udef3;
      private bool cMenu_Udef3_IsChanged=false;
      public string CMenu_Udef3
      {
         get{ return cMenu_Udef3; }
         set{ cMenu_Udef3 = value; cMenu_Udef3_IsChanged=true; }
      }
      public bool CMenu_Udef3_IsChanged
      {
         get{ return cMenu_Udef3_IsChanged; }
         set{ cMenu_Udef3_IsChanged = value; }
      }
      private int cMenu_Order;
      private bool cMenu_Order_IsChanged=false;
      public int CMenu_Order
      {
         get{ return cMenu_Order; }
         set{ cMenu_Order = value; cMenu_Order_IsChanged=true; }
      }
      public bool CMenu_Order_IsChanged
      {
         get{ return cMenu_Order_IsChanged; }
         set{ cMenu_Order_IsChanged = value; }
      }
   }
}
