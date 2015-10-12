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
        public enum SessionFactoryConfiguration
        {
            Application,
            Client
        }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static IDictionary<SessionFactoryConfiguration, ISessionFactory> sesionFactoryDictionary;

        static NhibernateSessionFactory()
        {
            sesionFactoryDictionary = new Dictionary<SessionFactoryConfiguration, ISessionFactory>();
            Configuration configuration = new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.hibernate.cfg.xml"));
            sesionFactoryDictionary.Add(SessionFactoryConfiguration.Application, configuration.BuildSessionFactory());
            configuration = new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Client.hibernate.cfg.xml"));
            sesionFactoryDictionary.Add(SessionFactoryConfiguration.Client, configuration.BuildSessionFactory());
        }

        public static ISessionFactory GetSessionFactory(SessionFactoryConfiguration configurationName)
        {
            ISessionFactory sessionFactory;
            sesionFactoryDictionary.TryGetValue(configurationName, out sessionFactory);
            return sessionFactory;
        }
    }
}