using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Sys_DictKey
   {
      private string tABLENAME;
      private bool tABLENAME_IsChanged=false;
      public string TABLENAME
      {
         get{ return tABLENAME; }
         set{ tABLENAME = value; tABLENAME_IsChanged=true; }
      }
      public bool TABLENAME_IsChanged
      {
         get{ return tABLENAME_IsChanged; }
         set{ tABLENAME_IsChanged = value; }
      }
      private string tABLEID;
      private bool tABLEID_IsChanged=false;
      public string TABLEID
      {
         get{ return tABLEID; }
         set{ tABLEID = value; tABLEID_IsChanged=true; }
      }
      public bool TABLEID_IsChanged
      {
         get{ return tABLEID_IsChanged; }
         set{ tABLEID_IsChanged = value; }
      }
      private int iD;
      private bool iD_IsChanged=false;
      public int ID
      {
         get{ return iD; }
         set{ iD = value; iD_IsChanged=true; }
      }
      public bool ID_IsChanged
      {
         get{ return iD_IsChanged; }
         set{ iD_IsChanged = value; }
      }
      private string moduleCode;
      private bool moduleCode_IsChanged=false;
      public string ModuleCode
      {
         get{ return moduleCode; }
         set{ moduleCode = value; moduleCode_IsChanged=true; }
      }
      public bool ModuleCode_IsChanged
      {
         get{ return moduleCode_IsChanged; }
         set{ moduleCode_IsChanged = value; }
      }
      private string prefixCode;
      private bool prefixCode_IsChanged=false;
      public string PrefixCode
      {
         get{ return prefixCode; }
         set{ prefixCode = value; prefixCode_IsChanged=true; }
      }
      public bool PrefixCode_IsChanged
      {
         get{ return prefixCode_IsChanged; }
         set{ prefixCode_IsChanged = value; }
      }
      private int codeLenth;
      private bool codeLenth_IsChanged=false;
      public int CodeLenth
      {
         get{ return codeLenth; }
         set{ codeLenth = value; codeLenth_IsChanged=true; }
      }
      public bool CodeLenth_IsChanged
      {
         get{ return codeLenth_IsChanged; }
         set{ codeLenth_IsChanged = value; }
      }
   }
}
