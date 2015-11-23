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
        private string[] subtaskTypes;
        private string[] summaries;
        
        public string SubtaskType
        {
            get
            {
                return CanGetSingleSubtaskType ? subtaskTypes[0] : "<Multiple Values>";
            }
        }

        public string Summary
        {
            get
            {
                return CanGetSingleSummary ? summaries[0] : "<Multiple Values>";
            }
        }

        public bool CanGetSingleSubtaskType { get; private set; }
        public bool CanGetSingleSummary { get; private set; }

        public void Refresh()
        {
            InvokePropertyChanged(new PropertyChangedEventArgs( nameof(this.SubtaskType) ));
        }

        /// <summary>
        /// todo: should be replaced with Task collection property, it would copy fields appropriately 
        /// </summary>
        public string[] MultipleSubtaskTypes
        {
            set
            {
                subtaskTypes = value;
                CanGetSingleSubtaskType = ValuesAreTheSame(subtaskTypes);
                InvokePropertyChanged(new PropertyChangedEventArgs("ID"));
            }
        }

        /// <summary>
        /// todo: should be replaced with Task collection property, it would copy fields appropriately 
        /// </summary>
        public string[] MultipleSummaries
        {
            set
            {
                summaries = value;
                CanGetSingleSummary = ValuesAreTheSame(summaries);
                InvokePropertyChanged(new PropertyChangedEventArgs("Summary"));
            }
        }
         
        public SuperTask(ICollection<IssueService.TaskMainDTO> matchedTasks)
        {
            subtaskTypes = new string[matchedTasks.Count];
            summaries = new string[matchedTasks.Count];
            int arrayCount = 0;

            foreach (IssueService.TaskMainDTO task in matchedTasks)
            {
                subtaskTypes[arrayCount] = task.SubtaskType;
                summaries[arrayCount] = task.Summary;
                arrayCount++;
            }

            CanGetSingleSubtaskType = ValuesAreTheSame(subtaskTypes);
            CanGetSingleSummary = ValuesAreTheSame(summaries);
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

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}
