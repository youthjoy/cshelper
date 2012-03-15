using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QX.Model;
using QX.DAL;
//using BC.Shared;
using System.Drawing;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinSchedule;
using Infragistics.Win.UltraWinGrid;
using System.Data;

namespace BC.ControlGen
{
    internal class GridTagObject
    {
        public Sys_PD_Module Module
        {
            get;
            set;
        }

        public string GridValuePrefix
        {
            get;
            set;
        }
    }

    public class ContrlGenerate
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

        delegate void ExcuteWithReturnValue(UltraComboEditor uce, string type);

        #region 生成Form表单
        public void GenerateForm(string moduleName, Control ctr, Point p)
        {
            Sys_PD_Module module = new Sys_PD_Module();
            module = instModule.GetListByWhere(" and SPM_Module='" + moduleName + "'").ToList()[0];
            List<Sys_PD_Filed> filedList = new List<Sys_PD_Filed>();
            filedList = instField.GetListByWhere(" and DCP_ModuleName='" + moduleName + "' order by DCP_Order").ToList();
            Sys_PD_RefModule refModule = new Sys_PD_RefModule();

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
            Size textSize = new Size(fTX,fTY);//文本框的大小
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
                if (field.DCP_Style == "newline"||
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
                if (field.DCP_TI != 0 && field.DCP_TX != 0 && field.DCP_TY != 0&&field.DCP_Height!=0)
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
                        ctr.Controls.Add(_intBox);
                        break;
                    case "text":
                        UltraTextEditor _textBox = new UltraTextEditor();
                        _textBox.Location = new System.Drawing.Point(vXPosition, yPosition);
                        _textBox.Name = module.SPM_TPrefix + field.DCP_ControlID;
                        _textBox.Size = textSize;
                        _textBox.TabIndex = iTabInex++;
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
                        _texBox.Size = new Size(textSize.Width*2,textSize.Height);
                        _texBox.TabIndex = iTabInex++;
                        if (field.DCP_IsReadonly == 1)
                        {
                            _texBox.ReadOnly = true;
                        }
                        ctr.Controls.Add(_texBox);
                        step++;
                        vXPosition += (fTI+module.SPM_LI);
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
                        ExcuteWithReturnValue ddd = new ExcuteWithReturnValue(this.SetDictValue);

                        ddd.BeginInvoke(_comEdit, field.DCP_Type, null, null);
                        break;
                    case "ref":
                        #region UltraGrid 界面设置
                       

                        UltraCombo uCom = new UltraCombo();
                        //uCom.CheckedListSettings.CheckStateMember = "";
                        //uCom.DisplayLayout.Appearance = comDispAppear;
                        //uCom.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                        //uCom.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
                        //uCom.DisplayLayout.GroupByBox.Appearance = comGroupByboxAppear;
                        //uCom.DisplayLayout.GroupByBox.BandLabelAppearance = comGroupByboxBandLabelAppear;
                        //uCom.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                        //uCom.DisplayLayout.GroupByBox.PromptAppearance = comGroupByboxPromtAppear;
                        //uCom.DisplayLayout.MaxColScrollRegions = 1;
                        //uCom.DisplayLayout.MaxRowScrollRegions = 1;
                        //uCom.DisplayLayout.Override.ActiveCellAppearance = comActiCellAppear;
                        //uCom.DisplayLayout.Override.ActiveRowAppearance = comActiRowAppear;
                        //uCom.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
                        //uCom.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
                        //uCom.DisplayLayout.Override.CardAreaAppearance = comCardAreaAppear;
                        //uCom.DisplayLayout.Override.CellAppearance = comCellAppear;
                        //uCom.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                        //uCom.DisplayLayout.Override.CellPadding = 0;
                        //uCom.DisplayLayout.Override.GroupByRowAppearance = comGroupByRowAppear;
                        //uCom.DisplayLayout.Override.HeaderAppearance = comHearderAppear;
                        //uCom.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
                        //uCom.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
                        //uCom.DisplayLayout.Override.RowAppearance = comRowAppear;
                        //uCom.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
                        //uCom.DisplayLayout.Override.TemplateAddRowAppearance = comTemplRowAppear;
                        //uCom.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
                        //uCom.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
                        //uCom.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
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
                                //if (!string.IsNullOrEmpty(field.DCP_PControl))
                                //{
                                    sql = string.Format(refModule.SPR_RefSQL.Trim(), uCom.Text, "");
                                //}
                                //else
                                //{
                                //    sql = string.Format(refModule.SPR_RefSQL.Trim(), uCom.Text);
                                //}

                                DataTable refDate = new DataTable();
                                refDate = instField.GetRefData(sql);
                                uCom.DataSource = refDate.DefaultView;
                                uCom.DisplayMember = refModule.SPR_RefData;
                                uCom.ValueMember = refModule.SPR_RefValue;
                                //uCom.DataBind();
                            }
                        }
                        if (!string.IsNullOrEmpty(field.DCP_PControl))
                        {
                            uCom.Enabled = false;
                        }

                        uCom.ValueChanged += new EventHandler(uCom_ValueChanged);
                        uCom.BeforeDropDown += new System.ComponentModel.CancelEventHandler(uCom_BeforeDropDown);
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

        #region 生成Grid
        public UltraGrid GenerateGrid(string moduleName, Control ctr, Point p)
        {
            Sys_PD_Module module = new Sys_PD_Module();
            
            module = instModule.GetListByWhere(" and SPM_Module='" + moduleName + "'").ToList()[0];
            //List<Sys_PD_Filed> filedList = new List<Sys_PD_Filed>();
            //filedList = instField.GetListByWhere(" and DCP_ModuleName='" + moduleName + "' order by DCP_Order").ToList();
            GridTagObject gridObj = new GridTagObject();
            gridObj.Module = module;
            gridObj.GridValuePrefix = "";

            UltraGrid ug_list = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ctr.Tag = module;
            ug_list.Location = p;
            ug_list.Name = module.SPM_LPrefix + module.SPM_Module;//grid的技术名称
            ug_list.Tag = gridObj;
            ug_list.Size = new System.Drawing.Size(module.SPM_LX, module.SPM_LY);
            ug_list.Dock = DockStyle.Fill;
            ug_list.Text = module.SPM_Name;

            #region 默认样式初始化
            ug_list.DisplayLayout.Bands[0].Override.ActiveRowAppearance = GridFormater.GetGridAppearence(IGridAppearence.ActiveRow.ToString());
            ug_list.DisplayLayout.Bands[0].Override.RowSelectorAppearance = GridFormater.GetGridAppearence(IGridAppearence.RowSelector.ToString());
            ug_list.DisplayLayout.Bands[0].Override.HeaderAppearance = GridFormater.GetGridAppearence(IGridAppearence.Header.ToString());
            ug_list.DisplayLayout.Bands[0].Override.CellAppearance = GridFormater.GetGridAppearence(IGridAppearence.Cell.ToString());
            ug_list.DisplayLayout.Bands[0].Override.RowAppearance = GridFormater.GetGridAppearence(IGridAppearence.Row.ToString());
            ug_list.DisplayLayout.CaptionAppearance = GridFormater.GetGridAppearence(IGridAppearence.Caption.ToString());
            ug_list.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            //ug_list.DisplayLayout.Override.RowSelectorStyle = HeaderStyle.WindowsXPCommand;
            ug_list.DisplayLayout.EmptyRowSettings.ShowEmptyRows = true;
            ug_list.DisplayLayout.EmptyRowSettings.Style = EmptyRowStyle.ExtendRowSelector;
            ug_list.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;

            #endregion


            ug_list.AfterColPosChanged += new AfterColPosChangedEventHandler(ug_list_AfterColPosChanged);
            ug_list.InitializeLayout += new InitializeLayoutEventHandler(ug_list_InitializeLayout);
            ug_list.KeyUp += new KeyEventHandler(ug_list_KeyUp);
            ug_list.CellChange += new CellEventHandler(ug_list_CellChange);
            ug_list.BeforeCellListDropDown += new CancelableCellEventHandler(ug_list_BeforeCellListDropDown);
            ctr.Controls.Add(ug_list);
            return ug_list;
        }
        /// <summary>
        /// 用于生成某列需要输入值的Gird
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="ctr"></param>
        /// <param name="p"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public UltraGrid GenerateGrid(string moduleName, Control ctr, Point p,string prefix)
        {
            Sys_PD_Module module = new Sys_PD_Module();
            module = instModule.GetListByWhere(" and SPM_Module='" + moduleName + "'").ToList()[0];
            //List<Sys_PD_Filed> filedList = new List<Sys_PD_Filed>();
            //filedList = instField.GetListByWhere(" and DCP_ModuleName='" + moduleName + "' order by DCP_Order").ToList();
            GridTagObject gridObj = new GridTagObject();
            gridObj.Module = module;
            gridObj.GridValuePrefix = prefix;
            UltraGrid ug_list = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ug_list.Location = p;
            ug_list.Name = module.SPM_LPrefix + module.SPM_Module;//grid的技术名称
            ug_list.Tag = gridObj;
            ug_list.Size = new System.Drawing.Size(module.SPM_LX, module.SPM_LY);
            ug_list.Dock = DockStyle.Fill;
            ug_list.Text = module.SPM_Name;

            #region 默认样式初始化
            ug_list.DisplayLayout.Bands[0].Override.ActiveRowAppearance.BackColor = Color.YellowGreen;
            ug_list.DisplayLayout.Bands[0].Override.RowSelectorAppearance.BackColor = Color.SteelBlue;
            ug_list.DisplayLayout.Bands[0].Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ug_list.DisplayLayout.Override.CellAppearance.BorderColor = Color.SteelBlue;
            ug_list.DisplayLayout.Override.RowAppearance.BorderColor = Color.SteelBlue;

            ug_list.DisplayLayout.CaptionAppearance.BackColor = Color.SteelBlue;
            ug_list.DisplayLayout.CaptionAppearance.FontData.Name = "宋体";
            ug_list.DisplayLayout.CaptionAppearance.FontData.SizeInPoints = 11;
            ug_list.DisplayLayout.Bands[0].Override.RowAppearance.FontData.Name = "宋体";
            ug_list.DisplayLayout.Bands[0].Override.ActiveRowAppearance.FontData.Name = "宋体";
            ug_list.DisplayLayout.Bands[0].Override.RowAppearance.FontData.SizeInPoints = 10;
            ug_list.DisplayLayout.Bands[0].Override.ActiveRowAppearance.FontData.SizeInPoints = 10;

            ug_list.DisplayLayout.EmptyRowSettings.ShowEmptyRows = true;
            ug_list.DisplayLayout.EmptyRowSettings.Style = EmptyRowStyle.ExtendRowSelector;
            ug_list.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;

            #endregion

            ug_list.AfterColPosChanged += new AfterColPosChangedEventHandler(ug_list_AfterColPosChanged);
            ug_list.InitializeLayout += new InitializeLayoutEventHandler(ug_list_InitializeLayout);
            ug_list.KeyUp += new KeyEventHandler(ug_list_KeyUp);
            ug_list.CellChange += new CellEventHandler(ug_list_CellChange);
            ug_list.BeforeCellListDropDown += new CancelableCellEventHandler(ug_list_BeforeCellListDropDown);
            ug_list.InitializeRow += new InitializeRowEventHandler(ug_list_InitializeRow);
            ctr.Controls.Add(ug_list);
            return ug_list;
        }

        void ug_list_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            GridTagObject gridObj = ug_list.Tag as GridTagObject;
            string prefix = gridObj.GridValuePrefix;
            string _colType = prefix+"_Type";
            string _dictKey = prefix+"_DictKey";
            string _colValue = prefix+"_VCol";
            
            if (ug_list.DisplayLayout.Bands[0].Columns.Exists(_colType) && ug_list.DisplayLayout.Bands[0].Columns.Exists(_dictKey) &&
                ug_list.DisplayLayout.Bands[0].Columns.Exists(_colValue))/////包含三行的时候则调用
            {
                string[] col = e.Row.Cells[_colValue].Value.ToString().Split(',');
                switch (e.Row.Cells[_colType].Value.ToString().ToLower())
                {
                    case "dec":
                        e.Row.Cells[col[1]].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
                        e.Row.Cells[col[0]].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
                        break;
                    case "check":
                        e.Row.Cells[col[0]].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        e.Row.Cells[col[1]].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        break;
                    case "oshow":
                        e.Row.Appearance.BackColor = Color.Yellow;
                        break;
                    case "cdict":
                        ValueList valueList = new ValueList();
                        string[] dic = e.Row.Cells[_dictKey].Value.ToString().Split(',');
                        foreach (var obj in dic)
                        {
                            valueList.ValueListItems.Add(obj, obj);
                        }
                        e.Row.Cells[col[0]].ValueList = valueList;
                        e.Row.Cells[col[1]].ValueList = valueList;
                        e.Row.Cells[col[1]].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                        
                        //List<InternalDiction> listDic = new List<InternalDiction>();
                        //string[] dic = e.Row.Cells[_dictKey].Value.ToString().Split(',');
                        //foreach (string s in dic)
                        //{
                        //    listDic.Add(new InternalDiction { DisplayMember=s, ValueMember=s});
                        //}
                        //UltraComboEditor d = new UltraComboEditor();
                        //d.DataSource = listDic;
                        //d.DataMember = "DisplayMember";
                        //d.ValueMember = "ValueMember";
                        //e.Row.Cells[col[0]].EditorControl = d;
                        //e.Row.Cells[col[1]].EditorControl = d;
                        break;
                }
                //e.Row.Cells[_colValue].Editor = 
            }
        }

        void ug_list_BeforeCellListDropDown(object sender, CancelableCellEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            UltraGridCell cell = ug_list.ActiveCell;
            if (cell == null)
            {
                return;
            }
            Sys_PD_Filed field = cell.Column.Tag as Sys_PD_Filed;            

            if (field.DCP_ControlType == "ref")
            {
                UltraDropDown drop = cell.Column.ValueList as UltraDropDown;
                drop.Rows.ColumnFilters[field.DCP_RefValue].FilterConditions.Clear();
                drop.Rows.ColumnFilters[field.DCP_RefValue].FilterConditions.Add(FilterComparisionOperator.Contains, cell.Text);
                if (!string.IsNullOrEmpty(field.DCP_PControl))
                {
                    string[] pControl = field.DCP_PControl.Split(',');
                    drop.Rows.ColumnFilters[pControl[1]].FilterConditions.Clear();

                    if (cell.Row.Cells[pControl[0]].Value != null)
                    {
                        drop.Rows.ColumnFilters[pControl[1]].FilterConditions.Add(FilterComparisionOperator.Contains, cell.Row.Cells[pControl[0]].Value.ToString());
                    }
                    else
                    {
                        drop.Rows.ColumnFilters[pControl[1]].FilterConditions.Add(FilterComparisionOperator.Contains, "");
                    }
                }
            }
        }

        void ug_list_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            UltraGridCell cell = e.Cell;
            Sys_PD_Filed field = cell.Column.Tag as Sys_PD_Filed;
            EmbeddableEditorBase editor = e.Cell.EditorResolved;
            object value = editor.IsValid ? editor.Value : editor.CurrentEditText;
            e.Cell.Value = value;
            if (field.DCP_ControlType == "ref")
            {
                UltraDropDown drop = cell.Column.ValueList as UltraDropDown;
                drop.Rows.ColumnFilters.ClearAllFilters();
                drop.Rows.ColumnFilters[field.DCP_RefValue].FilterConditions.Add(FilterComparisionOperator.Contains, cell.Text);
                drop.Rows.ColumnFilters[field.DCP_RefCode].FilterConditions.Add(FilterComparisionOperator.Contains, cell.Text);
                drop.Rows.ColumnFilters.LogicalOperator = FilterLogicalOperator.Or;
            }
            if (!string.IsNullOrEmpty(field.DCP_PageName))
            {
                e.Cell.Row.Cells[field.DCP_PageName].Value = e.Cell.Text;
            }
        }


        #endregion


        #region 列初始化
        void ug_list_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            Sys_PD_RefModule refModule = new Sys_PD_RefModule();
            int i = 0;

            //ug_list.ResetDisplayLayout();
            //绑定每一列，并修改表头
            Sys_PD_Module module = new Sys_PD_Module();
            GridTagObject gridObj = ug_list.Tag as GridTagObject;
            module = gridObj.Module;
            //module = ug_list.Tag as Sys_PD_Module;
            List<Sys_PD_Filed> filedList = new List<Sys_PD_Filed>();
            filedList = instField.GetListByWhere(" and DCP_ModuleName='" + module.SPM_Module + "' order by DCP_Order ASC").ToList();


            //			 e.Layout.Bands[0].Columns["price"].MaskInput= "$#,###.##";

            Infragistics.Win.UltraWinGrid.UltraGridColumn ugCol;
            for (i = 0; i < e.Layout.Bands[0].Columns.Count; i++)//使所有的都不能编辑
            {
                ugCol = e.Layout.Bands[0].Columns[i];
                //使其不能在Grid上编辑
                ugCol.CellActivation = Activation.NoEdit;
                ugCol.Hidden = true;
            }
            foreach (Sys_PD_Filed field in filedList)
            {
                UltraGridBand band = e.Layout.Bands[0];
                if (band.Columns.Exists(field.DCP_ControlID))
                {
                    band.Columns[field.DCP_ControlID].Header.Caption = field.DCP_Label;
                    band.Columns[field.DCP_ControlID].Hidden = field.DCP_IsHidden == 1 ? true : false;
                    band.Columns[field.DCP_ControlID].Tag = field;
                    band.Columns[field.DCP_ControlID].Header.VisiblePosition = field.DCP_Order;
                }
                if (band.Columns.Exists(field.DCP_ControlID))
                {
                    band.Columns[field.DCP_ControlID].CellActivation = Activation.AllowEdit;
                }

                //绑定编辑的控件
                switch (field.DCP_ControlType)
                {
                    case "text":
                        if (field.DCP_IsReadonly == 1)
                        {
                            band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                        }
                        break;
                    case "dec":

                        if (band.Columns.Exists(field.DCP_ControlID))
                        {
                            band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double;

                            if (field.DCP_IsReadonly == 1)
                            {
                                band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                            }
                        }

                        break;
                    case "int":
                        if (band.Columns.Exists(field.DCP_ControlID))
                        {
                            band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;

                            if (field.DCP_IsReadonly == 1)
                            {
                                band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                            }
                        }
                        break;
                    case "check":
                        if (band.Columns.Exists(field.DCP_ControlID))
                        {
                            band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

                            if (field.DCP_IsReadonly == 1)
                            {
                                band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                            }
                        }
                        break;
                    case "date":
                        if (band.Columns.Exists(field.DCP_ControlID))
                        {
                            band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateWithSpin;
                            band.Columns[field.DCP_ControlID].MaskInput = "yyyy-mm-dd";

                            if (field.DCP_IsReadonly == 1)
                            {
                                band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                            }
                        }
                        break;
                    case "time":
                        if (band.Columns.Exists(field.DCP_ControlID))
                        {
                            band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTimeWithSpin;
                            band.Columns[field.DCP_ControlID].MaskInput = "yyyy-mm-dd hh:mm:ss";

                            if (field.DCP_IsReadonly == 1)
                            {
                                band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                            }
                        }
                        break;
                    case "dict":
                        var dict = instDict.GetListByWhere(string.Format(" and dict_key='{0}' and dict_code <>'{0}' order by dict_order ", field.DCP_Type));
                        var valueList = new ValueList();
                        foreach (var obj in dict)
                        {
                            valueList.ValueListItems.Add(obj.Dict_Code, obj.Dict_Name);
                        }

                        if (band.Columns.Exists(field.DCP_ControlID))
                        {
                            band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                            band.Columns[field.DCP_ControlID].ValueList = valueList;
                            band.Columns[field.DCP_ControlID].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;

                            if (field.DCP_IsReadonly == 1)
                            {
                                band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                            }
                        }
                        break;
                    case "ref":
                        //e.Layout.Bands[0].Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.ul;
                        UltraDropDown drop = new UltraDropDown();
                        string sql = string.Format(field.DCP_RefSQL, "");

                        refModule = instRef.GetListByWhere(string.Format(" and SPR_RefModule='{0}'", field.DCP_RefSQL)).FirstOrDefault();


                        if (refModule != null)
                        {
                            sql = refModule.SPR_RefSQL.Trim();
                            DataTable refDate = new DataTable();
                            refDate = instField.GetRefData(sql);
                            drop.DataSource = refDate.DefaultView;
                            drop.DisplayMember = field.DCP_RefValue;
                            drop.ValueMember = field.DCP_RefCode;

                            drop.Tag = field;

                            //drop.v += new EventHandler(drop_TextChanged);
                            if (band.Columns.Exists(field.DCP_ControlID))
                            {
                                band.Columns[field.DCP_ControlID].ValueList = drop;
                                band.Columns[field.DCP_ControlID].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;

                                if (field.DCP_IsReadonly == 1)
                                {
                                    band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                                }

                            }


                            drop.Rows.ColumnFilters[field.DCP_RefValue].FilterConditions.Add(FilterComparisionOperator.Contains, drop.Text);
                        }
                        break;
                }
            }
            GridFormater.RetrieveSetGridFormat(ug_list, ug_list.DisplayLayout.Bands[0], module.SPM_Module, SessionConfig.UserID);
        }


        private void ug_list_AfterColPosChanged(object sender, Infragistics.Win.UltraWinGrid.AfterColPosChangedEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            Sys_PD_Module module = new Sys_PD_Module();
            //module = ug_list.Tag as Sys_PD_Module;
            GridTagObject gridObj = ug_list.Tag as GridTagObject;
            module = gridObj.Module;
            GridFormater.SaveGridFormat(ug_list.DisplayLayout.Bands[0], module.SPM_Module, SessionConfig.UserID);
        }
        void ug_list_KeyUp(object sender, KeyEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            UltraGridRow aRow = ug_list.ActiveRow;
            UltraGridCell aCell = ug_list.ActiveCell;
            if (aCell != null)
            {
                Sys_PD_Filed field = aCell.Column.Tag as Sys_PD_Filed;
                if (field != null && field.DCP_ControlType == "ref")
                {
                    return;
                }
            }
            int i = 0;
            int cIndex = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (aRow == null)
                    i = 0;
                else
                {
                    i = aRow.Index + 1;
                }
                if (aCell == null)
                {
                    cIndex = 0;
                }
                else
                {
                    cIndex = aCell.Column.Index;
                }
                if (i > ug_list.Rows.Count - 1)
                {
                    i = 0;
                }
                if (i > -1 && i < ug_list.Rows.Count)
                {
                    ug_list.ActiveRow = ug_list.Rows[i];
                    ug_list.ActiveCell = ug_list.Rows[i].Cells[cIndex];
                    ug_list.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (aRow == null)
                    i = 0;
                else
                {
                    i = aRow.Index - 1;
                }
                if (aCell == null)
                {
                    cIndex = 0;
                }
                else
                {
                    cIndex = aCell.Column.Index;
                }
                if (i < 0)
                {
                    i = ug_list.Rows.Count - 1;
                }
                ug_list.ActiveRow = ug_list.Rows[i];
                ug_list.ActiveCell = ug_list.Rows[i].Cells[cIndex];
                ug_list.PerformAction(UltraGridAction.EnterEditMode);
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (aRow == null)
                    i = 0;
                else
                {
                    i = aRow.Index + 1;
                }
                if (aCell == null)
                {
                    cIndex = 0;
                }
                else
                {
                    cIndex = aCell.Column.Index;
                }
                if (i > ug_list.Rows.Count - 1)
                {
                    i = 0;
                }
                ug_list.ActiveRow = ug_list.Rows[i];
                ug_list.ActiveCell = ug_list.Rows[i].Cells[cIndex];
                ug_list.PerformAction(UltraGridAction.EnterEditMode);
            }
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
                Form frm = uCom.FindForm();
                Control ct = new Control();
                ct = frm.Controls.Find(field.DCP_CControl, true).FirstOrDefault();
                if (ct != null)
                {
                    ct.Enabled = true;//
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
                Form frm = uCom.FindForm();
                Control ct = new Control();
                ct = frm.Controls.Find(field.DCP_CControl, true).FirstOrDefault();
                if (ct != null)
                {
                    ct.Enabled = true;//
                }
            }


            /////////////////////////////////////////////////
            //根据界面需求，将取得的数据回填到界面上
            if (!string.IsNullOrEmpty(field.DCP_PageName))//回写数据
            {
                string[] arrCol = field.DCP_PageName.Split(',');
                foreach (string name in arrCol)
                {
                    uCom.Parent.Controls[name].Text = uCom.Text;
                }
                
            }
            //回写DCP_RefBack
            if (!string.IsNullOrEmpty(field.DCP_RefBack))//回写数据
            {
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
        
    }
}

