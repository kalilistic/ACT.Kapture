using ACT_FFXIV.Aetherbridge;

namespace ACT_FFXIV_Kapture.Plugin
{
    partial class BaseView
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
			this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
			this.mainButton = new CustomButton();
			this.advancedFiltersButton = new CustomButton();
			this.aboutButton = new CustomButton();
			this.viewPanel = new CustomPanel();
			this.tableLayoutPanel11.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel11
			// 
			this.tableLayoutPanel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel11.AutoSize = true;
			this.tableLayoutPanel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel11.ColumnCount = 4;
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel11.Controls.Add(this.mainButton, 0, 0);
			this.tableLayoutPanel11.Controls.Add(this.advancedFiltersButton, 1, 0);
			this.tableLayoutPanel11.Controls.Add(this.aboutButton, 3, 0);
			this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel11.Name = "tableLayoutPanel11";
			this.tableLayoutPanel11.RowCount = 1;
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel11.Size = new System.Drawing.Size(205, 31);
			this.tableLayoutPanel11.TabIndex = 44;
			// 
			// mainButton
			// 
			this.mainButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mainButton.AutoSize = true;
			this.mainButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.mainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainButton.Location = new System.Drawing.Point(3, 3);
			this.mainButton.Name = "mainButton";
			this.mainButton.Size = new System.Drawing.Size(42, 25);
			this.mainButton.TabIndex = 43;
			this.mainButton.Text = "Main";
			this.mainButton.UseVisualStyleBackColor = true;
			// 
			// advancedFiltersButton
			// 
			this.advancedFiltersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.advancedFiltersButton.AutoSize = true;
			this.advancedFiltersButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.advancedFiltersButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.advancedFiltersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.advancedFiltersButton.Location = new System.Drawing.Point(51, 3);
			this.advancedFiltersButton.Name = "advancedFiltersButton";
			this.advancedFiltersButton.Size = new System.Drawing.Size(98, 25);
			this.advancedFiltersButton.TabIndex = 40;
			this.advancedFiltersButton.Text = "Advanced Filters";
			this.advancedFiltersButton.UseVisualStyleBackColor = true;
			// 
			// aboutButton
			// 
			this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.aboutButton.AutoSize = true;
			this.aboutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.aboutButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.aboutButton.Location = new System.Drawing.Point(155, 3);
			this.aboutButton.Name = "aboutButton";
			this.aboutButton.Size = new System.Drawing.Size(47, 25);
			this.aboutButton.TabIndex = 42;
			this.aboutButton.Text = "About";
			this.aboutButton.UseVisualStyleBackColor = true;
			// 
			// viewPanel
			// 
			this.viewPanel.AutoSize = true;
			this.viewPanel.BackColor = System.Drawing.SystemColors.Control;
			this.viewPanel.Location = new System.Drawing.Point(0, 35);
			this.viewPanel.Name = "viewPanel";
			this.viewPanel.Size = new System.Drawing.Size(1000, 965);
			this.viewPanel.TabIndex = 10;
			// 
			// BaseView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel11);
			this.Controls.Add(this.viewPanel);
			this.Name = "BaseView";
			this.Size = new System.Drawing.Size(1000, 1000);
			this.tableLayoutPanel11.ResumeLayout(false);
			this.tableLayoutPanel11.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private CustomPanel viewPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private CustomButton mainButton;
        private CustomButton aboutButton;
        private CustomButton advancedFiltersButton;
    }
}
