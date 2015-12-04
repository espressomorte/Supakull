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
        public IList<TaskMainDAO> FindTasks(string textQuery)
        {
            if (textQuery == string.Empty)
            {
                return null;
            }
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (ISession session = applicationFactory.OpenSession())
            using (IFullTextSession fullTextSession = Search.CreateFullTextSession(session))
            {
                try
                {
                    IFullTextQuery fullTextQuery = fullTextSession.CreateFullTextQuery<TaskMainDAO>(textQuery);
                    IList<TaskMainDAO> tasks = fullTextQuery.List<TaskMainDAO>();
                    return tasks;
                }
                catch(Lucene.Net.QueryParsers.ParseException e)
                {
                    //handle parsing failure. Display some indication like "Wrong search criteria"
                    return new TaskMainDAO[0];
                }                
            }
        }
    }
}