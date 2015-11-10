using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class UserDAO
    {
        public virtual string UserId { get; set; }
        public virtual string UserName { get; set; }

        public UserDAO()
        {
        }

        public UserDAO(string UserId, string UserName)
        {
            this.UserId = UserId;
            this.UserName = UserName;
        }
    }
}