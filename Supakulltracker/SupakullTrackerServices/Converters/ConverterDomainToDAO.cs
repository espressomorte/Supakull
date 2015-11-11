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
        
        public static IList<TaskMainDAO> TaskMainToTaskMainDaoCollection(IList<ITask> param)
        {
            List<TaskMainDAO> target = new List<TaskMainDAO>();
            foreach (ITask item in param)
            {
                TaskMainDAO itemDAO = TaskMainToTaskMainDaoSingle(item);
                if (item.MatchedCount > 0)
                {
                    List<TaskMainDAO> matchedTasksDAO = new List<TaskMainDAO>();
                    matchedTasksDAO.Add(itemDAO);
                    foreach (ITask matchedTask in item.MatchedTasks)
                    {
                        TaskMainDAO matchedTaskDAO = TaskMainToTaskMainDaoSingle(matchedTask);
                        matchedTasksDAO.Add(matchedTaskDAO);
                    }
                    foreach (TaskMainDAO currentTask in matchedTasksDAO)
                    {
                        List<TaskMainDAO> collectionForCurrentTask = new List<TaskMainDAO>(matchedTasksDAO);
                        collectionForCurrentTask.Remove(currentTask);
                        currentTask.MatchedTasks = collectionForCurrentTask;
                    }
                }
                target.Add(itemDAO);
            }
            return target;
        }

        private static TaskMainDAO TaskMainToTaskMainDaoSingle(ITask param)
        {
            TaskMainDAO target = new TaskMainDAO();

            target.TaskID = param.TaskID;
            target.TargetVersion = param.TargetVersion;
            target.Summary = param.Summary;
            target.SubtaskType = param.SubtaskType;
            target.Status = param.Status;
            target.Project = param.Project;
            target.Product = param.Product;
            target.Priority = param.Priority;
            target.LinkToTracker = param.LinkToTracker;
            target.Estimation = param.Estimation;
            target.Description = param.Description;
            target.CreatedDate = param.CreatedDate;
            target.CreatedBy = param.CreatedBy;
            target.Comments = param.Comments;

            if (param.TaskParent != null)
            {
                target.TaskParent = TaskMainToTaskMainDaoSingle(param.TaskParent);
            }

            if (param.Assigned != null)
            {
                target.Assigned = UserToUserDaoCollection(param.Assigned);
            }

            return target;
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
            UserDAO target = new UserDAO(param.UserId, param.UserName);
            return target;
        }
    }
}