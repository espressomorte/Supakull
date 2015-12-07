using System;

namespace Supakulltracker
{
    interface IMainScreen
    {
        IssueService.TaskMainDTO[] TaskBoard { set; }
        string SearchQuery { get; }
        SuperTask DetailPanel { set; }

        event EventHandler<EventArgs> SetSearchQuery;
        event EventHandler<EventArgs> UdateAllTasks;
        event EventHandler<EventArgs> SelectTask;

        // events for Menu
    }
}