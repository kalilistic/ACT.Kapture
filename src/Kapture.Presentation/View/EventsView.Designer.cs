namespace ACT_FFXIV_Kapture.Presentation
{
    partial class EventsView
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
            this.events_ItemAddedCheckBox = new System.Windows.Forms.CheckBox();
            this.events_ItemLostCheckBox = new System.Windows.Forms.CheckBox();
            this.events_YouRollCheckBox = new System.Windows.Forms.CheckBox();
            this.events_YouObtainCheckBox = new System.Windows.Forms.CheckBox();
            this.events_TheyObtainCheckBox = new System.Windows.Forms.CheckBox();
            this.events_TheyRollCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // events_ItemAddedCheckBox
            // 
            this.events_ItemAddedCheckBox.AutoSize = true;
            this.events_ItemAddedCheckBox.Location = new System.Drawing.Point(3, 3);
            this.events_ItemAddedCheckBox.Name = "events_ItemAddedCheckBox";
            this.events_ItemAddedCheckBox.Size = new System.Drawing.Size(126, 17);
            this.events_ItemAddedCheckBox.TabIndex = 1;
            this.events_ItemAddedCheckBox.Text = "Item added to loot list";
            this.events_ItemAddedCheckBox.UseVisualStyleBackColor = true;
            // 
            // events_ItemLostCheckBox
            // 
            this.events_ItemLostCheckBox.AutoSize = true;
            this.events_ItemLostCheckBox.Location = new System.Drawing.Point(3, 26);
            this.events_ItemLostCheckBox.Name = "events_ItemLostCheckBox";
            this.events_ItemLostCheckBox.Size = new System.Drawing.Size(110, 17);
            this.events_ItemLostCheckBox.TabIndex = 3;
            this.events_ItemLostCheckBox.Text = "Item drops to floor";
            this.events_ItemLostCheckBox.UseVisualStyleBackColor = true;
            // 
            // events_YouRollCheckBox
            // 
            this.events_YouRollCheckBox.AutoSize = true;
            this.events_YouRollCheckBox.Location = new System.Drawing.Point(3, 95);
            this.events_YouRollCheckBox.Name = "events_YouRollCheckBox";
            this.events_YouRollCheckBox.Size = new System.Drawing.Size(117, 17);
            this.events_YouRollCheckBox.TabIndex = 11;
            this.events_YouRollCheckBox.Text = "YOU roll on an item";
            this.events_YouRollCheckBox.UseVisualStyleBackColor = true;
            // 
            // events_YouObtainCheckBox
            // 
            this.events_YouObtainCheckBox.AutoSize = true;
            this.events_YouObtainCheckBox.Location = new System.Drawing.Point(3, 49);
            this.events_YouObtainCheckBox.Name = "events_YouObtainCheckBox";
            this.events_YouObtainCheckBox.Size = new System.Drawing.Size(118, 17);
            this.events_YouObtainCheckBox.TabIndex = 12;
            this.events_YouObtainCheckBox.Text = "YOU obtain an item";
            this.events_YouObtainCheckBox.UseVisualStyleBackColor = true;
            // 
            // events_TheyObtainCheckBox
            // 
            this.events_TheyObtainCheckBox.AutoSize = true;
            this.events_TheyObtainCheckBox.Location = new System.Drawing.Point(3, 72);
            this.events_TheyObtainCheckBox.Name = "events_TheyObtainCheckBox";
            this.events_TheyObtainCheckBox.Size = new System.Drawing.Size(119, 17);
            this.events_TheyObtainCheckBox.TabIndex = 14;
            this.events_TheyObtainCheckBox.Text = "They obtain an item";
            this.events_TheyObtainCheckBox.UseVisualStyleBackColor = true;
            // 
            // events_TheyRollCheckBox
            // 
            this.events_TheyRollCheckBox.AutoSize = true;
            this.events_TheyRollCheckBox.Location = new System.Drawing.Point(3, 118);
            this.events_TheyRollCheckBox.Name = "events_TheyRollCheckBox";
            this.events_TheyRollCheckBox.Size = new System.Drawing.Size(118, 17);
            this.events_TheyRollCheckBox.TabIndex = 13;
            this.events_TheyRollCheckBox.Text = "They roll on an item";
            this.events_TheyRollCheckBox.UseVisualStyleBackColor = true;
            // 
            // EventsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.events_TheyObtainCheckBox);
            this.Controls.Add(this.events_TheyRollCheckBox);
            this.Controls.Add(this.events_YouObtainCheckBox);
            this.Controls.Add(this.events_YouRollCheckBox);
            this.Controls.Add(this.events_ItemLostCheckBox);
            this.Controls.Add(this.events_ItemAddedCheckBox);
            this.Name = "EventsView";
            this.Size = new System.Drawing.Size(140, 146);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox events_ItemAddedCheckBox;
        private System.Windows.Forms.CheckBox events_ItemLostCheckBox;
        private System.Windows.Forms.CheckBox events_YouRollCheckBox;
        private System.Windows.Forms.CheckBox events_YouObtainCheckBox;
        private System.Windows.Forms.CheckBox events_TheyObtainCheckBox;
        private System.Windows.Forms.CheckBox events_TheyRollCheckBox;
    }
}
