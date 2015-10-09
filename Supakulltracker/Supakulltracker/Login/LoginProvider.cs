using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class LoginProvider
    {
        public bool LoginUser()
        {
            ICredentialsProvider credentialsProvider = new LoginFormCredentialProvider();
            bool authorizationResult;
            string messageForGredentialProvider = string.Empty;

            do
            {
                CredentiolInfo credentialsInfo = credentialsProvider.GetCredentialsInfo(messageForGredentialProvider);
                if (credentialsInfo == null)
                {
                    return false;
                }
                Authorizer authorizer = new Authorizer();
                authorizationResult = authorizer.Authorize(credentialsInfo);
                if(!authorizationResult)
                {
                    messageForGredentialProvider = "User name is incorrect. Try again.";
                }
            } while (!authorizationResult);
            
            return authorizationResult;
        }
    }
}
