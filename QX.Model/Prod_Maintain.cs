using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Prod_Maintain
   {
      private decimal pRM_ID;
      private bool pRM_ID_IsChanged=false;
      public decimal PRM_ID
      {
         get{ return pRM_ID; }
         set{ pRM_ID = value; pRM_ID_IsChanged=true; }
      }
      public bool PRM_ID_IsChanged
      {
         get{ return pRM_ID_IsChanged; }
         set{ pRM_ID_IsChanged = value; }
      }
      /// <summary>
      /// 维修编码
      /// </summary>
      private string pRM_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRM_Code_IsChanged=false;
      /// <summary>
      /// 维修编码
      /// </summary>
      public string PRM_Code
      {
         get{ return pRM_Code; }
         set{ pRM_Code = value; pRM_Code_IsChanged=true; }
      }
      /// <summary>
      /// 维修编码
      /// </summary>
      public bool PRM_Code_IsChanged
      {
         get{ return pRM_Code_IsChanged; }
         set{ pRM_Code_IsChanged = value; }
      }
      /// <summary>
      /// 成品编号
      /// </summary>
      private string pRM_ProdCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRM_ProdCode_IsChanged=false;
      /// <summary>
      /// 成品编号
      /// </summary>
      public string PRM_ProdCode
      {
         get{ return pRM_ProdCode; }
         set{ pRM_ProdCode = value; pRM_ProdCode_IsChanged=true; }
      }
      /// <summary>
      /// 成品编号
      /// </summary>
      public bool PRM_ProdCode_IsChanged
      {
         get{ return pRM_ProdCode_IsChanged; }
         set{ pRM_ProdCode_IsChanged = value; }
      }
      private string pRM_Bak;
      private bool pRM_Bak_IsChanged=false;
      public string PRM_Bak
      {
         get{ return pRM_Bak; }
         set{ pRM_Bak = value; pRM_Bak_IsChanged=true; }
      }
      public bool PRM_Bak_IsChanged
      {
         get{ return pRM_Bak_IsChanged; }
         set{ pRM_Bak_IsChanged = value; }
      }
      private string pRM_Udef1;
      private bool pRM_Udef1_IsChanged=false;
      public string PRM_Udef1
      {
         get{ return pRM_Udef1; }
         set{ pRM_Udef1 = value; pRM_Udef1_IsChanged=true; }
      }
      public bool PRM_Udef1_IsChanged
      {
         get{ return pRM_Udef1_IsChanged; }
         set{ pRM_Udef1_IsChanged = value; }
      }
      private string pRM_Udef2;
      private bool pRM_Udef2_IsChanged=false;
      public string PRM_Udef2
      {
         get{ return pRM_Udef2; }
         set{ pRM_Udef2 = value; pRM_Udef2_IsChanged=true; }
      }
      public bool PRM_Udef2_IsChanged
      {
         get{ return pRM_Udef2_IsChanged; }
         set{ pRM_Udef2_IsChanged = value; }
      }
      private string pRM_Udef3;
      private bool pRM_Udef3_IsChanged=false;
      public string PRM_Udef3
      {
         get{ return pRM_Udef3; }
         set{ pRM_Udef3 = value; pRM_Udef3_IsChanged=true; }
      }
      public bool PRM_Udef3_IsChanged
      {
         get{ return pRM_Udef3_IsChanged; }
         set{ pRM_Udef3_IsChanged = value; }
      }
      private string pRM_Udef4;
      private bool pRM_Udef4_IsChanged=false;
      public string PRM_Udef4
      {
         get{ return pRM_Udef4; }
         set{ pRM_Udef4 = value; pRM_Udef4_IsChanged=true; }
      }
      public bool PRM_Udef4_IsChanged
      {
         get{ return pRM_Udef4_IsChanged; }
         set{ pRM_Udef4_IsChanged = value; }
      }
      private string pRM_Udef5;
      private bool pRM_Udef5_IsChanged=false;
      public string PRM_Udef5
      {
         get{ return pRM_Udef5; }
         set{ pRM_Udef5 = value; pRM_Udef5_IsChanged=true; }
      }
      public bool PRM_Udef5_IsChanged
      {
         get{ return pRM_Udef5_IsChanged; }
         set{ pRM_Udef5_IsChanged = value; }
      }
      /// <summary>
      /// 维修内部类型
      /// </summary>
      private string pRM_iType;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool pRM_iType_IsChanged=false;
      /// <summary>
      /// 维修内部类型
      /// </summary>
      public string PRM_iType
      {
         get{ return pRM_iType; }
         set{ pRM_iType = value; pRM_iType_IsChanged=true; }
      }
      /// <summary>
      /// 维修内部类型
      /// </summary>
      public bool PRM_iType_IsChanged
      {
         get{ return pRM_iType_IsChanged; }
         set{ pRM_iType_IsChanged = value; }
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
