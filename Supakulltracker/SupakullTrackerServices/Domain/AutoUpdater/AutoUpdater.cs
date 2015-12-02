using SupakullTrackerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;

namespace SupakullTrackerServices
{
    public class AutoUpdater
    {
        private static Dictionary<IAccountSettings, AccountAdapterLastUpdate> accountAdapterLastUpdateDic;
        private static DateTime dateOfLastUpdateAllAccounts;
        private static Int32 StartTimeForAutoUpdater;
        private static Int32 RepeatTimeForAutoUpdater;
        private static Int32 MinTimeForUpdateAllAccounts;

        static AutoUpdater()
        {
            var result = Int32.TryParse(ConfigurationManager.AppSettings["StartTimeForAutoUpdater"].ToString(), out StartTimeForAutoUpdater);
            result = Int32.TryParse(ConfigurationManager.AppSettings["RepeatTimeForAutoUpdater"].ToString(), out RepeatTimeForAutoUpdater);
            result = Int32.TryParse(ConfigurationManager.AppSettings["MinTimeForUpdateAllAccounts"].ToString(), out MinTimeForUpdateAllAccounts);

            dateOfLastUpdateAllAccounts = DateTime.MinValue;
            accountAdapterLastUpdateDic = new Dictionary<IAccountSettings, AccountAdapterLastUpdate>();
            Timer autoUpdateTimer = new Timer(_ => AutoUpdate(), new AutoResetEvent(false), StartTimeForAutoUpdater, RepeatTimeForAutoUpdater);
        }
        public static void AutoUpdate()
        {

            if ((DateTime.Now - dateOfLastUpdateAllAccounts).TotalMilliseconds > MinTimeForUpdateAllAccounts)
            {
                var accounts = SettingsManager.GetAllAccounts();
                foreach (var account in accounts)
                {
                    if (account.Source == Sources.DataBase || account.Source == Sources.Trello)
                    {
                        if (!accountAdapterLastUpdateDic.ContainsKey(account))
                        {
                            AccountAdapterLastUpdate accAdapterLastUpdate = new AccountAdapterLastUpdate();
                            accAdapterLastUpdate.adapter = GetAdapterForAccount(account);
                            accAdapterLastUpdate.adapterLastUpdate = DateTime.MinValue;
                            accountAdapterLastUpdateDic.Add(account, accAdapterLastUpdate);
                        }
                    }
                }
                dateOfLastUpdateAllAccounts = DateTime.Now;
            }
            List<ITask> allTasks = new List<ITask>();
            Parallel.ForEach(accountAdapterLastUpdateDic, a =>
            {
                if ((DateTime.Now - a.Value.adapterLastUpdate ).TotalMilliseconds > a.Key.MinUpdateTime)
                {
                    allTasks.AddRange(RunAdapter(a.Value.adapter));
                    AccountAdapterLastUpdate newAccUdater;

                    if (accountAdapterLastUpdateDic.TryGetValue(a.Key, out newAccUdater) )
                    {
                        newAccUdater.adapterLastUpdate = DateTime.Now;
                        accountAdapterLastUpdateDic.Remove(a.Key);
                        accountAdapterLastUpdateDic.Add(a.Key, newAccUdater);
                    }                           
                }
            });
            IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDAO(allTasks);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }

        private static IAdapter GetAdapterForAccount(IAccountSettings account)
        {
            // TODO. Here the common code, which currently resides on client project should be used.
            // GetCurrentInstance from SettingsManager.cs
            var adapter = AdapterInstanceFactory.GetCurentAdapterInstance(account.Source);
            return adapter.GetAdapter(account);
        }

        private static IList<ITask> RunAdapter(IAdapter adapter)
        {
            return adapter.GetAllTasks();
        }
    }
    public struct AccountAdapterLastUpdate
    {
        public IAdapter adapter { get; set; }
        public DateTime adapterLastUpdate { get; set; }
    }

}