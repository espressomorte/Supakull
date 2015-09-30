using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices.Class
{
    public interface IAdapter
    {
        List<ITask> GetAllItems();
        ITask GetItem(int index);
    }
}
