using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supakulltracker
{
    public partial class SettingsDialog : Form
    {
        private UserProvider.UserForAuthentication loggedUser;
        private List<IAccountSettings> userAccounts;

        public SettingsDialog(UserProvider.UserForAuthentication loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.userAccounts = loggedUser.GetAllUserAccounts();
        }

        private void dataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBSettingDialog dbSetingDialog = new DBSettingDialog(loggedUser, userAccounts);
            splitContainer1.Panel2.Controls.Add(dbSetingDialog);
           
        }
    }
}
