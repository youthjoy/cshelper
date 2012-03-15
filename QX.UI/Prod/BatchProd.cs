using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QX.Common.BseControl;
using QX.Model;
using QX.Common.BseControl;
using QX.Framework.AutoForm;
using QX.Common.Helper;
using QX.Helper;
using QX.UI.Comm;
namespace QX.UI.Prod
{
    public partial class BatchProd : Bse_PopForm
    {
        public BatchProd()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);

            this.btnConfirm.Click+=new EventHandler(btnConfirm_Click);
            this.btnCancel.Click+=new EventHandler(btnCancel_Click);
        }

        public delegate void DCallBackHandler(bool flag);
        public event DCallBackHandler CallBack;

        void Form_Load(object sender, EventArgs e)
        {
            GModel = new Prod_Pool();
            this.FormClosed += new FormClosedEventHandler(BatchComp_FormClosed);
            BindData();
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

        private Prod_Pool GModel
        {
            get;
            set;
        }

        public void BindData()
        {
            formHelper.GenerateForm("CForm_ProdBatch", this.groupBox2, new Point(20, 20));
        }

        private BLL.Bll_Prod compInstance = new QX.BLL.Bll_Prod();

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

            bmHelper.BindControlToModel<Prod_Pool>(GModel, this.groupBox2.Controls, "");

            int start = Common.Utils.TypeConverter.ObjectToInt(txtStart.Text);
            int end = Common.Utils.TypeConverter.ObjectToInt(txtEnd.Text);
            List<Prod_Pool> list = compInstance.GetAllProdCompList();

            StringBuilder sb = new StringBuilder();

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

                if (list.FirstOrDefault(o => o.PRP_ProdCode==compno) != null)
                {
                    sb.Append(compno).Append(",");
                    continue;
                }
                Prod_Pool comp = new Prod_Pool();
                comp = GModel;
                comp.PRP_ProdCode = compno;
                comp.CreateTime = DateTime.Now;
                comp.UpdateTime = DateTime.Now;
                comp.PRP_IDate = DateTime.Now;
                //comp.PRDC_RecDate = DateTime.Now;
                comp.PRP_iType = ProdStat.In.ToString();
                compInstance.PCInsert(comp);
            }



            this.txtStart.Text = string.Empty;
            this.txtEnd.Text = string.Empty;
            if (sb.ToString().Length != 0)
            {

                //Alert.Show(string.Format("以下零件编号已经存在请确认后重新输入"));
                MsgBox msgBox = new MsgBox(string.Format("以下成品编号已存在请确认后重新输入:\n{0}", sb.ToString().Trim(',')));
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
    }
}
