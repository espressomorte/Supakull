using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supakulltracker.IssueService;

namespace Supakulltracker
{
    public class TaskMain : ITask
    {
        public TaskMain()
        {
            this.Assigned = new List<User>();
        }

        public string TaskID { get; set; }
        public string SubtaskType { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Product { get; set; }
        public string Project { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Sources Source { get; set; }
        public string LinkToTracker { get; set; }
        public Int32 TokenID { get; set; }
        public string Estimation { get; set; }
        public string TargetVersion { get; set; }
        public string Comments { get; set; }
        public IList<User> Assigned { get; set; }
        public ITask TaskParent { get; set; }

        #region IEquatable

        public override bool Equals(object obj)
        {
            TaskMain taskMainToCompare = obj as TaskMain;
            return Equals(taskMainToCompare);
        }

        public virtual bool Equals(TaskMain taskMainToCompare)
        {
            return (taskMainToCompare != null &&
                this.TaskID.Equals(taskMainToCompare.TaskID) &&
                this.Source.Equals(taskMainToCompare.Source));
        }

        public override int GetHashCode()
        {
            return (this.TaskID.GetHashCode()) ^ (int)this.Source;
        }

        #endregion
    }
}
