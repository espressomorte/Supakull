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
        public GoogleSheetsAdapter()
        {           



            parameters.ClientId = Constants.googleSheetsCLIENT_ID;
            parameters.ClientSecret = Constants.googleSheetsCLIENT_SECRET;
            parameters.RedirectUri = Constants.googleSheetsREDIRECT_URI;
            parameters.Scope = Constants.googleSheetsSCOPE;
            parameters.AccessCode = "4/dEvtIvPoNciqrNs4FfBMcc8wxl70jgedJ8NBKGj1ksg";
            parameters.AccessToken = "1/VKkcm_QeQmBzDLmATBZoYXLW2ooEvg7MM6D9MBS8NCg";
            parameters.RefreshToken = "1/VKkcm_QeQmBzDLmATBZoYXLW2ooEvg7MM6D9MBS8NCg";
            //OAuthUtil.GetAccessToken(parameters);
            OAuthUtil.RefreshAccessToken(parameters);

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
         
        public IList<ITask> GetAllTasks()
        {
            IList<ITask> task = new List<ITask>();
            foreach (ListEntry row in listFeed.Entries)
            {
                task.Add(GetRowElements(row));
            }
            return task;
        }

        private TaskMain GetRowElements(ListEntry row)
        {
            TaskMain tm = new TaskMain();

            tm.TaskID = row.Elements[0].Value;
            if (tm.TaskID == "")
                tm.TaskID = row.Elements[1].Value;
            tm.Description = row.Elements[3].Value;
            tm.Status = row.Elements[5].Value;
            tm.Comments = row.Elements[6].Value;
            tm.LinkToTracker = Sources.GoogleSheets;

            return tm;
        }

        public ITask GetTask(int index)
        {
            throw new NotImplementedException();
        }

        public IAccountSettings TestAccount(IAccountSettings accountnForTest)
        {
            throw new NotImplementedException();
        }

        public IAdapter GetAdapter(IAccountSettings account)
        {
            throw new NotImplementedException();
        }
    }    
}