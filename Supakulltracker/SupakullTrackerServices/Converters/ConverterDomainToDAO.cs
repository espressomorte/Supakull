﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public static class ConverterDomainToDAO
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public static IList<TaskMainDAO> TaskMainToTaskMainDaoCollection(IList<ITask> param)
        {
            List<TaskMainDAO> target = new List<TaskMainDAO>();
            foreach (ITask item in param)
            {
                TaskMainDAO itemDAO = TaskMainToTaskMainDaoSingle(item);
                if (item.MatchedCount > 0)
                {
                    List<TaskMainDAO> matchedTasksDAO = new List<TaskMainDAO>();
                    matchedTasksDAO.Add(itemDAO);
                    foreach (ITask matchedTask in item.MatchedTasks)
                    {
                        TaskMainDAO matchedTaskDAO = TaskMainToTaskMainDaoSingle(matchedTask);
                        matchedTasksDAO.Add(matchedTaskDAO);
                    }
                    foreach (TaskMainDAO currentTask in matchedTasksDAO)
                    {
                        List<TaskMainDAO> collectionForCurrentTask = new List<TaskMainDAO>(matchedTasksDAO);
                        collectionForCurrentTask.Remove(currentTask);
                        currentTask.MatchedTasks = collectionForCurrentTask;
                    }
                }
                target.Add(itemDAO);
            }
            return target;
        }

        private static TaskMainDAO TaskMainToTaskMainDaoSingle(ITask param)
        {
            TaskMainDAO target = new TaskMainDAO();

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
                target.TaskParent = TaskMainToTaskMainDaoSingle(param.TaskParent);
            }

            if (param.Assigned != null)
            {
                target.Assigned = UserToUserDaoCollection(param.Assigned);
            }

            return target;
        }

        private static IList<DisagreementDAO> DisagreementToDisagreementDaoCollection(ISet<Disagreement> param, TaskMainDAO taskMainDaoLinked)
        {
            IList<DisagreementDAO> target = new List<DisagreementDAO>();

            foreach (Disagreement item in param)
            {
                target.Add(DisagreementToDisagreementDao(item, taskMainDaoLinked));
            }
            return target;
        }

        private static DisagreementDAO DisagreementToDisagreementDao(Disagreement param, TaskMainDAO taskMainDaoLinked)
        {
            DisagreementDAO target = new DisagreementDAO(param.FieldName, taskMainDaoLinked);
            return target;
        }

        public static IList<UserDAO> UserToUserDaoCollection(IList<User> param)
        {
            IList<UserDAO> target = new List<UserDAO>();

            foreach (User item in param)
            {
                target.Add(UserToUserDaoSingle(item));
            }
            return target;
        }

        private static UserDAO UserToUserDaoSingle(User param)
        {
            UserDAO target = new UserDAO(param.UserId, param.UserName);
            return target;
        }

        #region Converters For Settings
        public static List<ServiceAccountDAO> ServiceAccountDAOCollectionToDomain(this IList<ServiceAccount> param)
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

            target.TokeneId = param.TokeneId;
            target.TokeneName = param.TokeneName;
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
    }
}