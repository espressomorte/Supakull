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

        #region Converters For Settings
        public static List<ServiceAccount> ServiceAccountDAOCollectionToDomain(this IList<ServiceAccountDAO> param)
        {
            List<ServiceAccount> target = new List<ServiceAccount>();
            foreach (ServiceAccountDAO item in param)
            {
                target.Add(ServiceAccountDAOToDomain(item));
            }
            return target;
        }

        public static ServiceAccount ServiceAccountDAOToDomain(this ServiceAccountDAO param)
        {
            ServiceAccount target = new ServiceAccount();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;

            if (param.Tokens != null)
            {
                target.Tokens = param.Tokens.Select<TokenDAO, Token>(x => x.TokenDAOToToken()).ToList();
            }
            else
            {
                target.Tokens = null;
            }

            if (param.MappingTemplates != null)
            { 
                target.MappingTemplates = param.MappingTemplates.Select<TemplateDAO, Template>(x => x.TemplateDAOToTemplate()).ToList();
            }
            else
            {
                target.MappingTemplates = null;
            }

            return target;
        }

        public static Token TokenDAOToToken(this TokenDAO param)
        {
            Token target = new Token();

            target.TokenId = param.TokenId;
            target.TokenName = param.TokenName;
            target.Tokens = param.Token;

            return target;
        }

        public static Template TemplateDAOToTemplate(this TemplateDAO param)
        {
            Template target = new Template();

            target.TemplateId = param.TemplateId;
            target.TemplateName = param.TemplateName;
            target.Mapping = param.Mapping;

            return target;
        }


        #endregion
    }
}