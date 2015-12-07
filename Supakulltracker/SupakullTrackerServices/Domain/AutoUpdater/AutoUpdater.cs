﻿using SupakullTrackerServices;
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        private static Dictionary<IAccountSettings, IAdapter> accountAdapterLastUpdateDic;
        private static DateTime dateOfLastUpdateAllAccounts;
        private static Int32 StartTimeForAutoUpdater;
        private static Int32 RepeatTimeForAutoUpdater;
        private static Int32 MinTimeForUpdateAllAccounts;
        private static Boolean ReadyForChekingAllAccounts = true;
        private static Boolean ReadyForRuningAllAdapters = true;

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
            if (ReadyForChekingAllAccounts)
            {
                ReadyForChekingAllAccounts = false;
                var result = Int32.TryParse(ConfigurationManager.AppSettings["MinTimeForUpdateAllAccounts"].ToString(), out MinTimeForUpdateAllAccounts);
                if ((DateTime.Now - dateOfLastUpdateAllAccounts).TotalMilliseconds > MinTimeForUpdateAllAccounts)
                {
                    var accounts = SettingsManager.GetAllAccounts();
                    foreach (var account in accounts)
                    {
                        if (account.Source != Sources.Excel)
                        {
                            if (!accountAdapterLastUpdateDic.ContainsKey(account))
                            {
                                IAdapter adapter = GetAdapterForAccount(account);
                                accountAdapterLastUpdateDic.Add(account, adapter);
                            }
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
                ReadyForChekingAllAccounts = true;
            }

            if (ReadyForRuningAllAdapters)
            {
                ReadyForRuningAllAdapters = false;
                List<ITask> allTasks = new List<ITask>(500);
                IEnumerable<IAdapter> canRunAdapters = accountAdapterLastUpdateDic.Values.Where(ad => ad.CanRunUpdate()).ToList();
                Parallel.ForEach(canRunAdapters, a =>
                {
                    try
                    {    
                        allTasks.AddRange(RunAdapter(a));
                        a.adapterLastUpdate = DateTime.Now;
                    }
                    catch (TrelloNet.TrelloException treloEX)
                    {
                        log.Error(treloEX.Message, treloEX);
                        a.MinUpdateTime += 60000; 
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message, ex);
                        throw;
                    }

                });
                IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDAO(allTasks);
                TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
                ReadyForRuningAllAdapters = true;
            }
            
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