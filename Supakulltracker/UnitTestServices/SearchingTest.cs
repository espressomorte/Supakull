using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupakullTrackerServices;
using NHibernate.Search;
using NHibernate;

namespace UnitTestServices
{
    [TestClass]
    public class SearchingTest
    {
        [TestMethod]
        public void NHibernateSearchTest1()
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (ISession session = applicationFactory.OpenSession())
            using (IFullTextSession fullTextSession = Search.CreateFullTextSession(session))
            using (ITransaction transaction = session.BeginTransaction())
            {
                IFullTextQuery fullTextQuery = fullTextSession.CreateFullTextQuery<TaskMainDAO>("Description:duplication");
                IList<TaskMainDAO> tasks = fullTextQuery.List<TaskMainDAO>();
                transaction.Commit();
                Assert.AreNotEqual(0, tasks.Count);
            }   
        }
    }
}
