using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices.Class
{
    public class DataAccess
    {
        public void StoreSources(List<IAdapter> adapters)
        {
            if(IsTaskTableEmpty)
            {
                foreach (IAdapter adapter in adapters)
                {
                    StoreSource(adapter);
                }
            }            
        }
        
        public void StoreSource(IAdapter adapter)
        {
            List<ITask> allTasks = adapter.GetAllItems();
            var clientFactory = new NhibernateSessionFactory("App.hibernate.cfg.xml").SessionFactory;
            foreach (ITask task in allTasks)
            {                
                using (var session = clientFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {                        
                        session.Save(task);
                        transaction.Commit();
                    }
                }
            }
        }

        private bool IsTaskTableEmpty
        {
            get
            {
                GetTrackerServices getTrackerServices = new GetTrackerServices();
                int issuesAmount = getTrackerServices.GetAllIssues().Count;
                return (issuesAmount == 0);
            }            
        }

    }
}