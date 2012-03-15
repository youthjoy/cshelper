using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   /// <summary>
   /// 系统运行日志
   /// </summary>
   [Serializable]
   public partial class Sys_RunLog
   {
      private decimal log_ID;
      private bool log_ID_IsChanged=false;
      public decimal Log_ID
      {
         get{ return log_ID; }
         set{ log_ID = value; log_ID_IsChanged=true; }
      }
      public bool Log_ID_IsChanged
      {
         get{ return log_ID_IsChanged; }
         set{ log_ID_IsChanged = value; }
      }
      private DateTime log_Date;
      private bool log_Date_IsChanged=false;
      public DateTime Log_Date
      {
         get{ return log_Date; }
         set{ log_Date = value; log_Date_IsChanged=true; }
      }
      public bool Log_Date_IsChanged
      {
         get{ return log_Date_IsChanged; }
         set{ log_Date_IsChanged = value; }
      }
      private string log_SQL;
      private bool log_SQL_IsChanged=false;
      public string Log_SQL
      {
         get{ return log_SQL; }
         set{ log_SQL = value; log_SQL_IsChanged=true; }
      }
      public bool Log_SQL_IsChanged
      {
         get{ return log_SQL_IsChanged; }
         set{ log_SQL_IsChanged = value; }
      }
      private string log_Author;
      private bool log_Author_IsChanged=false;
      public string Log_Author
      {
         get{ return log_Author; }
         set{ log_Author = value; log_Author_IsChanged=true; }
      }
      public bool Log_Author_IsChanged
      {
         get{ return log_Author_IsChanged; }
         set{ log_Author_IsChanged = value; }
      }
      private string log_Fun;
      private bool log_Fun_IsChanged=false;
      public string Log_Fun
      {
         get{ return log_Fun; }
         set{ log_Fun = value; log_Fun_IsChanged=true; }
      }
      public bool Log_Fun_IsChanged
      {
         get{ return log_Fun_IsChanged; }
         set{ log_Fun_IsChanged = value; }
      }
      private string log_SQLParameter;
      private bool log_SQLParameter_IsChanged=false;
      public string Log_SQLParameter
      {
         get{ return log_SQLParameter; }
         set{ log_SQLParameter = value; log_SQLParameter_IsChanged=true; }
      }
      public bool Log_SQLParameter_IsChanged
      {
         get{ return log_SQLParameter_IsChanged; }
         set{ log_SQLParameter_IsChanged = value; }
      }
      private string log_Error;
      private bool log_Error_IsChanged=false;
      public string Log_Error
      {
         get{ return log_Error; }
         set{ log_Error = value; log_Error_IsChanged=true; }
      }
      public bool Log_Error_IsChanged
      {
         get{ return log_Error_IsChanged; }
         set{ log_Error_IsChanged = value; }
      }
   }
}
