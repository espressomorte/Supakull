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
        public UserDTO Find(string userId)
        {
            UserDAO userDAO = FindUserDAO(userId);
            User user = ConverterDAOtoDomain.UserDaoToUser(userDAO);
            UserDTO userDTO = ConverterDomainToDTO.UserToUserDTO(user);
            return userDTO;
        }

        [WebMethod]
        public bool Exist(string userId)
        {
            UserDAO userDAO = FindUserDAO(userId);
            return (userId != null);
        }
        
        private UserDAO FindUserDAO(string userId)
        {
            ISessionFactory applicationFactory =
                            NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                UserDAO userDAO = session
                    .CreateCriteria(typeof(UserDAO))
                    .Add(Restrictions.Eq("UserId", userId))
                    .UniqueResult<UserDAO>();

                return userDAO;
            }
        }
    }
}
