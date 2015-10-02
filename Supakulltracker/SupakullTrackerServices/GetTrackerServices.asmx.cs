using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SupakullTrackerServices;
using NHibernate;
using NHibernate.Linq;
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
        public List<TaskMainDTO> GetAllIssues()
        {
            var clientFactory = new NhibernateSessionFactory("App.hibernate.cfg.xml").SessionFactory;
            IList<IssueDAO> issuesDaoCollection;
            using (var session = clientFactory.OpenSession())
            {
                issuesDaoCollection = session.Query<IssueDAO>().ToList();
                IList<ITask> taskMainCollection = ConverterDAOtoDomain.IssueDaoToTaskMainCollection(issuesDaoCollection, true);
                List<TaskMainDTO> taskMainDtoCollection = ConverterDomainToDTO.TaskMainToTaskMainDtoCollection(taskMainCollection, true);
                return taskMainDtoCollection;
            }            
        }

        [WebMethod]
        public void StoreSources()
        {
            DataAccess dao = new DataAccess();
            ICollection<IAdapter> adapters = GetAllAdapters();
            dao.GetAllItemsFromAdaptersAndStoreToDbDirectly(adapters);
        }

        private ICollection<IAdapter> GetAllAdapters()
        {
            ICollection<IAdapter> adapters = new List<IAdapter>();
            adapters.Add(new DBAdapter());
            //adapters.Add(new TrelloAdapter());
            //adapters.Add(new ExcelAdapter());
            return adapters;
        }
    }
}
