﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class UsersListDAO
    {
        public UsersListDAO()
        {
            this.TaskList = new List<IssueDAO>();
        }
        
        public virtual string UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual IList<IssueDAO> TaskList { get; set; }
    }
}