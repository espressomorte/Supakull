using System;
using System.Collections.Generic;
using log4net;
using NHibernate;
using NHibernate.Cfg;

namespace SupakullTrackerServices
{
    static class ClientNHibernateSessionFactory
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static IDictionary<Int32, ISessionFactory> sesionFactoryDictionary = new Dictionary<Int32, ISessionFactory>();

        public static void Add(DatabaseAccountToken configFile)
        {
            try
            {
                Configuration configuration = new Configuration();
                configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, configFile.ConnectionString);
                configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, String.Format("NHibernate.Driver.{0}", configFile.DatabaseDriver));
                configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, String.Format("NHibernate.Dialect.{0}", configFile.DatabaseDialect));
                configuration.AddXml(configFile.Mapping);
                sesionFactoryDictionary.Add(configFile.TokenId, configuration.BuildSessionFactory());
            }
            catch (Exception ex)
            {
                throw new Exception("Can't create sessionFactory", ex);
            }
        }

        public static ISessionFactory GetSessionFactory(Int32 id)
        {
            ISessionFactory sessionFactory;
            bool isSessionFactoryGot = sesionFactoryDictionary.TryGetValue(id, out sessionFactory);
            if (isSessionFactoryGot)
            {
                return sessionFactory;
            }
            else
            {
                DatabaseAccountToken token = (DatabaseAccountToken)SettingsManager.GetTokenByID(id, Sources.DataBase); ;
                if (token != null)
                {
                    Add(token);
                    isSessionFactoryGot = sesionFactoryDictionary.TryGetValue(id, out sessionFactory);
                }
                if (isSessionFactoryGot)
                {
                    return sessionFactory;
                }
                else
                {
                    throw new Exception("Can't create sessionFactory");
                }

            }
        }
    }
}
