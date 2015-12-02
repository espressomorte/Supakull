using NHibernate;
using NHibernate.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class SearchProviderDAO
    {
        public IList<TaskMainDAO> FindTasks(string textQuery)
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (ISession session = applicationFactory.OpenSession())
            using (IFullTextSession fullTextSession = Search.CreateFullTextSession(session))
            //using (ITransaction transaction = session.BeginTransaction())
            {
                IFullTextQuery fullTextQuery = fullTextSession.CreateFullTextQuery<TaskMainDAO>(textQuery);
                IList<TaskMainDAO> tasks = fullTextQuery.List<TaskMainDAO>();
                //transaction.Commit();
                return tasks;
            }
        }
    }
}