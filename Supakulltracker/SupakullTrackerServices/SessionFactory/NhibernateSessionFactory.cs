﻿using NHibernate;
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
            Application
        }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static IDictionary<SessionFactoryConfiguration, ISessionFactory> sesionFactoryDictionary;

        static NhibernateSessionFactory()
        {
            sesionFactoryDictionary = new Dictionary<SessionFactoryConfiguration, ISessionFactory>();
            Configuration configuration = new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.hibernate.cfg.xml"));
            configuration.Properties.Add("connection.connection_string", System.Configuration.ConfigurationManager.ConnectionStrings["AppDataBase"].ConnectionString);
            sesionFactoryDictionary.Add(SessionFactoryConfiguration.Application, configuration.BuildSessionFactory());
        }

        public static ISessionFactory GetSessionFactory(SessionFactoryConfiguration configurationName)
        {
            ISessionFactory sessionFactory;
            sesionFactoryDictionary.TryGetValue(configurationName, out sessionFactory);
            return sessionFactory;
        }
    }
}