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
                TaskMainDAO taskFromDB = TaskMainDAO.GetTaskMainDaoFromDB(this.TaskID, this.LinkToTracker);
                if (taskFromDB == null)
                {
                    this.SaveTaskInDB();                        
                }
                else
                {
                    this.ID = taskFromDB.ID;
                    this.UpdateTaskInDB();                    
                }
            }
        }

        private void SaveTaskInDB()
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (var session = applicationFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(this);
                    transaction.Commit();
                }
            }
        }

        private void UpdateTaskInDB()
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (var session = applicationFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(this);
                    transaction.Commit();
                }
            }
        }

        private static TaskMainDAO GetTaskMainDaoFromDB(string taskID, Sources linkToTracker)
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
    }  
}