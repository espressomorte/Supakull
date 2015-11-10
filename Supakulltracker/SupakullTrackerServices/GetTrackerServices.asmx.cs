using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SupakullTrackerServices;
using NHibernate;
using NHibernate.Linq;
using TrelloManagerApp;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]



namespace SupakullTrackerServices
{
    /// <summary>
    /// Summary description for GetTrackerServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetTrackerServices : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [WebMethod]
        public List<TaskMainDTO> GetAllTasks()
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                IList<TaskMainDAO> taskMainDaoCollection = session.Query<TaskMainDAO>().ToList();
                IList<ITask> taskMainCollection = ConverterDAOtoDomain.TaskMainDaoToTaskMainCollection(taskMainDaoCollection);
                List<TaskMainDTO> taskMainDtoCollection = ConverterDomainToDTO.TaskMainToTaskMainDtoCollection(taskMainCollection);
                return taskMainDtoCollection;
            }
        }

        #region Update
        [WebMethod]
        public void Update()
        {
            ICollection<IAdapter> adapters = GetAllAdapters();
            IList<ITask> allTaskMainFromAdapters = GetAllTasksFromAdapterCollection(adapters);

            IMatchTasks taskMatcher = new MatchTasksById();
            TaskMain.MatchTasks(allTaskMainFromAdapters, taskMatcher);
            AddDisagreementsToTasks(allTaskMainFromAdapters);

            IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDaoCollection(allTaskMainFromAdapters);
            TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }
        
        private ICollection<IAdapter> GetAllAdapters()
        {
            ICollection<IAdapter> adapters = new List<IAdapter>();
            adapters.Add(new DBAdapter());
            adapters.Add(new TrelloManager("ded104e76f80e7dbe0c3f9ecc8f3591ee32af8fdfa90d32441380ccb1fcd35ee"));
            adapters.Add(new GoogleSheetsAdapter());
            adapters.Add(new ExcelAdapter(@"C:\EPPLus.xlsx"));
            return adapters;
        }

        private IList<ITask> GetAllTasksFromAdapterCollection(ICollection<IAdapter> adapters)
        {
            List<ITask> allTasksFromAdapterCollection = new List<ITask>();
            foreach (IAdapter adapter in adapters)
            {
                allTasksFromAdapterCollection.AddRange(adapter.GetAllTasks());
            }
            return allTasksFromAdapterCollection;
        }

        private void AddDisagreementsToTasks(IList<ITask> allTaskMainFromAdapters)
        {
            foreach (ITask taskMain in allTaskMainFromAdapters)
            {
                if (taskMain.MatchedCount > 0)
                {
                    List<ITask> matchedTasks = new List<ITask>();
                    matchedTasks.Add(taskMain);
                    matchedTasks.AddRange(taskMain.MatchedTasks);
                    IEnumerable<Disagreement> disagreements = TaskMain.GetDisagreements(matchedTasks);
                    foreach (ITask matchedTask in matchedTasks)
                    {
                        matchedTask.AddDisagreementCollection(disagreements);
                    }
                }
            }
        }
        #endregion


        #region ServicesForReadingSettings

        [WebMethod]
        public List<ServiceAccountDTO> GetAllUserAccountsByUserID(Int64 userId)
        {
            List<ServiceAccountDTO> allUserAccountsDTO;

            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (ISession session = sessionFactory.OpenSession())
            {
                var allUserLinks = session.QueryOver<UserLinkDAO>().Where(x => x.UserId == userId).List();
                if (allUserLinks != null)
                {
                    List<ServiceAccountDAO> allUserAccountsDAO = allUserLinks.Select<UserLinkDAO, ServiceAccountDAO>(x => x.Account).ToList();
                    List<ServiceAccount> allUserAccounts = allUserAccountsDAO.ServiceAccountDAOCollectionToDomain();
                    allUserAccountsDTO = allUserAccounts.ServiceAccountDomainCollectionToDTO();
                }
                else
                {
                     allUserAccountsDTO = null;
                }

                return allUserAccountsDTO;
            }
        }

        [WebMethod]
        public ServiceAccountDTO GetUserAccountsByUserIDAndAccountId(Int64 userId, Int32 seviceAccountId)
        {
            ServiceAccountDTO UserAccountsDTO;


            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (ISession session = sessionFactory.OpenSession())
            {
                UserLinkDAO userLink = session.QueryOver<UserLinkDAO>().Where(x => x.UserId == userId).And(x => x.ServiceAccountId == seviceAccountId).SingleOrDefault();
                if (userLink != null)
                {
                    UserAccountsDTO = userLink.Account.ServiceAccountDAOToDomain().ServiceAccountDomainToDTO(IsDetailsNeed: true);
                }
                else
                {
                    UserAccountsDTO = null;
                }

                return UserAccountsDTO;
            }
        }


        #endregion
    }
}
