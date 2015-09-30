using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SupakullTrackerServices.Class;
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
        public List<ProxyTaskMain> GetAllIssues()
        {
            var clientFactory = new NhibernateSessionFactory("App.hibernate.cfg.xml").SessionFactory;            

            using (var session = clientFactory.OpenSession())
            {
                IList<IssueDAO> issues = session.Query<IssueDAO>().ToList();
                List<ProxyTaskMain> proxyIs = ConverterToFromProxy.ConvertToProxyList(issues, true);
                return proxyIs;
            }
        }

        [WebMethod]
        public void StoreSources()
        {
            DataAccess dao = new DataAccess();
            List<IAdapter> adapters = new List<IAdapter>();
            adapters.Add(new DBAdapter());
            //adapters.Add(new TrelloAdapter());
            //adapters.Add(new ExcelAdapter());
            dao.StoreSources(adapters);
        }
    }
}
