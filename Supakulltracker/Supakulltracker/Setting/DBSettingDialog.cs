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
        private List<IAccountSettings> userDBAccounts;
        private DatabaseAccountSettings userDBFullAccount;
        private DatabaseAccountSettings newAccountSetting = new DatabaseAccountSettings();
        private DatabaseAccountToken newToken = new DatabaseAccountToken();


        public DBSettingDialog(UserForAuthentication user, List<IAccountSettings> accounts)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.userDBAccounts = SettingsManager.GetAllUserAccountsInSource(accounts,Sources.DataBase);     
            PrepareDialog();
        }

        private void PrepareDialog()
        {  
            foreach (var item in userDBAccounts)
            {
               cmbAcconts.Items.Add(item.Name);
            }

            this.Dock = DockStyle.Fill;   
            this.Show();
            cmbDBType.Items.AddRange(Enum.GetNames(typeof(DatabaseDriver)));
            cmbDBDialect.Items.AddRange(Enum.GetNames(typeof(DatabaseDialect)));
        }

        private void availableConectionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            IAccountSettings selectedAccount = userDBAccounts.FirstOrDefault(x => x.Name == cmbAcconts.SelectedItem.ToString());
            userDBFullAccount = (DatabaseAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID);
            cmbTokens.Items.Clear();
            foreach (var item in userDBFullAccount.Tokens)
            {
                cmbTokens.Items.Add(item.TokenName);
            }
        }

        private void PrepareForShowingTokenDetails(DatabaseAccountToken token)
        {
            cmbDBType.Text = token.DatabaseDriver.ToString();
            cmbDBDialect.Text = token.DatabaseDialect.ToString();
            panelChoseDBProvider.Show();

            txtUserID.Text = token.UserName;
            txtPasswrd.Text = token.Password;
            txtDataSource.Text = token.DataSource;
            panelConStrDiteils.Show();

            txtConnectionString.Text = token.ConnectionString;
            panelPreviewString.Show();

            rtxtMapping.Text = token.Mapping;
        }

        private void cmbTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseAccountToken selectedToken = userDBFullAccount.Tokens.FirstOrDefault(x => x.TokenName == cmbTokens.SelectedItem.ToString());
            PrepareForShowingTokenDetails(selectedToken);
        }

        private void btnEddNewConfigForDB_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToken_Click(object sender, EventArgs e)
        {
            cmbDBType.Text = String.Empty;
            cmbDBDialect.Text = String.Empty;
            txtConnectionString.Text = String.Empty;
            txtPasswrd.Text = String.Empty;
            txtUserID.Text = String.Empty;
            txtDataSource.Text = String.Empty;
            rtxtMapping.Text = String.Empty;
            label2.Hide();
            cmbDBDialect.Hide();
            panelConStrDiteils.Hide();
            panelPreviewString.Hide();

        }

        private void cmbDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseDriver dbDriver;
            Enum.TryParse(cmbDBType.SelectedItem.ToString(),out dbDriver);
            newToken.DatabaseDriver = dbDriver;
            label2.Show();
            cmbDBDialect.Show();
        }

        private void cmbDBDialect_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseDialect dbDialect;
            Enum.TryParse(cmbDBDialect.SelectedItem.ToString(), out dbDialect);
            newToken.DatabaseDialect = dbDialect;

            panelConStrDiteils.Show();
        }

        private void btnApplyConSetDiteils_Click(object sender, EventArgs e)
        {
            newToken.UserName = txtUserID.Text;
            newToken.Password = txtPasswrd.Text;
            newToken.DataSource = txtDataSource.Text;

            CreateConString();
            panelPreviewString.Show();
            txtConnectionString.Text = newToken.ConnectionString; 
        }

        private void CreateConString()
        {
            String conStr = String.Format("User ID = '{0}'; Password = {1}; Data Source = {2}", newToken.UserName, newToken.Password, newToken.DataSource);
            newToken.ConnectionString = conStr;
        }

        private void btnTestConStr_Click(object sender, EventArgs e)
        {
            btnGoToMappingTab.Show();

        }

        private void btnGoToMappingTab_Click(object sender, EventArgs e)
        {
            DBTab.SelectTab(1);
            panelItemName.Show();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (txtNewTokenName.Text != String.Empty && rtxtMapping.Text != String.Empty)
            {
                newToken.TokenName = txtNewTokenName.Text;
                newToken.Mapping = rtxtMapping.Text;
                userDBFullAccount.Tokens.Add(newToken);
                SettingsManager.SaveOrUpdateAccount(userDBFullAccount);
            }
            else
            {
                label5.Text = "Plese enter token name and mapping!";
                label5.ForeColor = Color.Red;
            }
        }
    }
}
