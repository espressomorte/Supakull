using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SupakullTrackerServices;
using NHibernate.Linq;
using NHibernate.Criterion;
using NHibernate;

namespace SupakullTrackerServices
{
    /// <summary>
    /// Summary description for UserProvider
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserProvider : System.Web.Services.WebService
    {
        [WebMethod]
        public UserForAuthentication Find(string userLogin)
        {
            ISessionFactory applicationFactory;
            try
            {
            applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            }
            catch(Exception e)
            {
                throw;
            }

            using (var session = applicationFactory.OpenSession())
            {
                UserForAuthentication user = session
                    .CreateCriteria(typeof(UserForAuthentication))
                    .Add(Restrictions.Eq("UserLogin", userLogin))                    
                    .UniqueResult<UserForAuthentication>();
                return user;
            }
        }

        [WebMethod]
        public bool Exist(string userLogin)
        {
            UserForAuthentication user = Find(userLogin);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
