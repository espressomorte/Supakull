using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupakullTrackerServices;

namespace UnitTestServices
{
    [TestClass]
    public class TaskMainDaoTest
    {
        [TestMethod]
        public void SaveOrUpdateCollectionInDB_Test1()
        {
            IList<TaskMainDAO> taskMainDaoCollection = new List<TaskMainDAO>();
            TaskMainDAO taskMainDAO1 = new TaskMainDAO() { TaskID = "Task11", LinkToTracker = Sources.DataBase };
            TaskMainDAO taskMainDAO2 = new TaskMainDAO() { TaskID = "Task11", LinkToTracker = Sources.Excel };
            TaskMainDAO taskMainDAO3 = new TaskMainDAO() { TaskID = "Task13", LinkToTracker = Sources.DataBase };
            UserDAO userDAO11 = new UserDAO("user11", "user name 11");
            UserDAO userDAO12 = new UserDAO("user12", "user name 12");
            UserDAO userDAO13 = new UserDAO("user11", "user name 11");
            UserDAO userDAO14 = new UserDAO("user12", "user name 12");
            taskMainDAO1.MatchedTasks.Add(taskMainDAO2);
            taskMainDAO2.MatchedTasks.Add(taskMainDAO1);
            taskMainDAO1.Assigned.Add(userDAO11);
            taskMainDAO1.Assigned.Add(userDAO12);
            taskMainDAO2.Assigned.Add(userDAO13);
            taskMainDAO2.Assigned.Add(userDAO14);
            taskMainDAO1.TaskParent = taskMainDAO3;

            taskMainDaoCollection.Add(taskMainDAO1);
            taskMainDaoCollection.Add(taskMainDAO2);
            taskMainDaoCollection.Add(taskMainDAO3);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }

        [TestMethod]
        public void SaveOrUpdateCollectionInDB_Test2()
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

            IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDaoCollection(taskMainCollection);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }
    }
}
