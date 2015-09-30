using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices.Class
{
    [Serializable]
    public class ProxyUsersList
    {
        public ProxyUsersList()
        {
            TaskList = new List<ProxyTaskMain>();
        }

        public  string UserId { get; set; }
        public  string UserName { get; set; }
        public  List<ProxyTaskMain> TaskList { get; set; }
    }
}