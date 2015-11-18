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

        public static IAccountSettings GetAccountByTokenID(Int32 id)
        {
            IAccountSettings targetAccount = null;
            using (ISession session = sessionFactory.OpenSession())
            {
                TokenDAO token = session.Get<TokenDAO>(id);
                ServiceAccountDAO accountFromDB = session.QueryOver<ServiceAccountDAO>().Where(x => x.Tokens.Contains(token)).SingleOrDefault();
                if (accountFromDB != null)
                {
                    targetAccount = GetCurrentInstance(accountFromDB.Source);
                    if (targetAccount != null)
                    {
                        targetAccount = targetAccount.Convert(accountFromDB);
                    }
                }
                return targetAccount;
            }
        }

        public static IAccountToken GetTokenByID(Int32 tokenId, Sources source)
        {
            IAccountToken targetToken = null;
            using (ISession session = sessionFactory.OpenSession())
            {
                TokenDAO token = session.Get<TokenDAO>(tokenId);

                targetToken = GetCurrentInstanceForToken(source);
                if (targetToken != null)
                {
                    targetToken = targetToken.Convert(token);
                }
            }
            return targetToken;
        }


        public static List<IAccountSettings> GetAllUserAccountsByUserID(Int64 userId)
        {
            List<IAccountSettings> allUserAccounts = new List<IAccountSettings>();

            using (ISession session = sessionFactory.OpenSession())
            {
                var allUserLinks = session.QueryOver<UserLinkDAO>().Where(x => x.UserId == userId).List();
                if (allUserLinks != null)
                {
                    List<ServiceAccountDAO> allUserAccountsDAO = allUserLinks.Select<UserLinkDAO, ServiceAccountDAO>(x => x.Account).ToList();
                    foreach (ServiceAccountDAO account in allUserAccountsDAO)
                    {
                        IAccountSettings temp = GetCurrentInstance(account.Source);
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

        public static IAccountSettings GetCurrentInstance(Sources source)
        {
            switch (source)
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

        public static IAccountToken GetCurrentInstanceForToken(Sources source)
        {
            switch (source)
            {
                case Sources.DataBase:
                    return new DatabaseAccountToken();
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

