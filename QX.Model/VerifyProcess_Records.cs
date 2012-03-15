using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   /// <summary>
   /// 审核流程记录表
   /// </summary>
   [Serializable]
   public partial class VerifyProcess_Records
   {
      /// <summary>
      /// 记录序号
      /// </summary>
      private decimal vRecord_ID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_ID_IsChanged=false;
      /// <summary>
      /// 记录序号
      /// </summary>
      public decimal VRecord_ID
      {
         get{ return vRecord_ID; }
         set{ vRecord_ID = value; vRecord_ID_IsChanged=true; }
      }
      /// <summary>
      /// 记录序号
      /// </summary>
      public bool VRecord_ID_IsChanged
      {
         get{ return vRecord_ID_IsChanged; }
         set{ vRecord_ID_IsChanged = value; }
      }
      private string vRecord_Code;
      private bool vRecord_Code_IsChanged=false;
      public string VRecord_Code
      {
         get{ return vRecord_Code; }
         set{ vRecord_Code = value; vRecord_Code_IsChanged=true; }
      }
      public bool VRecord_Code_IsChanged
      {
         get{ return vRecord_Code_IsChanged; }
         set{ vRecord_Code_IsChanged = value; }
      }
      /// <summary>
      /// 模块编码
      /// </summary>
      private string module_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool module_Code_IsChanged=false;
      /// <summary>
      /// 模块编码
      /// </summary>
      public string Module_Code
      {
         get{ return module_Code; }
         set{ module_Code = value; module_Code_IsChanged=true; }
      }
      /// <summary>
      /// 模块编码
      /// </summary>
      public bool Module_Code_IsChanged
      {
         get{ return module_Code_IsChanged; }
         set{ module_Code_IsChanged = value; }
      }
      /// <summary>
      /// 单据编码
      /// </summary>
      private string record_ID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool record_ID_IsChanged=false;
      /// <summary>
      /// 单据编码
      /// </summary>
      public string Record_ID
      {
         get{ return record_ID; }
         set{ record_ID = value; record_ID_IsChanged=true; }
      }
      /// <summary>
      /// 单据编码
      /// </summary>
      public bool Record_ID_IsChanged
      {
         get{ return record_ID_IsChanged; }
         set{ record_ID_IsChanged = value; }
      }
      /// <summary>
      /// 流程配置序号
      /// </summary>
      private string vRecord_VCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_VCode_IsChanged=false;
      /// <summary>
      /// 流程配置序号
      /// </summary>
      public string VRecord_VCode
      {
         get{ return vRecord_VCode; }
         set{ vRecord_VCode = value; vRecord_VCode_IsChanged=true; }
      }
      /// <summary>
      /// 流程配置序号
      /// </summary>
      public bool VRecord_VCode_IsChanged
      {
         get{ return vRecord_VCode_IsChanged; }
         set{ vRecord_VCode_IsChanged = value; }
      }
      /// <summary>
      /// 流程审理人
      /// </summary>
      private string vRecord_Owner;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_Owner_IsChanged=false;
      /// <summary>
      /// 流程审理人
      /// </summary>
      public string VRecord_Owner
      {
         get{ return vRecord_Owner; }
         set{ vRecord_Owner = value; vRecord_Owner_IsChanged=true; }
      }
      /// <summary>
      /// 流程审理人
      /// </summary>
      public bool VRecord_Owner_IsChanged
      {
         get{ return vRecord_Owner_IsChanged; }
         set{ vRecord_Owner_IsChanged = value; }
      }
      /// <summary>
      /// 审理时间
      /// </summary>
      private DateTime vRecord_Date;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_Date_IsChanged=false;
      /// <summary>
      /// 审理时间
      /// </summary>
      public DateTime VRecord_Date
      {
         get{ return vRecord_Date; }
         set{ vRecord_Date = value; vRecord_Date_IsChanged=true; }
      }
      /// <summary>
      /// 审理时间
      /// </summary>
      public bool VRecord_Date_IsChanged
      {
         get{ return vRecord_Date_IsChanged; }
         set{ vRecord_Date_IsChanged = value; }
      }
      /// <summary>
      /// 审理意见
      /// </summary>
      private string vRecord_Opinion;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_Opinion_IsChanged=false;
      /// <summary>
      /// 审理意见
      /// </summary>
      public string VRecord_Opinion
      {
         get{ return vRecord_Opinion; }
         set{ vRecord_Opinion = value; vRecord_Opinion_IsChanged=true; }
      }
      /// <summary>
      /// 审理意见
      /// </summary>
      public bool VRecord_Opinion_IsChanged
      {
         get{ return vRecord_Opinion_IsChanged; }
         set{ vRecord_Opinion_IsChanged = value; }
      }
      /// <summary>
      /// 审理结果标志
      /// </summary>
      private string vRecord_Flag;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_Flag_IsChanged=false;
      /// <summary>
      /// 审理结果标志
      /// </summary>
      public string VRecord_Flag
      {
         get{ return vRecord_Flag; }
         set{ vRecord_Flag = value; vRecord_Flag_IsChanged=true; }
      }
      /// <summary>
      /// 审理结果标志
      /// </summary>
      public bool VRecord_Flag_IsChanged
      {
         get{ return vRecord_Flag_IsChanged; }
         set{ vRecord_Flag_IsChanged = value; }
      }
      /// <summary>
      /// 用户自定义一
      /// </summary>
      private string vRecord_UDef1;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_UDef1_IsChanged=false;
      /// <summary>
      /// 用户自定义一
      /// </summary>
      public string VRecord_UDef1
      {
         get{ return vRecord_UDef1; }
         set{ vRecord_UDef1 = value; vRecord_UDef1_IsChanged=true; }
      }
      /// <summary>
      /// 用户自定义一
      /// </summary>
      public bool VRecord_UDef1_IsChanged
      {
         get{ return vRecord_UDef1_IsChanged; }
         set{ vRecord_UDef1_IsChanged = value; }
      }
      /// <summary>
      /// 用户自定义二
      /// </summary>
      private string vRecord_UDef2;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_UDef2_IsChanged=false;
      /// <summary>
      /// 用户自定义二
      /// </summary>
      public string VRecord_UDef2
      {
         get{ return vRecord_UDef2; }
         set{ vRecord_UDef2 = value; vRecord_UDef2_IsChanged=true; }
      }
      /// <summary>
      /// 用户自定义二
      /// </summary>
      public bool VRecord_UDef2_IsChanged
      {
         get{ return vRecord_UDef2_IsChanged; }
         set{ vRecord_UDef2_IsChanged = value; }
      }
      /// <summary>
      /// 用户自定义三
      /// </summary>
      private string vRecord_UDef3;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_UDef3_IsChanged=false;
      /// <summary>
      /// 用户自定义三
      /// </summary>
      public string VRecord_UDef3
      {
         get{ return vRecord_UDef3; }
         set{ vRecord_UDef3 = value; vRecord_UDef3_IsChanged=true; }
      }
      /// <summary>
      /// 用户自定义三
      /// </summary>
      public bool VRecord_UDef3_IsChanged
      {
         get{ return vRecord_UDef3_IsChanged; }
         set{ vRecord_UDef3_IsChanged = value; }
      }
      /// <summary>
      /// 用户自定义四
      /// </summary>
      private string vRecord_UDef4;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_UDef4_IsChanged=false;
      /// <summary>
      /// 用户自定义四
      /// </summary>
      public string VRecord_UDef4
      {
         get{ return vRecord_UDef4; }
         set{ vRecord_UDef4 = value; vRecord_UDef4_IsChanged=true; }
      }
      /// <summary>
      /// 用户自定义四
      /// </summary>
      public bool VRecord_UDef4_IsChanged
      {
         get{ return vRecord_UDef4_IsChanged; }
         set{ vRecord_UDef4_IsChanged = value; }
      }
      /// <summary>
      /// 用户自定义五
      /// </summary>
      private string vRecord_UDef5;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_UDef5_IsChanged=false;
      /// <summary>
      /// 用户自定义五
      /// </summary>
      public string VRecord_UDef5
      {
         get{ return vRecord_UDef5; }
         set{ vRecord_UDef5 = value; vRecord_UDef5_IsChanged=true; }
      }
      /// <summary>
      /// 用户自定义五
      /// </summary>
      public bool VRecord_UDef5_IsChanged
      {
         get{ return vRecord_UDef5_IsChanged; }
         set{ vRecord_UDef5_IsChanged = value; }
      }
      /// <summary>
      /// 用户自定义六
      /// </summary>
      private string vRecord_UDef6;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vRecord_UDef6_IsChanged=false;
      /// <summary>
      /// 用户自定义六
      /// </summary>
      public string VRecord_UDef6
      {
         get{ return vRecord_UDef6; }
         set{ vRecord_UDef6 = value; vRecord_UDef6_IsChanged=true; }
      }
      /// <summary>
      /// 用户自定义六
      /// </summary>
      public bool VRecord_UDef6_IsChanged
      {
         get{ return vRecord_UDef6_IsChanged; }
         set{ vRecord_UDef6_IsChanged = value; }
      }
      /// <summary>
      /// 数据状态
      /// </summary>
      private int stat;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool stat_IsChanged=false;
      /// <summary>
      /// 数据状态
      /// </summary>
      public int Stat
      {
         get{ return stat; }
         set{ stat = value; stat_IsChanged=true; }
      }
      /// <summary>
      /// 数据状态
      /// </summary>
      public bool Stat_IsChanged
      {
         get{ return stat_IsChanged; }
         set{ stat_IsChanged = value; }
      }
   }
}
