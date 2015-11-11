using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class UserDAO
    {
        public virtual int ID { get; set; }
        public virtual string UserId { get; set; }

        public UserDAO()
        {
        }

        public UserDAO(string UserId)
        {
            this.UserId = UserId;
        }

        public virtual int GetUserIDFormDB()
        {
            UserDAO userFromDB = this.GetUserFromDB();
            if (userFromDB != null)
            {
                return userFromDB.ID;
            }
            return -1;
        }

        private UserDAO GetUserFromDB()
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                UserDAO userDAO = session
                    .CreateCriteria(typeof(UserDAO))
                    .Add(Restrictions.Eq("UserId", this.UserId))
                    .UniqueResult<UserDAO>();
                return userDAO;
            }
        }
    }
}