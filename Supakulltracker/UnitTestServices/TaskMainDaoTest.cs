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
            TaskMainDAO taskMainDAO4 = new TaskMainDAO() { TaskID = "Task13", LinkToTracker = Sources.Excel };
            UserDAO userDAO1 = new UserDAO("user11");
            UserDAO userDAO2 = new UserDAO("user12");
            UserDAO userDAO3 = new UserDAO("user11");
            UserDAO userDAO4 = new UserDAO("user12");
            taskMainDAO1.MatchedTasks.Add(taskMainDAO2);
            taskMainDAO2.MatchedTasks.Add(taskMainDAO1);
            taskMainDAO3.MatchedTasks.Add(taskMainDAO4);
            taskMainDAO4.MatchedTasks.Add(taskMainDAO3);
            taskMainDAO1.Assigned.Add(userDAO1);
            taskMainDAO1.Assigned.Add(userDAO2);
            taskMainDAO2.Assigned.Add(userDAO1);
            taskMainDAO2.Assigned.Add(userDAO2);
            taskMainDAO1.TaskParent = taskMainDAO3;

            taskMainDaoCollection.Add(taskMainDAO3);
            taskMainDaoCollection.Add(taskMainDAO1);
            taskMainDaoCollection.Add(taskMainDAO2);
            taskMainDaoCollection.Add(taskMainDAO4);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }

        [TestMethod]
        public void SaveOrUpdateCollectionInDB_Test2()
        {
            IList<ITask> taskMainCollection = new List<ITask>();
            ITask taskMainParent1 = new TaskMain() { TaskID = "TaskParent1", LinkToTracker = Sources.DataBase };
            ITask taskMainParent2 = new TaskMain() { TaskID = "TaskParent1", LinkToTracker = Sources.Trello };
            //User user1 = new User("user1");
            //User user2 = new User("user2");
            //IList<User> assigned1 = new List<User>() { user1, user2 };
            //IList<User> assigned2 = new List<User>() { user2, user1 };

            ITask taskMain1 = new TaskMain()
            { TaskID = "Task1", SubtaskType = "a", Summary = null, Description = "cc", Status = "e", LinkToTracker = Sources.DataBase, TaskParent = taskMainParent1/*, Assigned = assigned2*/};
            ITask taskMain2 = new TaskMain()
            { TaskID = "Task1", SubtaskType = "a", Summary = null, Description = "cc", Status = "f", LinkToTracker = Sources.Trello, TaskParent = taskMainParent2, Assigned = null };
            //ITask taskMain3 = new TaskMain()
            //{ TaskID = "Task1", SubtaskType = "a", Summary = "b", Description = "d", Status = "g", LinkToTracker = Sources.Excel, TaskParent = taskMainParent1, Assigned = assigned1 };
            //ITask taskMain4 = new TaskMain()
            //{ TaskID = "TaskParent3", LinkToTracker = Sources.GoogleSheets };

            taskMainCollection.Add(taskMain1);
            taskMainCollection.Add(taskMain2);
            taskMainCollection.Add(taskMainParent1);
            taskMainCollection.Add(taskMainParent2);
            //taskMainCollection.Add(taskMain3);
            //taskMainCollection.Add(taskMain4);

            IMatchTasks taskMatcher = new MatchTasksById();
            TaskMain.MatchTasks(taskMainCollection, taskMatcher);

            IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDaoCollection(taskMainCollection);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }
    }
}
