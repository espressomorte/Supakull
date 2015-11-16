using Supakulltracker.UserProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class AuthorizationResult
    {
        public bool Authorized { get; set; }
        public UserDTO AuthorizedUser { get; set; }

        public AuthorizationResult(bool authorized, UserDTO authorizedUser)
        {
            this.Authorized = authorized;
            this.AuthorizedUser = authorizedUser;
        }
    }
}
