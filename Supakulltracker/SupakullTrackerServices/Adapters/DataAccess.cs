﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class DataAccess
    {
        public void GetAllItemsFromAdaptersAndStoreToDbDirectly(ICollection<IAdapter> adapters)
        {
            foreach (IAdapter adapter in adapters)
            {
                GetAllItemsFromAdapterAndStoreToDbDirectly(adapter);
            }
        }
        
        public void GetAllItemsFromAdapterAndStoreToDbDirectly(IAdapter adapter)
        {
            IList<ITask> taskMainCollection = adapter.GetAllItems();
            IList<TaskMainDAO> issueDaoCollection = ConverterDomainToDAO.TaskMainToIssueDaoCollection(taskMainCollection, true);
            var clientFactory = new NhibernateSessionFactory("App.hibernate.cfg.xml").SessionFactory;
            foreach (TaskMainDAO task in issueDaoCollection)
            {                
                using (var session = clientFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {                        
                        session.SaveOrUpdate(task);
                        transaction.Commit();
                    }
                }
            }
        }
    }
}