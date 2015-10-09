using NUnit.Framework;
using Supakulltracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Login
{
    [TestFixture]
    class LoginProviderTest
    {
        [Test]
        public void LoginUserMethodReturnsTrueWhenUserAuthorized()
        {
            ICredentialsProvider credentialsProviderMock = new CredentialProviderMock();
            IAuthorizer authorizerMock = new AuthorizerMockReturnTrue();
            LoginProvider loginProvider = new LoginProvider();

            bool actualLoginResult = loginProvider.LoginUser(credentialsProviderMock, authorizerMock);

            Assert.IsTrue(actualLoginResult, "LoginUser method returns incorrect value");
        }

        [Test]
        public void LoginUserMethodReturnsFalseWhenUserNotAuthorized()
        {
            ICredentialsProvider credentialsProviderMock = new CredentialProviderMock(null);
            IAuthorizer authorizerMock = new AuthorizerMockReturnTrue();
            LoginProvider loginProvider = new LoginProvider();

            bool actualLoginResult = loginProvider.LoginUser(credentialsProviderMock, authorizerMock);

            Assert.IsFalse(actualLoginResult, "LoginUser method returns incorrect value");
        }
    }
}
