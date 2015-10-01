using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace SupakullTrackerServices.Class
{
    public static class ConverterToFromProxy
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<ProxyTaskMain> ConvertToProxyList(IList<IssueDAO> param, bool GetUserList = false)
        {
            List<ProxyTaskMain> target = new List<ProxyTaskMain>();
            foreach (IssueDAO item in param)
            {
                target.Add(ToProxySinglTask(item, GetUserList));
            }
            return target;
        }

        public static ProxyTaskMain ToProxySinglTask(IssueDAO param, bool GetUserList = false)
        {
            ProxyTaskMain target = new ProxyTaskMain();

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



        public static List<ProxyUsersList> ToProxyUsesrList(IList<UsersListDAO> param, bool GetTaskList = false)
        {
            List<ProxyUsersList> target = new List<ProxyUsersList>();

            foreach (UsersListDAO item in param)
            {
                target.Add(ToProxySingleUserList(item, GetTaskList));
            }
            return target;
        }

        public static ProxyUsersList ToProxySingleUserList(UsersListDAO param, bool GetTaskList = false)
        {
            ProxyUsersList target = new ProxyUsersList();

            target.UserName = param.UserName;
            target.UserId = param.UserId;
            if (GetTaskList)
            {
                target.TaskList = ConvertToProxyList(param.TaskList);
            }
            else
            {
                target.TaskList = null;
            }
            return target;
        }
    }
}