using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supakulltracker.IssueService;

namespace Supakulltracker
{
    public class ExcelAccountSettings : IAccountSettings
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Sources Source { get; set; }
        public Boolean Owner { get; set; }
        public List<ExcelAccountToken> Tokens { get; set; }
        public List<ExcelAccountTemplate> Template { get; set; }

        public IAccountSettings ConvertFromDAO(ServiceAccountDTO serviceAccount)
        {
            ExcelAccountSettings target = new ExcelAccountSettings();
            target.ID = serviceAccount.ServiceAccountId;
            target.Name = serviceAccount.ServiceAccountName;
            target.Source = serviceAccount.Source;
            target.Tokens = new List<ExcelAccountToken>();
            target.Template = new List<ExcelAccountTemplate>();

            if (serviceAccount.Tokens.Length > 0)
            {
                foreach (TokenDTO token in serviceAccount.Tokens)
                {
                    ExcelAccountToken targetToken = new ExcelAccountToken();
                    targetToken = (ExcelAccountToken)targetToken.ConvertFromDAO(token);
                    target.Tokens.Add(targetToken);
                }
            }
            if (serviceAccount.MappingTemplates.Length > 0)
            {
                foreach (TemplateDTO template in serviceAccount.MappingTemplates)
                {
                    ExcelAccountTemplate targetTemplate = new ExcelAccountTemplate();
                    targetTemplate = (ExcelAccountTemplate)targetTemplate.ConvertFromDAO(template);
                    target.Template.Add(targetTemplate);
                }
            }
            return target;
        }

        public ServiceAccountDTO ConvertToDAO(IAccountSettings serviceAccount)
        {
            ServiceAccountDTO target = new ServiceAccountDTO();
            ExcelAccountSettings currentAccount = (ExcelAccountSettings)serviceAccount;

            target.ServiceAccountId = currentAccount.ID;
            target.ServiceAccountName = currentAccount.Name;
            target.Source = Sources.Excel;

            List<TokenDTO> tok = new List<TokenDTO>();
            List<TemplateDTO> templ = new List<TemplateDTO>();
            if (currentAccount.Tokens.Count > 0)
            {
                foreach (ExcelAccountToken token in currentAccount.Tokens)
                {
                    TokenDTO localtok = token.ConvertToDAO(token);
                    tok.Add(localtok);
                }
                target.Tokens = tok.ToArray();
            }
            if (currentAccount.Template.Count > 0)
            {
                foreach (ExcelAccountTemplate template in currentAccount.Template)
                {
                    TemplateDTO localtemp = template.ConvertToDAO(template);
                    templ.Add(localtemp);
                }
                target.MappingTemplates = templ.ToArray();
            }
            return target;
        }
    }

    public class ExcelAccountToken : IAccountToken
    {
        public Int32 TokenId { get; set; }
        public String TokenName { get; set; }
        public String Token { get; set; }

        public IAccountToken ConvertFromDAO(TokenDTO token)
        {
            ExcelAccountToken targetToken = new ExcelAccountToken();
            targetToken.TokenId = token.TokenId;
            targetToken.TokenName = token.TokenName;
            if (token.Tokens.Length > 0)
            {

                targetToken.Token = (from tok in token.Tokens
                                     where tok.Key == "Token"
                                     select tok.Value).SingleOrDefault();
            }

            return targetToken;
        }

        public TokenDTO ConvertToDAO(IAccountToken token)
        {
            TokenDTO target = new TokenDTO();
            ExcelAccountToken currentToken = (ExcelAccountToken)token;

            target.TokenName = currentToken.TokenName;
            target.TokenId = currentToken.TokenId;
            List<TokenForSerialization> tokenList = new List<TokenForSerialization>();

            TokenForSerialization password = new TokenForSerialization();
            password.Key = "Token";
            password.Value = currentToken.Token;
            tokenList.Add(password);

            target.Tokens = tokenList.ToArray();
            return target;
        }
    }

    public class ExcelAccountTemplate : IAccountTemplate
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }

        public string TaskID { get; set; }
        public string SubtaskType { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Product { get; set; }
        public string Project { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Sources LinkToTracker { get; set; }
        public string Estimation { get; set; }
        public string TargetVersion { get; set; }
        public string Comments { get; set; }

        public IAccountTemplate ConvertFromDAO(TemplateDTO template)
        {
            ExcelAccountTemplate targetTemplate = new ExcelAccountTemplate();
            targetTemplate.TemplateId = template.TemplateId;
            targetTemplate.TemplateName = template.TemplateName;
            if (template.Mapping.Length > 0)
            {
                targetTemplate.TaskID = (from templ in template.Mapping
                                         where templ.Key == "TaskID"
                                         select templ.Value).SingleOrDefault();

                targetTemplate.SubtaskType = (from templ in template.Mapping
                                              where templ.Key == "SubtaskType"
                                              select templ.Value).SingleOrDefault();

                targetTemplate.Summary = (from templ in template.Mapping
                                         where templ.Key == "Summary"
                                          select templ.Value).SingleOrDefault();

                targetTemplate.Description = (from templ in template.Mapping
                                         where templ.Key == "Description"
                                              select templ.Value).SingleOrDefault();

                targetTemplate.Status = (from templ in template.Mapping
                                         where templ.Key == "Status"
                                         select templ.Value).SingleOrDefault();

                targetTemplate.Priority = (from templ in template.Mapping
                                         where templ.Key == "Priority"
                                           select templ.Value).SingleOrDefault();

                targetTemplate.Product = (from templ in template.Mapping
                                         where templ.Key == "Product"
                                          select templ.Value).SingleOrDefault();

                targetTemplate.Project = (from templ in template.Mapping
                                         where templ.Key == "Project"
                                          select templ.Value).SingleOrDefault();

                targetTemplate.CreatedDate = (from templ in template.Mapping
                                         where templ.Key == "CreatedDate"
                                              select templ.Value).SingleOrDefault();

                targetTemplate.CreatedBy = (from templ in template.Mapping
                                         where templ.Key == "CreatedBy"
                                            select templ.Value).SingleOrDefault();
                Sources sour;
                var result = (from templ in template.Mapping
                              where templ.Key == "LinkToTracker"
                              select templ.Value).SingleOrDefault();
                Enum.TryParse(result, out sour);
                targetTemplate.LinkToTracker = sour;

                //int token;
                //var result2 = (from templ in template.Mapping
                //               where templ.Key == "TokenID"
                //               select templ.Value).SingleOrDefault();
                //Int32.TryParse(result2, out token);
                //targetTemplate.TokenID = token;

                targetTemplate.Estimation = (from templ in template.Mapping
                                         where templ.Key == "Estimation"
                                             select templ.Value).SingleOrDefault();

                targetTemplate.TargetVersion = (from templ in template.Mapping
                                         where templ.Key == "TargetVersion"
                                                select templ.Value).SingleOrDefault();

                targetTemplate.Comments = (from templ in template.Mapping
                                                where templ.Key == "Comments"
                                           select templ.Value).SingleOrDefault();
            }
            return targetTemplate;
        }

        public TemplateDTO ConvertToDAO(IAccountTemplate template)
        {
            TemplateDTO target = new TemplateDTO();
            ExcelAccountTemplate currentTemplate = (ExcelAccountTemplate)template;

            target.TemplateName = currentTemplate.TemplateName;
            target.TemplateId = currentTemplate.TemplateId;
            List<MappingForSerialization> mapList = new List<MappingForSerialization>();

            MappingForSerialization task_ID = new MappingForSerialization();
            task_ID.Key = "TaskID";
            task_ID.Value = currentTemplate.TaskID;
            mapList.Add(task_ID);

            MappingForSerialization subtaskType = new MappingForSerialization();
            subtaskType.Key = "SubtaskType";
            subtaskType.Value = currentTemplate.SubtaskType;
            mapList.Add(subtaskType);

            MappingForSerialization summary = new MappingForSerialization();
            summary.Key = "Summary";
            summary.Value = currentTemplate.Summary;
            mapList.Add(summary);

            MappingForSerialization description = new MappingForSerialization();
            description.Key = "Description";
            description.Value = currentTemplate.Description;
            mapList.Add(description);

            MappingForSerialization status = new MappingForSerialization();
            status.Key = "Status";
            status.Value = currentTemplate.Status;
            mapList.Add(status);

            MappingForSerialization priority = new MappingForSerialization();
            priority.Key = "Priority";
            priority.Value = currentTemplate.Priority;
            mapList.Add(priority);

            MappingForSerialization product = new MappingForSerialization();
            product.Key = "Product";
            product.Value = currentTemplate.Product;
            mapList.Add(product);

            MappingForSerialization project = new MappingForSerialization();
            project.Key = "Project";
            project.Value = currentTemplate.Project;
            mapList.Add(project);

            MappingForSerialization createdDate = new MappingForSerialization();
            createdDate.Key = "CreatedDate";
            createdDate.Value = currentTemplate.CreatedDate;
            mapList.Add(createdDate);

            MappingForSerialization createdBy = new MappingForSerialization();
            createdBy.Key = "CreatedBy";
            createdBy.Value = currentTemplate.CreatedBy;
            mapList.Add(createdBy);

            MappingForSerialization linkTotracker = new MappingForSerialization();
            linkTotracker.Key = "LinkToTracker";
            linkTotracker.Value = currentTemplate.LinkToTracker.ToString();
            mapList.Add(linkTotracker);
            
            MappingForSerialization estimation = new MappingForSerialization();
            estimation.Key = "Estimation";
            estimation.Value = currentTemplate.Estimation;
            mapList.Add(estimation);

            MappingForSerialization targetVersion = new MappingForSerialization();
            targetVersion.Key = "TargetVersion";
            targetVersion.Value = currentTemplate.TargetVersion;
            mapList.Add(targetVersion);

            MappingForSerialization comments = new MappingForSerialization();
            comments.Key = "Comments";
            comments.Value = currentTemplate.Comments;
            mapList.Add(comments);
            
            target.Mapping = mapList.ToArray();
            return target;
        }
    }
}