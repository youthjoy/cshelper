namespace QX.GenFramework.AutoForm
{
    partial class SystemInformationHelp
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
            this.uteSystemInformation.Size = new System.Drawing.Size(471, 432);
            this.uteSystemInformation.TabIndex = 0;
            // 
            // SystemInformationHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 432);
            this.Controls.Add(this.uteSystemInformation);
            this.Name = "SystemInformationHelp";
            this.Text = "SystemInformationHelp";
            this.Load += new System.EventHandler(this.SystemInformationHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uteSystemInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteSystemInformation;

    }
}