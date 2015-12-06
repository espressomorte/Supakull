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

        public UserDAO(string userId)
        {
            this.UserId = userId;
        }

        public UserDAO(Int32 id, string userId)
        {
            this.ID = id;
            this.UserId = userId;
        }

        public virtual UserKey GetUserKey()
        {
            return new UserKey(this.UserId);
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

        public static UserDAO FindUserFromDBByName(String name)
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                UserDAO userDAO = session.QueryOver<UserDAO>()
                                        .Where(user => user.UserId == name)
                                        .SingleOrDefault<UserDAO>();     
                return userDAO;
            }
        }
    }
}