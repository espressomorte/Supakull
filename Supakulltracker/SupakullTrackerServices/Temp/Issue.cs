using System;

namespace SupakullTrackerServices
{
    public class Issue
    {
        public virtual Int64 issueID { get; set; }
        public virtual String issueUFID { get; set; }
        public virtual String summary { get; set; }
        public virtual String type { get; set; }
        public virtual String status { get; set; }
        public virtual String severity { get; set; }
        public virtual String priority { get; set; }
    }
}