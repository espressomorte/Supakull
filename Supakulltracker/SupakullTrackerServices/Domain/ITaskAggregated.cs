using System.Collections.Generic;

namespace SupakullTrackerServices
{
    public interface ITaskAggregated
    {
        IList<ITask> TaskMainCollection { get; set; }
        void Add(ITask TaskMain);
    }
}