using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supakulltracker
{
    class LoginProviderWinForm : ILoginProvider
    {
        private IAuthorizer authorizer;

        public LoginProviderWinForm(IAuthorizer authorizer)
        {
            this.authorizer = authorizer;
        }

        public bool Login()
        {
            LoginForm loginForm = new LoginForm(authorizer);
            DialogResult dialogResult = loginForm.ShowDialog();
            return (dialogResult == DialogResult.OK);
        }
    }
}
