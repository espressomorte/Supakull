using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class UserDAO
    {
        public UserDAO()
        {
            this.TaskList = new List<TaskMainDAO>();
        }
        
        public virtual string UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual IList<TaskMainDAO> TaskList { get; set; }
    }
}