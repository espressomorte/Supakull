using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class TaskKey: IEquatable<TaskKey>
    {
        public string TaskID { get; set; }
        public Sources Source { get; set; }
        public Int32 TokenID { get; set; }

        public int HashCode
        {
            get
            {
                return this.GetHashCode();
            }
        }

        public TaskKey(string taskID, Sources Source, Int32 tokenID)
        {
            this.TaskID = taskID;
            this.Source = Source;
            this.TokenID = tokenID;
        }

        public override bool Equals(object obj)
        {
            if (obj is TaskKey)
            {
                TaskKey taskKeyToCompare = obj as TaskKey;
                return Equals(taskKeyToCompare);
            }
            return false;            
        }

        public virtual bool Equals(TaskKey taskKeyToCompare)
        {
            return (taskKeyToCompare != null &&
                this.TaskID.Equals(taskKeyToCompare.TaskID) &&
                this.Source.Equals(taskKeyToCompare.Source) &&
                this.TokenID.Equals(taskKeyToCompare.TokenID));
        }

        public override int GetHashCode()
        {
            return (this.TaskID.GetHashCode()) ^ (int)this.Source ^ this.TokenID;
        }
    }
}