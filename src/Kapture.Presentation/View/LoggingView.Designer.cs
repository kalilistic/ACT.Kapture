using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
    partial class LoggingView
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
			this.logging_LoggingEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.logging_LogFormatLabel = new System.Windows.Forms.Label();
			this.logging_LogLocationLabel = new System.Windows.Forms.Label();
			this.logging_LogLocationTextBox = new ACT_FFXIV_Kapture.Presentation.CustomTextBox();
			this.logging_LogFormatComboBox = new ACT_FFXIV_Kapture.Presentation.CustomComboBox();
			this.logging_BrowseButton = new System.Windows.Forms.Button();
			this.logging_UpdateButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// logging_LoggingEnabledCheckBox
			// 
			this.logging_LoggingEnabledCheckBox.AutoSize = true;
			this.logging_LoggingEnabledCheckBox.Location = new System.Drawing.Point(3, 3);
			this.logging_LoggingEnabledCheckBox.Name = "logging_LoggingEnabledCheckBox";
			this.logging_LoggingEnabledCheckBox.Size = new System.Drawing.Size(105, 17);
			this.logging_LoggingEnabledCheckBox.TabIndex = 23;
			this.logging_LoggingEnabledCheckBox.Text = "Logging enabled";
			this.logging_LoggingEnabledCheckBox.UseVisualStyleBackColor = true;
			// 
			// logging_LogFormatLabel
			// 
			this.logging_LogFormatLabel.AutoSize = true;
			this.logging_LogFormatLabel.Location = new System.Drawing.Point(1, 32);
			this.logging_LogFormatLabel.Name = "logging_LogFormatLabel";
			this.logging_LogFormatLabel.Size = new System.Drawing.Size(60, 13);
			this.logging_LogFormatLabel.TabIndex = 26;
			this.logging_LogFormatLabel.Text = "Log Format";
			// 
			// logging_LogLocationLabel
			// 
			this.logging_LogLocationLabel.AutoSize = true;
			this.logging_LogLocationLabel.Location = new System.Drawing.Point(3, 81);
			this.logging_LogLocationLabel.Name = "logging_LogLocationLabel";
			this.logging_LogLocationLabel.Size = new System.Drawing.Size(69, 13);
			this.logging_LogLocationLabel.TabIndex = 29;
			this.logging_LogLocationLabel.Text = "Log Location";
			// 
			// logging_LogLocationTextBox
			// 
			this.logging_LogLocationTextBox.Location = new System.Drawing.Point(3, 98);
			this.logging_LogLocationTextBox.Name = "logging_LogLocationTextBox";
			this.logging_LogLocationTextBox.Size = new System.Drawing.Size(322, 20);
			this.logging_LogLocationTextBox.TabIndex = 28;
			// 
			// logging_LogFormatComboBox
			// 
			this.logging_LogFormatComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.logging_LogFormatComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.logging_LogFormatComboBox.FormattingEnabled = true;
			this.logging_LogFormatComboBox.Location = new System.Drawing.Point(4, 48);
			this.logging_LogFormatComboBox.Name = "logging_LogFormatComboBox";
			this.logging_LogFormatComboBox.Size = new System.Drawing.Size(126, 21);
			this.logging_LogFormatComboBox.TabIndex = 27;
			// 
			// logging_BrowseButton
			// 
			this.logging_BrowseButton.Location = new System.Drawing.Point(169, 129);
			this.logging_BrowseButton.Name = "logging_BrowseButton";
			this.logging_BrowseButton.Size = new System.Drawing.Size(75, 23);
			this.logging_BrowseButton.TabIndex = 32;
			this.logging_BrowseButton.Text = "Browse";
			this.logging_BrowseButton.UseVisualStyleBackColor = true;
			// 
			// logging_UpdateButton
			// 
			this.logging_UpdateButton.Location = new System.Drawing.Point(250, 129);
			this.logging_UpdateButton.Name = "logging_UpdateButton";
			this.logging_UpdateButton.Size = new System.Drawing.Size(75, 23);
			this.logging_UpdateButton.TabIndex = 33;
			this.logging_UpdateButton.Text = "Update";
			this.logging_UpdateButton.UseVisualStyleBackColor = true;
			// 
			// LoggingView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.logging_UpdateButton);
			this.Controls.Add(this.logging_BrowseButton);
			this.Controls.Add(this.logging_LogLocationLabel);
			this.Controls.Add(this.logging_LogLocationTextBox);
			this.Controls.Add(this.logging_LogFormatComboBox);
			this.Controls.Add(this.logging_LogFormatLabel);
			this.Controls.Add(this.logging_LoggingEnabledCheckBox);
			this.Name = "LoggingView";
			this.Size = new System.Drawing.Size(500, 400);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox logging_LoggingEnabledCheckBox;
        private CustomComboBox logging_LogFormatComboBox;
        private System.Windows.Forms.Label logging_LogFormatLabel;
        private CustomTextBox logging_LogLocationTextBox;
        private System.Windows.Forms.Label logging_LogLocationLabel;
		private System.Windows.Forms.Button logging_BrowseButton;
		private System.Windows.Forms.Button logging_UpdateButton;
	}
}
