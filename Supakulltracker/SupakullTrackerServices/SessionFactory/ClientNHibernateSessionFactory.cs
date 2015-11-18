using System;
using System.Collections.Generic;
using log4net;
using NHibernate;
using NHibernate.Cfg;

namespace SupakullTrackerServices
{
    class ClientNHibernateSessionFactory
    {
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private IDictionary<Int32, ISessionFactory> sesionFactoryDictionary;

        //public  void Add(Int32 id, TokenDAO configFile)
        //{
        //    if (sesionFactoryDictionary == null)
        //    {
        //        sesionFactoryDictionary = new Dictionary<Int32, ISessionFactory>();
        //    }

        //    if (sesionFactoryDictionary.ContainsKey(id) == false)
        //    {
        //        try
        //        {
        //            Configuration configuration = new Configuration();
        //            configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, configFile.ConectionString);
        //            configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.OracleClientDriver");
        //            configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.Oracle10gDialect");


                  
        //            configuration.AddXml(configFile.MappingSettings);
        //            sesionFactoryDictionary.Add(id, configuration.BuildSessionFactory());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new ArgumentException(String.Format("No settings with id: {0}", id));
        //        }
        //    }
        //}

        //public ISessionFactory GetSessionFactory(Int32 id)
        //{
        //    ISessionFactory sessionFactory;
        //    bool isSessionFactoryGot = sesionFactoryDictionary.TryGetValue(id, out sessionFactory);
        //    if (isSessionFactoryGot)
        //    {
        //        return sessionFactory;
        //    }
        //    else
        //    {
              
        //    }
        //}
    }
}
