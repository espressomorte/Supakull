using Supakulltracker.IssueService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class TrelloAccountSettings : IAccountSettings
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Sources Source { get; set; }
        public List<TrelloAccountToken> Tokens { get; set; }
        public Boolean Owner { get; set; }
        public Int32 MinUpdateTime { get; set; }
        public Boolean TestResult { get; set; }
        public Int32 AccountVersion { get; set; }

        public IAccountSettings ConvertFromDAO(ServiceAccountDTO serviceAccount)
        {
            TrelloAccountSettings target = new TrelloAccountSettings();
            target.ID = serviceAccount.ServiceAccountId;
            target.Name = serviceAccount.ServiceAccountName;
            target.Source = serviceAccount.Source;
            target.TestResult = serviceAccount.TestResult;
            target.AccountVersion = serviceAccount.AccountVersion;

            target.MinUpdateTime = serviceAccount.MinUpdateTime;
            target.Tokens = new List<TrelloAccountToken>();

            if (serviceAccount.Tokens.Length > 0)
            {
                foreach (TokenDTO token in serviceAccount.Tokens)
                {
                    TrelloAccountToken targetToken = new TrelloAccountToken();
                    targetToken = (TrelloAccountToken)targetToken.ConvertFromDAO(token);
                    target.Tokens.Add(targetToken);
                }
            }
            return target;
        }

        public ServiceAccountDTO ConvertToDAO(IAccountSettings serviceAccount)
        {
            ServiceAccountDTO target = new ServiceAccountDTO();
            TrelloAccountSettings currentAccount = (TrelloAccountSettings)serviceAccount;
            target.TestResult = currentAccount.TestResult;
            target.ServiceAccountId = currentAccount.ID;
            target.ServiceAccountName = currentAccount.Name;
            target.AccountVersion = currentAccount.AccountVersion;
            
            target.Source = Sources.Trello;
            target.MinUpdateTime = serviceAccount.MinUpdateTime;


            List<TokenDTO> tok = new List<TokenDTO>();
            if (currentAccount.Tokens != null)
            {
                foreach (TrelloAccountToken token in currentAccount.Tokens)
                {
                    TokenDTO localtok = token.ConvertToDAO(token);
                    tok.Add(localtok);
                }
                target.Tokens = tok.ToArray();
            }
            return target;
        }

}
    public class TrelloAccountToken : IAccountToken
    {
        public Int32 TokenId { get; set; }
        public String TokenName { get; set; }
        public String UserToken { get; set; }
        public String DateCreation { get; set; }
        public String BoardID { get; set; }

        public IAccountToken ConvertFromDAO(TokenDTO token)
        {
            TrelloAccountToken targetToken = new TrelloAccountToken();
            targetToken.TokenId = token.TokenId;
            targetToken.TokenName = token.TokenName;
            if (token.Tokens.Length > 0)
            {
                targetToken.UserToken = (from tok in token.Tokens
                                         where tok.Key == "UserToken"
                                         select tok.Value).SingleOrDefault();

                targetToken.DateCreation = (from tok in token.Tokens
                                         where tok.Key == "DateCreation"
                                         select tok.Value).SingleOrDefault();
                targetToken.BoardID = (from tok in token.Tokens
                                            where tok.Key == "BoardID"
                                            select tok.Value).SingleOrDefault();
            }
            return targetToken;
        }

        public TokenDTO ConvertToDAO(IAccountToken token)
        {
            TokenDTO target = new TokenDTO();
            TrelloAccountToken currentToken = (TrelloAccountToken)token;

            target.TokenName = currentToken.TokenName;
            target.TokenId = currentToken.TokenId;
            List<TokenForSerialization> tokenList = new List<TokenForSerialization>();

            TokenForSerialization userName = new TokenForSerialization();
            userName.Key = "UserToken";
            userName.Value = currentToken.UserToken;
            tokenList.Add(userName);

            TokenForSerialization dateTime = new TokenForSerialization();
            dateTime.Key = "DateCreation";
            dateTime.Value = currentToken.DateCreation;
            tokenList.Add(dateTime);

            TokenForSerialization BoardID = new TokenForSerialization();
            BoardID.Key = "BoardID";
            BoardID.Value = currentToken.BoardID;
            tokenList.Add(BoardID);

            target.Tokens = tokenList.ToArray();
            return target;

        }
    }
}
