using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   /// <summary>
   /// 审核阶段用户
   /// </summary>
   [Serializable]
   public partial class Verify_Users
   {
      /// <summary>
      /// 审核用户序号
      /// </summary>
      private decimal vU_ID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vU_ID_IsChanged=false;
      /// <summary>
      /// 审核用户序号
      /// </summary>
      public decimal VU_ID
      {
         get{ return vU_ID; }
         set{ vU_ID = value; vU_ID_IsChanged=true; }
      }
      /// <summary>
      /// 审核用户序号
      /// </summary>
      public bool VU_ID_IsChanged
      {
         get{ return vU_ID_IsChanged; }
         set{ vU_ID_IsChanged = value; }
      }
      /// <summary>
      /// 阶段编码
      /// </summary>
      private string vU_VerifyNode_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vU_VerifyNode_Code_IsChanged=false;
      /// <summary>
      /// 阶段编码
      /// </summary>
      public string VU_VerifyNode_Code
      {
         get{ return vU_VerifyNode_Code; }
         set{ vU_VerifyNode_Code = value; vU_VerifyNode_Code_IsChanged=true; }
      }
      /// <summary>
      /// 阶段编码
      /// </summary>
      public bool VU_VerifyNode_Code_IsChanged
      {
         get{ return vU_VerifyNode_Code_IsChanged; }
         set{ vU_VerifyNode_Code_IsChanged = value; }
      }
      /// <summary>
      /// 用户
      /// </summary>
      private string vU_User;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vU_User_IsChanged=false;
      /// <summary>
      /// 用户
      /// </summary>
      public string VU_User
      {
         get{ return vU_User; }
         set{ vU_User = value; vU_User_IsChanged=true; }
      }
      /// <summary>
      /// 用户
      /// </summary>
      public bool VU_User_IsChanged
      {
         get{ return vU_User_IsChanged; }
         set{ vU_User_IsChanged = value; }
      }
      private string vU_UserName;
      private bool vU_UserName_IsChanged=false;
      public string VU_UserName
      {
         get{ return vU_UserName; }
         set{ vU_UserName = value; vU_UserName_IsChanged=true; }
      }
      public bool VU_UserName_IsChanged
      {
         get{ return vU_UserName_IsChanged; }
         set{ vU_UserName_IsChanged = value; }
      }
      /// <summary>
      /// 部门
      /// </summary>
      private string vU_Dept;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vU_Dept_IsChanged=false;
      /// <summary>
      /// 部门
      /// </summary>
      public string VU_Dept
      {
         get{ return vU_Dept; }
         set{ vU_Dept = value; vU_Dept_IsChanged=true; }
      }
      /// <summary>
      /// 部门
      /// </summary>
      public bool VU_Dept_IsChanged
      {
         get{ return vU_Dept_IsChanged; }
         set{ vU_Dept_IsChanged = value; }
      }
      private string vU_DeptName;
      private bool vU_DeptName_IsChanged=false;
      public string VU_DeptName
      {
         get{ return vU_DeptName; }
         set{ vU_DeptName = value; vU_DeptName_IsChanged=true; }
      }
      public bool VU_DeptName_IsChanged
      {
         get{ return vU_DeptName_IsChanged; }
         set{ vU_DeptName_IsChanged = value; }
      }
      /// <summary>
      /// 职务
      /// </summary>
      private string vU_Duty;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vU_Duty_IsChanged=false;
      /// <summary>
      /// 职务
      /// </summary>
      public string VU_Duty
      {
         get{ return vU_Duty; }
         set{ vU_Duty = value; vU_Duty_IsChanged=true; }
      }
      /// <summary>
      /// 职务
      /// </summary>
      public bool VU_Duty_IsChanged
      {
         get{ return vU_Duty_IsChanged; }
         set{ vU_Duty_IsChanged = value; }
      }
      /// <summary>
      /// 模板编码
      /// </summary>
      private string vU_VerifyTempldate_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool vU_VerifyTempldate_Code_IsChanged=false;
      /// <summary>
      /// 模板编码
      /// </summary>
      public string VU_VerifyTempldate_Code
      {
         get{ return vU_VerifyTempldate_Code; }
         set{ vU_VerifyTempldate_Code = value; vU_VerifyTempldate_Code_IsChanged=true; }
      }
      /// <summary>
      /// 模板编码
      /// </summary>
      public bool VU_VerifyTempldate_Code_IsChanged
      {
         get{ return vU_VerifyTempldate_Code_IsChanged; }
         set{ vU_VerifyTempldate_Code_IsChanged = value; }
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
