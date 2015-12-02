using System;
using Supakulltracker.IssueService;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public interface IAccountToken
    {
        Int32 TokenId { get; set; }
        String TokenName { get; set; }

        IAccountToken ConvertFromDAO(TokenDTO token);
        TokenDTO ConvertToDAO(IAccountToken token);
    }


}
