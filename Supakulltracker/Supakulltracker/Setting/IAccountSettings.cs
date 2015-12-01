using Supakulltracker.IssueService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public interface IAccountSettings
    {
        Int32 ID { get; set; }
        String Name { get; set; }
        Sources Source { get; set; }
        Boolean Owner { get; set; }
        Int32 MinUpdateTime { get; set; }
        IAccountSettings ConvertFromDAO(ServiceAccountDTO token);
        ServiceAccountDTO ConvertToDAO(IAccountSettings token);
    }
}
