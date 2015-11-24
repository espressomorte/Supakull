using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    [Serializable]
    public class UserDTO: IEquatable<UserDTO>
    {
        public Int32 UserID { get; set; }
        public string UserLogin { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(Int32 userID, string userLogin)
        {
            this.UserID = userID;
            this.UserLogin = userLogin;
        }

        #region IEquatable

        public override bool Equals(object obj)
        {
            UserDTO userDtoToCampare = obj as UserDTO;
            return Equals(userDtoToCampare);
        }

        public bool Equals(UserDTO userDtoToCampare)
        {
            return this.UserLogin.Equals(userDtoToCampare.UserLogin);
        }

        public override int GetHashCode()
        {
            return this.UserLogin.GetHashCode();
        }

        #endregion
    }
}