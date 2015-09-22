using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using UnitTestProject.Class;
using NHibernate.Tool.hbm2ddl;

namespace UnitTestProject
{
    [TestClass]
    public class DBAccess
    {
        [TestMethod]
        public void CanGenerateSchema()
        {
            var nHibernateConfiguration = new Configuration();
            nHibernateConfiguration.Configure();
            nHibernateConfiguration.AddAssembly(typeof(ItemForTesting).Assembly);
            new SchemaExport(nHibernateConfiguration).Execute(false, true, false);
        }
    }
}
