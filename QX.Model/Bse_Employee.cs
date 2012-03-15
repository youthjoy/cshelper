using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Bse_Employee
   {
      /// <summary>
      /// 员工序号
      /// </summary>
      private Int64 emp_ID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_ID_IsChanged=false;
      /// <summary>
      /// 员工序号
      /// </summary>
      public Int64 Emp_ID
      {
         get{ return emp_ID; }
         set{ emp_ID = value; emp_ID_IsChanged=true; }
      }
      /// <summary>
      /// 员工序号
      /// </summary>
      public bool Emp_ID_IsChanged
      {
         get{ return emp_ID_IsChanged; }
         set{ emp_ID_IsChanged = value; }
      }
      /// <summary>
      /// 员工号
      /// </summary>
      private string emp_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Code_IsChanged=false;
      /// <summary>
      /// 员工号
      /// </summary>
      public string Emp_Code
      {
         get{ return emp_Code; }
         set{ emp_Code = value; emp_Code_IsChanged=true; }
      }
      /// <summary>
      /// 员工号
      /// </summary>
      public bool Emp_Code_IsChanged
      {
         get{ return emp_Code_IsChanged; }
         set{ emp_Code_IsChanged = value; }
      }
      /// <summary>
      /// 员工姓名
      /// </summary>
      private string emp_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Name_IsChanged=false;
      /// <summary>
      /// 员工姓名
      /// </summary>
      public string Emp_Name
      {
         get{ return emp_Name; }
         set{ emp_Name = value; emp_Name_IsChanged=true; }
      }
      /// <summary>
      /// 员工姓名
      /// </summary>
      public bool Emp_Name_IsChanged
      {
         get{ return emp_Name_IsChanged; }
         set{ emp_Name_IsChanged = value; }
      }
      /// <summary>
      /// 性别
      /// </summary>
      private string emp_Gendar;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Gendar_IsChanged=false;
      /// <summary>
      /// 性别
      /// </summary>
      public string Emp_Gendar
      {
         get{ return emp_Gendar; }
         set{ emp_Gendar = value; emp_Gendar_IsChanged=true; }
      }
      /// <summary>
      /// 性别
      /// </summary>
      public bool Emp_Gendar_IsChanged
      {
         get{ return emp_Gendar_IsChanged; }
         set{ emp_Gendar_IsChanged = value; }
      }
      /// <summary>
      /// 所属部门编码
      /// </summary>
      private string emp_Dept_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Dept_Code_IsChanged=false;
      /// <summary>
      /// 所属部门编码
      /// </summary>
      public string Emp_Dept_Code
      {
         get{ return emp_Dept_Code; }
         set{ emp_Dept_Code = value; emp_Dept_Code_IsChanged=true; }
      }
      /// <summary>
      /// 所属部门编码
      /// </summary>
      public bool Emp_Dept_Code_IsChanged
      {
         get{ return emp_Dept_Code_IsChanged; }
         set{ emp_Dept_Code_IsChanged = value; }
      }
      /// <summary>
      /// 所属部门名称
      /// </summary>
      private string emp_Dept_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Dept_Name_IsChanged=false;
      /// <summary>
      /// 所属部门名称
      /// </summary>
      public string Emp_Dept_Name
      {
         get{ return emp_Dept_Name; }
         set{ emp_Dept_Name = value; emp_Dept_Name_IsChanged=true; }
      }
      /// <summary>
      /// 所属部门名称
      /// </summary>
      public bool Emp_Dept_Name_IsChanged
      {
         get{ return emp_Dept_Name_IsChanged; }
         set{ emp_Dept_Name_IsChanged = value; }
      }
      /// <summary>
      /// 职称名称
      /// </summary>
      private string emp_TitleName;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_TitleName_IsChanged=false;
      /// <summary>
      /// 职称名称
      /// </summary>
      public string Emp_TitleName
      {
         get{ return emp_TitleName; }
         set{ emp_TitleName = value; emp_TitleName_IsChanged=true; }
      }
      /// <summary>
      /// 职称名称
      /// </summary>
      public bool Emp_TitleName_IsChanged
      {
         get{ return emp_TitleName_IsChanged; }
         set{ emp_TitleName_IsChanged = value; }
      }
      /// <summary>
      /// 职称
      /// </summary>
      private string emp_Title;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Title_IsChanged=false;
      /// <summary>
      /// 职称
      /// </summary>
      public string Emp_Title
      {
         get{ return emp_Title; }
         set{ emp_Title = value; emp_Title_IsChanged=true; }
      }
      /// <summary>
      /// 职称
      /// </summary>
      public bool Emp_Title_IsChanged
      {
         get{ return emp_Title_IsChanged; }
         set{ emp_Title_IsChanged = value; }
      }
      /// <summary>
      /// 职务名称
      /// </summary>
      private string emp_DutyName;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_DutyName_IsChanged=false;
      /// <summary>
      /// 职务名称
      /// </summary>
      public string Emp_DutyName
      {
         get{ return emp_DutyName; }
         set{ emp_DutyName = value; emp_DutyName_IsChanged=true; }
      }
      /// <summary>
      /// 职务名称
      /// </summary>
      public bool Emp_DutyName_IsChanged
      {
         get{ return emp_DutyName_IsChanged; }
         set{ emp_DutyName_IsChanged = value; }
      }
      /// <summary>
      /// 职务
      /// </summary>
      private string emp_Duty;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Duty_IsChanged=false;
      /// <summary>
      /// 职务
      /// </summary>
      public string Emp_Duty
      {
         get{ return emp_Duty; }
         set{ emp_Duty = value; emp_Duty_IsChanged=true; }
      }
      /// <summary>
      /// 职务
      /// </summary>
      public bool Emp_Duty_IsChanged
      {
         get{ return emp_Duty_IsChanged; }
         set{ emp_Duty_IsChanged = value; }
      }
      /// <summary>
      /// 出生日期
      /// </summary>
      private string emp_Birth;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Birth_IsChanged=false;
      /// <summary>
      /// 出生日期
      /// </summary>
      public string Emp_Birth
      {
         get{ return emp_Birth; }
         set{ emp_Birth = value; emp_Birth_IsChanged=true; }
      }
      /// <summary>
      /// 出生日期
      /// </summary>
      public bool Emp_Birth_IsChanged
      {
         get{ return emp_Birth_IsChanged; }
         set{ emp_Birth_IsChanged = value; }
      }
      /// <summary>
      /// 进厂日期
      /// </summary>
      private string emp_StartDate;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_StartDate_IsChanged=false;
      /// <summary>
      /// 进厂日期
      /// </summary>
      public string Emp_StartDate
      {
         get{ return emp_StartDate; }
         set{ emp_StartDate = value; emp_StartDate_IsChanged=true; }
      }
      /// <summary>
      /// 进厂日期
      /// </summary>
      public bool Emp_StartDate_IsChanged
      {
         get{ return emp_StartDate_IsChanged; }
         set{ emp_StartDate_IsChanged = value; }
      }
      /// <summary>
      /// 备注
      /// </summary>
      private string emp_Bak;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Bak_IsChanged=false;
      /// <summary>
      /// 备注
      /// </summary>
      public string Emp_Bak
      {
         get{ return emp_Bak; }
         set{ emp_Bak = value; emp_Bak_IsChanged=true; }
      }
      /// <summary>
      /// 备注
      /// </summary>
      public bool Emp_Bak_IsChanged
      {
         get{ return emp_Bak_IsChanged; }
         set{ emp_Bak_IsChanged = value; }
      }
      /// <summary>
      /// 是否使用系统
      /// </summary>
      private string emp_CanLogin;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_CanLogin_IsChanged=false;
      /// <summary>
      /// 是否使用系统
      /// </summary>
      public string Emp_CanLogin
      {
         get{ return emp_CanLogin; }
         set{ emp_CanLogin = value; emp_CanLogin_IsChanged=true; }
      }
      /// <summary>
      /// 是否使用系统
      /// </summary>
      public bool Emp_CanLogin_IsChanged
      {
         get{ return emp_CanLogin_IsChanged; }
         set{ emp_CanLogin_IsChanged = value; }
      }
      /// <summary>
      /// 系统登录名
      /// </summary>
      private string emp_LoginID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_LoginID_IsChanged=false;
      /// <summary>
      /// 系统登录名
      /// </summary>
      public string Emp_LoginID
      {
         get{ return emp_LoginID; }
         set{ emp_LoginID = value; emp_LoginID_IsChanged=true; }
      }
      /// <summary>
      /// 系统登录名
      /// </summary>
      public bool Emp_LoginID_IsChanged
      {
         get{ return emp_LoginID_IsChanged; }
         set{ emp_LoginID_IsChanged = value; }
      }
      /// <summary>
      /// 系统登录密码
      /// </summary>
      private string emp_LoginPwd;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_LoginPwd_IsChanged=false;
      /// <summary>
      /// 系统登录密码
      /// </summary>
      public string Emp_LoginPwd
      {
         get{ return emp_LoginPwd; }
         set{ emp_LoginPwd = value; emp_LoginPwd_IsChanged=true; }
      }
      /// <summary>
      /// 系统登录密码
      /// </summary>
      public bool Emp_LoginPwd_IsChanged
      {
         get{ return emp_LoginPwd_IsChanged; }
         set{ emp_LoginPwd_IsChanged = value; }
      }
      /// <summary>
      /// 手机号
      /// </summary>
      private string emp_Mobile;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Mobile_IsChanged=false;
      /// <summary>
      /// 手机号
      /// </summary>
      public string Emp_Mobile
      {
         get{ return emp_Mobile; }
         set{ emp_Mobile = value; emp_Mobile_IsChanged=true; }
      }
      /// <summary>
      /// 手机号
      /// </summary>
      public bool Emp_Mobile_IsChanged
      {
         get{ return emp_Mobile_IsChanged; }
         set{ emp_Mobile_IsChanged = value; }
      }
      /// <summary>
      /// 家庭座机
      /// </summary>
      private string emp_HomeTel;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_HomeTel_IsChanged=false;
      /// <summary>
      /// 家庭座机
      /// </summary>
      public string Emp_HomeTel
      {
         get{ return emp_HomeTel; }
         set{ emp_HomeTel = value; emp_HomeTel_IsChanged=true; }
      }
      /// <summary>
      /// 家庭座机
      /// </summary>
      public bool Emp_HomeTel_IsChanged
      {
         get{ return emp_HomeTel_IsChanged; }
         set{ emp_HomeTel_IsChanged = value; }
      }
      /// <summary>
      /// 公司座机
      /// </summary>
      private string emp_OffTel;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_OffTel_IsChanged=false;
      /// <summary>
      /// 公司座机
      /// </summary>
      public string Emp_OffTel
      {
         get{ return emp_OffTel; }
         set{ emp_OffTel = value; emp_OffTel_IsChanged=true; }
      }
      /// <summary>
      /// 公司座机
      /// </summary>
      public bool Emp_OffTel_IsChanged
      {
         get{ return emp_OffTel_IsChanged; }
         set{ emp_OffTel_IsChanged = value; }
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
      /// 员工状态
      /// </summary>
      private string emp_Stat;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Stat_IsChanged=false;
      /// <summary>
      /// 员工状态
      /// </summary>
      public string Emp_Stat
      {
         get{ return emp_Stat; }
         set{ emp_Stat = value; emp_Stat_IsChanged=true; }
      }
      /// <summary>
      /// 员工状态
      /// </summary>
      public bool Emp_Stat_IsChanged
      {
         get{ return emp_Stat_IsChanged; }
         set{ emp_Stat_IsChanged = value; }
      }
      /// <summary>
      /// 状态改变日期
      /// </summary>
      private DateTime emp_Date;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool emp_Date_IsChanged=false;
      /// <summary>
      /// 状态改变日期
      /// </summary>
      public DateTime Emp_Date
      {
         get{ return emp_Date; }
         set{ emp_Date = value; emp_Date_IsChanged=true; }
      }
      /// <summary>
      /// 状态改变日期
      /// </summary>
      public bool Emp_Date_IsChanged
      {
         get{ return emp_Date_IsChanged; }
         set{ emp_Date_IsChanged = value; }
      }
      private int emp_Order;
      private bool emp_Order_IsChanged=false;
      public int Emp_Order
      {
         get{ return emp_Order; }
         set{ emp_Order = value; emp_Order_IsChanged=true; }
      }
      public bool Emp_Order_IsChanged
      {
         get{ return emp_Order_IsChanged; }
         set{ emp_Order_IsChanged = value; }
      }
   }
}
