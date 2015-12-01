using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public interface IAccountSettings
    {
        Int32 ID { get; set; }
        String Name { get; set; }
        Sources Source { get; set; }
        Int32 MinUpdateTime { get; set; }

        IAccountSettings Convert(ServiceAccount serviceAccount);
        ServiceAccount Convert(IAccountSettings serviceAccount);
    }
}
