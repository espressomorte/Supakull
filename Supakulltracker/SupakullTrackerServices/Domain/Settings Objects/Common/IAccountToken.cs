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

        IAccountToken Convert(Token token);
        Token Convert(IAccountToken token);
    }

}
