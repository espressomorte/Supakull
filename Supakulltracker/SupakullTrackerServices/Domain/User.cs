using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class User
    {
        public Int32 UserID { get; set; }
        public virtual string UserLogin { get; set; }

        public User(string userLogin)
        {
            this.UserLogin = userLogin;
        }

        public User(Int32 userID, string userLogin)
        {
            this.UserID = userID;
            this.UserLogin = userLogin;
        }

        public UserKey GetUserKey()
        {
            return new UserKey(this.UserLogin);
        }
    }
}