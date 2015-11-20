using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supakulltracker.IssueService;

namespace Supakulltracker
{
    public interface IAccountTemplate
    {
        Int32 TemplateId { get; set; }
        String TemplateName { get; set; }

        IAccountTemplate ConvertFromDAO(TemplateDTO template);
        TemplateDTO ConvertToDAO(IAccountTemplate token);
    }
}
