using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Sys_DictModule
   {
      private Int64 iD;
      private bool iD_IsChanged=false;
      public Int64 ID
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
      private bool isCompany;
      private bool isCompany_IsChanged=false;
      public bool IsCompany
      {
         get{ return isCompany; }
         set{ isCompany = value; isCompany_IsChanged=true; }
      }
      public bool IsCompany_IsChanged
      {
         get{ return isCompany_IsChanged; }
         set{ isCompany_IsChanged = value; }
      }
      private int codeLength;
      private bool codeLength_IsChanged=false;
      public int CodeLength
      {
         get{ return codeLength; }
         set{ codeLength = value; codeLength_IsChanged=true; }
      }
      public bool CodeLength_IsChanged
      {
         get{ return codeLength_IsChanged; }
         set{ codeLength_IsChanged = value; }
      }
      private int childLength;
      private bool childLength_IsChanged=false;
      public int ChildLength
      {
         get{ return childLength; }
         set{ childLength = value; childLength_IsChanged=true; }
      }
      public bool ChildLength_IsChanged
      {
         get{ return childLength_IsChanged; }
         set{ childLength_IsChanged = value; }
      }
      private string tableName;
      private bool tableName_IsChanged=false;
      public string TableName
      {
         get{ return tableName; }
         set{ tableName = value; tableName_IsChanged=true; }
      }
      public bool TableName_IsChanged
      {
         get{ return tableName_IsChanged; }
         set{ tableName_IsChanged = value; }
      }
      private string codeField;
      private bool codeField_IsChanged=false;
      public string CodeField
      {
         get{ return codeField; }
         set{ codeField = value; codeField_IsChanged=true; }
      }
      public bool CodeField_IsChanged
      {
         get{ return codeField_IsChanged; }
         set{ codeField_IsChanged = value; }
      }
      private string filterSQL;
      private bool filterSQL_IsChanged=false;
      public string FilterSQL
      {
         get{ return filterSQL; }
         set{ filterSQL = value; filterSQL_IsChanged=true; }
      }
      public bool FilterSQL_IsChanged
      {
         get{ return filterSQL_IsChanged; }
         set{ filterSQL_IsChanged = value; }
      }
      private string udef1;
      private bool udef1_IsChanged=false;
      public string Udef1
      {
         get{ return udef1; }
         set{ udef1 = value; udef1_IsChanged=true; }
      }
      public bool Udef1_IsChanged
      {
         get{ return udef1_IsChanged; }
         set{ udef1_IsChanged = value; }
      }
      private string udef2;
      private bool udef2_IsChanged=false;
      public string Udef2
      {
         get{ return udef2; }
         set{ udef2 = value; udef2_IsChanged=true; }
      }
      public bool Udef2_IsChanged
      {
         get{ return udef2_IsChanged; }
         set{ udef2_IsChanged = value; }
      }
      private string udef3;
      private bool udef3_IsChanged=false;
      public string Udef3
      {
         get{ return udef3; }
         set{ udef3 = value; udef3_IsChanged=true; }
      }
      public bool Udef3_IsChanged
      {
         get{ return udef3_IsChanged; }
         set{ udef3_IsChanged = value; }
      }
      private string udef4;
      private bool udef4_IsChanged=false;
      public string Udef4
      {
         get{ return udef4; }
         set{ udef4 = value; udef4_IsChanged=true; }
      }
      public bool Udef4_IsChanged
      {
         get{ return udef4_IsChanged; }
         set{ udef4_IsChanged = value; }
      }
      private string udef5;
      private bool udef5_IsChanged=false;
      public string Udef5
      {
         get{ return udef5; }
         set{ udef5 = value; udef5_IsChanged=true; }
      }
      public bool Udef5_IsChanged
      {
         get{ return udef5_IsChanged; }
         set{ udef5_IsChanged = value; }
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
