using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
     public class TaskMainDAO
    {        
        public TaskMainDAO()
        {
            this.Assigned = new List<UserDAO>();
            this.MatchedTasks = new List<TaskMainDAO>();
            this.Disagreements = new List<DisagreementDAO>();
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
        public virtual IList<DisagreementDAO> Disagreements { get; set; }

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
                TaskMainDAO.PutIDsInCurrentMatchedAndParentTaskFromDB(this);                
                
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

        public static void PutIDsInCurrentMatchedAndParentTaskFromDB(TaskMainDAO taskMainDAO)
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

            if (taskMainDAO.TaskParent != null)
            {
                TaskMainDAO.PutIDsInCurrentMatchedAndParentTaskFromDB(taskMainDAO.TaskParent);
            }
        }

        private int GetTaskIDFormDB()
        {
            TaskMainDAO taskParentFromDB = this.GetTaskFromDB();
            if (taskParentFromDB != null)
            {
                return taskParentFromDB.ID;
            }
            if (this.TaskParent != null)
            {
                
            }
            return -1;
        }

        private TaskMainDAO GetTaskFromDB()
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                TaskMainDAO taskMainDAO = session
                    .CreateCriteria(typeof(TaskMainDAO))
                    .Add(Restrictions.Eq("TaskID", this.TaskID))
                    .Add(Restrictions.Eq("LinkToTracker", this.LinkToTracker))
                    .UniqueResult<TaskMainDAO>();
                return taskMainDAO;
            }
        }
    }
}