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

        public static ServiceAccountDTO[] GetAllUserAccounts(this UserForAuthentication currentUser)
        {
            return services.GetAllUserAccountsByUserID(currentUser.UserID);
        }

        public static ServiceAccountDTO[] GetAllUserAccountsInSource(this UserForAuthentication currentUser, Sources sourceType)
        {
            ServiceAccountDTO[] accountsInSource;
            ServiceAccountDTO[] allAccounts = GetAllUserAccounts(currentUser);
            if (allAccounts != null)
            {
                accountsInSource = allAccounts.Select<ServiceAccountDTO, ServiceAccountDTO>(x => x).Where(x => x.Source == sourceType).ToArray();
            }
            else
            {
                accountsInSource = null;
            }
            return accountsInSource;
        }

        public static ServiceAccountDTO GetDetailsForAccount (this UserForAuthentication currentUser, Int32 accountId)
        {
            return services.GetUserAccountsByUserIDAndAccountId(currentUser.UserID, accountId);
        }
    }
}
