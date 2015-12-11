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
        private static List<ITask> allTasksForAdding;
        private static Timer autoUpdateTimer;
        private static DateTime dateOfLastUpdateAllAccounts;
        private static Int32 StartTimeForAutoUpdater;
        private static Int32 RepeatTimeForAutoUpdater;
        private static Int32 MinTimeForUpdateAllAccounts;
        private static Int32 TimeForIncreaseMinUpdateTime;
        private static Boolean readyForChekingAllAccounts = true;
        private static Boolean readyForRuningAllAdapters = true;
        private static Boolean isTaskListInUse = false;

        static AutoUpdater()
        {
            var result = Int32.TryParse(ConfigurationManager.AppSettings["StartTimeForAutoUpdater"].ToString(), out StartTimeForAutoUpdater);
            result = Int32.TryParse(ConfigurationManager.AppSettings["RepeatTimeForAutoUpdater"].ToString(), out RepeatTimeForAutoUpdater);


            dateOfLastUpdateAllAccounts = DateTime.MinValue;
            accountAdapterLastUpdateDic = new Dictionary<IAccountSettings, IAdapter>();
            allTasksForAdding = new List<ITask>();
            autoUpdateTimer = new Timer(new TimerCallback(AutoUpdate), null, StartTimeForAutoUpdater, RepeatTimeForAutoUpdater);
        }
        public static void AutoUpdate(Object obj)
        {
            if (readyForChekingAllAccounts)
            {
                ReadyForUpdateAllAccounts();
            }

            if (readyForRuningAllAdapters)
            {
                readyForRuningAllAdapters = false;
                List<ITask> allTasks = new List<ITask>(500);
                var result = Int32.TryParse(ConfigurationManager.AppSettings["TimeForIncreaseMinUpdateTime"].ToString(), out TimeForIncreaseMinUpdateTime);
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
                    if (allTasksForAdding.Count > 0)
                    {
                        isTaskListInUse = true;
                        allTasks.AddRange(allTasksForAdding);
                        allTasksForAdding.Clear();
                        isTaskListInUse = false;
                    }
                    IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDAO(allTasks);

                    TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                }
                finally
                {
                    readyForRuningAllAdapters = true;
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
                readyForChekingAllAccounts = false;
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
                readyForChekingAllAccounts = true;
            }

        }

        public static void AddTaskForSaveving(IList<ITask> tasksForSaving)
        {
            if (isTaskListInUse)
            {
                do
                {
                    Thread.Sleep(250); 
                } while (isTaskListInUse);
            }
                isTaskListInUse = true;
                allTasksForAdding.AddRange(tasksForSaving);
                isTaskListInUse = false;   
        }

    }

}