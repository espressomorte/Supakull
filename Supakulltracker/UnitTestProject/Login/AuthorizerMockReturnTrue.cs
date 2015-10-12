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
        public bool Authorize(CredentialInfo credentiolInfo)
        {
            return true;
        }
    }
}
