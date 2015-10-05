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
            List<TaskMainDTO> aTaskList = new List<TaskMainDTO>();
            aTaskList.Add(new TaskMainDTO() { Summary = "My Task", Status = "Like new" });
            return aTaskList;

            NhibernateSessionFactory.Add("Application", "App.hibernate.cfg.xml");
            ISessionFactory applicationFactory = NhibernateSessionFactory.GetSessionFactory("Application");

            using (var session = applicationFactory.OpenSession())
            {
                IList<TaskMainDAO> taskMainDaoCollection = session.Query<TaskMainDAO>().ToList();
                IList<ITask> taskMainCollection = ConverterDAOtoDomain.TaskMainDaoToTaskMainCollection(taskMainDaoCollection, true);
                List<TaskMainDTO> taskMainDtoCollection = ConverterDomainToDTO.TaskMainToTaskMainDtoCollection(taskMainCollection, true);
                return taskMainDtoCollection;
            }            
        }

        #region StoreSources
        [WebMethod]
        public void StoreSources()
        {
            System.Threading.Thread.Sleep(30000);
            return;
            ICollection<IAdapter> adapters = GetAllAdapters();
            IList<ITask> allTaskMainFromAdapters = GetAllTasksFromAdapterCollection(adapters);
            IList<TaskMainDAO> taskMainDaoCollection = ConverterDomainToDAO.TaskMainToTaskMainDaoCollection(allTaskMainFromAdapters);
            TaskMainDAO.StoreToDB(taskMainDaoCollection);
        }

        private ICollection<IAdapter> GetAllAdapters()
        {
            ICollection<IAdapter> adapters = new List<IAdapter>();
            adapters.Add(new DBAdapter());
            adapters.Add(new TrelloManager("4c298896003406f6fce126eec5b6830589ef1bbc63996b2853fee5925ee4701f"));
            //adapters.Add(new ExcelAdapter());
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

        //private IList<ITask> GetAllTasksFromAdapterSingle(IAdapter adapter)
        //{
        //    return taskMainCollection = adapter.GetAllItems();


        //    IList<TaskMainDAO> issueDaoCollection = ConverterDomainToDAO.TaskMainToIssueDaoCollection(taskMainCollection, false);
        //    var clientFactory = new NhibernateSessionFactory("App.hibernate.cfg.xml").SessionFactory;
        //    foreach (TaskMainDAO task in issueDaoCollection)
        //    {
        //        using (var session = clientFactory.OpenSession())
        //        {
        //            using (ITransaction transaction = session.BeginTransaction())
        //            {
        //                session.SaveOrUpdate(task);
        //                transaction.Commit();
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
