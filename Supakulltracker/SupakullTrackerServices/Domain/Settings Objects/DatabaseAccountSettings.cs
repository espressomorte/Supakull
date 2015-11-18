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

        public IAccountSettings Convert(ServiceAccountDAO serviceAccount)
        {
            DatabaseAccountSettings target = new DatabaseAccountSettings();
            target.ID = serviceAccount.ServiceAccountId;
            target.Name = serviceAccount.ServiceAccountName;
            target.Source = serviceAccount.Source;
            target.Tokens = new List<DatabaseAccountToken>();

            if (serviceAccount.Tokens.Count > 0)
            {
                foreach (TokenDAO token in serviceAccount.Tokens)
                {
                    DatabaseAccountToken targetToken = new DatabaseAccountToken();
                    targetToken = (DatabaseAccountToken)targetToken.Convert(token);
                    target.Tokens.Add(targetToken);
                }
            }
            return target;
        }

        public IAccountSettings Convert(ServiceAccountDTO serviceAccount)
        {
            DatabaseAccountSettings target = new DatabaseAccountSettings();
            target.ID = serviceAccount.ServiceAccountId;
            target.Name = serviceAccount.ServiceAccountName;
            target.Source = serviceAccount.Source;
            target.Tokens = new List<DatabaseAccountToken>();

            if (serviceAccount.Tokens.Count > 0)
            {
                foreach (TokenDTO token in serviceAccount.Tokens)
                {
                    DatabaseAccountToken targetToken = new DatabaseAccountToken();
                    targetToken = (DatabaseAccountToken)targetToken.Convert(token);
                    target.Tokens.Add(targetToken);
                }
            }
            return target;
        }
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

        public IAccountToken Convert(TokenDAO token)
        {
            DatabaseAccountToken targetToken = new DatabaseAccountToken();
            targetToken.TokenId = token.TokenId;
            targetToken.TokenName = token.TokenName;
            if (token.Token != null)
            {

                targetToken.Mapping = (from tok in token.Token
                                       where tok.Key == "Mapping"
                                       select tok.Value).SingleOrDefault();

                targetToken.Password = (from tok in token.Token
                                        where tok.Key == "Password"
                                        select tok.Value).SingleOrDefault();

                targetToken.ConnectionString = (from tok in token.Token
                                                where tok.Key == "ConnectionString"
                                                select tok.Value).SingleOrDefault();

                targetToken.UserName = (from tok in token.Token
                                        where tok.Key == "UserName"
                                        select tok.Value).SingleOrDefault();

                targetToken.DataSource = (from tok in token.Token
                                          where tok.Key == "DataSource"
                                          select tok.Value).SingleOrDefault();

                String dialect = (from tok in token.Token
                                    where tok.Key == "DatabaseDialect"
                                    select tok.Value).SingleOrDefault();

                DatabaseDialect dbDialect;
                Enum.TryParse(dialect, out dbDialect);
                targetToken.DatabaseDialect = dbDialect;

                String Driver = (from tok in token.Token
                                  where tok.Key == "DatabaseDriver"
                                 select tok.Value).SingleOrDefault();

                DatabaseDriver dbDriver;
                Enum.TryParse(Driver, out dbDriver);
                targetToken.DatabaseDriver = dbDriver;
            }

            return targetToken;
        }

        public IAccountToken Convert(TokenDTO token)
        {
            DatabaseAccountToken targetToken = new DatabaseAccountToken();
            targetToken.TokenId = token.TokenId;
            targetToken.TokenName = token.TokenName;
            if (token.Tokens != null)
            {
                
                targetToken.Mapping = (from tok in token.Tokens
                                       where tok.Key == "Mapping"
                                       select tok.Value).SingleOrDefault();

                targetToken.Password = (from tok in token.Tokens
                                        where tok.Key == "Password"
                                        select tok.Value).SingleOrDefault();

                targetToken.ConnectionString = (from tok in token.Tokens
                                                where tok.Key == "ConnectionString"
                                                select tok.Value).SingleOrDefault();

                targetToken.UserName = (from tok in token.Tokens
                                        where tok.Key == "UserName"
                                        select tok.Value).SingleOrDefault();

                targetToken.DataSource = (from tok in token.Tokens
                                          where tok.Key == "DataSource"
                                          select tok.Value).SingleOrDefault();

                String dialect = (from tok in token.Tokens
                                  where tok.Key == "DatabaseDialect"
                                  select tok.Value).SingleOrDefault();

                DatabaseDialect dbDialect;
                Enum.TryParse(dialect, out dbDialect);
                targetToken.DatabaseDialect = dbDialect;

                String Driver = (from tok in token.Tokens
                                 where tok.Key == "DatabaseDriver"
                                 select tok.Value).SingleOrDefault();

                DatabaseDriver dbDriver;
                Enum.TryParse(Driver, out dbDriver);
                targetToken.DatabaseDriver = dbDriver;
            }

            return targetToken;
        }
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
