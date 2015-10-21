using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public class ServiceAccountDAO
    {
        public ServiceAccountDAO()
        {
            this.FirstToken = new Dictionary<String, String>();
            this.SecondToken = new Dictionary<String, String>();
            this.ThirdToken = new Dictionary<String, String>();
            this.FourthToken = new Dictionary<String, String>();
            this.FifthToken = new Dictionary<String, String>();
            this.MappingTemplates = new List<TemplateDAO>();
        }
        public virtual Int32 ServiceAccountId { get; set; }
        public virtual String ServiceAccountName { get; set; }
        public virtual Sources Source { get; set; }
        public virtual IList<TemplateDAO> MappingTemplates { get; set; }
        public virtual IDictionary<String, String> FirstToken { get; set; }
        public virtual IDictionary<String, String> SecondToken { get; set; }
        public virtual IDictionary<String, String> ThirdToken { get; set; }
        public virtual IDictionary<String, String> FourthToken { get; set; }
        public virtual IDictionary<String, String> FifthToken { get; set; }


    }
}
