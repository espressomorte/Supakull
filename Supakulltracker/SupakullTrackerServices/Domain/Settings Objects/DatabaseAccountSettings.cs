using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public class DatabaseAccountSettings : IAccountSettings
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Sources Source { get; set; }
        public List<DatabaseAccountToken> Tokens { get; set; }
    }

    public class DatabaseAccountToken : IAccountToken
    {
        public Int32 TokenId { get; set; }
        public String TokenName { get; set; }
        public String ConnectionString { get; set; }
        public DatabaseDriver DatabaseDriver { get; set; }
        public DatabaseDialect DatabaseDialect { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String DataSource { get; set; }
        public String Mapping { get; set; }
    }

    public enum DatabaseDriver
    {
        OracleClientDriver,
        SqlClientDriver
    }

    public enum DatabaseDialect
    {
        Oracle8iDialect,
        Oracle9iDialect,
        Oracle10gDialect,
        MsSql2005Dialect
    }
}
