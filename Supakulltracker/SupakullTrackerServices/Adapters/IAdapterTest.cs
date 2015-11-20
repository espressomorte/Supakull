using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public interface IAdapterTest
    {
        IAccountSettings TestAccount(IAccountSettings accountnForTest);
    }
}
