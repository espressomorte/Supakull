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

        public CredentiolInfo GetCredentialsInfo(string message)
        {
            loginForm.MessageForUser = message;
            DialogResult dialogResult = loginForm.ShowDialog();
            CredentiolInfo credentiolInfo;
            if (dialogResult == DialogResult.OK)
            {
                credentiolInfo = new CredentiolInfo(loginForm.UserLogin);
            }
            else
            {
                credentiolInfo = null;
            }
            
            return credentiolInfo;
        }
    }
}
