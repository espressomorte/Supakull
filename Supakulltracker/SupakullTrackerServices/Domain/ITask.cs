using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices.Class
{
    public interface ITask
    {
        string TaskID { get; set; }
        string SubtaskType { get; set; }
        string Summary { get; set; }
        string Description { get; set; }        
        string Status { get; set; }
        string Priority { get; set; }
        string Product { get; set; }
        string Project { get; set; }        
        string CreatedDate { get; set; }
        string CreatedBy { get; set; }
        string LinkToTracker { get; set; }
        string Estimation { get; set; }
        string TargetVersion { get; set; }
        string Comments { get; set; }
        string[] Assigned { get; set; }
        string TaskParent { get; set; }
    }
}