﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
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
        Sources LinkToTracker { get; set; }
        string Estimation { get; set; }
        string TargetVersion { get; set; }
        string Comments { get; set; }
        IList<User> Assigned { get; set; }
        ITask TaskParent { get; set; }
    }
}