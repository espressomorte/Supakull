using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class User
    {
        public virtual string UserId { get; set; }

        public User(string UserId)
        {
            this.UserId = UserId;
        }

        public UserKay GetUserKay()
        {
            return new UserKay(this.UserId);
        }
    }
}