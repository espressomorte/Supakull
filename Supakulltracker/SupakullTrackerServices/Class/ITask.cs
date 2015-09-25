using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices.Class
{
    interface ITask
    {
        string TaskID { get; set; }
        string SubtaskType { get; set; }
        string Summary { get; set; }
        string Description { get; set; }
        TaskMain TaskParent { get; set; }
        string Status { get; set; }
        string Priority { get; set; }
        string Product { get; set; }
        string Project { get; set; }
        IList<UsersList> Assigned { get; set; }
        string CreatedDate { get; set; }
        string CreatedBy { get; set; }
        string LinkToTracker { get; set; }
        string Estimation { get; set; }
        string TargetVersion { get; set; }
        string Comments { get; set; }
    }
}