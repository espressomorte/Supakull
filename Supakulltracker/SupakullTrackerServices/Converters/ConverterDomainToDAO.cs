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
        private static IList<TaskMainDAO> taskMainDaoCollection;

        public static IList<TaskMainDAO> TaskMainToTaskMainDaoCollection(IList<ITask> TaskMainCollection)
        {
            List<TaskMainDAO> target = new List<TaskMainDAO>();
            foreach (ITask taskMain in TaskMainCollection)
            {
                taskMainDaoCollection = new List<TaskMainDAO>();
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
            TaskMainDAO taskMainDAO = GetExistedTaskDAO(taskMain.TaskID, taskMain.LinkToTracker);
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
                    taskMainDAO.Assigned = UserToUserDaoCollection(taskMain.Assigned);
                }

                taskMainDaoCollection.Add(taskMainDAO);
            }           
            return taskMainDAO;
        }

        private static TaskMainDAO GetExistedTaskDAO(string taskID, Sources linkToTracker)
        {
            foreach (TaskMainDAO existedTaskMainDAO in taskMainDaoCollection)
            {
                if (existedTaskMainDAO.TaskID.Equals(taskID) && existedTaskMainDAO.LinkToTracker.Equals(linkToTracker))
                {
                    return existedTaskMainDAO;
                }
            }
            return null;
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

        public static IList<UserDAO> UserToUserDaoCollection(IList<User> param)
        {
            IList<UserDAO> target = new List<UserDAO>();

            foreach (User item in param)
            {
                target.Add(UserToUserDaoSingle(item));
            }
            return target;
        }

        private static UserDAO UserToUserDaoSingle(User param)
        {
            UserDAO target = new UserDAO(param.UserId);
            return target;
        }
    }
}