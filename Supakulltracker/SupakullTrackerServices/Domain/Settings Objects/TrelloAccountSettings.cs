using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class TrelloAccountSettings : IAccountSettings,IAccountTest
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Sources Source { get; set; }
        public Boolean TestResult { get; set; }
        public Int32 MinUpdateTime { get; set; }
        public List<TrelloAccountToken> Tokens { get; set; }
        public Int32 AccountVersion { get; set; }

        public IAccountSettings Convert(ServiceAccount serviceAccount)
        {
            TrelloAccountSettings target = new TrelloAccountSettings();
            target.ID = serviceAccount.ServiceAccountId;
            target.Name = serviceAccount.ServiceAccountName;
            target.Source = serviceAccount.Source;
            target.TestResult = serviceAccount.TestResult;
            target.MinUpdateTime = serviceAccount.MinUpdateTime;
            target.AccountVersion = serviceAccount.AccountVersion;
            target.Tokens = new List<TrelloAccountToken>();

            if (serviceAccount.Tokens.Count > 0)
            {
                foreach (Token token in serviceAccount.Tokens)
                {
                    TrelloAccountToken targetToken = new TrelloAccountToken();
                    targetToken = (TrelloAccountToken)targetToken.Convert(token);
                    target.Tokens.Add(targetToken);
                }
            }
            return target;
        }

        public ServiceAccount Convert(IAccountSettings serviceAccount)
        {
            ServiceAccount target = new ServiceAccount();
            TrelloAccountSettings currentAccount = (TrelloAccountSettings)serviceAccount;

            target.ServiceAccountId = currentAccount.ID;
            target.ServiceAccountName = currentAccount.Name;            
            target.Source = Sources.Trello;
            target.TestResult = currentAccount.TestResult;
            target.AccountVersion = currentAccount.AccountVersion;
            target.MinUpdateTime = currentAccount.MinUpdateTime;
            List<Token> tok = new List<Token>();
            if (currentAccount.Tokens != null)
            {
                foreach (TrelloAccountToken token in currentAccount.Tokens)
                {
                    Token localtok = token.Convert(token);
                    tok.Add(localtok);
                }
                target.Tokens = tok.ToArray();
            }
            return target;
        }

        public bool Equals(IAccountSettings accountToCompare)
        {
            TrelloAccountSettings trelloAccountToCompere = (TrelloAccountSettings)accountToCompare;
            return (this.ID == trelloAccountToCompere.ID && this.AccountVersion == trelloAccountToCompere.AccountVersion);
        }
        public override bool Equals(object obj)
        {
            if (obj is TrelloAccountSettings)
            {
                return this.Equals(obj as TrelloAccountSettings);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return (this.ID.GetHashCode() ^ this.AccountVersion.GetHashCode());
        }
    }
    public class TrelloAccountToken : IAccountToken
    {
        public Int32 TokenId { get; set; }
        public String TokenName { get; set; }
        public String UserToken { get; set; }
        public String BoardID { get; set; }
        public DateTime DateCreation { get; set; }

        public IAccountToken Convert(Token token)
        {
            TrelloAccountToken targetToken = new TrelloAccountToken();
            targetToken.TokenId = token.TokenId;
            targetToken.TokenName = token.TokenName;
            if (token.Tokens.Count > 0)
            {

                targetToken.BoardID = (from tok in token.Tokens
                                         where tok.Key == "BoardID"
                                       select tok.Value).SingleOrDefault();
                DateTime result;
                var res = DateTime.TryParse((from tok in token.Tokens
                                             where tok.Key == "DateCreation"
                                             select tok.Value).SingleOrDefault(), out result);
                targetToken.DateCreation = result;
                targetToken.UserToken = (from tok in token.Tokens
                                            where tok.Key == "UserToken"
                                         select tok.Value).SingleOrDefault();
            }
            return targetToken;
        }

        public Token Convert(IAccountToken token)
        {
            Token targetToken = new Token();
            TrelloAccountToken currentToken = (TrelloAccountToken)token;
            targetToken.TokenName = currentToken.TokenName;
            targetToken.TokenId = currentToken.TokenId;
            targetToken.Tokens.Add("UserToken", currentToken.UserToken);
            targetToken.Tokens.Add("DateCreation", currentToken.DateCreation.ToString());
            targetToken.Tokens.Add("BoardID", currentToken.BoardID);

            return targetToken;

        }
    }
}