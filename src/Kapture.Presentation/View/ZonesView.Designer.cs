using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
    partial class ZonesView
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.zones_AddZoneLabel = new System.Windows.Forms.Label();
			this.zones_ZoneIncludeExcludePanel = new System.Windows.Forms.Panel();
			this.zones_ZoneExcludeRadioButton = new System.Windows.Forms.RadioButton();
			this.zones_ZoneIncludeRadioButton = new System.Windows.Forms.RadioButton();
			this.zones_PresetLabel = new System.Windows.Forms.Label();
			this.zones_ZoneFilterCheckBox = new System.Windows.Forms.CheckBox();
			this.zones_ZonesListDataGridView = new CustomDataGridView();
			this.zones_ZoneAddComboBox = new CustomComboBox();
			this.zones_ZonePresetComboBox = new CustomComboBox();
			this.zones_ZoneIncludeExcludePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.zones_ZonesListDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// zones_AddZoneLabel
			// 
			this.zones_AddZoneLabel.AutoSize = true;
			this.zones_AddZoneLabel.Location = new System.Drawing.Point(3, 107);
			this.zones_AddZoneLabel.Name = "zones_AddZoneLabel";
			this.zones_AddZoneLabel.Size = new System.Drawing.Size(54, 13);
			this.zones_AddZoneLabel.TabIndex = 26;
			this.zones_AddZoneLabel.Text = "Add Zone";
			// 
			// zones_ZoneIncludeExcludePanel
			// 
			this.zones_ZoneIncludeExcludePanel.Controls.Add(this.zones_ZoneExcludeRadioButton);
			this.zones_ZoneIncludeExcludePanel.Controls.Add(this.zones_ZoneIncludeRadioButton);
			this.zones_ZoneIncludeExcludePanel.Location = new System.Drawing.Point(3, 75);
			this.zones_ZoneIncludeExcludePanel.Name = "zones_ZoneIncludeExcludePanel";
			this.zones_ZoneIncludeExcludePanel.Size = new System.Drawing.Size(276, 22);
			this.zones_ZoneIncludeExcludePanel.TabIndex = 24;
			// 
			// zones_ZoneExcludeRadioButton
			// 
			this.zones_ZoneExcludeRadioButton.AutoSize = true;
			this.zones_ZoneExcludeRadioButton.Location = new System.Drawing.Point(153, 3);
			this.zones_ZoneExcludeRadioButton.Name = "zones_ZoneExcludeRadioButton";
			this.zones_ZoneExcludeRadioButton.Size = new System.Drawing.Size(94, 17);
			this.zones_ZoneExcludeRadioButton.TabIndex = 16;
			this.zones_ZoneExcludeRadioButton.TabStop = true;
			this.zones_ZoneExcludeRadioButton.Text = "Exclude zones";
			this.zones_ZoneExcludeRadioButton.UseVisualStyleBackColor = true;
			// 
			// zones_ZoneIncludeRadioButton
			// 
			this.zones_ZoneIncludeRadioButton.AutoSize = true;
			this.zones_ZoneIncludeRadioButton.Location = new System.Drawing.Point(3, 3);
			this.zones_ZoneIncludeRadioButton.Name = "zones_ZoneIncludeRadioButton";
			this.zones_ZoneIncludeRadioButton.Size = new System.Drawing.Size(91, 17);
			this.zones_ZoneIncludeRadioButton.TabIndex = 15;
			this.zones_ZoneIncludeRadioButton.TabStop = true;
			this.zones_ZoneIncludeRadioButton.Text = "Include zones";
			this.zones_ZoneIncludeRadioButton.UseVisualStyleBackColor = true;
			// 
			// zones_PresetLabel
			// 
			this.zones_PresetLabel.AutoSize = true;
			this.zones_PresetLabel.Location = new System.Drawing.Point(1, 30);
			this.zones_PresetLabel.Name = "zones_PresetLabel";
			this.zones_PresetLabel.Size = new System.Drawing.Size(37, 13);
			this.zones_PresetLabel.TabIndex = 23;
			this.zones_PresetLabel.Text = "Preset";
			// 
			// zones_ZoneFilterCheckBox
			// 
			this.zones_ZoneFilterCheckBox.AutoSize = true;
			this.zones_ZoneFilterCheckBox.Location = new System.Drawing.Point(3, 3);
			this.zones_ZoneFilterCheckBox.Name = "zones_ZoneFilterCheckBox";
			this.zones_ZoneFilterCheckBox.Size = new System.Drawing.Size(93, 17);
			this.zones_ZoneFilterCheckBox.TabIndex = 22;
			this.zones_ZoneFilterCheckBox.Text = "Filter by zones";
			this.zones_ZoneFilterCheckBox.UseVisualStyleBackColor = true;
			// 
			// zones_ZonesListDataGridView
			// 
			this.zones_ZonesListDataGridView.AllowUserToAddRows = false;
			this.zones_ZonesListDataGridView.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window;
			this.zones_ZonesListDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.zones_ZonesListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.zones_ZonesListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.zones_ZonesListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.zones_ZonesListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.zones_ZonesListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.zones_ZonesListDataGridView.ColumnHeadersVisible = false;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.zones_ZonesListDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
			this.zones_ZonesListDataGridView.GridColor = System.Drawing.SystemColors.Window;
			this.zones_ZonesListDataGridView.Location = new System.Drawing.Point(3, 150);
			this.zones_ZonesListDataGridView.Name = "zones_ZonesListDataGridView";
			this.zones_ZonesListDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.zones_ZonesListDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.zones_ZonesListDataGridView.RowHeadersVisible = false;
			this.zones_ZonesListDataGridView.Size = new System.Drawing.Size(370, 135);
			this.zones_ZonesListDataGridView.TabIndex = 28;
			// 
			// zones_ZoneAddComboBox
			// 
			this.zones_ZoneAddComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.zones_ZoneAddComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.zones_ZoneAddComboBox.FormattingEnabled = true;
			this.zones_ZoneAddComboBox.Location = new System.Drawing.Point(3, 123);
			this.zones_ZoneAddComboBox.Name = "zones_ZoneAddComboBox";
			this.zones_ZoneAddComboBox.Size = new System.Drawing.Size(370, 21);
			this.zones_ZoneAddComboBox.TabIndex = 27;
			// 
			// zones_ZonePresetComboBox
			// 
			this.zones_ZonePresetComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.zones_ZonePresetComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.zones_ZonePresetComboBox.FormattingEnabled = true;
			this.zones_ZonePresetComboBox.Location = new System.Drawing.Point(3, 46);
			this.zones_ZonePresetComboBox.Name = "zones_ZonePresetComboBox";
			this.zones_ZonePresetComboBox.Size = new System.Drawing.Size(183, 21);
			this.zones_ZonePresetComboBox.TabIndex = 25;
			// 
			// ZonesView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.zones_ZonesListDataGridView);
			this.Controls.Add(this.zones_ZoneAddComboBox);
			this.Controls.Add(this.zones_AddZoneLabel);
			this.Controls.Add(this.zones_ZonePresetComboBox);
			this.Controls.Add(this.zones_ZoneIncludeExcludePanel);
			this.Controls.Add(this.zones_PresetLabel);
			this.Controls.Add(this.zones_ZoneFilterCheckBox);
			this.Name = "ZonesView";
			this.Size = new System.Drawing.Size(500, 400);
			this.zones_ZoneIncludeExcludePanel.ResumeLayout(false);
			this.zones_ZoneIncludeExcludePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.zones_ZonesListDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private CustomComboBox zones_ZoneAddComboBox;
        private System.Windows.Forms.Label zones_AddZoneLabel;
        private CustomComboBox zones_ZonePresetComboBox;
        private System.Windows.Forms.Panel zones_ZoneIncludeExcludePanel;
        private System.Windows.Forms.RadioButton zones_ZoneExcludeRadioButton;
        private System.Windows.Forms.RadioButton zones_ZoneIncludeRadioButton;
        private System.Windows.Forms.Label zones_PresetLabel;
        private System.Windows.Forms.CheckBox zones_ZoneFilterCheckBox;
        private CustomDataGridView zones_ZonesListDataGridView;
    }
}
