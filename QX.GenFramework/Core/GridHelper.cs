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
using QX.GenFramework.Model;
using QX.GenFramework.ADO;
using Infragistics.Win.SupportDialogs.FilterUIProvider;
using QX.Shared;

namespace QX.GenFramework.AutoForm
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

    public class GridHelper
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
            GridFormater.SetGridStyle(ug_list);
            #endregion


            ug_list.AfterColPosChanged += new AfterColPosChangedEventHandler(ug_list_AfterColPosChanged);
            ug_list.InitializeLayout += new InitializeLayoutEventHandler(ug_list_InitializeLayout);
            ug_list.KeyUp += new KeyEventHandler(ug_list_KeyUp);
            ug_list.CellChange += new CellEventHandler(ug_list_CellChange);
            ug_list.BeforeCellListDropDown += new CancelableCellEventHandler(ug_list_BeforeCellListDropDown);
            ctr.Controls.Add(ug_list);
            return ug_list;
        }

        public UltraGrid GenerateColumn(string moduleName, UltraGrid ug_list, Point p)
        {
            Sys_PD_Module module = new Sys_PD_Module();

            module = instModule.GetListByWhere(" and SPM_Module='" + moduleName + "'").ToList()[0];
            //List<Sys_PD_Filed> filedList = new List<Sys_PD_Filed>();
            //filedList = instField.GetListByWhere(" and DCP_ModuleName='" + moduleName + "' order by DCP_Order").ToList();
            GridTagObject gridObj = new GridTagObject();
            gridObj.Module = module;
            gridObj.GridValuePrefix = "";

            //UltraGrid ug_list = new Infragistics.Win.UltraWinGrid.UltraGrid();
            //ctr.Tag = module;
            ug_list.Location = p;
            ug_list.Name = module.SPM_LPrefix + module.SPM_Module;//grid的技术名称
            ug_list.Tag = gridObj;
            ug_list.Size = new System.Drawing.Size(module.SPM_LX, module.SPM_LY);
            ug_list.Dock = DockStyle.Fill;
            ug_list.Text = module.SPM_Name;
            ug_list.DisplayLayout.GroupByBox.Prompt = "请把要分组的列拖放到此处";
            #region 默认样式初始化
            GridFormater.SetGridStyle(ug_list);
            //ug_list.DisplayLayout.Override.AllowGroupBy = DefaultableBoolean.True;
            //ug_list.DisplayLayout.GroupByBox.Hidden = false;
            //ug_list.DisplayLayout.Override.GroupByColumnsHidden = DefaultableBoolean.False;
            #endregion


            ug_list.AfterColPosChanged += new AfterColPosChangedEventHandler(ug_list_AfterColPosChanged);
            ug_list.InitializeLayout += new InitializeLayoutEventHandler(ug_list_InitializeLayout);
            ug_list.KeyUp += new KeyEventHandler(ug_list_KeyUp);
            ug_list.CellChange += new CellEventHandler(ug_list_CellChange);
            ug_list.BeforeCellListDropDown += new CancelableCellEventHandler(ug_list_BeforeCellListDropDown);
            //ctr.Controls.Add(ug_list);
            return ug_list;
        }

        /// <summary>
        /// 用于生成某列需要输入值的Gird，用于指定测试记录的录入
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="ctr"></param>
        /// <param name="p"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public UltraGrid GenerateGrid(string moduleName, Control ctr, Point p, string prefix)
        {
            Sys_PD_Module module = new Sys_PD_Module();
            module = instModule.GetListByWhere(" and SPM_Module='" + moduleName + "'").ToList()[0];
            //List<Sys_PD_Filed> filedList = new List<Sys_PD_Filed>();
            //filedList = instField.GetListByWhere(" and DCP_ModuleName='" + moduleName + "' order by DCP_Order").ToList();
            ctr.Tag = module;
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
            GridFormater.SetGridStyle(ug_list);

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


        public UltraGrid GenerateGridCellMultiInput(string moduleName, Control ctr, Point p)
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
            GridFormater.SetGridStyle(ug_list);
            #endregion


            ug_list.AfterColPosChanged += new AfterColPosChangedEventHandler(ug_list_AfterColPosChanged);
            ug_list.InitializeLayout += new InitializeLayoutEventHandler(ug_list_InitializeLayout);
            ug_list.KeyUp += new KeyEventHandler(ug_list_KeyUp);
            ug_list.CellChange += new CellEventHandler(ug_list_CellChange);
            ug_list.BeforeCellListDropDown += new CancelableCellEventHandler(ug_list_BeforeCellListDropDown);
            ctr.Controls.Add(ug_list);
            return ug_list;
        }

        void ug_list_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            GridTagObject gridObj = ug_list.Tag as GridTagObject;
            string prefix = gridObj.GridValuePrefix;
            string _colType = prefix + "_Type";
            string _dictKey = prefix + "_DictKey";
            string _colValue = prefix + "_VCol";

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
                        e.Row.Activation = Activation.NoEdit;
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
                        break;
                }
                //e.Row.Cells[_colValue].Editor = 
            }
        }

        void ug_list_BeforeCellListDropDown(object sender, CancelableCellEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            if (ug_list.DisplayLayout.Override.CellClickAction == CellClickAction.CellSelect || ug_list.DisplayLayout.Override.CellClickAction == CellClickAction.RowSelect)
            {
                e.Cancel = true;
                return;
            }

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
                    // 0 父级控件ID  1 过滤数据参考列
                    string[] pControl = field.DCP_PControl.Split(',');


                    if (pControl.Length <= 2)
                    {
                        drop.Rows.ColumnFilters[pControl[1]].FilterConditions.Clear();

                        if (cell.Row.Cells[pControl[0]].Value != null)
                        {
                            drop.Rows.ColumnFilters[pControl[1]].FilterConditions.Add(FilterComparisionOperator.Contains, cell.Row.Cells[pControl[0]].Value.ToString());
                        }
                        else
                        {
                            drop.Rows.ColumnFilters[pControl[1]].FilterConditions.Add(FilterComparisionOperator.Contains, "");
                        }
                    }         //如果有三个参数则表示 取反
                    else
                    {
                        drop.Rows.ColumnFilters[pControl[1]].FilterConditions.Clear();

                        if (cell.Row.Cells[pControl[0]].Value != null)
                        {
                            drop.Rows.ColumnFilters[pControl[1]].FilterConditions.Add(FilterComparisionOperator.DoesNotContain, cell.Row.Cells[pControl[0]].Value.ToString());
                        }
                        else
                        {
                            drop.Rows.ColumnFilters[pControl[1]].FilterConditions.Add(FilterComparisionOperator.Contains, "");
                        }
                    }



                }
            }
        }

        void ug_list_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            UltraGridCell cell = e.Cell;
            Sys_PD_Filed field = cell.Column.Tag as Sys_PD_Filed;
            try
            {
                EmbeddableEditorBase editor = e.Cell.EditorResolved;
                object value = editor.IsValid ? editor.Value : editor.CurrentEditText;

                e.Cell.Value = value;

                if (field != null)
                {
                    if (field.DCP_ControlType == "ref")
                    {
                        UltraDropDown drop = cell.Column.ValueList as UltraDropDown;
                        drop.Rows.ColumnFilters.ClearAllFilters();
                        drop.Rows.ColumnFilters[field.DCP_RefValue].FilterConditions.Add(FilterComparisionOperator.Contains, cell.Text);
                        drop.Rows.ColumnFilters[field.DCP_RefCode].FilterConditions.Add(FilterComparisionOperator.Contains, cell.Text);
                        drop.Rows.ColumnFilters.LogicalOperator = FilterLogicalOperator.Or;

                        if (!string.IsNullOrEmpty(field.DCP_RefBack))//回写数据
                        {
                            //回写DCP_RefBack
                            string[] arr = field.DCP_RefBack.Split(',');
                            foreach (string controlInfo in arr)
                            {
                                try
                                {
                                    string[] control = controlInfo.Split(':');
                                    e.Cell.Row.Cells[control[0]].Value = drop.SelectedRow.Cells[control[1]].Value.ToString();
                                }
                                catch { }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(field.DCP_CControl))
                    {
                        Sys_PD_Filed cField = e.Cell.Row.Cells[field.DCP_CControl].Column.Tag as Sys_PD_Filed;
                        if (cField != null)
                        {
                            if (cField.DCP_ControlType == "proc")
                            {
                                ADOSys_PD_Filed fieldInstance = new ADOSys_PD_Filed();

                                DataTable refDate = fieldInstance.GetProcData(cField.DCP_RefSQL, cell.Value.ToString());
                                if (refDate != null && refDate.Rows.Count > 0)
                                {
                                    UltraDropDown drop = new UltraDropDown();
                                    drop.DataSource = refDate.DefaultView;
                                    drop.DisplayMember = cField.DCP_RefValue;
                                    drop.ValueMember = cField.DCP_RefCode;

                                    drop.Tag = cField;
                                    e.Cell.Row.Cells[field.DCP_CControl].ValueList = drop;
                                    drop.Rows.ColumnFilters[cField.DCP_RefValue].FilterConditions.Add(FilterComparisionOperator.Contains, drop.Text);
                                }
                                else
                                {
                                    e.Cell.Row.Cells[field.DCP_CControl].ValueList = null;
                                }
                            }
                        }
                    }
                    //if (field.DCP_ControlType == "proc")
                    //{
                    //    ADOSys_PD_Filed fieldInstance = new ADOSys_PD_Filed();

                    //        DataTable refDate = fieldInstance.GetProcData(field.DCP_RefSQL, e.Cell.Row.Cells[field.DCP_PControl].Value.ToString());
                    //        UltraDropDown drop = new UltraDropDown();
                    //        drop.DataSource = refDate.DefaultView;
                    //        drop.DisplayMember = field.DCP_RefValue;
                    //        drop.ValueMember = field.DCP_RefCode;

                    //        drop.Tag = field;
                    //        cell.ValueList = drop;
                    //        drop.Rows.ColumnFilters[field.DCP_RefValue].FilterConditions.Add(FilterComparisionOperator.Contains, drop.Text);
                    //}
                    if (!string.IsNullOrEmpty(field.DCP_PageName))
                    {
                        string[] arr = field.DCP_PageName.Split(',');
                        foreach (string name in arr)
                        {
                            e.Cell.Row.Cells[name].Value = e.Cell.Text;
                        }
                    }

                }
            }
            catch
            {

            }
        }


        #endregion


        #region 列初始化
        void ug_list_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGrid ug_list = sender as UltraGrid;
            Sys_PD_RefModule refModuleData = new Sys_PD_RefModule();
            int i = 0;
            //ug_list.DisplayLayout.Appearance.FontData.SizeInPoints = (float)30;
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
                //ugCol.Header.te
                
                
            }
            ug_list.DisplayLayout.Bands[0].Summaries.Clear();

            foreach (Sys_PD_Filed field in filedList)
            {
                UltraGridBand band = e.Layout.Bands[0];
                if (band.Columns.Exists(field.DCP_ControlID))
                {
                    band.Columns[field.DCP_ControlID].Header.Caption = field.DCP_Label;
                    band.Columns[field.DCP_ControlID].Hidden = field.DCP_IsHidden == 1 ? true : false;
                    band.Columns[field.DCP_ControlID].Tag = field;//置tag属性，保存列的配置属性
                    band.Columns[field.DCP_ControlID].Header.VisiblePosition = field.DCP_Order;
                    band.Columns[field.DCP_ControlID].CellActivation = Activation.AllowEdit;
                    
                }
                else
                {
                    continue;
                }
                
                if (field.DCP_IsSummary > 0)
                {
                    ug_list.DisplayLayout.Bands[0].Columns[field.DCP_ControlID].AllowRowSummaries = AllowRowSummaries.SingleSummaryBasedOnDataType;
                    
                    ug_list.DisplayLayout.Bands[0].Summaries.Add(SummaryType.Sum, ug_list.DisplayLayout.Bands[0].Columns[field.DCP_ControlID]);
                    ug_list.DisplayLayout.Bands[0].SummaryFooterCaption = "合计";
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
                        band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
                        band.Columns[field.DCP_ControlID].PromptChar = ' ';
                        band.Columns[field.DCP_ControlID].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                        band.Columns[field.DCP_ControlID].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                        if (field.DCP_IsReadonly == 1)
                        {
                            band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                        }

                        break;
                    case "int":
                        band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;


                        if (field.DCP_IsReadonly == 1)
                        {
                            band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                        }
                        break;
                    case "check":
                        band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

                        if (field.DCP_IsReadonly == 1)
                        {
                            band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                        }
                        break;
                    case "date":
                        band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
                        band.Columns[field.DCP_ControlID].MaskInput = "yyyy-mm-dd";
                        //band.Columns[field.DCP_ControlID].DefaultCellValue = DateTime.Now;

                        if (field.DCP_IsReadonly == 1)
                        {
                            band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                        }
                        break;
                    case "time":
                        band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTimeWithoutDropDown;
                        band.Columns[field.DCP_ControlID].MaskInput = "yyyy-mm-dd hh:mm";
                        //band.Columns[field.DCP_ControlID].DefaultCellValue = DateTime.Now;

                        if (field.DCP_IsReadonly == 1)
                        {
                            band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                        }
                        break;
                    case "dict":
                        var dict = instDict.GetListByWhere(string.Format(" and dict_key='{0}' and dict_code <>'{0}' order by dict_order ", field.DCP_Type));
                        var valueList = new ValueList();
                        foreach (var obj in dict)
                        {
                            valueList.ValueListItems.Add(obj.Dict_Code, obj.Dict_Name);
                        }
                        band.Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                        band.Columns[field.DCP_ControlID].ValueList = valueList;
                        band.Columns[field.DCP_ControlID].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;

                        if (field.DCP_IsReadonly == 1)
                        {
                            band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                        }
                        break;
                    case "ref":
                        //e.Layout.Bands[0].Columns[field.DCP_ControlID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.ul;
                        UltraDropDown drop = new UltraDropDown();
                        string sql = string.Empty;
                        //if (!string.IsNullOrEmpty(field.DCP_RefSQL))
                        //{
                        //    sql = string.Format(field.DCP_RefSQL, "");
                        //MethodInvoker exc = delegate
                        //{
                        ADOSys_PD_RefModule refInst = new ADOSys_PD_RefModule();
                        Sys_PD_RefModule refModule = refInst.GetListByWhere(string.Format(" and SPR_RefModule='{0}'", field.DCP_RefSQL)).FirstOrDefault();

                        if (refModule != null && !string.IsNullOrEmpty(field.DCP_RefSQL))
                        {

                            sql = refModule.SPR_RefSQL.Trim();
                            DataTable refDate = new DataTable();
                            refDate = instField.GetRefData(sql);
                            drop.DataSource = refDate.DefaultView;
                            drop.DisplayMember = field.DCP_RefValue;
                            drop.ValueMember = field.DCP_RefCode;

                            drop.Tag = field;

                            //drop.v += new EventHandler(drop_TextChanged);
                            band.Columns[field.DCP_ControlID].ValueList = drop;
                            band.Columns[field.DCP_ControlID].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;

                            if (field.DCP_IsReadonly == 1)
                            {
                                band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                            }
                            drop.Rows.ColumnFilters[field.DCP_RefValue].FilterConditions.Add(FilterComparisionOperator.Contains, drop.Text);
                        }
                        else
                        {
                            DataTable refDate = new DataTable();
                            drop.DataSource = refDate.DefaultView;
                            drop.DisplayMember = field.DCP_RefValue;
                            drop.ValueMember = field.DCP_RefCode;
                            //drop.v += new EventHandler(drop_TextChanged);
                            band.Columns[field.DCP_ControlID].ValueList = drop;
                            band.Columns[field.DCP_ControlID].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;

                            if (field.DCP_IsReadonly == 1)
                            {
                                band.Columns[field.DCP_ControlID].CellClickAction = CellClickAction.RowSelect;
                            }


                            //drop.Rows.ColumnFilters[field.DCP_RefValue].FilterConditions.Add(FilterComparisionOperator.Contains, drop.Text);
                        }
                        //};

                        //exc.BeginInvoke(null, null);

                        //}

                        break;
                }
            }
            if (module.SPM_IsFilter > 0)
            {
                SetExcelStyleFilter(ug_list);
            }
            ug_list.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            GridFormater.RetrieveSetGridFormat(ug_list, ug_list.DisplayLayout.Bands[0], module.SPM_Module, SessionConfig.UserID);
        }
        
        #region 设置Excel过滤
        /// <summary>
        /// 设置UltraGrid 行过滤器
        /// </summary>
        public void SetExcelStyleFilter(UltraGrid ug_list)
        {
            UltraGridFilterUIProvider filterUIProvider = null;
            //  Create a new UltraGridFilterUIProvider
            //this.filterUIProvider = new UltraGridFilterUIProvider(this.components);
            filterUIProvider = new UltraGridFilterUIProvider(ug_list.Parent.Container);
            //  Assign the UltraGridFilterUIProvider component to the
            //  FilterUIProvider property of the layout's Override, so
            //  it is used by all columns.
            ug_list.DisplayLayout.Override.FilterUIProvider = filterUIProvider;


            //  Set the AllowRowFiltering property of the layout's
            //  Override to true to enable row filtering.
            ug_list.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;


            //  Handle the AfterMenuPopulate event so we can control which menu items appear.
            filterUIProvider.AfterMenuPopulate += new AfterMenuPopulateEventHandler(this.filterUIProvider_AfterMenuPopulate);

        }


        /// <summary>
        /// Handles the UltraGridFilterUIProvider's AfterMenuPopulate event.
        /// </summary>
        private void filterUIProvider_AfterMenuPopulate(object sender, AfterMenuPopulateEventArgs e)
        {
            UltraGridFilterUIProvider provider = sender as UltraGridFilterUIProvider;
            UltraGridColumn column = e.ColumnFilter != null ? e.ColumnFilter.Column : null;
            string columnKey = column != null ? column.Key : string.Empty;
            ////this.SetupFilterTools(columnKey, e.MenuItems);

            //if (string.Equals(columnKey, "33"))
            //{
            foreach (FilterTool tool in e.MenuItems)
            {
                if (string.Equals(tool.Id, "Clear Filter"))
                {
                    tool.DisplayText = "清除过滤条件";
                }
                if (string.Equals(tool.Id, "Number Filters") || string.Equals(tool.Id, "Text Filters") || string.Equals(tool.Id, "Date Filters"))
                {
                    e.MenuItems.Remove(tool);
                    break;
                }

            }
            //}

            //this.currentColumnFilecter = e.ColumnFilter;
        }
        #endregion filterUIProvider_AfterMenuPopulate


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
            if (e.KeyCode == Keys.F4)
            {
                SystemInformationHelp helper = new SystemInformationHelp(ug_list);
                helper.Show();
                return;
            }
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
                //string prefix = uCom.Name.Replace(field.DCP_ControlID, " ").Trim();

                foreach (string name in arr)
                {
                    //string controlId = prefix + name;

                    //uCom.Parent.Controls[controlId].Text = uCom.Text;
                    uCom.Parent.Controls[name].Text = uCom.Text;
                }
            }
        }
        #endregion

        #region 设置是否可编辑
        public void SetGridReadOnly(UltraGrid ug_list, bool flag)
        {
            GridFormater.SetGridEditMode(flag, ug_list);
        }

        #endregion

        public void SetGridColumnStyle(UltraGrid ug_list, AutoFitStyle style)
        {
            ug_list.DisplayLayout.AutoFitStyle = style;

        }
    }
}

