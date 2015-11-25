using Supakulltracker.IssueService;
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
        private static string multipleValuesMessage = "<Multiple Values>";

        private string[] subtaskTypes;
        private string[] summaries;
        private string[] descriptions;
        private string[] statuses;
        private string[] priorities;
        private string[] products;
        private string[] projects;
        private string[] createdDates;
        private string[] createdBy;
        private Sources[] linkToTrackers;
        private string[] estimations;
        private string[] targetVersions;
        private string[] comments;
        private UserDTO[][] assigneds;
        private TaskMainDTO[] taskParents;
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
        public string LinkToTracker { get; set; }
        public string Estimation { get; set; }
        public string TargetVersion { get; set; }
        public string Comments { get; set; }
        public string Assigned { get; set; }
        public string TaskParent { get; set; }
        #endregion

        public SuperTask(ICollection<TaskMainDTO> matchedTasks)
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
            linkToTrackers = new Sources[matchedTasks.Count];
            estimations = new string[matchedTasks.Count];
            targetVersions = new string[matchedTasks.Count];
            comments = new string[matchedTasks.Count];
            assigneds = new UserDTO[matchedTasks.Count][];
            taskParents = new TaskMainDTO[matchedTasks.Count];

            int arrayCount = 0;
            foreach (TaskMainDTO task in matchedTasks)
            {
                subtaskTypes[arrayCount] = task.SubtaskType;
                summaries[arrayCount] = task.Summary;
                descriptions[arrayCount] = task.Description;
                statuses[arrayCount] = task.Status;
                priorities[arrayCount] = task.Priority;
                products[arrayCount] = task.Product;
                projects[arrayCount] = task.Project;
                createdDates[arrayCount] = task.CreatedDate;
                createdBy[arrayCount] = task.CreatedBy;
                linkToTrackers[arrayCount] = task.LinkToTracker;
                estimations[arrayCount] = task.Estimation;
                targetVersions[arrayCount] = task.TargetVersion;
                comments[arrayCount] = task.Comments;
                assigneds[arrayCount] = task.Assigned;
                taskParents[arrayCount] = task.TaskParent;

                arrayCount++;
            }

            FillSuperTaskProperties();
        }

        private void FillSuperTaskProperties()
        {
            SubtaskType = GetSingleValue(subtaskTypes);
            Summary = GetSingleValue(summaries);
            Description = GetSingleValue(descriptions);
            Status = GetSingleValue(statuses);
            Priority = GetSingleValue(priorities);
            Product = GetSingleValue(products);
            Project = GetSingleValue(projects);
            CreatedDate = GetSingleValue(createdDates);
            CreatedBy = GetSingleValue(createdBy);
            LinkToTracker = GetSingleValue(linkToTrackers);
            Estimation = GetSingleValue(estimations);
            TargetVersion = GetSingleValue(targetVersions);
            Comments = GetSingleValue(comments);
            Assigned = GetSingleValue(assigneds);
            TaskParent = GetSingleValue(taskParents);
        }


        private static string GetSingleValue(string[] values)
        {
            string singleValue = multipleValuesMessage;
            if (ValuesAreTheSame(values))
            {
                singleValue = null;
                foreach (string value in values)
                {
                    if (value != null)
                    {
                        singleValue = value;
                        break;
                    }
                }
            }            
            return singleValue;
        }

        private static bool ValuesAreTheSame(string[] values)
        {
            int indexFirstVal = 0;
            while (values[indexFirstVal] == null && indexFirstVal < values.Length - 2)
            {
                indexFirstVal++;
            }
            string firstVal = values[indexFirstVal];

            for (int indexSecondVal = indexFirstVal + 1; indexSecondVal < values.Length; indexSecondVal++)
            {
                string secondVal = values[indexSecondVal];
                if (firstVal != null && secondVal != null)
                {
                    char[] trimers = new char[] { ' ', ',', '.' };
                    firstVal = firstVal.Trim(trimers);
                    secondVal = secondVal.Trim(trimers);
                    if (!string.Equals(firstVal, secondVal, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return false;
                    }                    
                }
            }
            return true;
        }


        private static string GetSingleValue(Sources[] values)
        {
            string[] stringValues = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                stringValues[i] = values[i].ToString();
            }
            return string.Join(", ", stringValues);
        }
        

        private static string GetSingleValue(UserDTO[][] values)
        {
            string singleValue = multipleValuesMessage;
            if (ValuesAreTheSame(values))
            {
                singleValue = null;
                foreach (UserDTO[] usersDTO in values)
                {
                    if (usersDTO.Length > 0)
                    {
                        string[] userLogins = new string[usersDTO.Length];
                        for (int i = 0; i < usersDTO.Length; i++)
                        {
                            userLogins[i] = usersDTO[i].UserLogin;
                        }
                        singleValue = string.Join(", ", userLogins);
                        break;
                    }
                }
            }
            return singleValue;
        }

        private static bool ValuesAreTheSame(UserDTO[][] values)
        {
            int indexFirstArray = 0;
            while (values[indexFirstArray].Length == 0 && indexFirstArray < values.Length - 2)
            {
                indexFirstArray++;
            }
            UserDTO[] firstArray = values[indexFirstArray];

            for (int indexSecondArray = indexFirstArray + 1; indexSecondArray < values.Length; indexSecondArray++)
            {
                UserDTO[] secondArray = values[indexSecondArray];
                if ( firstArray.Length > 0 && secondArray.Length > 0 &&
                    (!FirstArrayIsInSecond(firstArray, secondArray) || !FirstArrayIsInSecond(secondArray, firstArray)) )
                {
                    return false;
                }
            }
            return true;
        }

        private static bool FirstArrayIsInSecond(UserDTO[] firstArray, UserDTO[] secondArray)
        {
            for (int n = 0; n < firstArray.Length; n++)
            {
                bool valueFromFirstArrayIsInSecond = false;
                for (int m = 0; m < secondArray.Length; m++)
                {
                    valueFromFirstArrayIsInSecond = firstArray[n].UserLogin.Equals(secondArray[m].UserLogin);
                    if (valueFromFirstArrayIsInSecond)
                    {
                        break;
                    }
                }
                if (!valueFromFirstArrayIsInSecond)
                {
                    return false;
                }
            }
            return true;
        }
        

        private static string GetSingleValue(TaskMainDTO[] values)
        {
            string singleValue = multipleValuesMessage;
            if (ValuesAreTheSame(values))
            {
                singleValue = null;
                foreach (TaskMainDTO task in values)
                {
                    if (task != null)
                    {
                        singleValue = task.TaskID;
                        break;
                    }
                }
            }
            return singleValue;
        }

        private static bool ValuesAreTheSame(TaskMainDTO[] values)
        {
            int indexFirstVal = 0;
            while (values[indexFirstVal] == null && indexFirstVal < values.Length - 2)
            {
                indexFirstVal++;
            }
            TaskMainDTO firstVal = values[indexFirstVal];

            for (int indexSecondVal = indexFirstVal + 1; indexSecondVal < values.Length; indexSecondVal++)
            {
                TaskMainDTO secondVal = values[indexSecondVal];
                if (firstVal != null && secondVal != null &&
                    !string.Equals(firstVal.TaskID, secondVal.TaskID, StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }
        

        public void InvokePropertyChanged()
        {
            InvokePropertyChanged(new PropertyChangedEventArgs(nameof(this.SubtaskType)));
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
