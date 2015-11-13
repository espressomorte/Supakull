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
        private DatabaseAccountSettings newAccountSetting;
        private DatabaseAccountToken newToken;


        public DBSettingDialog(UserForAuthentication user, List<IAccountSettings> accounts)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.userDBAccounts = SettingsManager.GetAllUserAccountsInSource(accounts, Sources.DataBase);

            PrepareDialog();
        }

        private void PrepareDialog()
        {
            cmbAcconts.Items.Clear();
            foreach (var item in userDBAccounts)
            {
                cmbAcconts.Items.Add(item.Name);
            }

            this.Dock = DockStyle.Fill;
            this.Show();
            btnAddToken.Enabled = false;
            btnDeleteToken.Enabled = false;
            btnDeleteAccount.Enabled = false;
            cmbDBType.SelectedIndexChanged -= cmbDBType_SelectedIndexChanged;
            cmbDBDialect.SelectedIndexChanged -= cmbDBDialect_SelectedIndexChanged;
            cmbDBType.Items.AddRange(Enum.GetNames(typeof(DatabaseDriver)));
            cmbDBDialect.Items.AddRange(Enum.GetNames(typeof(DatabaseDialect)));
        }

        private void availableConectionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAcconts.SelectedItem != null)
            {
                IAccountSettings selectedAccount = userDBAccounts.FirstOrDefault(x => x.Name == cmbAcconts.SelectedItem.ToString());
                userDBFullAccount = (DatabaseAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID);
                if (userDBFullAccount != null)
                {
                    cmbTokens.Items.Clear();
                    foreach (var item in userDBFullAccount.Tokens)
                    {
                        cmbTokens.Items.Add(item.TokenName);
                    }
                    btnDeleteAccount.Enabled = true;
                    btnAddToken.Enabled = true;
                }

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
            btnApplyConSetDiteils.Hide();
            btnTestConStr.Hide();

            label1.Text = "Database Type";
            label2.Text = "Database Dialect";
            label4.Text = "Conection string details";

            MakeFieldsReadonly();
        }

        private void cmbTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTokens.SelectedItem != null)
            {
                DatabaseAccountToken selectedToken = userDBFullAccount.Tokens.FirstOrDefault(x => x.TokenName == cmbTokens.SelectedItem.ToString());
                if (selectedToken != null)
                {
                    PrepareForShowingTokenDetails(selectedToken);
                    btnDeleteToken.Enabled = true;
                }

            }

        }

        private void btnAddToken_Click(object sender, EventArgs e)
        {
            newToken = new DatabaseAccountToken();
            cmbDBType.Text = String.Empty;
            cmbDBDialect.Text = String.Empty;
            txtConnectionString.Text = String.Empty;
            txtPasswrd.Text = String.Empty;
            txtUserID.Text = String.Empty;
            txtDataSource.Text = String.Empty;
            rtxtMapping.Text = String.Empty;
            label1.Text = "Choose DB Type";
            label2.Text = "Choose DB Dialect";
            label4.Text = "Set a conection string details";
            panelChoseDBProvider.Show();
            label2.Hide();
            cmbDBDialect.Hide();
            panelConStrDiteils.Hide();
            panelPreviewString.Hide();
            MakeFieldsEnabled();
            cmbDBType.SelectedIndexChanged += cmbDBType_SelectedIndexChanged;
            cmbDBDialect.SelectedIndexChanged += cmbDBDialect_SelectedIndexChanged;

        }

        private void cmbDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseDriver dbDriver;
            Enum.TryParse(cmbDBType.SelectedItem.ToString(), out dbDriver);
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
            btnApplyConSetDiteils.Show();
        }

        private void btnApplyConSetDiteils_Click(object sender, EventArgs e)
        {
            newToken.UserName = txtUserID.Text;
            newToken.Password = txtPasswrd.Text;
            newToken.DataSource = txtDataSource.Text;

            CreateConString();
            panelPreviewString.Show();
            btnTestConStr.Show();
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
            flpSaveAccount.Show();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (txtNewTokenName.Text != String.Empty && rtxtMapping.Text != String.Empty)
            {
                newToken.TokenName = txtNewTokenName.Text.Trim();
                newToken.Mapping = rtxtMapping.Text.Trim();
                userDBFullAccount.Tokens.Add(newToken);
                if (SettingsManager.SaveOrUpdateAccount(userDBFullAccount))
                {
                    DBTab.SelectTab(0);
                    UdateDataBaseSettingForm();
                }
            }
            else
            {
                label5.Text = "Plese enter token name and mapping!";
                label5.ForeColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbTokens.SelectedItem != null)
            {
                if (DialogResult.Yes == MessageBox.Show(
                    String.Format("Delete this token: {0}", cmbTokens.SelectedItem.ToString()), "Confirm", MessageBoxButtons.YesNo))
                {
                    IAccountToken tokenToDelete = userDBFullAccount.Tokens.SingleOrDefault(x => x.TokenName == cmbTokens.SelectedItem.ToString());
                    if (tokenToDelete != null)
                    {
                        Boolean result = SettingsManager.DeleteToken(tokenToDelete);
                        if (result)
                        {
                            UdateDataBaseSettingForm();
                        }
                    }
                }

            }
        }

        private void UdateDataBaseSettingForm()
        {
            panelChoseDBProvider.Hide();
            panelConStrDiteils.Hide();
            panelItemName.Hide();
            panelPreviewString.Hide();
            flpSaveAccount.Hide();
            panelItemName.Hide();
            btnGoToMappingTab.Hide();
            rtxtMapping.Clear();
            btnApplyConSetDiteils.Hide();
            if (cmbAcconts.SelectedItem != null)
            {
                IAccountSettings selectedAccount = userDBAccounts.FirstOrDefault(x => x.Name == cmbAcconts.SelectedItem.ToString());
                userDBFullAccount = (DatabaseAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID);

                cmbTokens.Items.Clear();
                cmbTokens.Text = String.Empty;
                foreach (var item in userDBFullAccount.Tokens)
                {
                    cmbTokens.Items.Add(item.TokenName);
                }
            }
        }
        private void MakeFieldsReadonly()
        {
            cmbDBType.Enabled = false;
            cmbDBDialect.Enabled = false;
            txtConnectionString.Enabled = false;
            txtDataSource.Enabled = false;
            txtNewTokenName.Enabled = false;
            txtPasswrd.Enabled = false;
            txtUserID.Enabled = false;
            rtxtMapping.Enabled = false;

        }

        private void MakeFieldsEnabled()
        {
            cmbDBType.Enabled = true;
            cmbDBDialect.Enabled = true;
            txtConnectionString.Enabled = true;
            txtDataSource.Enabled = true;
            txtNewTokenName.Enabled = true;
            txtPasswrd.Enabled = true;
            txtUserID.Enabled = true;
            rtxtMapping.Enabled = true;
        }

        private void btnEddNewConfigAccountForDB_Click(object sender, EventArgs e)
        {
            panelNewAccount.Show();
            newAccountSetting = new DatabaseAccountSettings();
        }

        private void btnNewAccountCancel_Click(object sender, EventArgs e)
        {
            panelNewAccount.Hide();
            txtNewNameForAccount.Text = String.Empty;
        }

        private Boolean CheckNewAccauntNameAlreadyExist(String name)
        {
            IAccountSettings account = userDBAccounts.Select(x => x).Where(acc => acc.Name == name).SingleOrDefault();
            if (account != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSaveNewAccount_Click(object sender, EventArgs e)
        {
            String newAccountName = txtNewNameForAccount.Text.Trim();
            if (newAccountName != String.Empty)
            {
                if (CheckNewAccauntNameAlreadyExist(newAccountName))
                {
                    label6.Text = "Name already exist. Plese enter new name";
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    newAccountSetting.Name = newAccountName;
                    if (loggedUser.CreateNewAccount(newAccountSetting))
                    {
                        List<IAccountSettings> userAllAccounts = loggedUser.GetAllUserAccounts();
                        userDBAccounts = SettingsManager.GetAllUserAccountsInSource(userAllAccounts, Sources.DataBase);
                        panelNewAccount.Hide();
                        cmbAcconts.Items.Clear();
                        foreach (var item in userDBAccounts)
                        {
                            cmbAcconts.Items.Add(item.Name);
                        }
                    }
                    else
                    {
                        label6.Text = "Please try again";
                        label6.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}
