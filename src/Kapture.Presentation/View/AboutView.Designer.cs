using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
    partial class AboutView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutView));
			this.about_VersionKeyLabel = new System.Windows.Forms.Label();
			this.about_VersionValueLabel = new System.Windows.Forms.Label();
			this.about_AuthorKeyLabel = new System.Windows.Forms.Label();
			this.about_SourceKeyLabel = new System.Windows.Forms.Label();
			this.about_SupportKeyLabel = new System.Windows.Forms.Label();
			this.about_LicenseKeyLabel = new System.Windows.Forms.Label();
			this.about_UpdateButton = new System.Windows.Forms.Button();
			this.about_ViewLogsButton = new System.Windows.Forms.Button();
			this.about_LicenseValueLabel = new ACT_FFXIV_Kapture.Presentation.CustomLabel();
			this.about_SourceValueLabel = new ACT_FFXIV_Kapture.Presentation.CustomLabel();
			this.about_SupportValueLabel = new ACT_FFXIV_Kapture.Presentation.CustomLabel();
			this.about_AuthorValueLabel = new ACT_FFXIV_Kapture.Presentation.CustomLabel();
			this.about_TitleLabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// about_VersionKeyLabel
			// 
			this.about_VersionKeyLabel.AutoSize = true;
			this.about_VersionKeyLabel.Location = new System.Drawing.Point(1, 70);
			this.about_VersionKeyLabel.Name = "about_VersionKeyLabel";
			this.about_VersionKeyLabel.Size = new System.Drawing.Size(42, 13);
			this.about_VersionKeyLabel.TabIndex = 39;
			this.about_VersionKeyLabel.Text = "Version";
			// 
			// about_VersionValueLabel
			// 
			this.about_VersionValueLabel.AutoSize = true;
			this.about_VersionValueLabel.Location = new System.Drawing.Point(73, 70);
			this.about_VersionValueLabel.Name = "about_VersionValueLabel";
			this.about_VersionValueLabel.Size = new System.Drawing.Size(55, 13);
			this.about_VersionValueLabel.TabIndex = 41;
			this.about_VersionValueLabel.Text = "VERSION";
			// 
			// about_AuthorKeyLabel
			// 
			this.about_AuthorKeyLabel.AutoSize = true;
			this.about_AuthorKeyLabel.Location = new System.Drawing.Point(1, 98);
			this.about_AuthorKeyLabel.Name = "about_AuthorKeyLabel";
			this.about_AuthorKeyLabel.Size = new System.Drawing.Size(38, 13);
			this.about_AuthorKeyLabel.TabIndex = 42;
			this.about_AuthorKeyLabel.Text = "Author";
			// 
			// about_SourceKeyLabel
			// 
			this.about_SourceKeyLabel.AutoSize = true;
			this.about_SourceKeyLabel.Location = new System.Drawing.Point(1, 154);
			this.about_SourceKeyLabel.Name = "about_SourceKeyLabel";
			this.about_SourceKeyLabel.Size = new System.Drawing.Size(41, 13);
			this.about_SourceKeyLabel.TabIndex = 47;
			this.about_SourceKeyLabel.Text = "Source";
			// 
			// about_SupportKeyLabel
			// 
			this.about_SupportKeyLabel.AutoSize = true;
			this.about_SupportKeyLabel.Location = new System.Drawing.Point(1, 126);
			this.about_SupportKeyLabel.Name = "about_SupportKeyLabel";
			this.about_SupportKeyLabel.Size = new System.Drawing.Size(44, 13);
			this.about_SupportKeyLabel.TabIndex = 49;
			this.about_SupportKeyLabel.Text = "Support";
			// 
			// about_LicenseKeyLabel
			// 
			this.about_LicenseKeyLabel.AutoSize = true;
			this.about_LicenseKeyLabel.Location = new System.Drawing.Point(0, 182);
			this.about_LicenseKeyLabel.Name = "about_LicenseKeyLabel";
			this.about_LicenseKeyLabel.Size = new System.Drawing.Size(44, 13);
			this.about_LicenseKeyLabel.TabIndex = 52;
			this.about_LicenseKeyLabel.Text = "License";
			// 
			// about_UpdateButton
			// 
			this.about_UpdateButton.Location = new System.Drawing.Point(192, 70);
			this.about_UpdateButton.Name = "about_UpdateButton";
			this.about_UpdateButton.Size = new System.Drawing.Size(118, 23);
			this.about_UpdateButton.TabIndex = 58;
			this.about_UpdateButton.Text = "Check for Updates";
			this.about_UpdateButton.UseVisualStyleBackColor = true;
			// 
			// about_ViewLogsButton
			// 
			this.about_ViewLogsButton.Location = new System.Drawing.Point(192, 99);
			this.about_ViewLogsButton.Name = "about_ViewLogsButton";
			this.about_ViewLogsButton.Size = new System.Drawing.Size(118, 23);
			this.about_ViewLogsButton.TabIndex = 59;
			this.about_ViewLogsButton.Text = "View Plugin Log";
			this.about_ViewLogsButton.UseVisualStyleBackColor = true;
			// 
			// about_LicenseValueLabel
			// 
			this.about_LicenseValueLabel.AutoSize = true;
			this.about_LicenseValueLabel.ForeColor = System.Drawing.Color.Blue;
			this.about_LicenseValueLabel.Location = new System.Drawing.Point(73, 182);
			this.about_LicenseValueLabel.Name = "about_LicenseValueLabel";
			this.about_LicenseValueLabel.Size = new System.Drawing.Size(26, 13);
			this.about_LicenseValueLabel.TabIndex = 57;
			this.about_LicenseValueLabel.Text = "MIT";
			// 
			// about_SourceValueLabel
			// 
			this.about_SourceValueLabel.AutoSize = true;
			this.about_SourceValueLabel.ForeColor = System.Drawing.Color.Blue;
			this.about_SourceValueLabel.Location = new System.Drawing.Point(73, 154);
			this.about_SourceValueLabel.Name = "about_SourceValueLabel";
			this.about_SourceValueLabel.Size = new System.Drawing.Size(38, 13);
			this.about_SourceValueLabel.TabIndex = 56;
			this.about_SourceValueLabel.Text = "Github";
			// 
			// about_SupportValueLabel
			// 
			this.about_SupportValueLabel.AutoSize = true;
			this.about_SupportValueLabel.ForeColor = System.Drawing.Color.Blue;
			this.about_SupportValueLabel.Location = new System.Drawing.Point(73, 126);
			this.about_SupportValueLabel.Name = "about_SupportValueLabel";
			this.about_SupportValueLabel.Size = new System.Drawing.Size(43, 13);
			this.about_SupportValueLabel.TabIndex = 55;
			this.about_SupportValueLabel.Text = "Discord";
			// 
			// about_AuthorValueLabel
			// 
			this.about_AuthorValueLabel.AutoSize = true;
			this.about_AuthorValueLabel.ForeColor = System.Drawing.Color.Blue;
			this.about_AuthorValueLabel.Location = new System.Drawing.Point(73, 98);
			this.about_AuthorValueLabel.Name = "about_AuthorValueLabel";
			this.about_AuthorValueLabel.Size = new System.Drawing.Size(44, 13);
			this.about_AuthorValueLabel.TabIndex = 54;
			this.about_AuthorValueLabel.Text = "Kalilistic";
			// 
			// about_TitleLabel
			// 
			this.about_TitleLabel.AutoSize = true;
			this.about_TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.about_TitleLabel.Location = new System.Drawing.Point(71, 16);
			this.about_TitleLabel.Name = "about_TitleLabel";
			this.about_TitleLabel.Size = new System.Drawing.Size(239, 29);
			this.about_TitleLabel.TabIndex = 37;
			this.about_TitleLabel.Text = "Kapture Loot Tracker";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(62, 47);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 38;
			this.pictureBox1.TabStop = false;
			// 
			// AboutView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.about_ViewLogsButton);
			this.Controls.Add(this.about_UpdateButton);
			this.Controls.Add(this.about_LicenseValueLabel);
			this.Controls.Add(this.about_SourceValueLabel);
			this.Controls.Add(this.about_SupportValueLabel);
			this.Controls.Add(this.about_AuthorValueLabel);
			this.Controls.Add(this.about_LicenseKeyLabel);
			this.Controls.Add(this.about_SupportKeyLabel);
			this.Controls.Add(this.about_SourceKeyLabel);
			this.Controls.Add(this.about_AuthorKeyLabel);
			this.Controls.Add(this.about_VersionValueLabel);
			this.Controls.Add(this.about_VersionKeyLabel);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.about_TitleLabel);
			this.Name = "AboutView";
			this.Size = new System.Drawing.Size(500, 400);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label about_VersionKeyLabel;
        private System.Windows.Forms.Label about_VersionValueLabel;
        private System.Windows.Forms.Label about_AuthorKeyLabel;
        private System.Windows.Forms.Label about_SourceKeyLabel;
        private System.Windows.Forms.Label about_SupportKeyLabel;
        private System.Windows.Forms.Label about_LicenseKeyLabel;
		private CustomLabel about_AuthorValueLabel;
		private CustomLabel about_SupportValueLabel;
		private CustomLabel about_SourceValueLabel;
		private CustomLabel about_LicenseValueLabel;
		private System.Windows.Forms.Button about_UpdateButton;
		private System.Windows.Forms.Button about_ViewLogsButton;
		private System.Windows.Forms.Label about_TitleLabel;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
