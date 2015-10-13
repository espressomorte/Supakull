﻿using Supakulltracker.UserProvider;
using System;
using System.Windows.Forms;

namespace Supakulltracker
{
    public partial class LoginForm : Form
    {
        public UserForAuthentication LoggedUser { get; private set; }
        private IAuthorizer authorizer;

        public LoginForm(IAuthorizer authorizer)
        {
            InitializeComponent();
            this.authorizer = authorizer;
            this.textBoxUseName.Text = "supakull";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Authorize();
        }

        private void textBoxUseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)     // ASCII Carriage return = 13
            {
                Authorize();
            }
        }

        private void Authorize()
        {
            CredentialInfo credentialInfo = new CredentialInfo(textBoxUseName.Text);
            bool authorizeResult = authorizer.Authorize(credentialInfo);
            if (authorizeResult)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                labelMessageForUser.Text = "User name is incorrect. Try again.";
                textBoxUseName.Focus();
            }
        }
    }
}
