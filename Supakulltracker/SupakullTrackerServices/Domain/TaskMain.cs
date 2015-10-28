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
            this.Disagreements = new List<Disagreement>();
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
        public IList<ITask> MatchedTasks { get; set; }
        public IList<Disagreement> Disagreements { get; set; }

        public void AddMatchedTask(ITask taskMain)
        {
            this.MatchedTasks.Add(taskMain);
        }

        public void AddDisagreement(Disagreement disagreement)
        {
            if( !this.Disagreements.Contains(disagreement) )
            {
                this.Disagreements.Add(disagreement);
            }
        }

        public void AddDisagreementToMatchedTasks(Disagreement disagreement)
        {
            foreach(TaskMain matchedTask in this.MatchedTasks)
            {
                matchedTask.AddDisagreement(disagreement);
            }
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

        public static ICollection<Disagreement> GetDisagreements(IList<ITask> taskMainCollection)
        {
            ICollection<Disagreement> disagreements = new HashSet<Disagreement>();
            ITask taskA = taskMainCollection[0];
            for(int b = 1; b < taskMainCollection.Count; b++)
            {
                ITask taskB = taskMainCollection[b];

                if (taskA.SubtaskType != null &&
                        taskB.SubtaskType != null &&
                        taskA.SubtaskType != taskB.SubtaskType)
                {
                    Disagreement disagreement = new Disagreement(nameof(taskA.SubtaskType));
                    disagreements.Add(disagreement);
                }


                if (taskA.Summary != null &&
                         taskB.Summary != null &&
                         taskA.Summary != taskB.Summary)
                {
                    Disagreement disagreement = new Disagreement("Summary");
                    taskA.AddDisagreement(disagreement);
                    disagreements.Add(disagreement);
                }


                if (taskA.Description != null &&
                     taskB.Description != null &&
                     taskA.Description != taskB.Description)
                {
                    Disagreement disagreement = new Disagreement("Description");
                    taskA.AddDisagreement(disagreement);
                    disagreements.Add(disagreement);
                }


                if (taskA.Status != null &&
                     taskB.Status != null &&
                     taskA.Status != taskB.Status)
                {
                    Disagreement disagreement = new Disagreement("Status");
                    taskA.AddDisagreement(disagreement);
                    disagreements.Add(disagreement);
                }


                if (taskA.Priority != null &&
                    taskB.Priority != null &&
                    taskA.Priority != taskB.Priority)
                {
                    Disagreement disagreement = new Disagreement("Priority");
                    taskA.AddDisagreement(disagreement);
                }


                if (taskA.Product != null &&
                     taskB.Product != null &&
                     taskA.Product != taskB.Product)
                {
                    Disagreement disagreement = new Disagreement("Product");
                    taskA.AddDisagreement(disagreement);
                }


                if (taskA.Project != null &&
                     taskB.Project != null &&
                     taskA.Project != taskB.Project)
                {
                    Disagreement disagreement = new Disagreement("Project");
                    taskA.AddDisagreement(disagreement);
                }


                if (taskA.CreatedDate != null &&
                     taskB.CreatedDate != null &&
                     taskA.CreatedDate != taskB.CreatedDate)
                {
                    Disagreement disagreement = new Disagreement("CreatedDate");
                    taskA.AddDisagreement(disagreement);
                }


                if (taskA.CreatedBy != null &&
                     taskB.CreatedBy != null &&
                     taskA.CreatedBy != taskB.CreatedBy)
                {
                    Disagreement disagreement = new Disagreement("CreatedBy");
                    taskA.AddDisagreement(disagreement);
                }


                if (taskA.LinkToTracker != null &&
                     taskB.LinkToTracker != null &&
                     taskA.LinkToTracker != taskB.LinkToTracker)
                {
                    Disagreement disagreement = new Disagreement("LinkToTracker");
                    taskA.AddDisagreement(disagreement);
                }


                if (taskA.Estimation != null &&
                     taskB.Estimation != null &&
                     taskA.Estimation != taskB.Estimation)
                {
                    Disagreement disagreement = new Disagreement("Estimation");
                    taskA.AddDisagreement(disagreement);
                }


                if (taskA.TargetVersion != null &&
                     taskB.TargetVersion != null &&
                     taskA.TargetVersion != taskB.TargetVersion)
                {
                    Disagreement disagreement = new Disagreement("TargetVersion");
                    taskA.AddDisagreement(disagreement);
                }


                if (taskA.Comments != null &&
                     taskB.Comments != null &&
                     taskA.Comments != taskB.Comments)
                {
                    Disagreement disagreement = new Disagreement("Comments");
                    taskA.AddDisagreement(disagreement);
                }
            }
            return disagreements;

        }
    }   
}
