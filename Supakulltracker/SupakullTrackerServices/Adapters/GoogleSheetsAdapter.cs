using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Google.GData.Client;
using Google.GData.Spreadsheets;
using Google.GData.Extensions;

namespace SupakullTrackerServices
{  
    public class GoogleSheetsAdapter : IAdapter
    {
        private OAuth2Parameters parameters = new OAuth2Parameters();
        ListFeed listFeed;
        List<GoogleSheetsAccountToken> allTokensInAccount = new List<GoogleSheetsAccountToken>();
        public DateTime adapterLastUpdate { get; set; }
        public Int32 MinUpdateTime { get; set; }
        public Boolean CanRunUpdate()
        {
            if ((DateTime.Now - this.adapterLastUpdate).TotalMilliseconds > this.MinUpdateTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetLinkToTracker(String LinkToTrackerInfo)
        {
            throw new NotImplementedException();
        }
        public GoogleSheetsAdapter()
        {           
            
        }
         
        public IList<ITask> GetAllTasks()
        {
            IList<ITask> task = new List<ITask>();
            if (listFeed != null)
            {
                foreach (ListEntry row in listFeed.Entries)
                {
                    task.Add(GetRowElements(row));
                }
            }
            return task;
        }

        private TaskMain GetRowElements(ListEntry row)
        {
            TaskMain tm = new TaskMain();
            
            tm.LinkToTracker= row.Feed.Entries.FirstOrDefault().Feed.Links.First().AbsoluteUri.ToString();
            var str = row.Links;
            tm.TaskID = row.Elements[0].Value;
            if (tm.TaskID == "")
                tm.TaskID = row.Elements[1].Value;
            tm.Description = row.Elements[3].Value;
            tm.Status = row.Elements[5].Value;
            tm.Comments = row.Elements[6].Value;
            tm.Source = Sources.GoogleSheets;

            return tm;
        }

        public ITask GetTask(int index)
        {
            ITask task = null;
            if (listFeed != null)
            {
                foreach (ListEntry row in listFeed.Entries)
                {
                   
                    index--;
                    if (index == 0)
                        task = GetRowElements(row);
                }
            }
            return task;
        }

        public IAccountSettings TestAccount(IAccountSettings accountnForTest)
        {
            parameters.ClientId = Constants.googleSheetsCLIENT_ID;
            parameters.ClientSecret = Constants.googleSheetsCLIENT_SECRET;
            parameters.RedirectUri = Constants.googleSheetsREDIRECT_URI;
            parameters.Scope = Constants.googleSheetsSCOPE;

            GoogleSheetsAccountSettings accountForTestGS = (GoogleSheetsAccountSettings)accountnForTest;
            GoogleSheetsAccountToken tokenForTest = accountForTestGS.Tokens.First();
            Boolean result = false;

            if (tokenForTest != null)
            {
                foreach (GoogleSheetsAccountToken gast in accountForTestGS.Tokens)
                {
                    if (gast.TokenName == "GetNewToken")
                    {
                        string authorizationUrl = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);
                        gast.RefreshToken = authorizationUrl;
                    }
                    else if (gast.TokenName == "EnterAccessToken")
                    {
                        parameters.AccessToken = gast.RefreshToken;
                        parameters.AccessCode = gast.RefreshToken;
                        OAuthUtil.GetAccessToken(parameters);
                        gast.RefreshToken = parameters.RefreshToken;
                    }
                    else if (gast.TokenName == "UseSaveToken")
                    {
                        parameters.AccessToken = gast.RefreshToken;
                        parameters.AccessCode = gast.RefreshToken;
                        parameters.RefreshToken = gast.RefreshToken;
                        OAuthUtil.RefreshAccessToken(parameters);
                    }
                    else if (gast.TokenName == "CheckFileName")
                    {
                        parameters.AccessToken = accountForTestGS.Tokens[0].RefreshToken;
                        parameters.AccessCode = accountForTestGS.Tokens[0].RefreshToken;
                        parameters.RefreshToken = accountForTestGS.Tokens[0].RefreshToken;
                        bool result2;
                        result2 = CheckFileGS(gast.RefreshToken, accountForTestGS);
                        if (!result2)
                            gast.RefreshToken = "This file does not exist";
                        else
                            gast.RefreshToken = "OK";
                    }
                }
                
                result = true;
            }

            accountForTestGS.TestResult = result;
            return accountForTestGS;
        }


        private bool CheckFileGS(string FileName, GoogleSheetsAccountSettings accountForTestGS)
        {
            bool result = false;
            SpreadsheetsService service = new SpreadsheetsService(Constants.googleSheetsAppName);
            GOAuth2RequestFactory requestFactory = new GOAuth2RequestFactory(null, Constants.googleSheetsAppName, parameters);
            service.RequestFactory = requestFactory;
            SpreadsheetQuery query = new SpreadsheetQuery();
            SpreadsheetFeed feed = service.Query(query);
            SpreadsheetEntry spreadsheet;
            for (int i = 0; i < feed.Entries.Count; i++)
            {
                if (feed.Entries[i].Title.Text == FileName)
                {
                    spreadsheet = (SpreadsheetEntry)feed.Entries[i];
                    WorksheetFeed wsFeed = spreadsheet.Worksheets;
                    WorksheetEntry worksheet = (WorksheetEntry)wsFeed.Entries[0];
                    AtomLink listFeedLink = worksheet.Links.FindService(GDataSpreadsheetsNameTable.ListRel, null);
                    ListQuery listQuery = new ListQuery(listFeedLink.HRef.ToString());
                    listFeed = service.Query(listQuery);
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }
            }

            //if (listFeed != null)
            //{
            //    //ShowMapping();
            //}

            return result;
        }

        public IAdapter GetAdapter(IAccountSettings account)
        {
            GoogleSheetsAccountSettings gsAccount = (GoogleSheetsAccountSettings)account;
            allTokensInAccount = gsAccount.Tokens;

            parameters.ClientId = Constants.googleSheetsCLIENT_ID;
            parameters.ClientSecret = Constants.googleSheetsCLIENT_SECRET;
            parameters.RedirectUri = Constants.googleSheetsREDIRECT_URI;
            parameters.Scope = Constants.googleSheetsSCOPE;
            if (allTokensInAccount.Count != 0)
            {
                parameters.AccessToken = allTokensInAccount[0].RefreshToken;
                parameters.AccessCode = allTokensInAccount[0].RefreshToken;
                parameters.RefreshToken = allTokensInAccount[0].RefreshToken;
                OAuthUtil.RefreshAccessToken(parameters);

                ReadGSFile();
            }
            return this;
        }

        private void ReadGSFile()
        {
            SpreadsheetsService service = new SpreadsheetsService(Constants.googleSheetsAppName);
            GOAuth2RequestFactory requestFactory = new GOAuth2RequestFactory(null, Constants.googleSheetsAppName, parameters);

            service.RequestFactory = requestFactory;

            SpreadsheetQuery query = new SpreadsheetQuery();
            SpreadsheetFeed feed = service.Query(query);

            SpreadsheetEntry spreadsheet = (SpreadsheetEntry)feed.Entries[0];
            WorksheetFeed wsFeed = spreadsheet.Worksheets;
            WorksheetEntry worksheet = (WorksheetEntry)wsFeed.Entries[0];

            AtomLink listFeedLink = worksheet.Links.FindService(GDataSpreadsheetsNameTable.ListRel, null);

            ListQuery listQuery = new ListQuery(listFeedLink.HRef.ToString());
            listFeed = service.Query(listQuery);
        }
    }    
}