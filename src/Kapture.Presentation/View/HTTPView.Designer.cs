using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
    partial class HTTPView
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
			this.http_HTTPEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.http_EndPointLabel = new System.Windows.Forms.Label();
			this.http_EndpointTextBox = new CustomTextBox();
			this.http_CustomJSONLabel = new System.Windows.Forms.Label();
			this.http_CustomJsonTextBox = new CustomTextBox();
			this.http_UpdateButton = new CustomButton();
			this.SuspendLayout();
			// 
			// http_HTTPEnabledCheckBox
			// 
			this.http_HTTPEnabledCheckBox.AutoSize = true;
			this.http_HTTPEnabledCheckBox.Location = new System.Drawing.Point(3, 3);
			this.http_HTTPEnabledCheckBox.Name = "http_HTTPEnabledCheckBox";
			this.http_HTTPEnabledCheckBox.Size = new System.Drawing.Size(96, 17);
			this.http_HTTPEnabledCheckBox.TabIndex = 23;
			this.http_HTTPEnabledCheckBox.Text = "HTTP enabled";
			this.http_HTTPEnabledCheckBox.UseVisualStyleBackColor = true;
			// 
			// http_EndPointLabel
			// 
			this.http_EndPointLabel.AutoSize = true;
			this.http_EndPointLabel.Location = new System.Drawing.Point(1, 32);
			this.http_EndPointLabel.Name = "http_EndPointLabel";
			this.http_EndPointLabel.Size = new System.Drawing.Size(49, 13);
			this.http_EndPointLabel.TabIndex = 29;
			this.http_EndPointLabel.Text = "Endpoint";
			// 
			// http_EndpointTextBox
			// 
			this.http_EndpointTextBox.Location = new System.Drawing.Point(3, 49);
			this.http_EndpointTextBox.Name = "http_EndpointTextBox";
			this.http_EndpointTextBox.Size = new System.Drawing.Size(322, 20);
			this.http_EndpointTextBox.TabIndex = 28;
			// 
			// http_CustomJSONLabel
			// 
			this.http_CustomJSONLabel.AutoSize = true;
			this.http_CustomJSONLabel.Location = new System.Drawing.Point(3, 81);
			this.http_CustomJSONLabel.Name = "http_CustomJSONLabel";
			this.http_CustomJSONLabel.Size = new System.Drawing.Size(73, 13);
			this.http_CustomJSONLabel.TabIndex = 33;
			this.http_CustomJSONLabel.Text = "Custom JSON";
			// 
			// http_CustomJsonTextBox
			// 
			this.http_CustomJsonTextBox.Location = new System.Drawing.Point(3, 98);
			this.http_CustomJsonTextBox.Multiline = true;
			this.http_CustomJsonTextBox.Name = "http_CustomJsonTextBox";
			this.http_CustomJsonTextBox.Size = new System.Drawing.Size(322, 173);
			this.http_CustomJsonTextBox.TabIndex = 35;
			// 
			// http_UpdateButton
			// 
			this.http_UpdateButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.http_UpdateButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.http_UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.http_UpdateButton.Location = new System.Drawing.Point(229, 283);
			this.http_UpdateButton.Name = "http_UpdateButton";
			this.http_UpdateButton.Size = new System.Drawing.Size(97, 23);
			this.http_UpdateButton.TabIndex = 36;
			this.http_UpdateButton.Text = "Update";
			this.http_UpdateButton.UseVisualStyleBackColor = false;
			// 
			// HTTPView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.http_UpdateButton);
			this.Controls.Add(this.http_CustomJsonTextBox);
			this.Controls.Add(this.http_CustomJSONLabel);
			this.Controls.Add(this.http_EndPointLabel);
			this.Controls.Add(this.http_EndpointTextBox);
			this.Controls.Add(this.http_HTTPEnabledCheckBox);
			this.Name = "HTTPView";
			this.Size = new System.Drawing.Size(500, 400);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox http_HTTPEnabledCheckBox;
        private CustomTextBox http_EndpointTextBox;
        private System.Windows.Forms.Label http_EndPointLabel;
        private System.Windows.Forms.Label http_CustomJSONLabel;
        private CustomTextBox http_CustomJsonTextBox;
        private CustomButton http_UpdateButton;
    }
}
