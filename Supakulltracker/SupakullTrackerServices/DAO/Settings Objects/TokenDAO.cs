using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class TokenDAO
    {
        public TokenDAO()
        {
            this.Token = new Dictionary<String, String>();
        }
        public virtual Int32 TokenId { get; set; }
        public virtual String TokenName { get; set; }
        public virtual IDictionary<String, String> Token { get; set; }
    }
}