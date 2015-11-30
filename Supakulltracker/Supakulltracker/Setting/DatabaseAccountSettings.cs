using Supakulltracker.IssueService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class DatabaseAccountSettings : IAccountSettings
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Sources Source { get; set; }
        public Boolean Owner { get; set; }
        public List<DatabaseAccountToken> Tokens { get; set; }
        public Int32 MinUpdateTime { get; set; }
        public Int32 AccountVersion { get; set; }

        public DatabaseAccountSettings()
        {
            this.Tokens = new List<DatabaseAccountToken>();
        }

        public IAccountSettings ConvertFromDAO(ServiceAccountDTO serviceAccount)
        {
            DatabaseAccountSettings target = new DatabaseAccountSettings();
            target.ID = serviceAccount.ServiceAccountId;
            target.Name = serviceAccount.ServiceAccountName;
            target.Source = serviceAccount.Source;
            target.MinUpdateTime = serviceAccount.MinUpdateTime;
            target.AccountVersion = serviceAccount.AccountVersion;

            if (serviceAccount.Tokens.Length > 0)
            {
                foreach (TokenDTO token in serviceAccount.Tokens)
                {
                    DatabaseAccountToken targetToken = new DatabaseAccountToken();
                    targetToken = (DatabaseAccountToken)targetToken.ConvertFromDAO(token);
                    target.Tokens.Add(targetToken);
                }
            }
            return target;
        }

        public ServiceAccountDTO ConvertToDAO(IAccountSettings serviceAccount)
        {
            ServiceAccountDTO target = new ServiceAccountDTO();
            DatabaseAccountSettings currentAccount = (DatabaseAccountSettings)serviceAccount;

            target.ServiceAccountId = currentAccount.ID;
            target.ServiceAccountName = currentAccount.Name;
            target.Source = Sources.DataBase;
            target.MinUpdateTime = serviceAccount.MinUpdateTime;
            target.AccountVersion = serviceAccount.AccountVersion;

            List<TokenDTO> tok = new List<TokenDTO>();
            if (currentAccount.Tokens != null)
            {
                foreach (DatabaseAccountToken token in currentAccount.Tokens)
                {
                    TokenDTO localtok = token.ConvertToDAO(token);
                    tok.Add(localtok);
                }
                target.Tokens = tok.ToArray();
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

        public IAccountToken ConvertFromDAO(TokenDTO token)
        {
            DatabaseAccountToken targetToken = new DatabaseAccountToken();
            targetToken.TokenId = token.TokenId;
            targetToken.TokenName = token.TokenName;
            if (token.Tokens.Length > 0)
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

        public TokenDTO ConvertToDAO(IAccountToken token)
        {
            TokenDTO target = new TokenDTO();
            DatabaseAccountToken currentToken = (DatabaseAccountToken)token;

            target.TokenName = currentToken.TokenName;
            target.TokenId = currentToken.TokenId;
            List<TokenForSerialization> tokenList = new List<TokenForSerialization>();

            TokenForSerialization userName = new TokenForSerialization();
            userName.Key = "UserName";
            userName.Value = currentToken.UserName;
            tokenList.Add(userName);

            TokenForSerialization password = new TokenForSerialization();
            password.Key = "Password";
            password.Value = currentToken.Password;
            tokenList.Add(password);

            TokenForSerialization mapping = new TokenForSerialization();
            mapping.Key = "Mapping";
            mapping.Value = currentToken.Mapping;
            tokenList.Add(mapping);

            TokenForSerialization dataSource = new TokenForSerialization();
            dataSource.Key = "DataSource";
            dataSource.Value = currentToken.DataSource;
            tokenList.Add(dataSource);

            TokenForSerialization databaseDriver = new TokenForSerialization();
            databaseDriver.Key = "DatabaseDriver";
            databaseDriver.Value = currentToken.DatabaseDriver.ToString();
            tokenList.Add(databaseDriver);

            TokenForSerialization databaseDialect = new TokenForSerialization();
            databaseDialect.Key = "DatabaseDialect";
            databaseDialect.Value = currentToken.DatabaseDialect.ToString();
            tokenList.Add(databaseDialect);

            TokenForSerialization databaseConnectionString = new TokenForSerialization();
            databaseConnectionString.Key = "ConnectionString";
            databaseConnectionString.Value = currentToken.ConnectionString;
            tokenList.Add(databaseConnectionString);

            target.Tokens = tokenList.ToArray();
            return target;

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
