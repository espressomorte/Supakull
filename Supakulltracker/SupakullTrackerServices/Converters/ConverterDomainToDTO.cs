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

        public static List<TaskMainDTO> TaskMainToTaskMainDtoCollection(IList<ITask> param)
        {
            List<TaskMainDTO> target = new List<TaskMainDTO>();
            foreach (ITask item in param)
            {
                target.Add(TaskMainToTaskMainDtoSingle(item));
            }
            return target;
        }

        private static TaskMainDTO TaskMainToTaskMainDtoSingle(ITask param)
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

            if (param.Assigned != null)
            {
                target.Assigned = UserToUserDtoCollection(param.Assigned);
            }

            return target;
        }

        public static List<UserDTO> UserToUserDtoCollection(IList<User> param)
        {
            List<UserDTO> target = new List<UserDTO>();

            foreach (User item in param)
            {
                target.Add(UserToUserDtoSingle(item));
            }
            return target;
        }

        private static UserDTO UserToUserDtoSingle(User param)
        {
            UserDTO target = new UserDTO();

            target.UserName = param.UserName;
            target.UserId = param.UserId;

            return target;
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

        /// <summary>
        /// Convert Domain Object for serialization 
        /// </summary>
        /// <param name="param">Object for converting</param>
        /// <param name="IsDetailsNeed">If Tokens and Mapping Templates needs</param>
        /// <returns></returns>
        public static ServiceAccountDTO ServiceAccountDomainToDTO(this ServiceAccount param, Boolean IsDetailsNeed = false)
        {
            ServiceAccountDTO target = new ServiceAccountDTO();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;
            if (IsDetailsNeed)
            {
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
            }

            return target;
        }

        public static TokenDTO TokenToTokenDTO(this Token param)
        {
            TokenDTO target = new TokenDTO();

            target.TokenId = param.TokenId;
            target.TokenName = param.TokenName;
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
                target.Mapping.Add(new MappingForSerialization { Key = item.Key, Value = item.Value });
            }

            return target;
        }

        public static ServiceAccount ServiceAccountDTOToDomain(this ServiceAccountDTO param)
        {
            ServiceAccount target = new ServiceAccount();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;

            if (param.Tokens != null)
            {
                target.Tokens = param.Tokens.Select<TokenDTO, Token>(x => x.TokenDTOToTokenDomain()).ToList();
            }
            else
            {
                target.Tokens = null;
            }

            if (param.MappingTemplates != null)
            {
                target.MappingTemplates = param.MappingTemplates.Select<TemplateDTO, Template>(x => x.TemplateDTOToTemplateDomain()).ToList();
            }
            else
            {
                target.MappingTemplates = null;
            }

            return target;
        }

        public static Token TokenDTOToTokenDomain(this TokenDTO param)
        {
            Token target = new Token();

            target.TokenId = param.TokenId;
            target.TokenName = param.TokenName;

            foreach (TokenForSerialization item in param.Tokens)
            {
                if (item.Key != null && item.Value != null)
                {
                    target.Tokens.Add(item.Key, item.Value);
                }

            }

            return target;
        }

        public static Template TemplateDTOToTemplateDomain(this TemplateDTO param)
        {
            Template target = new Template();

            target.TemplateId = param.TemplateId;
            target.TemplateName = param.TemplateName;

            foreach (MappingForSerialization item in param.Mapping)
            {
                if (item.Key != null && item.Value != null)
                {
                    target.Mapping.Add(item.Key, item.Value);
                }
            }

            return target;
        }
        #endregion
    }
}