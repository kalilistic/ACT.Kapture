using ACT_FFXIV_Kapture.Presentation.CustomControl;

namespace ACT_FFXIV_Kapture.Presentation
{
    partial class ItemsView
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
            this.label5 = new System.Windows.Forms.Label();
            this.items_ItemIncludeExcludePanel = new System.Windows.Forms.Panel();
            this.items_ItemExcludeRadioButton = new System.Windows.Forms.RadioButton();
            this.items_ItemIncludeRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.items_ItemFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.items_ItemsListDataGridView = new CustomDataGridView();
            this.items_ItemAddComboBox = new CustomComboBox();
            this.items_ItemPresetComboBox = new CustomComboBox();
            this.items_ItemIncludeExcludePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.items_ItemsListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Add Item";
            // 
            // items_ItemIncludeExcludePanel
            // 
            this.items_ItemIncludeExcludePanel.Controls.Add(this.items_ItemExcludeRadioButton);
            this.items_ItemIncludeExcludePanel.Controls.Add(this.items_ItemIncludeRadioButton);
            this.items_ItemIncludeExcludePanel.Location = new System.Drawing.Point(3, 55);
            this.items_ItemIncludeExcludePanel.Name = "items_ItemIncludeExcludePanel";
            this.items_ItemIncludeExcludePanel.Size = new System.Drawing.Size(214, 22);
            this.items_ItemIncludeExcludePanel.TabIndex = 24;
            // 
            // items_ItemExcludeRadioButton
            // 
            this.items_ItemExcludeRadioButton.AutoSize = true;
            this.items_ItemExcludeRadioButton.Location = new System.Drawing.Point(111, 3);
            this.items_ItemExcludeRadioButton.Name = "items_ItemExcludeRadioButton";
            this.items_ItemExcludeRadioButton.Size = new System.Drawing.Size(90, 17);
            this.items_ItemExcludeRadioButton.TabIndex = 16;
            this.items_ItemExcludeRadioButton.TabStop = true;
            this.items_ItemExcludeRadioButton.Text = "Exclude items";
            this.items_ItemExcludeRadioButton.UseVisualStyleBackColor = true;
            // 
            // items_ItemIncludeRadioButton
            // 
            this.items_ItemIncludeRadioButton.AutoSize = true;
            this.items_ItemIncludeRadioButton.Location = new System.Drawing.Point(3, 3);
            this.items_ItemIncludeRadioButton.Name = "items_ItemIncludeRadioButton";
            this.items_ItemIncludeRadioButton.Size = new System.Drawing.Size(87, 17);
            this.items_ItemIncludeRadioButton.TabIndex = 15;
            this.items_ItemIncludeRadioButton.TabStop = true;
            this.items_ItemIncludeRadioButton.Text = "Include items";
            this.items_ItemIncludeRadioButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Preset";
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
            // items_ItemsListDataGridView
            // 
            this.items_ItemsListDataGridView.AllowUserToAddRows = false;
            this.items_ItemsListDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window;
            this.items_ItemsListDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.items_ItemsListDataGridView.Location = new System.Drawing.Point(4, 114);
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
            this.items_ItemsListDataGridView.Size = new System.Drawing.Size(330, 135);
            this.items_ItemsListDataGridView.TabIndex = 28;
            // 
            // items_ItemAddComboBox
            // 
            this.items_ItemAddComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.items_ItemAddComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.items_ItemAddComboBox.FormattingEnabled = true;
            this.items_ItemAddComboBox.Location = new System.Drawing.Point(60, 84);
            this.items_ItemAddComboBox.Name = "items_ItemAddComboBox";
            this.items_ItemAddComboBox.Size = new System.Drawing.Size(274, 21);
            this.items_ItemAddComboBox.TabIndex = 27;
            // 
            // items_ItemPresetComboBox
            // 
            this.items_ItemPresetComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.items_ItemPresetComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.items_ItemPresetComboBox.FormattingEnabled = true;
            this.items_ItemPresetComboBox.Location = new System.Drawing.Point(58, 27);
            this.items_ItemPresetComboBox.Name = "items_ItemPresetComboBox";
            this.items_ItemPresetComboBox.Size = new System.Drawing.Size(164, 21);
            this.items_ItemPresetComboBox.TabIndex = 25;
            // 
            // ItemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.items_ItemsListDataGridView);
            this.Controls.Add(this.items_ItemAddComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.items_ItemPresetComboBox);
            this.Controls.Add(this.items_ItemIncludeExcludePanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.items_ItemFilterCheckBox);
            this.Name = "ItemsView";
            this.Size = new System.Drawing.Size(465, 303);
            this.items_ItemIncludeExcludePanel.ResumeLayout(false);
            this.items_ItemIncludeExcludePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.items_ItemsListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomComboBox items_ItemAddComboBox;
        private System.Windows.Forms.Label label5;
        private CustomComboBox items_ItemPresetComboBox;
        private System.Windows.Forms.Panel items_ItemIncludeExcludePanel;
        private System.Windows.Forms.RadioButton items_ItemExcludeRadioButton;
        private System.Windows.Forms.RadioButton items_ItemIncludeRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox items_ItemFilterCheckBox;
        private CustomDataGridView items_ItemsListDataGridView;
    }
}
