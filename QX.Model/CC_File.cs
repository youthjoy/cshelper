using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class CC_File
   {
      private decimal cCF_ID;
      private bool cCF_ID_IsChanged=false;
      public decimal CCF_ID
      {
         get{ return cCF_ID; }
         set{ cCF_ID = value; cCF_ID_IsChanged=true; }
      }
      public bool CCF_ID_IsChanged
      {
         get{ return cCF_ID_IsChanged; }
         set{ cCF_ID_IsChanged = value; }
      }
      /// <summary>
      /// 文档编号
      /// </summary>
      private string cCF_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_Code_IsChanged=false;
      /// <summary>
      /// 文档编号
      /// </summary>
      public string CCF_Code
      {
         get{ return cCF_Code; }
         set{ cCF_Code = value; cCF_Code_IsChanged=true; }
      }
      /// <summary>
      /// 文档编号
      /// </summary>
      public bool CCF_Code_IsChanged
      {
         get{ return cCF_Code_IsChanged; }
         set{ cCF_Code_IsChanged = value; }
      }
      private string cCF_DCode;
      private bool cCF_DCode_IsChanged=false;
      public string CCF_DCode
      {
         get{ return cCF_DCode; }
         set{ cCF_DCode = value; cCF_DCode_IsChanged=true; }
      }
      public bool CCF_DCode_IsChanged
      {
         get{ return cCF_DCode_IsChanged; }
         set{ cCF_DCode_IsChanged = value; }
      }
      private string cCF_CompNo;
      private bool cCF_CompNo_IsChanged=false;
      public string CCF_CompNo
      {
         get{ return cCF_CompNo; }
         set{ cCF_CompNo = value; cCF_CompNo_IsChanged=true; }
      }
      public bool CCF_CompNo_IsChanged
      {
         get{ return cCF_CompNo_IsChanged; }
         set{ cCF_CompNo_IsChanged = value; }
      }
      /// <summary>
      /// 文档名称
      /// </summary>
      private string cCF_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_Name_IsChanged=false;
      /// <summary>
      /// 文档名称
      /// </summary>
      public string CCF_Name
      {
         get{ return cCF_Name; }
         set{ cCF_Name = value; cCF_Name_IsChanged=true; }
      }
      /// <summary>
      /// 文档名称
      /// </summary>
      public bool CCF_Name_IsChanged
      {
         get{ return cCF_Name_IsChanged; }
         set{ cCF_Name_IsChanged = value; }
      }
      /// <summary>
      /// 文档内部类型
      /// </summary>
      private string cCF_iType;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_iType_IsChanged=false;
      /// <summary>
      /// 文档内部类型
      /// </summary>
      public string CCF_iType
      {
         get{ return cCF_iType; }
         set{ cCF_iType = value; cCF_iType_IsChanged=true; }
      }
      /// <summary>
      /// 文档内部类型
      /// </summary>
      public bool CCF_iType_IsChanged
      {
         get{ return cCF_iType_IsChanged; }
         set{ cCF_iType_IsChanged = value; }
      }
      /// <summary>
      /// 存储地址
      /// </summary>
      private string cCF_Directory;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_Directory_IsChanged=false;
      /// <summary>
      /// 存储地址
      /// </summary>
      public string CCF_Directory
      {
         get{ return cCF_Directory; }
         set{ cCF_Directory = value; cCF_Directory_IsChanged=true; }
      }
      /// <summary>
      /// 存储地址
      /// </summary>
      public bool CCF_Directory_IsChanged
      {
         get{ return cCF_Directory_IsChanged; }
         set{ cCF_Directory_IsChanged = value; }
      }
      /// <summary>
      /// 存储备注
      /// </summary>
      private string cCF_Bak;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_Bak_IsChanged=false;
      /// <summary>
      /// 存储备注
      /// </summary>
      public string CCF_Bak
      {
         get{ return cCF_Bak; }
         set{ cCF_Bak = value; cCF_Bak_IsChanged=true; }
      }
      /// <summary>
      /// 存储备注
      /// </summary>
      public bool CCF_Bak_IsChanged
      {
         get{ return cCF_Bak_IsChanged; }
         set{ cCF_Bak_IsChanged = value; }
      }
      /// <summary>
      /// 下载次数
      /// </summary>
      private string cCF_DownTime;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_DownTime_IsChanged=false;
      /// <summary>
      /// 下载次数
      /// </summary>
      public string CCF_DownTime
      {
         get{ return cCF_DownTime; }
         set{ cCF_DownTime = value; cCF_DownTime_IsChanged=true; }
      }
      /// <summary>
      /// 下载次数
      /// </summary>
      public bool CCF_DownTime_IsChanged
      {
         get{ return cCF_DownTime_IsChanged; }
         set{ cCF_DownTime_IsChanged = value; }
      }
      /// <summary>
      /// 转储次数
      /// </summary>
      private int cCF_RCount;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_RCount_IsChanged=false;
      /// <summary>
      /// 转储次数
      /// </summary>
      public int CCF_RCount
      {
         get{ return cCF_RCount; }
         set{ cCF_RCount = value; cCF_RCount_IsChanged=true; }
      }
      /// <summary>
      /// 转储次数
      /// </summary>
      public bool CCF_RCount_IsChanged
      {
         get{ return cCF_RCount_IsChanged; }
         set{ cCF_RCount_IsChanged = value; }
      }
      /// <summary>
      /// 转储位置
      /// </summary>
      private string cCF_RDirectory;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_RDirectory_IsChanged=false;
      /// <summary>
      /// 转储位置
      /// </summary>
      public string CCF_RDirectory
      {
         get{ return cCF_RDirectory; }
         set{ cCF_RDirectory = value; cCF_RDirectory_IsChanged=true; }
      }
      /// <summary>
      /// 转储位置
      /// </summary>
      public bool CCF_RDirectory_IsChanged
      {
         get{ return cCF_RDirectory_IsChanged; }
         set{ cCF_RDirectory_IsChanged = value; }
      }
      /// <summary>
      /// 转储人
      /// </summary>
      private string cCF_ROwner;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_ROwner_IsChanged=false;
      /// <summary>
      /// 转储人
      /// </summary>
      public string CCF_ROwner
      {
         get{ return cCF_ROwner; }
         set{ cCF_ROwner = value; cCF_ROwner_IsChanged=true; }
      }
      /// <summary>
      /// 转储人
      /// </summary>
      public bool CCF_ROwner_IsChanged
      {
         get{ return cCF_ROwner_IsChanged; }
         set{ cCF_ROwner_IsChanged = value; }
      }
      /// <summary>
      /// 转储时间
      /// </summary>
      private DateTime cCF_RDate;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_RDate_IsChanged=false;
      /// <summary>
      /// 转储时间
      /// </summary>
      public DateTime CCF_RDate
      {
         get{ return cCF_RDate; }
         set{ cCF_RDate = value; cCF_RDate_IsChanged=true; }
      }
      /// <summary>
      /// 转储时间
      /// </summary>
      public bool CCF_RDate_IsChanged
      {
         get{ return cCF_RDate_IsChanged; }
         set{ cCF_RDate_IsChanged = value; }
      }
      /// <summary>
      /// 转储备注
      /// </summary>
      private string cCF_RBak;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool cCF_RBak_IsChanged=false;
      /// <summary>
      /// 转储备注
      /// </summary>
      public string CCF_RBak
      {
         get{ return cCF_RBak; }
         set{ cCF_RBak = value; cCF_RBak_IsChanged=true; }
      }
      /// <summary>
      /// 转储备注
      /// </summary>
      public bool CCF_RBak_IsChanged
      {
         get{ return cCF_RBak_IsChanged; }
         set{ cCF_RBak_IsChanged = value; }
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
