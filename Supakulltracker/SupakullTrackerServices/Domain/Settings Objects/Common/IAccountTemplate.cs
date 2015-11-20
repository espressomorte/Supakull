using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public interface IAccountTemplate
    {
        Int32 TemplateId { get; set; }
        String TemplateName { get; set; }

        IAccountTemplate Convert(Template template);
        Template Convert(IAccountTemplate template);

    }
}
