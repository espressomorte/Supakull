using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    [Serializable]
    public class TemplateDTO
    {
        public TemplateDTO()
        {
            Mapping = new List<MappingForSerialization>();
        }
        public  Int32 TemplateId { get; set; }
        public  String TemplateName { get; set; }
        public  List<MappingForSerialization> Mapping { get; set; }
    }

    [Serializable]
    public class MappingForSerialization
    {
        public String Key { get; set; }
        public String Value { get; set; }
    }
}
