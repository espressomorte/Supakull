using Supakulltracker.UserProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class Authorizer : IAuthorizer
    {
        public bool Authorize(CredentialInfo credentiolInfo)
        {
            string userLogin = credentiolInfo.UserLogin;
            UserProviderSoapClient userProvider = new UserProviderSoapClient();
            bool authorizationResult = userProvider.Exist(userLogin);
            return authorizationResult;
        }
    }
}
