using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class MatchTasksById : IMatchTasks
    {
        public bool Match(ITask taskA, ITask taskB)
        {
            return string.Equals(taskA.TaskID, taskB.TaskID, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}