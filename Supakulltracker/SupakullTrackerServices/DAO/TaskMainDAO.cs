using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Search.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    [Indexed]
    public class TaskMainDAO : IEquatable<TaskMainDAO>
    {
        public TaskMainDAO()
        {
            this.Assigned = new List<UserDAO>();
            this.MatchedTasks = new List<TaskMainDAO>();
        }

        [DocumentId]
        public virtual int ID { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string TaskID { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string SubtaskType { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string Summary { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string Description { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string Status { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string Priority { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string Product { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string Project { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string CreatedDate { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string CreatedBy { get; set; }

        [IndexedEmbedded]
        public virtual Sources Source { get; set; }
        public virtual string LinkToTracker { get; set; }

        public virtual Int32 TokenID { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string Estimation { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string TargetVersion { get; set; }

        [Field(Index.Tokenized, Store = Store.No)]
        public virtual string Comments { get; set; }

        [IndexedEmbedded]
        public virtual IList<UserDAO> Assigned { get; set; }

        public virtual TaskMainDAO TaskParent { get; set; }

        public virtual IList<TaskMainDAO> MatchedTasks { get; set; }

        public virtual int MatchedCount
        {
            get
            {
                return MatchedTasks.Count;
            }
        }

        public virtual TaskKey GetTaskKey()
        {
            return new TaskKey(this.TaskID, this.Source, this.TokenID);
        }

        #region SaveOrUpdate

        public static void SaveOrUpdateCollectionInDB(IEnumerable<TaskMainDAO> taskMainDaoCollection)
        {
            if (taskMainDaoCollection.Count() > 0)
            {

                ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

                using (var session = applicationFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (TaskMainDAO taskMainDAO in taskMainDaoCollection)
                        {
                            TaskMainDAO.PutIDsInCurrentAndMatchedAndParentTaskFromDB(taskMainDAO);
                            session.SaveOrUpdate(taskMainDAO);
                        }
                        transaction.Commit();

                    }

                }
            }

        }

        /// <summary>
        /// Test save. Checking are the task can be save. Without actual save in data base.
        /// </summary>
        /// <param name="taskMainDaoCollection">Tasks collection</param>
        public static void SaveOrUpdateCollectionInDBWhithRollback(IEnumerable<TaskMainDAO> taskMainDaoCollection)
        {
            if (taskMainDaoCollection.Count() > 0)
            {

                ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

                using (var session = applicationFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (TaskMainDAO taskMainDAO in taskMainDaoCollection)
                        {
                            session.SaveOrUpdate(taskMainDAO);
                        }
                        transaction.Rollback();
                    }

                }
            }

        }

        private static void PutIDsInCurrentAndMatchedAndParentTaskFromDB(TaskMainDAO taskMainDAO)
        {
            TaskMainDAO.PutIDsInCurrentAndParentTaskFromDB(taskMainDAO);

            foreach (TaskMainDAO matchedTask in taskMainDAO.MatchedTasks)
            {
                TaskMainDAO.PutIDsInCurrentAndParentTaskFromDB(matchedTask);
            }
        }

        private static void PutIDsInCurrentAndParentTaskFromDB(TaskMainDAO taskMainDAO)
        {
            int taskIdFromDB = taskMainDAO.GetTaskIDFormDB();
            if (taskIdFromDB > -1)
            {
                taskMainDAO.ID = taskIdFromDB;
            }

            foreach (UserDAO user in taskMainDAO.Assigned)
            {
                int userIdFromDB = user.GetUserIDFormDB();
                if (userIdFromDB > -1)
                {
                    user.ID = userIdFromDB;
                }
            }

            if (taskMainDAO.TaskParent != null)
            {
                TaskMainDAO.PutIDsInCurrentAndMatchedAndParentTaskFromDB(taskMainDAO.TaskParent);
            }
        }

        private int GetTaskIDFormDB()
        {
            TaskMainDAO taskFromDB = TaskMainDAO.GetTaskFromDB(this.TaskID, this.Source, this.TokenID);
            if (taskFromDB != null)
            {
                return taskFromDB.ID;
            }
            return -1;
        }


        public static TaskMainDAO GetTaskFromDB(string taskID, Sources source, Int32 tokenId)
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                TaskMainDAO taskMainDAO = session
                    .CreateCriteria(typeof(TaskMainDAO))
                    .Add(Restrictions.Eq("TaskID", taskID))
                    .Add(Restrictions.Eq("Source", source))
                    .Add(Restrictions.Eq("TokenID", tokenId))
                    .UniqueResult<TaskMainDAO>();
                return taskMainDAO;
            }
        }

        public static IList<TaskMainDAO> GetAllTasksFromDB()
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                IList<TaskMainDAO> taskMainDaoCollection = session.Query<TaskMainDAO>().ToList();
                return taskMainDaoCollection;
            }
        }
        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            TaskMainDAO taskMainDaoToCompare = obj as TaskMainDAO;
            return Equals(taskMainDaoToCompare);
        }

        public virtual bool Equals(TaskMainDAO taskMainDaoToCompare)
        {
            return (taskMainDaoToCompare != null &&
                this.TaskID.Equals(taskMainDaoToCompare.TaskID) &&
                this.Source.Equals(taskMainDaoToCompare.Source));
        }

        public override int GetHashCode()
        {
            return (this.TaskID.GetHashCode()) ^ (int)this.Source;
        }

        #endregion

    }
}