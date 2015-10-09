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
        public CredentiolInfo GetCredentialsInfo(string message)
        {
            LoginForm loginForm = new LoginForm(message);
            DialogResult dialogResult = loginForm.ShowDialog();
            CredentiolInfo credentiolInfo;
            if (dialogResult == DialogResult.OK)
            {
                credentiolInfo = new CredentiolInfo(loginForm.UserName);
            }
            else
            {
                credentiolInfo = null;
            }
            
            return credentiolInfo;
        }
    }
}
