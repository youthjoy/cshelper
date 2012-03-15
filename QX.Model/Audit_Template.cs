using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   /// <summary>
   /// 审核模板列表
   /// </summary>
   [Serializable]
   public partial class Audit_Template
   {
      /// <summary>
      /// 模板ID
      /// </summary>
      private decimal template_ID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool template_ID_IsChanged=false;
      /// <summary>
      /// 模板ID
      /// </summary>
      public decimal Template_ID
      {
         get{ return template_ID; }
         set{ template_ID = value; template_ID_IsChanged=true; }
      }
      /// <summary>
      /// 模板ID
      /// </summary>
      public bool Template_ID_IsChanged
      {
         get{ return template_ID_IsChanged; }
         set{ template_ID_IsChanged = value; }
      }
      /// <summary>
      /// 模板编码
      /// </summary>
      private string template_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool template_Code_IsChanged=false;
      /// <summary>
      /// 模板编码
      /// </summary>
      public string Template_Code
      {
         get{ return template_Code; }
         set{ template_Code = value; template_Code_IsChanged=true; }
      }
      /// <summary>
      /// 模板编码
      /// </summary>
      public bool Template_Code_IsChanged
      {
         get{ return template_Code_IsChanged; }
         set{ template_Code_IsChanged = value; }
      }
      /// <summary>
      /// 模板关键字
      /// </summary>
      private string template_Key;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool template_Key_IsChanged=false;
      /// <summary>
      /// 模板关键字
      /// </summary>
      public string Template_Key
      {
         get{ return template_Key; }
         set{ template_Key = value; template_Key_IsChanged=true; }
      }
      /// <summary>
      /// 模板关键字
      /// </summary>
      public bool Template_Key_IsChanged
      {
         get{ return template_Key_IsChanged; }
         set{ template_Key_IsChanged = value; }
      }
      /// <summary>
      /// 模板名称
      /// </summary>
      private string template_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool template_Name_IsChanged=false;
      /// <summary>
      /// 模板名称
      /// </summary>
      public string Template_Name
      {
         get{ return template_Name; }
         set{ template_Name = value; template_Name_IsChanged=true; }
      }
      /// <summary>
      /// 模板名称
      /// </summary>
      public bool Template_Name_IsChanged
      {
         get{ return template_Name_IsChanged; }
         set{ template_Name_IsChanged = value; }
      }
      /// <summary>
      /// 模板描述
      /// </summary>
      private string template_Remark;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool template_Remark_IsChanged=false;
      /// <summary>
      /// 模板描述
      /// </summary>
      public string Template_Remark
      {
         get{ return template_Remark; }
         set{ template_Remark = value; template_Remark_IsChanged=true; }
      }
      /// <summary>
      /// 模板描述
      /// </summary>
      public bool Template_Remark_IsChanged
      {
         get{ return template_Remark_IsChanged; }
         set{ template_Remark_IsChanged = value; }
      }
      /// <summary>
      /// 状态
      /// </summary>
      private int stat;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool stat_IsChanged=false;
      /// <summary>
      /// 状态
      /// </summary>
      public int Stat
      {
         get{ return stat; }
         set{ stat = value; stat_IsChanged=true; }
      }
      /// <summary>
      /// 状态
      /// </summary>
      public bool Stat_IsChanged
      {
         get{ return stat_IsChanged; }
         set{ stat_IsChanged = value; }
      }
      private string template_Table;
      private bool template_Table_IsChanged=false;
      public string Template_Table
      {
         get{ return template_Table; }
         set{ template_Table = value; template_Table_IsChanged=true; }
      }
      public bool Template_Table_IsChanged
      {
         get{ return template_Table_IsChanged; }
         set{ template_Table_IsChanged = value; }
      }
      private string template_Column;
      private bool template_Column_IsChanged=false;
      public string Template_Column
      {
         get{ return template_Column; }
         set{ template_Column = value; template_Column_IsChanged=true; }
      }
      public bool Template_Column_IsChanged
      {
         get{ return template_Column_IsChanged; }
         set{ template_Column_IsChanged = value; }
      }
      private string template_ColumnType;
      private bool template_ColumnType_IsChanged=false;
      public string Template_ColumnType
      {
         get{ return template_ColumnType; }
         set{ template_ColumnType = value; template_ColumnType_IsChanged=true; }
      }
      public bool Template_ColumnType_IsChanged
      {
         get{ return template_ColumnType_IsChanged; }
         set{ template_ColumnType_IsChanged = value; }
      }
      private string template_CheckSQL;
      private bool template_CheckSQL_IsChanged=false;
      public string Template_CheckSQL
      {
         get{ return template_CheckSQL; }
         set{ template_CheckSQL = value; template_CheckSQL_IsChanged=true; }
      }
      public bool Template_CheckSQL_IsChanged
      {
         get{ return template_CheckSQL_IsChanged; }
         set{ template_CheckSQL_IsChanged = value; }
      }
   }
}
