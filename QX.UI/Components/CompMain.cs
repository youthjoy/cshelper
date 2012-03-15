﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QX.GenFramework.BseControl;
using QX.GenFramework;
using QX.GenFramework.AutoForm;
using Infragistics.Win.UltraWinGrid;
using QX.Model;
using QX.GenFramework.Helper;
using QX.Helper;

namespace QX.UI.Components
{
    public partial class CompMain : Bse_Form
    {
        public CompMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);

            BindTopTool();
        }

        #region 操作句柄

        private GridHelper gen = new GridHelper();

        private BLL.Bll_Comp compInstance = new QX.BLL.Bll_Comp();

        UltraGrid comGrid = new UltraGrid();

   
        #endregion

        #region 工具条

        private void BindTopTool()
        {

            this.top_tool_bar.AddClicked += new EventHandler(top_tool_bar_AddClicked);

            this.top_tool_bar.EditClicked += new EventHandler(top_tool_bar_EditClicked);

            this.top_tool_bar.RefreshClicked += new EventHandler(top_tool_bar_RefreshClicked);
            this.top_tool_bar.LookClicked += new EventHandler(top_tool_bar_LookClicked);
            top_tool_bar.DelClicked += new EventHandler(top_tool_bar_DelClicked);


            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();

        }

        void top_tool_bar_LookClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Tpl_Components comp = row.ListObject as Tpl_Components;
                CompOp EditFrm = new CompOp(comp, OperationTypeEnum.Look);
                //EditFrm.CallBack += new CompOp.DCallBackHandler(EditFrm_CallBack);
                EditFrm.Show();
            }
        }

        void top_tool_bar_RefreshClicked(object sender, EventArgs e)
        {
            BindData();
        }

        void top_tool_bar_DelClicked(object sender, EventArgs e)
        {
            var rows = this.comGrid.Selected.Rows;

            if (rows.Count == 0)
            {
                Alert.Show("请选中要删除的行!");
                return;
            }

            if (Alert.ShowIsConfirm("确定删除该零件图号模板吗?"))
            {
                StringBuilder sb=new StringBuilder();

                foreach (var r in rows)
                {

                    Tpl_Components comp = r.ListObject as Tpl_Components;
                    if(!compInstance.CompDelete(comp))
                    {
                      sb.Append(comp.TPLC_Code).Append(",");
                    }
                }
                if(sb.ToString().Length==0)
                {
                    Alert.Show("数据更新成功!");
                }
                else
                {
                    Alert.Show(string.Format("以下零件图号未能成功删除!{0}",sb.ToString().TrimEnd(',')));
                }

                BindData();
            }
        }

        void top_tool_bar_EditClicked(object sender, EventArgs e)
        {
            UltraGridRow row = this.comGrid.ActiveRow;
            if (row != null)
            {
                Tpl_Components comp = row.ListObject as Tpl_Components;
                //CompOp EditFrm = new CompOp(comp, OperationTypeEnum.Edit);
                //EditFrm.CallBack += new CompOp.DCallBackHandler(EditFrm_CallBack);
                //EditFrm.Show();
            }
        }

        void EditFrm_CallBack(bool flag)
        {
            BindData();
        }


        void top_tool_bar_AddClicked(object sender, EventArgs e)
        {
            //CompOp frmAdd = new CompOp(new Tpl_Components(), OperationTypeEnum.Add);
            //frmAdd.CallBack += new CompOp.DCallBackHandler(frmAdd_CallBack);
            //frmAdd.Show();
        }

        void frmAdd_CallBack(bool flag)
        {
            BindData();
        }

        void top_tool_bar_SearchClicked(object sender, EventArgs e)
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");
            string val3 = this.top_tool_bar.GetSearchValue("Key", "Text");
            List<Tpl_Components> list = compInstance.GetComponentsList(val1, val2, val3);

            comGrid.DataSource = list;

        }
        #endregion

        void Form_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData();
        }

        public void InitControl()
        {
            List<Tpl_Components> list = new List<Tpl_Components>();
            comGrid = gen.GenerateGrid("CList_Comp", this.pnlGrid, new Point(0, 0));
            comGrid.DataSource = list;
            comGrid.DoubleClickRow += new DoubleClickRowEventHandler(comGrid_DoubleClickRow);
            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;

            
        }

        void comGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //双击查看
            top_tool_bar_LookClicked(null, null);
        }

        public void BindData()
        {
            List<Tpl_Components> list = compInstance.GetComponentsList().OrderByDescending(o => o.TPLC_ID).ToList();

            comGrid.DataSource = list;
        }

    }
}
