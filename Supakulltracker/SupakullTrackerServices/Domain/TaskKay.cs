using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class TaskKay: IEquatable<TaskKay>
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

        public TaskKay(string taskID, Sources linkToTracker)
        {
            this.TaskID = taskID;
            this.LinkToTracker = linkToTracker;
        }

        public override bool Equals(object obj)
        {
            TaskKay taskKayToCompare = obj as TaskKay;
            return Equals(taskKayToCompare);
        }

        public virtual bool Equals(TaskKay taskKayToCompare)
        {
            return (taskKayToCompare != null &&
                this.TaskID.Equals(taskKayToCompare.TaskID) &&
                this.LinkToTracker.Equals(taskKayToCompare.LinkToTracker));
        }

        public override int GetHashCode()
        {
            return (this.TaskID.GetHashCode()) ^ (int)this.LinkToTracker;
        }
    }
}