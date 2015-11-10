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
        public void AddDisagreementsToTasks_Test1() 
        {
            IList<ITask> taskMainCollection = new List<ITask>();
            ITask taskMainParent1 = new TaskMain() { TaskID = "TaskParent1", LinkToTracker = Sources.DataBase };
            ITask taskMainParent2 = new TaskMain() { TaskID = "TaskParent2", LinkToTracker = Sources.Trello };
            User user1 = new User("user1", "user1");
            User user2 = new User("user2", "user2");
            IList<User> assigned1 = new List<User>() { user1, user2 };
            IList<User> assigned2 = new List<User>() { user2, user1 };

            ITask taskMain1 = new TaskMain()
                { TaskID = "Task1", SubtaskType = "a", Summary = null, Description = "cc", Status = "e", LinkToTracker = Sources.DataBase, TaskParent = null, Assigned = assigned2 };
            ITask taskMain2 = new TaskMain()
                { TaskID = "Task1", SubtaskType = "a", Summary = null, Description = "cc", Status = "f", LinkToTracker = Sources.Trello, TaskParent = taskMainParent2, Assigned = null };
            ITask taskMain3 = new TaskMain()
                { TaskID = "Task1", SubtaskType = "a", Summary = "b", Description = "d", Status = "g", LinkToTracker = Sources.Excel, TaskParent = taskMainParent1, Assigned = assigned1 };
            ITask taskMain4 = new TaskMain()
                { TaskID = "TaskParent3", LinkToTracker = Sources.GoogleSheets };

            taskMainCollection.Add(taskMainParent1);
            taskMainCollection.Add(taskMain1);
            taskMainCollection.Add(taskMain2);
            taskMainCollection.Add(taskMain3);
            taskMainCollection.Add(taskMain4);
            taskMainCollection.Add(taskMainParent2);

            IMatchTasks taskMatcher = new MatchTasksById();
            TaskMain.MatchTasks(taskMainCollection, taskMatcher);

            foreach (ITask taskMain in taskMainCollection)
            {
                if (taskMain.MatchedTasks.Count > 0)
                {
                    List<ITask> matchedTasks = new List<ITask>();
                    matchedTasks.Add(taskMain);
                    matchedTasks.AddRange(taskMain.MatchedTasks);
                    IEnumerable<Disagreement> disagreements = TaskMain.GetDisagreements(matchedTasks);
                    foreach (ITask matchedTask in matchedTasks)
                    {
                        matchedTask.AddDisagreementCollection(disagreements);
                    }
                }
            }
        }
    }
}
