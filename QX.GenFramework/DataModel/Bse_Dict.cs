using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.GenFramework.Model
{
   /// <summary>
   /// 数据字典
   /// </summary>
   [Serializable]
   public partial class Bse_Dict
   {
      /// <summary>
      /// 字典编码
      /// </summary>
      private decimal dict_ID;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_ID_IsChanged=false;
      /// <summary>
      /// 字典编码
      /// </summary>
      public decimal Dict_ID
      {
         get{ return dict_ID; }
         set{ dict_ID = value; dict_ID_IsChanged=true; }
      }
      /// <summary>
      /// 字典编码
      /// </summary>
      public bool Dict_ID_IsChanged
      {
         get{ return dict_ID_IsChanged; }
         set{ dict_ID_IsChanged = value; }
      }
      /// <summary>
      /// 字典关键字
      /// </summary>
      private string dict_Key;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_Key_IsChanged=false;
      /// <summary>
      /// 字典关键字
      /// </summary>
      public string Dict_Key
      {
         get{ return dict_Key; }
         set{ dict_Key = value; dict_Key_IsChanged=true; }
      }
      /// <summary>
      /// 字典关键字
      /// </summary>
      public bool Dict_Key_IsChanged
      {
         get{ return dict_Key_IsChanged; }
         set{ dict_Key_IsChanged = value; }
      }
      /// <summary>
      /// 编码
      /// </summary>
      private string dict_Code;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_Code_IsChanged=false;
      /// <summary>
      /// 编码
      /// </summary>
      public string Dict_Code
      {
         get{ return dict_Code; }
         set{ dict_Code = value; dict_Code_IsChanged=true; }
      }
      /// <summary>
      /// 编码
      /// </summary>
      public bool Dict_Code_IsChanged
      {
         get{ return dict_Code_IsChanged; }
         set{ dict_Code_IsChanged = value; }
      }
      /// <summary>
      /// 名称
      /// </summary>
      private string dict_Name;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_Name_IsChanged=false;
      /// <summary>
      /// 名称
      /// </summary>
      public string Dict_Name
      {
         get{ return dict_Name; }
         set{ dict_Name = value; dict_Name_IsChanged=true; }
      }
      /// <summary>
      /// 名称
      /// </summary>
      public bool Dict_Name_IsChanged
      {
         get{ return dict_Name_IsChanged; }
         set{ dict_Name_IsChanged = value; }
      }
      /// <summary>
      /// 父编码
      /// </summary>
      private string dict_PCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_PCode_IsChanged=false;
      /// <summary>
      /// 父编码
      /// </summary>
      public string Dict_PCode
      {
         get{ return dict_PCode; }
         set{ dict_PCode = value; dict_PCode_IsChanged=true; }
      }
      /// <summary>
      /// 父编码
      /// </summary>
      public bool Dict_PCode_IsChanged
      {
         get{ return dict_PCode_IsChanged; }
         set{ dict_PCode_IsChanged = value; }
      }
      /// <summary>
      /// 父名称
      /// </summary>
      private string dict_PName;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_PName_IsChanged=false;
      /// <summary>
      /// 父名称
      /// </summary>
      public string Dict_PName
      {
         get{ return dict_PName; }
         set{ dict_PName = value; dict_PName_IsChanged=true; }
      }
      /// <summary>
      /// 父名称
      /// </summary>
      public bool Dict_PName_IsChanged
      {
         get{ return dict_PName_IsChanged; }
         set{ dict_PName_IsChanged = value; }
      }
      /// <summary>
      /// 说明
      /// </summary>
      private string dict_Desp;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_Desp_IsChanged=false;
      /// <summary>
      /// 说明
      /// </summary>
      public string Dict_Desp
      {
         get{ return dict_Desp; }
         set{ dict_Desp = value; dict_Desp_IsChanged=true; }
      }
      /// <summary>
      /// 说明
      /// </summary>
      public bool Dict_Desp_IsChanged
      {
         get{ return dict_Desp_IsChanged; }
         set{ dict_Desp_IsChanged = value; }
      }
      /// <summary>
      /// 查询简码
      /// </summary>
      private string dict_SCode;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_SCode_IsChanged=false;
      /// <summary>
      /// 查询简码
      /// </summary>
      public string Dict_SCode
      {
         get{ return dict_SCode; }
         set{ dict_SCode = value; dict_SCode_IsChanged=true; }
      }
      /// <summary>
      /// 查询简码
      /// </summary>
      public bool Dict_SCode_IsChanged
      {
         get{ return dict_SCode_IsChanged; }
         set{ dict_SCode_IsChanged = value; }
      }
      /// <summary>
      /// 备注
      /// </summary>
      private string dict_Bak;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_Bak_IsChanged=false;
      /// <summary>
      /// 备注
      /// </summary>
      public string Dict_Bak
      {
         get{ return dict_Bak; }
         set{ dict_Bak = value; dict_Bak_IsChanged=true; }
      }
      /// <summary>
      /// 备注
      /// </summary>
      public bool Dict_Bak_IsChanged
      {
         get{ return dict_Bak_IsChanged; }
         set{ dict_Bak_IsChanged = value; }
      }
      /// <summary>
      /// 自定义项1
      /// </summary>
      private string dict_UDef1;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_UDef1_IsChanged=false;
      /// <summary>
      /// 自定义项1
      /// </summary>
      public string Dict_UDef1
      {
         get{ return dict_UDef1; }
         set{ dict_UDef1 = value; dict_UDef1_IsChanged=true; }
      }
      /// <summary>
      /// 自定义项1
      /// </summary>
      public bool Dict_UDef1_IsChanged
      {
         get{ return dict_UDef1_IsChanged; }
         set{ dict_UDef1_IsChanged = value; }
      }
      /// <summary>
      /// 自定义项2
      /// </summary>
      private string dict_UDef2;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_UDef2_IsChanged=false;
      /// <summary>
      /// 自定义项2
      /// </summary>
      public string Dict_UDef2
      {
         get{ return dict_UDef2; }
         set{ dict_UDef2 = value; dict_UDef2_IsChanged=true; }
      }
      /// <summary>
      /// 自定义项2
      /// </summary>
      public bool Dict_UDef2_IsChanged
      {
         get{ return dict_UDef2_IsChanged; }
         set{ dict_UDef2_IsChanged = value; }
      }
      /// <summary>
      /// 自定义项3
      /// </summary>
      private string dict_UDef3;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_UDef3_IsChanged=false;
      /// <summary>
      /// 自定义项3
      /// </summary>
      public string Dict_UDef3
      {
         get{ return dict_UDef3; }
         set{ dict_UDef3 = value; dict_UDef3_IsChanged=true; }
      }
      /// <summary>
      /// 自定义项3
      /// </summary>
      public bool Dict_UDef3_IsChanged
      {
         get{ return dict_UDef3_IsChanged; }
         set{ dict_UDef3_IsChanged = value; }
      }
      /// <summary>
      /// 自定义项4
      /// </summary>
      private string dict_UDef4;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_UDef4_IsChanged=false;
      /// <summary>
      /// 自定义项4
      /// </summary>
      public string Dict_UDef4
      {
         get{ return dict_UDef4; }
         set{ dict_UDef4 = value; dict_UDef4_IsChanged=true; }
      }
      /// <summary>
      /// 自定义项4
      /// </summary>
      public bool Dict_UDef4_IsChanged
      {
         get{ return dict_UDef4_IsChanged; }
         set{ dict_UDef4_IsChanged = value; }
      }
      /// <summary>
      /// 自定义项5
      /// </summary>
      private string dict_UDef5;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_UDef5_IsChanged=false;
      /// <summary>
      /// 自定义项5
      /// </summary>
      public string Dict_UDef5
      {
         get{ return dict_UDef5; }
         set{ dict_UDef5 = value; dict_UDef5_IsChanged=true; }
      }
      /// <summary>
      /// 自定义项5
      /// </summary>
      public bool Dict_UDef5_IsChanged
      {
         get{ return dict_UDef5_IsChanged; }
         set{ dict_UDef5_IsChanged = value; }
      }
      /// <summary>
      /// 层级
      /// </summary>
      private int dict_Level;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_Level_IsChanged=false;
      /// <summary>
      /// 层级
      /// </summary>
      public int Dict_Level
      {
         get{ return dict_Level; }
         set{ dict_Level = value; dict_Level_IsChanged=true; }
      }
      /// <summary>
      /// 层级
      /// </summary>
      public bool Dict_Level_IsChanged
      {
         get{ return dict_Level_IsChanged; }
         set{ dict_Level_IsChanged = value; }
      }
      /// <summary>
      /// 是否可修改
      /// </summary>
      private int dict_IsEditable;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_IsEditable_IsChanged=false;
      /// <summary>
      /// 是否可修改
      /// </summary>
      public int Dict_IsEditable
      {
         get{ return dict_IsEditable; }
         set{ dict_IsEditable = value; dict_IsEditable_IsChanged=true; }
      }
      /// <summary>
      /// 是否可修改
      /// </summary>
      public bool Dict_IsEditable_IsChanged
      {
         get{ return dict_IsEditable_IsChanged; }
         set{ dict_IsEditable_IsChanged = value; }
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
      /// 显示顺序
      /// </summary>
      private int dict_Order;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool dict_Order_IsChanged=false;
      /// <summary>
      /// 显示顺序
      /// </summary>
      public int Dict_Order
      {
         get{ return dict_Order; }
         set{ dict_Order = value; dict_Order_IsChanged=true; }
      }
      /// <summary>
      /// 显示顺序
      /// </summary>
      public bool Dict_Order_IsChanged
      {
         get{ return dict_Order_IsChanged; }
         set{ dict_Order_IsChanged = value; }
      }
   }
}
