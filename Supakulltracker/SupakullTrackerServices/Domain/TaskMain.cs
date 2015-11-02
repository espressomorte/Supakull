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
            this.Disagreements = new HashSet<Disagreement>();
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
        public ISet<Disagreement> Disagreements { get; set; }

        public void AddMatchedTask(ITask taskMain)
        {
            this.MatchedTasks.Add(taskMain);
        }

        public bool AddDisagreement(Disagreement disagreement)
        {            
            return Disagreements.Add(disagreement);
        }

        public void AddDisagreementCollection(IEnumerable<Disagreement> disagreementCollection)
        {
            foreach (Disagreement disagreement in disagreementCollection)
            {
                this.AddDisagreement(disagreement);
            }
        }

        public IList<ITaskField> GetFields()
        {
            List<ITaskField> taskMainFields = new List<ITaskField>();

            taskMainFields.Add(new FieldString(nameof(this.SubtaskType), this.SubtaskType));
            taskMainFields.Add(new FieldString(nameof(this.Summary), this.Summary));
            taskMainFields.Add(new FieldString(nameof(this.Description), this.Description));
            taskMainFields.Add(new FieldString(nameof(this.Status), this.Status));
            taskMainFields.Add(new FieldString(nameof(this.Priority), this.Priority));
            taskMainFields.Add(new FieldString(nameof(this.Product), this.Product));
            taskMainFields.Add(new FieldString(nameof(this.Project), this.Project));
            taskMainFields.Add(new FieldString(nameof(this.CreatedDate), this.CreatedDate));
            taskMainFields.Add(new FieldString(nameof(this.CreatedBy), this.CreatedBy));
            taskMainFields.Add(new FieldString(nameof(this.Estimation), this.Estimation));
            taskMainFields.Add(new FieldString(nameof(this.TargetVersion), this.TargetVersion));
            taskMainFields.Add(new FieldString(nameof(this.Comments), this.Comments));
            ICollection<string> assignedUserIDs = GetUserIDs();
            taskMainFields.Add(new FieldStringCollection(nameof(this.Assigned), assignedUserIDs));
            taskMainFields.Add(new FieldString(nameof(this.TaskParent), this.TaskParent == null ? null : this.TaskParent.TaskID));

            return taskMainFields;
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
        
        public static IEnumerable<Disagreement> GetDisagreements(IList<ITask> taskMainCollection)
        {
            HashSet<Disagreement> disagreements = new HashSet<Disagreement>();
            ITask taskA = taskMainCollection[0];
            IList<ITaskField> fieldsA = taskA.GetFields();
            for (int b = 1; b < taskMainCollection.Count; b++)
            {
                ITask taskB = taskMainCollection[b];                                
                IList<ITaskField> fieldsB = taskB.GetFields();

                for(int i = 0; i < fieldsA.Count; i++)
                {
                    bool fieldsCompareResult = fieldsA[i].Equals(fieldsB[i]);
                    if(!fieldsCompareResult)
                    {
                        Disagreement disagreement = new Disagreement(fieldsA[i].FieldName);
                        disagreements.Add(disagreement);
                    }
                }
            }
            return disagreements;
        }
    }   
}
