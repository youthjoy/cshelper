using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Tpl_Components
   {
      private decimal tPLC_ID;
      private bool tPLC_ID_IsChanged=false;
      public decimal TPLC_ID
      {
         get{ return tPLC_ID; }
         set{ tPLC_ID = value; tPLC_ID_IsChanged=true; }
      }
      public bool TPLC_ID_IsChanged
      {
         get{ return tPLC_ID_IsChanged; }
         set{ tPLC_ID_IsChanged = value; }
      }
      /// <summary>
      /// 零件图号
      /// </summary>
      private string tPLC_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPLC_Code_IsChanged=false;
      /// <summary>
      /// 零件图号
      /// </summary>
      public string TPLC_Code
      {
         get{ return tPLC_Code; }
         set{ tPLC_Code = value; tPLC_Code_IsChanged=true; }
      }
      /// <summary>
      /// 零件图号
      /// </summary>
      public bool TPLC_Code_IsChanged
      {
         get{ return tPLC_Code_IsChanged; }
         set{ tPLC_Code_IsChanged = value; }
      }
      /// <summary>
      /// 零件名称
      /// </summary>
      private string tPLC_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPLC_Name_IsChanged=false;
      /// <summary>
      /// 零件名称
      /// </summary>
      public string TPLC_Name
      {
         get{ return tPLC_Name; }
         set{ tPLC_Name = value; tPLC_Name_IsChanged=true; }
      }
      /// <summary>
      /// 零件名称
      /// </summary>
      public bool TPLC_Name_IsChanged
      {
         get{ return tPLC_Name_IsChanged; }
         set{ tPLC_Name_IsChanged = value; }
      }
      /// <summary>
      /// 零件类型
      /// </summary>
      private string tPLC_Cat;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPLC_Cat_IsChanged=false;
      /// <summary>
      /// 零件类型
      /// </summary>
      public string TPLC_Cat
      {
         get{ return tPLC_Cat; }
         set{ tPLC_Cat = value; tPLC_Cat_IsChanged=true; }
      }
      /// <summary>
      /// 零件类型
      /// </summary>
      public bool TPLC_Cat_IsChanged
      {
         get{ return tPLC_Cat_IsChanged; }
         set{ tPLC_Cat_IsChanged = value; }
      }
      /// <summary>
      /// 技术参数
      /// </summary>
      private string tPLC_Tec;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPLC_Tec_IsChanged=false;
      /// <summary>
      /// 技术参数
      /// </summary>
      public string TPLC_Tec
      {
         get{ return tPLC_Tec; }
         set{ tPLC_Tec = value; tPLC_Tec_IsChanged=true; }
      }
      /// <summary>
      /// 技术参数
      /// </summary>
      public bool TPLC_Tec_IsChanged
      {
         get{ return tPLC_Tec_IsChanged; }
         set{ tPLC_Tec_IsChanged = value; }
      }
      /// <summary>
      /// 材质
      /// </summary>
      private string tPLC_Raw;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPLC_Raw_IsChanged=false;
      /// <summary>
      /// 材质
      /// </summary>
      public string TPLC_Raw
      {
         get{ return tPLC_Raw; }
         set{ tPLC_Raw = value; tPLC_Raw_IsChanged=true; }
      }
      /// <summary>
      /// 材质
      /// </summary>
      public bool TPLC_Raw_IsChanged
      {
         get{ return tPLC_Raw_IsChanged; }
         set{ tPLC_Raw_IsChanged = value; }
      }
      /// <summary>
      /// 默认加工厂家
      /// </summary>
      private string tPLC_Plant;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPLC_Plant_IsChanged=false;
      /// <summary>
      /// 默认加工厂家
      /// </summary>
      public string TPLC_Plant
      {
         get{ return tPLC_Plant; }
         set{ tPLC_Plant = value; tPLC_Plant_IsChanged=true; }
      }
      /// <summary>
      /// 默认加工厂家
      /// </summary>
      public bool TPLC_Plant_IsChanged
      {
         get{ return tPLC_Plant_IsChanged; }
         set{ tPLC_Plant_IsChanged = value; }
      }
      /// <summary>
      /// 内部类型
      /// </summary>
      private string tPLC_iType;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool tPLC_iType_IsChanged=false;
      /// <summary>
      /// 内部类型
      /// </summary>
      public string TPLC_iType
      {
         get{ return tPLC_iType; }
         set{ tPLC_iType = value; tPLC_iType_IsChanged=true; }
      }
      /// <summary>
      /// 内部类型
      /// </summary>
      public bool TPLC_iType_IsChanged
      {
         get{ return tPLC_iType_IsChanged; }
         set{ tPLC_iType_IsChanged = value; }
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
   }
}
