using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using System.Drawing;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using QX.GenFramework.Model;
using QX.GenFramework.ADO;

namespace QX.GenFramework.AutoForm
{
    public class FormHelper
    {
        internal class InternalDiction
        {
            public string ValueMember
            {
                get;
                set;
            }

            public string DisplayMember
            {
                get;
                set;
            }
        }
        ADOSys_PD_Module instModule = new ADOSys_PD_Module();
        ADOSys_PD_Filed instField = new ADOSys_PD_Filed();
        ADOBse_Dict instDict = new ADOBse_Dict();
        ADOSys_PD_RefModule instRef = new ADOSys_PD_RefModule();

        //delegate void ExcuteWithReturnValue(UltraComboEditor uce, string type);

        #region 生成Form表单
        public void GenerateForm(string moduleName, Control ctr, Point p)
        {
            Sys_PD_Module module = new Sys_PD_Module();
            module = instModule.GetListByWhere(" and SPM_Module='" + moduleName + "'").ToList()[0];
            List<Sys_PD_Filed> filedList = new List<Sys_PD_Filed>();
            filedList = instField.GetListByWhere(" and DCP_ModuleName='" + moduleName + "' order by DCP_Order").ToList();
            Sys_PD_RefModule refModule = new Sys_PD_RefModule();
            ctr.Tag = module;

            int iTabInex = 0;
            int xPosition = p.X;
            int yPosition = p.Y;
            int vXPosition = p.X;
            int step = 0;//控制一行已经输出多少列
            int fTI = module.SPM_TI;
            int fTX = module.SPM_TX;
            int fTY = module.SPM_TY;
            int fHeight = module.SPM_Height;

            Size lableSize = new Size(module.SPM_LX, module.SPM_LY);//标签的大小
            Size textSize = new Size(fTX, fTY);//文本框的大小
            Size areaSize = new Size((fTX * 2) + module.SPM_LX + module.SPM_LI, fTY * 3);//备注框大小
            foreach (Sys_PD_Filed field in filedList)
            {

                if (field.DCP_IsHidden == 1)
                {
                    UltraTextEditor _hiddenBox = new UltraTextEditor();
                    _hiddenBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                    _hiddenBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                    _hiddenBox.Visible = false;
                    ctr.Controls.Add(_hiddenBox);
                    continue;
                }
                if (field.DCP_Style == "newline" ||
                    (field.DCP_ControlType == "textarea" &&
                    step > module.SPM_CNum - 2))
                {
                    if (module.SPM_CNum == 1 && field.DCP_ControlType == "textarea")
                    { }
                    else
                    {
                        step = 0;
                        vXPosition = xPosition;
                        yPosition += fHeight;
                    }
                }

                fTI = module.SPM_TI;
                fTX = module.SPM_TX;
                fTY = module.SPM_TY;
                fHeight = module.SPM_Height;
                textSize = new Size(fTX, fTY);//文本框的大小
                areaSize = new Size((fTX * 2) + module.SPM_LX + module.SPM_LI, fTY * 3);


                /////////如果字段有自定义的大小，则赋值到相关模块
                if (field.DCP_TI != 0 && field.DCP_TX != 0 && field.DCP_TY != 0 && field.DCP_Height != 0)
                {
                    textSize = new Size(field.DCP_TX, field.DCP_TY);
                    areaSize = new Size(field.DCP_TX, field.DCP_TY);
                    fTX = field.DCP_TX;
                    fTY = field.DCP_TY;
                    fTI = field.DCP_TI;
                    fHeight = field.DCP_Height;
                }

                Infragistics.Win.Misc.UltraLabel _lab = new Infragistics.Win.Misc.UltraLabel();
                _lab.Location = new Point(vXPosition, yPosition + 6);
                _lab.Name = module.SPM_LPrefix + field.DCP_ControlID.ToString();
                _lab.Size = lableSize;
                _lab.TabIndex = iTabInex++;
                _lab.Text = field.DCP_Label.ToString();
                ctr.Controls.Add(_lab);

                vXPosition += module.SPM_LI;

                #region 控件生成
                switch (field.DCP_ControlType)
                {
                    case "dec":
                        UltraNumericEditor _numBox = new UltraNumericEditor();
                        _numBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _numBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _numBox.Size = textSize;
                        _numBox.NumericType = NumericType.Double;
                        _numBox.TabIndex = iTabInex++;
                        _numBox.PromptChar = ' ';
                        _numBox.Nullable = true;
                        _numBox.NullText = "0";
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    _numBox.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    _numBox.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}
                        if (field.DCP_IsReadonly == 1)
                        {
                            _numBox.ReadOnly = true;
                        }
                        //_numBox.DoubleClick += new EventHandler(_numBox_DoubleClick);
                        ctr.Controls.Add(_numBox);
                        break;
                    case "int":
                        UltraNumericEditor _intBox = new UltraNumericEditor();
                        _intBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _intBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _intBox.Size = textSize;
                        _intBox.NumericType = NumericType.Integer;
                        _intBox.TabIndex = iTabInex++;
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    _intBox.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    _intBox.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}
                        if (field.DCP_IsReadonly == 1)
                        {
                            _intBox.ReadOnly = true;
                        }
                        _intBox.PromptChar = ' ';
                        _intBox.Nullable = true;
                        _intBox.NullText = "0";
                        
                        ctr.Controls.Add(_intBox);
                        break;
                    case "text":
                        UltraTextEditor _textBox = new UltraTextEditor();
                        _textBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _textBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _textBox.Size = textSize;
                        _textBox.TabIndex = iTabInex++;
                        _textBox.Nullable = true;
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    _textBox.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    _textBox.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}
                        if (field.DCP_IsReadonly == 1)
                        {
                            _textBox.ReadOnly = true;
                        }
                        ctr.Controls.Add(_textBox);
                        break;
                    case "textl":
                        UltraTextEditor _texBox = new UltraTextEditor();
                        _texBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _texBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _texBox.Size = new Size(textSize.Width * 2, textSize.Height);
                        _texBox.TabIndex = iTabInex++;
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    _texBox.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    _texBox.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}

                        if (field.DCP_IsReadonly == 1)
                        {
                            _texBox.ReadOnly = true;
                        }
                        
                        ctr.Controls.Add(_texBox);
                        step++;
                        vXPosition += (fTI + module.SPM_LI);
                        break;
                    case "textarea":

                        UltraTextEditor _mBox = new UltraTextEditor();
                        _mBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _mBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _mBox.Multiline = true;
                        _mBox.Size = areaSize;
                        _mBox.TabIndex = iTabInex++;
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    _mBox.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    _mBox.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}
                        if (field.DCP_IsReadonly == 1)
                        {
                            _mBox.ReadOnly = true;
                        }
                        
                        ctr.Controls.Add(_mBox);
                        break;
                    case "date":
                        UltraDateTimeEditor _dateCom = new UltraDateTimeEditor();
                        _dateCom.BackColor = System.Drawing.SystemColors.Window;
                        _dateCom.MaskInput = "yyyy-mm-dd";
                        _dateCom.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
                        _dateCom.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _dateCom.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _dateCom.Size = textSize;
                        _dateCom.TabIndex = iTabInex++;
                        _dateCom.Value = DateTime.Now;
                        _dateCom.PromptChar = ' ';
                        _dateCom.Nullable = true;
                        _dateCom.NullText = DateTime.Now.ToString();
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    _dateCom.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    _dateCom.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}
                        if (field.DCP_IsReadonly == 1)
                        {
                            _dateCom.ReadOnly = true;
                        }
                        
                        ctr.Controls.Add(_dateCom);
                        break;
                    case "time":
                        UltraDateTimeEditor _timeCom = new UltraDateTimeEditor();
                        _timeCom.BackColor = System.Drawing.SystemColors.Window;
                        _timeCom.MaskInput = "yyyy-mm-dd hh:mm";
                        _timeCom.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
                        _timeCom.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _timeCom.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _timeCom.Size = textSize;
                        _timeCom.TabIndex = iTabInex++;
                        _timeCom.Value = DateTime.Now;
                        _timeCom.PromptChar = ' ';
                        _timeCom.Nullable = true;
                        _timeCom.NullText = DateTime.Now.ToString();
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    _timeCom.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    _timeCom.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}
                        if (field.DCP_IsReadonly == 1)
                        {
                            _timeCom.ReadOnly = true;
                        }
                        
                        ctr.Controls.Add(_timeCom);
                        break;
                    case "dict":
                        UltraComboEditor _comEdit = new UltraComboEditor();
                        _comEdit.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _comEdit.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _comEdit.Size = textSize;
                        _comEdit.TabIndex = iTabInex++;
                        _comEdit.DropDownStyle = DropDownStyle.DropDownList;
                        _comEdit.Tag = field;
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    _comEdit.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    _comEdit.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}
                        if (field.DCP_IsReadonly == 1)
                        {
                            _comEdit.ReadOnly = true;
                        }
                        _comEdit.ValueChanged += new EventHandler(_comEdit_ValueChanged);

                        ctr.Controls.Add(_comEdit);
                        //ExcuteWithReturnValue ddd = new ExcuteWithReturnValue(this.SetDictValue);

                        //ddd.BeginInvoke(_comEdit, field.DCP_Type, null, null);
                       
                        SetDictValue(_comEdit, field.DCP_Type);
                        break;
                    case "ref":
                        #region UltraGrid 界面设置

                        UltraCombo uCom = new UltraCombo();
                        #endregion
                        uCom.Location = new System.Drawing.Point(vXPosition, yPosition);
                        uCom.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        uCom.Size = textSize;
                        uCom.TabIndex = iTabInex++;
                        uCom.Tag = field;
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    uCom.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    uCom.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}
                        //uCom.Text =
                        ctr.Controls.Add(uCom);
                        //if (uCom.Value == null)
                        //{
                        //    uCom.Value = "";
                        //}

                        string sql = string.Empty;
                        if (!string.IsNullOrEmpty(field.DCP_RefSQL))
                        {
                            refModule = instRef.GetListByWhere(string.Format(" and SPR_RefModule='{0}'", field.DCP_RefSQL)).FirstOrDefault();//获取参考
                            if (refModule != null)
                            {
                                sql = string.Format(refModule.SPR_RefSQL.Trim(), "", "");
                                DataTable refDate = new DataTable();
                                refDate = instField.GetRefData(sql);
                                uCom.DataSource = refDate.DefaultView;
                                uCom.DisplayMember = refModule.SPR_RefData;
                                uCom.ValueMember = refModule.SPR_RefValue;
                            }
                        }
                        if (!string.IsNullOrEmpty(field.DCP_PControl))
                        {
                            uCom.Enabled = false;
                        }

                        uCom.ValueChanged += new EventHandler(uCom_ValueChanged);
                        //uCom.BeforeDropDown += new System.ComponentModel.CancelEventHandler(uCom_BeforeDropDown);
                        uCom.TextChanged += new EventHandler(uCom_TextChanged);
                        //uCom.LostFocus += new EventHandler(uCom_LostFocus);
                        //uCom.InitializeLayout += new InitializeLayoutEventHandler(uCom_InitializeLayout);

                        if (field.DCP_IsReadonly == 1)
                        {
                            uCom.ReadOnly = true;
                        }
                        break;
                    case "refone":
                        UltraTextEditor _refTextBox = new UltraTextEditor();
                        _refTextBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _refTextBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _refTextBox.Size = textSize;
                        _refTextBox.Tag = field;
                        _refTextBox.TabIndex = iTabInex++;
                        _refTextBox.Nullable = true;
                        //if (!string.IsNullOrEmpty(field.DCP_BackColor)) //背景颜色
                        //{
                        //    _refTextBox.Appearance.BackColor = GridFormater.ToColor(field.DCP_BackColor);
                        //}
                        //if (!string.IsNullOrEmpty(field.DCP_ForeColor)) //  前景颜色
                        //{
                        //    _refTextBox.Appearance.ForeColor = GridFormater.ToColor(field.DCP_ForeColor);
                        //}
                        if (field.DCP_IsReadonly == 1)
                        {
                            _refTextBox.ReadOnly = true;
                        }
                        _refTextBox.TextChanged += new EventHandler(_refTextBox_TextChanged);
                        ctr.Controls.Add(_refTextBox);
                        break;
                }
                #endregion

                if (field.DCP_ControlType == "textarea" && step + 2 < module.SPM_CNum - 2)
                {
                    vXPosition += fTI;//
                    step++;
                }
                else if (field.DCP_ControlType == "textarea" && step + 2 > module.SPM_CNum - 2)
                {
                    step = module.SPM_CNum - 1;

                    if (field.DCP_TI != 0 && field.DCP_TX != 0 && field.DCP_TY != 0 && field.DCP_Height != 0)
                    {
                        yPosition += fHeight;
                    }
                    else
                    {
                        yPosition += fHeight * 2 - 14; ;
                    }
                }

                vXPosition += fTI;
                if (step == module.SPM_CNum - 1)
                {
                    step = 0;
                    vXPosition = xPosition;
                    yPosition += module.SPM_Height;
                }
                else
                {
                    step++;
                }
            }
            ctr.KeyUp += new KeyEventHandler(ctr_KeyUp);
            ctr.DoubleClick += new EventHandler(ctr_DoubleClick);
        }

        void _numBox_DoubleClick(object sender, EventArgs e)
        {
            UltraNumericEditor ne = sender as UltraNumericEditor;
            MessageBox.Show(ne.Value.ToString());
        }

        void _refTextBox_TextChanged(object sender, EventArgs e)
        {
            UltraTextEditor _refTextBox = sender as UltraTextEditor;
            Sys_PD_Filed field = _refTextBox.Tag as Sys_PD_Filed;
            Sys_PD_RefModule refModule = new Sys_PD_RefModule();
            string sql = string.Empty;
            #region 处理其参考及带出
            if (!string.IsNullOrEmpty(field.DCP_RefSQL) && !string.IsNullOrEmpty(field.DCP_RefBack))
            {
                refModule = instRef.GetListByWhere(string.Format(" and SPR_RefModule='{0}'", field.DCP_RefSQL)).FirstOrDefault();//获取参考
                if (refModule != null)
                {
                    sql = string.Format(refModule.SPR_RefSQL.Trim(), _refTextBox.Text.Trim());
                    DataTable refDate = new DataTable();
                    refDate = instField.GetRefData(sql);
                    if (refDate.Rows.Count > 0)
                    {
                        //回写DCP_RefBack
                        string[] arr = field.DCP_RefBack.Split(',');
                        foreach (string controlInfo in arr)
                        {
                            string[] control = controlInfo.Split(':');
                            try
                            {
                                Control ct = _refTextBox.FindForm().Controls.Find(control[0].Trim(), true).FirstOrDefault();
                                if (ct.GetType() == typeof(UltraNumericEditor))
                                {
                                    UltraNumericEditor ne = _refTextBox.FindForm().Controls.Find(control[0].Trim(), true).FirstOrDefault() as UltraNumericEditor;
                                    ne.Value = refDate.Rows[0][control[1]].ToString().Trim();
                                }
                                else
                                {
                                    ct.Text = refDate.Rows[0][control[1]].ToString().Trim();
                                }
                            }
                            catch(Exception ex) {
                                throw ex;
                            }
                        }
                    }
                }
            }
            #endregion

            #region 处理下级控件
            //处理下级控件的情况
            if (!string.IsNullOrEmpty(field.DCP_CControl) && !string.IsNullOrEmpty(_refTextBox.Text))
            {
                Form frm = _refTextBox.FindForm();
                UltraCombo ccCom = frm.Controls.Find(field.DCP_CControl, true).FirstOrDefault() as UltraCombo;
                if (ccCom != null)
                {
                    ccCom.Enabled = true;// 处理下级控件的数据绑定
                    ResetChildControl(ccCom, field, _refTextBox.Text.ToString());
                }
            }
            #endregion
        }

        void ctr_DoubleClick(object sender, EventArgs e)
        {
            SystemInformationHelp helper = new SystemInformationHelp(sender);
            helper.Show();
        }

        public Size GenerateTipsForm(Sys_PD_Module module, List<Sys_PD_Filed> filedList, Control ctr, Point p)
        {
            Sys_PD_RefModule refModule = new Sys_PD_RefModule();
            ctr.Tag = module;
            ctr.Text = module.SPM_Name;

            int iTabInex = 0;
            int xPosition = p.X;
            int yPosition = p.Y;
            int vXPosition = p.X;
            int step = 0;//控制一行已经输出多少列
            int fTI = module.SPM_TI;
            int fTX = module.SPM_TX;
            int fTY = module.SPM_TY;
            int fHeight = module.SPM_Height;
            int controlWidth = 0;
            int controlHeight = 0;

            Size lableSize = new Size(module.SPM_LX, module.SPM_LY);//标签的大小
            Size textSize = new Size(fTX, fTY);//文本框的大小
            Size areaSize = new Size((fTX * 2) + module.SPM_LX + module.SPM_LI, fTY * 3);//备注框大小
            foreach (Sys_PD_Filed field in filedList)
            {

                if (field.DCP_IsHidden == 1)
                {
                    UltraTextEditor _hiddenBox = new UltraTextEditor();
                    _hiddenBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                    _hiddenBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                    _hiddenBox.Visible = false;
                    ctr.Controls.Add(_hiddenBox);
                    continue;
                }
                if (field.DCP_Style == "newline" ||
                    (field.DCP_ControlType == "textarea" &&
                    step > module.SPM_CNum - 2))
                {
                    step = 0;
                    vXPosition = xPosition;
                    yPosition += fHeight;
                }

                fTI = module.SPM_TI;
                fTX = module.SPM_TX;
                fTY = module.SPM_TY;
                fHeight = module.SPM_Height;
                textSize = new Size(fTX, fTY);//文本框的大小
                areaSize = new Size((fTX * 2) + module.SPM_LX + module.SPM_LI, fTY * 3);


                /////////如果字段有自定义的大小，则赋值到相关模块
                if (field.DCP_TI != 0 && field.DCP_TX != 0 && field.DCP_TY != 0 && field.DCP_Height != 0)
                {
                    textSize = new Size(field.DCP_TX, field.DCP_TY);
                    areaSize = new Size(field.DCP_TX, field.DCP_TY);
                    fTX = field.DCP_TX;
                    fTY = field.DCP_TY;
                    fTI = field.DCP_TI;
                    fHeight = field.DCP_Height;
                }

                Infragistics.Win.Misc.UltraLabel _lab = new Infragistics.Win.Misc.UltraLabel();
                _lab.Location = new Point(vXPosition, yPosition + 6);
                _lab.Name = module.SPM_LPrefix + field.DCP_ControlID.ToString();
                _lab.Size = lableSize;
                _lab.TabIndex = iTabInex++;
                _lab.Text = field.DCP_Label.ToString();
                ctr.Controls.Add(_lab);

                vXPosition += module.SPM_LI;

                #region 控件生成
                switch (field.DCP_ControlType)
                {
                    case "dec":
                        UltraNumericEditor _numBox = new UltraNumericEditor();
                        _numBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _numBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _numBox.Size = textSize;
                        _numBox.NumericType = NumericType.Double;
                        _numBox.TabIndex = iTabInex++;
                        _numBox.PromptChar = ' ';
                        _numBox.Nullable = true;
                        _numBox.NullText = "0";
                        if (field.DCP_IsReadonly == 1)
                        {
                            _numBox.ReadOnly = true;
                        }
                        ctr.Controls.Add(_numBox);
                        break;
                    case "int":
                        UltraNumericEditor _intBox = new UltraNumericEditor();
                        _intBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _intBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _intBox.Size = textSize;
                        _intBox.NumericType = NumericType.Integer;
                        _intBox.TabIndex = iTabInex++;
                        if (field.DCP_IsReadonly == 1)
                        {
                            _intBox.ReadOnly = true;
                        }
                        _intBox.PromptChar = ' ';
                        _intBox.Nullable = true;
                        _intBox.NullText = "";
                        ctr.Controls.Add(_intBox);
                        break;
                    case "text":
                        UltraTextEditor _textBox = new UltraTextEditor();
                        _textBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _textBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _textBox.Size = textSize;
                        _textBox.TabIndex = iTabInex++;
                        _textBox.Nullable = true;
                        if (field.DCP_IsReadonly == 1)
                        {
                            _textBox.ReadOnly = true;
                        }
                        ctr.Controls.Add(_textBox);
                        break;
                    case "textl":
                        UltraTextEditor _texBox = new UltraTextEditor();
                        _texBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _texBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _texBox.Size = new Size(textSize.Width * 2, textSize.Height);
                        _texBox.TabIndex = iTabInex++;
                        if (field.DCP_IsReadonly == 1)
                        {
                            _texBox.ReadOnly = true;
                        }
                        ctr.Controls.Add(_texBox);
                        step++;
                        vXPosition += (fTI + module.SPM_LI);
                        break;
                    case "textarea":

                        UltraTextEditor _mBox = new UltraTextEditor();
                        _mBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _mBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _mBox.Multiline = true;
                        _mBox.Size = areaSize;
                        _mBox.TabIndex = iTabInex++;
                        if (field.DCP_IsReadonly == 1)
                        {
                            _mBox.ReadOnly = true;
                        }
                        ctr.Controls.Add(_mBox);
                        break;
                    case "date":
                        UltraDateTimeEditor _dateCom = new UltraDateTimeEditor();
                        _dateCom.BackColor = System.Drawing.SystemColors.Window;
                        _dateCom.MaskInput = "yyyy-mm-dd";
                        _dateCom.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
                        _dateCom.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _dateCom.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _dateCom.Size = textSize;
                        _dateCom.TabIndex = iTabInex++;
                        _dateCom.Value = DateTime.Now;
                        _dateCom.PromptChar = ' ';
                        _dateCom.Nullable = true;
                        _dateCom.NullText = DateTime.Now.ToString();
                        if (field.DCP_IsReadonly == 1)
                        {
                            _dateCom.ReadOnly = true;
                        }
                        ctr.Controls.Add(_dateCom);
                        break;
                    case "time":
                        UltraDateTimeEditor _timeCom = new UltraDateTimeEditor();
                        _timeCom.BackColor = System.Drawing.SystemColors.Window;
                        _timeCom.MaskInput = "yyyy-mm-dd hh:mm";
                        _timeCom.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
                        _timeCom.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _timeCom.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _timeCom.Size = textSize;
                        _timeCom.TabIndex = iTabInex++;
                        _timeCom.Value = DateTime.Now;
                        _timeCom.PromptChar = ' ';
                        _timeCom.Nullable = true;
                        _timeCom.NullText = DateTime.Now.ToString();
                        if (field.DCP_IsReadonly == 1)
                        {
                            _timeCom.ReadOnly = true;
                        }
                        ctr.Controls.Add(_timeCom);
                        break;
                    case "dict":
                        UltraComboEditor _comEdit = new UltraComboEditor();
                        _comEdit.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _comEdit.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _comEdit.Size = textSize;
                        _comEdit.TabIndex = iTabInex++;
                        _comEdit.DropDownStyle = DropDownStyle.DropDownList;
                        _comEdit.Tag = field;
                        if (field.DCP_IsReadonly == 1)
                        {
                            _comEdit.ReadOnly = true;
                        }
                        _comEdit.ValueChanged += new EventHandler(_comEdit_ValueChanged);

                        ctr.Controls.Add(_comEdit);
                        //ExcuteWithReturnValue ddd = new ExcuteWithReturnValue(this.SetDictValue);

                        //ddd.BeginInvoke(_comEdit, field.DCP_Type, null, null);
                        SetDictValue(_comEdit, field.DCP_Type);
                        break;
                    case "ref":
                        #region UltraGrid 界面设置

                        UltraCombo uCom = new UltraCombo();
                        #endregion
                        uCom.Location = new System.Drawing.Point(vXPosition, yPosition);
                        uCom.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        uCom.Size = textSize;
                        uCom.TabIndex = iTabInex++;
                        uCom.Tag = field;
                        //uCom.Text =
                        ctr.Controls.Add(uCom);
                        //if (uCom.Value == null)
                        //{
                        //    uCom.Value = "";
                        //}

                        string sql = string.Empty;
                        if (!string.IsNullOrEmpty(field.DCP_RefSQL))
                        {
                            refModule = instRef.GetListByWhere(string.Format(" and SPR_RefModule='{0}'", field.DCP_RefSQL)).FirstOrDefault();//获取参考
                            if (refModule != null)
                            {
                                sql = string.Format(refModule.SPR_RefSQL.Trim(), "", "");
                                DataTable refDate = new DataTable();
                                refDate = instField.GetRefData(sql);
                                uCom.DataSource = refDate.DefaultView;
                                uCom.DisplayMember = refModule.SPR_RefData;
                                uCom.ValueMember = refModule.SPR_RefValue;
                            }
                        }
                        if (!string.IsNullOrEmpty(field.DCP_PControl))
                        {
                            uCom.Enabled = false;
                        }

                        uCom.ValueChanged += new EventHandler(uCom_ValueChanged);
                        //uCom.BeforeDropDown += new System.ComponentModel.CancelEventHandler(uCom_BeforeDropDown);
                        uCom.TextChanged += new EventHandler(uCom_TextChanged);
                        //uCom.LostFocus += new EventHandler(uCom_LostFocus);
                        //uCom.InitializeLayout += new InitializeLayoutEventHandler(uCom_InitializeLayout);

                        if (field.DCP_IsReadonly == 1)
                        {
                            uCom.ReadOnly = true;
                        }
                        break;
                }
                #endregion

                if (field.DCP_ControlType == "textarea" && step + 2 < module.SPM_CNum - 2)
                {
                    vXPosition += fTI;//
                    step++;
                }
                else if (field.DCP_ControlType == "textarea" && step + 2 > module.SPM_CNum - 2)
                {
                    step = module.SPM_CNum - 1;

                    if (field.DCP_TI != 0 && field.DCP_TX != 0 && field.DCP_TY != 0 && field.DCP_Height != 0)
                    {
                        yPosition += fHeight;
                    }
                    else
                    {
                        yPosition += fHeight * 2 - 14; ;
                    }
                }

                vXPosition += fTI;
                if (controlWidth < vXPosition)
                {
                    controlWidth = vXPosition;
                }
                if (controlHeight < yPosition + module.SPM_Height)
                {
                    controlHeight = yPosition + module.SPM_Height;
                }
                if (step == module.SPM_CNum - 1)
                {
                    step = 0;
                    vXPosition = xPosition;
                    yPosition += module.SPM_Height;
                }
                else
                {
                    step++;
                }
            }
            ctr.Height = controlHeight;
            Size point = new Size(controlWidth + 20, controlHeight + 10);
            ctr.KeyUp += new KeyEventHandler(ctr_KeyUp);
            return point;
        }
        void ctr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                SystemInformationHelp helper = new SystemInformationHelp(sender);
                helper.Show();
                return;
            }
        }

        void uCom_TextChanged(object sender, EventArgs e)
        {
            UltraCombo uCom = sender as UltraCombo;
            if (uCom == null)
                return;
            Sys_PD_Filed field = uCom.Tag as Sys_PD_Filed;
            try
            {
                uCom.DisplayLayout.Bands[0].ColumnFilters[field.DCP_RefCode].FilterConditions.Clear();
                uCom.DisplayLayout.Bands[0].ColumnFilters[field.DCP_RefValue].FilterConditions.Clear();


                uCom.DisplayLayout.Bands[0].ColumnFilters[field.DCP_RefCode].FilterConditions.Add(FilterComparisionOperator.Contains, uCom.Text);
                uCom.DisplayLayout.Bands[0].ColumnFilters[field.DCP_RefValue].FilterConditions.Add(FilterComparisionOperator.Contains, uCom.Text);

                uCom.DisplayLayout.Bands[0].ColumnFilters.LogicalOperator = FilterLogicalOperator.Or;
            }
            catch { }
        }




        #endregion

        #region 参考函数
        private void SetDictValue(UltraComboEditor _comEdit, string type)
        {
            var dict = instDict.GetListByWhere(string.Format(" and dict_key='{0}' and dict_code <>'{0}' order by dict_order ", type));

            _comEdit.DataSource = dict.ToList();
            _comEdit.DisplayMember = "Dict_Name";
            _comEdit.ValueMember = "Dict_Code";
            _comEdit.SelectedIndex = 0;

        }
        void _comEdit_ValueChanged(object sender, EventArgs e)
        {
            UltraComboEditor uCom = sender as UltraComboEditor;

            Sys_PD_Filed field = uCom.Tag as Sys_PD_Filed;
            //处理下级控件的情况
            if (!string.IsNullOrEmpty(field.DCP_CControl) && uCom.Value != null)
            {
                //处理多个子级控件
                string[] childControls = field.DCP_CControl.Split(',');
                Form frm = uCom.FindForm();
                foreach (string child in childControls)
                {
                    UltraCombo ccCom = frm.Controls.Find(child, true).FirstOrDefault() as UltraCombo;
                    if (ccCom != null)
                    {
                        ccCom.Enabled = true;// 处理下级控件的数据绑定
                        ResetChildControl(ccCom, field, uCom.Value.ToString());
                    }
                }
            }
            /////////////////////////////////////////////////
            //根据界面需求，将取得的数据回填到界面上
            if (!string.IsNullOrEmpty(field.DCP_PageName))//回写数据
            {
                string[] arr = field.DCP_PageName.Split(',');
                string prefix = uCom.Name.Replace(field.DCP_ControlID, " ").Trim();

                foreach (string name in arr)
                {
                    string controlId = prefix + name;

                    uCom.Parent.Controls[controlId].Text = uCom.Text;
                }
            }
        }


        void uCom_ValueChanged(object sender, EventArgs e)
        {
            UltraCombo uCom = sender as UltraCombo;
            //if (uCom.Value == null)
            //{
            //    uCom.Value = "";
            //}
            Sys_PD_Filed field = uCom.Tag as Sys_PD_Filed;
            //处理下级控件的情况
            if (!string.IsNullOrEmpty(field.DCP_CControl) && uCom.Value != null)
            {
                //处理多个子级控件
                string[] childControls = field.DCP_CControl.Split(',');
                Form frm = uCom.FindForm();
                foreach (string child in childControls)
                {
                    UltraCombo ccCom = frm.Controls.Find(child, true).FirstOrDefault() as UltraCombo;
                    if (ccCom != null)
                    {
                        ccCom.Enabled = true;// 处理下级控件的数据绑定
                        ResetChildControl(ccCom, field, uCom.Value.ToString());
                    }
                }
            }


            /////////////////////////////////////////////////
            //根据界面需求，将取得的数据回填到界面上
            if (!string.IsNullOrEmpty(field.DCP_PageName))//回写数据
            {
                string[] arrCol = field.DCP_PageName.Split(',');
                foreach (string name in arrCol)
                {
                    try
                    {
                        uCom.Parent.Controls[name].Text = uCom.Text;
                    }
                    catch { }
                }
            }
            if (!string.IsNullOrEmpty(field.DCP_RefBack))//回写数据
            {
                //回写DCP_RefBack
                string[] arr = field.DCP_RefBack.Split(',');
                foreach (string controlInfo in arr)
                {
                    try
                    {
                        string[] control = controlInfo.Split(':');
                        Control ct = uCom.FindForm().Controls.Find(control[0].Trim(), true).FirstOrDefault();
                        ct.Text = uCom.SelectedRow.Cells[control[1]].Value.ToString();
                    }
                    catch { }
                }
            }
        }

        void ResetChildControl(UltraCombo ccCom, Sys_PD_Filed field, string parentValue)
        {
            try
            {
                Sys_PD_Module module = ccCom.Parent.Tag as Sys_PD_Module;
                Sys_PD_Filed cField = new Sys_PD_Filed(); 
                Sys_PD_RefModule refModule = new Sys_PD_RefModule();

                string sql = string.Empty;
                if (ccCom != null) //如果是UltraCombo
                {
                    cField = ccCom.Tag as Sys_PD_Filed;

                    if (!string.IsNullOrEmpty(cField.DCP_RefSQL))
                    {
                        refModule = instRef.GetListByWhere(string.Format(" and SPR_RefModule='{0}'", cField.DCP_RefSQL)).FirstOrDefault();//获取参考
                        if (refModule != null)
                        {
                            sql = string.Format(refModule.SPR_RefSQL.Trim(), parentValue);
                            DataTable refDate = new DataTable();
                            refDate = instField.GetRefData(sql);
                            ccCom.DataSource = refDate.DefaultView;
                            ccCom.DisplayMember = refModule.SPR_RefData;
                            ccCom.ValueMember = refModule.SPR_RefValue;
                        }
                    }
                }
            }
            catch { }
        }
        void uCom_BeforeDropDown(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UltraCombo uCom = sender as UltraCombo;
            //if (uCom.Value == null)
            //{
            //    uCom.Value = "";
            //}

            Sys_PD_Filed field = uCom.Tag as Sys_PD_Filed;
            Sys_PD_RefModule refModule = new Sys_PD_RefModule();
            refModule = instRef.GetListByWhere(string.Format(" and SPR_RefModule='{0}'", field.DCP_RefSQL)).FirstOrDefault();
            if (refModule == null)
            {
                return;
            }
            string sql = string.Empty;
            //处理有上级控件的情况
            if (!string.IsNullOrEmpty(field.DCP_PControl))
            {
                uCom.Enabled = true;
                Form frm = uCom.FindForm();

                UltraCombo ultra = new UltraCombo();
                UltraComboEditor ultrEditor = new UltraComboEditor();
                Control ct = new Control();
                string pValue = "";
                ct = frm.Controls.Find(field.DCP_PControl, true).FirstOrDefault();

                if (ct.GetType() == typeof(UltraCombo))
                {
                    ultra = ct as UltraCombo;
                    pValue = ultra.Value.ToString();
                }
                else if (ct.GetType() == typeof(UltraComboEditor))
                {
                    ultrEditor = ct as UltraComboEditor;
                    pValue = ultrEditor.Value.ToString();
                }
            }
            else
            {
            }
        }
        #endregion

        #region 生成Label列表

        public List<Label> GenerateLabelList(string moduleName, Control ctr)
        {

            List<Label> list = new List<Label>();
            Sys_PD_Module module = new Sys_PD_Module();
            module = instModule.GetListByWhere(" and SPM_Module='" + moduleName + "'").FirstOrDefault();
            List<Sys_PD_Filed> filedList = new List<Sys_PD_Filed>();
            filedList = instField.GetListByWhere(" and DCP_ModuleName='" + moduleName + "' order by DCP_Order").ToList();


            ctr.Tag = module;
            Point p = new Point(module.SPM_LX, module.SPM_LY);
            int iTabInex = 0;
            int xPosition = p.X;
            int yPosition = p.Y;
            int vXPosition = p.X;
            int fHeight = module.SPM_Height;
            foreach (Sys_PD_Filed field in filedList)
            {
                if (field.DCP_Style == "newline")//换行，则将高度增加，横向坐标返回原坐标
                {
                    vXPosition = xPosition;
                    yPosition += fHeight;
                }

                //打印数据项的说明
                Label _labDesp = new Label();
                _labDesp.Location = new Point(vXPosition, yPosition);
                _labDesp.Name = "d" + field.DCP_ControlID.ToString();
                _labDesp.Size = new Size(int.Parse(field.DCP_Udef1), int.Parse(field.DCP_Udef2));
                _labDesp.TabIndex = iTabInex++;
                _labDesp.Text = field.DCP_Label + ":";
                ctr.Controls.Add(_labDesp);

                vXPosition += int.Parse(field.DCP_PageName);
                //if (field.DCP_IsHidden == 1)
                //{
                //    UltraTextEditor _hiddenBox = new UltraTextEditor();
                //    _hiddenBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                //    _hiddenBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                //    _hiddenBox.Visible = false;
                //    ctr.Controls.Add(_hiddenBox);
                //    continue;
                //}

                #region 控件生成

                Label _lab = new Label();
                _lab.Location = new Point(vXPosition, yPosition);
                _lab.Name = field.DCP_ControlID.ToString();
                _lab.Size = new Size(field.DCP_TX, field.DCP_TY);
                _lab.TabIndex = iTabInex++;
                _lab.Text = "";
                _lab.Tag = field;
                //if (field.DCP_ControlType == "ref")
                //{
                //    #region
                //    string sql = string.Empty;
                //    if (!string.IsNullOrEmpty(field.DCP_RefSQL))
                //    {
                //        refModule = instRef.GetListByWhere(string.Format(" and SPR_RefModule='{0}'", field.DCP_RefSQL)).FirstOrDefault();//获取参考
                //        if (refModule != null)
                //        {
                //            sql = string.Format(refModule.SPR_RefSQL.Trim(), "", "");
                //            DataTable refDate = new DataTable();
                //            refDate = instField.GetRefData(sql);
                //        }
                //    }
                //    #endregion
                //}

                list.Add(_lab);
                ctr.Controls.Add(_lab);
                vXPosition += field.DCP_TI;
                //_lab.DoubleClick += new EventHandler(_lab_DoubleClick);

                #endregion
            }
            return list;
        }

        void _lab_DoubleClick(object sender, EventArgs e)
        {
            Label lab = sender as Label;
            MessageBox.Show(lab.Location.ToString() + "    " + lab.Size.ToString());
        }
        #endregion

    }
}

