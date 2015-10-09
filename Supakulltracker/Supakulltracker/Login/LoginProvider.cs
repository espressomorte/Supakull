using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class LoginProvider
    {
        public bool LoginUser(ICredentialsProvider credentialsProvider, IAuthorizer authorizer)
        {
            bool authorizationResult;
            string messageForCredentialProvider = string.Empty;

            do
            {
                CredentialInfo credentialsInfo = credentialsProvider.GetCredentialsInfo(messageForCredentialProvider);
                if (credentialsInfo == null)
                {
                    return false;
                }
                
                authorizationResult = authorizer.Authorize(credentialsInfo);
                if(!authorizationResult)
                {
                    messageForCredentialProvider = "User name is incorrect. Try again.";
                }
            } while (!authorizationResult);
            
            return authorizationResult;
        }
    }
}
