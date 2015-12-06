using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class LoggedUser
    {
        public Int32 userId;
        public List<IAdapter> userAdapters { get; set; }
        public LoggedUser(Int32 idUser)
        {
            userId = idUser;
            userAdapters = null;
            //userAdapters.AddRange(new GetTrackerServices().GetAllAdaptersByUserID(idUser));
        }

    }
}