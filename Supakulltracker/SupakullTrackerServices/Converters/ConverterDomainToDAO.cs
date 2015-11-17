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
        private static IDictionary<TaskKey, TaskMainDAO> taskMainDaoCollection;
        private static IDictionary<UserKey, UserDAO> userDaoCollection;

        public static IList<TaskMainDAO> TaskMainToTaskMainDao(IList<ITask> TaskMainCollection)
        {
            List<TaskMainDAO> target = new List<TaskMainDAO>();
            taskMainDaoCollection = new Dictionary<TaskKey, TaskMainDAO>();
            userDaoCollection = new Dictionary<UserKey, UserDAO>();

            foreach (ITask taskMain in TaskMainCollection)
            {
                TaskMainDAO taskMainDAO = TaskMainToTaskMainDaoWithMatchedTasks(taskMain);
                target.Add(taskMainDAO);
            }
            return target;
        }

        private static TaskMainDAO TaskMainToTaskMainDaoWithMatchedTasks(ITask taskMain)
        {            
            TaskMainDAO taskMainDAO = TaskMainToTaskMainDAO(taskMain);
            if (taskMain.MatchedCount > 0)
            {
                IList<TaskMainDAO> matchedTasksDAO = GetMatchedTasksDAO(taskMain.MatchedTasks, taskMainDAO);
                taskMainDAO.MatchedTasks = matchedTasksDAO;
            }
            return taskMainDAO;
        }

        private static TaskMainDAO TaskMainToTaskMainDAO(ITask taskMain)
        {
            TaskKey taskKey = taskMain.GetTaskKey();
            TaskMainDAO taskMainDAO = GetExistingTaskDAO(taskKey);
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

                if (taskMain.TaskParent != null)
                {
                    taskMainDAO.TaskParent = TaskMainToTaskMainDaoWithMatchedTasks(taskMain.TaskParent);
                }

                if (taskMain.Assigned != null && taskMain.Assigned.Count > 0)
                {
                    taskMainDAO.Assigned = UserToUserDao(taskMain.Assigned);
                }

                taskMainDaoCollection.Add(taskKey, taskMainDAO);
            }           
            return taskMainDAO;
        }

        private static TaskMainDAO GetExistingTaskDAO(TaskKey taskKey)
        {
            TaskMainDAO existedTaskMainDAO = null;
            taskMainDaoCollection.TryGetValue(taskKey, out existedTaskMainDAO);
            return existedTaskMainDAO;
        }

        private static IList<TaskMainDAO> GetMatchedTasksDAO(IEnumerable<ITask> matchedTasks, TaskMainDAO itemDAO)
        {
            List<TaskMainDAO> matchedTasksDAO = new List<TaskMainDAO>();
            foreach (ITask matchedTask in matchedTasks)
            {
                TaskMainDAO matchedTaskDAO = TaskMainToTaskMainDAO(matchedTask);
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

        public static IList<UserDAO> UserToUserDao(IList<User> user)
        {
            IList<UserDAO> userDAO = new List<UserDAO>();
            foreach (User item in user)
            {    
                userDAO.Add(UserToUserDao(item));
            }
            return userDAO;
        }

        private static UserDAO UserToUserDao(User user)
        {
            UserKey userKey = user.GetUserKey();
            UserDAO userDAO = GetExistingUserDAO(userKey);
            if (userDAO == null)
            {
                userDAO = new UserDAO(user.UserId);
                userDaoCollection.Add(userKey, userDAO);
            }
            return userDAO;
        }

        private static UserDAO GetExistingUserDAO(UserKey userKey)
        {
            UserDAO existedUserMainDAO = null;
            userDaoCollection.TryGetValue(userKey, out existedUserMainDAO);
            return existedUserMainDAO;
        }
    }
}