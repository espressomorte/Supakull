using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class MatchTasksById : IMatchTasks
    {
        public bool MatchTasks(ITask taskA, ITask taskB)
        {
            return string.Equals(taskA.TaskID, taskB.TaskID, StringComparison.OrdinalIgnoreCase);
        }
    }
}