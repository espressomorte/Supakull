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
        public List<TemplateDTO> MappingTemplates { get; set; }
        public List<TokenDTO> Tokens { get; set; }
    }
}
