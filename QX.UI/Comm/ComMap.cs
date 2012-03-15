using System;
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
using Infragistics.Win.UltraWinEditors;
using QX.BLL;

namespace QX.UI.Comm
{
    public partial class ComMap : Form
    {


        public ComMap(string data)
        {
            InitializeComponent();

            EventInit();

            string[] arr = data.Split(',');
            if (arr != null && arr.Length > 1)
            {

                ModuleCode = arr[0];
                DataCode = arr[1];
                DataName = arr[2];
                this.Text = DataName;
            }
            else
            {
                DataCode = data;
            }

            this.Load += new EventHandler(ComDict_Load);
        }

        private void ComDict_Load(object sender, EventArgs e)
        {
            //PermissionHelper.PermissionControl(tbGrid, (this.Tag as MenuData).ItemId);
            InitData();
        }
        public string DataName
        {
            get;
            set;
        }
        /// <summary>
        /// 数据源模块
        /// </summary>
        public string ModuleCode
        {
            get;
            set;
        }
        //模块编码
        public string DataCode
        {
            get;
            set;
        }


        public void EventInit()
        {

            this.tbGrid.SaveClicked += new EventHandler(pSaveBtn_Click);

            this.tbGrid.RefreshClicked += new EventHandler(tbGrid_RefreshClicked);

        }

        void tbGrid_RefreshClicked(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        void pSaveBtn_Click(object sender, EventArgs e)
        {
            SaveData();
            RefreshGrid();
            Alert.Show("数据更新完成");
        }

        private void SaveData()
        {

            List<Sys_Map> list = new List<Sys_Map>();
            foreach (UltraGridRow row in comGrid.Rows)
            {

                Sys_Map line = row.ListObject as Sys_Map;
                //line.Dict_Key = "";
                list.Add(line);
            }


            dcInstance.AddOrUpdateDict(ModuleCode, list);
        }

        private void InitData()
        {

            GridInit();
        }

        private Bll_SysMap dcInstance = new Bll_SysMap();

        UltraGrid comGrid = new UltraGrid();

        private void GridInit()
        {
            GridHelper gen = new GridHelper();

            List<Sys_Map> bsList = new List<Sys_Map>();
            string moduleCode = DataCode;
            bsList = dcInstance.GetMap(ModuleCode);

            //ADOSys_PD_Module moduleInstance = new ADOSys_PD_Module();
            //Sys_PD_Module module = new Sys_PD_Module();
            //module = moduleInstance.GetListByWhere(" and SPM_Module='" + DataCode + "'").FirstOrDefault();
            //if (module == null)
            //{
            //    moduleCode = "CList_BseDict";
            //}

            comGrid = gen.GenerateGrid(moduleCode, this.pnlGrid, new Point(6, 20));
            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = bsList;

            comGrid.DataSource = dataSource;

            //SetGridEditMode(false, StationGrid);

            //列宽度自适应
            comGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            comGrid.Text = this.Text;
        }

        private void RefreshGrid()
        {
            List<Sys_Map> bsList = new List<Sys_Map>();

            bsList = dcInstance.GetMap(ModuleCode);
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = bsList;
            comGrid.DataSource = dataSource;
        }

        public void SetGridEditMode(bool flag, UltraGrid grid)
        {
            if (flag)
            {
                grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
                grid.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;
            }
            else
            {
                grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
                grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            }

        }
    }
}
