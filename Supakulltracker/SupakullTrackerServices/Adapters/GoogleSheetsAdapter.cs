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

        public GoogleSheetsAdapter()
        {           
            string CLIENT_ID = "693545380187-8u2n7drovokad59fffiqbt8duqq3qhuq.apps.googleusercontent.com";
            string CLIENT_SECRET = "SdZybpbTGeRMJjOKo2Ggw5oU";
            string SCOPE = "https://spreadsheets.google.com/feeds https://docs.google.com/feeds";
            string REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";


            parameters.ClientId = CLIENT_ID;
            parameters.ClientSecret = CLIENT_SECRET;
            parameters.RedirectUri = REDIRECT_URI;
            parameters.Scope = SCOPE;
            parameters.AccessCode = "4/dEvtIvPoNciqrNs4FfBMcc8wxl70jgedJ8NBKGj1ksg";
            parameters.AccessToken = "1/VKkcm_QeQmBzDLmATBZoYXLW2ooEvg7MM6D9MBS8NCg";
            parameters.RefreshToken = "1/VKkcm_QeQmBzDLmATBZoYXLW2ooEvg7MM6D9MBS8NCg";
        }

        public IList<ITask> GetAllTasks()
        {
            //OAuthUtil.GetAccessToken(parameters);
            OAuthUtil.RefreshAccessToken(parameters);

            SpreadsheetsService service = new SpreadsheetsService("MySpreadsheetIntegration-v1");
            GOAuth2RequestFactory requestFactory = new GOAuth2RequestFactory(null, "MySpreadsheetIntegration-v1", parameters);

            service.RequestFactory = requestFactory;

            SpreadsheetQuery query = new SpreadsheetQuery();
            SpreadsheetFeed feed = service.Query(query);

            SpreadsheetEntry spreadsheet = (SpreadsheetEntry)feed.Entries[0];
            WorksheetFeed wsFeed = spreadsheet.Worksheets;
            WorksheetEntry worksheet = (WorksheetEntry)wsFeed.Entries[0];

            AtomLink listFeedLink = worksheet.Links.FindService(GDataSpreadsheetsNameTable.ListRel, null);

            ListQuery listQuery = new ListQuery(listFeedLink.HRef.ToString());
            ListFeed listFeed = service.Query(listQuery);

            IList<ITask> task = new List<ITask>();

            foreach (ListEntry row in listFeed.Entries)
            {
                TaskMain tm = new TaskMain();

                tm.TaskID = row.Elements[0].Value;
                if (tm.TaskID == "")
                    tm.TaskID = row.Elements[1].Value;
                tm.Description = row.Elements[3].Value;
                tm.Status = row.Elements[5].Value;
                tm.Comments = row.Elements[6].Value;
                tm.LinkToTracker = "GoogleSheet";

                task.Add(tm);
            }
            return task;
        }

        public ITask GetTask(int index)
        {
            throw new NotImplementedException();
        }
    }    
}