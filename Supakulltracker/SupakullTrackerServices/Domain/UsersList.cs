using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices.Class
{
    public class UsersList
    {
        public UsersList()
        {
            this.TaskList = new List<TaskMain>();
        }

        public virtual string UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual IList<TaskMain> TaskList { get; set; }
    }
}