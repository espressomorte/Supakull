using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    static class SettingsConverter
    {
        #region Convert From DAO to DTO
        public static List<ServiceAccountDTO> ServiceAccountDAOCollectionToDTO(this IList<ServiceAccountDAO> param)
        {
            List<ServiceAccountDTO> target = new List<ServiceAccountDTO>();
            foreach (ServiceAccountDAO item in param)
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
        public static ServiceAccountDTO ServiceAccountDomainToDTO(this ServiceAccountDAO param, Boolean IsDetailsNeed = false)
        {
            ServiceAccountDTO target = new ServiceAccountDTO();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;
            if (IsDetailsNeed)
            {
                if (param.Tokens != null)
                {
                    target.Tokens = param.Tokens.Select<TokenDAO, TokenDTO>(x => x.TokenDAOToTokenDTO()).ToList();
                }
                else
                {
                    target.Tokens = null;
                }

                if (param.MappingTemplates != null)
                {
                    target.MappingTemplates = param.MappingTemplates.Select<TemplateDAO, TemplateDTO>(x => x.TemplateDAOToTemplateDTO()).ToList();
                }
                else
                {
                    target.MappingTemplates = null;
                }
            }

            return target;
        }

        public static TokenDTO TokenDAOToTokenDTO(this TokenDAO param)
        {
            TokenDTO target = new TokenDTO();

            target.TokenId = param.TokenId;
            target.TokenName = param.TokenName;
            foreach (KeyValuePair<string, string> item in param.Token)
            {
                target.Tokens.Add(new TokenForSerialization { Key = item.Key, Value = item.Value });
            }

            return target;
        }

        public static TemplateDTO TemplateDAOToTemplateDTO(this TemplateDAO param)
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

        #region Convert From DTO to DAO

        
        public static ServiceAccountDAO ServiceAccountDTOToDAO(this ServiceAccountDTO param)
        {
            ServiceAccountDAO target = new ServiceAccountDAO();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;

            if (param.Tokens != null)
            {
                target.Tokens = param.Tokens.Select<TokenDTO, TokenDAO>(x => x.TokenDTOToTokenDAO()).ToList();
            }
            else
            {
                target.Tokens = null;
            }

            if (param.MappingTemplates != null)
            {
                target.MappingTemplates = param.MappingTemplates.Select<TemplateDTO, TemplateDAO>(x => x.TemplateDTOToTemplateDAO()).ToList();
            }
            else
            {
                target.MappingTemplates = null;
            }

            return target;
        }

        public static TokenDAO TokenDTOToTokenDAO(this TokenDTO param)
        {
            TokenDAO target = new TokenDAO();

            target.TokenId = param.TokenId;
            target.TokenName = param.TokenName;

            foreach (TokenForSerialization item in param.Tokens)
            {
                if (item.Key != null && item.Value != null)
                {
                    target.Token.Add(item.Key, item.Value);
                }

            }

            return target;
        }

        public static TemplateDAO TemplateDTOToTemplateDAO(this TemplateDTO param)
        {
            TemplateDAO target = new TemplateDAO();

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
