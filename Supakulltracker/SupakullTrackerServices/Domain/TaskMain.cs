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

        public static void ForceMatchTasks(IList<ITask> taskMainCollection, IMatchTasks taskMatcher)
        {
            for (int a = 0; a < taskMainCollection.Count - 1; a++)
            {
                for (int b = a + 1; b < taskMainCollection.Count; b++)
                {
                    ITask taskA = taskMainCollection[a];
                    ITask taskB = taskMainCollection[b];
                    bool taskMatchingResult = taskMatcher.MatchTasks(taskA, taskB);
                    if (taskMatchingResult)
                    {
                        taskA.AddMatchedTask(taskB);
                        taskB.AddMatchedTask(taskA);
                    }
                }
            }
        }

        public static void ForceDetectDisagreements(IList<ITask> taskMainCollection)
        {
            List<ITask> taskMainCollectionCopy = new List<ITask>(taskMainCollection);
            for (int i = 0; i < taskMainCollectionCopy.Count; i++)
            {
                ITask currentTaskMain = taskMainCollectionCopy[i];
                foreach (ITask matchedTask in currentTaskMain.MatchedTasks)
                {

                    if ( currentTaskMain.SubtaskType != null &&
                        matchedTask.SubtaskType != null &&
                        currentTaskMain.SubtaskType != matchedTask.SubtaskType )
                    {                        
                        Disagreement disagreement = new Disagreement("SubtaskType");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if ( currentTaskMain.Summary != null &&
                         matchedTask.Summary != null &&
                         currentTaskMain.Summary != matchedTask.Summary)
                    {
                        Disagreement disagreement = new Disagreement("Summary");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if ( currentTaskMain.Description != null &&
                         matchedTask.Description != null &&
                         currentTaskMain.Description != matchedTask.Description)
                    {
                        Disagreement disagreement = new Disagreement("Description");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if ( currentTaskMain.Status != null &&
                         matchedTask.Status != null &&
                         currentTaskMain.Status != matchedTask.Status)
                    {
                        Disagreement disagreement = new Disagreement("Status");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if (currentTaskMain.Priority != null &&
                         matchedTask.Priority != null &&
                         currentTaskMain.Priority != matchedTask.Priority)
                    {
                        Disagreement disagreement = new Disagreement("Priority");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if (currentTaskMain.Product != null &&
                         matchedTask.Product != null &&
                         currentTaskMain.Product != matchedTask.Product)
                    {
                        Disagreement disagreement = new Disagreement("Product");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if (currentTaskMain.Project != null &&
                         matchedTask.Project != null &&
                         currentTaskMain.Project != matchedTask.Project)
                    {
                        Disagreement disagreement = new Disagreement("Project");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if (currentTaskMain.CreatedDate != null &&
                         matchedTask.CreatedDate != null &&
                         currentTaskMain.CreatedDate != matchedTask.CreatedDate)
                    {
                        Disagreement disagreement = new Disagreement("CreatedDate");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if (currentTaskMain.CreatedBy != null &&
                         matchedTask.CreatedBy != null &&
                         currentTaskMain.CreatedBy != matchedTask.CreatedBy)
                    {
                        Disagreement disagreement = new Disagreement("CreatedBy");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if (currentTaskMain.LinkToTracker != null &&
                         matchedTask.LinkToTracker != null &&
                         currentTaskMain.LinkToTracker != matchedTask.LinkToTracker)
                    {
                        Disagreement disagreement = new Disagreement("LinkToTracker");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if (currentTaskMain.Estimation != null &&
                         matchedTask.Estimation != null &&
                         currentTaskMain.Estimation != matchedTask.Estimation)
                    {
                        Disagreement disagreement = new Disagreement("Estimation");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if (currentTaskMain.TargetVersion != null &&
                         matchedTask.TargetVersion != null &&
                         currentTaskMain.TargetVersion != matchedTask.TargetVersion)
                    {
                        Disagreement disagreement = new Disagreement("TargetVersion");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    if (currentTaskMain.Comments != null &&
                         matchedTask.Comments != null &&
                         currentTaskMain.Comments != matchedTask.Comments)
                    {
                        Disagreement disagreement = new Disagreement("Comments");
                        currentTaskMain.AddDisagreement(disagreement);
                        currentTaskMain.AddDisagreementToMatchedTasks(disagreement);
                    }


                    int indexOfTaskToDelete = taskMainCollectionCopy.IndexOf(matchedTask, i + 1);
                    taskMainCollectionCopy.RemoveAt(indexOfTaskToDelete);
                }
            }
        }
    }   
}
