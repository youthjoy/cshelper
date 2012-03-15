using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

namespace QX.UI.Dept
{
    public partial class Dept : Bse_PopForm
    {
        public Dept()
        {
            InitializeComponent();
        }
        private Bll_Dept instance;
        private Bll_Bse_Employee employeeInstance;
        private Bse_Department GModel;

        private OperationTypeEnum operationType;
        public OperationTypeEnum OperationType
        {
            get { return operationType; }
            set { operationType = value; }
        }

        public Dept(Bll_Dept _instance, Bll_Bse_Employee _employeeInstance, Bse_Department _model)
        {
            this.Refresh();
            InitializeComponent();
            instance = _instance;
            employeeInstance = _employeeInstance;
            GModel = _model;

            this.Load += new EventHandler(Dept_Load);
        }


        public Dept(string pCode, string pName, Bll_Dept _instance, Bll_Bse_Employee _employeeInstance, Bse_Department _model)
        {
            this.Refresh();
            InitializeComponent();
            instance = _instance;
            employeeInstance = _employeeInstance;
            GModel = _model;

            this.Load+=new EventHandler(Dept_Load);
        }

        private string PCode
        {
            get;
            set;
        }

        private string PName
        {
            get;
            set;
        }




        /// <summary>
        /// 获取窗体中所有控件
        /// </summary>
        /// <returns></returns>
        private Control.ControlCollection AllControls()
        {
            //WinformHelper winhelper = new WinformHelper(this.Controls);
            //Control.ControlCollection contrls = winhelper.GetAllControl(this.Controls);
            //return contrls;

            return null;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private bool SaveData()
        {
            bool result = true;
            //if (!Validata())
            //{
            //    return result;
            //}
            //Bse_Department dept = new Bse_Department();
            BindModelHelper modelHepler = new BindModelHelper();


            //helper.BindControlToModel(dept, AllControls());
            modelHepler.BindControlToModel<Bse_Department>(GModel, this.groupBox1.Controls, "");
            modelHepler.BindControlToModel<Bse_Department>(GModel, this.panel1.Controls, "");
            modelHepler.BindControlToModel<Bse_Department>(GModel, this.panel2.Controls, "");

            switch (operationType)
            {
                case OperationTypeEnum.Look:
                    break;
                case OperationTypeEnum.Edit:
   
                    result = instance.UpdateDept(GModel);
        
                    break;
                case OperationTypeEnum.Add:

                    var re = instance.InsertDept(GModel);
                    if (re != 0)
                    {
                        GModel.Dept_ID = re;
                        result = true;
                    }
                   
                    break;
                default:
                    break;
            }

            MessageShow(result);
            return result;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dept_Load(object sender, EventArgs e)
        {

            FormHelper gen = new FormHelper();

            gen.GenerateForm("FDept", this.groupBox1, new Point(6, 20));
            gen.GenerateForm("FODept", this.panel1, new Point(6, 20));
            gen.GenerateForm("FBDept", this.panel2, new Point(6, 20));
            //保存按钮：保存并关闭
            btnSave.Click += new EventHandler(btnSave_Click);
            btnOk.Click += new EventHandler(btnOk_Click);
            //btnDel.Click += new EventHandler(btnDel_Click);
            //弹出部门选择
            //Dept_PCode.Click+=new EventHandler(Dept_PCode_Click);
            //Dept_PName.Click += new EventHandler(Dept_PCode_Click);

            //弹出人员选择窗口
            //Dept_Owner.Click += new EventHandler(Dept_Owner_Click);
            //Dept_OwnerName.Click += new EventHandler(Dept_Owner_Click);
            //Dept_OMob.Click += new EventHandler(Dept_Owner_Click);
            //Dept_OTel.Click += new EventHandler(Dept_Owner_Click);
            BindModelHelper modelHepler = new BindModelHelper();
            //操作类型
            switch (operationType)
            {
                case OperationTypeEnum.Look:
                    break;
                case OperationTypeEnum.Edit:

                    //modelHepler.BindModelToControl<Bse_Department>(GModel, AllControls());
                    modelHepler.BindModelToControl<Bse_Department>(GModel, this.groupBox1.Controls, "");
                    modelHepler.BindModelToControl<Bse_Department>(GModel, this.panel1.Controls, "");
                    modelHepler.BindModelToControl<Bse_Department>(GModel, this.panel2.Controls, "");

                    break;
                case OperationTypeEnum.Add:
                    GModel = new Bse_Department();
                    GModel.Dept_Code = instance.GenerateDeptCode();
                    modelHepler.BindModelToControl<Bse_Department>(GModel, this.groupBox1.Controls, "");
                    modelHepler.BindModelToControl<Bse_Department>(GModel, this.panel1.Controls, "");
                    modelHepler.BindModelToControl<Bse_Department>(GModel, this.panel2.Controls, "");
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 人员选择弹出窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Dept_Owner_Click(object sender, EventArgs e)
        {
            //CommUser<Bll_Dept, Bll_Bse_Employee, Bse_Department, Bse_Employee> user =
            //    new CommUser<Bll_Dept, Bll_Bse_Employee, Bse_Department, Bse_Employee>(instance, employeeInstance,
            //        new Size(460, 380));
            //user.CallBack += new CommUser<Bll_Dept, Bll_Bse_Employee, Bse_Department, Bse_Employee>.DCallBackHandler(user_CallBack);
            //user.ShowDialog();
        }

        void user_CallBack(object sender, DataTable list)
        {
            if (list != null && list.Rows.Count > 0)
            {
                //Dept_Owner.Text = list.Rows[0]["Emp_Code"] != null ? list.Rows[0]["Emp_Code"].ToString() : string.Empty;
                //Dept_OwnerName.Text = list.Rows[0]["Emp_Name"] != null ? list.Rows[0]["Emp_Name"].ToString() : string.Empty;
                //Dept_OMob.Text = list.Rows[0]["Emp_Mobile"] != null ? list.Rows[0]["Emp_Mobile"].ToString() : string.Empty;
                //Dept_OTel.Text = list.Rows[0]["Emp_OffTel"] != null ? list.Rows[0]["Emp_OffTel"].ToString() : string.Empty;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnDel_Click(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(Dept_ID.Text))
            //{
            //    BindModelHelper modelHepler = new BindModelHelper();
            //    Bse_Department model = new Bse_Department();
            //    modelHepler.BindControlToModel<Bse_Department>(model, AllControls());
            //    bool result = instance.DeleteDept(Dept_ID.Text);
            //    MessageShow(result);
            //}
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                operationType = OperationTypeEnum.Edit;
            }
        }

        ///// <summary>
        ///// 添加数据按钮事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.Close();
            }
        }

        ///// <summary>
        ///// 弹出部门选择窗口
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Dept_PCode_Click(object sender, EventArgs e)
        //{
        //    CommDept<Bll_Dept, Bse_Department> CommDept = new CommDept<Bll_Dept, Bse_Department>(instance,
        //        new Size(350, 350));
        //    CommDept.CallBack += new CommDept<Bll_Dept, Bse_Department>.DCallBackHandler(CommDept_CallBack);
        //    CommDept.ShowDialog();
        //}

        ///// <summary>
        ///// 用户选择后的返回事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="list"></param>
        //void CommDept_CallBack(object sender, DataTable list)
        //{
        //    if (list.Rows.Count == 1)
        //    {
        //        //Dept_PCode.Text = list.Rows[0]["Dept_Code"].ToString();
        //        //Dept_PName.Text = list.Rows[0]["Dept_Name"].ToString();
        //    }
        //}

        /// <summary>
        /// 检查部门是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckDeptIsExist(string NodeCode)
        {
            bool result = false;
            Bse_Department model = instance.GetDeptModel(" AND (Dept_Code='" + NodeCode + "')");
            if (!String.IsNullOrEmpty(model.Dept_Code))
            {
                result = true;
                Alert.Show("您输入的部门已存在，请查证后重新输入");
            }
            return result;
        }

        /// <summary>
        /// 操作提示
        /// </summary>
        /// <param name="result"></param>
        public void MessageShow(bool result)
        {
            if (result)
            {
                Alert.Show("数据更新成功");
            }
            else
            {
                Alert.Show("数据更新失败");
            }
        }

        /// <summary>
        /// 设置父类显示
        /// </summary>
        /// <param name="_Dept_PCode"></param>
        /// <param name="_Dept_PName"></param>
        public void SetDeptPCode(string _Dept_PCode, string _Dept_PName)
        {
            //this.Dept_PCode.Text = _Dept_PCode;
            //this.Dept_PName.Text = _Dept_PName;
        }

        ///// <summary>
        ///// 数据验证
        ///// </summary>
        ///// <returns></returns>
        //private bool Validata()
        //{
        //    bool flag = true;
        //    Dictionary<string, ValidateModel> dict = new Dictionary<string, ValidateModel>();
        //    //dict.Add("Dept_Code", new ValidateModel(@"\d+", "部门编号必须是数字"));
        //    Dictionary<string, string> re = ValidateControlHelper.Validate(AllControls(), dict);
        //    if (re.Count != 0)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (KeyValuePair<string, string> k in re)
        //        {
        //            sb.AppendLine(k.Value);
        //        }
        //        Alert.Show(sb.ToString());
        //        flag = false;
        //    }
        //    return flag;
        //}
    }
}
