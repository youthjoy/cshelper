using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinGrid;
using System.Data;
using QX.GenFramework.Model;
using QX.GenFramework.ADO;
using Infragistics.Win;
using System.Drawing;
using System.Text.RegularExpressions;

namespace QX.GenFramework.AutoForm
{
    public enum IGridAppearence
    {
        Disp,
        GroupBy,
        GroupByBandLab,
        GroupByPromt,
        GroupByRow,
        Header,
        Row,
        TemplateRow,
        ActiveRow,
        Cell,
        ActiveCell,
        CardArea,
        RowSelector,
        Caption
    }
    public class GridFormater
    {

        public static void SaveGridFormat(UltraGridBand ug, string sModuleCode, string sEmplNo)
        {
            ADOSys_PD_GridFormat InstGrid = new ADOSys_PD_GridFormat();
            Sys_PD_GridFormat formater = new Sys_PD_GridFormat();

            InstGrid.DeleteFormatter(sModuleCode, sEmplNo);

            foreach (UltraGridColumn aCol in ug.Columns)
            {
                if (aCol.Hidden == true)
                { }
                else
                {
                    formater.ColFor_Code = sModuleCode;
                    formater.Empl_NO = sEmplNo;
                    formater.ColFor_ColName = aCol.Key;
                    formater.ColFor_ColOrder = aCol.Header.VisiblePosition;
                    formater.ColFor_ColWidth = aCol.Width.ToString();
                    InstGrid.Add(formater);
                }
            }

        }

        public static void RetrieveSetGridFormat(UltraGrid ugrid, UltraGridBand ug, string sModule, string sEmplNo)
        {
            ugrid.EventManager.AllEventsEnabled = false;
            string ssql = string.Format(" select colfor_colname, colfor_colorder, colfor_colwidth from colformat where empl_no = '{0}' and colfor_code = '{1}' ", sEmplNo, sModule);

            ADOSys_PD_GridFormat InstGrid = new ADOSys_PD_GridFormat();
            List<Sys_PD_GridFormat> fList = new List<Sys_PD_GridFormat>();
            fList = InstGrid.GetListByWhere(string.Format(" and empl_no = '{0}' and colfor_code = '{1}' ", sEmplNo, sModule));
            foreach (Sys_PD_GridFormat f in fList)
            {
                string sCol = f.ColFor_ColName;
                if (ug.Columns.Exists(sCol))
                {
                    ug.Columns[sCol].Header.VisiblePosition = f.ColFor_ColOrder;
                    ug.Columns[sCol].Width = int.Parse(f.ColFor_ColWidth);
                }
            }
            ugrid.EventManager.AllEventsEnabled = true;
        }

        public static Appearance GetGridAppearence(string GridAppearceModule)
        {
            Infragistics.Win.Appearance appear = new Infragistics.Win.Appearance();
            //appear.BackColor
            switch (GridAppearceModule.ToLower().Trim())
            {
                case "disp":
                    appear.BackColor = System.Drawing.SystemColors.Window;
                    appear.BorderColor = System.Drawing.SystemColors.InactiveCaption;
                    break;
                #region GroupBy
                case "groupby":
                    appear.BackColor = System.Drawing.SystemColors.ActiveBorder;
                    appear.BackColor2 = System.Drawing.SystemColors.ControlDark;
                    appear.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                    appear.BorderColor = System.Drawing.SystemColors.Window;
                    break;
                case "groupbybandlab":
                    appear.ForeColor = System.Drawing.SystemColors.GrayText;
                    break;
                case "groupbypromt":
                    appear.BackColor = System.Drawing.SystemColors.ControlLightLight;
                    appear.BackColor2 = System.Drawing.SystemColors.Control;
                    appear.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
                    appear.ForeColor = System.Drawing.SystemColors.GrayText;
                    break;
                case "groupbyrow":
                    appear.BackColor = System.Drawing.SystemColors.Control;
                    appear.BackColor2 = System.Drawing.SystemColors.ControlDark;
                    appear.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
                    appear.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
                    appear.BorderColor = System.Drawing.SystemColors.Window;
                    break;
                #endregion

                #region Header
                case "header":
                    appear.TextHAlignAsString = "Center";
                    appear.BackColor2 = Color.FromKnownColor(KnownColor.Window);
                    appear.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                    appear.FontData.Name = "宋体";
                    appear.FontData.SizeInPoints = 11;
                    break;
                case "caption":
                    appear.TextHAlignAsString = "Center";
                    appear.BackColor2 = Color.FromKnownColor(KnownColor.Red);
                    appear.FontData.Name = "宋体";
                    appear.FontData.SizeInPoints = 11;
                    break;
                #endregion

                #region Row
                case "row":
                    appear.BackColor = System.Drawing.SystemColors.Window;
                    appear.BorderColor = Color.SteelBlue;
                    appear.FontData.Name = "宋体";
                    appear.FontData.SizeInPoints = 10;
                    break;
                case "templaterow":
                    appear.BackColor = System.Drawing.SystemColors.ControlLight;
                    break;
                case "activerow":
                    appear.BackColor = Color.YellowGreen;
                    appear.ForeColor = System.Drawing.SystemColors.HighlightText;
                    appear.FontData.Name = "宋体";
                    appear.FontData.SizeInPoints = 10;
                    break;
                case "rowselector":
                    appear.BackColor2 = Color.FromKnownColor(KnownColor.Menu);
                    appear.TextHAlign = HAlign.Center;
                    break;
                #endregion

                #region Cell
                case "cell":
                    appear.BorderColor = Color.SteelBlue;
                    appear.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
                    break;
                case "activecell":
                    appear.BackColor = System.Drawing.SystemColors.Window;
                    appear.ForeColor = System.Drawing.SystemColors.ControlText;
                    break;
                #endregion

                case "cardarea":
                    appear.BackColor = System.Drawing.SystemColors.Window;
                    break;

                default:
                    break;
            }
            return appear;

        }

        public static void SetGridStyle(UltraGrid ug_list)
        {
            ug_list.DisplayLayout.Bands[0].Override.ActiveRowAppearance = GridFormater.GetGridAppearence(IGridAppearence.ActiveRow.ToString());
            ug_list.DisplayLayout.Bands[0].Override.RowSelectorAppearance = GridFormater.GetGridAppearence(IGridAppearence.RowSelector.ToString());
            ug_list.DisplayLayout.Bands[0].Override.HeaderAppearance = GridFormater.GetGridAppearence(IGridAppearence.Header.ToString());
            ug_list.DisplayLayout.Bands[0].Override.CellAppearance = GridFormater.GetGridAppearence(IGridAppearence.Cell.ToString());
            ug_list.DisplayLayout.Bands[0].Override.RowAppearance = GridFormater.GetGridAppearence(IGridAppearence.Row.ToString());
            ug_list.DisplayLayout.CaptionAppearance = GridFormater.GetGridAppearence(IGridAppearence.Caption.ToString());
            ug_list.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            ug_list.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            //ug_list.DisplayLayout.Override.RowSelectorStyle = HeaderStyle.WindowsXPCommand;
            ug_list.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

            ug_list.DisplayLayout.EmptyRowSettings.ShowEmptyRows = true;
            ug_list.DisplayLayout.EmptyRowSettings.Style = EmptyRowStyle.ExtendRowSelector;
            ug_list.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;


            
            
        }

        public static void SetGridEditMode(bool flag, UltraGrid grid)
        {
            if (flag)
            {
                grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
                grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
                
            }
            else
            {
                grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
                grid.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;
            }
        }

        /// <summary>
        /// 将字符串转换为Color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color ToColor(string color)
        {
            int red, green, blue = 0;
            char[] rgb;
            color = color.TrimStart('#');
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            switch (color.Length)
            {
                case 3:
                    rgb = color.ToCharArray();
                    red = Convert.ToInt32(rgb[0].ToString() + rgb[0].ToString(), 16);
                    green = Convert.ToInt32(rgb[1].ToString() + rgb[1].ToString(), 16);
                    blue = Convert.ToInt32(rgb[2].ToString() + rgb[2].ToString(), 16);
                    return Color.FromArgb(red, green, blue);
                case 6:
                    rgb = color.ToCharArray();
                    red = Convert.ToInt32(rgb[0].ToString() + rgb[1].ToString(), 16);
                    green = Convert.ToInt32(rgb[2].ToString() + rgb[3].ToString(), 16);
                    blue = Convert.ToInt32(rgb[4].ToString() + rgb[5].ToString(), 16);
                    return Color.FromArgb(red, green, blue);
                default:
                    return Color.FromName(color);

            }
        }
    }
}