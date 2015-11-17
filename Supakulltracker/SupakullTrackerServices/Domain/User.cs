using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class User
    {
        public virtual string UserId { get; set; }

        public User(string userId)
        {
            this.UserId = userId;
        }

        public UserKey GetUserKey()
        {
            return new UserKey(this.UserId);
        }
    }
}