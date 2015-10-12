using Supakulltracker.UserProvider;
using System;
using System.Windows.Forms;

namespace Supakulltracker
{
    public partial class LoginForm : Form
    {
        public UserForAuthentication LoggedUser { get; private set; }
        public string UserLogin { get; private set; }
        public string MessageForUser
        {
            set
            {
                labelMessageForUser.Text = value;
            }
        }

        public LoginForm()
        {
            InitializeComponent();
            textBoxUseName.Text = "supakull";
            UserLogin = null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            UserLogin = this.textBoxUseName.Text;
            textBoxUseName.Focus();
        }

        private void textBoxUseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)     // ASCII Carriage return = 13
            {
                this.DialogResult = DialogResult.OK;
                UserLogin = this.textBoxUseName.Text;

            }
        }
    }
}
