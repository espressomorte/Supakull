using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public class UserLinkDAO
    {
        public virtual Int32 UserLinkId { get; set; }
        public virtual Boolean Owner { get; set; }
        public virtual Int64 UserId { get; set; }
        public virtual Int64 UserOwnerID { get; set; }
        public virtual ServiceAccountDAO Account { get; set; }
    }
}
