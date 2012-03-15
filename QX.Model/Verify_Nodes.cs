using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   /// <summary>
   /// 审核阶段信息
   /// </summary>
   [Serializable]
   public partial class Verify_Nodes
   {
      /// <summary>
      /// 审核阶段序号
      /// </summary>
      private decimal verifyNode_ID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool verifyNode_ID_IsChanged=false;
      /// <summary>
      /// 审核阶段序号
      /// </summary>
      public decimal VerifyNode_ID
      {
         get{ return verifyNode_ID; }
         set{ verifyNode_ID = value; verifyNode_ID_IsChanged=true; }
      }
      /// <summary>
      /// 审核阶段序号
      /// </summary>
      public bool VerifyNode_ID_IsChanged
      {
         get{ return verifyNode_ID_IsChanged; }
         set{ verifyNode_ID_IsChanged = value; }
      }
      /// <summary>
      /// 阶段编码
      /// </summary>
      private string verifyNode_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool verifyNode_Code_IsChanged=false;
      /// <summary>
      /// 阶段编码
      /// </summary>
      public string VerifyNode_Code
      {
         get{ return verifyNode_Code; }
         set{ verifyNode_Code = value; verifyNode_Code_IsChanged=true; }
      }
      /// <summary>
      /// 阶段编码
      /// </summary>
      public bool VerifyNode_Code_IsChanged
      {
         get{ return verifyNode_Code_IsChanged; }
         set{ verifyNode_Code_IsChanged = value; }
      }
      /// <summary>
      /// 阶段名称
      /// </summary>
      private string verifyNode_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool verifyNode_Name_IsChanged=false;
      /// <summary>
      /// 阶段名称
      /// </summary>
      public string VerifyNode_Name
      {
         get{ return verifyNode_Name; }
         set{ verifyNode_Name = value; verifyNode_Name_IsChanged=true; }
      }
      /// <summary>
      /// 阶段名称
      /// </summary>
      public bool VerifyNode_Name_IsChanged
      {
         get{ return verifyNode_Name_IsChanged; }
         set{ verifyNode_Name_IsChanged = value; }
      }
      /// <summary>
      /// 阶段描述
      /// </summary>
      private string verifyNode_Remark;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool verifyNode_Remark_IsChanged=false;
      /// <summary>
      /// 阶段描述
      /// </summary>
      public string VerifyNode_Remark
      {
         get{ return verifyNode_Remark; }
         set{ verifyNode_Remark = value; verifyNode_Remark_IsChanged=true; }
      }
      /// <summary>
      /// 阶段描述
      /// </summary>
      public bool VerifyNode_Remark_IsChanged
      {
         get{ return verifyNode_Remark_IsChanged; }
         set{ verifyNode_Remark_IsChanged = value; }
      }
      /// <summary>
      /// 需要审批的人数
      /// </summary>
      private int verifyNode_AuditNum;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool verifyNode_AuditNum_IsChanged=false;
      /// <summary>
      /// 需要审批的人数
      /// </summary>
      public int VerifyNode_AuditNum
      {
         get{ return verifyNode_AuditNum; }
         set{ verifyNode_AuditNum = value; verifyNode_AuditNum_IsChanged=true; }
      }
      /// <summary>
      /// 需要审批的人数
      /// </summary>
      public bool VerifyNode_AuditNum_IsChanged
      {
         get{ return verifyNode_AuditNum_IsChanged; }
         set{ verifyNode_AuditNum_IsChanged = value; }
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
