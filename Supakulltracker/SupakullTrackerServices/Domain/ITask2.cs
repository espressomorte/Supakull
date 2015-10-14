using System.Collections.Generic;

namespace SupakullTrackerServices
{
    public interface ITask2: ITask
    {
        IList<ITask2> LinkedTasks { get; set; }
        void LinkTask(ITask2 taskToLink);
    }
}
