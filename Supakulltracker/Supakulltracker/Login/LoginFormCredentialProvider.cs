using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supakulltracker
{
    public class LoginFormCredentialProvider : ICredentialsProvider
    {
        private LoginForm loginForm;

        public LoginFormCredentialProvider()
        {
            loginForm = new LoginForm();
        }

        public CredentialInfo GetCredentialsInfo(string message)
        {
            loginForm.MessageForUser = message;
            DialogResult dialogResult = loginForm.ShowDialog();
            CredentialInfo credentiolInfo;
            if (dialogResult == DialogResult.OK)
            {
                credentiolInfo = new CredentialInfo(loginForm.UserLogin);
            }
            else
            {
                credentiolInfo = null;
            }
            
            return credentiolInfo;
        }
    }
}
