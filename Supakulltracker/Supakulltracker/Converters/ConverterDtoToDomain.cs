using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Supakulltracker.IssueService;

namespace Supakulltracker
{
    public static class ConverterDtoToDomain
    {
        public static List<ITask> TaskMainDtoToTaskMain(IList<TaskMainDTO> taskMainDTO)
        {
            if (taskMainDTO == null)
            {
                return null;
            }
            List<ITask> target = new List<ITask>();
            foreach (TaskMainDTO item in taskMainDTO)
            {
                target.Add(TaskMainDtoToTaskMain(item));
            }
            return target;
        }

        private static ITask TaskMainDtoToTaskMain(TaskMainDTO taskMainDTO)
        {
            TaskMain taskMain = new TaskMain();

            taskMain.TaskID = taskMainDTO.TaskID;
            taskMain.TargetVersion = taskMainDTO.TargetVersion;
            taskMain.Summary = taskMainDTO.Summary;
            taskMain.SubtaskType = taskMainDTO.SubtaskType;
            taskMain.Status = taskMainDTO.Status;
            taskMain.Project = taskMainDTO.Project;
            taskMain.Product = taskMainDTO.Product;
            taskMain.Priority = taskMainDTO.Priority;
            taskMain.Source = taskMainDTO.Source;
            taskMain.LinkToTracker = taskMainDTO.LinkToTracker;
            taskMain.Estimation = taskMainDTO.Estimation;
            taskMain.Description = taskMainDTO.Description;
            taskMain.CreatedDate = taskMainDTO.CreatedDate;
            taskMain.CreatedBy = taskMainDTO.CreatedBy;
            taskMain.Comments = taskMainDTO.Comments;
            taskMain.TokenID = taskMainDTO.TokenID;

            if (taskMainDTO.TaskParent != null)
            {
                taskMain.TaskParent = TaskMainDtoToTaskMain(taskMainDTO.TaskParent);
            }

            if (taskMainDTO.Assigned != null)
            {
                taskMain.Assigned = UserDtoToUser(taskMainDTO.Assigned);
            }

            return taskMain;
        }

        private static List<User> UserDtoToUser(IList<UserDTO> userDTO)
        {
            List<User> user = new List<User>();

            foreach (UserDTO item in userDTO)
            {
                user.Add(UserDtoToUser(item));
            }
            return user;
        }

        private static User UserDtoToUser(UserDTO userDTO)
        {
            User user = null;
            if (userDTO != null)
            {
                user = new User(userDTO.UserID, userDTO.UserLogin);
            }
            return user;
        }

    }
}