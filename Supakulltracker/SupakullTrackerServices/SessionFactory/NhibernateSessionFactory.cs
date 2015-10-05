using NHibernate;
using NHibernate.Cfg;
using log4net;
using System;
using System.IO;
using System.Collections.Generic;

namespace SupakullTrackerServices
{
    public class NhibernateSessionFactory
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static IDictionary<string, ISessionFactory> sesionFactoryDictionary;

        public static void Add(string name, string configFile)
        {
            if (sesionFactoryDictionary == null)
            {
                sesionFactoryDictionary = new Dictionary<string, ISessionFactory>();
            }

            if(sesionFactoryDictionary.ContainsKey(name) == false)
            {
                try
                {
                    Configuration configuration = new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFile));
                    sesionFactoryDictionary.Add(name, configuration.BuildSessionFactory());
                }
                catch (Exception ex)
                {
                    log.Fatal("Problems with Session Factory", ex);
                    throw;
                }
            }            
        }

        public static ISessionFactory GetSessionFactory(string name)
        {
            ISessionFactory sessionFactory;
            bool isSessionFactoryGot = sesionFactoryDictionary.TryGetValue(name, out sessionFactory);
            if(isSessionFactoryGot)
            {
                return sessionFactory;
            }
            else
            {
                throw new ArgumentException("Session Factory {0} doesn't exist", name);
            }
        }
    }
}