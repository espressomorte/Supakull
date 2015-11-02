using System;
using System.Collections.Generic;

namespace SupakullTrackerServices
{
    public class ServiceAccount
    {
        public ServiceAccount()
        {
            this.Tokens = new List<Token>();
            this.MappingTemplates = new List<Template>();
        }
        public virtual Int32 ServiceAccountId { get; set; }
        public virtual String ServiceAccountName { get; set; }
        public virtual Sources Source { get; set; }
        public virtual IList<Template> MappingTemplates { get; set; }
        public virtual IList<Token> Tokens { get; set; }
    }
}

