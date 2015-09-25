using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices.Class
{
    [Serializable]
    public class ProxyTaskMain
    {
        public ProxyTaskMain()
        {
            Assigned = new List<ProxyUsersList>();
        }
        public  string TaskID { get; set; }
        public  string SubtaskType { get; set; }
        public  string Summary { get; set; }
        public  string Description { get; set; }
        public  string Status { get; set; }
        public  string Priority { get; set; }
        public  string Product { get; set; }
        public  string Project { get; set; }
        public  string CreatedDate { get; set; }
        public  string CreatedBy { get; set; }
        public  string LinkToTracker { get; set; }
        public  string Estimation { get; set; }
        public  string TargetVersion { get; set; }
        public  string Comments { get; set; }
        public  List<ProxyUsersList> Assigned { get; set; }
      //  public  ProxyTaskMain TaskParent { get; set; }
    }
}