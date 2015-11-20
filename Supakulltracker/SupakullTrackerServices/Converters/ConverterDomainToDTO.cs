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
            target.LinkToTracker = param.LinkToTracker;
            target.Estimation = param.Estimation;
            target.Description = param.Description;
            target.CreatedDate = param.CreatedDate;
            target.CreatedBy = param.CreatedBy;
            target.Comments = param.Comments;


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
                userDAO = new UserDTO(user.UserId);
            }
            return userDAO;
        }

        #region Converters For Settings
        public static List<ServiceAccountDTO> ServiceAccountDomainCollectionToDTO(this IList<ServiceAccount> param)
        {
            List<ServiceAccountDTO> target = new List<ServiceAccountDTO>();
            foreach (ServiceAccount item in param)
            {
                target.Add(ServiceAccountDomainToDTO(item));
            }
            return target;
        }

        public static ServiceAccountDTO ServiceAccountDomainToDTO(this ServiceAccount param)
        {
            ServiceAccountDTO target = new ServiceAccountDTO();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;

            if (param.Tokens != null)
            {
                target.Tokens = param.Tokens.Select<Token, TokenDTO>(x => x.TokenToTokenDTO()).ToList();
            }
            else
            {
                target.Tokens = null;
            }

            if (param.MappingTemplates != null)
            {
                target.MappingTemplates = param.MappingTemplates.Select<Template, TemplateDTO>(x => x.TemplateToTemplateDTO()).ToList();
            }
            else
            {
                target.MappingTemplates = null;
            }

            return target;
        }

        public static TokenDTO TokenToTokenDTO(this Token param)
        {
            TokenDTO target = new TokenDTO();

            target.TokeneId = param.TokeneId;
            target.TokeneName = param.TokeneName;
            foreach (KeyValuePair<string, string> item in param.Tokens)
            {
                target.Tokens.Add(new TokenForSerialization { Key = item.Key, Value = item.Value });
            }

            return target;
        }

        public static TemplateDTO TemplateToTemplateDTO(this Template param)
        {
            TemplateDTO target = new TemplateDTO();

            target.TemplateId = param.TemplateId;
            target.TemplateName = param.TemplateName;
            foreach (KeyValuePair<string, string> item in param.Mapping)
            {
                target.Mapping.Add(new MappingForSerialization{ Key = item.Key, Value = item.Value });
            }

            return target;
        }
        #endregion
    }
}