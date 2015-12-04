namespace Supakulltracker
{
    partial class GoogleSheetsSettingDialog
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ShareAccountsComboBox = new System.Windows.Forms.ComboBox();
            this.GR5CancelButton = new System.Windows.Forms.Button();
            this.ShareButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.ShareUserNameTB = new System.Windows.Forms.TextBox();
            this.PermitChangesCB = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ShareAccountButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.GR4ComboBox = new System.Windows.Forms.ComboBox();
            this.GR4CancelButton = new System.Windows.Forms.Button();
            this.DeleteAccountGBButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.DeleteAccountButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.AddAccountGBButton = new System.Windows.Forms.Button();
            this.GR3CancelButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.NameNewAccountTextBox = new System.Windows.Forms.TextBox();
            this.AddNewAccountButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CheckAccount = new System.Windows.Forms.Button();
            this.AccountsNameComboBox = new System.Windows.Forms.ComboBox();
            this.UseSaveToken = new System.Windows.Forms.Button();
            this.TokenStatusLabel = new System.Windows.Forms.Label();
            this.EnterAccessTokenButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AccessTokenTextBox = new System.Windows.Forms.TextBox();
            this.LinkToGetToken = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.TemplateNameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteTemplateButton = new System.Windows.Forms.Button();
            this.ActivateTemplateButton = new System.Windows.Forms.Button();
            this.NewTemplateButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TemplateComboBox = new System.Windows.Forms.ComboBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckButton = new System.Windows.Forms.Button();
            this.FileNameTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MappingDataView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label14 = new System.Windows.Forms.Label();
            this.SharedAccountsComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 539);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SharedAccountsComboBox);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.ShareAccountButton);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.DeleteAccountButton);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.AddNewAccountButton);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.CheckAccount);
            this.tabPage1.Controls.Add(this.AccountsNameComboBox);
            this.tabPage1.Controls.Add(this.UseSaveToken);
            this.tabPage1.Controls.Add(this.TokenStatusLabel);
            this.tabPage1.Controls.Add(this.EnterAccessTokenButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.AccessTokenTextBox);
            this.tabPage1.Controls.Add(this.LinkToGetToken);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(435, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ShareAccountsComboBox);
            this.groupBox5.Controls.Add(this.GR5CancelButton);
            this.groupBox5.Controls.Add(this.ShareButton);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.ShareUserNameTB);
            this.groupBox5.Controls.Add(this.PermitChangesCB);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(16, 336);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(411, 103);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Share";
            // 
            // ShareAccountsComboBox
            // 
            this.ShareAccountsComboBox.FormattingEnabled = true;
            this.ShareAccountsComboBox.Location = new System.Drawing.Point(132, 42);
            this.ShareAccountsComboBox.Name = "ShareAccountsComboBox";
            this.ShareAccountsComboBox.Size = new System.Drawing.Size(155, 24);
            this.ShareAccountsComboBox.TabIndex = 17;
            // 
            // GR5CancelButton
            // 
            this.GR5CancelButton.Location = new System.Drawing.Point(293, 43);
            this.GR5CancelButton.Name = "GR5CancelButton";
            this.GR5CancelButton.Size = new System.Drawing.Size(112, 23);
            this.GR5CancelButton.TabIndex = 6;
            this.GR5CancelButton.Text = "Cancel";
            this.GR5CancelButton.UseVisualStyleBackColor = true;
            this.GR5CancelButton.Click += new System.EventHandler(this.GR5CancelButton_Click);
            // 
            // ShareButton
            // 
            this.ShareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShareButton.Location = new System.Drawing.Point(293, 14);
            this.ShareButton.Name = "ShareButton";
            this.ShareButton.Size = new System.Drawing.Size(112, 23);
            this.ShareButton.TabIndex = 16;
            this.ShareButton.Text = "Share";
            this.ShareButton.UseVisualStyleBackColor = true;
            this.ShareButton.Click += new System.EventHandler(this.ShareButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = " ";
            // 
            // ShareUserNameTB
            // 
            this.ShareUserNameTB.Location = new System.Drawing.Point(132, 14);
            this.ShareUserNameTB.Name = "ShareUserNameTB";
            this.ShareUserNameTB.Size = new System.Drawing.Size(155, 23);
            this.ShareUserNameTB.TabIndex = 2;
            // 
            // PermitChangesCB
            // 
            this.PermitChangesCB.AutoSize = true;
            this.PermitChangesCB.Location = new System.Drawing.Point(10, 40);
            this.PermitChangesCB.Name = "PermitChangesCB";
            this.PermitChangesCB.Size = new System.Drawing.Size(125, 21);
            this.PermitChangesCB.TabIndex = 1;
            this.PermitChangesCB.Text = "Permit changes";
            this.PermitChangesCB.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Enter User name:";
            // 
            // ShareAccountButton
            // 
            this.ShareAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShareAccountButton.Location = new System.Drawing.Point(156, 278);
            this.ShareAccountButton.Name = "ShareAccountButton";
            this.ShareAccountButton.Size = new System.Drawing.Size(135, 23);
            this.ShareAccountButton.TabIndex = 14;
            this.ShareAccountButton.Text = "Share account";
            this.ShareAccountButton.UseVisualStyleBackColor = true;
            this.ShareAccountButton.Click += new System.EventHandler(this.ShareAccountButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GR4ComboBox);
            this.groupBox4.Controls.Add(this.GR4CancelButton);
            this.groupBox4.Controls.Add(this.DeleteAccountGBButton);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(13, 336);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(414, 74);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Delete account";
            // 
            // GR4ComboBox
            // 
            this.GR4ComboBox.FormattingEnabled = true;
            this.GR4ComboBox.Location = new System.Drawing.Point(113, 16);
            this.GR4ComboBox.Name = "GR4ComboBox";
            this.GR4ComboBox.Size = new System.Drawing.Size(177, 24);
            this.GR4ComboBox.TabIndex = 5;
            // 
            // GR4CancelButton
            // 
            this.GR4CancelButton.Location = new System.Drawing.Point(296, 45);
            this.GR4CancelButton.Name = "GR4CancelButton";
            this.GR4CancelButton.Size = new System.Drawing.Size(112, 23);
            this.GR4CancelButton.TabIndex = 4;
            this.GR4CancelButton.Text = "Cancel";
            this.GR4CancelButton.UseVisualStyleBackColor = true;
            this.GR4CancelButton.Click += new System.EventHandler(this.GR4CancelButton_Click);
            // 
            // DeleteAccountGBButton
            // 
            this.DeleteAccountGBButton.Location = new System.Drawing.Point(296, 16);
            this.DeleteAccountGBButton.Name = "DeleteAccountGBButton";
            this.DeleteAccountGBButton.Size = new System.Drawing.Size(113, 23);
            this.DeleteAccountGBButton.TabIndex = 3;
            this.DeleteAccountGBButton.Text = "Delete account";
            this.DeleteAccountGBButton.UseVisualStyleBackColor = true;
            this.DeleteAccountGBButton.Click += new System.EventHandler(this.DeleteAccountGBButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Account name:";
            // 
            // DeleteAccountButton
            // 
            this.DeleteAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteAccountButton.Location = new System.Drawing.Point(13, 307);
            this.DeleteAccountButton.Name = "DeleteAccountButton";
            this.DeleteAccountButton.Size = new System.Drawing.Size(137, 23);
            this.DeleteAccountButton.TabIndex = 13;
            this.DeleteAccountButton.Text = "Delete account";
            this.DeleteAccountButton.UseVisualStyleBackColor = true;
            this.DeleteAccountButton.Click += new System.EventHandler(this.DeleteAccountButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.AddAccountGBButton);
            this.groupBox3.Controls.Add(this.GR3CancelButton);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.NameNewAccountTextBox);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(13, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 74);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New account";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = " ";
            // 
            // AddAccountGBButton
            // 
            this.AddAccountGBButton.Location = new System.Drawing.Point(296, 13);
            this.AddAccountGBButton.Name = "AddAccountGBButton";
            this.AddAccountGBButton.Size = new System.Drawing.Size(113, 23);
            this.AddAccountGBButton.TabIndex = 2;
            this.AddAccountGBButton.Text = "Add account";
            this.AddAccountGBButton.UseVisualStyleBackColor = true;
            this.AddAccountGBButton.Click += new System.EventHandler(this.AddAccountGBButton_Click);
            // 
            // GR3CancelButton
            // 
            this.GR3CancelButton.Location = new System.Drawing.Point(296, 39);
            this.GR3CancelButton.Name = "GR3CancelButton";
            this.GR3CancelButton.Size = new System.Drawing.Size(112, 23);
            this.GR3CancelButton.TabIndex = 3;
            this.GR3CancelButton.Text = "Cancel";
            this.GR3CancelButton.UseVisualStyleBackColor = true;
            this.GR3CancelButton.Click += new System.EventHandler(this.GR3CancelButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Account name:";
            // 
            // NameNewAccountTextBox
            // 
            this.NameNewAccountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameNewAccountTextBox.Location = new System.Drawing.Point(114, 13);
            this.NameNewAccountTextBox.Name = "NameNewAccountTextBox";
            this.NameNewAccountTextBox.Size = new System.Drawing.Size(176, 23);
            this.NameNewAccountTextBox.TabIndex = 0;
            // 
            // AddNewAccountButton
            // 
            this.AddNewAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddNewAccountButton.Location = new System.Drawing.Point(13, 278);
            this.AddNewAccountButton.Name = "AddNewAccountButton";
            this.AddNewAccountButton.Size = new System.Drawing.Size(137, 23);
            this.AddNewAccountButton.TabIndex = 10;
            this.AddNewAccountButton.Text = "Add new account";
            this.AddNewAccountButton.UseVisualStyleBackColor = true;
            this.AddNewAccountButton.Click += new System.EventHandler(this.AddNewAccountButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(10, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Check account:";
            // 
            // CheckAccount
            // 
            this.CheckAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckAccount.Location = new System.Drawing.Point(263, 6);
            this.CheckAccount.Name = "CheckAccount";
            this.CheckAccount.Size = new System.Drawing.Size(75, 23);
            this.CheckAccount.TabIndex = 8;
            this.CheckAccount.Text = "Check";
            this.CheckAccount.UseVisualStyleBackColor = true;
            this.CheckAccount.Click += new System.EventHandler(this.CheckAccount_Click);
            // 
            // AccountsNameComboBox
            // 
            this.AccountsNameComboBox.FormattingEnabled = true;
            this.AccountsNameComboBox.Location = new System.Drawing.Point(126, 6);
            this.AccountsNameComboBox.Name = "AccountsNameComboBox";
            this.AccountsNameComboBox.Size = new System.Drawing.Size(131, 21);
            this.AccountsNameComboBox.TabIndex = 7;
            // 
            // UseSaveToken
            // 
            this.UseSaveToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UseSaveToken.Location = new System.Drawing.Point(297, 307);
            this.UseSaveToken.Name = "UseSaveToken";
            this.UseSaveToken.Size = new System.Drawing.Size(126, 23);
            this.UseSaveToken.TabIndex = 6;
            this.UseSaveToken.Text = "Use saved token";
            this.UseSaveToken.UseVisualStyleBackColor = true;
            this.UseSaveToken.Click += new System.EventHandler(this.UseSaveToken_Click);
            // 
            // TokenStatusLabel
            // 
            this.TokenStatusLabel.AutoSize = true;
            this.TokenStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TokenStatusLabel.Location = new System.Drawing.Point(10, 67);
            this.TokenStatusLabel.Name = "TokenStatusLabel";
            this.TokenStatusLabel.Size = new System.Drawing.Size(90, 17);
            this.TokenStatusLabel.TabIndex = 5;
            this.TokenStatusLabel.Text = "Token status";
            // 
            // EnterAccessTokenButton
            // 
            this.EnterAccessTokenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterAccessTokenButton.Location = new System.Drawing.Point(297, 278);
            this.EnterAccessTokenButton.Name = "EnterAccessTokenButton";
            this.EnterAccessTokenButton.Size = new System.Drawing.Size(126, 23);
            this.EnterAccessTokenButton.TabIndex = 4;
            this.EnterAccessTokenButton.Text = "Save new token";
            this.EnterAccessTokenButton.UseVisualStyleBackColor = true;
            this.EnterAccessTokenButton.Click += new System.EventHandler(this.EnterAccessTokenButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Paste AccessToken:";
            // 
            // AccessTokenTextBox
            // 
            this.AccessTokenTextBox.Location = new System.Drawing.Point(13, 252);
            this.AccessTokenTextBox.Name = "AccessTokenTextBox";
            this.AccessTokenTextBox.Size = new System.Drawing.Size(410, 20);
            this.AccessTokenTextBox.TabIndex = 2;
            // 
            // LinkToGetToken
            // 
            this.LinkToGetToken.Location = new System.Drawing.Point(13, 127);
            this.LinkToGetToken.Name = "LinkToGetToken";
            this.LinkToGetToken.Size = new System.Drawing.Size(410, 96);
            this.LinkToGetToken.TabIndex = 1;
            this.LinkToGetToken.Text = "";
            this.LinkToGetToken.Click += new System.EventHandler(this.LinkToGetToken_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Get Token";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.StatusLabel);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.CheckButton);
            this.tabPage2.Controls.Add(this.FileNameTB);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.MappingDataView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(435, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mapping";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.AddButton);
            this.groupBox2.Controls.Add(this.CancelButton);
            this.groupBox2.Controls.Add(this.TemplateNameTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(190, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 112);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New template";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = " ";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(70, 83);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(76, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(152, 83);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TemplateNameTextBox
            // 
            this.TemplateNameTextBox.Location = new System.Drawing.Point(67, 23);
            this.TemplateNameTextBox.Name = "TemplateNameTextBox";
            this.TemplateNameTextBox.Size = new System.Drawing.Size(160, 23);
            this.TemplateNameTextBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteTemplateButton);
            this.groupBox1.Controls.Add(this.ActivateTemplateButton);
            this.groupBox1.Controls.Add(this.NewTemplateButton);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TemplateComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(10, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 131);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Template";
            // 
            // DeleteTemplateButton
            // 
            this.DeleteTemplateButton.Location = new System.Drawing.Point(87, 101);
            this.DeleteTemplateButton.Name = "DeleteTemplateButton";
            this.DeleteTemplateButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteTemplateButton.TabIndex = 4;
            this.DeleteTemplateButton.Text = "Delete";
            this.DeleteTemplateButton.UseVisualStyleBackColor = true;
            this.DeleteTemplateButton.Click += new System.EventHandler(this.DeleteTemplateButton_Click);
            // 
            // ActivateTemplateButton
            // 
            this.ActivateTemplateButton.Location = new System.Drawing.Point(6, 101);
            this.ActivateTemplateButton.Name = "ActivateTemplateButton";
            this.ActivateTemplateButton.Size = new System.Drawing.Size(75, 23);
            this.ActivateTemplateButton.TabIndex = 3;
            this.ActivateTemplateButton.Text = "Select";
            this.ActivateTemplateButton.UseVisualStyleBackColor = true;
            this.ActivateTemplateButton.Click += new System.EventHandler(this.ActivateTemplateButton_Click);
            // 
            // NewTemplateButton
            // 
            this.NewTemplateButton.Location = new System.Drawing.Point(6, 72);
            this.NewTemplateButton.Name = "NewTemplateButton";
            this.NewTemplateButton.Size = new System.Drawing.Size(156, 23);
            this.NewTemplateButton.TabIndex = 2;
            this.NewTemplateButton.Text = "Add new template";
            this.NewTemplateButton.UseVisualStyleBackColor = true;
            this.NewTemplateButton.Click += new System.EventHandler(this.NewTemplateButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Template list:";
            // 
            // TemplateComboBox
            // 
            this.TemplateComboBox.FormattingEnabled = true;
            this.TemplateComboBox.Location = new System.Drawing.Point(6, 42);
            this.TemplateComboBox.Name = "TemplateComboBox";
            this.TemplateComboBox.Size = new System.Drawing.Size(156, 24);
            this.TemplateComboBox.TabIndex = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.Location = new System.Drawing.Point(65, 38);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(16, 17);
            this.StatusLabel.TabIndex = 11;
            this.StatusLabel.Text = "_";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status:";
            // 
            // CheckButton
            // 
            this.CheckButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckButton.Location = new System.Drawing.Point(241, 7);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(92, 23);
            this.CheckButton.TabIndex = 9;
            this.CheckButton.Text = "Check file";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // FileNameTB
            // 
            this.FileNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileNameTB.Location = new System.Drawing.Point(86, 7);
            this.FileNameTB.Name = "FileNameTB";
            this.FileNameTB.Size = new System.Drawing.Size(149, 23);
            this.FileNameTB.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "File name:";
            // 
            // MappingDataView
            // 
            this.MappingDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MappingDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.MappingDataView.Location = new System.Drawing.Point(10, 195);
            this.MappingDataView.Name = "MappingDataView";
            this.MappingDataView.Size = new System.Drawing.Size(413, 312);
            this.MappingDataView.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "GoogleSheets";
            this.Column1.Name = "Column1";
            this.Column1.Width = 185;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ITask";
            this.Column2.Name = "Column2";
            this.Column2.Width = 185;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(10, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 17);
            this.label14.TabIndex = 16;
            this.label14.Text = "Shared account:";
            // 
            // SharedAccountsComboBox
            // 
            this.SharedAccountsComboBox.FormattingEnabled = true;
            this.SharedAccountsComboBox.Location = new System.Drawing.Point(126, 37);
            this.SharedAccountsComboBox.Name = "SharedAccountsComboBox";
            this.SharedAccountsComboBox.Size = new System.Drawing.Size(131, 21);
            this.SharedAccountsComboBox.TabIndex = 17;
            // 
            // GoogleSheetsSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "GoogleSheetsSettingDialog";
            this.Size = new System.Drawing.Size(443, 542);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox LinkToGetToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AccessTokenTextBox;
        private System.Windows.Forms.DataGridView MappingDataView;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FileNameTB;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Button EnterAccessTokenButton;
        private System.Windows.Forms.Label TokenStatusLabel;
        private System.Windows.Forms.Button UseSaveToken;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AccountsNameComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CheckAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TemplateComboBox;
        private System.Windows.Forms.Button DeleteTemplateButton;
        private System.Windows.Forms.Button ActivateTemplateButton;
        private System.Windows.Forms.Button NewTemplateButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox TemplateNameTextBox;
        private System.Windows.Forms.Button AddNewAccountButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NameNewAccountTextBox;
        private System.Windows.Forms.Button AddAccountGBButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button DeleteAccountButton;
        private System.Windows.Forms.Button DeleteAccountGBButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button GR3CancelButton;
        private System.Windows.Forms.Button GR4CancelButton;
        private System.Windows.Forms.ComboBox GR4ComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ShareAccountButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox PermitChangesCB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ShareUserNameTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button ShareButton;
        private System.Windows.Forms.Button GR5CancelButton;
        private System.Windows.Forms.ComboBox ShareAccountsComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox SharedAccountsComboBox;
    }
}
