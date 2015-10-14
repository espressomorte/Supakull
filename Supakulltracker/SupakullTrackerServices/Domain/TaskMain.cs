using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
     public class TaskMain: ITask, ITask2
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
        public string LinkToTracker { get; set; }
        public string Estimation { get; set; }
        public string TargetVersion { get; set; }
        public string Comments { get; set; }
        public IList<User> Assigned { get; set; }
        public ITask TaskParent { get; set; }
        public IList<ITask2> LinkedTasks { get; set; }

        public void LinkTask(ITask2 taskMain)
        {
            this.LinkedTasks.Add(taskMain);
        }

        public static void LinkTasks(IList<ITask2> taskMainCollection, IMatchTasks taskMatcher)
        {
            for(int a = 0; a < taskMainCollection.Count - 1; a++)
            {
                for (int b = a + 1; b < taskMainCollection.Count; b++)
                {
                    ITask2 taskA = taskMainCollection[a];
                    ITask2 taskB = taskMainCollection[b];
                    bool taskMatchingResult = taskMatcher.MatchTasks(taskA, taskB);
                    if(taskMatchingResult)
                    {
                        taskA.LinkTask(taskB);
                        taskB.LinkTask(taskA);
                    }
                }
            }
        }


    }    
}
