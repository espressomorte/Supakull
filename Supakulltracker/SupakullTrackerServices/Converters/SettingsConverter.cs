using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    static class SettingsConverter
    {
        #region Convert From DAO to Domain
        public static List<ServiceAccount> ServiceAccountDAOCollectionToDomain(this IList<ServiceAccountDAO> param)
        {
            List<ServiceAccount> target = new List<ServiceAccount>();
            foreach (ServiceAccountDAO item in param)
            {
                target.Add(ServiceAccountDAOToDomain(item, true));
            }
            return target;
        }

        /// <summary>
        /// Convert Domain Object for serialization 
        /// </summary>
        /// <param name="param">Object for converting</param>
        /// <param name="IsDetailsNeed">If Tokens and Mapping Templates needs</param>
        /// <returns></returns>
        public static ServiceAccount ServiceAccountDAOToDomain(this ServiceAccountDAO param, Boolean IsDetailsNeed = false)
        {
            ServiceAccount target = new ServiceAccount();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;
            target.MinUpdateTime = param.MinUpdateTime;
            target.AccountVersion = param.AccountVersion;

            if (IsDetailsNeed)
            {
                if (param.Tokens != null)
                {
                    target.Tokens = param.Tokens.Select<TokenDAO, Token>(x => x.TokenDAOToTokenDomain()).ToList();
                }
                else
                {
                    target.Tokens = null;
                }

                if (param.MappingTemplates != null)
                {
                    target.MappingTemplates = param.MappingTemplates.Select<TemplateDAO, Template>(x => x.TemplateDAOToTemplateDomain()).ToList();
                }
                else
                {
                    target.MappingTemplates = null;
                }
            }

            return target;
        }

        public static Token TokenDAOToTokenDomain(this TokenDAO param)
        {
            Token target = new Token();

            target.TokenId = param.TokenId;
            target.TokenName = param.TokenName;
            target.Tokens = param.Token;

            return target;
        }

        public static Template TemplateDAOToTemplateDomain(this TemplateDAO param)
        {
            Template target = new Template();

            target.TemplateId = param.TemplateId;
            target.TemplateName = param.TemplateName;
            target.Mapping = param.Mapping;

            return target;
        }

        #endregion

        #region Convert From Domain To DTO

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
            target.TestResult = param.TestResult;
            target.MinUpdateTime = param.MinUpdateTime;
            target.AccountVersion = param.AccountVersion;

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

        #endregion

        #region Convert From Domain To DAO

        public static List<ServiceAccountDAO> ServiceAccountCollectionToDAO(this IList<ServiceAccount> param)
        {
            List<ServiceAccountDAO> target = new List<ServiceAccountDAO>();
            foreach (ServiceAccount item in param)
            {
                target.Add(ServiceAccountDomainToDAO(item));
            }
            return target;
        }

        public static ServiceAccountDAO ServiceAccountDomainToDAO(this ServiceAccount param)
        {
            ServiceAccountDAO target = new ServiceAccountDAO();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;
            target.MinUpdateTime = param.MinUpdateTime;
            target.AccountVersion = param.AccountVersion;

            if (param.Tokens != null)
            {
                target.Tokens = param.Tokens.Select<Token, TokenDAO>(x => x.TokenToTokenDAO()).ToList();
            }
            else
            {
                target.Tokens = null;
            }

            if (param.MappingTemplates != null)
            {
                target.MappingTemplates = param.MappingTemplates.Select<Template, TemplateDAO>(x => x.TemplateToTemplateDAO()).ToList();
            }
            else
            {
                target.MappingTemplates = null;
            }

            return target;
        }

        public static TokenDAO TokenToTokenDAO(this Token param)
        {
            TokenDAO target = new TokenDAO();

            target.TokenId = param.TokenId;
            target.TokenName = param.TokenName;
            target.Token = param.Tokens;

            return target;
        }

        public static TemplateDAO TemplateToTemplateDAO(this Template param)
        {
            TemplateDAO target = new TemplateDAO();

            target.TemplateId = param.TemplateId;
            target.TemplateName = param.TemplateName;
            target.Mapping = param.Mapping;

            return target;
        }

        #endregion

        #region Convert From DTO to Domain

        public static ServiceAccount ServiceAccountDTOToDomain(this ServiceAccountDTO param)
        {
            ServiceAccount target = new ServiceAccount();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;
            target.MinUpdateTime = param.MinUpdateTime;
            target.AccountVersion = param.AccountVersion;

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
