using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SupakullTrackerServices.Class;
using NHibernate.Linq;
using NHibernate.Criterion;

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
        public User Find(string userLogin)
        {
            var sessionFactory = new NhibernateSessionFactory("Client.hibernate.cfg.xml").SessionFactory;

            using (var session = sessionFactory.OpenSession())
            {
                User user = session
                    .CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("UserLogin", userLogin))                    
                    .UniqueResult<User>();
                return user;
            }
        }
    }
}
