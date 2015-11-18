using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public interface IAccountToken
    {
        Int32 TokenId { get; set; }
        String TokenName { get; set; }

        IAccountToken Convert(TokenDTO token);
        IAccountToken Convert(TokenDAO token);
    }

}
