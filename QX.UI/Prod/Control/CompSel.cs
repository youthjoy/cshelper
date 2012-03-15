using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QX.Model;
using Infragistics.Win.UltraWinGrid;
using QX.Framework.AutoForm;
using QX.BLL;
using QX.Common.Helper;

namespace QX.UI.Prod.Control
{
    public partial class CompSel : Form
    {
        public CompSel()
        {
            InitializeComponent();

            this.Load += new EventHandler(CompSel_Load);

            BindTopTool();
        }

        void CompSel_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData();
        }
        UltraGrid comGrid = new UltraGrid();
        UltraGrid savGrid = new UltraGrid();
        GridHelper gen = new GridHelper();
        Bll_Comp compInstance = new Bll_Comp();

        public delegate void DCallBackHandler(bool flag, List<Prod_Components> list);
        public event DCallBackHandler CallBack;

        private void AddCustomCol()
        {
            if (!comGrid.DisplayLayout.Bands[0].Columns.Exists("checkbox"))
            {
                var col = comGrid.DisplayLayout.Bands[0].Columns.Add("checkbox", "");
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                //col.Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                col.DataType = typeof(bool);
                col.DefaultCellValue = false;
                col.Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                col.Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
                col.Header.VisiblePosition = 0;
                col.CellClickAction = CellClickAction.Edit;

            }
            else
            {
                comGrid.DisplayLayout.Bands[0].Columns.Remove("checkbox");
                var col = comGrid.DisplayLayout.Bands[0].Columns.Add("checkbox", "");
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                //col.Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                col.DataType = typeof(bool);
                col.DefaultCellValue = false;
                col.Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                col.Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
                col.Header.VisiblePosition = 0;
                col.CellClickAction = CellClickAction.Edit;
            }
        }


        private List<Prod_Components> GetGridCheckBoxData()
        {
            List<Prod_Components> list = new List<Prod_Components>();

            foreach (UltraGridRow r in this.comGrid.DisplayLayout.Rows)
            {

                if (r.Cells["checkbox"].Value != null && r.Cells["checkbox"].Value.ToString() == "True")
                {
                    Prod_Components planProd = r.ListObject as Prod_Components;
                    list.Add(planProd);
                }
            }

            return list;
        }

        private void BindTopTool()
        {

            #region 工具条

            this.top_tool_bar.SearchClicked += new EventHandler(top_tool_bar_SearchClicked);
            this.top_tool_bar.AddSearchAllModule();

            ToolBarHelper tsHelper = new ToolBarHelper();
            
            ToolStripButton importBtn = tsHelper.New("手动录入", QX.GenFramework.Properties.Resources.import, new EventHandler(importBtn_Click));
            //importBtn.Click += new EventHandler(importBtn_Click);
            this.top_tool_bar.AddCustomControl(importBtn);
            //conBtn.Click += new EventHandler(conBtn_Click);
            ToolStripButton conBtn = tsHelper.New("保存", QX.GenFramework.Properties.Resources.finished, new EventHandler(conBtn_Click));

            this.top_tool_bar.AddCustomControl(conBtn);
            #endregion

        }

        void d_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                importBtn_Click(null, null);
            }
        }

        void importBtn_Click(object sender, EventArgs e)
        {
            string val3 = this.top_tool_bar.GetSearchValue("Key", "Text");
            Prod_Components road = compInstance.GetCompModel(val3);
            
            if (road != null)
            {
                var newrow = this.savGrid.DisplayLayout.Bands[0].AddNew();

                PropertyDescriptorCollection pc = TypeDescriptor.GetProperties(typeof(Prod_Components));

                foreach (UltraGridCell cell in newrow.Cells)
                {
                    if (cell.Column.IsBound)
                    {
                        object value = pc[cell.Column.Key].GetValue(road);
                        if (value != null)
                        {
                            newrow.Cells[cell.Column.Key].Value = value;
                        }
                    }
                }
            }
        }

        void conBtn_Click(object sender, EventArgs e)
        {
            List<Prod_Components> list = GetProdComponents();
            if (list.Count == 0)
            {
                return;
            }

            if (CallBack != null)
            {
                CallBack(true, list);
                this.Close();
            }
        }

        public List<Prod_Components> GetProdComponents()
        {
            List<Prod_Components> list = new List<Prod_Components>();
            foreach (var r in savGrid.Rows)
            {
                Prod_Components p = r.ListObject as Prod_Components;
                if (!list.Exists(o => o.PRDC_ID == p.PRDC_ID))
                {
                    list.Add(p);
                }
            }
            return list;
        }


        void top_tool_bar_SearchClicked(object sender, EventArgs e)
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");
            string val3 = this.top_tool_bar.GetSearchValue("Key", "Text");

            List<Prod_Components> list = compInstance.GetPComponentsList(val1, val2, val3);

            comGrid.DataSource = list;

            AddCustomCol();
        }

        public void InitControl()
        {
            List<Prod_Components> list = new List<Prod_Components>();
            comGrid = gen.GenerateGrid("CList_Components", this.pnlGrid, new Point(0, 0));
            gen.SetGridReadOnly(comGrid, true);
            //comGrid.DisplayLayout.LoadStyle = LoadStyle.LoadOnDemand;

            List<Prod_Components> list1 = new List<Prod_Components>();
            savGrid = gen.GenerateGrid("CList_Components", this.panel1, new Point(0, 0));
            gen.SetGridReadOnly(savGrid, false);
            BindingSource dataSouruce = new BindingSource();
            dataSouruce.DataSource = list1;
            savGrid.DataSource = dataSouruce;
        }



        public void BindData()
        {
            string val1 = this.top_tool_bar.GetSearchValue("bDate", "Date");
            string val2 = this.top_tool_bar.GetSearchValue("eDate", "Date");

            List<Prod_Components> list = compInstance.GetPComponentsList(val1, val2, "").ToList();

            comGrid.DataSource = list;

            AddCustomCol();

            BindingSource dataSouruce = new BindingSource();
            dataSouruce.DataSource = new List<Prod_Components>();
            savGrid.DataSource = dataSouruce;
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            var rows = comGrid.Selected.Rows;
            if (rows != null)
            {
                foreach (var row in rows)
                {
                    Prod_Components road = row.ListObject as Prod_Components;
                    var newrow = this.savGrid.DisplayLayout.Bands[0].AddNew();

                    if (road != null)
                    {
                        PropertyDescriptorCollection pc = TypeDescriptor.GetProperties(typeof(Prod_Components));

                        foreach (UltraGridCell cell in newrow.Cells)
                        {
                            if (cell.Column.IsBound)
                            {
                                object value = pc[cell.Column.Key].GetValue(road);
                                if (value != null)
                                {
                                    newrow.Cells[cell.Column.Key].Value = value;
                                }
                            }
                        }


                    }
                }
            }
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            var rows = this.savGrid.Selected.Rows;
            if (rows != null)
            {
                foreach (var row in rows)
                {
                    row.Delete(false);
                }
            }
        }
    }
}
