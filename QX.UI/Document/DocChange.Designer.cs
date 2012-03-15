namespace QX.UI.Document
{
    partial class DocChange
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlDoc = new System.Windows.Forms.Panel();
            this.top_tool_bar = new QX.Common.BseControl.CommonToolBar();
            this.pnlChange = new System.Windows.Forms.Panel();
            this.top_tool_bar1 = new QX.Common.BseControl.CommonToolBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 293);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlDoc);
            this.tabPage1.Controls.Add(this.top_tool_bar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 267);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "未转储列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlChange);
            this.tabPage2.Controls.Add(this.top_tool_bar1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(683, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "已转储列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlDoc
            // 
            this.pnlDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDoc.Location = new System.Drawing.Point(3, 43);
            this.pnlDoc.Name = "pnlDoc";
            this.pnlDoc.Size = new System.Drawing.Size(677, 221);
            this.pnlDoc.TabIndex = 5;
            // 
            // top_tool_bar
            // 
            this.top_tool_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_tool_bar.Location = new System.Drawing.Point(3, 3);
            this.top_tool_bar.Name = "top_tool_bar";
            this.top_tool_bar.Size = new System.Drawing.Size(677, 40);
            this.top_tool_bar.TabIndex = 4;
            // 
            // pnlChange
            // 
            this.pnlChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChange.Location = new System.Drawing.Point(3, 43);
            this.pnlChange.Name = "pnlChange";
            this.pnlChange.Size = new System.Drawing.Size(677, 221);
            this.pnlChange.TabIndex = 7;
            // 
            // top_tool_bar1
            // 
            this.top_tool_bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_tool_bar1.Location = new System.Drawing.Point(3, 3);
            this.top_tool_bar1.Name = "top_tool_bar1";
            this.top_tool_bar1.Size = new System.Drawing.Size(677, 40);
            this.top_tool_bar1.TabIndex = 6;
            // 
            // DocChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 293);
            this.Controls.Add(this.tabControl1);
            this.Name = "DocChange";
            this.Text = "DocChange";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlDoc;
        private QX.Common.BseControl.CommonToolBar top_tool_bar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlChange;
        private QX.Common.BseControl.CommonToolBar top_tool_bar1;

    }
}