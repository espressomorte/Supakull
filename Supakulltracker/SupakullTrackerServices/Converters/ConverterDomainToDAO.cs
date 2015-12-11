using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public static class ConverterDomainToDAO
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private static IDictionary<TaskKey, TaskMainDAO> taskMainDaoCollection;
        //private static IDictionary<UserKey, UserDAO> userDaoCollection;

        //static ConverterDomainToDAO()
        //{
        //    FillTaskMainDaoCollectionFromDB();
        //    FilluserDaoCollectionFromDB();
        //}

        //private static void FillTaskMainDaoCollectionFromDB()
        //{
        //    taskMainDaoCollection = new Dictionary<TaskKey, TaskMainDAO>();
        //    IList<TaskMainDAO> allTasks = TaskMainDAO.GetAllTasksFromDB();
        //    foreach (TaskMainDAO task in allTasks)
        //    {
        //        taskMainDaoCollection.Add(task.GetTaskKey(), task);
        //    }
        //}

        //private static void FilluserDaoCollectionFromDB()
        //{
        //    userDaoCollection = new Dictionary<UserKey, UserDAO>();
        //    IList<UserDAO> allTasks = UserDAO.GetAllUsersFromDB();
        //    foreach (UserDAO user in allTasks)
        //    {
        //        userDaoCollection.Add(user.GetUserKey(), user);
        //    }
        //}

        public static IList<TaskMainDAO> TaskMainToTaskMainDAO(IList<ITask> TaskMainCollection)
        {
            if (TaskMainCollection == null)
            {
                return null;
            }

            IDictionary<TaskKey, TaskMainDAO> taskMainDaoCollection = new Dictionary<TaskKey, TaskMainDAO>();
            IDictionary<UserKey, UserDAO> userDaoCollection = new Dictionary<UserKey, UserDAO>();

            List<TaskMainDAO> target = new List<TaskMainDAO>();  
            foreach (ITask taskMain in TaskMainCollection)
            {
                TaskMainDAO taskMainDAO = TaskMainToTaskMainDAO(taskMain, taskMainDaoCollection, userDaoCollection);
                target.Add(taskMainDAO);
            }
            return target;
        }

        private static TaskMainDAO TaskMainToTaskMainDAO(ITask taskMain, IDictionary<TaskKey, TaskMainDAO> taskMainDaoCollection, IDictionary<UserKey, UserDAO> userDaoCollection)
        {
            //List<TaskMainDAO> matchedTasksInDB = CheckMatchTasksInDataBase(taskMain);           
            TaskMainDAO taskMainDAO = TaskMainToTaskMainDAOWithoutMatchedTasks(taskMain, taskMainDaoCollection, userDaoCollection);      
            if (taskMain.MatchedCount > 0)
            {
                IList<TaskMainDAO> matchedTasksDAO = GetMatchedTasksDAO(taskMain.MatchedTasks, taskMainDAO, taskMainDaoCollection, userDaoCollection);
                taskMainDAO.MatchedTasks = matchedTasksDAO;
            }
            //if (matchedTasksInDB != null)
            //{
            //    taskMainDAO.MatchedTasks = matchedTasksInDB;
            //}
            return taskMainDAO;
        }

        private static TaskMainDAO TaskMainToTaskMainDAOWithoutMatchedTasks(ITask taskMain, IDictionary<TaskKey, TaskMainDAO> taskMainDaoCollection, IDictionary<UserKey, UserDAO> userDaoCollection)
        {
            TaskKey taskKey = taskMain.GetTaskKey();
            TaskMainDAO taskMainDAO = GetExistingTaskDAO(taskKey, taskMainDaoCollection);
            if (taskMainDAO == null)
            {
                taskMainDAO = new TaskMainDAO();

                taskMainDAO.TaskID = taskMain.TaskID;
                taskMainDAO.TargetVersion = taskMain.TargetVersion;
                taskMainDAO.Summary = taskMain.Summary;
                taskMainDAO.SubtaskType = taskMain.SubtaskType;
                taskMainDAO.Status = taskMain.Status;
                taskMainDAO.Project = taskMain.Project;
                taskMainDAO.Product = taskMain.Product;
                taskMainDAO.Priority = taskMain.Priority;
                taskMainDAO.LinkToTracker = taskMain.LinkToTracker;
                taskMainDAO.Estimation = taskMain.Estimation;
                taskMainDAO.Description = taskMain.Description;
                taskMainDAO.CreatedDate = taskMain.CreatedDate;
                taskMainDAO.CreatedBy = taskMain.CreatedBy;
                taskMainDAO.Comments = taskMain.Comments;
                taskMainDAO.TokenID = taskMain.TokenID;
                taskMainDAO.Source = taskMain.Source;

                if (taskMain.TaskParent != null)
                {
                    taskMainDAO.TaskParent = TaskMainToTaskMainDAO(taskMain.TaskParent, taskMainDaoCollection, userDaoCollection);
                }

                if (taskMain.Assigned != null && taskMain.Assigned.Count > 0)
                {
                    taskMainDAO.Assigned = UserToUserDAO(taskMain.Assigned, userDaoCollection);
                }

                taskMainDaoCollection.Add(taskKey, taskMainDAO);
            }
            //if (taskMainDAO != null)
            //{
            //    taskMainDAO.TaskID = taskMain.TaskID;
            //    taskMainDAO.TargetVersion = taskMain.TargetVersion;
            //    taskMainDAO.Summary = taskMain.Summary;
            //    taskMainDAO.SubtaskType = taskMain.SubtaskType;
            //    taskMainDAO.Status = taskMain.Status;
            //    taskMainDAO.Project = taskMain.Project;
            //    taskMainDAO.Product = taskMain.Product;
            //    taskMainDAO.Priority = taskMain.Priority;
            //    taskMainDAO.LinkToTracker = taskMain.LinkToTracker;
            //    taskMainDAO.Estimation = taskMain.Estimation;
            //    taskMainDAO.Description = taskMain.Description;
            //    taskMainDAO.CreatedDate = taskMain.CreatedDate;
            //    taskMainDAO.CreatedBy = taskMain.CreatedBy;
            //    taskMainDAO.Comments = taskMain.Comments;
            //    taskMainDAO.TokenID = taskMain.TokenID;
            //    taskMainDAO.Source = taskMain.Source;

            //    if (taskMain.TaskParent != null)
            //    {
            //        taskMainDAO.TaskParent = TaskMainToTaskMainDAO(taskMain.TaskParent);
            //    }

            //    if (taskMain.Assigned != null && taskMain.Assigned.Count > 0)
            //    {
            //        taskMainDAO.Assigned = UserToUserDAO(taskMain.Assigned);
            //    }
            //}
            return taskMainDAO;
        }

        //private static List<TaskMainDAO> CheckMatchTasksInDataBase(ITask taskMainDAO)
        //{
        //    List<TaskMainDAO> matchedTasks = null;
        //    matchedTasks = (from KeyValue in taskMainDaoCollection
        //                              where KeyValue.Key.TaskID == taskMainDAO.TaskID
        //                              select KeyValue.Value).ToList<TaskMainDAO>();
                     
        //    return matchedTasks;            
        //}
        private static TaskMainDAO GetExistingTaskDAO(TaskKey taskKey, IDictionary<TaskKey, TaskMainDAO> taskMainDaoCollection)
        {
            TaskMainDAO existedTaskMainDAO = null;
            taskMainDaoCollection.TryGetValue(taskKey, out existedTaskMainDAO);
            return existedTaskMainDAO;
        }

        private static IList<TaskMainDAO> GetMatchedTasksDAO(IEnumerable<ITask> matchedTasks, TaskMainDAO itemDAO, IDictionary<TaskKey, TaskMainDAO> taskMainDaoCollection, IDictionary<UserKey, UserDAO> userDaoCollection)
        {
            List<TaskMainDAO> matchedTasksDAO = new List<TaskMainDAO>();
            foreach (ITask matchedTask in matchedTasks)
            {
                TaskMainDAO matchedTaskDAO = TaskMainToTaskMainDAOWithoutMatchedTasks(matchedTask, taskMainDaoCollection, userDaoCollection);
                matchedTasksDAO.Add(matchedTaskDAO);
            }
            foreach (TaskMainDAO currentTask in matchedTasksDAO)
            {
                List<TaskMainDAO> collectionForCurrentTask = new List<TaskMainDAO>(matchedTasksDAO);
                collectionForCurrentTask.Remove(currentTask);
                collectionForCurrentTask.Add(itemDAO);
                currentTask.MatchedTasks = collectionForCurrentTask;
            }
            return matchedTasksDAO;
        }

        private static IList<UserDAO> UserToUserDAO(IList<User> user, IDictionary<UserKey, UserDAO> userDaoCollection)
        {
            IList<UserDAO> userDAO = new List<UserDAO>();
            foreach (User item in user)
            {    
                userDAO.Add(UserToUserDAO(item, userDaoCollection));
            }
            return userDAO;
        }

        private static UserDAO UserToUserDAO(User user, IDictionary<UserKey, UserDAO> userDaoCollection)
        {
            UserKey userKey = user.GetUserKey();
            UserDAO userDAO = GetExistingUserDAO(userKey, userDaoCollection);
            if (userDAO == null)
            {
                userDAO = new UserDAO(user.UserID ,user.UserLogin);
                userDaoCollection.Add(userKey, userDAO);
            }
            return userDAO;
        }

        private static UserDAO GetExistingUserDAO(UserKey userKey, IDictionary<UserKey, UserDAO> userDaoCollection)
        {
            UserDAO existedUserDAO = null;
            userDaoCollection.TryGetValue(userKey, out existedUserDAO);
            return existedUserDAO;
        }

    }
}