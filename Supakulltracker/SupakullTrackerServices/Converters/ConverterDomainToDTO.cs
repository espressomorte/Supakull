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

        public static List<TaskMainDTO> TaskMainToTaskMainDTO(IList<ITask> param)
        {
            if (param == null)
            {
                return null;
            }
            List<TaskMainDTO> target = new List<TaskMainDTO>();
            foreach (ITask item in param)
            {
                target.Add(TaskMainToTaskMainDTO(item));
            }
            return target;
        }

        private static TaskMainDTO TaskMainToTaskMainDTO(ITask param)
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
            target.Source = param.Source;
            target.Estimation = param.Estimation;
            target.Description = param.Description;
            target.CreatedDate = param.CreatedDate;
            target.CreatedBy = param.CreatedBy;
            target.Comments = param.Comments;
            target.TokenID = param.TokenID;
            target.LinkToTracker = param.LinkToTracker;

            if (param.TaskParent != null)
            {
                target.TaskParent = TaskMainToTaskMainDTO(param.TaskParent);
            }

            if (param.Assigned != null)
            {
                target.Assigned = UserToUserDTO(param.Assigned);
            }

            return target;
        }

        private static List<UserDTO> UserToUserDTO(IList<User> param)
        {
            List<UserDTO> target = new List<UserDTO>();

            foreach (User item in param)
            {
                target.Add(UserToUserDTO(item));
            }
            return target;
        }

        public static UserDTO UserToUserDTO(User user)
        {
            UserDTO userDAO = null;
            if (user != null)
            {
                userDAO = new UserDTO(user.UserID, user.UserLogin);
            }
            return userDAO;
        }

    }
}