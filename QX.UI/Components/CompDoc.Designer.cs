namespace QX.UI.Components
{
    partial class CompDoc
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
            this.top_tool_bar = new QX.GenFramework.BseControl.CommonToolBar();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Location = new System.Drawing.Point(0, 42);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(784, 520);
            this.pnlGrid.TabIndex = 3;
            // 
            // top_tool_bar
            // 
            this.top_tool_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_tool_bar.Location = new System.Drawing.Point(0, 0);
            this.top_tool_bar.Name = "top_tool_bar";
            this.top_tool_bar.Size = new System.Drawing.Size(784, 40);
            this.top_tool_bar.TabIndex = 2;
            // 
            // CompDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.top_tool_bar);
            this.Name = "CompDoc";
            this.Text = "CompDoc";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private QX.GenFramework.BseControl.CommonToolBar top_tool_bar;
    }
}