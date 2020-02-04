using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
    partial class DiscordView
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
			this.discord_DiscordEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.discord_WebhookLabel = new System.Windows.Forms.Label();
			this.discord_EndpointTextBox = new ACT_FFXIV_Kapture.Presentation.CustomTextBox();
			this.discord_UpdateButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// discord_DiscordEnabledCheckBox
			// 
			this.discord_DiscordEnabledCheckBox.AutoSize = true;
			this.discord_DiscordEnabledCheckBox.Location = new System.Drawing.Point(3, 3);
			this.discord_DiscordEnabledCheckBox.Name = "discord_DiscordEnabledCheckBox";
			this.discord_DiscordEnabledCheckBox.Size = new System.Drawing.Size(103, 17);
			this.discord_DiscordEnabledCheckBox.TabIndex = 23;
			this.discord_DiscordEnabledCheckBox.Text = "Discord enabled";
			this.discord_DiscordEnabledCheckBox.UseVisualStyleBackColor = true;
			// 
			// discord_WebhookLabel
			// 
			this.discord_WebhookLabel.AutoSize = true;
			this.discord_WebhookLabel.Location = new System.Drawing.Point(1, 32);
			this.discord_WebhookLabel.Name = "discord_WebhookLabel";
			this.discord_WebhookLabel.Size = new System.Drawing.Size(79, 13);
			this.discord_WebhookLabel.TabIndex = 29;
			this.discord_WebhookLabel.Text = "Webhook URL";
			// 
			// discord_EndpointTextBox
			// 
			this.discord_EndpointTextBox.Location = new System.Drawing.Point(3, 49);
			this.discord_EndpointTextBox.Name = "discord_EndpointTextBox";
			this.discord_EndpointTextBox.Size = new System.Drawing.Size(322, 20);
			this.discord_EndpointTextBox.TabIndex = 28;
			// 
			// discord_UpdateButton
			// 
			this.discord_UpdateButton.Location = new System.Drawing.Point(250, 80);
			this.discord_UpdateButton.Name = "discord_UpdateButton";
			this.discord_UpdateButton.Size = new System.Drawing.Size(75, 23);
			this.discord_UpdateButton.TabIndex = 39;
			this.discord_UpdateButton.Text = "Update";
			this.discord_UpdateButton.UseVisualStyleBackColor = true;
			// 
			// DiscordView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.discord_UpdateButton);
			this.Controls.Add(this.discord_WebhookLabel);
			this.Controls.Add(this.discord_EndpointTextBox);
			this.Controls.Add(this.discord_DiscordEnabledCheckBox);
			this.Name = "DiscordView";
			this.Size = new System.Drawing.Size(500, 400);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox discord_DiscordEnabledCheckBox;
        private CustomTextBox discord_EndpointTextBox;
        private System.Windows.Forms.Label discord_WebhookLabel;
		private System.Windows.Forms.Button discord_UpdateButton;
	}
}
