using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QX.GenFramework.Helper;

namespace QX.GenFramework.BseControl
{
    public partial class CommonToolBar : UserControl
    {
        public CommonToolBar()
        {
            InitializeComponent();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAudit.Click += new EventHandler(btnAudit_Click);
            this.btnAuditHistory.Click += new EventHandler(btnAuditHistory_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            btn_look.Click += new EventHandler(btn_look_Click);
        }

        public void AddSearchModule(List<string> dic)
        {
            if (onSearchClicked != null)
            {
                DateTimePicker bDate = new DateTimePicker();
                bDate.Name = "bDate";
                DateTimePicker eDate = new DateTimePicker();
                eDate.Name = "eDate";
                ToolStripTextBox txtKey = new ToolStripTextBox();
                txtKey.Name = "Key";

                if (dic.Contains("bDate"))
                {
                    //时间控件
                    ToolStripLabel tLabel = new ToolStripLabel();
                    tLabel.Text = "开始时间:";
                    AddCustomControl(0, tLabel);

                    AddCDTPtoToolstrip(1, bDate);
                }

                if (dic.Contains("eDate"))
                {
                    bDate.Value = DateTime.Now.AddMonths(-1);
                    ToolStripLabel tLabel2 = new ToolStripLabel();
                    tLabel2.Text = "结束时间:";

                    AddCustomControl(2, tLabel2);


                    AddCDTPtoToolstrip(3, eDate);
                }

                if (dic.Contains("key"))
                {
                    eDate.Value = DateTime.Now;
                    ToolStripLabel tLabel3 = new ToolStripLabel();
                    tLabel3.Text = "关键字:";

                    AddCustomControl(4, tLabel3);

                    AddCustomControl(5, txtKey);

                }

                ToolBarHelper tsHelper = new ToolBarHelper();
                ToolStripButton SearchBtn = tsHelper.New("搜索", QX.GenFramework.Properties.Resources.search, new EventHandler(SearchBtn_Click));
                AddCustomControl(6, SearchBtn);
            }

        }


        public void AddSearchAllModule()
        {
            if (onSearchClicked != null)
            {
                DateTimePicker bDate = new DateTimePicker();
                bDate.Name = "bDate";
                DateTimePicker eDate = new DateTimePicker();
                eDate.Name = "eDate";
                ToolStripTextBox txtKey = new ToolStripTextBox();
                txtKey.Name = "Key";

                //时间控件
                ToolStripLabel tLabel = new ToolStripLabel();
                tLabel.Text = "开始时间:";
                AddCustomControl(0, tLabel);

                AddCDTPtoToolstrip(1, bDate);



                bDate.Value = DateTime.Now.AddDays(-7);
                ToolStripLabel tLabel2 = new ToolStripLabel();
                tLabel2.Text = "结束时间:";

                AddCustomControl(2, tLabel2);

               
                AddCDTPtoToolstrip(3, eDate);
                eDate.Value = DateTime.Now.AddDays(1);
                //eDate.Value = DateTime.Now;
                ToolStripLabel tLabel3 = new ToolStripLabel();
                tLabel3.Text = "关键字:";

                AddCustomControl(4, tLabel3);

                AddCustomControl(5, txtKey);


                ToolBarHelper tsHelper = new ToolBarHelper();
                ToolStripButton SearchBtn = tsHelper.New("搜索", QX.GenFramework.Properties.Resources.search, new EventHandler(SearchBtn_Click));
                AddCustomControl(6, SearchBtn);
            }

        }

        public string GetSearchValue(string key,string type)
        {
            string result = string.Empty;

            var temp = this.toolStrip1.Items.Find(key, true);
            if (temp != null&&temp.Length>0)
            {
                var val = temp[0];
                switch (type)
                {
                    case "Date":
                        ToolStripControlHost picker = val as ToolStripControlHost;

                        result = picker.Text;
                        break;
                    case "Text":
                        ToolStripTextBox txt = val as ToolStripTextBox;
                        result = txt.Text;
                        break;
                }
            }

            return result;
        }

        void SearchBtn_Click(object sender, EventArgs e)
        {
            if (onSearchClicked != null)
            {
                onSearchClicked.Invoke(this, e);
            }
        }






        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="tButton"></param>
        public void AddCustomControl(ToolStripItem tButton)
        {
            this.toolStrip1.Items.Add(tButton);
        }


        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="order">显示顺序</param>
        /// <param name="tButton"></param>
        public void AddCustomControl(int order, ToolStripItem tButton)
        {
            this.toolStrip1.Items.Insert(order, tButton);
        }


        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="order">显示顺序</param>
        /// <param name="tButton"></param>
        public void AddCustomControl(int order, ToolStripItem tButton, string direct)
        {
            switch (direct)
            {
                case "r":
                    tButton.Alignment =
    System.Windows.Forms.ToolStripItemAlignment.Right;
                    this.toolStrip1.Items.Insert(order, tButton);
                    break;
                case "l":
                    this.toolStrip1.Items.Insert(order, tButton);
                    break;
            }

        }

        public void AddCustomControl(int order, ToolStripControlHost item)
        {
            this.toolStrip1.Items.Insert(order, item);
        }

        /// <summary>
        /// 添加时间控件
        /// </summary>
        /// <param name="n"></param>
        /// <param name="dtp"></param>
        public void AddCDTPtoToolstrip(int n, DateTimePicker dtp)
        {
            //DateTimePicker dtp = new DateTimePicker();
            dtp.Width = 150;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtp.ShowUpDown = true;
            string name = dtp.Name;
            ToolStripControlHost host1 = new ToolStripControlHost(dtp);
            host1.Name = name;
            toolStrip1.Items.Insert(n, host1);
        }
        /// <summary>
        /// 添加时间控件
        /// </summary>
        /// <param name="dtp"></param>
        public void AddCDTPtoToolstrip(DateTimePicker dtp)
        {
            //DateTimePicker dtp = new DateTimePicker();
            dtp.Width = 150;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtp.ShowUpDown = true;
            ToolStripControlHost host1 = new ToolStripControlHost(dtp);
            toolStrip1.Items.Add(host1);
        }

        // Add Click Event
        private EventHandler onAddClicked;

        public event EventHandler AddClicked
        {
            add
            {
                onAddClicked += value;
            }
            remove
            {
                onAddClicked -= value;
            }
        }

        // Edit Click Event
        private EventHandler onEditClicked;

        public event EventHandler EditClicked
        {
            add
            {
                onEditClicked += value;
            }
            remove
            {
                onEditClicked -= value;
            }
        }

        // Del Click Event
        private EventHandler onDelClicked;

        public event EventHandler DelClicked
        {
            add
            {
                onDelClicked += value;
            }
            remove
            {
                onDelClicked -= value;
            }
        }


        // Query Click Event
        private EventHandler onQueryClicked;

        public event EventHandler QueryClicked
        {
            add
            {
                onQueryClicked += value;
            }
            remove
            {
                onQueryClicked -= value;
            }
        }



        // Print Click Event
        private EventHandler onPrintClicked;

        public event EventHandler PrintClicked
        {
            add
            {
                onPrintClicked += value;
            }
            remove
            {
                onPrintClicked -= value;
            }
        }

        // Saveas click event
        private EventHandler onSaveAsClicked;

        public event EventHandler SaveAsClicked
        {
            add
            {
                onSaveAsClicked += value;
            }
            remove
            {
                onSaveAsClicked -= value;
            }
        }

        //Refresh click event
        private EventHandler onRefreshClicked;

        public event EventHandler RefreshClicked
        {
            add
            {
                onRefreshClicked += value;
            }
            remove
            {
                onRefreshClicked -= value;
            }
        }


        public void SetAllButtonStat(bool stat)
        {

            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(ToolStrip))
                {
                    item.Visible = stat;
                    item.Enabled = stat;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBtnName">ADD- 添加按钮 EDIT-编辑按钮 DEL-删除按钮 QUERY-查询按钮 PRINT-打印预览按钮 REFRESH -更新按钮 SAVE 保存</param>
        /// <param name="bState">是否可用</param>
        /// <param name="visible">是否可见</param>
        public void SetButtonEnabled(string sBtnName, bool bState, bool visible)
        {
            switch (sBtnName.ToUpper())
            {
                case "ADD":
                    btn_add.Enabled = bState;
                    btn_add.Visible = visible;
                    break;

                case "EDIT":
                    btn_edit.Enabled = bState;
                    btn_edit.Visible = visible;
                    break;

                case "DEL":
                    btn_del.Enabled = bState;
                    btn_del.Visible = visible;
                    break;

                case "QUERY":
                    btn_query.Enabled = bState;
                    btn_query.Visible = visible;
                    break;


                case "PRINT":
                    btn_print.Enabled = bState;
                    btn_print.Visible = visible;
                    break;

                case "REFRESH":
                    btn_refresh.Enabled = bState;
                    btn_refresh.Visible = visible;
                    break;
                case "SAVE":
                    btnSave.Enabled = bState;
                    btnSave.Visible = visible;
                    break;
                case "AUDIT":
                    btnAudit.Enabled = bState;
                    btnAudit.Visible = visible;
                    break;
                case "AUDITHISTORY":
                    btnAuditHistory.Enabled = bState;
                    btnAuditHistory.Visible = visible;
                    break;
                case "CANCEL":
                    btnCancel.Enabled = bState;
                    btnCancel.Visible = visible;
                    break;
                case "LOOK":
                    btn_look.Enabled = bState;
                    btn_look.Visible = visible;
                    break;
                default:
                    MessageBox.Show("BpAEDQP收到了错误的参数: " + sBtnName + ", 程序操作失败。此信息由BpSoft的控件程序发出！", "程序错误");
                    break;
            }
        }


        // Edit Click Event
        private EventHandler onSearchClicked;

        public event EventHandler SearchClicked
        {
            add
            {
                onSearchClicked += value;
            }
            remove
            {
                onSearchClicked -= value;
            }
        }

        /// <summary>
        /// 设置图片和文字的显示样式
        /// </summary>
        /// <param name="style">none -默认  text- 只显示文字  image-只显示图片  all-图片和文字 </param>
        public void SetButtonStyle(string style)
        {
            foreach (ToolStripItem item in this.toolStrip1.Items)
            {
                if (item.GetType() == typeof(ToolStripButton))
                {
                    switch (style)
                    {
                        case "none": ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.None; break;
                        case "text": ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Text; break;
                        case "image": ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Image; break;
                        case "all": ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText; break;
                    }
                }
            }
        }

        private void SetTextImageRelation(string style)
        {

        }

        private void btn_add_Click(object sender, System.EventArgs e)
        {
            if (onAddClicked != null)
            {
                onAddClicked.Invoke(this, new System.EventArgs());
            }
        }

        private void btn_edit_Click(object sender, System.EventArgs e)
        {
            if (onEditClicked != null)
            {
                onEditClicked.Invoke(this, new System.EventArgs());
            }
        }

        private void btn_del_Click(object sender, System.EventArgs e)
        {
            if (onDelClicked != null)
            {
                onDelClicked.Invoke(this, new System.EventArgs());
            }
        }

        private void btn_query_Click(object sender, System.EventArgs e)
        {
            if (onQueryClicked != null)
            {
                onQueryClicked.Invoke(this, new System.EventArgs());
            }
        }

        private void btn_print_Click(object sender, System.EventArgs e)
        {
            if (onPrintClicked != null)
            {
                onPrintClicked.Invoke(this, new System.EventArgs());
            }
        }

        private void btn_saveas_Click(object sender, System.EventArgs e)
        {
            onSaveAsClicked.Invoke(this, new System.EventArgs());
        }

        private void btn_refresh_Click(object sender, System.EventArgs e)
        {
            if (onRefreshClicked != null)
            {
                onRefreshClicked.Invoke(this, new System.EventArgs());
            }
        }

        private void CommonToolBar_Load(object sender, EventArgs e)
        {


            //foreach (ToolStripItem item in this.toolStrip1.Items)
            //{

            //}
            if (this.onAddClicked == null)
            {
                this.btn_add.Visible = false;
            }

            if (this.onEditClicked == null)
            {
                btn_edit.Visible = false;
            }


            if (this.onDelClicked == null)
            {
                btn_del.Visible = false;
            }

            if (this.onPrintClicked == null)
            {
                this.btn_print.Visible = false;
            }

            if (this.onQueryClicked == null)
            {
                btn_query.Visible = false;
            }

            if (this.onRefreshClicked == null)
            {
                this.btn_refresh.Visible = false;
            }


            if (this.onAuditClicked == null)
            {

                this.btnAudit.Visible = false;
            }


            if (this.onSaveClicked == null)
            {

                this.btnSave.Visible = false;
            }
            if (this.onCancelClicked == null)
            {

                this.btnCancel.Visible = false;
            }
            if (this.onAuditHistoryClicked == null)
            {

                this.btnAuditHistory.Visible = false;
            }
            if (this.onLookClicked == null)
            {
                this.btn_look.Visible = false;
            }
        }


        private EventHandler onAuditClicked;
        /// <summary>
        /// 审核
        /// </summary>
        public event EventHandler AuditClicked
        {
            add
            {
                onAuditClicked += value;
            }
            remove
            {
                onAuditClicked -= value;
            }
        }

        private EventHandler onAuditHistoryClicked;
        /// <summary>
        /// 审核
        /// </summary>
        public event EventHandler AuditHistoryClicked
        {
            add
            {
                onAuditHistoryClicked += value;
            }
            remove
            {
                onAuditHistoryClicked -= value;
            }
        }
        private EventHandler onSaveClicked;

        public event EventHandler SaveClicked
        {
            add
            {
                onSaveClicked += value;
            }
            remove
            {
                onSaveClicked -= value;
            }
        }
        private EventHandler onCancelClicked;

        public event EventHandler CancelClicked
        {
            add
            {
                onCancelClicked += value;
            }
            remove
            {
                onCancelClicked -= value;
            }
        }
        private EventHandler onLookClicked;

        public event EventHandler LookClicked
        {
            add
            {
                onLookClicked += value;
            }
            remove
            {
                onLookClicked -= value;
            }
        }
        private void btnAudit_Click(object sender, EventArgs e)
        {
            onAuditClicked.Invoke(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            onSaveClicked.Invoke(sender, e);
        }
        void btnAuditHistory_Click(object sender, EventArgs e)
        {
            onAuditHistoryClicked.Invoke(sender, e);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            onCancelClicked.Invoke(sender, e);
        }

        void btn_look_Click(object sender, EventArgs e)
        {
            onLookClicked.Invoke(sender, e);
        }

    }
}
