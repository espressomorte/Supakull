using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    class PresenterMain
    {
        private IssueService.GetTrackerServicesSoapClient service;
        private IMainScreen mainScreen;
        //private IssueService.TaskMainDTO[] tasks;

        public PresenterMain(IMainScreen mainScreen)
        {
            service = new IssueService.GetTrackerServicesSoapClient();
            this.mainScreen = mainScreen;
            mainScreen.SetSearchQuery += SetSearchQueryHendler;
            mainScreen.SelectTask += SelectTaskHendler;
            mainScreen.UdateAllTasks += UdateAllTasksHendler;
         }

        private void SetSearchQueryHendler(object sender, EventArgs e)
        {
            SearchProvider taskSearchProvider = new SearchProvider();
            IssueService.TaskMainDTO[] tasks = taskSearchProvider.FindTasks(mainScreen.SearchQuery);
            mainScreen.TaskBoard = tasks;
        }

        private void SelectTaskHendler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UdateAllTasksHendler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
