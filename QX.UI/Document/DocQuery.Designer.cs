namespace QX.UI.Document
{
    partial class DocQuery
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
            this.pnlDoc = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // top_tool_bar
            // 
            this.top_tool_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_tool_bar.Location = new System.Drawing.Point(0, 0);
            this.top_tool_bar.Name = "top_tool_bar";
            this.top_tool_bar.Size = new System.Drawing.Size(691, 40);
            this.top_tool_bar.TabIndex = 0;
            // 
            // pnlDoc
            // 
            this.pnlDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDoc.Location = new System.Drawing.Point(0, 40);
            this.pnlDoc.Name = "pnlDoc";
            this.pnlDoc.Size = new System.Drawing.Size(691, 253);
            this.pnlDoc.TabIndex = 1;
            // 
            // DocQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 293);
            this.Controls.Add(this.pnlDoc);
            this.Controls.Add(this.top_tool_bar);
            this.Name = "DocQuery";
            this.Text = "DocQuery";
            this.ResumeLayout(false);

        }

        #endregion

        private QX.Common.BseControl.CommonToolBar top_tool_bar;
        private System.Windows.Forms.Panel pnlDoc;

    }
}