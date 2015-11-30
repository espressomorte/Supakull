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
        private UserProvider.UserDTO loggedUser;
        private List<IAccountSettings> userAccounts;
        private List<IAccountSettings> sharedUserAccounts;

        DBSettingDialog dbSetingDialog;
        TrelloSettingDialog trelloSettingDialog;
        ExcelSettingsDialog excelSettingsDialog;


        public SettingsDialog(UserProvider.UserDTO loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.userAccounts = loggedUser.GetAllUserAccounts();
            this.sharedUserAccounts = loggedUser.GetAllSharedUserAccounts();

            dbSetingDialog = new DBSettingDialog(loggedUser, userAccounts, sharedUserAccounts);
            trelloSettingDialog = new TrelloSettingDialog(loggedUser, userAccounts, sharedUserAccounts);
            excelSettingsDialog = new ExcelSettingsDialog(loggedUser, userAccounts, sharedUserAccounts);
        }

        private void dataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(dbSetingDialog);     
        }

        private void trelloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(trelloSettingDialog);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(excelSettingsDialog);
        }
    }
}
