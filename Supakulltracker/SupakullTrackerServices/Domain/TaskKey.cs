using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class TaskKey: IEquatable<TaskKey>
    {
        public string TaskID { get; set; }
        public Sources LinkToTracker { get; set; }

        public int HashCode
        {
            get
            {
                return this.GetHashCode();
            }
        }

        public TaskKey(string taskID, Sources linkToTracker)
        {
            this.TaskID = taskID;
            this.LinkToTracker = linkToTracker;
        }

        public override bool Equals(object obj)
        {
            TaskKey taskKeyToCompare = obj as TaskKey;
            return Equals(taskKeyToCompare);
        }

        public virtual bool Equals(TaskKey taskKeyToCompare)
        {
            return (taskKeyToCompare != null &&
                this.TaskID.Equals(taskKeyToCompare.TaskID) &&
                this.LinkToTracker.Equals(taskKeyToCompare.LinkToTracker));
        }

        public override int GetHashCode()
        {
            return (this.TaskID.GetHashCode()) ^ (int)this.LinkToTracker;
        }
    }
}