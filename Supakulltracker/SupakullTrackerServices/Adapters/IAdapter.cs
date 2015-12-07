using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public interface IAdapter : IAdapterTest
    {
        IList<ITask> GetAllTasks();
        ITask GetTask(int index);
        IAdapter GetAdapter(IAccountSettings account);
        String GetLinkToTracker(String LinkToTrackerInfo);
        Boolean CanRunUpdate();
        DateTime adapterLastUpdate { get; set; }
        Int32 MinUpdateTime { get; set; }
    }
}
