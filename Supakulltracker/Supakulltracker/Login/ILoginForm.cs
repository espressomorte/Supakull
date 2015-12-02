using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public interface ILoginForm
    {
        string UserLogin{ get; }
        string MessageForUser { get; set; }
    }
}
