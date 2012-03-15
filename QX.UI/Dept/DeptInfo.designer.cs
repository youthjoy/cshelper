namespace QX.UI.Dept
{
    partial class DeptInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv_left = new System.Windows.Forms.TreeView();
            this.tool_left = new QX.Common.BseControl.CommonToolBar();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.tool_right = new QX.Common.BseControl.CommonToolBar();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv_left);
            this.splitContainer1.Panel1.Controls.Add(this.tool_left);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlGrid);
            this.splitContainer1.Panel2.Controls.Add(this.tool_right);
            this.splitContainer1.Size = new System.Drawing.Size(779, 456);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.TabIndex = 0;
            // 
            // tv_left
            // 
            this.tv_left.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_left.Location = new System.Drawing.Point(3, 44);
            this.tv_left.Name = "tv_left";
            this.tv_left.Size = new System.Drawing.Size(253, 409);
            this.tv_left.TabIndex = 1;
            // 
            // tool_left
            // 
            this.tool_left.Dock = System.Windows.Forms.DockStyle.Top;
            this.tool_left.Location = new System.Drawing.Point(0, 0);
            this.tool_left.Name = "tool_left";
            this.tool_left.Size = new System.Drawing.Size(259, 40);
            this.tool_left.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Location = new System.Drawing.Point(3, 43);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(513, 413);
            this.pnlGrid.TabIndex = 1;
            // 
            // tool_right
            // 
            this.tool_right.Dock = System.Windows.Forms.DockStyle.Top;
            this.tool_right.Location = new System.Drawing.Point(0, 0);
            this.tool_right.Name = "tool_right";
            this.tool_right.Size = new System.Drawing.Size(516, 40);
            this.tool_right.TabIndex = 0;
            // 
            // DeptInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 456);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DeptInfo";
            this.Text = "部门人员维护";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tv_left;
        private QX.Common.BseControl.CommonToolBar tool_left;
        private System.Windows.Forms.Panel pnlGrid;
        private QX.Common.BseControl.CommonToolBar tool_right;



    }
}