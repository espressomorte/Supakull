using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class UserKay//: IEquatable<UserKay>
    {
        public string UserId { get; set; }

        public int HashCode
        {
            get
            {
                return this.GetHashCode();
            }
        }

        public UserKay(string userId)
        {
            this.UserId = userId;
        }

        public override bool Equals(object obj)
        {
            UserKay userKayToCompare = obj as UserKay;
            return Equals(userKayToCompare);
        }

        public virtual bool Equals(UserKay userKayToCompare)
        {
            return (userKayToCompare != null &&
                this.UserId.Equals(userKayToCompare.UserId));
        }

        public override int GetHashCode()
        {
            return this.UserId.GetHashCode();
        }
    }
}