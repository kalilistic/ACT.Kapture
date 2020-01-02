using ACT_FFXIV_Kapture.Presentation.CustomControl;

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
            this.label5 = new System.Windows.Forms.Label();
            this.http_EndpointTextBox = new CustomTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.http_CustomJsonTextBox = new CustomTextBox();
            this.http_UpdateButton = new CustomButton();
            this.SuspendLayout();
            // 
            // http_HTTPEnabledCheckBox
            // 
            this.http_HTTPEnabledCheckBox.AutoSize = true;
            this.http_HTTPEnabledCheckBox.Location = new System.Drawing.Point(3, 3);
            this.http_HTTPEnabledCheckBox.Name = "http_HTTPEnabledCheckBox";
            this.http_HTTPEnabledCheckBox.Size = new System.Drawing.Size(97, 17);
            this.http_HTTPEnabledCheckBox.TabIndex = 23;
            this.http_HTTPEnabledCheckBox.Text = "HTTP Enabled";
            this.http_HTTPEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Endpoint";
            // 
            // http_EndpointTextBox
            // 
            this.http_EndpointTextBox.Location = new System.Drawing.Point(96, 26);
            this.http_EndpointTextBox.Name = "http_EndpointTextBox";
            this.http_EndpointTextBox.Size = new System.Drawing.Size(211, 20);
            this.http_EndpointTextBox.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Custom JSON";
            // 
            // http_CustomJsonTextBox
            // 
            this.http_CustomJsonTextBox.Location = new System.Drawing.Point(96, 52);
            this.http_CustomJsonTextBox.Multiline = true;
            this.http_CustomJsonTextBox.Name = "http_CustomJsonTextBox";
            this.http_CustomJsonTextBox.Size = new System.Drawing.Size(211, 121);
            this.http_CustomJsonTextBox.TabIndex = 35;
            // 
            // http_UpdateButton
            // 
            this.http_UpdateButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.http_UpdateButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.http_UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.http_UpdateButton.Location = new System.Drawing.Point(210, 179);
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.http_EndpointTextBox);
            this.Controls.Add(this.http_HTTPEnabledCheckBox);
            this.Name = "HTTPView";
            this.Size = new System.Drawing.Size(333, 222);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox http_HTTPEnabledCheckBox;
        private CustomTextBox http_EndpointTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private CustomTextBox http_CustomJsonTextBox;
        private CustomButton http_UpdateButton;
    }
}
