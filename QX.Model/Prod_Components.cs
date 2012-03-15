using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   /// <summary>
   /// 零件基本信息
   /// </summary>
   [Serializable]
   public partial class Prod_Components
   {
      private decimal pRDC_ID;
      private bool pRDC_ID_IsChanged=false;
      public decimal PRDC_ID
      {
         get{ return pRDC_ID; }
         set{ pRDC_ID = value; pRDC_ID_IsChanged=true; }
      }
      public bool PRDC_ID_IsChanged
      {
         get{ return pRDC_ID_IsChanged; }
         set{ pRDC_ID_IsChanged = value; }
      }
      /// <summary>
      /// 零件编号
      /// </summary>
      private string pRDC_CompNo;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_CompNo_IsChanged=false;
      /// <summary>
      /// 零件编号
      /// </summary>
      public string PRDC_CompNo
      {
         get{ return pRDC_CompNo; }
         set{ pRDC_CompNo = value; pRDC_CompNo_IsChanged=true; }
      }
      /// <summary>
      /// 零件编号
      /// </summary>
      public bool PRDC_CompNo_IsChanged
      {
         get{ return pRDC_CompNo_IsChanged; }
         set{ pRDC_CompNo_IsChanged = value; }
      }
      /// <summary>
      /// 零件图号
      /// </summary>
      private string pRDC_CompCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_CompCode_IsChanged=false;
      /// <summary>
      /// 零件图号
      /// </summary>
      public string PRDC_CompCode
      {
         get{ return pRDC_CompCode; }
         set{ pRDC_CompCode = value; pRDC_CompCode_IsChanged=true; }
      }
      /// <summary>
      /// 零件图号
      /// </summary>
      public bool PRDC_CompCode_IsChanged
      {
         get{ return pRDC_CompCode_IsChanged; }
         set{ pRDC_CompCode_IsChanged = value; }
      }
      /// <summary>
      /// 零件名称
      /// </summary>
      private string pRDC_CompName;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_CompName_IsChanged=false;
      /// <summary>
      /// 零件名称
      /// </summary>
      public string PRDC_CompName
      {
         get{ return pRDC_CompName; }
         set{ pRDC_CompName = value; pRDC_CompName_IsChanged=true; }
      }
      /// <summary>
      /// 零件名称
      /// </summary>
      public bool PRDC_CompName_IsChanged
      {
         get{ return pRDC_CompName_IsChanged; }
         set{ pRDC_CompName_IsChanged = value; }
      }
      /// <summary>
      /// 材质
      /// </summary>
      private string pRDC_Raw;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Raw_IsChanged=false;
      /// <summary>
      /// 材质
      /// </summary>
      public string PRDC_Raw
      {
         get{ return pRDC_Raw; }
         set{ pRDC_Raw = value; pRDC_Raw_IsChanged=true; }
      }
      /// <summary>
      /// 材质
      /// </summary>
      public bool PRDC_Raw_IsChanged
      {
         get{ return pRDC_Raw_IsChanged; }
         set{ pRDC_Raw_IsChanged = value; }
      }
      /// <summary>
      /// 生产厂家
      /// </summary>
      private string pRDC_Supp;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Supp_IsChanged=false;
      /// <summary>
      /// 生产厂家
      /// </summary>
      public string PRDC_Supp
      {
         get{ return pRDC_Supp; }
         set{ pRDC_Supp = value; pRDC_Supp_IsChanged=true; }
      }
      /// <summary>
      /// 生产厂家
      /// </summary>
      public bool PRDC_Supp_IsChanged
      {
         get{ return pRDC_Supp_IsChanged; }
         set{ pRDC_Supp_IsChanged = value; }
      }
      /// <summary>
      /// 红票日期
      /// </summary>
      private DateTime pRDC_RecDate;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_RecDate_IsChanged=false;
      /// <summary>
      /// 红票日期
      /// </summary>
      public DateTime PRDC_RecDate
      {
         get{ return pRDC_RecDate; }
         set{ pRDC_RecDate = value; pRDC_RecDate_IsChanged=true; }
      }
      /// <summary>
      /// 红票日期
      /// </summary>
      public bool PRDC_RecDate_IsChanged
      {
         get{ return pRDC_RecDate_IsChanged; }
         set{ pRDC_RecDate_IsChanged = value; }
      }
      /// <summary>
      /// 完工日期
      /// </summary>
      private DateTime pRDC_FinishDate;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_FinishDate_IsChanged=false;
      /// <summary>
      /// 完工日期
      /// </summary>
      public DateTime PRDC_FinishDate
      {
         get{ return pRDC_FinishDate; }
         set{ pRDC_FinishDate = value; pRDC_FinishDate_IsChanged=true; }
      }
      /// <summary>
      /// 完工日期
      /// </summary>
      public bool PRDC_FinishDate_IsChanged
      {
         get{ return pRDC_FinishDate_IsChanged; }
         set{ pRDC_FinishDate_IsChanged = value; }
      }
      /// <summary>
      /// 来样日期
      /// </summary>
      private DateTime pRDC_SampleDate;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_SampleDate_IsChanged=false;
      /// <summary>
      /// 来样日期
      /// </summary>
      public DateTime PRDC_SampleDate
      {
         get{ return pRDC_SampleDate; }
         set{ pRDC_SampleDate = value; pRDC_SampleDate_IsChanged=true; }
      }
      /// <summary>
      /// 来样日期
      /// </summary>
      public bool PRDC_SampleDate_IsChanged
      {
         get{ return pRDC_SampleDate_IsChanged; }
         set{ pRDC_SampleDate_IsChanged = value; }
      }
      /// <summary>
      /// 检验结果
      /// </summary>
      private string pRDC_VerifyResult;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_VerifyResult_IsChanged=false;
      /// <summary>
      /// 检验结果
      /// </summary>
      public string PRDC_VerifyResult
      {
         get{ return pRDC_VerifyResult; }
         set{ pRDC_VerifyResult = value; pRDC_VerifyResult_IsChanged=true; }
      }
      /// <summary>
      /// 检验结果
      /// </summary>
      public bool PRDC_VerifyResult_IsChanged
      {
         get{ return pRDC_VerifyResult_IsChanged; }
         set{ pRDC_VerifyResult_IsChanged = value; }
      }
      private string pRDC_iType;
      private bool pRDC_iType_IsChanged=false;
      public string PRDC_iType
      {
         get{ return pRDC_iType; }
         set{ pRDC_iType = value; pRDC_iType_IsChanged=true; }
      }
      public bool PRDC_iType_IsChanged
      {
         get{ return pRDC_iType_IsChanged; }
         set{ pRDC_iType_IsChanged = value; }
      }
      /// <summary>
      /// 屈服点
      /// </summary>
      private string pRDC_Tec1;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec1_IsChanged=false;
      /// <summary>
      /// 屈服点
      /// </summary>
      public string PRDC_Tec1
      {
         get{ return pRDC_Tec1; }
         set{ pRDC_Tec1 = value; pRDC_Tec1_IsChanged=true; }
      }
      /// <summary>
      /// 屈服点
      /// </summary>
      public bool PRDC_Tec1_IsChanged
      {
         get{ return pRDC_Tec1_IsChanged; }
         set{ pRDC_Tec1_IsChanged = value; }
      }
      /// <summary>
      /// 抗拉强度
      /// </summary>
      private string pRDC_Tec2;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec2_IsChanged=false;
      /// <summary>
      /// 抗拉强度
      /// </summary>
      public string PRDC_Tec2
      {
         get{ return pRDC_Tec2; }
         set{ pRDC_Tec2 = value; pRDC_Tec2_IsChanged=true; }
      }
      /// <summary>
      /// 抗拉强度
      /// </summary>
      public bool PRDC_Tec2_IsChanged
      {
         get{ return pRDC_Tec2_IsChanged; }
         set{ pRDC_Tec2_IsChanged = value; }
      }
      /// <summary>
      /// 伸长率
      /// </summary>
      private string pRDC_Tec3;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec3_IsChanged=false;
      /// <summary>
      /// 伸长率
      /// </summary>
      public string PRDC_Tec3
      {
         get{ return pRDC_Tec3; }
         set{ pRDC_Tec3 = value; pRDC_Tec3_IsChanged=true; }
      }
      /// <summary>
      /// 伸长率
      /// </summary>
      public bool PRDC_Tec3_IsChanged
      {
         get{ return pRDC_Tec3_IsChanged; }
         set{ pRDC_Tec3_IsChanged = value; }
      }
      /// <summary>
      /// 收缩率
      /// </summary>
      private string pRDC_Tec4;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec4_IsChanged=false;
      /// <summary>
      /// 收缩率
      /// </summary>
      public string PRDC_Tec4
      {
         get{ return pRDC_Tec4; }
         set{ pRDC_Tec4 = value; pRDC_Tec4_IsChanged=true; }
      }
      /// <summary>
      /// 收缩率
      /// </summary>
      public bool PRDC_Tec4_IsChanged
      {
         get{ return pRDC_Tec4_IsChanged; }
         set{ pRDC_Tec4_IsChanged = value; }
      }
      /// <summary>
      /// 冲击功J
      /// </summary>
      private string pRDC_Tec5;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec5_IsChanged=false;
      /// <summary>
      /// 冲击功J
      /// </summary>
      public string PRDC_Tec5
      {
         get{ return pRDC_Tec5; }
         set{ pRDC_Tec5 = value; pRDC_Tec5_IsChanged=true; }
      }
      /// <summary>
      /// 冲击功J
      /// </summary>
      public bool PRDC_Tec5_IsChanged
      {
         get{ return pRDC_Tec5_IsChanged; }
         set{ pRDC_Tec5_IsChanged = value; }
      }
      /// <summary>
      /// PRDC_Tec6
      /// </summary>
      private string pRDC_Tec6;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec6_IsChanged=false;
      /// <summary>
      /// PRDC_Tec6
      /// </summary>
      public string PRDC_Tec6
      {
         get{ return pRDC_Tec6; }
         set{ pRDC_Tec6 = value; pRDC_Tec6_IsChanged=true; }
      }
      /// <summary>
      /// PRDC_Tec6
      /// </summary>
      public bool PRDC_Tec6_IsChanged
      {
         get{ return pRDC_Tec6_IsChanged; }
         set{ pRDC_Tec6_IsChanged = value; }
      }
      /// <summary>
      /// PRDC_Tec7
      /// </summary>
      private string pRDC_Tec7;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec7_IsChanged=false;
      /// <summary>
      /// PRDC_Tec7
      /// </summary>
      public string PRDC_Tec7
      {
         get{ return pRDC_Tec7; }
         set{ pRDC_Tec7 = value; pRDC_Tec7_IsChanged=true; }
      }
      /// <summary>
      /// PRDC_Tec7
      /// </summary>
      public bool PRDC_Tec7_IsChanged
      {
         get{ return pRDC_Tec7_IsChanged; }
         set{ pRDC_Tec7_IsChanged = value; }
      }
      /// <summary>
      /// PRDC_Tec8
      /// </summary>
      private string pRDC_Tec8;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec8_IsChanged=false;
      /// <summary>
      /// PRDC_Tec8
      /// </summary>
      public string PRDC_Tec8
      {
         get{ return pRDC_Tec8; }
         set{ pRDC_Tec8 = value; pRDC_Tec8_IsChanged=true; }
      }
      /// <summary>
      /// PRDC_Tec8
      /// </summary>
      public bool PRDC_Tec8_IsChanged
      {
         get{ return pRDC_Tec8_IsChanged; }
         set{ pRDC_Tec8_IsChanged = value; }
      }
      /// <summary>
      /// PRDC_Tec9
      /// </summary>
      private string pRDC_Tec9;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec9_IsChanged=false;
      /// <summary>
      /// PRDC_Tec9
      /// </summary>
      public string PRDC_Tec9
      {
         get{ return pRDC_Tec9; }
         set{ pRDC_Tec9 = value; pRDC_Tec9_IsChanged=true; }
      }
      /// <summary>
      /// PRDC_Tec9
      /// </summary>
      public bool PRDC_Tec9_IsChanged
      {
         get{ return pRDC_Tec9_IsChanged; }
         set{ pRDC_Tec9_IsChanged = value; }
      }
      /// <summary>
      /// PRDC_Tec10
      /// </summary>
      private string pRDC_Tec10;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_Tec10_IsChanged=false;
      /// <summary>
      /// PRDC_Tec10
      /// </summary>
      public string PRDC_Tec10
      {
         get{ return pRDC_Tec10; }
         set{ pRDC_Tec10 = value; pRDC_Tec10_IsChanged=true; }
      }
      /// <summary>
      /// PRDC_Tec10
      /// </summary>
      public bool PRDC_Tec10_IsChanged
      {
         get{ return pRDC_Tec10_IsChanged; }
         set{ pRDC_Tec10_IsChanged = value; }
      }
      /// <summary>
      /// 成品编号
      /// </summary>
      private string pRDC_ProdCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRDC_ProdCode_IsChanged=false;
      /// <summary>
      /// 成品编号
      /// </summary>
      public string PRDC_ProdCode
      {
         get{ return pRDC_ProdCode; }
         set{ pRDC_ProdCode = value; pRDC_ProdCode_IsChanged=true; }
      }
      /// <summary>
      /// 成品编号
      /// </summary>
      public bool PRDC_ProdCode_IsChanged
      {
         get{ return pRDC_ProdCode_IsChanged; }
         set{ pRDC_ProdCode_IsChanged = value; }
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
