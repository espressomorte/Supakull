using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace SupakullTrackerServices
{
    public class ServiceAccountDAO
    {
        public ServiceAccountDAO()
        {
            this.Tokens = new List<TokenDAO>();
            this.MappingTemplates = new List<TemplateDAO>();
        }
        public virtual Int32 ServiceAccountId { get; set; }
        public virtual String ServiceAccountName { get; set; }
        public virtual Sources Source { get; set; }
        public virtual IList<TemplateDAO> MappingTemplates { get; set; }
        public virtual IList<TokenDAO> Tokens { get; set; }
        public virtual Int32 MinUpdateTime { get; set; }
        public virtual Int32 AccountVersion { get; set; }


    }
}
