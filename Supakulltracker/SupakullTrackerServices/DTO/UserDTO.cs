using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    [Serializable]
    public class UserDTO
    {
        public Int32 UserID { get; set; }
        public  string UserLogin { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(Int32 userID, string userLogin)
        {
            this.UserID = userID;
            this.UserLogin = userLogin;
        }
    }
}