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
        private static IDictionary<TaskKey, ITask> taskMainCollection;
        private static IDictionary<UserKey, User> userCollection;

        static ConverterDAOtoDomain()
        {
            taskMainCollection = new Dictionary<TaskKey, ITask>();
            userCollection = new Dictionary<UserKey, User>();
        }

        public static IList<ITask> TaskMainDaoToTaskMain(IList<TaskMainDAO> TaskMainDaoCollection)
        {
            List<ITask> target = new List<ITask>();
            foreach (TaskMainDAO taskMainDAO in TaskMainDaoCollection)
            {
                ITask taskMain = TaskMainDaoToTaskMain(taskMainDAO);
                target.Add(taskMain);
            }
            return target;
        }

        public static ITask TaskMainDaoToTaskMain(TaskMainDAO taskMainDAO)
        {
            ITask taskMain = TaskMainDaoToTaskMainWithoutMatchedTasks(taskMainDAO);
            if (taskMainDAO.MatchedCount > 0)
            {
                IList<ITask> matchedTasks = GetMatchedTasks(taskMainDAO.MatchedTasks, taskMain);
                taskMain.MatchedTasks = matchedTasks;
            }
            return taskMain;
        }

        private static ITask TaskMainDaoToTaskMainWithoutMatchedTasks(TaskMainDAO taskMainDAO)
        {
            TaskKey taskKey = taskMainDAO.GetTaskKey();
            ITask taskMain = GetExistingTask(taskKey);
            if (taskMain == null)
            {
                taskMain = new TaskMain();

                taskMain.TaskID = taskMainDAO.TaskID;
                taskMain.TargetVersion = taskMainDAO.TargetVersion;
                taskMain.Summary = taskMainDAO.Summary;
                taskMain.SubtaskType = taskMainDAO.SubtaskType;
                taskMain.Status = taskMainDAO.Status;
                taskMain.Project = taskMainDAO.Project;
                taskMain.Product = taskMainDAO.Product;
                taskMain.Priority = taskMainDAO.Priority;
                taskMain.LinkToTracker = taskMainDAO.LinkToTracker;
                taskMain.Estimation = taskMainDAO.Estimation;
                taskMain.Description = taskMainDAO.Description;
                taskMain.CreatedDate = taskMainDAO.CreatedDate;
                taskMain.CreatedBy = taskMainDAO.CreatedBy;
                taskMain.Comments = taskMainDAO.Comments;

                if (taskMainDAO.TaskParent != null)
                {
                    taskMain.TaskParent = TaskMainDaoToTaskMain(taskMainDAO.TaskParent);
                }

                if (taskMainDAO.Assigned != null && taskMainDAO.Assigned.Count > 0)
                {
                    taskMain.Assigned = UserDaoToUser(taskMainDAO.Assigned);
                }

                taskMainCollection.Add(taskKey, taskMain);
            }
            return taskMain;
        }

        private static ITask GetExistingTask(TaskKey taskKey)
        {
            ITask existedTaskMain = null;
            taskMainCollection.TryGetValue(taskKey, out existedTaskMain);
            return existedTaskMain;
        }

        private static IList<ITask> GetMatchedTasks(IEnumerable<TaskMainDAO> matchedTasksDAO, ITask item)
        {
            List<ITask> matchedTasks = new List<ITask>();
            foreach (TaskMainDAO matchedTaskDAO in matchedTasksDAO)
            {
                ITask matchedTask = TaskMainDaoToTaskMainWithoutMatchedTasks(matchedTaskDAO);
                matchedTasks.Add(matchedTask);
            }
            foreach (ITask currentTask in matchedTasks)
            {
                List<ITask> collectionForCurrentTask = new List<ITask>(matchedTasks);
                collectionForCurrentTask.Remove(currentTask);
                collectionForCurrentTask.Add(item);
                currentTask.MatchedTasks = collectionForCurrentTask;
            }
            return matchedTasks;
        }

        public static IList<User> UserDaoToUser(IList<UserDAO> userDAO)
        {
            IList<User> user = new List<User>();
            foreach (UserDAO item in userDAO)
            {
                user.Add(UserDaoToUser(item));
            }
            return user;
        }

        public static User UserDaoToUser(UserDAO userDAO)
        {
            UserKey userKey = userDAO.GetUserKey();
            User user = GetExistingUser(userKey);
            if (user == null)
            {
                user = new User(userDAO.UserId);
                userCollection.Add(userKey, user);
            }
            return user;
        }

        private static User GetExistingUser(UserKey userKey)
        {
            User existedUserMain = null;
            userCollection.TryGetValue(userKey, out existedUserMain);
            return existedUserMain;
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

            target.TokeneId = param.TokeneId;
            target.TokeneName = param.TokeneName;
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