using Supakulltracker.UserProvider;
using System;
using System.Windows.Forms;

namespace Supakulltracker
{
    public partial class LoginForm : Form
    {
        public UserForAuthentication LoggedUser { get; private set; }
        public string UserName { get; private set; }

        public LoginForm(string messageForUser)
        {
            InitializeComponent();
            textBoxUseName.Text = "supakull";
            UserName = null;
            this.labelWorning.Text = messageForUser;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            UserName = this.textBoxUseName.Text;
        }

        private void textBoxUseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)     // ASCII Carriage return = 13
            {
                this.DialogResult = DialogResult.OK;
                UserName = this.textBoxUseName.Text;
            }
        }
    }
}
