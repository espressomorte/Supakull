using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace SupakullTrackerServices
{
    static class SettingsManager
    {
        private static ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

        public static IAccountSettings GetAccountByAccountID(Int32 id)
        {
            IAccountSettings targetAccount = null;
            using (ISession session = sessionFactory.OpenSession())
            {
                ServiceAccountDAO accountFromDB = session.Get<ServiceAccountDAO>(id);
                
                if (accountFromDB != null)
                {
                    targetAccount = GetCurrentInstance(accountFromDB);
                    if (targetAccount != null)
                    {
                        targetAccount = targetAccount.Convert(accountFromDB);
                    }   
                }
               return targetAccount;
            }
        }

        public static List<IAccountSettings> GetAllUserAccountsByUserID(Int64 userId)
        {
            List<IAccountSettings> allUserAccounts= new List<IAccountSettings>();

            using (ISession session = sessionFactory.OpenSession())
            {
                var allUserLinks = session.QueryOver<UserLinkDAO>().Where(x => x.UserId == userId).List();
                if (allUserLinks != null)
                {
                    List<ServiceAccountDAO> allUserAccountsDAO = allUserLinks.Select<UserLinkDAO, ServiceAccountDAO>(x => x.Account).ToList();
                    foreach (ServiceAccountDAO account in allUserAccountsDAO)
                    {
                        IAccountSettings temp = GetCurrentInstance(account);
                        allUserAccounts.Add(temp.Convert(account));
                    }
                   
                }
                else
                {
                    allUserAccounts = null;
                }

                return allUserAccounts;
            }
        }


        public static IAccountSettings GetCurrentInstance(ServiceAccountDTO setting)
        {
            switch (setting.Source)
            {
                case Sources.DataBase:
                    return new DatabaseAccountSettings();
                case Sources.Trello:
                    return null;
                case Sources.Excel:
                    return null;
                case Sources.GoogleSheets:
                    return null;
                default:
                    return null;
            }
        }
        public static IAccountSettings GetCurrentInstance(ServiceAccountDAO setting)
        {
            switch (setting.Source)
            {
                case Sources.DataBase:
                    return new DatabaseAccountSettings();
                case Sources.Trello:
                    return null;
                case Sources.Excel:
                    return null;
                case Sources.GoogleSheets:
                    return null;
                default:
                    return null;
            }
        }
    }
}
