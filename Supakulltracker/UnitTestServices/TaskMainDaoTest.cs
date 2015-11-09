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
            taskMainDAO1.MatchedTasks.Add(taskMainDAO2);
            taskMainDAO2.MatchedTasks.Add(taskMainDAO1);
            taskMainDAO1.Assigned.Add(userDAO11);
            taskMainDAO1.Assigned.Add(userDAO12);
            taskMainDAO2.Assigned.Add(userDAO12);
            taskMainDAO2.Assigned.Add(userDAO11);
            taskMainDAO1.TaskParent = taskMainDAO3;

            taskMainDaoCollection.Add(taskMainDAO1);
            taskMainDaoCollection.Add(taskMainDAO2);
            taskMainDaoCollection.Add(taskMainDAO3);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }

        [TestMethod]
        public void SaveOrUpdateCollectionInDB_Test2()
        {
            IList<TaskMainDAO> taskMainDaoCollection = new List<TaskMainDAO>();
            TaskMainDAO taskMainDAO1 = new TaskMainDAO() { TaskID = null, LinkToTracker = Sources.DataBase };
            TaskMainDAO taskMainDAO2 = new TaskMainDAO() { TaskID = "Task21", LinkToTracker = Sources.DataBase, Summary = "Summary21" };
            TaskMainDAO taskMainDAO3 = new TaskMainDAO() { TaskID = "Task21", LinkToTracker = Sources.DataBase, Summary = "Summary22" };
            TaskMainDAO taskMainDAO4 = new TaskMainDAO() { TaskID = "Task21", LinkToTracker = Sources.Excel };
            TaskMainDAO taskMainDAO5 = new TaskMainDAO() { TaskID = "Task22", LinkToTracker = Sources.DataBase };
            taskMainDaoCollection.Add(taskMainDAO1);
            taskMainDaoCollection.Add(taskMainDAO2);
            taskMainDaoCollection.Add(taskMainDAO3);
            taskMainDaoCollection.Add(taskMainDAO4);
            taskMainDaoCollection.Add(taskMainDAO5);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }

        [TestMethod]
        public void SaveOrUpdateCollectionInDB_Disagreements()
        {
            
            IList<DisagreementDAO> disagreementCollection1 = new List<DisagreementDAO>();
            DisagreementDAO disagreement1 = new DisagreementDAO() { FieldName = "Summary" };
            DisagreementDAO disagreement2 = new DisagreementDAO() { FieldName = "Priority" };
            disagreementCollection1.Add(disagreement1);
            disagreementCollection1.Add(disagreement2);

            IList<DisagreementDAO> disagreementCollection2 = new List<DisagreementDAO>();
            DisagreementDAO disagreement3 = new DisagreementDAO() { FieldName = "Summary" };
            DisagreementDAO disagreement4 = new DisagreementDAO() { FieldName = "Priority" };
            disagreementCollection2.Add(disagreement3);
            disagreementCollection2.Add(disagreement4);

            TaskMainDAO taskMainDAO1 = new TaskMainDAO() { TaskID = "Task31", LinkToTracker = Sources.DataBase, Disagreements = disagreementCollection1 };
            disagreement1.TaskMainDaoLinked = taskMainDAO1;
            disagreement2.TaskMainDaoLinked = taskMainDAO1;

            TaskMainDAO taskMainDAO2 = new TaskMainDAO() { TaskID = "Task31", LinkToTracker = Sources.GoogleSheets, Disagreements = disagreementCollection2 };
            disagreement3.TaskMainDaoLinked = taskMainDAO2;
            disagreement4.TaskMainDaoLinked = taskMainDAO2;

            IList<TaskMainDAO> taskMainDaoCollection = new List<TaskMainDAO>();
            taskMainDaoCollection.Add(taskMainDAO1);
            taskMainDaoCollection.Add(taskMainDAO2);

            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }
    }
}
