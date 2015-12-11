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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        private static Dictionary<IAccountSettings, IAdapter> accountAdapterLastUpdateDic;
        private static Timer autoUpdateTimer;
        private static DateTime dateOfLastUpdateAllAccounts;
        private static Int32 StartTimeForAutoUpdater;
        private static Int32 RepeatTimeForAutoUpdater;
        private static Int32 MinTimeForUpdateAllAccounts;
        private static Int32 TimeForIncreaseMinUpdateTime;
        private static Boolean ReadyForChekingAllAccounts = true;
        private static Boolean ReadyForRuningAllAdapters = true;

        static AutoUpdater()
        {
            var result = Int32.TryParse(ConfigurationManager.AppSettings["StartTimeForAutoUpdater"].ToString(), out StartTimeForAutoUpdater);
            result = Int32.TryParse(ConfigurationManager.AppSettings["RepeatTimeForAutoUpdater"].ToString(), out RepeatTimeForAutoUpdater);


            dateOfLastUpdateAllAccounts = DateTime.MinValue;
            accountAdapterLastUpdateDic = new Dictionary<IAccountSettings, IAdapter>();
            autoUpdateTimer = new Timer(new TimerCallback(AutoUpdate), null, StartTimeForAutoUpdater, RepeatTimeForAutoUpdater);
        }
        public static void AutoUpdate(Object obj)
        {
            if (ReadyForChekingAllAccounts)
            {
                ReadyForUpdateAllAccounts();
            }

            if (ReadyForRuningAllAdapters)
            {             
                ReadyForRuningAllAdapters = false;
                List<ITask> allTasksFromAdapter = new List<ITask>(500);
                var result = Int32.TryParse(ConfigurationManager.AppSettings["TimeForIncreaseMinUpdateTime"].ToString(), out TimeForIncreaseMinUpdateTime);
                IEnumerable<IAdapter> canRunAdapters = accountAdapterLastUpdateDic.Values.Where(ad => ad.CanRunUpdate()).ToList();
                Parallel.ForEach(canRunAdapters, a =>
                {
                    try
                    {    
                        allTasksFromAdapter.AddRange(RunAdapter(a));
                        a.adapterLastUpdate = DateTime.Now;
                    }
                    catch (TrelloNet.TrelloException treloEX)
                    {
                        log.Error(treloEX.Message, treloEX);
                        a.MinUpdateTime += TimeForIncreaseMinUpdateTime; 
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message, ex);
                        throw;
                    }

                });
                try
                {
                    if(allTasksFromAdapter.Count > 0)
                    {
                        IList<TaskMainDAO> taskDaoFromDB = TaskMainDAO.GetAllTasksFromDB();
                        IList<ITask> taskFromDB = ConverterDAOtoDomain.TaskMainDaoToTaskMain(taskDaoFromDB);
                        List<ITask> tasksToMatchAndSave = new List<ITask>(allTasksFromAdapter);
                        tasksToMatchAndSave.AddRange(taskFromDB);

                        IMatchTasks taskMatcher = new MatchTasksById();
                        TaskMain.MatchTasks(tasksToMatchAndSave, taskMatcher);
                        IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDAO(tasksToMatchAndSave);
                        TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
                    }                    
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                }
                finally
                {
                    ReadyForRuningAllAdapters = true;
                }
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
        private static void ReadyForUpdateAllAccounts()
        {
            try
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
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
            finally
            {
                ReadyForChekingAllAccounts = true;
            }

        }

    }

}