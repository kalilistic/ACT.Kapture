using ACT_FFXIV_Kapture.Presentation.CustomControl;

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
            this.about_UpdateButton = new CustomButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.about_VersionLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.about_AuthorLabel = new System.Windows.Forms.LinkLabel();
            this.about_SourceLabel = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.about_SupportLabel = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.about_ViewLogsButton = new CustomButton();
            this.about_LicenseLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // about_UpdateButton
            // 
            this.about_UpdateButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.about_UpdateButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.about_UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.about_UpdateButton.Location = new System.Drawing.Point(181, 70);
            this.about_UpdateButton.Name = "about_UpdateButton";
            this.about_UpdateButton.Size = new System.Drawing.Size(129, 23);
            this.about_UpdateButton.TabIndex = 36;
            this.about_UpdateButton.Text = "Check for Updates";
            this.about_UpdateButton.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 29);
            this.label3.TabIndex = 37;
            this.label3.Text = "Kapture Loot Tracker";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Version";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(0, 55);
            this.label6.MinimumSize = new System.Drawing.Size(2, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(310, 2);
            this.label6.TabIndex = 40;
            // 
            // about_VersionLabel
            // 
            this.about_VersionLabel.AutoSize = true;
            this.about_VersionLabel.Location = new System.Drawing.Point(73, 70);
            this.about_VersionLabel.Name = "about_VersionLabel";
            this.about_VersionLabel.Size = new System.Drawing.Size(55, 13);
            this.about_VersionLabel.TabIndex = 41;
            this.about_VersionLabel.Text = "VERSION";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Author";
            // 
            // about_AuthorLabel
            // 
            this.about_AuthorLabel.AutoSize = true;
            this.about_AuthorLabel.Location = new System.Drawing.Point(73, 98);
            this.about_AuthorLabel.Name = "about_AuthorLabel";
            this.about_AuthorLabel.Size = new System.Drawing.Size(44, 13);
            this.about_AuthorLabel.TabIndex = 44;
            this.about_AuthorLabel.TabStop = true;
            this.about_AuthorLabel.Text = "Kalilistic";
            // 
            // about_SourceLabel
            // 
            this.about_SourceLabel.AutoSize = true;
            this.about_SourceLabel.Location = new System.Drawing.Point(73, 154);
            this.about_SourceLabel.Name = "about_SourceLabel";
            this.about_SourceLabel.Size = new System.Drawing.Size(38, 13);
            this.about_SourceLabel.TabIndex = 48;
            this.about_SourceLabel.TabStop = true;
            this.about_SourceLabel.Text = "Github";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Source";
            // 
            // about_SupportLabel
            // 
            this.about_SupportLabel.AutoSize = true;
            this.about_SupportLabel.Location = new System.Drawing.Point(73, 126);
            this.about_SupportLabel.Name = "about_SupportLabel";
            this.about_SupportLabel.Size = new System.Drawing.Size(43, 13);
            this.about_SupportLabel.TabIndex = 50;
            this.about_SupportLabel.TabStop = true;
            this.about_SupportLabel.Text = "Discord";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Support";
            // 
            // about_ViewLogsButton
            // 
            this.about_ViewLogsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.about_ViewLogsButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.about_ViewLogsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.about_ViewLogsButton.Location = new System.Drawing.Point(181, 99);
            this.about_ViewLogsButton.Name = "about_ViewLogsButton";
            this.about_ViewLogsButton.Size = new System.Drawing.Size(129, 23);
            this.about_ViewLogsButton.TabIndex = 51;
            this.about_ViewLogsButton.Text = "View Plugin Log";
            this.about_ViewLogsButton.UseVisualStyleBackColor = false;
            // 
            // about_LicenseLabel
            // 
            this.about_LicenseLabel.AutoSize = true;
            this.about_LicenseLabel.Location = new System.Drawing.Point(73, 182);
            this.about_LicenseLabel.Name = "about_LicenseLabel";
            this.about_LicenseLabel.Size = new System.Drawing.Size(26, 13);
            this.about_LicenseLabel.TabIndex = 53;
            this.about_LicenseLabel.TabStop = true;
            this.about_LicenseLabel.Text = "MIT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "License";
            // 
            // AboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.about_LicenseLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.about_ViewLogsButton);
            this.Controls.Add(this.about_SupportLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.about_SourceLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.about_AuthorLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.about_VersionLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.about_UpdateButton);
            this.Name = "AboutView";
            this.Size = new System.Drawing.Size(465, 303);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButton about_UpdateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label about_VersionLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel about_AuthorLabel;
        private System.Windows.Forms.LinkLabel about_SourceLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel about_SupportLabel;
        private System.Windows.Forms.Label label8;
        private CustomButton about_ViewLogsButton;
        private System.Windows.Forms.LinkLabel about_LicenseLabel;
        private System.Windows.Forms.Label label1;
    }
}
