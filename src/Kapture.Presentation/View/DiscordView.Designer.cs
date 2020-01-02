using ACT_FFXIV_Kapture.Presentation.CustomControl;

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
            this.label5 = new System.Windows.Forms.Label();
            this.discord_EndpointTextBox = new CustomTextBox();
            this.discord_UpdateButton = new CustomButton();
            this.SuspendLayout();
            // 
            // discord_DiscordEnabledCheckBox
            // 
            this.discord_DiscordEnabledCheckBox.AutoSize = true;
            this.discord_DiscordEnabledCheckBox.Location = new System.Drawing.Point(3, 3);
            this.discord_DiscordEnabledCheckBox.Name = "discord_DiscordEnabledCheckBox";
            this.discord_DiscordEnabledCheckBox.Size = new System.Drawing.Size(104, 17);
            this.discord_DiscordEnabledCheckBox.TabIndex = 23;
            this.discord_DiscordEnabledCheckBox.Text = "Discord Enabled";
            this.discord_DiscordEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Webhook URL";
            // 
            // discord_EndpointTextBox
            // 
            this.discord_EndpointTextBox.Location = new System.Drawing.Point(96, 26);
            this.discord_EndpointTextBox.Name = "discord_EndpointTextBox";
            this.discord_EndpointTextBox.Size = new System.Drawing.Size(211, 20);
            this.discord_EndpointTextBox.TabIndex = 28;
            // 
            // discord_UpdateButton
            // 
            this.discord_UpdateButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.discord_UpdateButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.discord_UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discord_UpdateButton.Location = new System.Drawing.Point(210, 52);
            this.discord_UpdateButton.Name = "discord_UpdateButton";
            this.discord_UpdateButton.Size = new System.Drawing.Size(97, 23);
            this.discord_UpdateButton.TabIndex = 37;
            this.discord_UpdateButton.Text = "Update";
            this.discord_UpdateButton.UseVisualStyleBackColor = false;
            // 
            // DiscordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.discord_UpdateButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.discord_EndpointTextBox);
            this.Controls.Add(this.discord_DiscordEnabledCheckBox);
            this.Name = "DiscordView";
            this.Size = new System.Drawing.Size(465, 303);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox discord_DiscordEnabledCheckBox;
        private CustomTextBox discord_EndpointTextBox;
        private System.Windows.Forms.Label label5;
        private CustomButton discord_UpdateButton;
    }
}
