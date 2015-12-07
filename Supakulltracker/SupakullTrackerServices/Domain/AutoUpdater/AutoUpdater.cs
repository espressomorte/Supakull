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
        private static Dictionary<IAccountSettings, IAdapter> accountAdapterLastUpdateDic;
        private static DateTime dateOfLastUpdateAllAccounts;
        private static Int32 StartTimeForAutoUpdater;
        private static Int32 RepeatTimeForAutoUpdater;
        private static Int32 MinTimeForUpdateAllAccounts;

        static AutoUpdater()
        {
            var result = Int32.TryParse(ConfigurationManager.AppSettings["StartTimeForAutoUpdater"].ToString(), out StartTimeForAutoUpdater);
            result = Int32.TryParse(ConfigurationManager.AppSettings["RepeatTimeForAutoUpdater"].ToString(), out RepeatTimeForAutoUpdater);


            dateOfLastUpdateAllAccounts = DateTime.MinValue;
            accountAdapterLastUpdateDic = new Dictionary<IAccountSettings, IAdapter>();
            Timer autoUpdateTimer = new Timer(_ => AutoUpdate(), new AutoResetEvent(false), StartTimeForAutoUpdater, RepeatTimeForAutoUpdater);
        }
        public static void AutoUpdate()
        {
            var result = Int32.TryParse(ConfigurationManager.AppSettings["MinTimeForUpdateAllAccounts"].ToString(), out MinTimeForUpdateAllAccounts);
            if ((DateTime.Now - dateOfLastUpdateAllAccounts).TotalMilliseconds > MinTimeForUpdateAllAccounts)
            {
                var accounts = SettingsManager.GetAllAccounts();
                foreach (var account in accounts)
                {
                    if (!accountAdapterLastUpdateDic.ContainsKey(account))
                    {
                        GetAdapterForAccount(account);
                        accountAdapterLastUpdateDic.Add(account, GetAdapterForAccount(account));

                    }
                }
                List<IAccountSettings> accForRemove = new List<IAccountSettings>();
                foreach (var account in accountAdapterLastUpdateDic.Keys)
                {
                    if (!accounts.Contains<IAccountSettings>(account))
                    {
                        accForRemove.Add(account);
                    }
                }
                foreach (var acc in accForRemove)
                {
                    accountAdapterLastUpdateDic.Remove(acc);
                }
                dateOfLastUpdateAllAccounts = DateTime.Now;
            }

            List<ITask> allTasks = new List<ITask>();
            IEnumerable<IAdapter> canRunAdapters = accountAdapterLastUpdateDic.Values.Where(ad => ad.CanRunUpdate());
            Parallel.ForEach(canRunAdapters, a =>
            {
                allTasks.AddRange(RunAdapter(a));
                a.adapterLastUpdate = DateTime.Now;
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

}