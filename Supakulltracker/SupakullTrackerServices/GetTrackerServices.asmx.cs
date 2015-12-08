using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using NHibernate;
using NHibernate.Linq;
using System.Web.Services.Protocols;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

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
        private static AutoUpdater updater;
        static GetTrackerServices()
        {
            updater = new AutoUpdater();
        }

        [WebMethod]
        public List<TaskMainDTO> GetAllTasks()
        {        
                IList<TaskMainDAO> taskMainDaoCollection = TaskMainDAO.GetAllTasksFromDB();
                IList<ITask> taskMainCollection = ConverterDAOtoDomain.TaskMainDaoToTaskMain(taskMainDaoCollection);
                List<TaskMainDTO> taskMainDtoCollection = ConverterDomainToDTO.TaskMainToTaskMainDTO(taskMainCollection);
                return taskMainDtoCollection;
            
        }

        [WebMethod]
        public List<TaskMainDTO> FindTasks(string textQuery)
        {
            SearchProviderDAO searchProvider = new SearchProviderDAO();
            IList<TaskMainDAO> taskMainDAO = searchProvider.Find(textQuery);
            IList<ITask> taskMain = ConverterDAOtoDomain.TaskMainDaoToTaskMain(taskMainDAO);
            List<TaskMainDTO> taskMainDTO = ConverterDomainToDTO.TaskMainToTaskMainDTO(taskMain);
            return taskMainDTO;
        }

        [WebMethod]
        public List<TaskMainDTO> GetMatchedTasks(string taskID, Sources linkToTracker, Int32 tokenID)
        {
            TaskMainDAO taskMainDAO = TaskMainDAO.GetTaskFromDB(taskID, linkToTracker, tokenID);
            ITask taskMain = ConverterDAOtoDomain.TaskMainDaoToTaskMain(taskMainDAO);

            List<ITask> matchedTasks = new List<ITask>();
            matchedTasks.Add(taskMain);
            matchedTasks.AddRange(taskMain.MatchedTasks);

            List<TaskMainDTO> taskMainDTO = ConverterDomainToDTO.TaskMainToTaskMainDTO(matchedTasks);
            return taskMainDTO;
        }

        [WebMethod]
        public void GetTasksFromExcel(Byte[] fileForParce, Int32 tokenID, String updateTime)
        {
            try
            {
                ExcelAdapter excelAdapter = new ExcelAdapter(fileForParce, tokenID);
                excelAdapter.RunAdapter();
                IList<ITask> allTasksFromexcel = excelAdapter.GetAllTasks();
                if (allTasksFromexcel != null)
                {
                    IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDAO(allTasksFromexcel);
                    TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
                    excelAdapter.ID = tokenID;
                    excelAdapter.UpdateTokenLastUpdateTime(updateTime);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new SoapException("Fault occurred", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, ex);
            }
        }


        [WebMethod]
        public ServiceAccountDTO TestExcelAccount(ServiceAccountDTO accountForTest, Byte[] fileForParce)
        {
            IAccountSettings currentAccountForTest = SettingsManager.GetCurrentInstance(accountForTest.Source);

            currentAccountForTest = currentAccountForTest.Convert(accountForTest.ServiceAccountDTOToDomain());
            ExcelAdapter currentAdapter = new ExcelAdapter(currentAccountForTest, fileForParce);

            IAccountSettings testResult = currentAdapter.TestAccount(currentAccountForTest);
            ServiceAccount resultDomain = new ServiceAccount();
            resultDomain = testResult.Convert(testResult);
            ServiceAccountDTO result = resultDomain.ServiceAccountDomainToDTO();
            return result;
        }

        [WebMethod]
        public Boolean UpdateTokenNameForExcel(Int32 tokeID, String newTokenName)
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                ISQLQuery query = session.CreateSQLQuery(String.Format(@"UPDATE TOKENS_IN_ACCOUNT SET TOKEN_NAME = '{0}' WHERE TOKEN_ID = {1}", newTokenName, tokeID));
                Int32 number = query.ExecuteUpdate();
                session.Flush();
                if (number > 0)
                {
                    return true;
                } 
            }
            return false;
        }

        #region Update
        [WebMethod]
        public void GenerateIndexes()
        {
            SearchProviderDAO searchProvider = new SearchProviderDAO();
            searchProvider.GenerateIndexes();
        }
        
        [WebMethod]
        public void Update()
        {
            //ICollection<IAdapter> adapters = GetAllAdapters();
            //IList<ITask> allTaskMainFromAdapters = GetAllTasksFromAdapterCollection(adapters);

            //IMatchTasks taskMatcher = new MatchTasksById();
            //TaskMain.MatchTasks(allTaskMainFromAdapters, taskMatcher);
            //IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDAO(allTaskMainFromAdapters);
            //TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        }
        //[WebMethod]
        //public void UpdateTasksOfLoggedUsers()
        //{
        //    {
        //        List<ITask> allTaskMainFromAdapters=null;
        //        foreach (var loggedUser in loggedUsers)
        //        {
        //            allTaskMainFromAdapters.AddRange( GetAllTasksFromAdapterCollection(loggedUser.userAdapters));
        //        }

        //        IMatchTasks taskMatcher = new MatchTasksById();
        //        TaskMain.MatchTasks(allTaskMainFromAdapters, taskMatcher);

        //        IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDAO(allTaskMainFromAdapters);
        //        TaskMainDAO.SaveOrUpdateCollectionInDB(taskMainDaoCollection);
        //    }
        //}
        //private ICollection<IAdapter> GetAllAdapters()
        //{
        //    ICollection<IAdapter> adapters = new List<IAdapter>();
        //    adapters.Add(new DatabaseAdapter());
        //    // adapters.Add(new TrelloManager("ded104e76f80e7dbe0c3f9ecc8f3591ee32af8fdfa90d32441380ccb1fcd35ee"));
        //    // adapters.Add(new GoogleSheetsAdapter());
        //    adapters.Add(new ExcelAdapter(@"C:\EPPLus.xlsx"));
        //    return adapters;
        //}

        //public ICollection<IAdapter> GetAllAdaptersByUserID(Int32 userId)
        //{
        //    List<ServiceAccountDTO> allAccountsForUser = GetAllUserAccountsByUserID(userId);
        //    allAccountsForUser.AddRange(GetAllSharedUserAccountsByUserID(userId));
        //    ICollection<IAdapter> adapters = new List<IAdapter>();
        //    foreach (var account in allAccountsForUser)
        //    {
        //        switch (account.Source)
        //        {
        //            case Sources.DataBase:
        //                adapters.Add(new DatabaseAdapter());
        //                break;
        //            case Sources.Trello:
        //                //adapters.Add(new TrelloManager().GetAllTasksByToken(account.Tokens));
        //                break;
        //            case Sources.Excel:
        //                adapters.Add(new GoogleSheetsAdapter());
        //                break;
        //            case Sources.GoogleSheets:

        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    return adapters;
        //}

        //private IList<ITask> GetAllTasksFromAdapterCollection(ICollection<IAdapter> adapters)
        //{
        //    List<ITask> allTasksFromAdapterCollection = new List<ITask>();
        //    Parallel.ForEach(adapters, a =>
        //    {
        //        if (a is DatabaseAdapter)
        //        {
        //            allTasksFromAdapterCollection.AddRange(((DatabaseAdapter)a).GetAllTasks(272));
        //        }
        //        else
        //        {
        //            allTasksFromAdapterCollection.AddRange(a.GetAllTasks());
        //        }
        //    });

        //    allTasksFromAdapterCollection.AddRange(new DatabaseAdapter().GetAllTasks(356));
        //    return allTasksFromAdapterCollection;
        //}
        #endregion


        #region ServicesForReadingSettings

        [WebMethod]
        public List<ServiceAccountDTO> GetAllUserAccountsByUserID(Int32 userId)
        {
            return AllUserAccountsByUserID(userId, true);

        }

        [WebMethod]
        public ServiceAccountDTO GetUserAccountsByUserIDAndAccountId(Int32 userId, Int32 seviceAccountId)
        {
            ServiceAccountDTO UserAccountsDTO;


            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (ISession session = sessionFactory.OpenSession())
            {
                UserLinkDAO userLink = session.QueryOver<UserLinkDAO>().Where(x => x.UserId == userId).And(x => x.Account.ServiceAccountId == seviceAccountId).SingleOrDefault();
                if (userLink != null)
                {
                    ServiceAccount account = userLink.Account.ServiceAccountDAOToDomain(IsDetailsNeed: true);
                    UserAccountsDTO = account.ServiceAccountDomainToDTO();
                }
                else
                {
                    UserAccountsDTO = null;
                }

                return UserAccountsDTO;
            }
        }


        [WebMethod]
        public Boolean SaveOrUdateAccount(ServiceAccountDTO account)
        {
            Boolean succeed = false;
            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            ServiceAccountDAO target = account.ServiceAccountDTOToDomain().ServiceAccountDomainToDAO();
            using (ISession session = sessionFactory.OpenSession())
            {
                target.AccountVersion += 1;
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(target);
                    transaction.Commit();
                    succeed = transaction.WasCommitted;
                }
            }
            return succeed;
        }

        [WebMethod]
        public Boolean DeleteToken(TokenDTO token)
        {
            Boolean succeed = false;
            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            TokenDAO target = token.TokenDTOToTokenDomain().TokenToTokenDAO();
            using (ISession session = sessionFactory.OpenSession())
            {
                ServiceAccountDAO account = session.Query<ServiceAccountDAO>().Where(acount => acount.Tokens.Contains(target)).SingleOrDefault();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(target);
                    transaction.Commit();
                    succeed = transaction.WasCommitted;
                }
                if (succeed)
                {
                    UpdateAccountVersion(account.ServiceAccountId, account.AccountVersion + 1);
                }

            }
            return succeed;
        }

        [WebMethod]
        public Boolean DeleteMapping(TemplateDTO template)
        {
            Boolean succeed = false;
            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            TemplateDAO target = template.TemplateDTOToTemplateDomain().TemplateToTemplateDAO();
            using (ISession session = sessionFactory.OpenSession())
            {
                ServiceAccountDAO account = session.Query<ServiceAccountDAO>().Where(acount => acount.MappingTemplates.Contains(target)).SingleOrDefault();
                using (ITransaction transaction = session.BeginTransaction())
                {             
                    session.Delete(target);
                    transaction.Commit();
                    succeed = transaction.WasCommitted;
                    if (succeed)
                    {
                        UpdateAccountVersion(account.ServiceAccountId, account.AccountVersion + 1);
                    }
                }

            }
            return succeed;
        }

        private Boolean UpdateAccountVersion(Int32 acID, Int32 newVersion)
        {
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            using (var session = applicationFactory.OpenSession())
            {
                ISQLQuery query = session.CreateSQLQuery(String.Format(@"UPDATE SERVICE_ACCOUNT SET ACCOUNT_VERSION = '{0}' WHERE SERVICE_ID = {1}", newVersion, acID));
                Int32 number = query.ExecuteUpdate();
                session.Flush();
                if (number > 0)
                {
                    return true;
                }
            }
            return false;
        }

        [WebMethod]
        public Boolean CreateNewAccount(Int32 UserID, ServiceAccountDTO newAccount)
        {
            Boolean succeed = false;
            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            UserLinkDAO newUserLink = new UserLinkDAO();
            ServiceAccountDAO target = newAccount.ServiceAccountDTOToDomain().ServiceAccountDomainToDAO();
            target.AccountVersion = 0;
            newUserLink.UserOwnerID = UserID;
            newUserLink.Account = target;
            newUserLink.Owner = true;
            newUserLink.UserId = UserID;

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.Save(newUserLink);
                    transaction.Commit();
                    succeed = transaction.WasCommitted;
                }

            }
            return succeed;
        }

        [WebMethod]
        public Boolean DeleteAccount(Int32 UserID, ServiceAccountDTO accountToDelete, Boolean DeleteForAllUsers)
        {
            Boolean succeed = false;
            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            ServiceAccountDAO targetAccountToDelete = accountToDelete.ServiceAccountDTOToDomain().ServiceAccountDomainToDAO();
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    UserLinkDAO userLink = session.QueryOver<UserLinkDAO>().Where(x => x.Account.ServiceAccountId == accountToDelete.ServiceAccountId).And(x => x.UserId == UserID).SingleOrDefault();
                    if (userLink != null)
                    {
                        try
                        {
                            IList<UserLinkDAO> Links = session.QueryOver<UserLinkDAO>().Where(x => x.Account.ServiceAccountId == accountToDelete.ServiceAccountId).List();

                            if (DeleteForAllUsers)
                            {
                                foreach (var item in Links)
                                {
                                    session.Delete(item);
                                }
                                session.Delete(targetAccountToDelete);
                            }
                            else
                            {
                                if (Links.Count == 1)
                                {
                                    session.Delete(targetAccountToDelete);
                                }
                                session.Delete(userLink);
                            }

                            transaction.Commit();
                            succeed = transaction.WasCommitted;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return succeed;
                        }
                    }

                }

            }
            return succeed;
        }

        [WebMethod]
        public List<ServiceAccountDTO> GetAllSharedUserAccountsByUserID(Int32 userId)
        {
            return AllUserAccountsByUserID(userId, false);
        }

        [WebMethod]
        public Boolean ShareTheSettingAccount(Int32 currentUserID, ServiceAccountDTO accountToShare, String shareUserName, Boolean owner)
        {
            Boolean succeed = false;
            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);

            UserDAO shareUser;
            UserLinkDAO newUserLink = new UserLinkDAO();
            ServiceAccountDAO targetShareAccount = accountToShare.ServiceAccountDTOToDomain().ServiceAccountDomainToDAO();
            newUserLink.Account = targetShareAccount;
            newUserLink.Owner = owner;
            newUserLink.UserOwnerID = currentUserID;

            using (ISession session = sessionFactory.OpenSession())
            {
                shareUser = session.QueryOver<UserDAO>().Where(user => user.UserId == shareUserName).SingleOrDefault();
                if (shareUser != null)
                {
                    newUserLink.UserId = shareUser.ID;
                    UserLinkDAO checkLink = session.QueryOver<UserLinkDAO>().Where(link => link.Account.ServiceAccountId == targetShareAccount.ServiceAccountId).And(link => link.UserId == shareUser.ID).SingleOrDefault();
                    if (checkLink == null)
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            session.Save(newUserLink);
                            transaction.Commit();
                            succeed = transaction.WasCommitted;
                        }
                    }
                    else
                    {
                        return succeed;
                    }
                }
            }
            return succeed;
        }


        private List<ServiceAccountDTO> AllUserAccountsByUserID(Int32 userId, Boolean owner)
        {
            List<ServiceAccountDTO> allUserAccountsDTO;

            ISessionFactory sessionFactory = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application);
            using (ISession session = sessionFactory.OpenSession())
            {
                var allUserLinks = session.QueryOver<UserLinkDAO>().Where(x => x.UserId == userId).And(link => link.Owner == owner).List();
                if (allUserLinks != null)
                {
                    List<ServiceAccountDAO> allUserAccountsDAO = allUserLinks.Select<UserLinkDAO, ServiceAccountDAO>(x => x.Account).ToList();
                    List<ServiceAccount> alAcc = SettingsConverter.ServiceAccountDAOCollectionToDomain(allUserAccountsDAO);
                    allUserAccountsDTO = SettingsConverter.ServiceAccountDomainCollectionToDTO(alAcc);
                }
                else
                {
                    allUserAccountsDTO = null;
                }

                return allUserAccountsDTO;
            }
        }


        [WebMethod]
        public ServiceAccountDTO TestAccount(ServiceAccountDTO accountForTest)
        {
            IAdapter currentAdapter = AdapterInstanceFactory.GetCurentAdapterInstance(accountForTest.Source);
            if (currentAdapter != null)
            {
                IAccountSettings currentAccountForTest = SettingsManager.GetCurrentInstance(accountForTest.Source);

                currentAccountForTest = currentAccountForTest.Convert(accountForTest.ServiceAccountDTOToDomain());

                IAccountSettings testResult = currentAdapter.TestAccount(currentAccountForTest);
                ServiceAccount resultDomain = new ServiceAccount();
                resultDomain = testResult.Convert(testResult);
                ServiceAccountDTO result = resultDomain.ServiceAccountDomainToDTO();
                return result;
            }
            else
            {
                accountForTest.TestResult = false;
                return accountForTest;
            }

        }
        #endregion
    }
}
