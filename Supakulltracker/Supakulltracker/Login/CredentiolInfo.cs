using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class CredentiolInfo
    {
        public string UserLogin { get; set; }

        public CredentiolInfo(string userLogin)
        {
            this.UserLogin = userLogin;
        }
    }
}
