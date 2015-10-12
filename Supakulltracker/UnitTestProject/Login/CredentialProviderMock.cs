using Supakulltracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestClient.Login
{
    class CredentialProviderMock : ICredentialsProvider
    {
        private CredentialInfo credentialsInfo;

        public CredentialProviderMock()
        {
            credentialsInfo = new CredentialInfo("SomeUserLogin");
        }

        public CredentialProviderMock(CredentialInfo credentialsInfo)
        {
            this.credentialsInfo = credentialsInfo;
        }

        public CredentialInfo GetCredentialsInfo(string message)
        {
            return credentialsInfo;
        }
    }
}
