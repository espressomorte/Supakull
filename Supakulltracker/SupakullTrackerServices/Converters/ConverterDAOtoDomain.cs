using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public static class ConverterDAOtoDomain
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static IDictionary<TaskKey, ITask> taskMainCollection;
        private static IDictionary<UserKey, User> userCollection;

        public static IList<ITask> TaskMainDaoToTaskMain(IList<TaskMainDAO> TaskMainDaoCollection)
        {
            List<ITask> target = new List<ITask>();
            taskMainCollection = new Dictionary<TaskKey, ITask>();
            userCollection = new Dictionary<UserKey, User>();

            foreach (TaskMainDAO taskMainDAO in TaskMainDaoCollection)
            {
                ITask taskMain = TaskMainDaoToTaskMainWithMatchedTasks(taskMainDAO);
                target.Add(taskMain);
            }
            return target;
        }

        private static ITask TaskMainDaoToTaskMainWithMatchedTasks(TaskMainDAO taskMainDAO)
        {
            ITask taskMain = TaskMainDaoToTaskMain(taskMainDAO);
            if (taskMainDAO.MatchedCount > 0)
            {
                IList<ITask> matchedTasks = GetMatchedTasks(taskMainDAO.MatchedTasks, taskMain);
                taskMain.MatchedTasks = matchedTasks;
            }
            return taskMain;
        }

        private static ITask TaskMainDaoToTaskMain(TaskMainDAO taskMainDAO)
        {
            TaskKey taskKey = taskMainDAO.GetTaskKey();
            ITask taskMain = GetExistingTask(taskKey);
            if (taskMain == null)
            {
                taskMain = new TaskMain();

                taskMain.TaskID = taskMainDAO.TaskID;
                taskMain.TargetVersion = taskMainDAO.TargetVersion;
                taskMain.Summary = taskMainDAO.Summary;
                taskMain.SubtaskType = taskMainDAO.SubtaskType;
                taskMain.Status = taskMainDAO.Status;
                taskMain.Project = taskMainDAO.Project;
                taskMain.Product = taskMainDAO.Product;
                taskMain.Priority = taskMainDAO.Priority;
                taskMain.LinkToTracker = taskMainDAO.LinkToTracker;
                taskMain.Estimation = taskMainDAO.Estimation;
                taskMain.Description = taskMainDAO.Description;
                taskMain.CreatedDate = taskMainDAO.CreatedDate;
                taskMain.CreatedBy = taskMainDAO.CreatedBy;
                taskMain.Comments = taskMainDAO.Comments;

                if (taskMainDAO.TaskParent != null)
                {
                    taskMain.TaskParent = TaskMainDaoToTaskMainWithMatchedTasks(taskMainDAO.TaskParent);
                }

                if (taskMainDAO.Assigned != null && taskMainDAO.Assigned.Count > 0)
                {
                    taskMain.Assigned = UserDaoToUser(taskMainDAO.Assigned);
                }

                taskMainCollection.Add(taskKey, taskMain);
            }
            return taskMain;
        }

        private static ITask GetExistingTask(TaskKey taskKey)
        {
            ITask existedTaskMain = null;
            taskMainCollection.TryGetValue(taskKey, out existedTaskMain);
            return existedTaskMain;
        }

        private static IList<ITask> GetMatchedTasks(IEnumerable<TaskMainDAO> matchedTasksDAO, ITask item)
        {
            List<ITask> matchedTasks = new List<ITask>();
            foreach (TaskMainDAO matchedTaskDAO in matchedTasksDAO)
            {
                ITask matchedTask = TaskMainDaoToTaskMain(matchedTaskDAO);
                matchedTasks.Add(matchedTask);
            }
            foreach (ITask currentTask in matchedTasks)
            {
                List<ITask> collectionForCurrentTask = new List<ITask>(matchedTasks);
                collectionForCurrentTask.Remove(currentTask);
                collectionForCurrentTask.Add(item);
                currentTask.MatchedTasks = collectionForCurrentTask;
            }
            return matchedTasks;
        }
        //////////////////////

        public static IList<User> UserDaoToUser(IList<UserDAO> userDAO)
        {
            IList<User> user = new List<User>();
            foreach (UserDAO item in userDAO)
            {
                user.Add(UserDaoToUser(item));
            }
            return user;
        }

        private static UserDAO UserDaoToUser(UserDAO userDAO)
        {
            UserKey userKey = user.GetUserKey();
            UserDAO userDAO = GetExistingUserDAO(userKey);
            if (userDAO == null)
            {
                userDAO = new UserDAO(user.UserId);
                userCollection.Add(userKey, userDAO);
            }
            return userDAO;
        }

        private static UserDAO GetExistingUserDAO(UserKey userKey)
        {
            UserDAO existedUserMainDAO = null;
            userCollection.TryGetValue(userKey, out existedUserMainDAO);
            return existedUserMainDAO;
        }
    }
}