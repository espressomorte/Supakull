using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class User
    {
        public User()
        {
            this.TaskList = new List<ITask>();
        }

        public virtual string UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual IList<ITask> TaskList { get; set; }
    }
}