using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Sys_Map
   {
      private decimal map_ID;
      private bool map_ID_IsChanged=false;
      public decimal Map_ID
      {
         get{ return map_ID; }
         set{ map_ID = value; map_ID_IsChanged=true; }
      }
      public bool Map_ID_IsChanged
      {
         get{ return map_ID_IsChanged; }
         set{ map_ID_IsChanged = value; }
      }
      /// <summary>
      /// 模块编码
      /// </summary>
      private string map_Module;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool map_Module_IsChanged=false;
      /// <summary>
      /// 模块编码
      /// </summary>
      public string Map_Module
      {
         get{ return map_Module; }
         set{ map_Module = value; map_Module_IsChanged=true; }
      }
      /// <summary>
      /// 模块编码
      /// </summary>
      public bool Map_Module_IsChanged
      {
         get{ return map_Module_IsChanged; }
         set{ map_Module_IsChanged = value; }
      }
      /// <summary>
      /// 源数据
      /// </summary>
      private string map_Source;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool map_Source_IsChanged=false;
      /// <summary>
      /// 源数据
      /// </summary>
      public string Map_Source
      {
         get{ return map_Source; }
         set{ map_Source = value; map_Source_IsChanged=true; }
      }
      /// <summary>
      /// 源数据
      /// </summary>
      public bool Map_Source_IsChanged
      {
         get{ return map_Source_IsChanged; }
         set{ map_Source_IsChanged = value; }
      }
      /// <summary>
      /// 映射对应数据
      /// </summary>
      private string map_Object;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool map_Object_IsChanged=false;
      /// <summary>
      /// 映射对应数据
      /// </summary>
      public string Map_Object
      {
         get{ return map_Object; }
         set{ map_Object = value; map_Object_IsChanged=true; }
      }
      /// <summary>
      /// 映射对应数据
      /// </summary>
      public bool Map_Object_IsChanged
      {
         get{ return map_Object_IsChanged; }
         set{ map_Object_IsChanged = value; }
      }
      /// <summary>
      /// 映射对应数据1
      /// </summary>
      private string map_Object1;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool map_Object1_IsChanged=false;
      /// <summary>
      /// 映射对应数据1
      /// </summary>
      public string Map_Object1
      {
         get{ return map_Object1; }
         set{ map_Object1 = value; map_Object1_IsChanged=true; }
      }
      /// <summary>
      /// 映射对应数据1
      /// </summary>
      public bool Map_Object1_IsChanged
      {
         get{ return map_Object1_IsChanged; }
         set{ map_Object1_IsChanged = value; }
      }
      /// <summary>
      /// 映射对应数据2
      /// </summary>
      private string map_Object2;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool map_Object2_IsChanged=false;
      /// <summary>
      /// 映射对应数据2
      /// </summary>
      public string Map_Object2
      {
         get{ return map_Object2; }
         set{ map_Object2 = value; map_Object2_IsChanged=true; }
      }
      /// <summary>
      /// 映射对应数据2
      /// </summary>
      public bool Map_Object2_IsChanged
      {
         get{ return map_Object2_IsChanged; }
         set{ map_Object2_IsChanged = value; }
      }
      /// <summary>
      /// 映射类型
      /// </summary>
      private string map_Type;
      /// <summary>
      /// 改变标识
      /// </summary>
      private bool map_Type_IsChanged=false;
      /// <summary>
      /// 映射类型
      /// </summary>
      public string Map_Type
      {
         get{ return map_Type; }
         set{ map_Type = value; map_Type_IsChanged=true; }
      }
      /// <summary>
      /// 映射类型
      /// </summary>
      public bool Map_Type_IsChanged
      {
         get{ return map_Type_IsChanged; }
         set{ map_Type_IsChanged = value; }
      }
      private string map_UDEF1;
      private bool map_UDEF1_IsChanged=false;
      public string Map_UDEF1
      {
         get{ return map_UDEF1; }
         set{ map_UDEF1 = value; map_UDEF1_IsChanged=true; }
      }
      public bool Map_UDEF1_IsChanged
      {
         get{ return map_UDEF1_IsChanged; }
         set{ map_UDEF1_IsChanged = value; }
      }
      private string map_UDEF2;
      private bool map_UDEF2_IsChanged=false;
      public string Map_UDEF2
      {
         get{ return map_UDEF2; }
         set{ map_UDEF2 = value; map_UDEF2_IsChanged=true; }
      }
      public bool Map_UDEF2_IsChanged
      {
         get{ return map_UDEF2_IsChanged; }
         set{ map_UDEF2_IsChanged = value; }
      }
      private string map_UDEF3;
      private bool map_UDEF3_IsChanged=false;
      public string Map_UDEF3
      {
         get{ return map_UDEF3; }
         set{ map_UDEF3 = value; map_UDEF3_IsChanged=true; }
      }
      public bool Map_UDEF3_IsChanged
      {
         get{ return map_UDEF3_IsChanged; }
         set{ map_UDEF3_IsChanged = value; }
      }
      private string map_UDEF4;
      private bool map_UDEF4_IsChanged=false;
      public string Map_UDEF4
      {
         get{ return map_UDEF4; }
         set{ map_UDEF4 = value; map_UDEF4_IsChanged=true; }
      }
      public bool Map_UDEF4_IsChanged
      {
         get{ return map_UDEF4_IsChanged; }
         set{ map_UDEF4_IsChanged = value; }
      }
      private string map_UDEF5;
      private bool map_UDEF5_IsChanged=false;
      public string Map_UDEF5
      {
         get{ return map_UDEF5; }
         set{ map_UDEF5 = value; map_UDEF5_IsChanged=true; }
      }
      public bool Map_UDEF5_IsChanged
      {
         get{ return map_UDEF5_IsChanged; }
         set{ map_UDEF5_IsChanged = value; }
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
