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
using BC.Model;
using BC.DAL;
using BC.Shared;

namespace QX.Framework.AutoForm
{
    public class ControlHelper
    {
        ADOSys_PD_Controls instControl = new ADOSys_PD_Controls();


        private Control GenerateControls(string parentItemCode, Control _ctl, List<Sys_PD_Controls> allItems)
        {
            /*
             * 坐标规则：
             * 第一个控件：
             *          以控件本身的LocX,LocY为起始点
             *          以SizX,SizY控制控件大小
             *          以XI控制是否有平级控件，如果XI < SizX，则无平级控件，则有平级控件，且平级控件的起始点为（LocX+XI，LocY）
             * 后续控件：
             * 如果是平级控件，且没有设置LocX，LocY，则依据上一控件来进行设计`
             */
            Color backColor = new Color();
            int locationX = 0; //X坐标点
            int locationY = 0;//Y坐标点
            //int controlHeight = 0;
            //int controlWidth = 0;

            List<Sys_PD_Controls> childItems = allItems.Where(o => o.SPC_PControlID == parentItemCode).ToList();
            if (childItems.Count > 0)
            {
                locationX = childItems[0].SPC_LocX;
                locationY = childItems[0].SPC_LocY;
            }

            #region 创建同一父模块的子控件
            foreach (Sys_PD_Controls pItem in childItems)
            {
                if (pItem.SPC_LocX != 0)//如果X没值，则默认为上一Location
                {
                    locationX = pItem.SPC_LocX;
                }
                if (pItem.SPC_LocY != 0)//如果Y没值，则默认为上一Location
                {
                    locationY = pItem.SPC_LocY;
                }

                if (!string.IsNullOrEmpty(pItem.SPC_BackGround))
                {
                    string[] background = pItem.SPC_BackGround.Split(',');
                    try
                    {
                        backColor = System.Drawing.Color.FromArgb(int.Parse(background[0]), int.Parse(background[1]), int.Parse(background[2]));
                    }
                    catch
                    { }
                }
                else
                {
                    backColor = Color.FromKnownColor(KnownColor.Control);
                }
                #region 生成控件
                switch (pItem.SPC_ControlType.ToLower())
                {
                    case "groupbox":
                        GroupBox gb = new GroupBox();
                        gb.Name = pItem.SPC_ControlID;
                        gb.Size = new Size(pItem.SPC_SizeX, pItem.SPC_SizeY);
                        GenerateControls(pItem.SPC_ControlID, gb, allItems);
                        gb.Location = new Point(locationX, locationY);                        
                        gb.BackColor = backColor;
                        gb.TabStop = false;
                        gb.Text = pItem.SPC_ControlTitle;
                        gb.TabIndex = pItem.SPC_ControlOrder;
                        //gb.SendToBack();
                        _ctl.Controls.Add(gb);
                        
                        break;
                    case "panel":
                        Panel pl = new Panel();
                        pl.Name = pItem.SPC_ControlID;
                        pl.Size = new Size(pItem.SPC_SizeX, pItem.SPC_SizeY);
                        GenerateControls(pItem.SPC_ControlID, pl, allItems);
                        pl.Location = new Point(locationX,locationY);                        
                        pl.BackColor = backColor;
                        pl.Text = pItem.SPC_ControlTitle;
                        pl.TabIndex = pItem.SPC_ControlOrder;
                        _ctl.Controls.Add(pl);
                        break;
                    case "tablelayoutpanel":
                        //TableLayoutPanel tLayout = new TableLayoutPanel();
                        break;
                }
                #endregion

                //计算坐标增量   如果X无增量，则设置locationX为0
                if (pItem.SPC_XI != 0)
                {
                    locationX += pItem.SPC_XI;
                }
                //计算Y坐标增量，如果无增量，则设置LocationY为0
                if (pItem.SPC_YI != 0)
                {
                    locationY += pItem.SPC_YI;
                }
            }
            #endregion
            if(_ctl.FindForm()==null)
            {
                _ctl.Size = new Size(_ctl.Size.Width, locationY);
            }
            return _ctl;
        }

        public Control GenerateControls(string _module,Control ccc)
        {
            List<Sys_PD_Controls> allControls = new List<Sys_PD_Controls>();
            allControls = instControl.GetListByWhere(string.Format(" and SPC_ModuleName='{0}'", _module));//获取该模块下的所有控件
            if (allControls.Count < 1)
                return ccc;
            //List<Sys_PD_Controls> rootList = new List<Sys_PD_Controls>();
            //rootList = allControls.Where(o => o.SPC_PControlID == _module).ToList();
            //foreach (Sys_PD_Controls rootItem in rootList)
            //{
            //ccc.SuspendLayout();
            return GenerateControls(_module, ccc, allControls);  //以Form为基础进行生成
            //}

        }

    }
}
