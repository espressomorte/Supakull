namespace Supakulltracker
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxUseName = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelWorning = new System.Windows.Forms.Label();
            this.labelIntroduction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(13, 56);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(71, 15);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "User name:";
            // 
            // textBoxUseName
            // 
            this.textBoxUseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUseName.Location = new System.Drawing.Point(91, 53);
            this.textBoxUseName.Name = "textBoxUseName";
            this.textBoxUseName.Size = new System.Drawing.Size(158, 21);
            this.textBoxUseName.TabIndex = 1;
            this.textBoxUseName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUseName_KeyPress);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(91, 85);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(174, 85);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelWorning
            // 
            this.labelWorning.AutoSize = true;
            this.labelWorning.ForeColor = System.Drawing.Color.Red;
            this.labelWorning.Location = new System.Drawing.Point(88, 32);
            this.labelWorning.Name = "labelWorning";
            this.labelWorning.Size = new System.Drawing.Size(0, 13);
            this.labelWorning.TabIndex = 4;
            // 
            // labelIntroduction
            // 
            this.labelIntroduction.AutoSize = true;
            this.labelIntroduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntroduction.Location = new System.Drawing.Point(60, 10);
            this.labelIntroduction.Name = "labelIntroduction";
            this.labelIntroduction.Size = new System.Drawing.Size(138, 15);
            this.labelIntroduction.TabIndex = 5;
            this.labelIntroduction.Text = "Please enter user name";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 121);
            this.Controls.Add(this.labelIntroduction);
            this.Controls.Add(this.labelWorning);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxUseName);
            this.Controls.Add(this.labelUserName);
            this.MaximumSize = new System.Drawing.Size(280, 160);
            this.MinimumSize = new System.Drawing.Size(280, 160);
            this.Name = "LoginForm";
            this.Text = "Supakull";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxUseName;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelWorning;
        private System.Windows.Forms.Label labelIntroduction;
    }
}