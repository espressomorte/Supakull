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

        static ConverterDomainToDAO()
        {
            taskMainDaoCollection = new Dictionary<TaskKey, TaskMainDAO>();
            userDaoCollection = new Dictionary<UserKey, UserDAO>();
        }

        public static IList<TaskMainDAO> TaskMainToTaskMainDAO(IList<ITask> TaskMainCollection)
        {
            List<TaskMainDAO> target = new List<TaskMainDAO>();  
            foreach (ITask taskMain in TaskMainCollection)
            {
                TaskMainDAO taskMainDAO = TaskMainToTaskMainDAO(taskMain);
                target.Add(taskMainDAO);
            }
            return target;
        }

        private static TaskMainDAO TaskMainToTaskMainDAO(ITask taskMain)
        {            
            TaskMainDAO taskMainDAO = TaskMainToTaskMainDAOWithoutMatchedTasks(taskMain);
            if (taskMain.MatchedCount > 0)
            {
                IList<TaskMainDAO> matchedTasksDAO = GetMatchedTasksDAO(taskMain.MatchedTasks, taskMainDAO);
                taskMainDAO.MatchedTasks = matchedTasksDAO;
            }
            return taskMainDAO;
        }

        private static TaskMainDAO TaskMainToTaskMainDAOWithoutMatchedTasks(ITask taskMain)
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
                taskMainDAO.TokenID = taskMain.TokenID;

                if (taskMain.TaskParent != null)
                {
                    taskMainDAO.TaskParent = TaskMainToTaskMainDAO(taskMain.TaskParent);
                }

                if (taskMain.Assigned != null && taskMain.Assigned.Count > 0)
                {
                    taskMainDAO.Assigned = UserToUserDAO(taskMain.Assigned);
                }

                taskMainDaoCollection.Add(taskKey, taskMainDAO);
            }
            if (taskMainDAO != null)
            {
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

                if (taskMain.TaskParent != null)
                {
                    taskMainDAO.TaskParent = TaskMainToTaskMainDAO(taskMain.TaskParent);
                }

                if (taskMain.Assigned != null && taskMain.Assigned.Count > 0)
                {
                    taskMainDAO.Assigned = UserToUserDAO(taskMain.Assigned);
                }
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
                TaskMainDAO matchedTaskDAO = TaskMainToTaskMainDAOWithoutMatchedTasks(matchedTask);
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

        public static IList<UserDAO> UserToUserDAO(IList<User> user)
        {
            IList<UserDAO> userDAO = new List<UserDAO>();
            foreach (User item in user)
            {    
                userDAO.Add(UserToUserDAO(item));
            }
            return userDAO;
        }

        private static UserDAO UserToUserDAO(User user)
        {
            UserKey userKey = user.GetUserKey();
            UserDAO userDAO = GetExistingUserDAO(userKey);
            if (userDAO == null)
            {
                userDAO = new UserDAO(user.UserID ,user.UserLogin);
                userDaoCollection.Add(userKey, userDAO);
            }
            return userDAO;
        }

        private static UserDAO GetExistingUserDAO(UserKey userKey)
        {
            UserDAO existedUserDAO = null;
            userDaoCollection.TryGetValue(userKey, out existedUserDAO);
            return existedUserDAO;
        }

    }
}