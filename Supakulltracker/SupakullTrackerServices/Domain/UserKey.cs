using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class UserKey: IEquatable<UserKey>
    {
        public string UserId { get; set; }

        public int HashCode
        {
            get
            {
                return this.GetHashCode();
            }
        }

        public UserKey(string userId)
        {
            this.UserId = userId;
        }

        public override bool Equals(object obj)
        {
            UserKey userKeyToCompare = obj as UserKey;
            return Equals(userKeyToCompare);
        }

        public virtual bool Equals(UserKey userKeyToCompare)
        {
            return (userKeyToCompare != null &&
                this.UserId.Equals(userKeyToCompare.UserId));
        }

        public override int GetHashCode()
        {
            return this.UserId.GetHashCode();
        }
    }
}