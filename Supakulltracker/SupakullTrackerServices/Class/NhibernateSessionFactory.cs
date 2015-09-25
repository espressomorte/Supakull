using NHibernate;
using NHibernate.Cfg;
using log4net;
using System;
using System.IO;

namespace SupakullTrackerServices.Class
{
    public class NhibernateSessionFactory
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ISessionFactory mySesionFactory;
        private readonly string nHibernateConfigFile = "";

        public NhibernateSessionFactory(string nHConfigFile)
        {
            this.nHibernateConfigFile = nHConfigFile;
        }

        public ISessionFactory SessionFactory
        {
            get { return mySesionFactory ?? (mySesionFactory = CreateSessionFactory()); }
        }

        private ISessionFactory CreateSessionFactory()
        {

            Configuration cfg;
            try
            {
                cfg = new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.nHibernateConfigFile));
                return (cfg.BuildSessionFactory());
            }
            catch (Exception ex)
            {
                log.Fatal("Problems with Session Factory", ex);
                throw;
            }
            
        }
    }
}