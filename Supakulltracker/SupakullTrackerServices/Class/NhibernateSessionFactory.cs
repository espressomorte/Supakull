using NHibernate;
using NHibernate.Cfg;

namespace SupakullTrackerServices.Class
{
    public class NhibernateSessionFactory
    {
        private Configuration config = new Configuration();
        private ISessionFactory mySesionFactory;

        public ISessionFactory CreateSessionFactory()
        {
            config = config.Configure();
            mySesionFactory = config.BuildSessionFactory();
            return mySesionFactory;
        }
    }
}