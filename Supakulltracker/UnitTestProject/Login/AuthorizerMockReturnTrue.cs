using Supakulltracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestClient.Login
{
    class AuthorizerMockReturnTrue : IAuthorizer
    {
        public AuthorizationResult Authorize(CredentialInfo credentiolInfo)
        {
            return new AuthorizationResult(true, null);
        }
    }
}
