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
        private UserProvider.UserDTO loggedUser;
        private List<IAccountSettings> userDBAccounts;
        private List<IAccountSettings> sharedUserDBAccounts;
        private DatabaseAccountSettings userDBFullAccount;
        private DatabaseAccountSettings newAccountSetting;
        private DatabaseAccountToken newToken;
        private DatabaseAccountToken selectedToken;


        public DBSettingDialog(UserProvider.UserDTO user, List<IAccountSettings> accounts, List<IAccountSettings> sharedAccounts)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.userDBAccounts = SettingsManager.GetAllUserAccountsInSource(accounts, Sources.DataBase);
            this.sharedUserDBAccounts = SettingsManager.GetAllUserAccountsInSource(sharedAccounts, Sources.DataBase);
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
            btnShareAccount.Enabled = false;
            cmbDBType.SelectedIndexChanged -= cmbDBType_SelectedIndexChanged;
            cmbDBDialect.SelectedIndexChanged -= cmbDBDialect_SelectedIndexChanged;
            btnCancelSaveOrEditingSettings.Click += btnCancelSaveNewToken_Click;
            cmbDBType.Items.AddRange(Enum.GetNames(typeof(DatabaseDriver)));
            cmbDBDialect.Items.AddRange(Enum.GetNames(typeof(DatabaseDialect)));
            if (sharedUserDBAccounts.Count > 0)
            {
                cmbSharedAccounts.Enabled = true;
                foreach (var item in sharedUserDBAccounts)
                {
                    cmbSharedAccounts.Items.Add(item.Name);
                }
            }
            else
            {
                cmbSharedAccounts.Enabled = false;
            }
        }

        private void availableConectionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddToken.Enabled = true;
            if (cmbAcconts.SelectedItem != null)
            {
                cmbSharedAccounts.SelectedItem = null;
                UdateDataBaseSettingForm();
                btnShareAccount.Enabled = true;
                btnDeleteAccount.Enabled = true;
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
                    this.selectedToken = selectedToken;
                    PrepareForShowingTokenDetails(selectedToken);
                    if (userDBFullAccount.Owner)
                    {
                        btnDeleteToken.Enabled = true;
                        btnChangeToken.Enabled = true;
                    }
                    else
                    {
                        btnChangeToken.Enabled = false;
                        btnDeleteToken.Enabled = false;
                    }
                }

            }

        }

        private void btnAddToken_Click(object sender, EventArgs e)
        {
            newToken = new DatabaseAccountToken();
            cmbTokens.Enabled = false;
            btnAddToken.Enabled = false;
            cmbDBType.Text = String.Empty;
            cmbDBDialect.Text = String.Empty;
            txtConnectionString.Text = String.Empty;
            txtPasswrd.Text = String.Empty;
            txtUserID.Text = String.Empty;
            txtDataSource.Text = String.Empty;
            rtxtMapping.Text = String.Empty;
            txtNewTokenName.Text = String.Empty;
            label1.Text = "Choose DB Type";
            label2.Text = "Choose DB Dialect";
            label4.Text = "Set a conection string details";
            panelChoseDBProvider.Show();
            btnCancelSaveOrEditingSettings.Show();
            label2.Hide();
            cmbDBDialect.Hide();
            panelConStrDiteils.Hide();
            panelPreviewString.Hide();
            MakeFieldsEnabled();
            groupBoxAccounts.Enabled = false;

            cmbDBType.SelectedIndexChanged += cmbDBType_SelectedIndexChanged;
            cmbDBDialect.SelectedIndexChanged += cmbDBDialect_SelectedIndexChanged;
            btnApplyConSetDiteils.Click += btnApplyConSetDiteils_Click;
            btnApplyConSetDiteils.Click -= btnApplyConSetDiteilsForExistingToken_Click;
            btnSaveSettings.Click += btnSaveSettings_Click;
            btnSaveSettings.Click -= btnSaveChangedSettings_Click;
            cmbDBDialect.SelectedIndexChanged -= cmbDBDialect_SelectedIndexChangedForExistingToken;
            cmbDBDialect.SelectedIndexChanged -= cmbDBType_SelectedIndexChangedForExistingToken;
            cmbDBDialect.SelectedIndexChanged += cmbDBType_SelectedIndexChanged;
            cmbDBDialect.SelectedIndexChanged += cmbDBDialect_SelectedIndexChanged;
            btnTestConStr.Click += btnTestConStr_Click;
            btnTestConStr.Click -= btnTestConStrChanged_Click;
            btnChekMapping.Click += btnChekMapping_Click;
            btnChekMapping.Click -= btnChekMappingChanged_Click;
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

            newToken.ConnectionString = CreateConString(newToken);
            panelPreviewString.Show();
            btnTestConStr.Show();
            txtConnectionString.Text = newToken.ConnectionString;
        }

        private String CreateConString(DatabaseAccountToken token)
        {
            String conStr = String.Format("User ID = '{0}'; Password = {1}; Data Source = {2}", token.UserName, token.Password, token.DataSource);
            return conStr;
        }

        private void btnTestConStr_Click(object sender, EventArgs e)
        {
            DatabaseAccountSettings accForTest = new DatabaseAccountSettings();
            accForTest.Tokens.Add(newToken);
            if (SettingsManager.AccountSettingsTest(accForTest))
            {
                label12.Text = "Connected!";
                label12.ForeColor = Color.Green;
                label12.Show();
                btnGoToMappingTab.Show();
            }
            else
            {
                label12.Text = "Error! Check settings.";
                label12.ForeColor = Color.Red;
                label12.Show();
            }
            

        }

        private void btnTestConStrChanged_Click(object sender, EventArgs e)
        {
            DatabaseAccountSettings accForTest = new DatabaseAccountSettings();
            accForTest.Tokens.Add(selectedToken);
            if (SettingsManager.AccountSettingsTest(accForTest))
            {
                label12.Text = "Connected!";
                label12.ForeColor = Color.Green;
                label12.Show();
                btnGoToMappingTab.Show();
            }
            else
            {
                label12.Text = "Error! Check settings.";
                label12.ForeColor = Color.Red;
                label12.Show();
            }


        }

        private void btnGoToMappingTab_Click(object sender, EventArgs e)
        {
            DBTab.SelectTab(1);
            panelItemName.Show();
            flpSaveAccount.Show();
            numUpdateTime.Enabled = true;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (txtNewTokenName.Text.Trim() != String.Empty && rtxtMapping.Text.Trim() != String.Empty)
            {
                newToken.TokenName = txtNewTokenName.Text.Trim();
                newToken.Mapping = rtxtMapping.Text.Trim();
                userDBFullAccount.Tokens.Add(newToken);
                userDBFullAccount.MinUpdateTime = (Int32)numUpdateTime.Value;

                if (SettingsManager.SaveOrUpdateAccount(userDBFullAccount))
                {
                    DBTab.SelectTab(0);
                    UdateDataBaseSettingForm();
                    btnCancelSaveOrEditingSettings.Hide();
                    btnApplyConSetDiteils.Click -= btnApplyConSetDiteils_Click;
                }
            }
            else
            {
                label5.Show();
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
            numUpdateTime.Enabled = false;
            groupBoxAccounts.Enabled = true;
            label12.Hide();
            label5.Hide();
            panelChoseDBProvider.Hide();
            panelConStrDiteils.Hide();
            panelItemName.Hide();
            panelPreviewString.Hide();
            btnSaveSettings.Hide();
            flpSaveAccount.Hide();
            panelItemName.Hide();
            btnGoToMappingTab.Hide();
            rtxtMapping.Clear();
            btnApplyConSetDiteils.Hide();
            GetSelectedAccountAndFillTokensToControl();
            btnAddToken.Enabled = true;
            cmbTokens.Enabled = true;
        }

        private void GetSelectedAccountAndFillTokensToControl()
        {
            if (cmbAcconts.SelectedItem != null)
            {
                IAccountSettings selectedAccount = userDBAccounts.FirstOrDefault(x => x.Name == cmbAcconts.SelectedItem.ToString());
                userDBFullAccount = (DatabaseAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID, selectedAccount.Owner);
                cmbTokens.Items.Clear();
                cmbTokens.Text = String.Empty;
                numUpdateTime.Value = userDBFullAccount.MinUpdateTime;
                foreach (var item in userDBFullAccount.Tokens)
                {
                    cmbTokens.Items.Add(item.TokenName);
                }
                btnChangeToken.Enabled = false;
                btnDeleteToken.Enabled = false;
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
            rtxtMapping.ReadOnly = true;

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
            rtxtMapping.ReadOnly = false;
        }

        private void btnEddNewConfigAccountForDB_Click(object sender, EventArgs e)
        {
            panelNewAccount.Show();
            groupBoxTokens.Enabled = false;
            newAccountSetting = new DatabaseAccountSettings();
        }

        private void btnNewAccountCancel_Click(object sender, EventArgs e)
        {
            panelNewAccount.Hide();
            groupBoxTokens.Enabled = true;
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
            label6.Text = "Please enter new account name";
            label6.ForeColor = Color.Black;
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
                        RefreshSettingsAccountList();
                        panelNewAccount.Hide();
                        ClearAllForm();
                    }
                    else
                    {
                        label6.Text = "Please try again";
                        label6.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                label6.Text = "Name can not be empty string";
                label6.ForeColor = Color.Red;
            }
        }

        private void RefreshSettingsAccountList()
        {
            List<IAccountSettings> userAllAccounts = loggedUser.GetAllUserAccounts();
            sharedUserDBAccounts = loggedUser.GetAllSharedUserAccounts();
            userDBAccounts = SettingsManager.GetAllUserAccountsInSource(userAllAccounts, Sources.DataBase);
            sharedUserDBAccounts = SettingsManager.GetAllUserAccountsInSource(sharedUserDBAccounts, Sources.DataBase);

            cmbAcconts.Items.Clear();
            foreach (var item in userDBAccounts)
            {
                cmbAcconts.Items.Add(item.Name);
            }
            cmbSharedAccounts.Items.Clear();
            if (sharedUserDBAccounts.Count > 0)
            {
                label13.Show();
                cmbSharedAccounts.Show();
                foreach (var item in sharedUserDBAccounts)
                {
                    cmbSharedAccounts.Items.Add(item.Name);
                }
            }
            else
            {
                label13.Hide();
                cmbSharedAccounts.Hide();
            }
        }

        private void ClearAllForm()
        {
            panelChoseDBProvider.Hide();
            panelConStrDiteils.Hide();
            panelItemName.Hide();
            panelPreviewString.Hide();
            txtNewNameForAccount.Text = String.Empty;
            cmbTokens.Text = String.Empty;
            txtShareUserName.Text = String.Empty;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            String selectedAccountName;
            if (cmbAcconts.SelectedItem != null && (cmbAcconts.SelectedItem.ToString() == userDBFullAccount.Name))
            {
                selectedAccountName = cmbAcconts.SelectedItem.ToString();
            }
            else if (cmbSharedAccounts.SelectedItem != null && (cmbSharedAccounts.SelectedItem.ToString() == userDBFullAccount.Name))
            {
                selectedAccountName = cmbSharedAccounts.SelectedItem.ToString();
            }
            else
            {
                selectedAccountName = String.Empty;
            }

            if (selectedAccountName != String.Empty)
            {
                Boolean deleteResult;

                if (DialogResult.Yes == MessageBox.Show(
                    String.Format("Delete this Account: {0}.", selectedAccountName), "Confirm", MessageBoxButtons.YesNo))
                {
                    if (userDBFullAccount.Owner)
                    {
                        if (DialogResult.Yes == MessageBox.Show(
                        String.Format("Delete this account for all users?", selectedAccountName), "Confirm", MessageBoxButtons.YesNo))
                        {
                            deleteResult = loggedUser.DeleteAccount(userDBFullAccount, true);
                        }
                        else
                        {
                            deleteResult = loggedUser.DeleteAccount(userDBFullAccount, false);
                        }
                    }
                    else
                    {
                        deleteResult = loggedUser.DeleteAccount(userDBFullAccount, false);
                    }

                    if (deleteResult)
                    {
                        ClearAllForm();
                        RefreshSettingsAccountList();
                    }
                    else
                    {
                        MessageBox.Show("Oops! Error. Try later");
                    }
                }
            }
        }

        private void cmbSharedAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSharedAccounts.SelectedItem != null)
            {
                cmbAcconts.SelectedItem = null;
                IAccountSettings selectedAccount = sharedUserDBAccounts.FirstOrDefault(x => x.Name == cmbSharedAccounts.SelectedItem.ToString());
                userDBFullAccount = (DatabaseAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID, selectedAccount.Owner);
                cmbTokens.Text = String.Empty;
                btnAddToken.Enabled = false;
                btnDeleteToken.Enabled = false;
                btnChangeToken.Enabled = false;
                if (userDBFullAccount != null)
                {
                    cmbTokens.Items.Clear();
                    foreach (var item in userDBFullAccount.Tokens)
                    {
                        cmbTokens.Items.Add(item.TokenName);
                    }
                    btnDeleteAccount.Enabled = true;
                }
                btnShareAccount.Enabled = false;
                ClearAllForm();
            }
        }

        private void btnShareAccount_Click(object sender, EventArgs e)
        {
            panelNewShareAccount.Show();
        }

        private void btnCancelSaveShareAccount_Click(object sender, EventArgs e)
        {
            txtShareUserName.Text = String.Empty;
            lblSharedAccountError.Hide();
            panelNewShareAccount.Hide();
        }

        private void btnSaveSharedAccount_Click(object sender, EventArgs e)
        {
            String shareUserName = txtShareUserName.Text.Trim();
            if (shareUserName != String.Empty && shareUserName != loggedUser.UserLogin)
            {
                Boolean result = loggedUser.ShareTheSettingAccount(userDBFullAccount, shareUserName, chboxMakeUserOwner.Checked);
                if (result)
                {
                    RefreshSettingsAccountList();
                    ClearAllForm();
                    panelNewShareAccount.Hide();
                }
                else
                {
                    lblSharedAccountError.Text = "Please try later";
                    lblSharedAccountError.Show();
                }
            }
            else
            {
                lblSharedAccountError.Text = "Envalid user name!";
                lblSharedAccountError.Show();
            }
        }

        private void btnChangeToken_Click(object sender, EventArgs e)
        {
            numUpdateTime.Enabled = true;
            MakeFieldsEnabled();
            groupBoxAccounts.Enabled = false;
            cmbTokens.Enabled = false;
            cmbAcconts.Enabled = false;
            cmbSharedAccounts.Enabled = false;
            btnAddToken.Enabled = false;
            btnDeleteToken.Enabled = false;
            btnChangeToken.Enabled = false;
            btnCancelSaveOrEditingSettings.Show();
            btnApplyConSetDiteils.Show();
            btnTestConStr.Show();
            txtNewTokenName.Text = selectedToken.TokenName;

            btnSaveSettings.Click -= btnSaveSettings_Click;
            btnSaveSettings.Click += btnSaveChangedSettings_Click;
            btnApplyConSetDiteils.Click -= btnApplyConSetDiteils_Click;
            btnApplyConSetDiteils.Click += btnApplyConSetDiteilsForExistingToken_Click;
            cmbDBDialect.SelectedIndexChanged += cmbDBDialect_SelectedIndexChangedForExistingToken;
            cmbDBDialect.SelectedIndexChanged += cmbDBType_SelectedIndexChangedForExistingToken;
            cmbDBDialect.SelectedIndexChanged -= cmbDBType_SelectedIndexChanged;
            cmbDBDialect.SelectedIndexChanged -= cmbDBDialect_SelectedIndexChanged;
            btnApplyConSetDiteils.Click += btnApplyConSetDiteilsForExistingToken_Click;
            btnTestConStr.Click -= btnTestConStr_Click;
            btnTestConStr.Click += btnTestConStrChanged_Click;
            btnChekMapping.Click -= btnChekMapping_Click;
            btnChekMapping.Click += btnChekMappingChanged_Click;
            
        }

        private void btnApplyConSetDiteilsForExistingToken_Click(object sender, EventArgs e)
        {
            selectedToken.UserName = txtUserID.Text;
            selectedToken.Password = txtPasswrd.Text;
            selectedToken.DataSource = txtDataSource.Text;

            selectedToken.ConnectionString = CreateConString(selectedToken);
            txtConnectionString.Text = selectedToken.ConnectionString;
        }

        private void btnSaveChangedSettings_Click(object sender, EventArgs e)
        {
            if (txtNewTokenName.Text.Trim() != String.Empty && rtxtMapping.Text.Trim() != String.Empty)
            {
                selectedToken.TokenName = txtNewTokenName.Text.Trim();
                selectedToken.Mapping = rtxtMapping.Text.Trim(); 
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

        private void cmbDBType_SelectedIndexChangedForExistingToken(object sender, EventArgs e)
        {
            DatabaseDriver dbDriver;
            Enum.TryParse(cmbDBType.SelectedItem.ToString(), out dbDriver);
            selectedToken.DatabaseDriver = dbDriver;      
        }

        private void cmbDBDialect_SelectedIndexChangedForExistingToken(object sender, EventArgs e)
        {
            DatabaseDialect dbDialect;
            Enum.TryParse(cmbDBDialect.SelectedItem.ToString(), out dbDialect);
            selectedToken.DatabaseDialect = dbDialect;        
        }

        private void btnCancelSaveNewToken_Click(object sender, EventArgs e)
        {
            DBTab.SelectTab(0);
            cmbTokens.Enabled = true;
            cmbAcconts.Enabled = true;
            btnAddToken.Enabled = true;
            btnDeleteToken.Enabled = true;
            btnChangeToken.Enabled = true;
            groupBoxAccounts.Enabled = true;
            groupBoxAccounts.Enabled = true;
            btnAddToken.Enabled = true;
            UdateDataBaseSettingForm();
            btnCancelSaveOrEditingSettings.Hide();

        }

        private void btnChekMapping_Click(object sender, EventArgs e)
        {
            DatabaseAccountSettings accForTest = new DatabaseAccountSettings();
            newToken.Mapping = rtxtMapping.Text;
            accForTest.Tokens.Add(newToken);
            
            if (SettingsManager.AccountSettingsTest(accForTest))
            {
                label5.Text = "Connected!";
                label5.ForeColor = Color.Green;
                label5.Show();
                btnSaveSettings.Show();
            }
            else
            {
                label5.Text = "Error! Check settings.";
                label5.ForeColor = Color.Red;
                label5.Show();
            }

        }
        private void btnChekMappingChanged_Click(object sender, EventArgs e)
        {
            DatabaseAccountSettings accForTest = new DatabaseAccountSettings();
            selectedToken.Mapping = rtxtMapping.Text;
            accForTest.Tokens.Add(selectedToken);
            if (SettingsManager.AccountSettingsTest(accForTest))
            {
                label5.Text = "Connected!";
                label5.ForeColor = Color.Green;
                label5.Show();
                btnSaveSettings.Show();
            }
            else
            {
                label5.Text = "Error! Check settings.";
                label5.ForeColor = Color.Red;
                label5.Show();
            }

        }
    }
}
