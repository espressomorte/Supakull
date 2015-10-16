using Supakulltracker.UserProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supakulltracker
{
    public class DBSettingsCreater
    {
        private UserProviderSoapClient userProvider = new UserProviderSoapClient();

        public String DBType { get; set; }
        public String DialectType { get; set; }
        public String ConectionString { get; set; }
        public String Mapping { get; set; }

        public String GenerateConectionStringForOracle(String userName, String password, String source)
        {
            String conStr = "User ID=" + userName + "; " + "Password=" + password + "; " + "Data Source=" + source;
            return conStr;
        }
        public Boolean TestDBString(String ConectionString)
        {
            return userProvider.CheckConectionString(DBType, ConectionString);
        }

        public void SaveUserSettings(UserForAuthenticationDTO LoggedUser, String SettingsName, String MappingSettings, String ConectionString)
        {
            UserSettings newSet = new UserSettings();
            Random rd = new Random();
            newSet.ConectionString = ConectionString;
            newSet.IsActiv = false;
            newSet.MappingSettings = MappingSettings;
            newSet.SettingsDate = DateTime.Now;
            newSet.SettingsID = rd.Next();
            newSet.SettingsName = SettingsName;


            userProvider.UpdateUserSettings(LoggedUser, newSet);
        }
    }
}
