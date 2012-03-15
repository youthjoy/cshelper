namespace QX.GenFramework.BseControl
{
    partial class CommonToolBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonToolBar));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_look = new System.Windows.Forms.ToolStripButton();
            this.btn_del = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnAudit = new System.Windows.Forms.ToolStripButton();
            this.btnAuditHistory = new System.Windows.Forms.ToolStripButton();
            this.btn_query = new System.Windows.Forms.ToolStripButton();
            this.btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.btn_print = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_edit,
            this.btn_look,
            this.btn_del,
            this.btnSave,
            this.btnCancel,
            this.btnAudit,
            this.btnAuditHistory,
            this.btn_query,
            this.btn_refresh,
            this.btn_print});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(400, 40);
            this.toolStrip1.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_add.Image = global::QX.GenFramework.Properties.Resources.add;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_add.Size = new System.Drawing.Size(49, 37);
            this.btn_add.Text = "添加&A";
            this.btn_add.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.Image")));
            this.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_edit.Size = new System.Drawing.Size(49, 37);
            this.btn_edit.Text = "编辑&E";
            this.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_look
            // 
            this.btn_look.Image = global::QX.GenFramework.Properties.Resources.look;
            this.btn_look.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_look.Name = "btn_look";
            this.btn_look.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_look.Size = new System.Drawing.Size(43, 37);
            this.btn_look.Text = "查看";
            this.btn_look.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btn_del
            // 
            this.btn_del.Image = ((System.Drawing.Image)(resources.GetObject("btn_del.Image")));
            this.btn_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_del.Name = "btn_del";
            this.btn_del.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_del.Size = new System.Drawing.Size(43, 37);
            this.btn_del.Text = "删除";
            this.btn_del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = global::QX.GenFramework.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(43, 37);
            this.btnSave.Text = "保存&S";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::QX.GenFramework.Properties.Resources.cancel;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(49, 37);
            this.btnCancel.Text = "取消&C";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnAudit
            // 
            this.btnAudit.AutoSize = false;
            this.btnAudit.Image = global::QX.GenFramework.Properties.Resources.audit;
            this.btnAudit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(43, 37);
            this.btnAudit.Text = "审核&C";
            this.btnAudit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnAuditHistory
            // 
            this.btnAuditHistory.Image = global::QX.GenFramework.Properties.Resources.hitory;
            this.btnAuditHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAuditHistory.Name = "btnAuditHistory";
            this.btnAuditHistory.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAuditHistory.Size = new System.Drawing.Size(67, 32);
            this.btnAuditHistory.Text = "审核记录";
            this.btnAuditHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btn_query
            // 
            this.btn_query.Image = ((System.Drawing.Image)(resources.GetObject("btn_query.Image")));
            this.btn_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_query.Name = "btn_query";
            this.btn_query.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_query.Size = new System.Drawing.Size(43, 32);
            this.btn_query.Text = "查找";
            this.btn_query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_refresh.Size = new System.Drawing.Size(43, 32);
            this.btn_refresh.Text = "刷新";
            this.btn_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_print
            // 
            this.btn_print.Image = ((System.Drawing.Image)(resources.GetObject("btn_print.Image")));
            this.btn_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_print.Name = "btn_print";
            this.btn_print.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_print.Size = new System.Drawing.Size(67, 32);
            this.btn_print.Text = "打印预览";
            this.btn_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // CommonToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "CommonToolBar";
            this.Size = new System.Drawing.Size(400, 40);
            this.Load += new System.EventHandler(this.CommonToolBar_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_del;
        private System.Windows.Forms.ToolStripButton btn_query;
        private System.Windows.Forms.ToolStripButton btn_print;
        private System.Windows.Forms.ToolStripButton btn_refresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnAudit;
        private System.Windows.Forms.ToolStripButton btnAuditHistory;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btn_look;
    }
}
