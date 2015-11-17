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

        public AuthorizationResult Login()
        {
            LoginForm loginForm = new LoginForm(authorizer);
            loginForm.ShowDialog();
            AuthorizationResult authorizationResult = loginForm.AuthorizationResult;
            return authorizationResult;
        }
    }
}
