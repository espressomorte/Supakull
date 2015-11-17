using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public class TaskMain : ITask
    {
        public TaskMain()
        {
            this.Assigned = new List<User>();
            this.MatchedTasks = new List<ITask>();
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
        public Sources LinkToTracker { get; set; }
        public string Estimation { get; set; }
        public string TargetVersion { get; set; }
        public string Comments { get; set; }
        public IList<User> Assigned { get; set; }
        public ITask TaskParent { get; set; }
        public IList<ITask> MatchedTasks { get; set; }

        public int MatchedCount
        {
            get
            {
                return MatchedTasks.Count;
            }
        }

        public void AddMatchedTask(ITask taskMain)
        {
            this.MatchedTasks.Add(taskMain);
        }
        
        private ICollection<string> GetUserIDs()
        {
            if (Assigned == null)
            {
                return null;
            }
            ICollection<string> assignedUserIDs = new List<string>();
            foreach (User user in Assigned)
            {
                assignedUserIDs.Add(user.UserId);
            }
            return assignedUserIDs;
        }

        public static void MatchTasks(IList<ITask> taskMainCollection, IMatchTasks taskMatcher)
        {
            for (int a = 0; a < taskMainCollection.Count - 1; a++)
            {
                for (int b = a + 1; b < taskMainCollection.Count; b++)
                {
                    ITask taskA = taskMainCollection[a];
                    ITask taskB = taskMainCollection[b];
                    bool taskMatchingResult = taskMatcher.Match(taskA, taskB);
                    if (taskMatchingResult)
                    {
                        taskA.AddMatchedTask(taskB);
                        taskB.AddMatchedTask(taskA);
                    }
                }
            }
        }

        public TaskKey GetTaskKey()
        {
            return new TaskKey(this.TaskID, this.LinkToTracker);
        }
    }   
}
