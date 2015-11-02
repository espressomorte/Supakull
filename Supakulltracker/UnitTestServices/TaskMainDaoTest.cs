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
            TaskMainDAO taskMainDAO1 = new TaskMainDAO() { TaskID = "Task1", LinkToTracker = "Tracker1" };
            TaskMainDAO taskMainDAO2 = new TaskMainDAO() { TaskID = "Task2", LinkToTracker = "Tracker2" };
            TaskMainDAO taskMainDAO3 = new TaskMainDAO() { TaskID = "Task3", LinkToTracker = "Tracker1" };
            UserDAO userDAO1 = new UserDAO() { UserId = "user1", UserName = "user name 1" };
            UserDAO userDAO2 = new UserDAO() { UserId = "user2", UserName = "user name 2" };
            taskMainDAO1.MatchedTasks.Add(taskMainDAO2);
            taskMainDAO2.MatchedTasks.Add(taskMainDAO1);
            taskMainDAO1.Assigned.Add(userDAO1);
            taskMainDAO1.Assigned.Add(userDAO2);
            taskMainDAO3.TaskParent = taskMainDAO1;
            taskMainDaoCollection.Add(taskMainDAO1);
            taskMainDaoCollection.Add(taskMainDAO2);
            taskMainDaoCollection.Add(taskMainDAO3);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }

        [TestMethod]
        public void SaveOrUpdateCollectionInDB_Test2()
        {
            IList<TaskMainDAO> taskMainDaoCollection = new List<TaskMainDAO>();
            TaskMainDAO taskMainDAO1 = new TaskMainDAO() { TaskID = null, LinkToTracker = "Tracker1" };
            TaskMainDAO taskMainDAO2 = new TaskMainDAO() { TaskID = "Task1", LinkToTracker = "Tracker1", Summary = "Summary1" };
            TaskMainDAO taskMainDAO3 = new TaskMainDAO() { TaskID = "Task1", LinkToTracker = "Tracker1", Summary = "Summary2" };
            TaskMainDAO taskMainDAO4 = new TaskMainDAO() { TaskID = "Task1", LinkToTracker = "Tracker2" };
            TaskMainDAO taskMainDAO5 = new TaskMainDAO() { TaskID = "Task2", LinkToTracker = "Tracker1" };
            taskMainDaoCollection.Add(taskMainDAO1);
            taskMainDaoCollection.Add(taskMainDAO2);
            taskMainDaoCollection.Add(taskMainDAO3);
            taskMainDaoCollection.Add(taskMainDAO4);
            taskMainDaoCollection.Add(taskMainDAO5);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }
    }
}
