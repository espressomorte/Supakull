using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using UnitTests.Class;

namespace UnitTests
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
