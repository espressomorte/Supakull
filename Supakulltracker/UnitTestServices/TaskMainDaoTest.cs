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
            User user1 = new User("user1");
            User user2 = new User("user2");
            IList<User> assigned1 = new List<User>() { user1, user2 };
            IList<User> assigned2 = new List<User>() { user2, user1 };

            ITask taskMain1 = new TaskMain()
            { TaskID = "Task1", SubtaskType = "a", Summary = null, Description = "cc", Status = "e", LinkToTracker = Sources.DataBase, TaskParent = taskMainParent1, Assigned = assigned1 };
            ITask taskMain2 = new TaskMain()
            { TaskID = "Task1", SubtaskType = "a", Summary = null, Description = "cc", Status = "f", LinkToTracker = Sources.Trello, TaskParent = taskMainParent2, Assigned = assigned2 };
            ITask taskMain3 = new TaskMain()
            { TaskID = "Task1", SubtaskType = "a", Summary = "b", Description = "d", Status = "g", LinkToTracker = Sources.Excel, TaskParent = null, Assigned = assigned1 };
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

            IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDao(taskMainCollection);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }
        
        [TestMethod]
        public void SaveOrUpdateCollectionInDB_Test3()
        {
            User user1 = new User("user1");
            User user2 = new User("user2");
            IList<User> assigned1 = new List<User>() { user1, user2 };
            IList<User> assigned2 = new List<User>() { user2, user1 };

            ITask taskMainParent1 = new TaskMain()
            {
                TaskID = "TaskParent1",
                SubtaskType = "fhdhfd",
                Summary = "1MOL - Patient Group - Pedigree chart - Dupligcation of patients after press 'Rebuild' in read mode",
                Description = @"6MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - Patient Group
Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - Patient 
Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - 
Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Status = "Impletmented",
                Priority = "urgrent",
                Product = "SoftMol",
                Project = "12345d67789",
                CreatedDate = "1x2121212",
                CreatedBy = "fgceg",
                LinkToTracker = Sources.DataBase,
                Estimation = "121v21212",
                TargetVersion = "5634n3276",
                Comments = "1Pedigree chart - Duplication of patients after press",
                TaskParent = null,
                Assigned = assigned1
            };

            ITask taskMainParent2 = new TaskMain()
            {
                TaskID = "TaskParent1",
                SubtaskType = "fhdhfd",
                Summary = "2MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Description = @"5MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode
Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - Patient 
Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - 
Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Status = "Implemenlted",
                Priority = "urgjent",
                Product = "SofgtMol",
                Project = "1234d567789",
                CreatedDate = "121s21212",
                CreatedBy = "fgseg",
                LinkToTracker = Sources.Trello,
                Estimation = "1212c1212",
                TargetVersion = "5e6343276",
                Comments = "2Pedigree chart - Duplication of patients after press",
                TaskParent = null,
                Assigned = null
            };

            ITask taskMainParent3 = new TaskMain()
            {
                TaskID = "TaskParent1",
                SubtaskType = "fhdhfd",
                Summary = "3MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Description = @"4MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode
Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - Patient 
Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - 
Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Status = "Implemfented",
                Priority = "urggfent",
                Product = "Soft4Mol",
                Project = "12345567789",
                CreatedDate = "121t21212",
                CreatedBy = "fgfceg",
                LinkToTracker = Sources.Excel,
                Estimation = "121j21212",
                TargetVersion = "563k43276",
                Comments = "3Pedigree chart - Duplication of patients after press",
                TaskParent = null,
                Assigned = assigned2
            };

            ITask taskMain1 = new TaskMain()
            {
                TaskID = "Task1",
                SubtaskType = "fhdhfd",
                Summary = "4MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Description = @"3MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode
Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - Patient 
Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - 
Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Status = "Impleemented",
                Priority = "urdgent",
                Product = "SofdtMol",
                Project = "123x4567789",
                CreatedDate = "121c21212",
                CreatedBy = "fgveg",
                LinkToTracker = Sources.DataBase,
                Estimation = "121b21212",
                TargetVersion = "563nu43276",
                Comments = "4Pedi7gree chart - Duplication of patients after press",
                TaskParent = taskMainParent1,
                Assigned = assigned1
            };

            ITask taskMain2 = new TaskMain()
            {
                TaskID = "Task1",
                SubtaskType = "fhdhfd",
                Summary = "5MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Description = @"2MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read modePedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - Patient 
Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - 
Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Status = "Implemfented",
                Priority = "urghent",
                Product = "SofgtMol",
                Project = "123456j7789",
                CreatedDate = "1212k1212",
                CreatedBy = "fgleg",
                LinkToTracker = Sources.Trello,
                Estimation = "12121;212",
                TargetVersion = "5634'3276",
                Comments = "5Pedigree chart - Duplication of patients after press",
                TaskParent = taskMainParent2,
                Assigned = null
            };

            ITask taskMain3 = new TaskMain()
            {
                TaskID = "Task1",
                SubtaskType = "fhdhfd",
                Summary = "6MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Description = @"1MOL - Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode
Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - Patient 
Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode6MOL - 
Patient Group - Pedigree chart - Duplication of patients after press 'Rebuild' in read mode",
                Status = "Imp3lemented",
                Priority = "urg4ent",
                Product = "SoftM5ol",
                Project = "12345667789",
                CreatedDate = "121721212",
                CreatedBy = "fg8eg",
                LinkToTracker = Sources.Excel,
                Estimation = "121291212",
                TargetVersion = "563403276",
                Comments = "6Pedigree chart - Duplication of patients after press",
                TaskParent = taskMainParent3,
                Assigned = assigned2
            };

            IList<ITask> taskMainCollection = new List<ITask>();
            taskMainCollection.Add(taskMain1);
            taskMainCollection.Add(taskMain2);
            taskMainCollection.Add(taskMain3);
            taskMainCollection.Add(taskMainParent1);
            taskMainCollection.Add(taskMainParent2);
            taskMainCollection.Add(taskMainParent3);

            IMatchTasks taskMatcher = new MatchTasksById();
            TaskMain.MatchTasks(taskMainCollection, taskMatcher);

            IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDao(taskMainCollection);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);

            GetTrackerServices services = new GetTrackerServices();
            TaskMainDTO taskMainDTO = services.GetTask("Task1", Sources.DataBase);
        }
    }
}
