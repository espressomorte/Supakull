using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supakulltracker.IssueService;

namespace Supakulltracker
{
    class GoogleSheetsAccountSettings : IAccountSettings
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Sources Source { get; set; }
        public Boolean Owner { get; set; }
        public Int32 MinUpdateTime { get; set; }
        public Int32 AccountVersion { get; set; }
        public List<GoogleSheetsAccountToken> Tokens { get; set; }
        public List<GoogleSheetsAccountTemplate> Template { get; set; }


        public IAccountSettings ConvertFromDAO(ServiceAccountDTO serviceAccount)
        {
            GoogleSheetsAccountSettings target = new GoogleSheetsAccountSettings();
            target.ID = serviceAccount.ServiceAccountId;
            target.Name = serviceAccount.ServiceAccountName;
            target.Source = serviceAccount.Source;
            target.Tokens = new List<GoogleSheetsAccountToken>();
            target.Template = new List<GoogleSheetsAccountTemplate>();
            target.MinUpdateTime = serviceAccount.MinUpdateTime;
            target.AccountVersion = serviceAccount.AccountVersion;

            if (serviceAccount.Tokens.Length > 0)
            {
                foreach (TokenDTO token in serviceAccount.Tokens)
                {
                    GoogleSheetsAccountToken targetToken = new GoogleSheetsAccountToken();
                    targetToken = (GoogleSheetsAccountToken)targetToken.ConvertFromDAO(token);
                    target.Tokens.Add(targetToken);
                }
            }
            if (serviceAccount.MappingTemplates.Length > 0)
            {
                foreach (TemplateDTO template in serviceAccount.MappingTemplates)
                {
                    GoogleSheetsAccountTemplate targetTemplate = new GoogleSheetsAccountTemplate();
                    targetTemplate = (GoogleSheetsAccountTemplate)targetTemplate.ConvertFromDAO(template);
                    target.Template.Add(targetTemplate);
                }
            }
            return target;
        }
        public ServiceAccountDTO ConvertToDAO(IAccountSettings serviceAccount)
        {
            ServiceAccountDTO target = new ServiceAccountDTO();
            GoogleSheetsAccountSettings currentAccount = (GoogleSheetsAccountSettings)serviceAccount;

            target.ServiceAccountId = currentAccount.ID;
            target.ServiceAccountName = currentAccount.Name;
            target.Source = Sources.GoogleSheets;
            target.MinUpdateTime = target.MinUpdateTime;
            target.AccountVersion = serviceAccount.AccountVersion;

            List<TokenDTO> tok = new List<TokenDTO>();
            List<TemplateDTO> templ = new List<TemplateDTO>();
            if (currentAccount.Tokens != null && currentAccount.Tokens.Count > 0)
            {
                foreach (GoogleSheetsAccountToken token in currentAccount.Tokens)
                {
                    TokenDTO localtok = token.ConvertToDAO(token);
                    tok.Add(localtok);
                }
                target.Tokens = tok.ToArray();               
            }
            if (currentAccount.Template != null && currentAccount.Template.Count > 0)
            {
                foreach (GoogleSheetsAccountTemplate template in currentAccount.Template)
                {
                    TemplateDTO locTemlate = template.ConvertToDAO(template);
                    templ.Add(locTemlate);
                }
                target.MappingTemplates = templ.ToArray();
            }
            return target;
        }
    }

    class GoogleSheetsAccountToken : IAccountToken
    {
        public Int32 TokenId { get; set; }
        public String TokenName { get; set; }
        public String RefreshToken { get; set; }

        public IAccountToken ConvertFromDAO(TokenDTO token)
        {
            GoogleSheetsAccountToken targetToken = new GoogleSheetsAccountToken();
            targetToken.TokenId = token.TokenId;
            targetToken.TokenName = token.TokenName;
            if (token.Tokens.Length > 0)
            {
                targetToken.RefreshToken = (from tok in token.Tokens
                                            where tok.Key == "RefreshToken"
                                            select tok.Value).SingleOrDefault();
            }

            return targetToken;
        }

        public TokenDTO ConvertToDAO(IAccountToken token)
        {
            TokenDTO target = new TokenDTO();
            GoogleSheetsAccountToken currentToken = (GoogleSheetsAccountToken)token;

            target.TokenName = currentToken.TokenName;
            target.TokenId = currentToken.TokenId;
            List<TokenForSerialization> tokenList = new List<TokenForSerialization>();

            TokenForSerialization password = new TokenForSerialization();
            password.Key = "RefreshToken";
            password.Value = currentToken.RefreshToken;
            tokenList.Add(password);

            target.Tokens = tokenList.ToArray();
            return target;
        }
    }

    class GoogleSheetsAccountTemplate : IAccountTemplate
    {
        public Int32 TemplateId { get; set; }
        public String TemplateName { get; set; }
        public String Mapping { get; set; }

        public IAccountTemplate ConvertFromDAO(TemplateDTO template)
        {
            GoogleSheetsAccountTemplate targetTemplate = new GoogleSheetsAccountTemplate();
            targetTemplate.TemplateId = template.TemplateId;
            targetTemplate.TemplateName = template.TemplateName;
            if (template.Mapping.Length > 0)
            {
                targetTemplate.Mapping = (from tok in template.Mapping
                                          where tok.Key == "Mapping"
                                          select tok.Value).SingleOrDefault();
            }

            return targetTemplate;
        }

        public TemplateDTO ConvertToDAO(IAccountTemplate template)
        {
            TemplateDTO target = new TemplateDTO();
            GoogleSheetsAccountTemplate currentTemplate = (GoogleSheetsAccountTemplate)template;

            target.TemplateName = currentTemplate.TemplateName;
            target.TemplateId = currentTemplate.TemplateId;
            List<MappingForSerialization> mappingList = new List<MappingForSerialization>();

            MappingForSerialization map = new MappingForSerialization();
            map.Key = "Mapping";
            map.Value = currentTemplate.Mapping;
            mappingList.Add(map);

            target.Mapping = mappingList.ToArray();
            return target;
        }
    }
}
