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
        
        public static IList<IssueDAO> TaskMainToIssueDaoCollection(IList<ITask> param, bool GetUserList = false)
        {
            IList<IssueDAO> target = new List<IssueDAO>();
            foreach (ITask item in param)
            {
                target.Add(TaskMainToIssueDaoSingle(item, GetUserList));
            }
            return target;
        }

        private static IssueDAO TaskMainToIssueDaoSingle(ITask param, bool GetUserList = false)
        {
            IssueDAO target = new IssueDAO();

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
                target.TaskParent = TaskMainToIssueDaoSingle(param.TaskParent);
            }

            if (GetUserList)
            {
                target.Assigned = UserListToUserListDaoCollection(param.Assigned);
            }

            return target;
        }

        public static IList<UsersListDAO> UserListToUserListDaoCollection(IList<UsersList> param, bool GetTaskList = false)
        {
            IList<UsersListDAO> target = new List<UsersListDAO>();

            foreach (UsersList item in param)
            {
                target.Add(UserListToUserListDaoSingle(item, GetTaskList));
            }
            return target;
        }

        private static UsersListDAO UserListToUserListDaoSingle(UsersList param, bool GetTaskList = false)
        {
            UsersListDAO target = new UsersListDAO();

            target.UserName = param.UserName;
            target.UserId = param.UserId;

            if (GetTaskList)
            {
                target.TaskList = TaskMainToIssueDaoCollection(param.TaskList);
            }

            return target;
        }
    }
}