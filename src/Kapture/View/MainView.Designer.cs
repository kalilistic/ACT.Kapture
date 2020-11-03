using ACT_FFXIV.Aetherbridge;

namespace ACT_FFXIV_Kapture.Plugin
{
    partial class MainView
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
			this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.generalGroupBox = new System.Windows.Forms.GroupBox();
			this.generalGetMarketBoardDataCheckBox = new System.Windows.Forms.CheckBox();
			this.generalPluginEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.generalCheckForBetaVersionsCheckBox = new System.Windows.Forms.CheckBox();
			this.generalLogImportsEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.messageLogGroupBox = new System.Windows.Forms.GroupBox();
			this.messageLogListBox = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
			this.filtersGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.filtersItemObtainedCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersItemAddedCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersExcludeCommonItemsCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersSelfCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersPartyCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersItemRolledOnCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersItemLostCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersAllianceCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersItemCastLotCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersIncludeMountsOnlyCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersHighEndDutyOnlyCheckBox = new System.Windows.Forms.CheckBox();
			this.filtersItemSearchedCheckBox = new System.Windows.Forms.CheckBox();
			this.httpGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			this.httpUpdateButton = new ACT_FFXIV.Aetherbridge.CustomButton();
			this.httpEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.httpEndpointTextBox = new ACT_FFXIV.Aetherbridge.CustomTextBox();
			this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			this.httpEndpointLabel = new System.Windows.Forms.Label();
			this.httpCustomJsonLabel = new System.Windows.Forms.Label();
			this.httpCustomJsonTextBox = new ACT_FFXIV.Aetherbridge.CustomTextBox();
			this.loggingGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.loggingEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.loggingLocationTextBox = new ACT_FFXIV.Aetherbridge.CustomTextBox();
			this.loggingFormatLabel = new System.Windows.Forms.Label();
			this.loggingLocationLabel = new System.Windows.Forms.Label();
			this.loggingFormatComboBox = new ACT_FFXIV.Aetherbridge.CustomComboBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.loggingBrowseButton = new ACT_FFXIV.Aetherbridge.CustomButton();
			this.loggingUpdateButton = new ACT_FFXIV.Aetherbridge.CustomButton();
			this.discordGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.discordEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.discordWebhookTextBox = new ACT_FFXIV.Aetherbridge.CustomTextBox();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.discordUpdateButton = new ACT_FFXIV.Aetherbridge.CustomButton();
			this.discordWebhookLabel = new System.Windows.Forms.Label();
			this.generalGroupBox.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.messageLogGroupBox.SuspendLayout();
			this.tableLayoutPanel10.SuspendLayout();
			this.filtersGroupBox.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.httpGroupBox.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			this.loggingGroupBox.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.discordGroupBox.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridViewButtonColumn1
			// 
			this.dataGridViewButtonColumn1.HeaderText = "Delete";
			this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
			this.dataGridViewButtonColumn1.Text = "Y";
			this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
			// 
			// generalGroupBox
			// 
			this.generalGroupBox.AutoSize = true;
			this.generalGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.generalGroupBox.Controls.Add(this.generalGetMarketBoardDataCheckBox);
			this.generalGroupBox.Controls.Add(this.generalPluginEnabledCheckBox);
			this.generalGroupBox.Controls.Add(this.generalCheckForBetaVersionsCheckBox);
			this.generalGroupBox.Controls.Add(this.generalLogImportsEnabledCheckBox);
			this.generalGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.generalGroupBox.Location = new System.Drawing.Point(3, 3);
			this.generalGroupBox.MaximumSize = new System.Drawing.Size(0, 115);
			this.generalGroupBox.Name = "generalGroupBox";
			this.generalGroupBox.Size = new System.Drawing.Size(150, 115);
			this.generalGroupBox.TabIndex = 3;
			this.generalGroupBox.TabStop = false;
			this.generalGroupBox.Text = "General";
			// 
			// generalGetMarketBoardDataCheckBox
			// 
			this.generalGetMarketBoardDataCheckBox.AutoSize = true;
			this.generalGetMarketBoardDataCheckBox.Location = new System.Drawing.Point(6, 88);
			this.generalGetMarketBoardDataCheckBox.Name = "generalGetMarketBoardDataCheckBox";
			this.generalGetMarketBoardDataCheckBox.Size = new System.Drawing.Size(129, 17);
			this.generalGetMarketBoardDataCheckBox.TabIndex = 3;
			this.generalGetMarketBoardDataCheckBox.Text = "Get marketboard data";
			this.generalGetMarketBoardDataCheckBox.UseVisualStyleBackColor = true;
			// 
			// generalPluginEnabledCheckBox
			// 
			this.generalPluginEnabledCheckBox.AutoSize = true;
			this.generalPluginEnabledCheckBox.Location = new System.Drawing.Point(6, 19);
			this.generalPluginEnabledCheckBox.Name = "generalPluginEnabledCheckBox";
			this.generalPluginEnabledCheckBox.Size = new System.Drawing.Size(96, 17);
			this.generalPluginEnabledCheckBox.TabIndex = 0;
			this.generalPluginEnabledCheckBox.Text = "Plugin enabled";
			this.generalPluginEnabledCheckBox.UseVisualStyleBackColor = true;
			// 
			// generalCheckForBetaVersionsCheckBox
			// 
			this.generalCheckForBetaVersionsCheckBox.AutoSize = true;
			this.generalCheckForBetaVersionsCheckBox.Location = new System.Drawing.Point(6, 65);
			this.generalCheckForBetaVersionsCheckBox.Name = "generalCheckForBetaVersionsCheckBox";
			this.generalCheckForBetaVersionsCheckBox.Size = new System.Drawing.Size(138, 17);
			this.generalCheckForBetaVersionsCheckBox.TabIndex = 2;
			this.generalCheckForBetaVersionsCheckBox.Text = "Check for beta versions";
			this.generalCheckForBetaVersionsCheckBox.UseVisualStyleBackColor = true;
			// 
			// generalLogImportsEnabledCheckBox
			// 
			this.generalLogImportsEnabledCheckBox.AutoSize = true;
			this.generalLogImportsEnabledCheckBox.Location = new System.Drawing.Point(6, 42);
			this.generalLogImportsEnabledCheckBox.Name = "generalLogImportsEnabledCheckBox";
			this.generalLogImportsEnabledCheckBox.Size = new System.Drawing.Size(121, 17);
			this.generalLogImportsEnabledCheckBox.TabIndex = 1;
			this.generalLogImportsEnabledCheckBox.Text = "Log imports enabled";
			this.generalLogImportsEnabledCheckBox.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.messageLogGroupBox, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel10, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.httpGroupBox, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.loggingGroupBox, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.discordGroupBox, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(719, 445);
			this.tableLayoutPanel1.TabIndex = 26;
			// 
			// messageLogGroupBox
			// 
			this.messageLogGroupBox.AutoSize = true;
			this.messageLogGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.messageLogGroupBox.Controls.Add(this.messageLogListBox);
			this.messageLogGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageLogGroupBox.Location = new System.Drawing.Point(347, 251);
			this.messageLogGroupBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.messageLogGroupBox.Name = "messageLogGroupBox";
			this.messageLogGroupBox.Padding = new System.Windows.Forms.Padding(9);
			this.messageLogGroupBox.Size = new System.Drawing.Size(369, 194);
			this.messageLogGroupBox.TabIndex = 27;
			this.messageLogGroupBox.TabStop = false;
			this.messageLogGroupBox.Text = "Message Log";
			// 
			// messageLogListBox
			// 
			this.messageLogListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.messageLogListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageLogListBox.Location = new System.Drawing.Point(9, 22);
			this.messageLogListBox.Name = "messageLogListBox";
			this.messageLogListBox.Size = new System.Drawing.Size(351, 163);
			this.messageLogListBox.TabIndex = 20;
			// 
			// tableLayoutPanel10
			// 
			this.tableLayoutPanel10.AutoSize = true;
			this.tableLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel10.ColumnCount = 3;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel10, 2);
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel10.Controls.Add(this.filtersGroupBox, 1, 0);
			this.tableLayoutPanel10.Controls.Add(this.generalGroupBox, 0, 0);
			this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel10.Name = "tableLayoutPanel10";
			this.tableLayoutPanel10.RowCount = 1;
			this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel10.Size = new System.Drawing.Size(591, 121);
			this.tableLayoutPanel10.TabIndex = 27;
			// 
			// filtersGroupBox
			// 
			this.filtersGroupBox.AutoSize = true;
			this.filtersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.filtersGroupBox.Controls.Add(this.tableLayoutPanel2);
			this.filtersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filtersGroupBox.Location = new System.Drawing.Point(159, 3);
			this.filtersGroupBox.Name = "filtersGroupBox";
			this.filtersGroupBox.Size = new System.Drawing.Size(429, 115);
			this.filtersGroupBox.TabIndex = 25;
			this.filtersGroupBox.TabStop = false;
			this.filtersGroupBox.Text = "Filters";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.filtersExcludeCommonItemsCheckBox, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.filtersSelfCheckBox, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.filtersPartyCheckBox, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.filtersAllianceCheckBox, 2, 2);
			this.tableLayoutPanel2.Controls.Add(this.filtersIncludeMountsOnlyCheckBox, 3, 2);
			this.tableLayoutPanel2.Controls.Add(this.filtersHighEndDutyOnlyCheckBox, 3, 1);
			this.tableLayoutPanel2.Controls.Add(this.filtersItemSearchedCheckBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.filtersItemObtainedCheckBox, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.filtersItemLostCheckBox, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.filtersItemAddedCheckBox, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.filtersItemRolledOnCheckBox, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.filtersItemCastLotCheckBox, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(423, 69);
			this.tableLayoutPanel2.TabIndex = 25;
			// 
			// filtersItemObtainedCheckBox
			// 
			this.filtersItemObtainedCheckBox.AutoSize = true;
			this.filtersItemObtainedCheckBox.Location = new System.Drawing.Point(9, 26);
			this.filtersItemObtainedCheckBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.filtersItemObtainedCheckBox.Name = "filtersItemObtainedCheckBox";
			this.filtersItemObtainedCheckBox.Size = new System.Drawing.Size(90, 17);
			this.filtersItemObtainedCheckBox.TabIndex = 18;
			this.filtersItemObtainedCheckBox.Text = "Item obtained";
			this.filtersItemObtainedCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersItemAddedCheckBox
			// 
			this.filtersItemAddedCheckBox.AutoSize = true;
			this.filtersItemAddedCheckBox.Location = new System.Drawing.Point(9, 49);
			this.filtersItemAddedCheckBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.filtersItemAddedCheckBox.Name = "filtersItemAddedCheckBox";
			this.filtersItemAddedCheckBox.Size = new System.Drawing.Size(79, 17);
			this.filtersItemAddedCheckBox.TabIndex = 15;
			this.filtersItemAddedCheckBox.Text = "Item added";
			this.filtersItemAddedCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersExcludeCommonItemsCheckBox
			// 
			this.filtersExcludeCommonItemsCheckBox.AutoSize = true;
			this.filtersExcludeCommonItemsCheckBox.Location = new System.Drawing.Point(284, 3);
			this.filtersExcludeCommonItemsCheckBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.filtersExcludeCommonItemsCheckBox.Name = "filtersExcludeCommonItemsCheckBox";
			this.filtersExcludeCommonItemsCheckBox.Size = new System.Drawing.Size(136, 17);
			this.filtersExcludeCommonItemsCheckBox.TabIndex = 16;
			this.filtersExcludeCommonItemsCheckBox.Text = "Exclude Common Items";
			this.filtersExcludeCommonItemsCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersSelfCheckBox
			// 
			this.filtersSelfCheckBox.AutoSize = true;
			this.filtersSelfCheckBox.Location = new System.Drawing.Point(209, 3);
			this.filtersSelfCheckBox.Name = "filtersSelfCheckBox";
			this.filtersSelfCheckBox.Size = new System.Drawing.Size(44, 17);
			this.filtersSelfCheckBox.TabIndex = 15;
			this.filtersSelfCheckBox.Text = "Self";
			this.filtersSelfCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersPartyCheckBox
			// 
			this.filtersPartyCheckBox.AutoSize = true;
			this.filtersPartyCheckBox.Location = new System.Drawing.Point(209, 26);
			this.filtersPartyCheckBox.Name = "filtersPartyCheckBox";
			this.filtersPartyCheckBox.Size = new System.Drawing.Size(50, 17);
			this.filtersPartyCheckBox.TabIndex = 16;
			this.filtersPartyCheckBox.Text = "Party";
			this.filtersPartyCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersItemRolledOnCheckBox
			// 
			this.filtersItemRolledOnCheckBox.AutoSize = true;
			this.filtersItemRolledOnCheckBox.Location = new System.Drawing.Point(114, 26);
			this.filtersItemRolledOnCheckBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.filtersItemRolledOnCheckBox.Name = "filtersItemRolledOnCheckBox";
			this.filtersItemRolledOnCheckBox.Size = new System.Drawing.Size(89, 17);
			this.filtersItemRolledOnCheckBox.TabIndex = 19;
			this.filtersItemRolledOnCheckBox.Text = "Item rolled on";
			this.filtersItemRolledOnCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersItemLostCheckBox
			// 
			this.filtersItemLostCheckBox.AutoSize = true;
			this.filtersItemLostCheckBox.Location = new System.Drawing.Point(114, 49);
			this.filtersItemLostCheckBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.filtersItemLostCheckBox.Name = "filtersItemLostCheckBox";
			this.filtersItemLostCheckBox.Size = new System.Drawing.Size(65, 17);
			this.filtersItemLostCheckBox.TabIndex = 16;
			this.filtersItemLostCheckBox.Text = "Item lost";
			this.filtersItemLostCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersAllianceCheckBox
			// 
			this.filtersAllianceCheckBox.AutoSize = true;
			this.filtersAllianceCheckBox.Location = new System.Drawing.Point(209, 49);
			this.filtersAllianceCheckBox.Name = "filtersAllianceCheckBox";
			this.filtersAllianceCheckBox.Size = new System.Drawing.Size(63, 17);
			this.filtersAllianceCheckBox.TabIndex = 18;
			this.filtersAllianceCheckBox.Text = "Alliance";
			this.filtersAllianceCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersItemCastLotCheckBox
			// 
			this.filtersItemCastLotCheckBox.AutoSize = true;
			this.filtersItemCastLotCheckBox.Location = new System.Drawing.Point(114, 3);
			this.filtersItemCastLotCheckBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.filtersItemCastLotCheckBox.Name = "filtersItemCastLotCheckBox";
			this.filtersItemCastLotCheckBox.Size = new System.Drawing.Size(83, 17);
			this.filtersItemCastLotCheckBox.TabIndex = 21;
			this.filtersItemCastLotCheckBox.Text = "Item cast lot";
			this.filtersItemCastLotCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersIncludeMountsOnlyCheckBox
			// 
			this.filtersIncludeMountsOnlyCheckBox.AutoSize = true;
			this.filtersIncludeMountsOnlyCheckBox.Location = new System.Drawing.Point(284, 49);
			this.filtersIncludeMountsOnlyCheckBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.filtersIncludeMountsOnlyCheckBox.Name = "filtersIncludeMountsOnlyCheckBox";
			this.filtersIncludeMountsOnlyCheckBox.Size = new System.Drawing.Size(123, 17);
			this.filtersIncludeMountsOnlyCheckBox.TabIndex = 20;
			this.filtersIncludeMountsOnlyCheckBox.Text = "Include Mounts Only";
			this.filtersIncludeMountsOnlyCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersHighEndDutyOnlyCheckBox
			// 
			this.filtersHighEndDutyOnlyCheckBox.AutoSize = true;
			this.filtersHighEndDutyOnlyCheckBox.Location = new System.Drawing.Point(284, 26);
			this.filtersHighEndDutyOnlyCheckBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.filtersHighEndDutyOnlyCheckBox.Name = "filtersHighEndDutyOnlyCheckBox";
			this.filtersHighEndDutyOnlyCheckBox.Size = new System.Drawing.Size(119, 17);
			this.filtersHighEndDutyOnlyCheckBox.TabIndex = 15;
			this.filtersHighEndDutyOnlyCheckBox.Text = "High-End Duty Only";
			this.filtersHighEndDutyOnlyCheckBox.UseVisualStyleBackColor = true;
			// 
			// filtersItemSearchedCheckBox
			// 
			this.filtersItemSearchedCheckBox.AutoSize = true;
			this.filtersItemSearchedCheckBox.Location = new System.Drawing.Point(9, 3);
			this.filtersItemSearchedCheckBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.filtersItemSearchedCheckBox.Name = "filtersItemSearchedCheckBox";
			this.filtersItemSearchedCheckBox.Size = new System.Drawing.Size(93, 17);
			this.filtersItemSearchedCheckBox.TabIndex = 22;
			this.filtersItemSearchedCheckBox.Text = "Item searched";
			this.filtersItemSearchedCheckBox.UseVisualStyleBackColor = true;
			// 
			// httpGroupBox
			// 
			this.httpGroupBox.AutoSize = true;
			this.httpGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.httpGroupBox.Controls.Add(this.tableLayoutPanel7);
			this.httpGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.httpGroupBox.Location = new System.Drawing.Point(3, 251);
			this.httpGroupBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.httpGroupBox.Name = "httpGroupBox";
			this.httpGroupBox.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.httpGroupBox.Size = new System.Drawing.Size(338, 194);
			this.httpGroupBox.TabIndex = 56;
			this.httpGroupBox.TabStop = false;
			this.httpGroupBox.Text = "HTTP";
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.AutoSize = true;
			this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel7.ColumnCount = 3;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel9, 2, 3);
			this.tableLayoutPanel7.Controls.Add(this.httpEnabledCheckBox, 0, 0);
			this.tableLayoutPanel7.Controls.Add(this.httpEndpointTextBox, 1, 1);
			this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 2, 2);
			this.tableLayoutPanel7.Controls.Add(this.httpEndpointLabel, 0, 1);
			this.tableLayoutPanel7.Controls.Add(this.httpCustomJsonLabel, 0, 2);
			this.tableLayoutPanel7.Controls.Add(this.httpCustomJsonTextBox, 1, 2);
			this.tableLayoutPanel7.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 4;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel7.Size = new System.Drawing.Size(308, 162);
			this.tableLayoutPanel7.TabIndex = 44;
			// 
			// tableLayoutPanel9
			// 
			this.tableLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.tableLayoutPanel9.AutoSize = true;
			this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel9.ColumnCount = 1;
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel9.Controls.Add(this.httpUpdateButton, 0, 0);
			this.tableLayoutPanel9.Location = new System.Drawing.Point(245, 128);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel9.Size = new System.Drawing.Size(60, 31);
			this.tableLayoutPanel9.TabIndex = 57;
			// 
			// httpUpdateButton
			// 
			this.httpUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.httpUpdateButton.AutoSize = true;
			this.httpUpdateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.httpUpdateButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.httpUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.httpUpdateButton.Location = new System.Drawing.Point(3, 3);
			this.httpUpdateButton.Name = "httpUpdateButton";
			this.httpUpdateButton.Size = new System.Drawing.Size(54, 25);
			this.httpUpdateButton.TabIndex = 33;
			this.httpUpdateButton.Text = "Update";
			this.httpUpdateButton.UseVisualStyleBackColor = true;
			// 
			// httpEnabledCheckBox
			// 
			this.httpEnabledCheckBox.AutoSize = true;
			this.tableLayoutPanel7.SetColumnSpan(this.httpEnabledCheckBox, 2);
			this.httpEnabledCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.httpEnabledCheckBox.Location = new System.Drawing.Point(3, 3);
			this.httpEnabledCheckBox.Name = "httpEnabledCheckBox";
			this.httpEnabledCheckBox.Size = new System.Drawing.Size(236, 17);
			this.httpEnabledCheckBox.TabIndex = 23;
			this.httpEnabledCheckBox.Text = "Enabled";
			this.httpEnabledCheckBox.UseVisualStyleBackColor = true;
			// 
			// httpEndpointTextBox
			// 
			this.httpEndpointTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel7.SetColumnSpan(this.httpEndpointTextBox, 2);
			this.httpEndpointTextBox.Location = new System.Drawing.Point(82, 26);
			this.httpEndpointTextBox.Name = "httpEndpointTextBox";
			this.httpEndpointTextBox.Size = new System.Drawing.Size(223, 20);
			this.httpEndpointTextBox.TabIndex = 28;
			// 
			// tableLayoutPanel8
			// 
			this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel8.AutoSize = true;
			this.tableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel8.ColumnCount = 1;
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel8.Location = new System.Drawing.Point(76, 128);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 1;
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.Size = new System.Drawing.Size(0, 0);
			this.tableLayoutPanel8.TabIndex = 45;
			// 
			// httpEndpointLabel
			// 
			this.httpEndpointLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.httpEndpointLabel.AutoSize = true;
			this.httpEndpointLabel.Location = new System.Drawing.Point(3, 29);
			this.httpEndpointLabel.Name = "httpEndpointLabel";
			this.httpEndpointLabel.Size = new System.Drawing.Size(49, 13);
			this.httpEndpointLabel.TabIndex = 29;
			this.httpEndpointLabel.Text = "Endpoint";
			this.httpEndpointLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// httpCustomJsonLabel
			// 
			this.httpCustomJsonLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.httpCustomJsonLabel.AutoSize = true;
			this.httpCustomJsonLabel.Location = new System.Drawing.Point(3, 80);
			this.httpCustomJsonLabel.Name = "httpCustomJsonLabel";
			this.httpCustomJsonLabel.Size = new System.Drawing.Size(73, 13);
			this.httpCustomJsonLabel.TabIndex = 46;
			this.httpCustomJsonLabel.Text = "Custom JSON";
			// 
			// httpCustomJsonTextBox
			// 
			this.tableLayoutPanel7.SetColumnSpan(this.httpCustomJsonTextBox, 2);
			this.httpCustomJsonTextBox.Location = new System.Drawing.Point(82, 52);
			this.httpCustomJsonTextBox.Multiline = true;
			this.httpCustomJsonTextBox.Name = "httpCustomJsonTextBox";
			this.httpCustomJsonTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.httpCustomJsonTextBox.Size = new System.Drawing.Size(223, 70);
			this.httpCustomJsonTextBox.TabIndex = 50;
			// 
			// loggingGroupBox
			// 
			this.loggingGroupBox.AutoSize = true;
			this.loggingGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.loggingGroupBox.Controls.Add(this.tableLayoutPanel3);
			this.loggingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loggingGroupBox.Location = new System.Drawing.Point(3, 130);
			this.loggingGroupBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.loggingGroupBox.Name = "loggingGroupBox";
			this.loggingGroupBox.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.loggingGroupBox.Size = new System.Drawing.Size(338, 118);
			this.loggingGroupBox.TabIndex = 53;
			this.loggingGroupBox.TabStop = false;
			this.loggingGroupBox.Text = "Logging";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.loggingEnabledCheckBox, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.loggingLocationTextBox, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.loggingFormatLabel, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.loggingLocationLabel, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.loggingFormatComboBox, 1, 2);
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 2, 2);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 3;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new System.Drawing.Size(326, 86);
			this.tableLayoutPanel3.TabIndex = 44;
			// 
			// loggingEnabledCheckBox
			// 
			this.loggingEnabledCheckBox.AutoSize = true;
			this.tableLayoutPanel3.SetColumnSpan(this.loggingEnabledCheckBox, 2);
			this.loggingEnabledCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loggingEnabledCheckBox.Location = new System.Drawing.Point(3, 3);
			this.loggingEnabledCheckBox.Name = "loggingEnabledCheckBox";
			this.loggingEnabledCheckBox.Size = new System.Drawing.Size(180, 17);
			this.loggingEnabledCheckBox.TabIndex = 23;
			this.loggingEnabledCheckBox.Text = "Enabled";
			this.loggingEnabledCheckBox.UseVisualStyleBackColor = true;
			// 
			// loggingLocationTextBox
			// 
			this.loggingLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.SetColumnSpan(this.loggingLocationTextBox, 2);
			this.loggingLocationTextBox.Location = new System.Drawing.Point(57, 26);
			this.loggingLocationTextBox.Name = "loggingLocationTextBox";
			this.loggingLocationTextBox.Size = new System.Drawing.Size(266, 20);
			this.loggingLocationTextBox.TabIndex = 28;
			// 
			// loggingFormatLabel
			// 
			this.loggingFormatLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.loggingFormatLabel.AutoSize = true;
			this.loggingFormatLabel.Location = new System.Drawing.Point(3, 61);
			this.loggingFormatLabel.Name = "loggingFormatLabel";
			this.loggingFormatLabel.Size = new System.Drawing.Size(39, 13);
			this.loggingFormatLabel.TabIndex = 26;
			this.loggingFormatLabel.Text = "Format";
			// 
			// loggingLocationLabel
			// 
			this.loggingLocationLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.loggingLocationLabel.AutoSize = true;
			this.loggingLocationLabel.Location = new System.Drawing.Point(3, 29);
			this.loggingLocationLabel.Name = "loggingLocationLabel";
			this.loggingLocationLabel.Size = new System.Drawing.Size(48, 13);
			this.loggingLocationLabel.TabIndex = 29;
			this.loggingLocationLabel.Text = "Location";
			this.loggingLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// loggingFormatComboBox
			// 
			this.loggingFormatComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.loggingFormatComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.loggingFormatComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.loggingFormatComboBox.FormattingEnabled = true;
			this.loggingFormatComboBox.Location = new System.Drawing.Point(57, 57);
			this.loggingFormatComboBox.Name = "loggingFormatComboBox";
			this.loggingFormatComboBox.Size = new System.Drawing.Size(126, 21);
			this.loggingFormatComboBox.TabIndex = 27;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel5.AutoSize = true;
			this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel5.ColumnCount = 2;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Controls.Add(this.loggingBrowseButton, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.loggingUpdateButton, 1, 0);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(189, 52);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(134, 31);
			this.tableLayoutPanel5.TabIndex = 45;
			// 
			// loggingBrowseButton
			// 
			this.loggingBrowseButton.AutoSize = true;
			this.loggingBrowseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.loggingBrowseButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.loggingBrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loggingBrowseButton.Location = new System.Drawing.Point(3, 3);
			this.loggingBrowseButton.Name = "loggingBrowseButton";
			this.loggingBrowseButton.Size = new System.Drawing.Size(54, 25);
			this.loggingBrowseButton.TabIndex = 32;
			this.loggingBrowseButton.Text = "Browse";
			this.loggingBrowseButton.UseVisualStyleBackColor = true;
			// 
			// loggingUpdateButton
			// 
			this.loggingUpdateButton.AutoSize = true;
			this.loggingUpdateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.loggingUpdateButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.loggingUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loggingUpdateButton.Location = new System.Drawing.Point(70, 3);
			this.loggingUpdateButton.Name = "loggingUpdateButton";
			this.loggingUpdateButton.Size = new System.Drawing.Size(54, 25);
			this.loggingUpdateButton.TabIndex = 33;
			this.loggingUpdateButton.Text = "Update";
			this.loggingUpdateButton.UseVisualStyleBackColor = true;
			// 
			// discordGroupBox
			// 
			this.discordGroupBox.AutoSize = true;
			this.discordGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.discordGroupBox.Controls.Add(this.tableLayoutPanel4);
			this.discordGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.discordGroupBox.Location = new System.Drawing.Point(347, 130);
			this.discordGroupBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.discordGroupBox.Name = "discordGroupBox";
			this.discordGroupBox.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.discordGroupBox.Size = new System.Drawing.Size(369, 118);
			this.discordGroupBox.TabIndex = 55;
			this.discordGroupBox.TabStop = false;
			this.discordGroupBox.Text = "Discord";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.AutoSize = true;
			this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.Controls.Add(this.discordEnabledCheckBox, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.discordWebhookTextBox, 1, 1);
			this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 2, 2);
			this.tableLayoutPanel4.Controls.Add(this.discordWebhookLabel, 0, 1);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 3;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(357, 86);
			this.tableLayoutPanel4.TabIndex = 44;
			// 
			// discordEnabledCheckBox
			// 
			this.discordEnabledCheckBox.AutoSize = true;
			this.tableLayoutPanel4.SetColumnSpan(this.discordEnabledCheckBox, 2);
			this.discordEnabledCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.discordEnabledCheckBox.Location = new System.Drawing.Point(3, 3);
			this.discordEnabledCheckBox.Name = "discordEnabledCheckBox";
			this.discordEnabledCheckBox.Size = new System.Drawing.Size(285, 17);
			this.discordEnabledCheckBox.TabIndex = 23;
			this.discordEnabledCheckBox.Text = "Enabled";
			this.discordEnabledCheckBox.UseVisualStyleBackColor = true;
			// 
			// discordWebhookTextBox
			// 
			this.discordWebhookTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel4.SetColumnSpan(this.discordWebhookTextBox, 2);
			this.discordWebhookTextBox.Location = new System.Drawing.Point(88, 26);
			this.discordWebhookTextBox.Name = "discordWebhookTextBox";
			this.discordWebhookTextBox.Size = new System.Drawing.Size(266, 20);
			this.discordWebhookTextBox.TabIndex = 28;
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel6.AutoSize = true;
			this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel6.ColumnCount = 1;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel6.Controls.Add(this.discordUpdateButton, 0, 0);
			this.tableLayoutPanel6.Location = new System.Drawing.Point(294, 52);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(60, 31);
			this.tableLayoutPanel6.TabIndex = 45;
			// 
			// discordUpdateButton
			// 
			this.discordUpdateButton.AutoSize = true;
			this.discordUpdateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.discordUpdateButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.discordUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.discordUpdateButton.Location = new System.Drawing.Point(3, 3);
			this.discordUpdateButton.Name = "discordUpdateButton";
			this.discordUpdateButton.Size = new System.Drawing.Size(54, 25);
			this.discordUpdateButton.TabIndex = 33;
			this.discordUpdateButton.Text = "Update";
			this.discordUpdateButton.UseVisualStyleBackColor = true;
			// 
			// discordWebhookLabel
			// 
			this.discordWebhookLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.discordWebhookLabel.AutoSize = true;
			this.discordWebhookLabel.Location = new System.Drawing.Point(3, 29);
			this.discordWebhookLabel.Name = "discordWebhookLabel";
			this.discordWebhookLabel.Size = new System.Drawing.Size(79, 13);
			this.discordWebhookLabel.TabIndex = 29;
			this.discordWebhookLabel.Text = "Webhook URL";
			this.discordWebhookLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "MainView";
			this.Size = new System.Drawing.Size(722, 448);
			this.generalGroupBox.ResumeLayout(false);
			this.generalGroupBox.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.messageLogGroupBox.ResumeLayout(false);
			this.tableLayoutPanel10.ResumeLayout(false);
			this.tableLayoutPanel10.PerformLayout();
			this.filtersGroupBox.ResumeLayout(false);
			this.filtersGroupBox.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.httpGroupBox.ResumeLayout(false);
			this.httpGroupBox.PerformLayout();
			this.tableLayoutPanel7.ResumeLayout(false);
			this.tableLayoutPanel7.PerformLayout();
			this.tableLayoutPanel9.ResumeLayout(false);
			this.tableLayoutPanel9.PerformLayout();
			this.loggingGroupBox.ResumeLayout(false);
			this.loggingGroupBox.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.discordGroupBox.ResumeLayout(false);
			this.discordGroupBox.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel6.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
		private System.Windows.Forms.GroupBox generalGroupBox;
		private System.Windows.Forms.CheckBox generalPluginEnabledCheckBox;
		private System.Windows.Forms.CheckBox generalCheckForBetaVersionsCheckBox;
		private System.Windows.Forms.CheckBox generalLogImportsEnabledCheckBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox messageLogGroupBox;
		private System.Windows.Forms.ListBox messageLogListBox;
		private System.Windows.Forms.CheckBox loggingEnabledCheckBox;
		private System.Windows.Forms.GroupBox loggingGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private CustomButton loggingBrowseButton;
		private CustomButton loggingUpdateButton;
		private CustomTextBox loggingLocationTextBox;
		private System.Windows.Forms.Label loggingLocationLabel;
		private System.Windows.Forms.GroupBox filtersGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.CheckBox filtersExcludeCommonItemsCheckBox;
		private System.Windows.Forms.CheckBox filtersHighEndDutyOnlyCheckBox;
		private System.Windows.Forms.CheckBox filtersAllianceCheckBox;
		private System.Windows.Forms.CheckBox filtersItemObtainedCheckBox;
		private System.Windows.Forms.CheckBox filtersItemAddedCheckBox;
		private System.Windows.Forms.CheckBox filtersItemRolledOnCheckBox;
		private System.Windows.Forms.CheckBox filtersItemCastLotCheckBox;
		private System.Windows.Forms.CheckBox filtersItemLostCheckBox;
		private System.Windows.Forms.CheckBox filtersSelfCheckBox;
		private System.Windows.Forms.CheckBox filtersPartyCheckBox;
		private System.Windows.Forms.Label loggingFormatLabel;
		private CustomComboBox loggingFormatComboBox;
		private System.Windows.Forms.GroupBox discordGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.CheckBox discordEnabledCheckBox;
		private CustomTextBox discordWebhookTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private CustomButton discordUpdateButton;
		private System.Windows.Forms.Label discordWebhookLabel;
		private CustomTextBox httpCustomJsonTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.CheckBox httpEnabledCheckBox;
		private CustomTextBox httpEndpointTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
		private System.Windows.Forms.Label httpEndpointLabel;
		private System.Windows.Forms.Label httpCustomJsonLabel;
		private System.Windows.Forms.GroupBox httpGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private CustomButton httpUpdateButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
		private System.Windows.Forms.CheckBox filtersIncludeMountsOnlyCheckBox;
		private System.Windows.Forms.CheckBox generalGetMarketBoardDataCheckBox;
		private System.Windows.Forms.CheckBox filtersItemSearchedCheckBox;
	}
}
