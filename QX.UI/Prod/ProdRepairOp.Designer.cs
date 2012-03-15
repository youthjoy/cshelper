namespace QX.UI.Prod
{
    partial class ProdRepairOp
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
            this.top_tool_bar = new QX.Common.BseControl.CommonToolBar();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // top_tool_bar
            // 
            this.top_tool_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_tool_bar.Location = new System.Drawing.Point(0, 0);
            this.top_tool_bar.Name = "top_tool_bar";
            this.top_tool_bar.Size = new System.Drawing.Size(584, 40);
            this.top_tool_bar.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Location = new System.Drawing.Point(0, 42);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(584, 146);
            this.pnlGrid.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 276);
            this.panel1.TabIndex = 2;
            // 
            // ProdRepairOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.top_tool_bar);
            this.Name = "ProdRepairOp";
            this.Text = "ProdRepairOp";
            this.ResumeLayout(false);

        }

        #endregion

        private QX.Common.BseControl.CommonToolBar top_tool_bar;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel panel1;
    }
}