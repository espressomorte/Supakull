using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public interface IAdapter
    {
        IList<ITask> GetAllItems();
        ITask GetItem(int index);
    }
}
