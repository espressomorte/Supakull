﻿using System.Collections.Generic;
using System;
using Supakulltracker.IssueService;

namespace Supakulltracker
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
        Sources Source { get; set; }
        string LinkToTracker { get; set; }
        Int32 TokenID { get; set; }
        string Estimation { get; set; }
        string TargetVersion { get; set; }
        string Comments { get; set; }
        IList<User> Assigned { get; set; }
        ITask TaskParent { get; set; }
    }
}