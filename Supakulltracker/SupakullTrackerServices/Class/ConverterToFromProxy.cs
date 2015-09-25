using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices.Class
{
    public static class ConverterToFromProxy
    {
        public static List<ProxyTaskMain>  ConvertToProxyList(IList<TaskMain> param)
        {
            List<ProxyTaskMain> target = new List<ProxyTaskMain>();
            foreach (var item in param)
            {
                target.Add(ToProxySinglTask(item)); 
            }
            return target;
        }

        public static ProxyTaskMain ToProxySinglTask(TaskMain param)
        {
            ProxyTaskMain target = new ProxyTaskMain();
           // target.TaskParent = ToProxySinglTask(param.TaskParent);
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

            if (param.Assigned != null)
            {
                target.Assigned = ToProxyUsesrList(param.Assigned);
            }

            return target;
        }

        public static List<ProxyUsersList> ToProxyUsesrList (IList<UsersList> param)
        {
            List<ProxyUsersList> target = new List<ProxyUsersList>();

            foreach (var item in param)
            {
                target.Add(ToProxySingleUserList(item));
            }
            return target;
        }

        public static ProxyUsersList ToProxySingleUserList (UsersList param)
        {
            ProxyUsersList target = new ProxyUsersList();

            target.UserName = param.UserName;
            target.UserId = param.UserId;
            target.TaskList = null;
            return target;
        }
    }
}