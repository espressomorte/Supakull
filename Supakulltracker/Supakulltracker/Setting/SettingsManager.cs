using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supakulltracker.IssueService;
using Supakulltracker.UserProvider;

namespace Supakulltracker
{
    public static class SettingsManager
    {

        private static GetTrackerServicesSoapClient services = new GetTrackerServicesSoapClient();

        /// <summary>
        /// Get user setting for each adapter. Where current user is owner.
        /// </summary>
        /// <param name="currentUser"> Logged user.</param>
        /// <returns></returns>
        public static List<IAccountSettings> GetAllUserAccounts(this UserForAuthentication currentUser)
        {
            ServiceAccountDTO[] allAcc = services.GetAllUserAccountsByUserID(currentUser.UserID);
            List<IAccountSettings> targetAccs = new List<IAccountSettings>();
            foreach (ServiceAccountDTO account in allAcc)
            {

                IAccountSettings acc = GetCurrentInstance(account);
                if (acc != null)
                {
                    acc = acc.ConvertFromDAO(account);
                    acc.Owner = true;
                    targetAccs.Add(acc);
                }
            }
            return targetAccs;
        }

        public static List<IAccountSettings> GetAllUserAccountsInSource(List<IAccountSettings> allAccounts, Sources sourceType)
        {
            List<IAccountSettings> acc;
            if (allAccounts != null)
            {
                acc = allAccounts.Select(x => x).Where(x => x.Source == sourceType).ToList();
            }
            else
            {
                acc = null;
            }
            return acc;
        }

        public static IAccountSettings GetDetailsForAccount(this UserForAuthentication currentUser, Int32 accountId, Boolean owner = true)
        {
            ServiceAccountDTO serviceAcc = services.GetUserAccountsByUserIDAndAccountId(currentUser.UserID, accountId);
            IAccountSettings targetAcc = GetCurrentInstance(serviceAcc);
            targetAcc = targetAcc.ConvertFromDAO(serviceAcc);
            targetAcc.Owner = owner;
            return targetAcc;
        }


        public static Boolean SaveOrUpdateAccount(IAccountSettings account)
        {
            Boolean succeed = false;
            ServiceAccountDTO targetAccount = account.ConvertToDAO(account);
            succeed = services.SaveOrUdateAccount(targetAccount);
            return succeed;
        }


        public static Boolean DeleteToken(IAccountToken token)
        {
            Boolean succeed = false;
            TokenDTO targetToken = token.ConvertToDAO(token);
            succeed = services.DeleteToken(targetToken);
            return succeed;
        }

        public static Boolean CreateNewAccount(this UserForAuthentication currentUser,IAccountSettings newAccount)
        {
            Boolean succeed = false;
            ServiceAccountDTO targetnewAccount = newAccount.ConvertToDAO(newAccount);
            succeed = services.CreateNewAccount(currentUser.UserID, targetnewAccount);
            return succeed;
        }


        public static Boolean DeleteAccount(this UserForAuthentication currentUser, IAccountSettings accountToDelete, Boolean DeleteForAllUsers)
        {
            Boolean succeed = false;
            ServiceAccountDTO targetAccountToDelete = accountToDelete.ConvertToDAO(accountToDelete);
            succeed = services.DeleteAccount(currentUser.UserID, targetAccountToDelete, DeleteForAllUsers);
            return succeed;
        }


        /// <summary>
        /// Get user setting for each adapter. Where current user is not owner. Setting can not be changed.
        /// </summary>
        /// <param name="currentUser">Logged user.</param>
        /// <returns></returns>
        public static List<IAccountSettings> GetAllSharedUserAccounts(this UserForAuthentication currentUser)
        {
            ServiceAccountDTO[] allAcc = services.GetAllSharedUserAccountsByUserID(currentUser.UserID);
            List<IAccountSettings> targetAccs = new List<IAccountSettings>();
            foreach (ServiceAccountDTO account in allAcc)
            {
                IAccountSettings acc = GetCurrentInstance(account);
                if (acc != null)
                {
                    acc = acc.ConvertFromDAO(account);
                    acc.Owner = false;
                    targetAccs.Add(acc.ConvertFromDAO(account));
                }
            }
            return targetAccs;
        }


        public static Boolean ShareTheSettingAccount(this UserForAuthentication currentUser, IAccountSettings accountToShare, String shareUserName, Boolean owner)
        {
            Boolean succeed = false;
            ServiceAccountDTO targetAccountToShare = accountToShare.ConvertToDAO(accountToShare);
            succeed = services.ShareTheSettingAccount(currentUser.UserID, targetAccountToShare, shareUserName, owner);
            return succeed;
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
    }
}

