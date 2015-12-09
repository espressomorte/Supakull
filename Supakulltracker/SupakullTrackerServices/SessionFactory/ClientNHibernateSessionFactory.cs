using System;
using System.Collections.Generic;
using log4net;
using NHibernate;
using NHibernate.Cfg;

namespace SupakullTrackerServices
{
    class ClientNHibernateSessionFactory
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private  IDictionary<Int32, ISessionFactory> sesionFactoryDictionary = new Dictionary<Int32, ISessionFactory>();

        public   void Add(DatabaseAccountToken configFile)
        {
            try
            {
                if (sesionFactoryDictionary.ContainsKey(configFile.TokenId))
                {
                    return;
                }
                else
                {
                    Configuration configuration = new Configuration();
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, configFile.ConnectionString);
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, String.Format("NHibernate.Driver.{0}", configFile.DatabaseDriver));
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, String.Format("NHibernate.Dialect.{0}", configFile.DatabaseDialect));
                    configuration.AddXml(configFile.Mapping);

                    sesionFactoryDictionary.Add(configFile.TokenId, configuration.BuildSessionFactory());
                }
            }
            catch (Exception ex)
            {
                log.Error("Can't create sessionFactory", ex);
            }
        }

        public  ISessionFactory GetSessionFactory(DatabaseAccountToken token)
        {
            ISessionFactory sessionFactory;
            bool isSessionFactoryGot = sesionFactoryDictionary.TryGetValue(token.TokenId, out sessionFactory);
            if (isSessionFactoryGot)
            {
                return sessionFactory;
            }
            else
            {
                if (token != null)
                {
                    Add(token);
                    isSessionFactoryGot = sesionFactoryDictionary.TryGetValue(token.TokenId, out sessionFactory);
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

        public static Boolean TestAccount(DatabaseAccountToken token, Boolean testMapping = false)
        {
            try
            {
                Configuration configuration = new Configuration();
                configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, token.ConnectionString);
                configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, String.Format("NHibernate.Driver.{0}", token.DatabaseDriver));
                configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, String.Format("NHibernate.Dialect.{0}", token.DatabaseDialect));
                if (testMapping)
                {
                    configuration.AddXml(token.Mapping);
                    using (ISessionFactory sessionFactory = configuration.BuildSessionFactory())
                    {
                        using (ISession session = sessionFactory.OpenSession())
                        {
                            return session.IsConnected;
                        }
                    }
                }
                else
                {
                    using (ISessionFactory sessionFactory = configuration.BuildSessionFactory())
                    {
                        using (ISession session = sessionFactory.OpenSession())
                        {
                            return session.IsConnected;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
