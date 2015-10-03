using Supakulltracker.UserProvider;
using System;
using System.Windows.Forms;

namespace Supakulltracker
{
    public partial class LoginForm : Form
    {
        public UserForAuthentication LoggedUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            textBoxUseName.Text = "supakull";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoggedUser = FindUser(this.textBoxUseName.Text);
            this.textBoxUseName.Focus();
        }

        private void textBoxUseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)     // ASCII Carriage return = 13
            {
                LoggedUser = FindUser(this.textBoxUseName.Text);
            }
            this.textBoxUseName.Focus();
        }

        private UserForAuthentication FindUser(string userName)
        {
            UserProviderSoapClient userProvider = new UserProviderSoapClient();
            UserForAuthentication user = userProvider.Find(userName);
            if (user == null)
            {
                this.labelWorning.Text = "User name is incorrect. Try again.";
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            return user;
        }

    }
}
