using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QX.Common.BseControl;
using QX.Gen;
using QX.GenFramework;
using QX.Framework;
using QX.Framework.AutoForm;
using Infragistics.Win.UltraWinGrid;
using QX.Model;
using QX.Common.Helper;
using QX.Helper;

namespace QX.UI.Components
{
    public partial class CompOp : Bse_PopForm
    {
        public CompOp(Tpl_Components item, OperationTypeEnum op)
        {
            InitializeComponent();
            opType = op;

            GModel = item;

            this.Load += new EventHandler(Form_Load);
            this.FormClosed += new FormClosedEventHandler(CompOp_FormClosed);
            BindTopTool();
        }

        void CompOp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CallBack != null)
            {
                CallBack(true);
            }
        }

        public delegate void DCallBackHandler(bool flag);
        public event DCallBackHandler CallBack;

        private Tpl_Components GModel
        {
            get;
            set;
        }

        public void BindTopTool()
        {
            this.top_tool_bar.SaveClicked += new EventHandler(top_tool_bar_SaveClicked);
        }

        void top_tool_bar_SaveClicked(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Alert.Show("数据更新完成!");

            }
        }

        #region 操作句柄
        private GridHelper gen = new GridHelper();

        FormHelper formHelper = new FormHelper();

        BindModelHelper bmHelper = new BindModelHelper();

        private BLL.Bll_Comp compInstance = new QX.BLL.Bll_Comp();

        public OperationTypeEnum opType
        {
            get;
            set;
        }

        #endregion


        void Form_Load(object sender, EventArgs e)
        {
            InitData();

            BindData();
        }

        public void InitData()
        {
            formHelper.GenerateForm("CForm_Components", this.gpBse, new Point(20, 20));
         
            gen.GenerateColumn("CList_ReqDoc", comGrid, new Point(0, 0));
            comGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            List<Tpl_ReqDoc> list = new List<Tpl_ReqDoc>();
            BindingSource source = new BindingSource();
            source.DataSource = list;
            comGrid.DataSource = source;

            switch (opType)
            {
                case OperationTypeEnum.Add:
                    GModel.TPLC_Code = compInstance.GenerateCompCode();
                    bmHelper.BindModelToControl<Tpl_Components>(GModel, this.gpBse.Controls, "");
                   

                    break;
                case OperationTypeEnum.Edit:
                    bmHelper.BindModelToControl<Tpl_Components>(GModel, this.gpBse.Controls, "");
                    break;
                case OperationTypeEnum.Look:
                    top_tool_bar.SetButtonEnabled("save", false, true);
                    gen.SetGridReadOnly(comGrid, true);
                    break;
            }

        }

        public void BindData()
        {
            bmHelper.BindModelToControl<Tpl_Components>(GModel, this.gpBse.Controls, "");

            List<Tpl_ReqDoc> list = compInstance.GetReqDocByComp(GModel.TPLC_Code);
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = list;
            comGrid.DataSource = dataSource;

            if (comGrid.Rows.Count == 0)
            {
                BLL.Bll_Bse_Dict dictInstance = new QX.BLL.Bll_Bse_Dict();
                List<Bse_Dict> list1 = dictInstance.GetDictByKey("DocType");

                foreach (var d in list1)
                {
                    UltraGridRow nrow = comGrid.DisplayLayout.Bands[0].AddNew();
                    nrow.Cells["TPRD_Type"].Value = d.Dict_Code;
                    nrow.Cells["TPRD_IsReq"].Value = "Yes";
                }
            }
        }

        public bool SaveData()
        {
            bool flag = true;
            switch (opType)
            {
                case OperationTypeEnum.Add:
                    bmHelper.BindControlToModel<Tpl_Components>(GModel, this.gpBse.Controls, "");
                    var re = compInstance.AddComp(GModel);

                    if (re > 0)
                    {

                        GModel.TPLC_ID = re;
                        opType = OperationTypeEnum.Edit;
                        bmHelper.BindModelToControl<Tpl_Components>(GModel, this.gpBse.Controls, "");
                        //bmHelper.ClearControl<PC_CPlan>(GModel, this.gpOther.Controls, "");
                    }


                    break;
                case OperationTypeEnum.Edit:
                    bmHelper.BindControlToModel<Tpl_Components>(GModel, this.gpBse.Controls, "");

                    flag = compInstance.UpdateComp(GModel);

                    break;
                case OperationTypeEnum.Look:

                    break;
            }
            SaveGrid();

            return flag;

        }

        public void SaveGrid()
        {
            List<Tpl_ReqDoc> list = new List<Tpl_ReqDoc>();
            foreach (var row in comGrid.Rows)
            {
                Tpl_ReqDoc doc = row.ListObject as Tpl_ReqDoc;
                list.Add(doc);
            }

            compInstance.AddOrUpdateCDoc(GModel, list);
        }
    }
}
