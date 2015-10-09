using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public interface ICredentialsProvider
    {
        CredentiolInfo GetCredentialsInfo(string message);
    }
}
