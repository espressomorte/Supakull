using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class CredentialInfo
    {
        public string UserLogin { get; set; }

        public CredentialInfo(string userLogin)
        {
            this.UserLogin = userLogin;
        }
    }
}
