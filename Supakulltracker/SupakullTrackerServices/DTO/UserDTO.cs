using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    [Serializable]
    public class UserDTO
    {
        public UserDTO()
        {
            TaskList = new List<TaskMainDTO>();
        }

        public  string UserId { get; set; }
        public  string UserName { get; set; }
        public  List<TaskMainDTO> TaskList { get; set; }
    }
}