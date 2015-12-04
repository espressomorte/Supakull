using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    class SearchProvider
    {
        public IssueService.TaskMainDTO[] FindTasks(string textQuery)
        {
            IssueService.GetTrackerServicesSoapClient trackerServices = new IssueService.GetTrackerServicesSoapClient();
            IssueService.TaskMainDTO[] tasks = trackerServices.FindTasks(textQuery);
            if(tasks == null)
            {
                tasks = trackerServices.GetAllTasks();
            }
            return tasks;
        }
    }
}
