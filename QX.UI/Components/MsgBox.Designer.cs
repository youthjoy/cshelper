namespace QX.UI.Comm
{
    partial class MsgBox
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
            this.uteSystemInformation = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.uteSystemInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // uteSystemInformation
            // 
            this.uteSystemInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uteSystemInformation.Location = new System.Drawing.Point(0, 0);
            this.uteSystemInformation.Multiline = true;
            this.uteSystemInformation.Name = "uteSystemInformation";
            this.uteSystemInformation.Size = new System.Drawing.Size(271, 106);
            this.uteSystemInformation.TabIndex = 1;
            // 
            // MsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 106);
            this.Controls.Add(this.uteSystemInformation);
            this.Name = "MsgBox";
            this.Text = "提示信息";
            ((System.ComponentModel.ISupportInitialize)(this.uteSystemInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteSystemInformation;

    }
}