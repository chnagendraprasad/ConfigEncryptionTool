using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ConfigEncryptionTool
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtConfigFilePath = new System.Windows.Forms.TextBox();
            this.lstConnectionStrings = new System.Windows.Forms.ListBox();
            this.lstAppSettings = new System.Windows.Forms.ListBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnThemeToggle = new System.Windows.Forms.Button();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblConnectionStrings = new System.Windows.Forms.Label();
            this.lblAppSettings = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(424, 72);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtConfigFilePath
            // 
            this.txtConfigFilePath.Location = new System.Drawing.Point(12, 73);
            this.txtConfigFilePath.Name = "txtConfigFilePath";
            this.txtConfigFilePath.Size = new System.Drawing.Size(406, 20);
            this.txtConfigFilePath.TabIndex = 1;
            // 
            // lstConnectionStrings
            // 
            this.lstConnectionStrings.FormattingEnabled = true;
            this.lstConnectionStrings.Location = new System.Drawing.Point(12, 139);
            this.lstConnectionStrings.Name = "lstConnectionStrings";
            this.lstConnectionStrings.Size = new System.Drawing.Size(226, 160);
            this.lstConnectionStrings.TabIndex = 2;
            this.lstConnectionStrings.SelectedIndexChanged += new System.EventHandler(this.lstConnectionStrings_SelectedIndexChanged);
            // 
            // lstAppSettings
            // 
            this.lstAppSettings.FormattingEnabled = true;
            this.lstAppSettings.Location = new System.Drawing.Point(274, 139);
            this.lstAppSettings.Name = "lstAppSettings";
            this.lstAppSettings.Size = new System.Drawing.Size(226, 160);
            this.lstAppSettings.TabIndex = 3;
            this.lstAppSettings.SelectedIndexChanged += new System.EventHandler(this.lstAppSettings_SelectedIndexChanged);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(12, 325);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(488, 71);
            this.txtValue.TabIndex = 4;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(12, 415);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 5;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(425, 415);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 6;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnThemeToggle
            // 
            this.btnThemeToggle.Location = new System.Drawing.Point(210, 415);
            this.btnThemeToggle.Name = "btnThemeToggle";
            this.btnThemeToggle.Size = new System.Drawing.Size(75, 23);
            this.btnThemeToggle.TabIndex = 7;
            this.btnThemeToggle.Text = "Toggle Theme";
            this.btnThemeToggle.UseVisualStyleBackColor = true;
            this.btnThemeToggle.Click += new System.EventHandler(this.btnThemeToggle_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCompanyName.Location = new System.Drawing.Point(85, 37);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(147, 17);
            this.lblCompanyName.TabIndex = 8;
            this.lblCompanyName.Text = "HDBFS Gold Loans";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(13, 7);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(70, 60);
            //   Load the JPEG image from the project root directory
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CompanyLogo.jpeg");
            pictureBoxLogo.Image = Image.FromFile(imagePath);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 9;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblFooter.Location = new System.Drawing.Point(85, 472);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(217, 13);
            this.lblFooter.TabIndex = 10;
            this.lblFooter.Text = "All rights reserved. © Jayam Solutions - 2024";
            // 
            // lblConnectionStrings
            // 
            this.lblConnectionStrings.AutoSize = true;
            this.lblConnectionStrings.Location = new System.Drawing.Point(12, 120);
            this.lblConnectionStrings.Name = "lblConnectionStrings";
            this.lblConnectionStrings.Size = new System.Drawing.Size(99, 13);
            this.lblConnectionStrings.TabIndex = 11;
            this.lblConnectionStrings.Text = "Connection Strings:";
            // 
            // lblAppSettings
            // 
            this.lblAppSettings.AutoSize = true;
            this.lblAppSettings.Location = new System.Drawing.Point(274, 120);
            this.lblAppSettings.Name = "lblAppSettings";
            this.lblAppSettings.Size = new System.Drawing.Size(70, 13);
            this.lblAppSettings.TabIndex = 12;
            this.lblAppSettings.Text = "App Settings:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(10, 309);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 13);
            this.lblValue.TabIndex = 13;
            this.lblValue.Text = "Value:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(514, 497);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblAppSettings);
            this.Controls.Add(this.lblConnectionStrings);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.btnThemeToggle);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lstAppSettings);
            this.Controls.Add(this.lstConnectionStrings);
            this.Controls.Add(this.txtConfigFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Name = "Form1";
            this.Text = "Config Encryption Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtConfigFilePath;
        private System.Windows.Forms.ListBox lstConnectionStrings;
        private System.Windows.Forms.ListBox lstAppSettings;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnThemeToggle;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblConnectionStrings;
        private System.Windows.Forms.Label lblAppSettings;
        private System.Windows.Forms.Label lblValue;
    }
}