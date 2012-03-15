using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QX.Model;
using QX.GenFramework.BseControl;
using QX.GenFramework.AutoForm;
using QX.GenFramework.Helper;
using QX.BLL;
using QX.Helper;
using QX.UI.Comm;

namespace QX.UI.Components
{
    public partial class BatchComp : Form
    {
        public BatchComp()
        {
            InitializeComponent();

            this.Load += new EventHandler(BatchComp_Load);
        }

        public delegate void DCallBackHandler(bool flag);
        public event DCallBackHandler CallBack;

        void BatchComp_Load(object sender, EventArgs e)
        {
            Bll_Bse_Dict dictInstance = new Bll_Bse_Dict();
            DictList = dictInstance.GetDictByKey("DocType");
            GModel = new Prod_Components();
            this.FormClosed += new FormClosedEventHandler(BatchComp_FormClosed);
            BindData();
        }

        public List<Bse_Dict> DictList
        {
            get;
            set;
        }

        void BatchComp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CallBack != null)
            {
                CallBack(true);
            }
        }

        FormHelper formHelper = new FormHelper();

        BindModelHelper bmHelper = new BindModelHelper();

        private Prod_Components GModel
        {
            get;
            set;
        }

        public void BindData()
        {
            formHelper.GenerateForm("CForm_BatchComp", this.groupBox2, new Point(20, 20));
        }

        private BLL.Bll_Comp compInstance = new QX.BLL.Bll_Comp();

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string pre = txtPre.Text;

            int len = Common.Utils.TypeConverter.ObjectToInt(this.txtLen.Text);

            if (string.IsNullOrEmpty(this.txtStart.Text))
            {
                Alert.Show("请输入起始编号!");
                return;
            }

            if (string.IsNullOrEmpty(this.txtEnd.Text))
            {
                Alert.Show("请输入结束编号!");
                return;
            }

            bmHelper.BindControlToModel<Prod_Components>(GModel, this.groupBox2.Controls, "");

            int start = Common.Utils.TypeConverter.ObjectToInt(txtStart.Text);
            int end = Common.Utils.TypeConverter.ObjectToInt(txtEnd.Text);
            List<Prod_Components> list = compInstance.GetPComponentsList();
            List<string> newCompList = new List<string>();

            StringBuilder sb = new StringBuilder();
            //int successCount = 0;
            for (int i = start; i <= end; i++)
            {
                string index = i.ToString();
                string result = string.Empty;
                if (len != 0)
                {
                    result = index.PadLeft(len, '0');
                }
                else
                {
                    result = index;
                }

                string compno = pre + result;

                if (list.FirstOrDefault(o => o.PRDC_CompNo == compno) != null)
                {
                    sb.Append(compno).Append(",");
                    continue;
                }

                Prod_Components comp = new Prod_Components();

                if (string.IsNullOrEmpty(compno))
                {
                    continue;
                }

                comp = GModel;
                comp.PRDC_CompNo = compno;
                comp.CreateTime = DateTime.Now;
                comp.UpdateTime = DateTime.Now;
                comp.PRDC_RecDate = DateTime.Now;
                comp.PRDC_iType = iTypeEnum.Comp.ToString();
                comp.PRDC_VerifyResult = "Check";
                
                compInstance.CompInsert(comp);

                newCompList.Add(compno);
                
            }



            this.txtStart.Text = string.Empty;
            this.txtEnd.Text = string.Empty;

            InsertDocument(newCompList);


            if (sb.ToString().Length != 0)
            {

                //Alert.Show(string.Format("以下零件编号已经存在请确认后重新输入"));
                MsgBox msgBox = new MsgBox(string.Format("成功生成{0}个，另外以下零件编号已存在请确认后重新输入:\n{1}", newCompList.Count,sb.ToString().Trim(',')));
                msgBox.Show();
            }
            else
            {
                Alert.Show("批量生成成功!");
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void InsertDocument(List<string> list)
        {

            List<Tpl_ReqDoc> dlist = new List<Tpl_ReqDoc>();
            if (!string.IsNullOrEmpty(GModel.PRDC_CompCode))
            {
                dlist = compInstance.GetReqDocByComp(GModel.PRDC_CompCode);
            }



            foreach (var c in list)
            {
                foreach (var d in dlist)
                {
                    Prod_Doc doc = new Prod_Doc();
                    doc.PRDQ_CompNo = c;
                    doc.PRDQ_CompCode = GModel.PRDC_CompCode;
                    doc.PRDQ_CompName = GModel.PRDC_CompName;
                    doc.PRDQ_Type = d.TPRD_Type;
                    doc.PRDQ_IsNeed = d.TPRD_IsReq;
                    doc.PRDQ_iType = iTypeEnum.Comp.ToString();
                    var dict = DictList.FirstOrDefault(o => o.Dict_Code == d.TPRD_Type);
                    doc.PRDQ_Name = dict.Dict_Name + "报告";
                    compInstance.PDocInsert(doc);
                }
            }
        }
    }
}
