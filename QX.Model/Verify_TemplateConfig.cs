using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   /// <summary>
   /// 审核模板配置表
   /// </summary>
   [Serializable]
   public partial class Verify_TemplateConfig
   {
      /// <summary>
      /// 模板序号
      /// </summary>
      private decimal vT_ID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vT_ID_IsChanged=false;
      /// <summary>
      /// 模板序号
      /// </summary>
      public decimal VT_ID
      {
         get{ return vT_ID; }
         set{ vT_ID = value; vT_ID_IsChanged=true; }
      }
      /// <summary>
      /// 模板序号
      /// </summary>
      public bool VT_ID_IsChanged
      {
         get{ return vT_ID_IsChanged; }
         set{ vT_ID_IsChanged = value; }
      }
      /// <summary>
      /// 模板阶段序号
      /// </summary>
      private string vT_Template_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vT_Template_Code_IsChanged=false;
      /// <summary>
      /// 模板阶段序号
      /// </summary>
      public string VT_Template_Code
      {
         get{ return vT_Template_Code; }
         set{ vT_Template_Code = value; vT_Template_Code_IsChanged=true; }
      }
      /// <summary>
      /// 模板阶段序号
      /// </summary>
      public bool VT_Template_Code_IsChanged
      {
         get{ return vT_Template_Code_IsChanged; }
         set{ vT_Template_Code_IsChanged = value; }
      }
      /// <summary>
      /// 模板关键字
      /// </summary>
      private string vT_Key;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vT_Key_IsChanged=false;
      /// <summary>
      /// 模板关键字
      /// </summary>
      public string VT_Key
      {
         get{ return vT_Key; }
         set{ vT_Key = value; vT_Key_IsChanged=true; }
      }
      /// <summary>
      /// 模板关键字
      /// </summary>
      public bool VT_Key_IsChanged
      {
         get{ return vT_Key_IsChanged; }
         set{ vT_Key_IsChanged = value; }
      }
      /// <summary>
      /// 阶段编码
      /// </summary>
      private string vT_VerifyNode_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vT_VerifyNode_Code_IsChanged=false;
      /// <summary>
      /// 阶段编码
      /// </summary>
      public string VT_VerifyNode_Code
      {
         get{ return vT_VerifyNode_Code; }
         set{ vT_VerifyNode_Code = value; vT_VerifyNode_Code_IsChanged=true; }
      }
      /// <summary>
      /// 阶段编码
      /// </summary>
      public bool VT_VerifyNode_Code_IsChanged
      {
         get{ return vT_VerifyNode_Code_IsChanged; }
         set{ vT_VerifyNode_Code_IsChanged = value; }
      }
      /// <summary>
      /// 阶段名称
      /// </summary>
      private string vT_VerifyNode_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vT_VerifyNode_Name_IsChanged=false;
      /// <summary>
      /// 阶段名称
      /// </summary>
      public string VT_VerifyNode_Name
      {
         get{ return vT_VerifyNode_Name; }
         set{ vT_VerifyNode_Name = value; vT_VerifyNode_Name_IsChanged=true; }
      }
      /// <summary>
      /// 阶段名称
      /// </summary>
      public bool VT_VerifyNode_Name_IsChanged
      {
         get{ return vT_VerifyNode_Name_IsChanged; }
         set{ vT_VerifyNode_Name_IsChanged = value; }
      }
      /// <summary>
      /// 类别标识
      /// </summary>
      private int flag;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool flag_IsChanged=false;
      /// <summary>
      /// 类别标识
      /// </summary>
      public int Flag
      {
         get{ return flag; }
         set{ flag = value; flag_IsChanged=true; }
      }
      /// <summary>
      /// 类别标识
      /// </summary>
      public bool Flag_IsChanged
      {
         get{ return flag_IsChanged; }
         set{ flag_IsChanged = value; }
      }
      /// <summary>
      /// 阶段顺序
      /// </summary>
      private int vT_VerifyNode_Order;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vT_VerifyNode_Order_IsChanged=false;
      /// <summary>
      /// 阶段顺序
      /// </summary>
      public int VT_VerifyNode_Order
      {
         get{ return vT_VerifyNode_Order; }
         set{ vT_VerifyNode_Order = value; vT_VerifyNode_Order_IsChanged=true; }
      }
      /// <summary>
      /// 阶段顺序
      /// </summary>
      public bool VT_VerifyNode_Order_IsChanged
      {
         get{ return vT_VerifyNode_Order_IsChanged; }
         set{ vT_VerifyNode_Order_IsChanged = value; }
      }
      /// <summary>
      /// 驳回节点
      /// </summary>
      private string vT_VerifyNode_Back;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vT_VerifyNode_Back_IsChanged=false;
      /// <summary>
      /// 驳回节点
      /// </summary>
      public string VT_VerifyNode_Back
      {
         get{ return vT_VerifyNode_Back; }
         set{ vT_VerifyNode_Back = value; vT_VerifyNode_Back_IsChanged=true; }
      }
      /// <summary>
      /// 驳回节点
      /// </summary>
      public bool VT_VerifyNode_Back_IsChanged
      {
         get{ return vT_VerifyNode_Back_IsChanged; }
         set{ vT_VerifyNode_Back_IsChanged = value; }
      }
      private string vT_VerifyNode_BackName;
      private bool vT_VerifyNode_BackName_IsChanged=false;
      public string VT_VerifyNode_BackName
      {
         get{ return vT_VerifyNode_BackName; }
         set{ vT_VerifyNode_BackName = value; vT_VerifyNode_BackName_IsChanged=true; }
      }
      public bool VT_VerifyNode_BackName_IsChanged
      {
         get{ return vT_VerifyNode_BackName_IsChanged; }
         set{ vT_VerifyNode_BackName_IsChanged = value; }
      }
      private string vT_Remark;
      private bool vT_Remark_IsChanged=false;
      public string VT_Remark
      {
         get{ return vT_Remark; }
         set{ vT_Remark = value; vT_Remark_IsChanged=true; }
      }
      public bool VT_Remark_IsChanged
      {
         get{ return vT_Remark_IsChanged; }
         set{ vT_Remark_IsChanged = value; }
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
      private decimal vT_AcSum;
      private bool vT_AcSum_IsChanged=false;
      public decimal VT_AcSum
      {
         get{ return vT_AcSum; }
         set{ vT_AcSum = value; vT_AcSum_IsChanged=true; }
      }
      public bool VT_AcSum_IsChanged
      {
         get{ return vT_AcSum_IsChanged; }
         set{ vT_AcSum_IsChanged = value; }
      }
      private string vT_AcNodeName;
      private bool vT_AcNodeName_IsChanged=false;
      public string VT_AcNodeName
      {
         get{ return vT_AcNodeName; }
         set{ vT_AcNodeName = value; vT_AcNodeName_IsChanged=true; }
      }
      public bool VT_AcNodeName_IsChanged
      {
         get{ return vT_AcNodeName_IsChanged; }
         set{ vT_AcNodeName_IsChanged = value; }
      }
      private string vT_AcNodeCode;
      private bool vT_AcNodeCode_IsChanged=false;
      public string VT_AcNodeCode
      {
         get{ return vT_AcNodeCode; }
         set{ vT_AcNodeCode = value; vT_AcNodeCode_IsChanged=true; }
      }
      public bool VT_AcNodeCode_IsChanged
      {
         get{ return vT_AcNodeCode_IsChanged; }
         set{ vT_AcNodeCode_IsChanged = value; }
      }
   }
}
