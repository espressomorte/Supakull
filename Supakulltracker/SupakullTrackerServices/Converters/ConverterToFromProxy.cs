using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace SupakullTrackerServices
{
    public static class ConverterToFromProxy
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<TaskMainDTO> ConvertToProxyList(IList<TaskMainDAO> param, bool GetUserList = false)
        {
            List<TaskMainDTO> target = new List<TaskMainDTO>();
            foreach (TaskMainDAO item in param)
            {
                target.Add(ToProxySinglTask(item, GetUserList));
            }
            return target;
        }

        public static TaskMainDTO ToProxySinglTask(TaskMainDAO param, bool GetUserList = false)
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
                target.TaskParent = ToProxySinglTask(param.TaskParent);
            }
            else
            {
                target.TaskParent = null;
            }


            if (GetUserList)
            {
                target.Assigned = ToProxyUsesrList(param.Assigned);
            }
            else
            {
                target.Assigned = null;
            }

            return target;
        }

        public static List<UserDTO> ToProxyUsesrList(IList<UserDAO> param)
        {
            List<UserDTO> target = new List<UserDTO>();

            foreach (UserDAO item in param)
            {
                target.Add(ToProxySingleUserList(item));
            }
            return target;
        }

        public static UserDTO ToProxySingleUserList(UserDAO param)
        {
            UserDTO target = new UserDTO();

            target.UserName = param.UserName;
            target.UserId = param.UserId;

            return target;
        }
    }
}