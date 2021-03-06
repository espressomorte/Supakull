﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;

namespace SupakullTrackerServices
{
    public class ExcelAccountSettings : IAccountSettings, IAccountTest
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Sources Source { get; set; }
        public Boolean Owner { get; set; }
        public Boolean TestResult { get; set; }
        public List<ExcelAccountToken> Tokens { get; set; }
        public List<ExcelAccountTemplate> Template { get; set; }
        public Int32 MinUpdateTime { get; set; }
        public int AccountVersion { get; set; }

        public ExcelAccountSettings()
        {
            Tokens = new List<ExcelAccountToken>();
            Template = new List<ExcelAccountTemplate>();
        }

        public IAccountSettings Convert(ServiceAccount serviceAccount)
        {
            ExcelAccountSettings target = new ExcelAccountSettings();
            target.ID = serviceAccount.ServiceAccountId;
            target.Name = serviceAccount.ServiceAccountName;
            target.Source = serviceAccount.Source;
            target.TestResult = serviceAccount.TestResult;
            target.AccountVersion = serviceAccount.AccountVersion;
            target.MinUpdateTime = serviceAccount.MinUpdateTime;

            target.Tokens = new List<ExcelAccountToken>();
            target.Template = new List<ExcelAccountTemplate>();

            if (serviceAccount.Tokens.Count > 0)
            {
                foreach (Token token in serviceAccount.Tokens)
                {
                    ExcelAccountToken targetToken = new ExcelAccountToken();
                    targetToken = (ExcelAccountToken)targetToken.Convert(token);
                    target.Tokens.Add(targetToken);
                }
            }
            if (serviceAccount.MappingTemplates.Count > 0)
            {
                foreach (Template template in serviceAccount.MappingTemplates)
                {
                    ExcelAccountTemplate targetTemplate = new ExcelAccountTemplate();
                    targetTemplate = (ExcelAccountTemplate)targetTemplate.Convert(template);
                    target.Template.Add(targetTemplate);
                }
            }
            return target;
        }

        public ServiceAccount Convert(IAccountSettings serviceAccount)
        {
            ServiceAccount target = new ServiceAccount();
            ExcelAccountSettings currentAccount = (ExcelAccountSettings)serviceAccount;

            target.ServiceAccountId = currentAccount.ID;
            target.ServiceAccountName = currentAccount.Name;
            target.TestResult = currentAccount.TestResult;
            target.AccountVersion = serviceAccount.AccountVersion;
            target.MinUpdateTime = serviceAccount.MinUpdateTime;
            target.Source = Sources.Excel;

            List<Token> tok = new List<Token>();
            List<Template> templ = new List<Template>();
            if (currentAccount.Tokens.Count > 0)
            {
                foreach (ExcelAccountToken token in currentAccount.Tokens)
                {
                    Token localtok = token.Convert(token);
                    tok.Add(localtok);
                }
                target.Tokens = tok;
            }
            if (currentAccount.Template.Count > 0)
            {
                foreach (ExcelAccountTemplate template in currentAccount.Template)
                {
                    Template localtemp = template.Convert(template);
                    templ.Add(localtemp);
                }
                target.MappingTemplates = templ;
            }
            return target;
        }

        public ExcelAccountToken FindTokenInAccountByID(Int32 id)
        {
            ExcelAccountToken result = this.Tokens.SingleOrDefault(token => token.TokenId == id);
            return result;
        }

        public bool Equals(IAccountSettings other)
        {
            if (other is ExcelAccountSettings)

            {
                ExcelAccountSettings account = (ExcelAccountSettings)other;
                return (this.ID.Equals(account.ID)
                        && this.AccountVersion.Equals(account.AccountVersion));
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ExcelAccountToken objAsExcelAccountToken = obj as ExcelAccountToken;
            if (objAsExcelAccountToken == null) return false;
            else return Equals(objAsExcelAccountToken);
        }
        public override int GetHashCode()
        {
            return this.ID;
        }
    }

    public class ExcelAccountToken : IAccountToken, IEquatable<IAccountToken>
    {
        public Int32 TokenId { get; set; }
        public String TokenName { get; set; }
        public DateTime LastUpdateTime { get; set; }


        public IAccountToken Convert(Token token)
        {
            ExcelAccountToken targetToken = new ExcelAccountToken();
            targetToken.TokenId = token.TokenId;
            targetToken.TokenName = token.TokenName;

            if (token.Tokens.Count > 0)
            {
                DateTime dt;
                DateTime.TryParse((from tok in token.Tokens
                                   where tok.Key == "LastUpdateTime"
                                   select tok.Value).SingleOrDefault(), out dt);
                targetToken.LastUpdateTime = dt;
            }

            return targetToken;
        }

        public Token Convert(IAccountToken token)
        {
            Token target = new Token();
            ExcelAccountToken currentToken = (ExcelAccountToken)token;

            target.TokenName = currentToken.TokenName;
            target.TokenId = currentToken.TokenId;
            List<TokenForSerialization> tokenList = new List<TokenForSerialization>();

            TokenForSerialization lastUpdateTime = new TokenForSerialization();
            lastUpdateTime.Key = "LastUpdateTime";
            lastUpdateTime.Value = currentToken.LastUpdateTime.ToString();
            tokenList.Add(lastUpdateTime);


            return target;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ExcelAccountToken objAsExcelAccountToken = obj as ExcelAccountToken;
            if (objAsExcelAccountToken == null) return false;
            else return Equals(objAsExcelAccountToken);
        }

        public bool Equals(IAccountToken other)
        {
            ExcelAccountToken token = (ExcelAccountToken)other;
            return (this.TokenId.Equals(token.TokenId)
                    && this.TokenName.Equals(token.TokenName));
        }

        public override int GetHashCode()
        {
            return TokenId;
        }
    }

    public class ExcelAccountTemplate : IAccountTemplate
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public List<String> AllFieldsInFile { get; set; }
        public ExcelAccountTemplate()
        {
            AllFieldsInFile = new List<string>();
        }

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
        public String LinkToTracker { get; set; }
        public Sources Source { get; set; }
        public string Estimation { get; set; }
        public string TargetVersion { get; set; }
        public string Comments { get; set; }
        public String TaskParent { get; set; }
        public String Assigned { get; set; }

        public IAccountTemplate Convert(Template template)
        {
            ExcelAccountTemplate targetTemplate = new ExcelAccountTemplate();
            targetTemplate.TemplateId = template.TemplateId;
            targetTemplate.TemplateName = template.TemplateName;

            if (template.Mapping.Count > 0)
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
                              where templ.Key == "Source"
                              select templ.Value).SingleOrDefault();
                Enum.TryParse(result, out sour);
                targetTemplate.Source = sour;

                targetTemplate.LinkToTracker = (from templ in template.Mapping
                                             where templ.Key == "LinkToTracker"
                                             select templ.Value).SingleOrDefault();


                targetTemplate.TaskParent = (from templ in template.Mapping
                                             where templ.Key == "TaskParent"
                                             select templ.Value).SingleOrDefault();

                targetTemplate.Estimation = (from templ in template.Mapping
                                             where templ.Key == "Estimation"
                                             select templ.Value).SingleOrDefault();

                targetTemplate.TargetVersion = (from templ in template.Mapping
                                                where templ.Key == "TargetVersion"
                                                select templ.Value).SingleOrDefault();

                targetTemplate.Comments = (from templ in template.Mapping
                                           where templ.Key == "Comments"
                                           select templ.Value).SingleOrDefault();

                targetTemplate.Assigned = (from templ in template.Mapping
                                           where templ.Key == "Assigned"
                                           select templ.Value).SingleOrDefault();
                

            }
            return targetTemplate;
        }

        public Template Convert(IAccountTemplate template)
        {
            Template target = new Template();
            ExcelAccountTemplate currentTemplate = (ExcelAccountTemplate)template;

            target.TemplateName = currentTemplate.TemplateName;
            target.TemplateId = currentTemplate.TemplateId;

            target.Mapping.Add("TaskID", currentTemplate.TaskID);
            target.Mapping.Add("SubtaskType", currentTemplate.SubtaskType);
            target.Mapping.Add("Summary", currentTemplate.Summary);
            target.Mapping.Add("Description", currentTemplate.Description);
            target.Mapping.Add("Status", currentTemplate.Status);
            target.Mapping.Add("Priority", currentTemplate.Priority);
            target.Mapping.Add("Product", currentTemplate.Product);
            target.Mapping.Add("Project", currentTemplate.Project);
            target.Mapping.Add("CreatedDate", currentTemplate.CreatedDate);
            target.Mapping.Add("CreatedBy", currentTemplate.CreatedBy);
            target.Mapping.Add("Source", currentTemplate.Source.ToString());
            target.Mapping.Add("Estimation", currentTemplate.Estimation);
            target.Mapping.Add("TargetVersion", currentTemplate.TargetVersion);
            target.Mapping.Add("Comments", currentTemplate.Comments);
            target.Mapping.Add("TaskParent", currentTemplate.TaskParent); 
            target.Mapping.Add("Assigned", currentTemplate.Assigned);
            target.Mapping.Add("LinkToTracker", currentTemplate.LinkToTracker);




            for (int i = 0; i < currentTemplate.AllFieldsInFile.Count; i++)
            {
                target.Mapping.Add(String.Format("AllFieldsInFile{0}", i), currentTemplate.AllFieldsInFile[i]);
            }

            return target;
        }
    }

}
