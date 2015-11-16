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
        public AuthorizationResult Authorize(CredentialInfo credentiolInfo)
        {
            UserProviderSoapClient userProvider = new UserProviderSoapClient();
            string userLogin = credentiolInfo.UserLogin;
            UserDTO userDTO = userProvider.Find(userLogin);
            AuthorizationResult authorizationResult = new AuthorizationResult( (userDTO != null), userDTO );
            return authorizationResult;
        }
    }
}
