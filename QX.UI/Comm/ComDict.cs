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
    public partial class ComDict : Bse_Form
    {
        public ComDict(string data)
        {
            InitializeComponent();
            base.Init();
            EventInit();

            string[] arr = data.Split(',');
            if (arr != null && arr.Length > 1)
            {
                DataCode = arr[0];
                DataName = arr[1];
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

            List<Bse_Dict> list = new List<Bse_Dict>();
            foreach (UltraGridRow row in comGrid.Rows)
            {
                //if (row.IsAddRow)
                //{
                //    continue;
                //}
                
                Bse_Dict line = row.ListObject as Bse_Dict;
                //line.Dict_Key = "";
                if (string.IsNullOrEmpty(line.Dict_Key))
                {
                    line.Dict_Key = DataCode;
                }



                list.Add(line);
            }


            dcInstance.AddOrUpdateDict(DataCode, list);
        }

        private void InitData()
        {
            if (!dcInstance.IsExsistDictKey(DataCode))
            {
                Bse_Dict dict = new Bse_Dict();
                dict.Dict_Code = DataCode;
                dict.Dict_Key = DataCode;
                dict.Dict_Name = DataName;
                dcInstance.AddDict(dict);
            }

            
            GridInit();
        }

        private Bll_Bse_Dict dcInstance = new Bll_Bse_Dict();

        UltraGrid comGrid = new UltraGrid();

        private void GridInit()
        {
            GridHelper gen = new GridHelper();

            List<Bse_Dict> bsList = new List<Bse_Dict>();
            string moduleCode = DataCode;
            bsList = dcInstance.GetDictByKey(DataCode);
            
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
            List<Bse_Dict> bsList = new List<Bse_Dict>();

            bsList = dcInstance.GetDictByKey(DataCode);
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
