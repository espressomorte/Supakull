namespace Supakulltracker
{
    partial class TrelloSettingDialog
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
            this.trelloTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.shearingGroupBox = new System.Windows.Forms.GroupBox();
            this.labelSharedAccountError = new System.Windows.Forms.Label();
            this.makeUserOwnerCheckBox = new System.Windows.Forms.CheckBox();
            this.btnCancelSaveShareAccount = new System.Windows.Forms.Button();
            this.saveSharedAccountButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.shareUserNameBox = new System.Windows.Forms.TextBox();
            this.informationGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.infTrelloUserToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.infTokenDateCreation = new System.Windows.Forms.TextBox();
            this.infTokenName = new System.Windows.Forms.TextBox();
            this.addingAccountGB = new System.Windows.Forms.GroupBox();
            this.AccountDetailsGB = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.accountNameBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.trelloBoardsCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accountSaveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.urlTrello = new System.Windows.Forms.LinkLabel();
            this.checkingAccount = new System.Windows.Forms.Button();
            this.tokenCheckingBox = new System.Windows.Forms.TextBox();
            this.trelloTokenGroup = new System.Windows.Forms.GroupBox();
            this.trelloToken = new System.Windows.Forms.ComboBox();
            this.addingTrelloToken = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addTrelloAccountButton = new System.Windows.Forms.Button();
            this.shareAccountButton = new System.Windows.Forms.Button();
            this.addingAccount = new System.Windows.Forms.GroupBox();
            this.AddAcountTrello = new System.Windows.Forms.Button();
            this.sharedLabel = new System.Windows.Forms.Label();
            this.sharedTrelloAccountsBox = new System.Windows.Forms.ComboBox();
            this.activeTrelloAccounts = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.minimalTimeForUpdate = new System.Windows.Forms.NumericUpDown();
            this.infBoardIdTB = new System.Windows.Forms.TextBox();
            this.trelloTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.shearingGroupBox.SuspendLayout();
            this.informationGroupBox.SuspendLayout();
            this.addingAccountGB.SuspendLayout();
            this.AccountDetailsGB.SuspendLayout();
            this.trelloTokenGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.addingAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimalTimeForUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // trelloTab
            // 
            this.trelloTab.Controls.Add(this.tabPage1);
            this.trelloTab.Controls.Add(this.tabPage2);
            this.trelloTab.Location = new System.Drawing.Point(3, 3);
            this.trelloTab.Name = "trelloTab";
            this.trelloTab.SelectedIndex = 0;
            this.trelloTab.Size = new System.Drawing.Size(526, 458);
            this.trelloTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.shearingGroupBox);
            this.tabPage1.Controls.Add(this.informationGroupBox);
            this.tabPage1.Controls.Add(this.addingAccountGB);
            this.tabPage1.Controls.Add(this.trelloTokenGroup);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(518, 432);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // shearingGroupBox
            // 
            this.shearingGroupBox.Controls.Add(this.labelSharedAccountError);
            this.shearingGroupBox.Controls.Add(this.makeUserOwnerCheckBox);
            this.shearingGroupBox.Controls.Add(this.btnCancelSaveShareAccount);
            this.shearingGroupBox.Controls.Add(this.saveSharedAccountButton);
            this.shearingGroupBox.Controls.Add(this.label14);
            this.shearingGroupBox.Controls.Add(this.shareUserNameBox);
            this.shearingGroupBox.Location = new System.Drawing.Point(289, 67);
            this.shearingGroupBox.Name = "shearingGroupBox";
            this.shearingGroupBox.Size = new System.Drawing.Size(202, 114);
            this.shearingGroupBox.TabIndex = 5;
            this.shearingGroupBox.TabStop = false;
            this.shearingGroupBox.Text = "Shearing";
            this.shearingGroupBox.Visible = false;
            // 
            // labelSharedAccountError
            // 
            this.labelSharedAccountError.AutoSize = true;
            this.labelSharedAccountError.ForeColor = System.Drawing.Color.Red;
            this.labelSharedAccountError.Location = new System.Drawing.Point(58, 71);
            this.labelSharedAccountError.Name = "labelSharedAccountError";
            this.labelSharedAccountError.Size = new System.Drawing.Size(76, 13);
            this.labelSharedAccountError.TabIndex = 11;
            this.labelSharedAccountError.Text = "Please try later";
            this.labelSharedAccountError.Visible = false;
            // 
            // makeUserOwnerCheckBox
            // 
            this.makeUserOwnerCheckBox.AutoSize = true;
            this.makeUserOwnerCheckBox.Location = new System.Drawing.Point(45, 52);
            this.makeUserOwnerCheckBox.Name = "makeUserOwnerCheckBox";
            this.makeUserOwnerCheckBox.Size = new System.Drawing.Size(99, 17);
            this.makeUserOwnerCheckBox.TabIndex = 10;
            this.makeUserOwnerCheckBox.Text = "Permit changes";
            this.makeUserOwnerCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnCancelSaveShareAccount
            // 
            this.btnCancelSaveShareAccount.Location = new System.Drawing.Point(111, 85);
            this.btnCancelSaveShareAccount.Name = "btnCancelSaveShareAccount";
            this.btnCancelSaveShareAccount.Size = new System.Drawing.Size(53, 23);
            this.btnCancelSaveShareAccount.TabIndex = 9;
            this.btnCancelSaveShareAccount.Text = "Cancel";
            this.btnCancelSaveShareAccount.UseVisualStyleBackColor = true;
            this.btnCancelSaveShareAccount.Click += new System.EventHandler(this.btnCancelSaveShareAccount_Click);
            // 
            // saveSharedAccountButton
            // 
            this.saveSharedAccountButton.Location = new System.Drawing.Point(19, 85);
            this.saveSharedAccountButton.Name = "saveSharedAccountButton";
            this.saveSharedAccountButton.Size = new System.Drawing.Size(53, 23);
            this.saveSharedAccountButton.TabIndex = 8;
            this.saveSharedAccountButton.Text = "Save";
            this.saveSharedAccountButton.UseVisualStyleBackColor = true;
            this.saveSharedAccountButton.Click += new System.EventHandler(this.saveSharedAccountButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(58, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Enter User name";
            // 
            // shareUserNameBox
            // 
            this.shareUserNameBox.Location = new System.Drawing.Point(42, 32);
            this.shareUserNameBox.Name = "shareUserNameBox";
            this.shareUserNameBox.Size = new System.Drawing.Size(125, 20);
            this.shareUserNameBox.TabIndex = 6;
            // 
            // informationGroupBox
            // 
            this.informationGroupBox.Controls.Add(this.infBoardIdTB);
            this.informationGroupBox.Controls.Add(this.label4);
            this.informationGroupBox.Controls.Add(this.infTrelloUserToken);
            this.informationGroupBox.Controls.Add(this.label3);
            this.informationGroupBox.Controls.Add(this.label2);
            this.informationGroupBox.Controls.Add(this.infTokenDateCreation);
            this.informationGroupBox.Controls.Add(this.infTokenName);
            this.informationGroupBox.Location = new System.Drawing.Point(9, 330);
            this.informationGroupBox.Name = "informationGroupBox";
            this.informationGroupBox.Size = new System.Drawing.Size(481, 93);
            this.informationGroupBox.TabIndex = 4;
            this.informationGroupBox.TabStop = false;
            this.informationGroupBox.Text = "Information About Token";
            this.informationGroupBox.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Trello User Token";
            // 
            // infTrelloUserToken
            // 
            this.infTrelloUserToken.Location = new System.Drawing.Point(99, 67);
            this.infTrelloUserToken.Name = "infTrelloUserToken";
            this.infTrelloUserToken.ReadOnly = true;
            this.infTrelloUserToken.Size = new System.Drawing.Size(367, 20);
            this.infTrelloUserToken.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Token Date Creation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TokenName";
            // 
            // infTokenDateCreation
            // 
            this.infTokenDateCreation.Location = new System.Drawing.Point(134, 41);
            this.infTokenDateCreation.Name = "infTokenDateCreation";
            this.infTokenDateCreation.ReadOnly = true;
            this.infTokenDateCreation.Size = new System.Drawing.Size(136, 20);
            this.infTokenDateCreation.TabIndex = 1;
            // 
            // infTokenName
            // 
            this.infTokenName.Location = new System.Drawing.Point(9, 41);
            this.infTokenName.Name = "infTokenName";
            this.infTokenName.ReadOnly = true;
            this.infTokenName.Size = new System.Drawing.Size(115, 20);
            this.infTokenName.TabIndex = 0;
            // 
            // addingAccountGB
            // 
            this.addingAccountGB.Controls.Add(this.AccountDetailsGB);
            this.addingAccountGB.Controls.Add(this.label5);
            this.addingAccountGB.Controls.Add(this.urlTrello);
            this.addingAccountGB.Controls.Add(this.checkingAccount);
            this.addingAccountGB.Controls.Add(this.tokenCheckingBox);
            this.addingAccountGB.Location = new System.Drawing.Point(9, 187);
            this.addingAccountGB.Name = "addingAccountGB";
            this.addingAccountGB.Size = new System.Drawing.Size(482, 137);
            this.addingAccountGB.TabIndex = 3;
            this.addingAccountGB.TabStop = false;
            this.addingAccountGB.Text = "AddingAccount";
            this.addingAccountGB.Visible = false;
            // 
            // AccountDetailsGB
            // 
            this.AccountDetailsGB.Controls.Add(this.minimalTimeForUpdate);
            this.AccountDetailsGB.Controls.Add(this.label7);
            this.AccountDetailsGB.Controls.Add(this.accountNameBox);
            this.AccountDetailsGB.Controls.Add(this.label6);
            this.AccountDetailsGB.Controls.Add(this.trelloBoardsCB);
            this.AccountDetailsGB.Controls.Add(this.label1);
            this.AccountDetailsGB.Controls.Add(this.accountSaveButton);
            this.AccountDetailsGB.Location = new System.Drawing.Point(6, 58);
            this.AccountDetailsGB.Name = "AccountDetailsGB";
            this.AccountDetailsGB.Size = new System.Drawing.Size(471, 79);
            this.AccountDetailsGB.TabIndex = 12;
            this.AccountDetailsGB.TabStop = false;
            this.AccountDetailsGB.Text = "Account Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Enter minimal time for update";
            // 
            // accountNameBox
            // 
            this.accountNameBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.accountNameBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.accountNameBox.Location = new System.Drawing.Point(216, 13);
            this.accountNameBox.Name = "accountNameBox";
            this.accountNameBox.Size = new System.Drawing.Size(161, 20);
            this.accountNameBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Choose your Board";
            // 
            // trelloBoardsCB
            // 
            this.trelloBoardsCB.FormattingEnabled = true;
            this.trelloBoardsCB.Location = new System.Drawing.Point(216, 34);
            this.trelloBoardsCB.Name = "trelloBoardsCB";
            this.trelloBoardsCB.Size = new System.Drawing.Size(161, 21);
            this.trelloBoardsCB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Token is correct,Enter your account name";
            // 
            // accountSaveButton
            // 
            this.accountSaveButton.Location = new System.Drawing.Point(387, 25);
            this.accountSaveButton.Name = "accountSaveButton";
            this.accountSaveButton.Size = new System.Drawing.Size(73, 36);
            this.accountSaveButton.TabIndex = 2;
            this.accountSaveButton.Text = "Save";
            this.accountSaveButton.UseVisualStyleBackColor = true;
            this.accountSaveButton.Click += new System.EventHandler(this.tokenSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Please click on link. and enter Your userToken here";
            // 
            // urlTrello
            // 
            this.urlTrello.AutoSize = true;
            this.urlTrello.Location = new System.Drawing.Point(9, 16);
            this.urlTrello.Name = "urlTrello";
            this.urlTrello.Size = new System.Drawing.Size(81, 13);
            this.urlTrello.TabIndex = 4;
            this.urlTrello.TabStop = true;
            this.urlTrello.Text = "TrelloAccessUrl";
            this.urlTrello.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlTrello_LinkClicked);
            // 
            // checkingAccount
            // 
            this.checkingAccount.Location = new System.Drawing.Point(403, 16);
            this.checkingAccount.Name = "checkingAccount";
            this.checkingAccount.Size = new System.Drawing.Size(73, 36);
            this.checkingAccount.TabIndex = 1;
            this.checkingAccount.Text = "Check";
            this.checkingAccount.UseVisualStyleBackColor = true;
            this.checkingAccount.Click += new System.EventHandler(this.checkingAccount_Click);
            // 
            // tokenCheckingBox
            // 
            this.tokenCheckingBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tokenCheckingBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tokenCheckingBox.Location = new System.Drawing.Point(5, 34);
            this.tokenCheckingBox.Name = "tokenCheckingBox";
            this.tokenCheckingBox.Size = new System.Drawing.Size(392, 20);
            this.tokenCheckingBox.TabIndex = 0;
            // 
            // trelloTokenGroup
            // 
            this.trelloTokenGroup.Controls.Add(this.trelloToken);
            this.trelloTokenGroup.Controls.Add(this.addingTrelloToken);
            this.trelloTokenGroup.Location = new System.Drawing.Point(289, 10);
            this.trelloTokenGroup.Name = "trelloTokenGroup";
            this.trelloTokenGroup.Size = new System.Drawing.Size(203, 51);
            this.trelloTokenGroup.TabIndex = 2;
            this.trelloTokenGroup.TabStop = false;
            this.trelloTokenGroup.Text = "Tokens";
            // 
            // trelloToken
            // 
            this.trelloToken.Enabled = false;
            this.trelloToken.FormattingEnabled = true;
            this.trelloToken.Location = new System.Drawing.Point(6, 17);
            this.trelloToken.Name = "trelloToken";
            this.trelloToken.Size = new System.Drawing.Size(110, 21);
            this.trelloToken.TabIndex = 0;
            this.trelloToken.SelectedIndexChanged += new System.EventHandler(this.trelloToken_SelectedIndexChanged);
            // 
            // addingTrelloToken
            // 
            this.addingTrelloToken.Enabled = false;
            this.addingTrelloToken.Location = new System.Drawing.Point(124, 15);
            this.addingTrelloToken.Name = "addingTrelloToken";
            this.addingTrelloToken.Size = new System.Drawing.Size(73, 22);
            this.addingTrelloToken.TabIndex = 3;
            this.addingTrelloToken.Text = "Add";
            this.addingTrelloToken.UseVisualStyleBackColor = true;
            this.addingTrelloToken.Click += new System.EventHandler(this.addingTrelloToken_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addTrelloAccountButton);
            this.groupBox1.Controls.Add(this.shareAccountButton);
            this.groupBox1.Controls.Add(this.addingAccount);
            this.groupBox1.Controls.Add(this.sharedLabel);
            this.groupBox1.Controls.Add(this.sharedTrelloAccountsBox);
            this.groupBox1.Controls.Add(this.activeTrelloAccounts);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 171);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ActiveAccounts";
            // 
            // addTrelloAccountButton
            // 
            this.addTrelloAccountButton.Location = new System.Drawing.Point(134, 18);
            this.addTrelloAccountButton.Name = "addTrelloAccountButton";
            this.addTrelloAccountButton.Size = new System.Drawing.Size(73, 22);
            this.addTrelloAccountButton.TabIndex = 2;
            this.addTrelloAccountButton.Text = "Add";
            this.addTrelloAccountButton.UseVisualStyleBackColor = true;
            this.addTrelloAccountButton.Click += new System.EventHandler(this.addTrelloAccountButton_Click);
            // 
            // shareAccountButton
            // 
            this.shareAccountButton.Location = new System.Drawing.Point(134, 43);
            this.shareAccountButton.Name = "shareAccountButton";
            this.shareAccountButton.Size = new System.Drawing.Size(73, 22);
            this.shareAccountButton.TabIndex = 18;
            this.shareAccountButton.Text = "Share";
            this.shareAccountButton.UseVisualStyleBackColor = true;
            this.shareAccountButton.Click += new System.EventHandler(this.shareAccountButton_Click);
            // 
            // addingAccount
            // 
            this.addingAccount.Controls.Add(this.AddAcountTrello);
            this.addingAccount.Enabled = false;
            this.addingAccount.Location = new System.Drawing.Point(5, 109);
            this.addingAccount.Name = "addingAccount";
            this.addingAccount.Size = new System.Drawing.Size(202, 48);
            this.addingAccount.TabIndex = 5;
            this.addingAccount.TabStop = false;
            this.addingAccount.Text = "AddingAccount";
            this.addingAccount.Visible = false;
            // 
            // AddAcountTrello
            // 
            this.AddAcountTrello.Location = new System.Drawing.Point(94, 19);
            this.AddAcountTrello.Name = "AddAcountTrello";
            this.AddAcountTrello.Size = new System.Drawing.Size(73, 21);
            this.AddAcountTrello.TabIndex = 1;
            this.AddAcountTrello.Text = "Add";
            this.AddAcountTrello.UseVisualStyleBackColor = true;
            this.AddAcountTrello.Click += new System.EventHandler(this.AddAcountTrello_Click);
            // 
            // sharedLabel
            // 
            this.sharedLabel.AutoSize = true;
            this.sharedLabel.Location = new System.Drawing.Point(9, 64);
            this.sharedLabel.Name = "sharedLabel";
            this.sharedLabel.Size = new System.Drawing.Size(84, 13);
            this.sharedLabel.TabIndex = 17;
            this.sharedLabel.Text = "Shared Account";
            this.sharedLabel.Visible = false;
            // 
            // sharedTrelloAccountsBox
            // 
            this.sharedTrelloAccountsBox.FormattingEnabled = true;
            this.sharedTrelloAccountsBox.Location = new System.Drawing.Point(5, 80);
            this.sharedTrelloAccountsBox.Name = "sharedTrelloAccountsBox";
            this.sharedTrelloAccountsBox.Size = new System.Drawing.Size(122, 21);
            this.sharedTrelloAccountsBox.TabIndex = 3;
            // 
            // activeTrelloAccounts
            // 
            this.activeTrelloAccounts.FormattingEnabled = true;
            this.activeTrelloAccounts.Location = new System.Drawing.Point(5, 19);
            this.activeTrelloAccounts.Name = "activeTrelloAccounts";
            this.activeTrelloAccounts.Size = new System.Drawing.Size(122, 21);
            this.activeTrelloAccounts.TabIndex = 0;
            this.activeTrelloAccounts.SelectedIndexChanged += new System.EventHandler(this.activeTrelloAccounts_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(518, 432);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Usage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // minimalTimeForUpdate
            // 
            this.minimalTimeForUpdate.Location = new System.Drawing.Point(216, 53);
            this.minimalTimeForUpdate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.minimalTimeForUpdate.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.minimalTimeForUpdate.Name = "minimalTimeForUpdate";
            this.minimalTimeForUpdate.Size = new System.Drawing.Size(161, 20);
            this.minimalTimeForUpdate.TabIndex = 12;
            this.minimalTimeForUpdate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // infBoardIdTB
            // 
            this.infBoardIdTB.Location = new System.Drawing.Point(280, 41);
            this.infBoardIdTB.Name = "infBoardIdTB";
            this.infBoardIdTB.ReadOnly = true;
            this.infBoardIdTB.Size = new System.Drawing.Size(136, 20);
            this.infBoardIdTB.TabIndex = 6;
            // 
            // TrelloSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trelloTab);
            this.Name = "TrelloSettingDialog";
            this.Size = new System.Drawing.Size(532, 461);
            this.trelloTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.shearingGroupBox.ResumeLayout(false);
            this.shearingGroupBox.PerformLayout();
            this.informationGroupBox.ResumeLayout(false);
            this.informationGroupBox.PerformLayout();
            this.addingAccountGB.ResumeLayout(false);
            this.addingAccountGB.PerformLayout();
            this.AccountDetailsGB.ResumeLayout(false);
            this.AccountDetailsGB.PerformLayout();
            this.trelloTokenGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.addingAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minimalTimeForUpdate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl trelloTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox activeTrelloAccounts;
        private System.Windows.Forms.GroupBox trelloTokenGroup;
        private System.Windows.Forms.GroupBox addingAccountGB;
        private System.Windows.Forms.Button checkingAccount;
        private System.Windows.Forms.TextBox tokenCheckingBox;
        private System.Windows.Forms.ComboBox trelloToken;
        private System.Windows.Forms.Button addingTrelloToken;
        private System.Windows.Forms.LinkLabel urlTrello;
        public System.Windows.Forms.GroupBox addingAccount;
        public System.Windows.Forms.Button addTrelloAccountButton;
        public System.Windows.Forms.TextBox accountNameBox;
        private System.Windows.Forms.ComboBox sharedTrelloAccountsBox;
        private System.Windows.Forms.Label sharedLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button shareAccountButton;
        private System.Windows.Forms.GroupBox informationGroupBox;
        private System.Windows.Forms.TextBox infTokenDateCreation;
        private System.Windows.Forms.TextBox infTokenName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox infTrelloUserToken;
        private System.Windows.Forms.GroupBox shearingGroupBox;
        private System.Windows.Forms.CheckBox makeUserOwnerCheckBox;
        private System.Windows.Forms.Button btnCancelSaveShareAccount;
        private System.Windows.Forms.Button saveSharedAccountButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox shareUserNameBox;
        private System.Windows.Forms.Label labelSharedAccountError;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox trelloBoardsCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddAcountTrello;
        private System.Windows.Forms.GroupBox AccountDetailsGB;
        private System.Windows.Forms.Button accountSaveButton;
        private System.Windows.Forms.NumericUpDown minimalTimeForUpdate;
        private System.Windows.Forms.TextBox infBoardIdTB;
    }
}
