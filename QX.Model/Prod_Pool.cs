using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Prod_Pool
   {
      private decimal pRP_ID;
      private bool pRP_ID_IsChanged=false;
      public decimal PRP_ID
      {
         get{ return pRP_ID; }
         set{ pRP_ID = value; pRP_ID_IsChanged=true; }
      }
      public bool PRP_ID_IsChanged
      {
         get{ return pRP_ID_IsChanged; }
         set{ pRP_ID_IsChanged = value; }
      }
      /// <summary>
      /// 成品编号
      /// </summary>
      private string pRP_ProdCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_ProdCode_IsChanged=false;
      /// <summary>
      /// 成品编号
      /// </summary>
      public string PRP_ProdCode
      {
         get{ return pRP_ProdCode; }
         set{ pRP_ProdCode = value; pRP_ProdCode_IsChanged=true; }
      }
      /// <summary>
      /// 成品编号
      /// </summary>
      public bool PRP_ProdCode_IsChanged
      {
         get{ return pRP_ProdCode_IsChanged; }
         set{ pRP_ProdCode_IsChanged = value; }
      }
      /// <summary>
      /// 成品类型
      /// </summary>
      private string pRP_Type;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_Type_IsChanged=false;
      /// <summary>
      /// 成品类型
      /// </summary>
      public string PRP_Type
      {
         get{ return pRP_Type; }
         set{ pRP_Type = value; pRP_Type_IsChanged=true; }
      }
      /// <summary>
      /// 成品类型
      /// </summary>
      public bool PRP_Type_IsChanged
      {
         get{ return pRP_Type_IsChanged; }
         set{ pRP_Type_IsChanged = value; }
      }
      /// <summary>
      /// 成品名称
      /// </summary>
      private string pRP_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_Name_IsChanged=false;
      /// <summary>
      /// 成品名称
      /// </summary>
      public string PRP_Name
      {
         get{ return pRP_Name; }
         set{ pRP_Name = value; pRP_Name_IsChanged=true; }
      }
      /// <summary>
      /// 成品名称
      /// </summary>
      public bool PRP_Name_IsChanged
      {
         get{ return pRP_Name_IsChanged; }
         set{ pRP_Name_IsChanged = value; }
      }
      /// <summary>
      /// 成品内部类型
      /// </summary>
      private string pRP_iType;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_iType_IsChanged=false;
      /// <summary>
      /// 成品内部类型
      /// </summary>
      public string PRP_iType
      {
         get{ return pRP_iType; }
         set{ pRP_iType = value; pRP_iType_IsChanged=true; }
      }
      /// <summary>
      /// 成品内部类型
      /// </summary>
      public bool PRP_iType_IsChanged
      {
         get{ return pRP_iType_IsChanged; }
         set{ pRP_iType_IsChanged = value; }
      }
      /// <summary>
      /// 入库人
      /// </summary>
      private string pRP_IOwner;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_IOwner_IsChanged=false;
      /// <summary>
      /// 入库人
      /// </summary>
      public string PRP_IOwner
      {
         get{ return pRP_IOwner; }
         set{ pRP_IOwner = value; pRP_IOwner_IsChanged=true; }
      }
      /// <summary>
      /// 入库人
      /// </summary>
      public bool PRP_IOwner_IsChanged
      {
         get{ return pRP_IOwner_IsChanged; }
         set{ pRP_IOwner_IsChanged = value; }
      }
      /// <summary>
      /// 入库时间
      /// </summary>
      private DateTime pRP_IDate;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_IDate_IsChanged=false;
      /// <summary>
      /// 入库时间
      /// </summary>
      public DateTime PRP_IDate
      {
         get{ return pRP_IDate; }
         set{ pRP_IDate = value; pRP_IDate_IsChanged=true; }
      }
      /// <summary>
      /// 入库时间
      /// </summary>
      public bool PRP_IDate_IsChanged
      {
         get{ return pRP_IDate_IsChanged; }
         set{ pRP_IDate_IsChanged = value; }
      }
      /// <summary>
      /// 入库备注
      /// </summary>
      private string pRP_IBak;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_IBak_IsChanged=false;
      /// <summary>
      /// 入库备注
      /// </summary>
      public string PRP_IBak
      {
         get{ return pRP_IBak; }
         set{ pRP_IBak = value; pRP_IBak_IsChanged=true; }
      }
      /// <summary>
      /// 入库备注
      /// </summary>
      public bool PRP_IBak_IsChanged
      {
         get{ return pRP_IBak_IsChanged; }
         set{ pRP_IBak_IsChanged = value; }
      }
      /// <summary>
      /// 出库人
      /// </summary>
      private string pRP_OOwner;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_OOwner_IsChanged=false;
      /// <summary>
      /// 出库人
      /// </summary>
      public string PRP_OOwner
      {
         get{ return pRP_OOwner; }
         set{ pRP_OOwner = value; pRP_OOwner_IsChanged=true; }
      }
      /// <summary>
      /// 出库人
      /// </summary>
      public bool PRP_OOwner_IsChanged
      {
         get{ return pRP_OOwner_IsChanged; }
         set{ pRP_OOwner_IsChanged = value; }
      }
      /// <summary>
      /// 出库客户
      /// </summary>
      private string pRP_OCust;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_OCust_IsChanged=false;
      /// <summary>
      /// 出库客户
      /// </summary>
      public string PRP_OCust
      {
         get{ return pRP_OCust; }
         set{ pRP_OCust = value; pRP_OCust_IsChanged=true; }
      }
      /// <summary>
      /// 出库客户
      /// </summary>
      public bool PRP_OCust_IsChanged
      {
         get{ return pRP_OCust_IsChanged; }
         set{ pRP_OCust_IsChanged = value; }
      }
      /// <summary>
      /// 出库时间
      /// </summary>
      private DateTime pRP_ODate;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_ODate_IsChanged=false;
      /// <summary>
      /// 出库时间
      /// </summary>
      public DateTime PRP_ODate
      {
         get{ return pRP_ODate; }
         set{ pRP_ODate = value; pRP_ODate_IsChanged=true; }
      }
      /// <summary>
      /// 出库时间
      /// </summary>
      public bool PRP_ODate_IsChanged
      {
         get{ return pRP_ODate_IsChanged; }
         set{ pRP_ODate_IsChanged = value; }
      }
      /// <summary>
      /// 出库终端客户
      /// </summary>
      private string pRP_OCust1;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_OCust1_IsChanged=false;
      /// <summary>
      /// 出库终端客户
      /// </summary>
      public string PRP_OCust1
      {
         get{ return pRP_OCust1; }
         set{ pRP_OCust1 = value; pRP_OCust1_IsChanged=true; }
      }
      /// <summary>
      /// 出库终端客户
      /// </summary>
      public bool PRP_OCust1_IsChanged
      {
         get{ return pRP_OCust1_IsChanged; }
         set{ pRP_OCust1_IsChanged = value; }
      }
      /// <summary>
      /// 出库备注
      /// </summary>
      private string pRP_OBak;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRP_OBak_IsChanged=false;
      /// <summary>
      /// 出库备注
      /// </summary>
      public string PRP_OBak
      {
         get{ return pRP_OBak; }
         set{ pRP_OBak = value; pRP_OBak_IsChanged=true; }
      }
      /// <summary>
      /// 出库备注
      /// </summary>
      public bool PRP_OBak_IsChanged
      {
         get{ return pRP_OBak_IsChanged; }
         set{ pRP_OBak_IsChanged = value; }
      }
      private int pRP_IsChange;
      private bool pRP_IsChange_IsChanged=false;
      public int PRP_IsChange
      {
         get{ return pRP_IsChange; }
         set{ pRP_IsChange = value; pRP_IsChange_IsChanged=true; }
      }
      public bool PRP_IsChange_IsChanged
      {
         get{ return pRP_IsChange_IsChanged; }
         set{ pRP_IsChange_IsChanged = value; }
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
      private string creator;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool creator_IsChanged=false;
      /// <summary>
      /// 录入人
      /// </summary>
      public string Creator
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
      private string pRP_Udef1;
      private bool pRP_Udef1_IsChanged=false;
      public string PRP_Udef1
      {
         get{ return pRP_Udef1; }
         set{ pRP_Udef1 = value; pRP_Udef1_IsChanged=true; }
      }
      public bool PRP_Udef1_IsChanged
      {
         get{ return pRP_Udef1_IsChanged; }
         set{ pRP_Udef1_IsChanged = value; }
      }
      private string pRP_Udef2;
      private bool pRP_Udef2_IsChanged=false;
      public string PRP_Udef2
      {
         get{ return pRP_Udef2; }
         set{ pRP_Udef2 = value; pRP_Udef2_IsChanged=true; }
      }
      public bool PRP_Udef2_IsChanged
      {
         get{ return pRP_Udef2_IsChanged; }
         set{ pRP_Udef2_IsChanged = value; }
      }
      private string pRP_Udef3;
      private bool pRP_Udef3_IsChanged=false;
      public string PRP_Udef3
      {
         get{ return pRP_Udef3; }
         set{ pRP_Udef3 = value; pRP_Udef3_IsChanged=true; }
      }
      public bool PRP_Udef3_IsChanged
      {
         get{ return pRP_Udef3_IsChanged; }
         set{ pRP_Udef3_IsChanged = value; }
      }
   }
}
