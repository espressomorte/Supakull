using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class SuperTask: INotifyPropertyChanged
    {
        #region Fields
        private string multipleValuesMessage = "<Multiple Values>";

        private string[] subtaskTypes;
        private string[] summaries;
        private string[] descriptions;
        private string[] statuses;
        private string[] priorities;
        private string[] products;
        private string[] projects;
        private string[] createdDates;
        private string[] createdBy;
        private IssueService.Sources[] linkToTrackers;
        private string[] estimations;
        private string[] targetVersions;
        private string[] comments;
        private IssueService.UserDTO[][] assigneds;
        private IssueService.TaskMainDTO[] taskParents;
        #endregion

        #region Properties
        public string SubtaskType { get; private set; }
        public string Summary { get; private set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Product { get; set; }
        public string Project { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public IssueService.Sources LinkToTracker { get; set; }
        public string Estimation { get; set; }
        public string TargetVersion { get; set; }
        public string Comments { get; set; }
        public IssueService.UserDTO[] Assigned { get; set; }
        public IssueService.TaskMainDTO TaskParent { get; set; }
        #endregion

        public SuperTask(ICollection<IssueService.TaskMainDTO> matchedTasks)
        {
            subtaskTypes = new string[matchedTasks.Count];
            summaries = new string[matchedTasks.Count];
            descriptions = new string[matchedTasks.Count];
            statuses = new string[matchedTasks.Count];
            priorities = new string[matchedTasks.Count];
            products = new string[matchedTasks.Count];
            projects = new string[matchedTasks.Count];
            createdDates = new string[matchedTasks.Count];
            createdBy = new string[matchedTasks.Count];
            linkToTrackers = new IssueService.Sources[matchedTasks.Count];
            estimations = new string[matchedTasks.Count];
            targetVersions = new string[matchedTasks.Count];
            comments = new string[matchedTasks.Count];
            //assigneds = 
            taskParents = new IssueService.TaskMainDTO[matchedTasks.Count];

            int arrayCount = 0;

            foreach (IssueService.TaskMainDTO task in matchedTasks)
            {
                subtaskTypes[arrayCount] = task.SubtaskType;
                summaries[arrayCount] = task.Summary;
                arrayCount++;
            }

            FillSuperTaskProperties();
        }

        private void FillSuperTaskProperties()
        {
            SubtaskType = ValuesAreTheSame(subtaskTypes) ? subtaskTypes[0] : multipleValuesMessage;
            Summary = ValuesAreTheSame(summaries) ? summaries[0] : multipleValuesMessage;
        }

        public void InvokePropertyChanged()
        {
            InvokePropertyChanged(new PropertyChangedEventArgs(nameof(this.SubtaskType)));
        }

        private static bool ValuesAreTheSame(string[] values)
        {
            string firstVal = values[0];
            foreach (string val in values)
            {
                if (firstVal != val) return false;
            }
            return true;
        }
                
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}
