using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    class TaskSearchProvider
    {
        public IssueService.TaskMainDTO[] Find(string searchLine)
        {
            IssueService.GetTrackerServicesSoapClient trackerServices = new IssueService.GetTrackerServicesSoapClient();
            // TODO: GetAllTasks should be replaced to FindTasks service
            return trackerServices.FindTasks();
        }
    }
}
