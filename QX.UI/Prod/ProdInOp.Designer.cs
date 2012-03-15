namespace QX.UI.Prod
{
    partial class ProdInOp
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.top_tool_bar = new QX.Common.BseControl.CommonToolBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucProdOut = new QX.UI.Prod.ProdOut();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.prodAll = new QX.UI.Prod.ProdAll();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 362);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlGrid);
            this.tabPage1.Controls.Add(this.top_tool_bar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "成品信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Location = new System.Drawing.Point(0, 41);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(576, 292);
            this.pnlGrid.TabIndex = 3;
            // 
            // top_tool_bar
            // 
            this.top_tool_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_tool_bar.Location = new System.Drawing.Point(3, 3);
            this.top_tool_bar.Name = "top_tool_bar";
            this.top_tool_bar.Size = new System.Drawing.Size(570, 40);
            this.top_tool_bar.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucProdOut);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 336);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "已出库成品";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucProdOut
            // 
            this.ucProdOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProdOut.Location = new System.Drawing.Point(3, 3);
            this.ucProdOut.Name = "ucProdOut";
            this.ucProdOut.Size = new System.Drawing.Size(570, 330);
            this.ucProdOut.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.prodAll);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(576, 336);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "所有成品列表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // prodAll
            // 
            this.prodAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prodAll.Location = new System.Drawing.Point(0, 0);
            this.prodAll.Name = "prodAll";
            this.prodAll.Size = new System.Drawing.Size(576, 336);
            this.prodAll.TabIndex = 0;
            // 
            // ProdInOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.tabControl1);
            this.Name = "ProdInOp";
            this.Text = "ProdInOp";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlGrid;
        private QX.Common.BseControl.CommonToolBar top_tool_bar;
        private System.Windows.Forms.TabPage tabPage2;
        private ProdOut ucProdOut;
        private System.Windows.Forms.TabPage tabPage3;
        private ProdAll prodAll;

    }
}