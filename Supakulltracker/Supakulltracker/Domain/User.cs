using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supakulltracker
{
    public class User: IEquatable<User>
    {
        public int UserID { get; set; }
        public virtual string UserLogin { get; set; }

        public User(int userID, string userLogin)
        {
            this.UserID = userID;
            this.UserLogin = userLogin;
        }

        #region IEquatable

        public override bool Equals(object obj)
        {
            User userToCompare = obj as User;
            return Equals(userToCompare);
        }

        public virtual bool Equals(User userToCompare)
        {
            return (userToCompare != null &&
                this.UserLogin.Equals(userToCompare.UserLogin));
        }

        public override int GetHashCode()
        {
            return this.UserLogin.GetHashCode();
        }

        #endregion
    }
}