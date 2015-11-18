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
        
        public static IList<ITask> TaskMainDaoToTaskMainCollection(IList<TaskMainDAO> param)
        {
            IList<ITask> target = new List<ITask>();
            foreach (TaskMainDAO item in param)
            {
                target.Add(TaskMainDaoToTaskMainSingle(item));
            }
            return target;
        }

        private static ITask TaskMainDaoToTaskMainSingle(TaskMainDAO param)
        {
            ITask target = new TaskMain();

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
                target.TaskParent = TaskMainDaoToTaskMainSingle(param.TaskParent);
            }

            if (param.Assigned != null)
            {
                target.Assigned = UserDaoToUserCollection(param.Assigned);
            }

            return target;
        }

        public static IList<User> UserDaoToUserCollection(IList<UserDAO> param)
        {
            IList<User> target = new List<User>();

            foreach (UserDAO item in param)
            {
                target.Add(UserDaoToUserSingle(item));
            }
            return target;
        }

        private static User UserDaoToUserSingle(UserDAO param)
        {
            User target = new User(param.UserId, param.UserName);
            return target;
        }

    }
}