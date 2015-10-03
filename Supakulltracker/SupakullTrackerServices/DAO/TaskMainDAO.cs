using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
     public class TaskMainDAO
    {        
        public TaskMainDAO()
        {
            this.Assigned = new List<UserDAO>();
        }
        public virtual string TaskID { get; set; }
        public virtual string SubtaskType { get; set; }
        public virtual string Summary { get; set; }
        public virtual string Description { get; set; }
        public virtual string Status { get; set; }
        public virtual string Priority { get; set; }
        public virtual string Product { get; set; }
        public virtual string Project { get; set; }
        public virtual string CreatedDate { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string LinkToTracker { get; set; }
        public virtual string Estimation { get; set; }
        public virtual string TargetVersion { get; set; }
        public virtual string Comments { get; set; }
        public virtual IList<UserDAO> Assigned { get; set; }
        public virtual TaskMainDAO TaskParent { get; set; }        
    }
    
}
