using ACT_FFXIV_Kapture.Aetherbridge;

namespace ACT_FFXIV_Kapture.Plugin
{
	partial class AdvancedView
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.items_AddItemLabel = new System.Windows.Forms.Label();
			this.items_ItemExcludeRadioButton = new System.Windows.Forms.RadioButton();
			this.items_ItemIncludeRadioButton = new System.Windows.Forms.RadioButton();
			this.items_ItemFilterCheckBox = new System.Windows.Forms.CheckBox();
			this.zones_AddZoneLabel = new System.Windows.Forms.Label();
			this.zones_ZoneExcludeRadioButton = new System.Windows.Forms.RadioButton();
			this.zones_ZoneIncludeRadioButton = new System.Windows.Forms.RadioButton();
			this.zones_ZoneFilterCheckBox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.itemsGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.zonesGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.items_ItemAddComboBox = new CustomComboBox();
			this.items_ItemsListDataGridView = new CustomDataGridView();
			this.zones_ZonesListDataGridView = new CustomDataGridView();
			this.zones_ZoneAddComboBox = new CustomComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.itemsGroupBox.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.zonesGroupBox.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.items_ItemsListDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.zones_ZonesListDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// items_AddItemLabel
			// 
			this.items_AddItemLabel.AutoSize = true;
			this.items_AddItemLabel.Location = new System.Drawing.Point(6, 50);
			this.items_AddItemLabel.Name = "items_AddItemLabel";
			this.items_AddItemLabel.Size = new System.Drawing.Size(49, 13);
			this.items_AddItemLabel.TabIndex = 26;
			this.items_AddItemLabel.Text = "Add Item";
			// 
			// items_ItemExcludeRadioButton
			// 
			this.items_ItemExcludeRadioButton.AutoSize = true;
			this.items_ItemExcludeRadioButton.Location = new System.Drawing.Point(191, 3);
			this.items_ItemExcludeRadioButton.Name = "items_ItemExcludeRadioButton";
			this.items_ItemExcludeRadioButton.Size = new System.Drawing.Size(91, 17);
			this.items_ItemExcludeRadioButton.TabIndex = 16;
			this.items_ItemExcludeRadioButton.TabStop = true;
			this.items_ItemExcludeRadioButton.Text = "Exclude Items";
			this.items_ItemExcludeRadioButton.UseVisualStyleBackColor = true;
			// 
			// items_ItemIncludeRadioButton
			// 
			this.items_ItemIncludeRadioButton.AutoSize = true;
			this.items_ItemIncludeRadioButton.Location = new System.Drawing.Point(98, 3);
			this.items_ItemIncludeRadioButton.Name = "items_ItemIncludeRadioButton";
			this.items_ItemIncludeRadioButton.Size = new System.Drawing.Size(87, 17);
			this.items_ItemIncludeRadioButton.TabIndex = 15;
			this.items_ItemIncludeRadioButton.TabStop = true;
			this.items_ItemIncludeRadioButton.Text = "Include items";
			this.items_ItemIncludeRadioButton.UseVisualStyleBackColor = true;
			// 
			// items_ItemFilterCheckBox
			// 
			this.items_ItemFilterCheckBox.AutoSize = true;
			this.items_ItemFilterCheckBox.Location = new System.Drawing.Point(3, 3);
			this.items_ItemFilterCheckBox.Name = "items_ItemFilterCheckBox";
			this.items_ItemFilterCheckBox.Size = new System.Drawing.Size(89, 17);
			this.items_ItemFilterCheckBox.TabIndex = 22;
			this.items_ItemFilterCheckBox.Text = "Filter by items";
			this.items_ItemFilterCheckBox.UseVisualStyleBackColor = true;
			// 
			// zones_AddZoneLabel
			// 
			this.zones_AddZoneLabel.AutoSize = true;
			this.zones_AddZoneLabel.Location = new System.Drawing.Point(9, 50);
			this.zones_AddZoneLabel.Name = "zones_AddZoneLabel";
			this.zones_AddZoneLabel.Size = new System.Drawing.Size(54, 13);
			this.zones_AddZoneLabel.TabIndex = 33;
			this.zones_AddZoneLabel.Text = "Add Zone";
			// 
			// zones_ZoneExcludeRadioButton
			// 
			this.zones_ZoneExcludeRadioButton.AutoSize = true;
			this.zones_ZoneExcludeRadioButton.Location = new System.Drawing.Point(199, 3);
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
			this.zones_ZoneIncludeRadioButton.Location = new System.Drawing.Point(102, 3);
			this.zones_ZoneIncludeRadioButton.Name = "zones_ZoneIncludeRadioButton";
			this.zones_ZoneIncludeRadioButton.Size = new System.Drawing.Size(91, 17);
			this.zones_ZoneIncludeRadioButton.TabIndex = 15;
			this.zones_ZoneIncludeRadioButton.TabStop = true;
			this.zones_ZoneIncludeRadioButton.Text = "Include zones";
			this.zones_ZoneIncludeRadioButton.UseVisualStyleBackColor = true;
			// 
			// zones_ZoneFilterCheckBox
			// 
			this.zones_ZoneFilterCheckBox.AutoSize = true;
			this.zones_ZoneFilterCheckBox.Location = new System.Drawing.Point(3, 3);
			this.zones_ZoneFilterCheckBox.Name = "zones_ZoneFilterCheckBox";
			this.zones_ZoneFilterCheckBox.Size = new System.Drawing.Size(93, 17);
			this.zones_ZoneFilterCheckBox.TabIndex = 29;
			this.zones_ZoneFilterCheckBox.Text = "Filter by zones";
			this.zones_ZoneFilterCheckBox.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.items_ItemFilterCheckBox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.items_ItemIncludeRadioButton, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.items_ItemExcludeRadioButton, 2, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 23);
			this.tableLayoutPanel1.TabIndex = 36;
			// 
			// itemsGroupBox
			// 
			this.itemsGroupBox.AutoSize = true;
			this.itemsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.itemsGroupBox.Controls.Add(this.items_AddItemLabel);
			this.itemsGroupBox.Controls.Add(this.tableLayoutPanel1);
			this.itemsGroupBox.Controls.Add(this.items_ItemAddComboBox);
			this.itemsGroupBox.Controls.Add(this.items_ItemsListDataGridView);
			this.itemsGroupBox.Location = new System.Drawing.Point(3, 3);
			this.itemsGroupBox.Name = "itemsGroupBox";
			this.itemsGroupBox.Size = new System.Drawing.Size(370, 249);
			this.itemsGroupBox.TabIndex = 37;
			this.itemsGroupBox.TabStop = false;
			this.itemsGroupBox.Text = "Items";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.zones_ZoneFilterCheckBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.zones_ZoneExcludeRadioButton, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.zones_ZoneIncludeRadioButton, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 19);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(296, 23);
			this.tableLayoutPanel2.TabIndex = 38;
			// 
			// zonesGroupBox
			// 
			this.zonesGroupBox.AutoSize = true;
			this.zonesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.zonesGroupBox.Controls.Add(this.zones_ZonesListDataGridView);
			this.zonesGroupBox.Controls.Add(this.tableLayoutPanel2);
			this.zonesGroupBox.Controls.Add(this.zones_AddZoneLabel);
			this.zonesGroupBox.Controls.Add(this.zones_ZoneAddComboBox);
			this.zonesGroupBox.Location = new System.Drawing.Point(382, 3);
			this.zonesGroupBox.Name = "zonesGroupBox";
			this.zonesGroupBox.Size = new System.Drawing.Size(373, 249);
			this.zonesGroupBox.TabIndex = 39;
			this.zonesGroupBox.TabStop = false;
			this.zonesGroupBox.Text = "Zones";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.itemsGroupBox, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.zonesGroupBox, 1, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(758, 255);
			this.tableLayoutPanel3.TabIndex = 40;
			// 
			// items_ItemAddComboBox
			// 
			this.items_ItemAddComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.items_ItemAddComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.items_ItemAddComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.items_ItemAddComboBox.FormattingEnabled = true;
			this.items_ItemAddComboBox.Location = new System.Drawing.Point(9, 68);
			this.items_ItemAddComboBox.Name = "items_ItemAddComboBox";
			this.items_ItemAddComboBox.Size = new System.Drawing.Size(355, 21);
			this.items_ItemAddComboBox.TabIndex = 27;
			// 
			// items_ItemsListDataGridView
			// 
			this.items_ItemsListDataGridView.AllowUserToAddRows = false;
			this.items_ItemsListDataGridView.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window;
			this.items_ItemsListDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.items_ItemsListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.items_ItemsListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.items_ItemsListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.items_ItemsListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.items_ItemsListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.items_ItemsListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.items_ItemsListDataGridView.ColumnHeadersVisible = false;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.items_ItemsListDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
			this.items_ItemsListDataGridView.GridColor = System.Drawing.SystemColors.Window;
			this.items_ItemsListDataGridView.Location = new System.Drawing.Point(9, 95);
			this.items_ItemsListDataGridView.Name = "items_ItemsListDataGridView";
			this.items_ItemsListDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.items_ItemsListDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.items_ItemsListDataGridView.RowHeadersVisible = false;
			this.items_ItemsListDataGridView.Size = new System.Drawing.Size(355, 135);
			this.items_ItemsListDataGridView.TabIndex = 28;
			// 
			// zones_ZonesListDataGridView
			// 
			this.zones_ZonesListDataGridView.AllowUserToAddRows = false;
			this.zones_ZonesListDataGridView.AllowUserToResizeRows = false;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Window;
			this.zones_ZonesListDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.zones_ZonesListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.zones_ZonesListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.zones_ZonesListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.zones_ZonesListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.zones_ZonesListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.zones_ZonesListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.zones_ZonesListDataGridView.ColumnHeadersVisible = false;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.zones_ZonesListDataGridView.DefaultCellStyle = dataGridViewCellStyle7;
			this.zones_ZonesListDataGridView.GridColor = System.Drawing.SystemColors.Window;
			this.zones_ZonesListDataGridView.Location = new System.Drawing.Point(9, 95);
			this.zones_ZonesListDataGridView.Name = "zones_ZonesListDataGridView";
			this.zones_ZonesListDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.zones_ZonesListDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.zones_ZonesListDataGridView.RowHeadersVisible = false;
			this.zones_ZonesListDataGridView.Size = new System.Drawing.Size(358, 135);
			this.zones_ZonesListDataGridView.TabIndex = 35;
			// 
			// zones_ZoneAddComboBox
			// 
			this.zones_ZoneAddComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.zones_ZoneAddComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.zones_ZoneAddComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.zones_ZoneAddComboBox.FormattingEnabled = true;
			this.zones_ZoneAddComboBox.Location = new System.Drawing.Point(9, 68);
			this.zones_ZoneAddComboBox.Name = "zones_ZoneAddComboBox";
			this.zones_ZoneAddComboBox.Size = new System.Drawing.Size(358, 21);
			this.zones_ZoneAddComboBox.TabIndex = 34;
			// 
			// AdvancedView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanel3);
			this.Name = "AdvancedView";
			this.Size = new System.Drawing.Size(764, 261);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.itemsGroupBox.ResumeLayout(false);
			this.itemsGroupBox.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.zonesGroupBox.ResumeLayout(false);
			this.zonesGroupBox.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.items_ItemsListDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.zones_ZonesListDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private CustomComboBox items_ItemAddComboBox;
		private System.Windows.Forms.Label items_AddItemLabel;
		private System.Windows.Forms.RadioButton items_ItemExcludeRadioButton;
		private System.Windows.Forms.RadioButton items_ItemIncludeRadioButton;
		private System.Windows.Forms.CheckBox items_ItemFilterCheckBox;
		private CustomDataGridView items_ItemsListDataGridView;
		private CustomDataGridView zones_ZonesListDataGridView;
		private CustomComboBox zones_ZoneAddComboBox;
		private System.Windows.Forms.Label zones_AddZoneLabel;
		private System.Windows.Forms.RadioButton zones_ZoneExcludeRadioButton;
		private System.Windows.Forms.RadioButton zones_ZoneIncludeRadioButton;
		private System.Windows.Forms.CheckBox zones_ZoneFilterCheckBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox itemsGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.GroupBox zonesGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
	}
}
