using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Tpl_ReqDoc
   {
      private decimal tPRD_ID;
      private bool tPRD_ID_IsChanged=false;
      public decimal TPRD_ID
      {
         get{ return tPRD_ID; }
         set{ tPRD_ID = value; tPRD_ID_IsChanged=true; }
      }
      public bool TPRD_ID_IsChanged
      {
         get{ return tPRD_ID_IsChanged; }
         set{ tPRD_ID_IsChanged = value; }
      }
      /// <summary>
      /// 质量文档编号
      /// </summary>
      private string tPRD_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPRD_Code_IsChanged=false;
      /// <summary>
      /// 质量文档编号
      /// </summary>
      public string TPRD_Code
      {
         get{ return tPRD_Code; }
         set{ tPRD_Code = value; tPRD_Code_IsChanged=true; }
      }
      /// <summary>
      /// 质量文档编号
      /// </summary>
      public bool TPRD_Code_IsChanged
      {
         get{ return tPRD_Code_IsChanged; }
         set{ tPRD_Code_IsChanged = value; }
      }
      /// <summary>
      /// 零件图号
      /// </summary>
      private string tPRD_CompCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPRD_CompCode_IsChanged=false;
      /// <summary>
      /// 零件图号
      /// </summary>
      public string TPRD_CompCode
      {
         get{ return tPRD_CompCode; }
         set{ tPRD_CompCode = value; tPRD_CompCode_IsChanged=true; }
      }
      /// <summary>
      /// 零件图号
      /// </summary>
      public bool TPRD_CompCode_IsChanged
      {
         get{ return tPRD_CompCode_IsChanged; }
         set{ tPRD_CompCode_IsChanged = value; }
      }
      private string tPRD_CompName;
      private bool tPRD_CompName_IsChanged=false;
      public string TPRD_CompName
      {
         get{ return tPRD_CompName; }
         set{ tPRD_CompName = value; tPRD_CompName_IsChanged=true; }
      }
      public bool TPRD_CompName_IsChanged
      {
         get{ return tPRD_CompName_IsChanged; }
         set{ tPRD_CompName_IsChanged = value; }
      }
      /// <summary>
      /// 零件加工类型
      /// </summary>
      private string tPRD_Type;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPRD_Type_IsChanged=false;
      /// <summary>
      /// 零件加工类型
      /// </summary>
      public string TPRD_Type
      {
         get{ return tPRD_Type; }
         set{ tPRD_Type = value; tPRD_Type_IsChanged=true; }
      }
      /// <summary>
      /// 零件加工类型
      /// </summary>
      public bool TPRD_Type_IsChanged
      {
         get{ return tPRD_Type_IsChanged; }
         set{ tPRD_Type_IsChanged = value; }
      }
      /// <summary>
      /// 文档名称
      /// </summary>
      private string tPRD_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPRD_Name_IsChanged=false;
      /// <summary>
      /// 文档名称
      /// </summary>
      public string TPRD_Name
      {
         get{ return tPRD_Name; }
         set{ tPRD_Name = value; tPRD_Name_IsChanged=true; }
      }
      /// <summary>
      /// 文档名称
      /// </summary>
      public bool TPRD_Name_IsChanged
      {
         get{ return tPRD_Name_IsChanged; }
         set{ tPRD_Name_IsChanged = value; }
      }
      /// <summary>
      /// 是否必须
      /// </summary>
      private string tPRD_IsReq;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPRD_IsReq_IsChanged=false;
      /// <summary>
      /// 是否必须
      /// </summary>
      public string TPRD_IsReq
      {
         get{ return tPRD_IsReq; }
         set{ tPRD_IsReq = value; tPRD_IsReq_IsChanged=true; }
      }
      /// <summary>
      /// 是否必须
      /// </summary>
      public bool TPRD_IsReq_IsChanged
      {
         get{ return tPRD_IsReq_IsChanged; }
         set{ tPRD_IsReq_IsChanged = value; }
      }
      /// <summary>
      /// 质量文档说明
      /// </summary>
      private string tPRD_Exp;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPRD_Exp_IsChanged=false;
      /// <summary>
      /// 质量文档说明
      /// </summary>
      public string TPRD_Exp
      {
         get{ return tPRD_Exp; }
         set{ tPRD_Exp = value; tPRD_Exp_IsChanged=true; }
      }
      /// <summary>
      /// 质量文档说明
      /// </summary>
      public bool TPRD_Exp_IsChanged
      {
         get{ return tPRD_Exp_IsChanged; }
         set{ tPRD_Exp_IsChanged = value; }
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
      /// <summary>
      /// 录入人
      /// </summary>
      private DateTime creator;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool creator_IsChanged=false;
      /// <summary>
      /// 录入人
      /// </summary>
      public DateTime Creator
      {
         get{ return creator; }
         set{ creator = value; creator_IsChanged=true; }
      }
      /// <summary>
      /// 录入人
      /// </summary>
      public bool Creator_IsChanged
      {
         get{ return creator_IsChanged; }
         set{ creator_IsChanged = value; }
      }
      private DateTime createTime;
      private bool createTime_IsChanged=false;
      public DateTime CreateTime
      {
         get{ return createTime; }
         set{ createTime = value; createTime_IsChanged=true; }
      }
      public bool CreateTime_IsChanged
      {
         get{ return createTime_IsChanged; }
         set{ createTime_IsChanged = value; }
      }
      private DateTime updateTime;
      private bool updateTime_IsChanged=false;
      public DateTime UpdateTime
      {
         get{ return updateTime; }
         set{ updateTime = value; updateTime_IsChanged=true; }
      }
      public bool UpdateTime_IsChanged
      {
         get{ return updateTime_IsChanged; }
         set{ updateTime_IsChanged = value; }
      }
      private DateTime deleteTime;
      private bool deleteTime_IsChanged=false;
      public DateTime DeleteTime
      {
         get{ return deleteTime; }
         set{ deleteTime = value; deleteTime_IsChanged=true; }
      }
      public bool DeleteTime_IsChanged
      {
         get{ return deleteTime_IsChanged; }
         set{ deleteTime_IsChanged = value; }
      }
   }
}
