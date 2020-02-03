using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
    partial class GeneralView
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
			this.general_PluginEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.general_LogImportsEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.general_CheckForBetaVersionsCheckBox = new System.Windows.Forms.CheckBox();
			this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.SuspendLayout();
			// 
			// general_PluginEnabledCheckBox
			// 
			this.general_PluginEnabledCheckBox.AutoSize = true;
			this.general_PluginEnabledCheckBox.Location = new System.Drawing.Point(3, 3);
			this.general_PluginEnabledCheckBox.Name = "general_PluginEnabledCheckBox";
			this.general_PluginEnabledCheckBox.Size = new System.Drawing.Size(96, 17);
			this.general_PluginEnabledCheckBox.TabIndex = 0;
			this.general_PluginEnabledCheckBox.Text = "Plugin enabled";
			this.general_PluginEnabledCheckBox.UseVisualStyleBackColor = true;
			this.general_PluginEnabledCheckBox.CheckedChanged += new System.EventHandler(this.PluginEnabledCheckBox_Changed);
			// 
			// general_LogImportsEnabledCheckBox
			// 
			this.general_LogImportsEnabledCheckBox.AutoSize = true;
			this.general_LogImportsEnabledCheckBox.Location = new System.Drawing.Point(3, 26);
			this.general_LogImportsEnabledCheckBox.Name = "general_LogImportsEnabledCheckBox";
			this.general_LogImportsEnabledCheckBox.Size = new System.Drawing.Size(121, 17);
			this.general_LogImportsEnabledCheckBox.TabIndex = 1;
			this.general_LogImportsEnabledCheckBox.Text = "Log imports enabled";
			this.general_LogImportsEnabledCheckBox.UseVisualStyleBackColor = true;
			this.general_LogImportsEnabledCheckBox.CheckedChanged += new System.EventHandler(this.LogImportsEnabledCheckBox_Changed);
			// 
			// general_CheckForBetaVersionsCheckBox
			// 
			this.general_CheckForBetaVersionsCheckBox.AutoSize = true;
			this.general_CheckForBetaVersionsCheckBox.Location = new System.Drawing.Point(3, 49);
			this.general_CheckForBetaVersionsCheckBox.Name = "general_CheckForBetaVersionsCheckBox";
			this.general_CheckForBetaVersionsCheckBox.Size = new System.Drawing.Size(138, 17);
			this.general_CheckForBetaVersionsCheckBox.TabIndex = 2;
			this.general_CheckForBetaVersionsCheckBox.Text = "Check for beta versions";
			this.general_CheckForBetaVersionsCheckBox.UseVisualStyleBackColor = true;
			this.general_CheckForBetaVersionsCheckBox.CheckedChanged += new System.EventHandler(this.CheckForBetaCheckBox_Changed);
			// 
			// dataGridViewButtonColumn1
			// 
			this.dataGridViewButtonColumn1.HeaderText = "Delete";
			this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
			this.dataGridViewButtonColumn1.Text = "Y";
			this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
			// 
			// GeneralView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.general_CheckForBetaVersionsCheckBox);
			this.Controls.Add(this.general_LogImportsEnabledCheckBox);
			this.Controls.Add(this.general_PluginEnabledCheckBox);
			this.Name = "GeneralView";
			this.Size = new System.Drawing.Size(500, 400);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox general_PluginEnabledCheckBox;
        private System.Windows.Forms.CheckBox general_LogImportsEnabledCheckBox;
        private System.Windows.Forms.CheckBox general_CheckForBetaVersionsCheckBox;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
	}
}
