using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    class DatabaseAdapter : IAdapter
    {
        public DateTime adapterLastUpdate { get; set; }
        public Int32 MinUpdateTime { get; set; }
        List<DatabaseAccountToken> allTokensInAccount = new List<DatabaseAccountToken>();
        ClientNHibernateSessionFactory allFactories = new ClientNHibernateSessionFactory();

        public IAdapter GetAdapter(IAccountSettings account)
        {
            DatabaseAccountSettings dbAccount = (DatabaseAccountSettings)account;
            allTokensInAccount = dbAccount.Tokens;
            foreach (var token in allTokensInAccount)
            {
                allFactories.GetSessionFactory(token);
            }
            adapterLastUpdate = DateTime.MinValue;
            MinUpdateTime = account.MinUpdateTime;
            return this;
        }

        public IList<ITask> GetAllTasks()
        {
            IList<ITask> issues = new List<ITask>();
            foreach (DatabaseAccountToken token in allTokensInAccount)
            {
                var clientDBFactory = allFactories.GetSessionFactory(token);

                using (var session = clientDBFactory.OpenSession())
                {
                    IList<DBTask> listTask = session.QueryOver<DBTask>().List();
                    foreach (DBTask issue in listTask)
                    {
                        TaskMain task = new TaskMain();

                        task.TokenID = token.TokenId;
                        task.Source = Sources.DataBase;
                        task.Assigned = issue.Assigned;
                        task.Comments = issue.Comments;
                        task.CreatedBy = issue.CreatedBy;
                        task.CreatedDate = issue.CreatedDate;
                        task.Description = issue.Description;
                        task.Estimation = issue.Estimation;
                        task.Priority = issue.Priority;
                        task.Product = issue.Product;
                        task.Project = issue.Project;
                        task.Status = issue.Status;
                        task.SubtaskType = issue.SubtaskType;
                        task.Summary = issue.Summary;
                        task.TargetVersion = issue.TargetVersion;
                        task.TaskID = issue.TaskID;
                        task.TaskParent = issue.TaskParent;

                        issues.Add(task);
                    }
                }
            }

            return issues;

        }
        public ITask GetTask(int index)
        {
            throw new NotImplementedException();
        }

        public IAccountSettings TestAccount(IAccountSettings accountnForTest)
        {
            DatabaseAccountSettings accountForTestDB = (DatabaseAccountSettings)accountnForTest;
            DatabaseAccountToken tokenForTest = accountForTestDB.Tokens.FirstOrDefault();
            Boolean result = false;
            if (tokenForTest != null)
            {
                if (tokenForTest.Mapping == null)
                {
                    result = ClientNHibernateSessionFactory.TestAccount(tokenForTest);
                }
                else
                {
                    result = ClientNHibernateSessionFactory.TestAccount(tokenForTest, true);
                }
            }
            accountForTestDB.TestResult = result;
            return accountForTestDB;
        }

        public string GetLinkToTracker(String LinkToTrackerInfo)
        {
            return null;
        }

        public Boolean CanRunUpdate()
        {
            if ((DateTime.Now - this.adapterLastUpdate).TotalMilliseconds > this.MinUpdateTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    public class DBTask
    {
        public virtual string TaskID { get; set; }
        public virtual string SubtaskType { get; set; }
        public virtual string Summary { get; set; }
        public virtual string Description { get; set; }
        public virtual string Status { get; set; }
        public virtual string Priority { get; set; }
        public virtual string Product { get; set; }
        public virtual string Project { get; set; }
        public virtual string CreatedDate { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual Sources LinkToTracker { get; set; }
        public virtual Int32 TokenID { get; set; }
        public virtual string Estimation { get; set; }
        public virtual string TargetVersion { get; set; }
        public virtual string Comments { get; set; }
        public virtual IList<User> Assigned { get; set; }
        public virtual ITask TaskParent { get; set; }


    }
}
