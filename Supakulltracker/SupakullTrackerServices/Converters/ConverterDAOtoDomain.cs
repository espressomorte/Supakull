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
        
        public static IList<ITask> IssueDaoToTaskMainCollection(IList<IssueDAO> param, bool GetUserList = false)
        {
            IList<ITask> target = new List<ITask>();
            foreach (IssueDAO item in param)
            {
                target.Add(IssueDaoToTaskMainSingle(item, GetUserList));
            }
            return target;
        }

        private static ITask IssueDaoToTaskMainSingle(IssueDAO param, bool GetUserList = false)
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
                target.TaskParent = IssueDaoToTaskMainSingle(param.TaskParent);
            }

            if (GetUserList)
            {
                target.Assigned = UserListDaoToUserListCollection(param.Assigned);
            }

            return target;
        }

        public static IList<UsersList> UserListDaoToUserListCollection(IList<UsersListDAO> param, bool GetTaskList = false)
        {
            IList<UsersList> target = new List<UsersList>();

            foreach (UsersListDAO item in param)
            {
                target.Add(UserListDaoToUserListSingle(item, GetTaskList));
            }
            return target;
        }

        private static UsersList UserListDaoToUserListSingle(UsersListDAO param, bool GetTaskList = false)
        {
            UsersList target = new UsersList();

            target.UserName = param.UserName;
            target.UserId = param.UserId;

            if (GetTaskList)
            {
                target.TaskList = IssueDaoToTaskMainCollection(param.TaskList);
            }

            return target;
        }
    }
}