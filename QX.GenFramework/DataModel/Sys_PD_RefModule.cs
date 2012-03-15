using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.GenFramework.Model
{
   [Serializable]
   public partial class Sys_PD_RefModule
   {
      private Int64 sPR_ID;
      private bool sPR_ID_IsChanged=false;
      public Int64 SPR_ID
      {
         get{ return sPR_ID; }
         set{ sPR_ID = value; sPR_ID_IsChanged=true; }
      }
      public bool SPR_ID_IsChanged
      {
         get{ return sPR_ID_IsChanged; }
         set{ sPR_ID_IsChanged = value; }
      }
      private string sPR_RefModule;
      private bool sPR_RefModule_IsChanged=false;
      public string SPR_RefModule
      {
         get{ return sPR_RefModule; }
         set{ sPR_RefModule = value; sPR_RefModule_IsChanged=true; }
      }
      public bool SPR_RefModule_IsChanged
      {
         get{ return sPR_RefModule_IsChanged; }
         set{ sPR_RefModule_IsChanged = value; }
      }
      private string sPR_RefSQL;
      private bool sPR_RefSQL_IsChanged=false;
      public string SPR_RefSQL
      {
         get{ return sPR_RefSQL; }
         set{ sPR_RefSQL = value; sPR_RefSQL_IsChanged=true; }
      }
      public bool SPR_RefSQL_IsChanged
      {
         get{ return sPR_RefSQL_IsChanged; }
         set{ sPR_RefSQL_IsChanged = value; }
      }
      private string sPR_RefValue;
      private bool sPR_RefValue_IsChanged=false;
      public string SPR_RefValue
      {
         get{ return sPR_RefValue; }
         set{ sPR_RefValue = value; sPR_RefValue_IsChanged=true; }
      }
      public bool SPR_RefValue_IsChanged
      {
         get{ return sPR_RefValue_IsChanged; }
         set{ sPR_RefValue_IsChanged = value; }
      }
      private string sPR_RefData;
      private bool sPR_RefData_IsChanged=false;
      public string SPR_RefData
      {
         get{ return sPR_RefData; }
         set{ sPR_RefData = value; sPR_RefData_IsChanged=true; }
      }
      public bool SPR_RefData_IsChanged
      {
         get{ return sPR_RefData_IsChanged; }
         set{ sPR_RefData_IsChanged = value; }
      }
      private string sPR_UDef1;
      private bool sPR_UDef1_IsChanged=false;
      public string SPR_UDef1
      {
         get{ return sPR_UDef1; }
         set{ sPR_UDef1 = value; sPR_UDef1_IsChanged=true; }
      }
      public bool SPR_UDef1_IsChanged
      {
         get{ return sPR_UDef1_IsChanged; }
         set{ sPR_UDef1_IsChanged = value; }
      }
      private string sPR_UDef2;
      private bool sPR_UDef2_IsChanged=false;
      public string SPR_UDef2
      {
         get{ return sPR_UDef2; }
         set{ sPR_UDef2 = value; sPR_UDef2_IsChanged=true; }
      }
      public bool SPR_UDef2_IsChanged
      {
         get{ return sPR_UDef2_IsChanged; }
         set{ sPR_UDef2_IsChanged = value; }
      }
      private string sPR_UDef3;
      private bool sPR_UDef3_IsChanged=false;
      public string SPR_UDef3
      {
         get{ return sPR_UDef3; }
         set{ sPR_UDef3 = value; sPR_UDef3_IsChanged=true; }
      }
      public bool SPR_UDef3_IsChanged
      {
         get{ return sPR_UDef3_IsChanged; }
         set{ sPR_UDef3_IsChanged = value; }
      }
      private string sPR_UDef4;
      private bool sPR_UDef4_IsChanged=false;
      public string SPR_UDef4
      {
         get{ return sPR_UDef4; }
         set{ sPR_UDef4 = value; sPR_UDef4_IsChanged=true; }
      }
      public bool SPR_UDef4_IsChanged
      {
         get{ return sPR_UDef4_IsChanged; }
         set{ sPR_UDef4_IsChanged = value; }
      }
      private string sPR_UDef5;
      private bool sPR_UDef5_IsChanged=false;
      public string SPR_UDef5
      {
         get{ return sPR_UDef5; }
         set{ sPR_UDef5 = value; sPR_UDef5_IsChanged=true; }
      }
      public bool SPR_UDef5_IsChanged
      {
         get{ return sPR_UDef5_IsChanged; }
         set{ sPR_UDef5_IsChanged = value; }
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
