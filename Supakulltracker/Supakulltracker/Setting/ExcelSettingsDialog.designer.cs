namespace Supakulltracker
{
    partial class ExcelSettingsDialog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_AddNewExcelTemplate = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Settings = new System.Windows.Forms.TabPage();
            this.groupBoxTokens = new System.Windows.Forms.GroupBox();
            this.btnChangeToken = new System.Windows.Forms.Button();
            this.btnAddToken = new System.Windows.Forms.Button();
            this.cmbTokens = new System.Windows.Forms.ComboBox();
            this.btnDeleteToken = new System.Windows.Forms.Button();
            this.grpBox_Connect_setting = new System.Windows.Forms.GroupBox();
            this.btn_cancelMapping = new System.Windows.Forms.Button();
            this.btn_saveMapping = new System.Windows.Forms.Button();
            this.grpBox_template = new System.Windows.Forms.GroupBox();
            this.btn_delete_template = new System.Windows.Forms.Button();
            this.btn_ActivateMappingExcel = new System.Windows.Forms.Button();
            this.comboBox_ExcelTemplate = new System.Windows.Forms.ComboBox();
            this.dataGrid_mapping = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu_template = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_shared = new System.Windows.Forms.GroupBox();
            this.lblSharedAccountError = new System.Windows.Forms.Label();
            this.chboxMakeUserOwner = new System.Windows.Forms.CheckBox();
            this.btnCancelSaveShareAccount = new System.Windows.Forms.Button();
            this.btnSaveSharedAccount = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtShareUserName = new System.Windows.Forms.TextBox();
            this.groupBoxAccounts = new System.Windows.Forms.GroupBox();
            this.label_shared = new System.Windows.Forms.Label();
            this.comboBox_shared = new System.Windows.Forms.ComboBox();
            this.btn_delete_account = new System.Windows.Forms.Button();
            this.btn_share_account = new System.Windows.Forms.Button();
            this.panelNewAccount = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_NameNewAccountExcel = new System.Windows.Forms.TextBox();
            this.btnNewAccountForExcel = new System.Windows.Forms.Button();
            this.btn_activate_account = new System.Windows.Forms.Button();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ExcelTab = new System.Windows.Forms.TabControl();
            this.Mapping = new System.Windows.Forms.TabPage();
            this.flpSaveAccount = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChekMapping = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnCancelSaveNewToken = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panelItemName = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewTemplateName = new System.Windows.Forms.TextBox();
            this.rtxtMapping = new System.Windows.Forms.RichTextBox();
            this.folderBrouseForSync = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSelectFolderForFiles = new System.Windows.Forms.Panel();
            this.Settings.SuspendLayout();
            this.groupBoxTokens.SuspendLayout();
            this.grpBox_Connect_setting.SuspendLayout();
            this.grpBox_template.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_mapping)).BeginInit();
            this.contextMenu_template.SuspendLayout();
            this.groupBox_shared.SuspendLayout();
            this.groupBoxAccounts.SuspendLayout();
            this.panelNewAccount.SuspendLayout();
            this.ExcelTab.SuspendLayout();
            this.Mapping.SuspendLayout();
            this.flpSaveAccount.SuspendLayout();
            this.panelItemName.SuspendLayout();
            this.panelSelectFolderForFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_AddNewExcelTemplate
            // 
            this.btn_AddNewExcelTemplate.Location = new System.Drawing.Point(133, 22);
            this.btn_AddNewExcelTemplate.Name = "btn_AddNewExcelTemplate";
            this.btn_AddNewExcelTemplate.Size = new System.Drawing.Size(75, 23);
            this.btn_AddNewExcelTemplate.TabIndex = 6;
            this.btn_AddNewExcelTemplate.Text = "Add";
            this.btn_AddNewExcelTemplate.UseVisualStyleBackColor = true;
            this.btn_AddNewExcelTemplate.Click += new System.EventHandler(this.btn_AddNewExcelTemplate_Click);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.White;
            this.Settings.Controls.Add(this.panelSelectFolderForFiles);
            this.Settings.Controls.Add(this.groupBoxTokens);
            this.Settings.Controls.Add(this.grpBox_Connect_setting);
            this.Settings.Controls.Add(this.groupBox_shared);
            this.Settings.Controls.Add(this.groupBoxAccounts);
            this.Settings.Controls.Add(this.label10);
            this.Settings.Location = new System.Drawing.Point(4, 22);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(578, 565);
            this.Settings.TabIndex = 0;
            this.Settings.Text = "General";
            // 
            // groupBoxTokens
            // 
            this.groupBoxTokens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTokens.Controls.Add(this.btnChangeToken);
            this.groupBoxTokens.Controls.Add(this.btnAddToken);
            this.groupBoxTokens.Controls.Add(this.cmbTokens);
            this.groupBoxTokens.Controls.Add(this.btnDeleteToken);
            this.groupBoxTokens.Location = new System.Drawing.Point(383, 19);
            this.groupBoxTokens.Name = "groupBoxTokens";
            this.groupBoxTokens.Size = new System.Drawing.Size(176, 185);
            this.groupBoxTokens.TabIndex = 17;
            this.groupBoxTokens.TabStop = false;
            this.groupBoxTokens.Text = "Tokens";
            this.groupBoxTokens.Visible = false;
            // 
            // btnChangeToken
            // 
            this.btnChangeToken.Enabled = false;
            this.btnChangeToken.Location = new System.Drawing.Point(116, 82);
            this.btnChangeToken.Name = "btnChangeToken";
            this.btnChangeToken.Size = new System.Drawing.Size(53, 23);
            this.btnChangeToken.TabIndex = 11;
            this.btnChangeToken.Text = "Change";
            this.btnChangeToken.UseVisualStyleBackColor = true;
            // 
            // btnAddToken
            // 
            this.btnAddToken.Location = new System.Drawing.Point(116, 24);
            this.btnAddToken.Name = "btnAddToken";
            this.btnAddToken.Size = new System.Drawing.Size(53, 23);
            this.btnAddToken.TabIndex = 6;
            this.btnAddToken.Text = "Add";
            this.btnAddToken.UseVisualStyleBackColor = true;
            this.btnAddToken.Click += new System.EventHandler(this.btnAddToken_Click);
            // 
            // cmbTokens
            // 
            this.cmbTokens.AllowDrop = true;
            this.cmbTokens.FormattingEnabled = true;
            this.cmbTokens.Location = new System.Drawing.Point(6, 26);
            this.cmbTokens.Name = "cmbTokens";
            this.cmbTokens.Size = new System.Drawing.Size(104, 21);
            this.cmbTokens.TabIndex = 7;
            this.cmbTokens.SelectedIndexChanged += new System.EventHandler(this.cmbTokens_SelectedIndexChanged);
            this.cmbTokens.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTokens_DragDrop);
            this.cmbTokens.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTokens_DragEnter);
            // 
            // btnDeleteToken
            // 
            this.btnDeleteToken.Location = new System.Drawing.Point(116, 53);
            this.btnDeleteToken.Name = "btnDeleteToken";
            this.btnDeleteToken.Size = new System.Drawing.Size(53, 23);
            this.btnDeleteToken.TabIndex = 10;
            this.btnDeleteToken.Text = "Delete";
            this.btnDeleteToken.UseVisualStyleBackColor = true;
            this.btnDeleteToken.Click += new System.EventHandler(this.btnDeleteToken_Click);
            // 
            // grpBox_Connect_setting
            // 
            this.grpBox_Connect_setting.Controls.Add(this.btn_cancelMapping);
            this.grpBox_Connect_setting.Controls.Add(this.btn_saveMapping);
            this.grpBox_Connect_setting.Controls.Add(this.grpBox_template);
            this.grpBox_Connect_setting.Controls.Add(this.dataGrid_mapping);
            this.grpBox_Connect_setting.Location = new System.Drawing.Point(16, 262);
            this.grpBox_Connect_setting.Name = "grpBox_Connect_setting";
            this.grpBox_Connect_setting.Size = new System.Drawing.Size(556, 297);
            this.grpBox_Connect_setting.TabIndex = 16;
            this.grpBox_Connect_setting.TabStop = false;
            this.grpBox_Connect_setting.Text = "Connections settings";
            this.grpBox_Connect_setting.Visible = false;
            this.grpBox_Connect_setting.VisibleChanged += new System.EventHandler(this.grpBox_Connect_setting_VisibleChanged);
            // 
            // btn_cancelMapping
            // 
            this.btn_cancelMapping.Location = new System.Drawing.Point(463, 260);
            this.btn_cancelMapping.Name = "btn_cancelMapping";
            this.btn_cancelMapping.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelMapping.TabIndex = 26;
            this.btn_cancelMapping.Text = "Cancel";
            this.btn_cancelMapping.UseVisualStyleBackColor = true;
            this.btn_cancelMapping.Click += new System.EventHandler(this.btn_cancelMapping_Click);
            // 
            // btn_saveMapping
            // 
            this.btn_saveMapping.Enabled = false;
            this.btn_saveMapping.Location = new System.Drawing.Point(351, 260);
            this.btn_saveMapping.Name = "btn_saveMapping";
            this.btn_saveMapping.Size = new System.Drawing.Size(106, 23);
            this.btn_saveMapping.TabIndex = 25;
            this.btn_saveMapping.Text = "Save mapping";
            this.btn_saveMapping.UseVisualStyleBackColor = true;
            this.btn_saveMapping.Click += new System.EventHandler(this.btn_saveMapping_Click);
            // 
            // grpBox_template
            // 
            this.grpBox_template.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBox_template.Controls.Add(this.btn_delete_template);
            this.grpBox_template.Controls.Add(this.btn_AddNewExcelTemplate);
            this.grpBox_template.Controls.Add(this.btn_ActivateMappingExcel);
            this.grpBox_template.Controls.Add(this.comboBox_ExcelTemplate);
            this.grpBox_template.Location = new System.Drawing.Point(9, 22);
            this.grpBox_template.Name = "grpBox_template";
            this.grpBox_template.Size = new System.Drawing.Size(215, 196);
            this.grpBox_template.TabIndex = 24;
            this.grpBox_template.TabStop = false;
            this.grpBox_template.Text = "Template";
            // 
            // btn_delete_template
            // 
            this.btn_delete_template.Location = new System.Drawing.Point(133, 51);
            this.btn_delete_template.Name = "btn_delete_template";
            this.btn_delete_template.Size = new System.Drawing.Size(75, 23);
            this.btn_delete_template.TabIndex = 18;
            this.btn_delete_template.Text = "Delete";
            this.btn_delete_template.UseVisualStyleBackColor = true;
            this.btn_delete_template.Click += new System.EventHandler(this.btn_delete_template_Click);
            // 
            // btn_ActivateMappingExcel
            // 
            this.btn_ActivateMappingExcel.Enabled = false;
            this.btn_ActivateMappingExcel.Location = new System.Drawing.Point(134, 80);
            this.btn_ActivateMappingExcel.Name = "btn_ActivateMappingExcel";
            this.btn_ActivateMappingExcel.Size = new System.Drawing.Size(75, 23);
            this.btn_ActivateMappingExcel.TabIndex = 9;
            this.btn_ActivateMappingExcel.Text = "Activate";
            this.btn_ActivateMappingExcel.UseVisualStyleBackColor = true;
            // 
            // comboBox_ExcelTemplate
            // 
            this.comboBox_ExcelTemplate.AllowDrop = true;
            this.comboBox_ExcelTemplate.FormattingEnabled = true;
            this.comboBox_ExcelTemplate.Location = new System.Drawing.Point(6, 24);
            this.comboBox_ExcelTemplate.Name = "comboBox_ExcelTemplate";
            this.comboBox_ExcelTemplate.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ExcelTemplate.TabIndex = 4;
            this.comboBox_ExcelTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBox_ExcelTemplate_SelectedIndexChanged);
            // 
            // dataGrid_mapping
            // 
            this.dataGrid_mapping.AllowDrop = true;
            this.dataGrid_mapping.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_mapping.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid_mapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_mapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGrid_mapping.ContextMenuStrip = this.contextMenu_template;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid_mapping.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid_mapping.Location = new System.Drawing.Point(230, 22);
            this.dataGrid_mapping.Name = "dataGrid_mapping";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_mapping.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid_mapping.RowHeadersVisible = false;
            this.dataGrid_mapping.Size = new System.Drawing.Size(320, 232);
            this.dataGrid_mapping.TabIndex = 23;
            this.dataGrid_mapping.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGrid_mapping_RowsAdded);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "File";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Template";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 150;
            // 
            // contextMenu_template
            // 
            this.contextMenu_template.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearFieldToolStripMenuItem});
            this.contextMenu_template.Name = "contextMenu_template";
            this.contextMenu_template.Size = new System.Drawing.Size(128, 26);
            // 
            // clearFieldToolStripMenuItem
            // 
            this.clearFieldToolStripMenuItem.Name = "clearFieldToolStripMenuItem";
            this.clearFieldToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.clearFieldToolStripMenuItem.Text = "Clear field";
            this.clearFieldToolStripMenuItem.Click += new System.EventHandler(this.clearFieldToolStripMenuItem_Click);
            // 
            // groupBox_shared
            // 
            this.groupBox_shared.Controls.Add(this.lblSharedAccountError);
            this.groupBox_shared.Controls.Add(this.chboxMakeUserOwner);
            this.groupBox_shared.Controls.Add(this.btnCancelSaveShareAccount);
            this.groupBox_shared.Controls.Add(this.btnSaveSharedAccount);
            this.groupBox_shared.Controls.Add(this.label14);
            this.groupBox_shared.Controls.Add(this.txtShareUserName);
            this.groupBox_shared.Location = new System.Drawing.Point(217, 19);
            this.groupBox_shared.Name = "groupBox_shared";
            this.groupBox_shared.Size = new System.Drawing.Size(160, 185);
            this.groupBox_shared.TabIndex = 15;
            this.groupBox_shared.TabStop = false;
            this.groupBox_shared.Text = "Shared user";
            this.groupBox_shared.Visible = false;
            // 
            // lblSharedAccountError
            // 
            this.lblSharedAccountError.AutoSize = true;
            this.lblSharedAccountError.Location = new System.Drawing.Point(48, 149);
            this.lblSharedAccountError.Name = "lblSharedAccountError";
            this.lblSharedAccountError.Size = new System.Drawing.Size(0, 13);
            this.lblSharedAccountError.TabIndex = 11;
            // 
            // chboxMakeUserOwner
            // 
            this.chboxMakeUserOwner.AutoSize = true;
            this.chboxMakeUserOwner.Location = new System.Drawing.Point(20, 77);
            this.chboxMakeUserOwner.Name = "chboxMakeUserOwner";
            this.chboxMakeUserOwner.Size = new System.Drawing.Size(99, 17);
            this.chboxMakeUserOwner.TabIndex = 10;
            this.chboxMakeUserOwner.Text = "Permit changes";
            this.chboxMakeUserOwner.UseVisualStyleBackColor = true;
            // 
            // btnCancelSaveShareAccount
            // 
            this.btnCancelSaveShareAccount.Location = new System.Drawing.Point(77, 107);
            this.btnCancelSaveShareAccount.Name = "btnCancelSaveShareAccount";
            this.btnCancelSaveShareAccount.Size = new System.Drawing.Size(75, 25);
            this.btnCancelSaveShareAccount.TabIndex = 9;
            this.btnCancelSaveShareAccount.Text = "Cancel";
            this.btnCancelSaveShareAccount.UseVisualStyleBackColor = true;
            this.btnCancelSaveShareAccount.Click += new System.EventHandler(this.btnCancelSaveShareAccount_Click);
            // 
            // btnSaveSharedAccount
            // 
            this.btnSaveSharedAccount.Location = new System.Drawing.Point(7, 107);
            this.btnSaveSharedAccount.Name = "btnSaveSharedAccount";
            this.btnSaveSharedAccount.Size = new System.Drawing.Size(62, 25);
            this.btnSaveSharedAccount.TabIndex = 8;
            this.btnSaveSharedAccount.Text = "Save";
            this.btnSaveSharedAccount.UseVisualStyleBackColor = true;
            this.btnSaveSharedAccount.Click += new System.EventHandler(this.btnSaveSharedAccount_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Enter User name:";
            // 
            // txtShareUserName
            // 
            this.txtShareUserName.Location = new System.Drawing.Point(7, 51);
            this.txtShareUserName.Name = "txtShareUserName";
            this.txtShareUserName.Size = new System.Drawing.Size(145, 20);
            this.txtShareUserName.TabIndex = 6;
            // 
            // groupBoxAccounts
            // 
            this.groupBoxAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxAccounts.Controls.Add(this.label_shared);
            this.groupBoxAccounts.Controls.Add(this.comboBox_shared);
            this.groupBoxAccounts.Controls.Add(this.btn_delete_account);
            this.groupBoxAccounts.Controls.Add(this.btn_share_account);
            this.groupBoxAccounts.Controls.Add(this.panelNewAccount);
            this.groupBoxAccounts.Controls.Add(this.btnNewAccountForExcel);
            this.groupBoxAccounts.Controls.Add(this.btn_activate_account);
            this.groupBoxAccounts.Controls.Add(this.cmbAccounts);
            this.groupBoxAccounts.Location = new System.Drawing.Point(6, 19);
            this.groupBoxAccounts.Name = "groupBoxAccounts";
            this.groupBoxAccounts.Size = new System.Drawing.Size(205, 237);
            this.groupBoxAccounts.TabIndex = 14;
            this.groupBoxAccounts.TabStop = false;
            this.groupBoxAccounts.Text = "Accounts";
            // 
            // label_shared
            // 
            this.label_shared.AutoSize = true;
            this.label_shared.Location = new System.Drawing.Point(6, 65);
            this.label_shared.Name = "label_shared";
            this.label_shared.Size = new System.Drawing.Size(84, 13);
            this.label_shared.TabIndex = 19;
            this.label_shared.Text = "Shared Account";
            this.label_shared.Visible = false;
            // 
            // comboBox_shared
            // 
            this.comboBox_shared.FormattingEnabled = true;
            this.comboBox_shared.Location = new System.Drawing.Point(6, 83);
            this.comboBox_shared.Name = "comboBox_shared";
            this.comboBox_shared.Size = new System.Drawing.Size(130, 21);
            this.comboBox_shared.TabIndex = 18;
            this.comboBox_shared.Visible = false;
            this.comboBox_shared.SelectedIndexChanged += new System.EventHandler(this.comboBox_shared_SelectedIndexChanged);
            // 
            // btn_delete_account
            // 
            this.btn_delete_account.Enabled = false;
            this.btn_delete_account.Location = new System.Drawing.Point(142, 52);
            this.btn_delete_account.Name = "btn_delete_account";
            this.btn_delete_account.Size = new System.Drawing.Size(58, 23);
            this.btn_delete_account.TabIndex = 17;
            this.btn_delete_account.Text = "Delete";
            this.btn_delete_account.UseVisualStyleBackColor = true;
            this.btn_delete_account.Click += new System.EventHandler(this.btn_delete_account_Click);
            // 
            // btn_share_account
            // 
            this.btn_share_account.Enabled = false;
            this.btn_share_account.Location = new System.Drawing.Point(142, 81);
            this.btn_share_account.Name = "btn_share_account";
            this.btn_share_account.Size = new System.Drawing.Size(58, 23);
            this.btn_share_account.TabIndex = 16;
            this.btn_share_account.Text = "Share";
            this.btn_share_account.UseVisualStyleBackColor = true;
            this.btn_share_account.Click += new System.EventHandler(this.btn_share_account_Click);
            // 
            // panelNewAccount
            // 
            this.panelNewAccount.Controls.Add(this.btn_cancel);
            this.panelNewAccount.Controls.Add(this.btn_ok);
            this.panelNewAccount.Controls.Add(this.label1);
            this.panelNewAccount.Controls.Add(this.textBox_NameNewAccountExcel);
            this.panelNewAccount.Location = new System.Drawing.Point(6, 142);
            this.panelNewAccount.Name = "panelNewAccount";
            this.panelNewAccount.Size = new System.Drawing.Size(186, 88);
            this.panelNewAccount.TabIndex = 15;
            this.panelNewAccount.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(90, 53);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(86, 26);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(11, 53);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(73, 26);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Please enter New account name";
            // 
            // textBox_NameNewAccountExcel
            // 
            this.textBox_NameNewAccountExcel.Location = new System.Drawing.Point(11, 27);
            this.textBox_NameNewAccountExcel.Name = "textBox_NameNewAccountExcel";
            this.textBox_NameNewAccountExcel.Size = new System.Drawing.Size(168, 20);
            this.textBox_NameNewAccountExcel.TabIndex = 11;
            // 
            // btnNewAccountForExcel
            // 
            this.btnNewAccountForExcel.Location = new System.Drawing.Point(142, 20);
            this.btnNewAccountForExcel.Name = "btnNewAccountForExcel";
            this.btnNewAccountForExcel.Size = new System.Drawing.Size(58, 26);
            this.btnNewAccountForExcel.TabIndex = 6;
            this.btnNewAccountForExcel.Text = "Add";
            this.btnNewAccountForExcel.UseVisualStyleBackColor = true;
            this.btnNewAccountForExcel.Click += new System.EventHandler(this.btnNewAccountForExcel_Click);
            // 
            // btn_activate_account
            // 
            this.btn_activate_account.Enabled = false;
            this.btn_activate_account.Location = new System.Drawing.Point(142, 110);
            this.btn_activate_account.Name = "btn_activate_account";
            this.btn_activate_account.Size = new System.Drawing.Size(58, 26);
            this.btn_activate_account.TabIndex = 9;
            this.btn_activate_account.Text = "Activate";
            this.btn_activate_account.UseVisualStyleBackColor = true;
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(6, 24);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(130, 21);
            this.cmbAccounts.TabIndex = 4;
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(341, 467);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 13;
            // 
            // ExcelTab
            // 
            this.ExcelTab.Controls.Add(this.Settings);
            this.ExcelTab.Controls.Add(this.Mapping);
            this.ExcelTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExcelTab.Location = new System.Drawing.Point(0, 0);
            this.ExcelTab.Name = "ExcelTab";
            this.ExcelTab.SelectedIndex = 0;
            this.ExcelTab.Size = new System.Drawing.Size(586, 591);
            this.ExcelTab.TabIndex = 4;
            // 
            // Mapping
            // 
            this.Mapping.Controls.Add(this.flpSaveAccount);
            this.Mapping.Controls.Add(this.label5);
            this.Mapping.Controls.Add(this.panelItemName);
            this.Mapping.Controls.Add(this.rtxtMapping);
            this.Mapping.Location = new System.Drawing.Point(4, 22);
            this.Mapping.Name = "Mapping";
            this.Mapping.Padding = new System.Windows.Forms.Padding(3);
            this.Mapping.Size = new System.Drawing.Size(578, 565);
            this.Mapping.TabIndex = 1;
            this.Mapping.Text = "Mapping";
            this.Mapping.UseVisualStyleBackColor = true;
            // 
            // flpSaveAccount
            // 
            this.flpSaveAccount.Controls.Add(this.btnChekMapping);
            this.flpSaveAccount.Controls.Add(this.btnSaveSettings);
            this.flpSaveAccount.Controls.Add(this.btnCancelSaveNewToken);
            this.flpSaveAccount.Location = new System.Drawing.Point(269, 64);
            this.flpSaveAccount.Name = "flpSaveAccount";
            this.flpSaveAccount.Size = new System.Drawing.Size(245, 30);
            this.flpSaveAccount.TabIndex = 12;
            // 
            // btnChekMapping
            // 
            this.btnChekMapping.Enabled = false;
            this.btnChekMapping.Location = new System.Drawing.Point(3, 3);
            this.btnChekMapping.Name = "btnChekMapping";
            this.btnChekMapping.Size = new System.Drawing.Size(75, 23);
            this.btnChekMapping.TabIndex = 2;
            this.btnChekMapping.Text = "Test";
            this.btnChekMapping.UseVisualStyleBackColor = true;
            this.btnChekMapping.Click += new System.EventHandler(this.btnChekMapping_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(84, 3);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(76, 23);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCancelSaveNewToken
            // 
            this.btnCancelSaveNewToken.Location = new System.Drawing.Point(166, 3);
            this.btnCancelSaveNewToken.Name = "btnCancelSaveNewToken";
            this.btnCancelSaveNewToken.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSaveNewToken.TabIndex = 3;
            this.btnCancelSaveNewToken.Text = "Cancel";
            this.btnCancelSaveNewToken.UseVisualStyleBackColor = true;
            this.btnCancelSaveNewToken.Click += new System.EventHandler(this.btnCancelSaveNewToken_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 11;
            // 
            // panelItemName
            // 
            this.panelItemName.Controls.Add(this.label3);
            this.panelItemName.Controls.Add(this.txtNewTemplateName);
            this.panelItemName.Location = new System.Drawing.Point(28, 51);
            this.panelItemName.Name = "panelItemName";
            this.panelItemName.Size = new System.Drawing.Size(194, 57);
            this.panelItemName.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name new template: ";
            // 
            // txtNewTemplateName
            // 
            this.txtNewTemplateName.Location = new System.Drawing.Point(16, 26);
            this.txtNewTemplateName.Name = "txtNewTemplateName";
            this.txtNewTemplateName.Size = new System.Drawing.Size(163, 20);
            this.txtNewTemplateName.TabIndex = 3;
            // 
            // rtxtMapping
            // 
            this.rtxtMapping.Location = new System.Drawing.Point(28, 114);
            this.rtxtMapping.Name = "rtxtMapping";
            this.rtxtMapping.Size = new System.Drawing.Size(523, 428);
            this.rtxtMapping.TabIndex = 9;
            this.rtxtMapping.Text = "";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(120, 4);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(34, 26);
            this.btnSelectFolder.TabIndex = 18;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Select Folder For Files";
            // 
            // panelSelectFolderForFiles
            // 
            this.panelSelectFolderForFiles.Controls.Add(this.btnSelectFolder);
            this.panelSelectFolderForFiles.Controls.Add(this.label2);
            this.panelSelectFolderForFiles.Location = new System.Drawing.Point(409, 223);
            this.panelSelectFolderForFiles.Name = "panelSelectFolderForFiles";
            this.panelSelectFolderForFiles.Size = new System.Drawing.Size(157, 33);
            this.panelSelectFolderForFiles.TabIndex = 20;
            this.panelSelectFolderForFiles.Visible = false;
            // 
            // ExcelSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExcelTab);
            this.Name = "ExcelSettingsDialog";
            this.Size = new System.Drawing.Size(586, 591);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.groupBoxTokens.ResumeLayout(false);
            this.grpBox_Connect_setting.ResumeLayout(false);
            this.grpBox_template.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_mapping)).EndInit();
            this.contextMenu_template.ResumeLayout(false);
            this.groupBox_shared.ResumeLayout(false);
            this.groupBox_shared.PerformLayout();
            this.groupBoxAccounts.ResumeLayout(false);
            this.groupBoxAccounts.PerformLayout();
            this.panelNewAccount.ResumeLayout(false);
            this.panelNewAccount.PerformLayout();
            this.ExcelTab.ResumeLayout(false);
            this.Mapping.ResumeLayout(false);
            this.Mapping.PerformLayout();
            this.flpSaveAccount.ResumeLayout(false);
            this.panelItemName.ResumeLayout(false);
            this.panelItemName.PerformLayout();
            this.panelSelectFolderForFiles.ResumeLayout(false);
            this.panelSelectFolderForFiles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.GroupBox grpBox_Connect_setting;
        private System.Windows.Forms.GroupBox grpBox_template;
        private System.Windows.Forms.Button btn_AddNewExcelTemplate;
        private System.Windows.Forms.Button btn_ActivateMappingExcel;
        private System.Windows.Forms.ComboBox comboBox_ExcelTemplate;
        private System.Windows.Forms.DataGridView dataGrid_mapping;
        private System.Windows.Forms.GroupBox groupBox_shared;
        private System.Windows.Forms.Label lblSharedAccountError;
        private System.Windows.Forms.CheckBox chboxMakeUserOwner;
        private System.Windows.Forms.Button btnCancelSaveShareAccount;
        private System.Windows.Forms.Button btnSaveSharedAccount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtShareUserName;
        private System.Windows.Forms.GroupBox groupBoxAccounts;
        private System.Windows.Forms.Label label_shared;
        private System.Windows.Forms.ComboBox comboBox_shared;
        private System.Windows.Forms.Button btn_delete_account;
        private System.Windows.Forms.Button btn_share_account;
        private System.Windows.Forms.Panel panelNewAccount;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_NameNewAccountExcel;
        private System.Windows.Forms.Button btnNewAccountForExcel;
        private System.Windows.Forms.Button btn_activate_account;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl ExcelTab;
        private System.Windows.Forms.Button btn_delete_template;
        private System.Windows.Forms.Button btn_cancelMapping;
        private System.Windows.Forms.Button btn_saveMapping;
        private System.Windows.Forms.GroupBox groupBoxTokens;
        private System.Windows.Forms.Button btnChangeToken;
        private System.Windows.Forms.Button btnAddToken;
        private System.Windows.Forms.ComboBox cmbTokens;
        private System.Windows.Forms.Button btnDeleteToken;
        private System.Windows.Forms.TabPage Mapping;
        private System.Windows.Forms.FlowLayoutPanel flpSaveAccount;
        private System.Windows.Forms.Button btnChekMapping;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnCancelSaveNewToken;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewTemplateName;
        private System.Windows.Forms.RichTextBox rtxtMapping;
        private System.Windows.Forms.ContextMenuStrip contextMenu_template;
        private System.Windows.Forms.ToolStripMenuItem clearFieldToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;

        private System.Windows.Forms.Panel panelSelectFolderForFiles;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrouseForSync;
    }
}
