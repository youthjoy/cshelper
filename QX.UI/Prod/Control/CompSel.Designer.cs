namespace QX.UI.Prod.Control
{
    partial class CompSel
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
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.top_tool_bar = new QX.Common.BseControl.CommonToolBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlGrid.Location = new System.Drawing.Point(0, 40);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(470, 322);
            this.pnlGrid.TabIndex = 7;
            // 
            // top_tool_bar
            // 
            this.top_tool_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_tool_bar.Location = new System.Drawing.Point(0, 0);
            this.top_tool_bar.Name = "top_tool_bar";
            this.top_tool_bar.Size = new System.Drawing.Size(784, 40);
            this.top_tool_bar.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(529, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 322);
            this.panel1.TabIndex = 8;
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(477, 123);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(46, 23);
            this.btn_left.TabIndex = 9;
            this.btn_left.Text = ">>";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // btn_right
            // 
            this.btn_right.Location = new System.Drawing.Point(477, 152);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(46, 23);
            this.btn_right.TabIndex = 9;
            this.btn_right.Text = "<<";
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.btn_right_Click);
            // 
            // CompSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.btn_right);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.top_tool_bar);
            this.Name = "CompSel";
            this.Text = "零件编号选择";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private QX.Common.BseControl.CommonToolBar top_tool_bar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_right;
    }
}