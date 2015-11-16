using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    [Serializable]
    public class UserDTO
    {
        public  string UserId { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(string userId)
        {
            this.UserId = userId;
        }
    }
}