using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public class TemplateDAO
    {
        public TemplateDAO()
        {
            this.Mapping = new Dictionary<String, String>();
        }
        public virtual Int32 TemplateId { get; set; }
        public virtual String TemplateName { get; set; }
        public virtual IDictionary<String, String> Mapping { get; set; }
    }

   
}
