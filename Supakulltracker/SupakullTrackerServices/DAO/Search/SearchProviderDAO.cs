using NHibernate;
using NHibernate.Search;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class SearchProviderDAO
    {
        public IList<TaskMainDAO> Find(string textQuery)
        {
            if (textQuery == string.Empty)
            {
                return null;
            }
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (ISession session = applicationFactory.OpenSession())
            using (IFullTextSession fullTextSession = Search.CreateFullTextSession(session))
            using (ITransaction transaction = fullTextSession.BeginTransaction())
            {
                try
                {
                    IFullTextQuery fullTextQuery = fullTextSession.CreateFullTextQuery<TaskMainDAO>(textQuery);
                    IList<TaskMainDAO> tasks = fullTextQuery.List<TaskMainDAO>();
                    transaction.Commit();
                    return tasks;
                }
                catch (Lucene.Net.QueryParsers.ParseException e)
                {
                    //handle parsing failure. Display some indication like "Wrong search criteria"
                    transaction.Commit();
                    return new TaskMainDAO[0];
                }
            }
        }

        public void GenerateIndexes()
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (ISession session = applicationFactory.OpenSession())
            using (IFullTextSession fullTextSession = Search.CreateFullTextSession(session))
            {
                using (ITransaction transaction = fullTextSession.BeginTransaction())
                {
                    fullTextSession.PurgeAll(typeof(TaskMainDAO));
                    transaction.Commit();
                }
                using (ITransaction transaction = fullTextSession.BeginTransaction())
                {
                    foreach (object entity in fullTextSession.CreateCriteria(typeof(TaskMainDAO)).List())
                    {
                        fullTextSession.Index(entity);
                    }
                    transaction.Commit();
                }
            }            
        }
    }
}