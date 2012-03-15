using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   /// <summary>
   /// 部门信息维护
   /// </summary>
   [Serializable]
   public partial class Bse_Department
   {
      /// <summary>
      /// 部门ID
      /// </summary>
      private Int64 dept_ID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_ID_IsChanged=false;
      /// <summary>
      /// 部门ID
      /// </summary>
      public Int64 Dept_ID
      {
         get{ return dept_ID; }
         set{ dept_ID = value; dept_ID_IsChanged=true; }
      }
      /// <summary>
      /// 部门ID
      /// </summary>
      public bool Dept_ID_IsChanged
      {
         get{ return dept_ID_IsChanged; }
         set{ dept_ID_IsChanged = value; }
      }
      /// <summary>
      /// 部门编码
      /// </summary>
      private string dept_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_Code_IsChanged=false;
      /// <summary>
      /// 部门编码
      /// </summary>
      public string Dept_Code
      {
         get{ return dept_Code; }
         set{ dept_Code = value; dept_Code_IsChanged=true; }
      }
      /// <summary>
      /// 部门编码
      /// </summary>
      public bool Dept_Code_IsChanged
      {
         get{ return dept_Code_IsChanged; }
         set{ dept_Code_IsChanged = value; }
      }
      /// <summary>
      /// 部门名称
      /// </summary>
      private string dept_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_Name_IsChanged=false;
      /// <summary>
      /// 部门名称
      /// </summary>
      public string Dept_Name
      {
         get{ return dept_Name; }
         set{ dept_Name = value; dept_Name_IsChanged=true; }
      }
      /// <summary>
      /// 部门名称
      /// </summary>
      public bool Dept_Name_IsChanged
      {
         get{ return dept_Name_IsChanged; }
         set{ dept_Name_IsChanged = value; }
      }
      /// <summary>
      /// 上级部门编码
      /// </summary>
      private string dept_PCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_PCode_IsChanged=false;
      /// <summary>
      /// 上级部门编码
      /// </summary>
      public string Dept_PCode
      {
         get{ return dept_PCode; }
         set{ dept_PCode = value; dept_PCode_IsChanged=true; }
      }
      /// <summary>
      /// 上级部门编码
      /// </summary>
      public bool Dept_PCode_IsChanged
      {
         get{ return dept_PCode_IsChanged; }
         set{ dept_PCode_IsChanged = value; }
      }
      /// <summary>
      /// 上级部门名称
      /// </summary>
      private string dept_PName;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_PName_IsChanged=false;
      /// <summary>
      /// 上级部门名称
      /// </summary>
      public string Dept_PName
      {
         get{ return dept_PName; }
         set{ dept_PName = value; dept_PName_IsChanged=true; }
      }
      /// <summary>
      /// 上级部门名称
      /// </summary>
      public bool Dept_PName_IsChanged
      {
         get{ return dept_PName_IsChanged; }
         set{ dept_PName_IsChanged = value; }
      }
      /// <summary>
      /// 部门主管
      /// </summary>
      private string dept_Owner;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_Owner_IsChanged=false;
      /// <summary>
      /// 部门主管
      /// </summary>
      public string Dept_Owner
      {
         get{ return dept_Owner; }
         set{ dept_Owner = value; dept_Owner_IsChanged=true; }
      }
      /// <summary>
      /// 部门主管
      /// </summary>
      public bool Dept_Owner_IsChanged
      {
         get{ return dept_Owner_IsChanged; }
         set{ dept_Owner_IsChanged = value; }
      }
      /// <summary>
      /// 部门主管姓名
      /// </summary>
      private string dept_OwnerName;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_OwnerName_IsChanged=false;
      /// <summary>
      /// 部门主管姓名
      /// </summary>
      public string Dept_OwnerName
      {
         get{ return dept_OwnerName; }
         set{ dept_OwnerName = value; dept_OwnerName_IsChanged=true; }
      }
      /// <summary>
      /// 部门主管姓名
      /// </summary>
      public bool Dept_OwnerName_IsChanged
      {
         get{ return dept_OwnerName_IsChanged; }
         set{ dept_OwnerName_IsChanged = value; }
      }
      /// <summary>
      /// 部门主管座机
      /// </summary>
      private string dept_OTel;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_OTel_IsChanged=false;
      /// <summary>
      /// 部门主管座机
      /// </summary>
      public string Dept_OTel
      {
         get{ return dept_OTel; }
         set{ dept_OTel = value; dept_OTel_IsChanged=true; }
      }
      /// <summary>
      /// 部门主管座机
      /// </summary>
      public bool Dept_OTel_IsChanged
      {
         get{ return dept_OTel_IsChanged; }
         set{ dept_OTel_IsChanged = value; }
      }
      /// <summary>
      /// 部门主管手机
      /// </summary>
      private string dept_OMob;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_OMob_IsChanged=false;
      /// <summary>
      /// 部门主管手机
      /// </summary>
      public string Dept_OMob
      {
         get{ return dept_OMob; }
         set{ dept_OMob = value; dept_OMob_IsChanged=true; }
      }
      /// <summary>
      /// 部门主管手机
      /// </summary>
      public bool Dept_OMob_IsChanged
      {
         get{ return dept_OMob_IsChanged; }
         set{ dept_OMob_IsChanged = value; }
      }
      /// <summary>
      /// 部门人数
      /// </summary>
      private string dept_Num;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_Num_IsChanged=false;
      /// <summary>
      /// 部门人数
      /// </summary>
      public string Dept_Num
      {
         get{ return dept_Num; }
         set{ dept_Num = value; dept_Num_IsChanged=true; }
      }
      /// <summary>
      /// 部门人数
      /// </summary>
      public bool Dept_Num_IsChanged
      {
         get{ return dept_Num_IsChanged; }
         set{ dept_Num_IsChanged = value; }
      }
      /// <summary>
      /// 是否叶节点
      /// </summary>
      private int dept_IsLeaf;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_IsLeaf_IsChanged=false;
      /// <summary>
      /// 是否叶节点
      /// </summary>
      public int Dept_IsLeaf
      {
         get{ return dept_IsLeaf; }
         set{ dept_IsLeaf = value; dept_IsLeaf_IsChanged=true; }
      }
      /// <summary>
      /// 是否叶节点
      /// </summary>
      public bool Dept_IsLeaf_IsChanged
      {
         get{ return dept_IsLeaf_IsChanged; }
         set{ dept_IsLeaf_IsChanged = value; }
      }
      /// <summary>
      /// 所在层级
      /// </summary>
      private int dept_Level;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_Level_IsChanged=false;
      /// <summary>
      /// 所在层级
      /// </summary>
      public int Dept_Level
      {
         get{ return dept_Level; }
         set{ dept_Level = value; dept_Level_IsChanged=true; }
      }
      /// <summary>
      /// 所在层级
      /// </summary>
      public bool Dept_Level_IsChanged
      {
         get{ return dept_Level_IsChanged; }
         set{ dept_Level_IsChanged = value; }
      }
      /// <summary>
      /// 部门简码
      /// </summary>
      private string dept_SimpleCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_SimpleCode_IsChanged=false;
      /// <summary>
      /// 部门简码
      /// </summary>
      public string Dept_SimpleCode
      {
         get{ return dept_SimpleCode; }
         set{ dept_SimpleCode = value; dept_SimpleCode_IsChanged=true; }
      }
      /// <summary>
      /// 部门简码
      /// </summary>
      public bool Dept_SimpleCode_IsChanged
      {
         get{ return dept_SimpleCode_IsChanged; }
         set{ dept_SimpleCode_IsChanged = value; }
      }
      /// <summary>
      /// 部门简称
      /// </summary>
      private string dept_SimpleName;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_SimpleName_IsChanged=false;
      /// <summary>
      /// 部门简称
      /// </summary>
      public string Dept_SimpleName
      {
         get{ return dept_SimpleName; }
         set{ dept_SimpleName = value; dept_SimpleName_IsChanged=true; }
      }
      /// <summary>
      /// 部门简称
      /// </summary>
      public bool Dept_SimpleName_IsChanged
      {
         get{ return dept_SimpleName_IsChanged; }
         set{ dept_SimpleName_IsChanged = value; }
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
      /// 部门状态
      /// </summary>
      private int dept_Stat;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_Stat_IsChanged=false;
      /// <summary>
      /// 部门状态
      /// </summary>
      public int Dept_Stat
      {
         get{ return dept_Stat; }
         set{ dept_Stat = value; dept_Stat_IsChanged=true; }
      }
      /// <summary>
      /// 部门状态
      /// </summary>
      public bool Dept_Stat_IsChanged
      {
         get{ return dept_Stat_IsChanged; }
         set{ dept_Stat_IsChanged = value; }
      }
      /// <summary>
      /// 部门简介
      /// </summary>
      private string dept_Desp;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_Desp_IsChanged=false;
      /// <summary>
      /// 部门简介
      /// </summary>
      public string Dept_Desp
      {
         get{ return dept_Desp; }
         set{ dept_Desp = value; dept_Desp_IsChanged=true; }
      }
      /// <summary>
      /// 部门简介
      /// </summary>
      public bool Dept_Desp_IsChanged
      {
         get{ return dept_Desp_IsChanged; }
         set{ dept_Desp_IsChanged = value; }
      }
      /// <summary>
      /// 备注
      /// </summary>
      private string dept_Bak;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dept_Bak_IsChanged=false;
      /// <summary>
      /// 备注
      /// </summary>
      public string Dept_Bak
      {
         get{ return dept_Bak; }
         set{ dept_Bak = value; dept_Bak_IsChanged=true; }
      }
      /// <summary>
      /// 备注
      /// </summary>
      public bool Dept_Bak_IsChanged
      {
         get{ return dept_Bak_IsChanged; }
         set{ dept_Bak_IsChanged = value; }
      }
      private DateTime dept_Date;
      private bool dept_Date_IsChanged=false;
      public DateTime Dept_Date
      {
         get{ return dept_Date; }
         set{ dept_Date = value; dept_Date_IsChanged=true; }
      }
      public bool Dept_Date_IsChanged
      {
         get{ return dept_Date_IsChanged; }
         set{ dept_Date_IsChanged = value; }
      }
   }
}
