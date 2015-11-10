using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class User
    {
        public virtual string UserId { get; set; }
        public virtual string UserName { get; set; }

        public User(string UserId, string UserName)
        {
            this.UserId = UserId;
            this.UserName = UserName;
        }
    }
}