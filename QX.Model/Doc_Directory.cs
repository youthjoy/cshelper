using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Doc_Directory
   {
      private decimal dD_ID;
      private bool dD_ID_IsChanged=false;
      public decimal DD_ID
      {
         get{ return dD_ID; }
         set{ dD_ID = value; dD_ID_IsChanged=true; }
      }
      public bool DD_ID_IsChanged
      {
         get{ return dD_ID_IsChanged; }
         set{ dD_ID_IsChanged = value; }
      }
      private string dD_Code;
      private bool dD_Code_IsChanged=false;
      public string DD_Code
      {
         get{ return dD_Code; }
         set{ dD_Code = value; dD_Code_IsChanged=true; }
      }
      public bool DD_Code_IsChanged
      {
         get{ return dD_Code_IsChanged; }
         set{ dD_Code_IsChanged = value; }
      }
      private string dD_Name;
      private bool dD_Name_IsChanged=false;
      public string DD_Name
      {
         get{ return dD_Name; }
         set{ dD_Name = value; dD_Name_IsChanged=true; }
      }
      public bool DD_Name_IsChanged
      {
         get{ return dD_Name_IsChanged; }
         set{ dD_Name_IsChanged = value; }
      }
      private string dD_PCode;
      private bool dD_PCode_IsChanged=false;
      public string DD_PCode
      {
         get{ return dD_PCode; }
         set{ dD_PCode = value; dD_PCode_IsChanged=true; }
      }
      public bool DD_PCode_IsChanged
      {
         get{ return dD_PCode_IsChanged; }
         set{ dD_PCode_IsChanged = value; }
      }
      private int dD_iType;
      private bool dD_iType_IsChanged=false;
      public int DD_iType
      {
         get{ return dD_iType; }
         set{ dD_iType = value; dD_iType_IsChanged=true; }
      }
      public bool DD_iType_IsChanged
      {
         get{ return dD_iType_IsChanged; }
         set{ dD_iType_IsChanged = value; }
      }
      /// <summary>
      /// ??
      /// </summary>
      private int stat;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool stat_IsChanged=false;
      /// <summary>
      /// ??
      /// </summary>
      public int Stat
      {
         get{ return stat; }
         set{ stat = value; stat_IsChanged=true; }
      }
      /// <summary>
      /// ??
      /// </summary>
      public bool Stat_IsChanged
      {
         get{ return stat_IsChanged; }
         set{ stat_IsChanged = value; }
      }
   }
}
