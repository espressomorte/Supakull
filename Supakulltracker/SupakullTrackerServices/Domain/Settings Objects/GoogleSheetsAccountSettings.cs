using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public class GoogleSheetsAccountSettings : IAccountSettings, IAccountTest
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Sources Source { get; set; }
        public Boolean TestResult { get; set; }
        public List<GoogleSheetsAccountToken> Tokens { get; set; }
        public List<GoogleSheetsAccountTemplate> Templates { get; set; }        
        public int MinUpdateTime { get; set; }
        public int AccountVersion { get; set; }

        public ServiceAccount Convert(IAccountSettings service)
        {
            ServiceAccount target = new ServiceAccount();
            GoogleSheetsAccountSettings serviceAccount = (GoogleSheetsAccountSettings)service;

            target.ServiceAccountId = serviceAccount.ID;
            target.ServiceAccountName = serviceAccount.Name;
            target.Source = serviceAccount.Source;
            target.TestResult = serviceAccount.TestResult;
            target.Tokens = new List<Token>();
            target.MinUpdateTime = serviceAccount.MinUpdateTime;
            target.AccountVersion = serviceAccount.AccountVersion;

            if (serviceAccount.Tokens != null && serviceAccount.Tokens.Count > 0) 
            {
                foreach (GoogleSheetsAccountToken token in serviceAccount.Tokens)
                {
                    Token targetToken = new Token();
                    targetToken = token.Convert(token);
                    target.Tokens.Add(targetToken);
                }
            }
            if (serviceAccount.Templates != null && serviceAccount.Templates.Count > 0)
            {
                foreach (GoogleSheetsAccountTemplate template in serviceAccount.Templates)
                {
                    Template targetTemplate = new Template();
                    targetTemplate = template.Convert(template);
                    target.MappingTemplates.Add(targetTemplate);
                }
            }
            return target;
            
        }

        public IAccountSettings Convert(ServiceAccount serviceAccount)
        {
            GoogleSheetsAccountSettings target = new GoogleSheetsAccountSettings();
            target.ID = serviceAccount.ServiceAccountId;
            target.Name = serviceAccount.ServiceAccountName;
            target.Source = serviceAccount.Source;
            target.Tokens = new List<GoogleSheetsAccountToken>();
            target.MinUpdateTime = serviceAccount.MinUpdateTime;
            target.AccountVersion = serviceAccount.AccountVersion;

            if (serviceAccount.Tokens.Count > 0)
            {
                foreach (Token token in serviceAccount.Tokens)
                {
                    GoogleSheetsAccountToken targetToken = new GoogleSheetsAccountToken();
                    targetToken = (GoogleSheetsAccountToken)targetToken.Convert(token);
                    target.Tokens.Add(targetToken);
                }
            }
            if (serviceAccount.MappingTemplates.Count > 0)
            {
                foreach (Template template in serviceAccount.MappingTemplates)
                {
                    GoogleSheetsAccountTemplate targetTemplate = new GoogleSheetsAccountTemplate();
                    targetTemplate = (GoogleSheetsAccountTemplate)targetTemplate.Convert(template);
                    target.Templates.Add(targetTemplate);
                }
            }
            return target;
        }

        public bool Equals(IAccountSettings other)
        {
            throw new NotImplementedException();
        }
    }

    public class GoogleSheetsAccountToken : IAccountToken
    {
        public Int32 TokenId { get; set; }
        public String TokenName { get; set; }
        public String RefreshToken { get; set; }

        public Token Convert(IAccountToken token)
        {
            Token targetToken = new Token();
            GoogleSheetsAccountToken paramToken = (GoogleSheetsAccountToken)token;

            targetToken.TokenId = paramToken.TokenId;
            targetToken.TokenName = paramToken.TokenName;
            targetToken.Tokens.Add("RefreshToken", paramToken.RefreshToken);

            return targetToken;
        }

        public IAccountToken Convert(Token token)
        {
            GoogleSheetsAccountToken targetToken = new GoogleSheetsAccountToken();
            targetToken.TokenId = token.TokenId;
            targetToken.TokenName = token.TokenName;
            if (token.Tokens.Count > 0)
            {
                targetToken.RefreshToken = (from tok in token.Tokens
                                            where tok.Key == "RefreshToken"
                                            select tok.Value).SingleOrDefault();
            }

            return targetToken;
        }
    }

    public class GoogleSheetsAccountTemplate : IAccountTemplate
    {
        public Int32 TemplateId { get; set; }
        public String TemplateName { get; set; }
        public String Mapping { get; set; }

        public Template Convert(IAccountTemplate template)
        {
            Template target = new Template();
            GoogleSheetsAccountTemplate currentTemplate = (GoogleSheetsAccountTemplate)template;

            target.TemplateName = currentTemplate.TemplateName;
            target.TemplateId = currentTemplate.TemplateId;
            List<MappingForSerialization> mappingList = new List<MappingForSerialization>();

            MappingForSerialization map = new MappingForSerialization();
            map.Key = "Mapping";
            map.Value = currentTemplate.Mapping;
            mappingList.Add(map);

            //target.Mapping = mappingList.ToArray();
            return target;
        }

        public IAccountTemplate Convert(Template template)
        {
            GoogleSheetsAccountTemplate targetTemplate = new GoogleSheetsAccountTemplate();
            targetTemplate.TemplateId = template.TemplateId;
            targetTemplate.TemplateName = template.TemplateName;
            if (template.Mapping.Count > 0)
            {
                targetTemplate.Mapping = (from tok in template.Mapping
                                          where tok.Key == "Mapping"
                                          select tok.Value).SingleOrDefault();
            }

            return targetTemplate;
        }
    }
}