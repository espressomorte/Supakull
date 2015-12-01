using System;
using System.Collections.Generic;

namespace SupakullTrackerServices
{
    [Serializable]
    public class ServiceAccountDTO
    {
        public ServiceAccountDTO()
        {
            Tokens = new List<TokenDTO>();
            MappingTemplates = new List<TemplateDTO>();
        }
        public Int32 ServiceAccountId { get; set; }
        public String ServiceAccountName { get; set; }
        public Sources Source { get; set; }
        public virtual String UserAccountToken { get; set; }
        public List<TemplateDTO> MappingTemplates { get; set; }
        public List<TokenDTO> Tokens { get; set; }
        public Boolean TestResult { get; set; }
        public Int32 MinUpdateTime { get; set; }
        public Int32 AccountVersion { get; set; }

    }
}
