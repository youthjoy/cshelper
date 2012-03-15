namespace QX.UI.Comm
{
    partial class AutoClosedMessageBox
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.tmrAutoClosed = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblShowTip = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tmrAutoClosed
            // 
            this.tmrAutoClosed.Enabled = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblShowTip);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 55);
            this.panel1.TabIndex = 1;
            // 
            // lblShowTip
            // 
            this.lblShowTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowTip.Location = new System.Drawing.Point(0, 0);
            this.lblShowTip.Name = "lblShowTip";
            this.lblShowTip.Size = new System.Drawing.Size(306, 55);
            this.lblShowTip.TabIndex = 2;
            this.lblShowTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoClosedMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 108);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "AutoClosedMessageBox";
            this.Text = "信息提示框";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmrAutoClosed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblShowTip;
    }
}