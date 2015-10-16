using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class TaskAggregated: ITaskAggregated
    {
        public IList<ITask> TaskMainCollection { get; set; }

        public TaskAggregated()
        {
            TaskMainCollection = new List<ITask>();
        }

        public void Add(ITask newTaskMain)
        {
            TaskMainCollection.Add(newTaskMain);
        }

        public static IList<ITaskAggregated> ForceAggregateTasks(IList<ITask> taskMainCollectionOrigin)
        {
            List<ITask> taskMainCollectionCopy = new List<ITask>(taskMainCollectionOrigin);
            IList<ITaskAggregated> taskAggregatedCollection = new List<ITaskAggregated>();
            for (int i = 0; i < taskMainCollectionCopy.Count; i++)
            {
                ITask currentTaskMain = taskMainCollectionCopy[i];
                TaskAggregated taskAggregated = new TaskAggregated();
                taskAggregated.Add(currentTaskMain);
                foreach(ITask linkedTask in currentTaskMain.LinkedTasks)
                {
                    taskAggregated.Add(linkedTask);
                    int indexOfTaskToDelete = taskMainCollectionCopy.IndexOf(linkedTask, i+1);
                    taskMainCollectionCopy.RemoveAt(indexOfTaskToDelete);
                }
                taskAggregatedCollection.Add(taskAggregated);
            }
            return taskAggregatedCollection;
        }
    }
}