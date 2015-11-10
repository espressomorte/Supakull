using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supakulltracker.IssueService;
using Supakulltracker.UserProvider;

namespace Supakulltracker
{
    public partial class DBSettingDialog : UserControl
    {
        private UserForAuthentication loggedUser;
        private ServiceAccountDTO[] userDBAccounts;
        private ServiceAccountDTO userDBFullAccount;


        public DBSettingDialog(UserForAuthentication user, ServiceAccountDTO[] accounts)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.userDBAccounts = user.GetAllUserAccountsInSource(Sources.DataBase);
            PrepareDialog();
        }

        private void PrepareDialog()
        {  
            foreach (var item in userDBAccounts)
            {
               cmbAcconts.Items.Add(item.ServiceAccountName);
            }

            this.Dock = DockStyle.Fill;   
            this.Show();
        }

        private void availableConectionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceAccountDTO selectedAccount = userDBAccounts.FirstOrDefault(x => x.ServiceAccountName == cmbAcconts.SelectedItem.ToString());
            userDBFullAccount = loggedUser.GetDetailsForAccount(selectedAccount.ServiceAccountId);
            cmbTokens.Items.Clear();
            foreach (var item in userDBFullAccount.Tokens)
            {
                cmbTokens.Items.Add(item.TokenName);
            }
        }

        //private void PrepareForShowingTokenDetails(TokenDTO token)
        //{
        //    token.
        //    //panelChoseDBProvider.Show();
        //}

        private void cmbTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            TokenDTO selectedToken = userDBFullAccount.Tokens.FirstOrDefault(x => x.TokenName == cmbTokens.SelectedItem.ToString());
            //PrepareForShowingTokenDetails(selectedToken);
        }
    }
}
