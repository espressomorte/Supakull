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

        public static List<IAccountSettings> GetAllUserAccounts(this UserForAuthentication currentUser)
        {
            ServiceAccountDTO[] allAcc = services.GetAllUserAccountsByUserID(currentUser.UserID);
            List<IAccountSettings> targetAccs = new List<IAccountSettings>();
            foreach (ServiceAccountDTO account in allAcc)
            {
                IAccountSettings acc = GetCurrentInstance(account);
                if (acc != null)
                {
                    targetAccs.Add(acc.ConvertFromDAO(account));
                }
            }
            return targetAccs;
        }

        public static List<IAccountSettings>GetAllUserAccountsInSource(List<IAccountSettings> allAccounts, Sources sourceType)
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

        public static IAccountSettings GetDetailsForAccount(this UserForAuthentication currentUser, Int32 accountId)
        {
            ServiceAccountDTO serviceAcc = services.GetUserAccountsByUserIDAndAccountId(currentUser.UserID, accountId);
            IAccountSettings targetAcc = GetCurrentInstance(serviceAcc);
            targetAcc = targetAcc.ConvertFromDAO(serviceAcc);
            return targetAcc;
        }

        public static void SaveOrUpdateAccount(IAccountSettings account)
        {
            ServiceAccountDTO targetAccount = account.ConvertToDAO(account);
            services.SaveOrUdateAccount(targetAccount);
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

