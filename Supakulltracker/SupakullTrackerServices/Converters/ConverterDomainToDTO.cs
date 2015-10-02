using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace SupakullTrackerServices
{
    public static class ConverterDomainToDTO
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<TaskMainDTO> TaskMainToTaskMainDtoCollection(IList<ITask> param, bool GetUserList = false)
        {
            List<TaskMainDTO> target = new List<TaskMainDTO>();
            foreach (ITask item in param)
            {
                target.Add(TaskMainToTaskMainDtoSingle(item, GetUserList));
            }
            return target;
        }

        private static TaskMainDTO TaskMainToTaskMainDtoSingle(ITask param, bool GetUserList = false)
        {
            TaskMainDTO target = new TaskMainDTO();

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
                target.TaskParent = TaskMainToTaskMainDtoSingle(param.TaskParent);
            }

            if (GetUserList)
            {
                target.Assigned = UserListToUserListDtoCollection(param.Assigned);
            }
            else
            {
                target.Assigned = null;
            }

            return target;
        }

        public static List<UsersListDTO> UserListToUserListDtoCollection(IList<UsersList> param, bool GetTaskList = false)
        {
            List<UsersListDTO> target = new List<UsersListDTO>();

            foreach (UsersList item in param)
            {
                target.Add(UserListToUserListDtoSingle(item, GetTaskList));
            }
            return target;
        }

        private static UsersListDTO UserListToUserListDtoSingle(UsersList param, bool GetTaskList = false)
        {
            UsersListDTO target = new UsersListDTO();

            target.UserName = param.UserName;
            target.UserId = param.UserId;
            if (GetTaskList)
            {
                target.TaskList = TaskMainToTaskMainDtoCollection(param.TaskList);
            }
            else
            {
                target.TaskList = null;
            }
            return target;
        }
    }
}