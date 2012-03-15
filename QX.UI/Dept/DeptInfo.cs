using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;

using QX.GenFramework.BseControl;
using QX.GenFramework;
using QX.GenFramework.AutoForm;
using Infragistics.Win.UltraWinGrid;
using QX.Model;
using QX.GenFramework.Helper;
using QX.Helper;
using QX.BLL;
using System.Windows.Forms;
namespace QX.UI.Dept
{
    public partial class DeptInfo :Bse_Form
    {
        private delegate void DSynHanlder();


        UltraGrid empGrid = new UltraGrid();


        private Bll_Dept instance = new Bll_Dept();
        private Bll_Bse_Employee employeeInstance = new Bll_Bse_Employee();
        private GridHelper gen = new GridHelper();

        FormHelper fHelper = new FormHelper();

        #region 窗体单例
        public static DeptInfo NewForm = null;
        public static DeptInfo Instance()
        {
            if (NewForm == null || NewForm.IsDisposed == true)
            {
                NewForm = new DeptInfo();
            }
            else
            {
                NewForm.Activate();
            }
            return NewForm;
        }
        #endregion

        public DeptInfo()
        {
            InitializeComponent();
            this.Load += new EventHandler(DeptInfo_Load);

            //树控件
            //InitTree();
            ////Grid
            //InitGrid("");
            EventInit();
            BindTopTool();
            //fHelper.PermissionControl(tool_left.toolStrip1.Items,PermissionModuleEnum.Dept.ToString());
            //fHelper.PermissionControl(this.tool_right.toolStrip1.Items, PermissionModuleEnum.Employee.ToString());
        }

        private void EventInit()
        { 
           tv_left.MouseClick+=new MouseEventHandler(tv_left_MouseClick);
            tv_left.AfterSelect+=new TreeViewEventHandler(tv_left_AfterSelect);
        }

        public void BindTopTool()
        {
            tool_left.AddClicked += new EventHandler(btnAddDept_Click);
            tool_left.EditClicked += new EventHandler(btnModify_Click);
            tool_left.DelClicked += new EventHandler(btnDelDept_Click);
            tool_left.RefreshClicked += new EventHandler(btnRefresh_Click);

            //tool_left.SetButtonEnabled("his", false, false);
            //tool_right.SetButtonEnabled("his", false, false);

            //tool_left.SetButtonStyle("image");
            //tool_left.SetButtonEnabled("PRINT", false, false);
            tool_right.AddClicked += new EventHandler(tool_right_AddClicked);
            tool_right.EditClicked += new EventHandler(tool_right_EditClicked);
            tool_right.DelClicked += new EventHandler(tool_right_DelClicked);
            tool_right.RefreshClicked += new EventHandler(tool_right_RefreshClicked);
            tool_right.QueryClicked += new EventHandler(tool_right_QueryClicked);
            //tool_right.SetButtonEnabled("PRINT", false, false);

        }

        void DeptInfo_Load(object sender, EventArgs e)
        {
            InitTree();
            InitGrid();
            BindDataGrid("");
        }

        void tool_right_QueryClicked(object sender, EventArgs e)
        {
            if (empGrid.ActiveRow != null)
            {
                string EmpolyCode = empGrid.ActiveRow.Cells["Emp_Code"].Value.ToString();
                Bse_Employee model = employeeInstance.GetModel(" AND Emp_Code='" + EmpolyCode + "'");
                Employee employee = new Employee(employeeInstance, instance, model);
                employee.OperationType = OperationTypeEnum.Look;
                //employee.DataChange += new Employee.DataChangeHandler(employee_DataChange);
                employee.ShowDialog();
                //var node = tv_left.SelectedNode;
                //if (node != null)
                //{
                //    RefreshGrid(node.Name);
                //}
                //else
                //{
                //    RefreshGrid();
                //}
            }
        }

        


        void permissionBtn_Click(object sender, EventArgs e)
        {
            //UltraGridRow row = this.empGrid.ActiveRow;
            //if (row != null)
            //{
            //    Bse_Employee emp = row.ListObject as Bse_Employee;
            //    PermissionMain permissionForm = new PermissionMain(emp);
            //    permissionForm.ShowDialog();
            //}
        }


        void empGrid_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            tool_right_EditClicked(this, EventArgs.Empty);
        }

        /// <summary>
        /// 刷新人员gird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tool_right_RefreshClicked(object sender, EventArgs e)
        {
            //RefreshGrid();
        }

        /// <summary>
        /// 人员删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tool_right_DelClicked(object sender, EventArgs e)
        {
            if (empGrid.ActiveRow != null)
            {
                if (Alert.ShowIsConfirm("确定要删除该员工吗？"))
                {
                    string EmpolyCode = empGrid.ActiveRow.Cells["Emp_Code"].Value.ToString();
                    Bse_Employee model = employeeInstance.GetModel(" AND Emp_Code='" + EmpolyCode + "'");
                    bool result = employeeInstance.DeleteEmployee(model);
                    if (result)
                    {
                        tool_right_RefreshClicked(this, EventArgs.Empty);
                    }
                }
            }
            else
            {
                Alert.Show("请选择要操作的节点!");
            }
        }

        /// <summary>
        /// 人员编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tool_right_EditClicked(object sender, EventArgs e)
        {
            if (empGrid.ActiveRow != null)
            {
                string EmpolyCode = empGrid.ActiveRow.Cells["Emp_Code"].Value.ToString();
                Bse_Employee model = employeeInstance.GetModel(" AND Emp_Code='" + EmpolyCode + "'");
                Employee employee = new Employee(employeeInstance, instance, model);
                employee.OperationType = OperationTypeEnum.Edit;
                //employee.DataChange += new Employee.DataChangeHandler(employee_DataChange);
                employee.ShowDialog();
                var node = tv_left.SelectedNode;
                if (node != null)
                {
                    RefreshGrid(node.Name);
                }
                else
                {
                    RefreshGrid();
                }
            }
        }

        void employee_DataChange(object sender, EventArgs e)
        {
            tool_right_RefreshClicked(this, EventArgs.Empty);
        }

        /// <summary>
        /// 人员添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tool_right_AddClicked(object sender, EventArgs e)
        {
            Employee employee = new Employee(employeeInstance, instance, null);
            employee.OperationType = OperationTypeEnum.Add;
            employee.DataChange += new Employee.DataChangeHandler(employee_DataChange);
            employee.ShowDialog();
            RefreshGrid();
        }
        private void InitGrid()
        {
            List<Bse_Employee> list = new List<Bse_Employee>();
            empGrid = gen.GenerateGrid("GEmp", this.pnlGrid, new Point(0, 0));
            empGrid.DataSource = list;
        }
        ///// <summary>
        ///// 读取部门人员信息
        ///// </summary>
        public void BindDataGrid(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                List<Bse_Employee> list = employeeInstance.GetAllEmployee();
               // empGrid = gen.GenerateGrid("GEmp", this.pnlGrid, new Point(0, 0));
                empGrid.DataSource = list;
            }
            else
            { 
               
            }
        }

        ///// <summary>
        ///// 读取部门人员信息
        ///// </summary>
        public void RefreshGrid(string filter)
        {
            if (string.IsNullOrEmpty(filter) || filter == "root")
            {
                List<Bse_Employee> list = employeeInstance.GetAllEmployee().OrderBy(o => o.Emp_Order).ToList();
                empGrid.DataSource = list;
            }
            else
            {
                List<Bse_Employee> list = employeeInstance.GetEmpByDept(filter);
                empGrid.DataSource = list;
            }
        }

        public void RefreshGrid()
        {

            List<Bse_Employee> list = employeeInstance.GetAllEmployee().OrderBy(o => o.Emp_Order).ToList();
            empGrid.DataSource = list;
        }

        ///// <summary>
        ///// 筛选人员
        ///// </summary>
        ///// <param name="filter"></param>
        ///// <returns></returns>
        //private DataTable FilterDataTable(string filter)
        //{
        //    DataTable tmpDT = new DataTable();
        //    tmpDT = listEmployee.Clone();
        //    if (listEmployee != null && listEmployee.Rows.Count > 0)
        //    {
        //        DataRow[] rows = listEmployee.Select(filter);
        //        for (int i = 0; i < rows.Length; i++)
        //        {
        //            tmpDT.ImportRow(rows[i]);
        //        }
        //    }

        //    return tmpDT;
        //}

        /// <summary>
        /// 读取部门类别
        /// </summary>
        public void InitTree()
        {
            tv_left.Nodes.Clear();
            //DataTable dt = ConvertX.ToDataTable<Bse_Department>(instance.GetAllDept());
            //dt.TableName = "deptname";
            List<Bse_Department> list = instance.GetAllDept();
            var root = list.Where(o => o.Dept_Code == "root");
            foreach (var d in root)
            {
                TreeNode node = new TreeNode();
                node.Name = d.Dept_Code;
                node.Text = d.Dept_Name;
                node.Tag = d.Dept_PCode;
                tv_left.Nodes.Add(node);
                DeptTreeInit(node, list);
            }

            if (tv_left.Nodes.Count > 0)
            {
                tv_left.ExpandAll();
            }

        }

        private void DeptTreeInit(TreeNode pnode, List<Bse_Department> allList)
        {
            IEnumerable<Bse_Department> list = allList.Where(o => o.Dept_PCode == pnode.Name);

            if (list == null || list.Count() == 0)
            {
                return;
            }

            foreach (var d in list)
            {
                TreeNode node = new TreeNode();
                node.Name = d.Dept_Code;
                node.Text = d.Dept_Name;
                node.Tag = d.Dept_PCode;
                DeptTreeInit(node, allList);
                pnode.Nodes.Add(node);
            }

        }


        /// <summary>
        /// 刷新左边树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Invoke(new DSynHanlder(InitTree));
        }

        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnModify_Click(object sender, EventArgs e)
        {
            if (tv_left.SelectedNode != null)
            {
                Bse_Department model = instance.GetDeptModel(" And Dept_Code='" + tv_left.SelectedNode.Name + "'");
                Dept dept = new Dept(instance, employeeInstance, model);
                dept.OperationType = OperationTypeEnum.Edit;
                dept.FormClosing += new FormClosingEventHandler(dept_FormClosing);
                dept.ShowDialog();
            }
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnDelDept_Click(object sender, EventArgs e)
        {
            if (tv_left.SelectedNode != null && !String.IsNullOrEmpty(tv_left.SelectedNode.Text))
            {
                
                if (Alert.ShowIsConfirm("确定要删除当前选择部门吗？"))
                {

                    bool result = instance.DeleteDept(tv_left.SelectedNode.Name.ToString());
                    if (result)
                    {
                        tv_left.SelectedNode.Remove();
                    }

                }
            }
            else
            {
                Alert.Show("请选择要操作的节点");
            }
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddDept_Click(object sender, EventArgs e)
        {
            Dept dept = new Dept(instance, employeeInstance, null);
            dept.OperationType = OperationTypeEnum.Add;
            //dept.FormClosing += new FormClosingEventHandler(dept_FormClosing);
            if (tv_left.SelectedNode != null)
            {
                dept.SetDeptPCode(tv_left.SelectedNode.Name.ToString(), tv_left.SelectedNode.Text);
            }
            else
            {
                if (tv_left.Nodes.Count > 0)
                {
                    dept.SetDeptPCode(tv_left.Nodes[0].Name.ToString(), tv_left.Nodes[0].Text);
                }
            }
            dept.ShowDialog();
        }

        void dept_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnRefresh_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// 树节点选中后筛选数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_left_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectText = tv_left.SelectedNode.Tag != null ? tv_left.SelectedNode.Tag.ToString() : string.Empty;
            if (!string.IsNullOrEmpty(selectText))
            {
                string filter = selectText;
                if (tv_left.SelectedNode.Level == 0)
                {
                    filter = "";
                }
                RefreshGrid(filter);
            }
        }

        //private void tv_left_DoubleClick(object sender, EventArgs e)
        //{
        //    btnModify_Click(sender, e);
        //}

        //private void DeptInfo_Load(object sender, EventArgs e)
        //{

        //}

        private void tv_left_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    tvRoadCate.SelectedNode = tvRoadCate.GetNodeAt(e.X, e.Y);
            //    this.SelectedNode = tvRoadCate.SelectedNode;
            //    List<string> list = new List<string>();
            //    GetChildNode(this.SelectedNode, list);

            //    List<Road_Components> dataSource = rcInstance.GetListByRoadCate(list);
            //    //刷新数据源
            //    this.RefreshuGridLastAudit(dataSource);
            //}

            if (e.Button == MouseButtons.Left)
            {
                tv_left.SelectedNode = tv_left.GetNodeAt(e.X, e.Y);

                string selectText = tv_left.SelectedNode.Tag != null ? tv_left.SelectedNode.Tag.ToString() : string.Empty;
                if (!string.IsNullOrEmpty(selectText))
                {
                    string filter = selectText;
                    //if (tv_left.SelectedNode.Level == 0)
                    //{
                    //    filter = "";
                    //}
                    RefreshGrid(filter);
                }
            }
        }
    }
}
