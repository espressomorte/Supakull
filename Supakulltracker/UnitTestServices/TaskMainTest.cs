using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupakullTrackerServices;

namespace UnitTestServices
{
    [TestClass]
    public class TaskMainTest
    {
        [TestMethod]
        public void ForceDetectDisagreements_Test1()
        {
            IList<ITask> taskMainCollection = new List<ITask>();
            ITask taskMain1 = new TaskMain() { TaskID = "Task1", SubtaskType = "a", Summary = null, Description = "c", Status = "e" };
            ITask taskMain2 = new TaskMain() { TaskID = "Task1", SubtaskType = "a", Summary = null, Description = "c", Status = "f" };
            ITask taskMain3 = new TaskMain() { TaskID = "Task1", SubtaskType = "a", Summary = "b", Description = "d", Status = "g" };
            ITask taskMain4 = new TaskMain() { TaskID = "Task2" };
            taskMainCollection.Add(taskMain1);
            taskMainCollection.Add(taskMain2);
            taskMainCollection.Add(taskMain3);
            taskMainCollection.Add(taskMain4);

            IMatchTasks taskMatcher = new MatchTasksById();
            TaskMain.MatchTasks(taskMainCollection, taskMatcher);
            TaskMain.DetectDisagreements(taskMainCollection);
        }
    }
}
