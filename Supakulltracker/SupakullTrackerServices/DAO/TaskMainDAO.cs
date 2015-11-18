using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
     public class TaskMainDAO: IEquatable<TaskMainDAO>
    {        
        public TaskMainDAO()
        {
            this.Assigned = new List<UserDAO>();
            this.MatchedTasks = new List<TaskMainDAO>();
        }
        public virtual int ID { get; set; }
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
        public virtual string Estimation { get; set; }
        public virtual string TargetVersion { get; set; }
        public virtual string Comments { get; set; }
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
            return new TaskKey(this.TaskID, this.LinkToTracker);
        }

        #region SaveOrUpdat

        public static void SaveOrUpdateCollectionInDB(IEnumerable<TaskMainDAO> taskMainDaoCollection)
        {
            foreach (TaskMainDAO taskMainDAO in taskMainDaoCollection)
            {
                taskMainDAO.SaveOrUpdateTaskInDB();                
            }
        }

        private void SaveOrUpdateTaskInDB()
        {
            if (this.TaskID != null)
            {
                TaskMainDAO.PutIDsInCurrentAndMatchedAndParentTaskFromDB(this);                
                
                ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
                using (var session = applicationFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(this);
                        transaction.Commit();
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
            TaskMainDAO taskFromDB = TaskMainDAO.GetTaskFromDB(this.TaskID, this.LinkToTracker);
            if (taskFromDB != null)
            {
                return taskFromDB.ID;
            }
            return -1;
        }

        public static TaskMainDAO GetTaskFromDB(string taskID, Sources linkToTracker)
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                TaskMainDAO taskMainDAO = session
                    .CreateCriteria(typeof(TaskMainDAO))
                    .Add(Restrictions.Eq("TaskID", taskID))
                    .Add(Restrictions.Eq("LinkToTracker", linkToTracker))
                    .UniqueResult<TaskMainDAO>();
                return taskMainDAO;
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
            return ( taskMainDaoToCompare != null &&
                this.TaskID.Equals(taskMainDaoToCompare.TaskID) &&
                this.LinkToTracker.Equals(taskMainDaoToCompare.LinkToTracker) );
        }

        public override int GetHashCode()
        {
            return (this.TaskID.GetHashCode()) ^ (int)this.LinkToTracker;
        }

        #endregion

    }
}