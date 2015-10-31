using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public class Token
    {
        public Token()
        {
            this.Tokens = new Dictionary<String, String>();
        }
        public virtual Int32 TokenId { get; set; }
        public virtual String TokenName { get; set; }
        public virtual IDictionary<String, String> Tokens { get; set; }
    }
}
