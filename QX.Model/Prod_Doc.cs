using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Prod_Doc
   {
      private decimal pRDQ_ID;
      private bool pRDQ_ID_IsChanged=false;
      public decimal PRDQ_ID
      {
         get{ return pRDQ_ID; }
         set{ pRDQ_ID = value; pRDQ_ID_IsChanged=true; }
      }
      public bool PRDQ_ID_IsChanged
      {
         get{ return pRDQ_ID_IsChanged; }
         set{ pRDQ_ID_IsChanged = value; }
      }
      /// <summary>
      /// 报告编号
      /// </summary>
      private string pRDQ_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_Code_IsChanged=false;
      /// <summary>
      /// 报告编号
      /// </summary>
      public string PRDQ_Code
      {
         get{ return pRDQ_Code; }
         set{ pRDQ_Code = value; pRDQ_Code_IsChanged=true; }
      }
      /// <summary>
      /// 报告编号
      /// </summary>
      public bool PRDQ_Code_IsChanged
      {
         get{ return pRDQ_Code_IsChanged; }
         set{ pRDQ_Code_IsChanged = value; }
      }
      /// <summary>
      /// 零件编号
      /// </summary>
      private string pRDQ_CompNo;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_CompNo_IsChanged=false;
      /// <summary>
      /// 零件编号
      /// </summary>
      public string PRDQ_CompNo
      {
         get{ return pRDQ_CompNo; }
         set{ pRDQ_CompNo = value; pRDQ_CompNo_IsChanged=true; }
      }
      /// <summary>
      /// 零件编号
      /// </summary>
      public bool PRDQ_CompNo_IsChanged
      {
         get{ return pRDQ_CompNo_IsChanged; }
         set{ pRDQ_CompNo_IsChanged = value; }
      }
      /// <summary>
      /// 零件图号
      /// </summary>
      private string pRDQ_CompCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_CompCode_IsChanged=false;
      /// <summary>
      /// 零件图号
      /// </summary>
      public string PRDQ_CompCode
      {
         get{ return pRDQ_CompCode; }
         set{ pRDQ_CompCode = value; pRDQ_CompCode_IsChanged=true; }
      }
      /// <summary>
      /// 零件图号
      /// </summary>
      public bool PRDQ_CompCode_IsChanged
      {
         get{ return pRDQ_CompCode_IsChanged; }
         set{ pRDQ_CompCode_IsChanged = value; }
      }
      /// <summary>
      /// 零件名称
      /// </summary>
      private string pRDQ_CompName;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_CompName_IsChanged=false;
      /// <summary>
      /// 零件名称
      /// </summary>
      public string PRDQ_CompName
      {
         get{ return pRDQ_CompName; }
         set{ pRDQ_CompName = value; pRDQ_CompName_IsChanged=true; }
      }
      /// <summary>
      /// 零件名称
      /// </summary>
      public bool PRDQ_CompName_IsChanged
      {
         get{ return pRDQ_CompName_IsChanged; }
         set{ pRDQ_CompName_IsChanged = value; }
      }
      private string pRDQ_Name;
      private bool pRDQ_Name_IsChanged=false;
      public string PRDQ_Name
      {
         get{ return pRDQ_Name; }
         set{ pRDQ_Name = value; pRDQ_Name_IsChanged=true; }
      }
      public bool PRDQ_Name_IsChanged
      {
         get{ return pRDQ_Name_IsChanged; }
         set{ pRDQ_Name_IsChanged = value; }
      }
      /// <summary>
      /// 报告类型
      /// </summary>
      private string pRDQ_Type;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_Type_IsChanged=false;
      /// <summary>
      /// 报告类型
      /// </summary>
      public string PRDQ_Type
      {
         get{ return pRDQ_Type; }
         set{ pRDQ_Type = value; pRDQ_Type_IsChanged=true; }
      }
      /// <summary>
      /// 报告类型
      /// </summary>
      public bool PRDQ_Type_IsChanged
      {
         get{ return pRDQ_Type_IsChanged; }
         set{ pRDQ_Type_IsChanged = value; }
      }
      /// <summary>
      /// 文档内部类型
      /// </summary>
      private string pRDQ_iType;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_iType_IsChanged=false;
      /// <summary>
      /// 文档内部类型
      /// </summary>
      public string PRDQ_iType
      {
         get{ return pRDQ_iType; }
         set{ pRDQ_iType = value; pRDQ_iType_IsChanged=true; }
      }
      /// <summary>
      /// 文档内部类型
      /// </summary>
      public bool PRDQ_iType_IsChanged
      {
         get{ return pRDQ_iType_IsChanged; }
         set{ pRDQ_iType_IsChanged = value; }
      }
      /// <summary>
      /// 报告日期
      /// </summary>
      private string pRDQ_Date;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_Date_IsChanged=false;
      /// <summary>
      /// 报告日期
      /// </summary>
      public string PRDQ_Date
      {
         get{ return pRDQ_Date; }
         set{ pRDQ_Date = value; pRDQ_Date_IsChanged=true; }
      }
      /// <summary>
      /// 报告日期
      /// </summary>
      public bool PRDQ_Date_IsChanged
      {
         get{ return pRDQ_Date_IsChanged; }
         set{ pRDQ_Date_IsChanged = value; }
      }
      /// <summary>
      /// 报告人
      /// </summary>
      private string pRDQ_Owner;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_Owner_IsChanged=false;
      /// <summary>
      /// 报告人
      /// </summary>
      public string PRDQ_Owner
      {
         get{ return pRDQ_Owner; }
         set{ pRDQ_Owner = value; pRDQ_Owner_IsChanged=true; }
      }
      /// <summary>
      /// 报告人
      /// </summary>
      public bool PRDQ_Owner_IsChanged
      {
         get{ return pRDQ_Owner_IsChanged; }
         set{ pRDQ_Owner_IsChanged = value; }
      }
      /// <summary>
      /// 报告厂家
      /// </summary>
      private string pRDQ_Plant;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_Plant_IsChanged=false;
      /// <summary>
      /// 报告厂家
      /// </summary>
      public string PRDQ_Plant
      {
         get{ return pRDQ_Plant; }
         set{ pRDQ_Plant = value; pRDQ_Plant_IsChanged=true; }
      }
      /// <summary>
      /// 报告厂家
      /// </summary>
      public bool PRDQ_Plant_IsChanged
      {
         get{ return pRDQ_Plant_IsChanged; }
         set{ pRDQ_Plant_IsChanged = value; }
      }
      /// <summary>
      /// 检验结果
      /// </summary>
      private string pRDQ_Result;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_Result_IsChanged=false;
      /// <summary>
      /// 检验结果
      /// </summary>
      public string PRDQ_Result
      {
         get{ return pRDQ_Result; }
         set{ pRDQ_Result = value; pRDQ_Result_IsChanged=true; }
      }
      /// <summary>
      /// 检验结果
      /// </summary>
      public bool PRDQ_Result_IsChanged
      {
         get{ return pRDQ_Result_IsChanged; }
         set{ pRDQ_Result_IsChanged = value; }
      }
      /// <summary>
      /// 不合格审理单号
      /// </summary>
      private string pRDQ_FCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_FCode_IsChanged=false;
      /// <summary>
      /// 不合格审理单号
      /// </summary>
      public string PRDQ_FCode
      {
         get{ return pRDQ_FCode; }
         set{ pRDQ_FCode = value; pRDQ_FCode_IsChanged=true; }
      }
      /// <summary>
      /// 不合格审理单号
      /// </summary>
      public bool PRDQ_FCode_IsChanged
      {
         get{ return pRDQ_FCode_IsChanged; }
         set{ pRDQ_FCode_IsChanged = value; }
      }
      /// <summary>
      /// 不合格原因
      /// </summary>
      private string pRDQ_FReso;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_FReso_IsChanged=false;
      /// <summary>
      /// 不合格原因
      /// </summary>
      public string PRDQ_FReso
      {
         get{ return pRDQ_FReso; }
         set{ pRDQ_FReso = value; pRDQ_FReso_IsChanged=true; }
      }
      /// <summary>
      /// 不合格原因
      /// </summary>
      public bool PRDQ_FReso_IsChanged
      {
         get{ return pRDQ_FReso_IsChanged; }
         set{ pRDQ_FReso_IsChanged = value; }
      }
      /// <summary>
      /// 处理意见
      /// </summary>
      private string pRDQ_FOpi;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_FOpi_IsChanged=false;
      /// <summary>
      /// 处理意见
      /// </summary>
      public string PRDQ_FOpi
      {
         get{ return pRDQ_FOpi; }
         set{ pRDQ_FOpi = value; pRDQ_FOpi_IsChanged=true; }
      }
      /// <summary>
      /// 处理意见
      /// </summary>
      public bool PRDQ_FOpi_IsChanged
      {
         get{ return pRDQ_FOpi_IsChanged; }
         set{ pRDQ_FOpi_IsChanged = value; }
      }
      /// <summary>
      /// 报废单号
      /// </summary>
      private string pRDQ_FDeC;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_FDeC_IsChanged=false;
      /// <summary>
      /// 报废单号
      /// </summary>
      public string PRDQ_FDeC
      {
         get{ return pRDQ_FDeC; }
         set{ pRDQ_FDeC = value; pRDQ_FDeC_IsChanged=true; }
      }
      /// <summary>
      /// 报废单号
      /// </summary>
      public bool PRDQ_FDeC_IsChanged
      {
         get{ return pRDQ_FDeC_IsChanged; }
         set{ pRDQ_FDeC_IsChanged = value; }
      }
      /// <summary>
      /// 报告备注
      /// </summary>
      private string pRDQ_Bak;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_Bak_IsChanged=false;
      /// <summary>
      /// 报告备注
      /// </summary>
      public string PRDQ_Bak
      {
         get{ return pRDQ_Bak; }
         set{ pRDQ_Bak = value; pRDQ_Bak_IsChanged=true; }
      }
      /// <summary>
      /// 报告备注
      /// </summary>
      public bool PRDQ_Bak_IsChanged
      {
         get{ return pRDQ_Bak_IsChanged; }
         set{ pRDQ_Bak_IsChanged = value; }
      }
      /// <summary>
      /// 不合格处理时间
      /// </summary>
      private string pRDQ_FDate;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDQ_FDate_IsChanged=false;
      /// <summary>
      /// 不合格处理时间
      /// </summary>
      public string PRDQ_FDate
      {
         get{ return pRDQ_FDate; }
         set{ pRDQ_FDate = value; pRDQ_FDate_IsChanged=true; }
      }
      /// <summary>
      /// 不合格处理时间
      /// </summary>
      public bool PRDQ_FDate_IsChanged
      {
         get{ return pRDQ_FDate_IsChanged; }
         set{ pRDQ_FDate_IsChanged = value; }
      }
      private int pRDQ_IsScan;
      private bool pRDQ_IsScan_IsChanged=false;
      public int PRDQ_IsScan
      {
         get{ return pRDQ_IsScan; }
         set{ pRDQ_IsScan = value; pRDQ_IsScan_IsChanged=true; }
      }
      public bool PRDQ_IsScan_IsChanged
      {
         get{ return pRDQ_IsScan_IsChanged; }
         set{ pRDQ_IsScan_IsChanged = value; }
      }
      private string pRDQ_IsNeed;
      private bool pRDQ_IsNeed_IsChanged=false;
      public string PRDQ_IsNeed
      {
         get{ return pRDQ_IsNeed; }
         set{ pRDQ_IsNeed = value; pRDQ_IsNeed_IsChanged=true; }
      }
      public bool PRDQ_IsNeed_IsChanged
      {
         get{ return pRDQ_IsNeed_IsChanged; }
         set{ pRDQ_IsNeed_IsChanged = value; }
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
