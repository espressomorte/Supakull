﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class UserForAuthentication
    {
        public virtual Int64 UserID { get; set; }
        public virtual String UserLogin { get; set; }
        public virtual String UserPinCode { get; set; }
    }
}