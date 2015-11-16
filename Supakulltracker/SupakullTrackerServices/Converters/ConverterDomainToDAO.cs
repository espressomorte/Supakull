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
        private static IDictionary<TaskKay, TaskMainDAO> taskMainDaoCollection;
        private static IDictionary<UserKay, UserDAO> userDaoCollection;

        public static IList<TaskMainDAO> TaskMainToTaskMainDao(IList<ITask> TaskMainCollection)
        {
            List<TaskMainDAO> target = new List<TaskMainDAO>();
            taskMainDaoCollection = new Dictionary<TaskKay, TaskMainDAO>();
            userDaoCollection = new Dictionary<UserKay, UserDAO>();

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
            TaskKay taskKay = taskMain.GetTaskKay();
            TaskMainDAO taskMainDAO = GetExistingTaskDAO(taskKay);
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

                taskMainDaoCollection.Add(taskKay, taskMainDAO);
            }           
            return taskMainDAO;
        }

        private static TaskMainDAO GetExistingTaskDAO(TaskKay taskKay)
        {
            TaskMainDAO existedTaskMainDAO = null;
            taskMainDaoCollection.TryGetValue(taskKay, out existedTaskMainDAO);
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
            UserKay userKay = user.GetUserKay();
            UserDAO userDAO = GetExistingUserDAO(userKay);
            if (userDAO == null)
            {
                userDAO = new UserDAO(user.UserId);
                userDaoCollection.Add(userKay, userDAO);
            }
            return userDAO;
        }

        private static UserDAO GetExistingUserDAO(UserKay userKay)
        {
            UserDAO existedUserMainDAO = null;
            userDaoCollection.TryGetValue(userKay, out existedUserMainDAO);
            return existedUserMainDAO;
        }
    }
}