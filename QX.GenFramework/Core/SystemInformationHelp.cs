using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using QX.GenFramework.Model;
using Infragistics.Win.UltraWinEditors;

namespace QX.GenFramework.AutoForm
{
    public partial class SystemInformationHelp : Form
    {
        StringBuilder _SysInformation = new StringBuilder();
        Control _Control;

        public SystemInformationHelp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Control">控件本身信息</param>
        public SystemInformationHelp(Control ctl)
        {
            InitializeComponent();

            _Control = ctl;
            
        }
        public SystemInformationHelp(object ctl)
        {
            InitializeComponent();

            _Control = ctl as Control;

        }

        private void SystemInformationHelp_Load(object sender, EventArgs e)
        {
            SetBindHelpMessage();
            this.uteSystemInformation.Text = _SysInformation.ToString();
        }

        void SetBindHelpMessage()
        {
            _SysInformation = null;
            _SysInformation = new StringBuilder();
            if (_Control == null)
            {
                _SysInformation.Append("无相关帮助信息");
                return;
            }
            Form frm = _Control.FindForm();
            if (frm == null)
                return;
            _SysInformation.AppendLine("产品名称：" + Application.ProductName);
            _SysInformation.AppendLine("产品版本：" + Application.ProductVersion);
            _SysInformation.AppendLine("运行路径：" + Application.StartupPath);
            _SysInformation.AppendLine("数据路径：" + Application.UserAppDataPath);
            _SysInformation.AppendLine("执行路径：" + Application.ExecutablePath);
            _SysInformation.AppendLine();
            _SysInformation.AppendLine();
            _SysInformation.AppendLine("窗体信息：" + frm.ToString());
            _SysInformation.AppendLine("窗体名称：" + frm.Text);
            _SysInformation.AppendLine("窗体技术名称：" + frm.Name);
            _SysInformation.AppendLine("窗体全名：" + frm.GetType().FullName);
            _SysInformation.AppendLine("窗体命名空间：" + frm.GetType().Namespace);
            _SysInformation.AppendLine("窗体类型：" + frm.GetType().Name);
            _SysInformation.AppendLine("程序集：" + frm.GetType().Assembly.Location.ToString());
            _SysInformation.AppendLine("窗体位置：" + frm.Location.ToString());
            _SysInformation.AppendLine("窗体大小：" + frm.Size.ToString());
           
            _SysInformation.AppendLine();
            _SysInformation.AppendLine();

            string controlType = _Control.GetType().Name;
            Sys_PD_Module module;
            Sys_PD_Filed field;
            switch (controlType.ToLower())
            {
                case "ultragrid"://如果是列表
                    UltraGrid ug_list = _Control as UltraGrid;
                    GridTagObject gridObject = ug_list.Tag as GridTagObject;
                    module = gridObject.Module;
                    _SysInformation.AppendLine("Gird模块名称：" + module.SPM_Name);
                    _SysInformation.AppendLine("Gird技术模块：" + module.SPM_Module);
                    _SysInformation.AppendLine("Gird列数量：" + ug_list.DisplayLayout.Bands[0].Columns.Count.ToString());
                    _SysInformation.AppendLine("Gird数据行数：" + ug_list.Rows.Count.ToString());
                    _SysInformation.AppendLine("Gird位置：" + ug_list.Location.ToString());
                    _SysInformation.AppendLine("Gird大小：" + ug_list.Size.ToString());
                    _SysInformation.AppendLine("Gird数据源：" + ug_list.DataSource.GetType());
                    break;
                case "panel":
                    Panel panel = _Control as Panel;
                    module = panel.Tag as Sys_PD_Module;
                    _SysInformation.AppendLine("模块名称：" + module.SPM_Name);
                    _SysInformation.AppendLine("技术模块：" + module.SPM_Module);
                    break;
                case "groupbox":
                    GroupBox gbox = _Control as GroupBox;
                    module = gbox.Tag as Sys_PD_Module;
                    _SysInformation.AppendLine("模块名称：" + module.SPM_Name);
                    _SysInformation.AppendLine("技术模块：" + module.SPM_Module);
                    break;
                case "tabpage":
                    TabPage gtabPage = _Control as TabPage;
                    module = gtabPage.Tag as Sys_PD_Module;
                    _SysInformation.AppendLine("模块名称：" + module.SPM_Name);
                    _SysInformation.AppendLine("技术模块：" + module.SPM_Module);
                    break;
                case "ultracombo":
                    UltraCombo combo = _Control as UltraCombo;
                    field = combo.Tag as Sys_PD_Filed;

                    _SysInformation.AppendLine("字段标签：" + field.DCP_Label);
                    _SysInformation.AppendLine("字段名字：" + field.DCP_ControlID);
                    _SysInformation.AppendLine("配置模块：" + field.DCP_ModuleName);
                    _SysInformation.AppendLine("数据实体：" + field.DCP_Model);
                    _SysInformation.AppendLine("字段类型：" + field.DCP_ControlType);
                    _SysInformation.AppendLine("参考字典：" + field.DCP_Type);
                    _SysInformation.AppendLine("参考显示：" + field.DCP_RefValue + "    " + field.DCP_RefCode);
                    _SysInformation.AppendLine("参考SQL：" + field.DCP_RefSQL);
                    _SysInformation.AppendLine("回写字段：" + field.DCP_RefBack);
                    _SysInformation.AppendLine("多字段回写：" + field.DCP_PageName);
                    _SysInformation.AppendLine("上级控件：" + field.DCP_PControl);
                    _SysInformation.AppendLine("子级控件：" + field.DCP_CControl);
                    break;
                case "ultranumericeditor":
                    UltraNumericEditor une = _Control as UltraNumericEditor;
                    field = une.Tag as Sys_PD_Filed;

                    _SysInformation.AppendLine("字段标签：" + field.DCP_Label);
                    _SysInformation.AppendLine("字段名字：" + field.DCP_ControlID);
                    _SysInformation.AppendLine("配置模块：" + field.DCP_ModuleName);
                    _SysInformation.AppendLine("数据实体：" + field.DCP_Model);
                    _SysInformation.AppendLine("字段类型：" + field.DCP_ControlType);
                    _SysInformation.AppendLine("参考字典：" + field.DCP_Type);
                    _SysInformation.AppendLine("参考显示：" + field.DCP_RefValue + "    " + field.DCP_RefCode);
                    _SysInformation.AppendLine("参考SQL：" + field.DCP_RefSQL);
                    _SysInformation.AppendLine("回写字段：" + field.DCP_RefBack);
                    _SysInformation.AppendLine("多字段回写：" + field.DCP_PageName);
                    _SysInformation.AppendLine("上级控件：" + field.DCP_PControl);
                    _SysInformation.AppendLine("子级控件：" + field.DCP_CControl);
                    break;
                case "utratexteditor":
                    UltraTextEditor ute = _Control as UltraTextEditor;
                    field = ute.Tag as Sys_PD_Filed;

                    _SysInformation.AppendLine("字段标签：" + field.DCP_Label);
                    _SysInformation.AppendLine("字段名字：" + field.DCP_ControlID);
                    _SysInformation.AppendLine("配置模块：" + field.DCP_ModuleName);
                    _SysInformation.AppendLine("数据实体：" + field.DCP_Model);
                    _SysInformation.AppendLine("字段类型：" + field.DCP_ControlType);
                    _SysInformation.AppendLine("参考字典：" + field.DCP_Type);
                    _SysInformation.AppendLine("参考显示：" + field.DCP_RefValue + "    " + field.DCP_RefCode);
                    _SysInformation.AppendLine("参考SQL：" + field.DCP_RefSQL);
                    _SysInformation.AppendLine("回写字段：" + field.DCP_RefBack);
                    _SysInformation.AppendLine("多字段回写：" + field.DCP_PageName);
                    _SysInformation.AppendLine("上级控件：" + field.DCP_PControl);
                    _SysInformation.AppendLine("子级控件：" + field.DCP_CControl);
                    break;
                case "ultradatetimeeditor":
                    UltraDateTimeEditor udt = _Control as UltraDateTimeEditor;
                    field = udt.Tag as Sys_PD_Filed;

                    _SysInformation.AppendLine("字段标签：" + field.DCP_Label);
                    _SysInformation.AppendLine("字段名字：" + field.DCP_ControlID);
                    _SysInformation.AppendLine("配置模块：" + field.DCP_ModuleName);
                    _SysInformation.AppendLine("数据实体：" + field.DCP_Model);
                    _SysInformation.AppendLine("字段类型：" + field.DCP_ControlType);
                    _SysInformation.AppendLine("参考字典：" + field.DCP_Type);
                    _SysInformation.AppendLine("参考显示：" + field.DCP_RefValue + "    " + field.DCP_RefCode);
                    _SysInformation.AppendLine("参考SQL：" + field.DCP_RefSQL);
                    _SysInformation.AppendLine("回写字段：" + field.DCP_RefBack);
                    _SysInformation.AppendLine("多字段回写：" + field.DCP_PageName);
                    _SysInformation.AppendLine("上级控件：" + field.DCP_PControl);
                    _SysInformation.AppendLine("子级控件：" + field.DCP_CControl);
                    break;
                case "ultracomboeditor":
                    UltraComboEditor uce = _Control as UltraComboEditor;
                    field = uce.Tag as Sys_PD_Filed;

                    _SysInformation.AppendLine("字段标签：" + field.DCP_Label);
                    _SysInformation.AppendLine("字段名字：" + field.DCP_ControlID);
                    _SysInformation.AppendLine("配置模块：" + field.DCP_ModuleName);
                    _SysInformation.AppendLine("数据实体：" + field.DCP_Model);
                    _SysInformation.AppendLine("字段类型：" + field.DCP_ControlType);
                    _SysInformation.AppendLine("参考字典：" + field.DCP_Type);
                    _SysInformation.AppendLine("参考显示：" + field.DCP_RefValue + "    " + field.DCP_RefCode);
                    _SysInformation.AppendLine("参考SQL：" + field.DCP_RefSQL);
                    _SysInformation.AppendLine("回写字段：" + field.DCP_RefBack);
                    _SysInformation.AppendLine("多字段回写：" + field.DCP_PageName);
                    _SysInformation.AppendLine("上级控件：" + field.DCP_PControl);
                    _SysInformation.AppendLine("子级控件：" + field.DCP_CControl);
                    break;
            }

            //_SysInformation.AppendLine("窗体位置：" + fr);
        }
    }
}
