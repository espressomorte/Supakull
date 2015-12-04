using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supakulltracker.UserProvider;
using Supakulltracker.IssueService;

//using Google.GData.Client;
//using Google.GData.Spreadsheets;
//using Google.GData.Extensions;

namespace Supakulltracker
{
    public partial class GoogleSheetsSettingDialog : UserControl
    {
        //private OAuth2Parameters parameters = new OAuth2Parameters();
        //private ListFeed listFeed;
        private GoogleSheetsAccountToken googleSheetsAccountToken = new GoogleSheetsAccountToken();
        private GoogleSheetsAccountTemplate googleSheetsAccountTemplate = new GoogleSheetsAccountTemplate();
        private GoogleSheetsAccountSettings googleSheetsAccountSettings = new GoogleSheetsAccountSettings();
        private GoogleSheetsAccountSettings newGoogleSheetsAccountSettings = new GoogleSheetsAccountSettings();
        private UserProvider.UserDTO loggedUser;
        private List<IAccountSettings> userGoogleAccounts;
        private List<IAccountSettings> sharedUserGSAccounts;

        public GoogleSheetsSettingDialog(UserProvider.UserDTO user, List<IAccountSettings> accounts, List<IAccountSettings> sharedAccounts)
        {
            InitializeComponent();

            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;

            ((Control)this.tabPage2).Enabled = false;
            this.MappingDataView.EditMode = DataGridViewEditMode.EditOnEnter;

            this.loggedUser = user;
            this.userGoogleAccounts = SettingsManager.GetAllUserAccountsInSource(accounts, Sources.GoogleSheets);
            this.sharedUserGSAccounts = SettingsManager.GetAllUserAccountsInSource(sharedAccounts, Sources.GoogleSheets);

            foreach (var item in userGoogleAccounts)
            {
                AccountsNameComboBox.Items.Add(item.Name);
            }
            foreach (var item in sharedUserGSAccounts)
            {
                ShareAccountsComboBox.Items.Add(item.Name);
            }
        }

        private void LinkToGetToken_Click(object sender, EventArgs e)
        {
            if (LinkToGetToken.Text != null && LinkToGetToken.Text != "")
                System.Diagnostics.Process.Start(LinkToGetToken.Text);
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            //check file
            GoogleSheetsAccountToken locTok = new GoogleSheetsAccountToken();
            locTok.TokenName = "CheckFileName";
            locTok.RefreshToken = FileNameTB.Text;
            googleSheetsAccountSettings.Tokens.Add(locTok);
            googleSheetsAccountSettings = NewTestAccount(googleSheetsAccountSettings);
            if (googleSheetsAccountSettings.Tokens[1].RefreshToken != "This file does not exist")
            {
                StatusLabel.ForeColor = Color.Green;
                StatusLabel.Text = "OK";
            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "This file does not exist";
            }
            if (googleSheetsAccountSettings.Tokens.Count > 0)
                googleSheetsAccountSettings.Tokens.RemoveAt(googleSheetsAccountSettings.Tokens.Count - 1);
            //if (listFeed != null)
            //{
            //    ShowMapping();
            //}
        }

        private void ShowMapping()
        {
            //ListEntry row = (ListEntry)listFeed.Entries[0];
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            //for (int i = 0; i < row.Elements.Count; i++)
            //{
            //    list.Add(row.Elements[i].LocalName);
            //}

            list2.Add("TaskID"); list2.Add("SubtaskType");
            list2.Add("Summary"); list2.Add("Description");
            list2.Add("Status"); list2.Add("Priority");
            list2.Add("Product"); list2.Add("Project");
            list2.Add("CreatedDate"); list2.Add("CreatedBy");
            list2.Add("LinkToTracker"); list2.Add("Estimation");

            ((DataGridViewComboBoxColumn)MappingDataView.Columns[0]).DataSource = list;
            ((DataGridViewComboBoxColumn)MappingDataView.Columns[1]).DataSource = list2;


        }

        private void EnterAccessTokenButton_Click(object sender, EventArgs e)
        {
            string token = AccessTokenTextBox.Text;
            GoogleSheetsAccountToken locTok = new GoogleSheetsAccountToken();
            locTok.TokenName = "EnterAccessToken";
            locTok.RefreshToken = token;
            
            googleSheetsAccountSettings.Tokens.Add(locTok);
            googleSheetsAccountSettings = NewTestAccount(googleSheetsAccountSettings);

            googleSheetsAccountToken.RefreshToken = googleSheetsAccountSettings.Tokens[0].RefreshToken;
            if (googleSheetsAccountSettings.Tokens.Count > 0)
                googleSheetsAccountSettings.Tokens.RemoveAt(0);
            googleSheetsAccountToken.TokenName = "Token" + googleSheetsAccountSettings.Name;
            googleSheetsAccountSettings.Tokens.Add(googleSheetsAccountToken);
            SettingsManager.SaveOrUpdateAccount(googleSheetsAccountSettings);
            ((Control)this.tabPage2).Enabled = true;
            LinkToGetToken.Text = null;
            AccessTokenTextBox.Text = null;
            TokenStatusLabel.ForeColor = Color.DarkTurquoise;
            TokenStatusLabel.Text = "New token is saved";
            RefreshMapSetting();
        }

        private void UseSaveToken_Click(object sender, EventArgs e)
        {
            if (isNewToken)
            {
                GoogleSheetsAccountToken locTok = new GoogleSheetsAccountToken();
                locTok.TokenName = "UseSaveToken";
                googleSheetsAccountSettings.Tokens.Add(locTok);
                googleSheetsAccountSettings = NewTestAccount(googleSheetsAccountSettings);
                if (googleSheetsAccountSettings.Tokens.Count > 0)
                    googleSheetsAccountSettings.Tokens.RemoveAt(0);
            }
            else
            {
                GoogleSheetsAccountToken locTok = new GoogleSheetsAccountToken();
                locTok.TokenName = "UseSaveToken";
                locTok.RefreshToken = googleSheetsAccountSettings.Tokens[0].RefreshToken;
                googleSheetsAccountSettings.Tokens.Add(locTok);
                NewTestAccount(googleSheetsAccountSettings);
                if (googleSheetsAccountSettings.Tokens.Count > 0)
                    googleSheetsAccountSettings.Tokens.RemoveAt(googleSheetsAccountSettings.Tokens.Count-1);
            }
            ((Control)this.tabPage2).Enabled = true;
            RefreshMapSetting();
        }
        // создание ссылки на получение токена || использование сохраненного токена
        private bool isNewToken;
        private void CheckAccount_Click(object sender, EventArgs e)
        {
            isNewToken = false;
            LinkToGetToken.Text = null;
            accName = AccountsNameComboBox.SelectedItem.ToString();
            IAccountSettings result = userGoogleAccounts.SingleOrDefault(x => x.Name == accName);
            if (SettingsManager.GetDetailsForAccount(loggedUser, result.ID) != null)
            {
                googleSheetsAccountSettings = (GoogleSheetsAccountSettings)SettingsManager.GetDetailsForAccount(loggedUser, result.ID);
            }
            if (googleSheetsAccountSettings.Tokens.Count == 0)
            {
                TokenStatusLabel.Text = "Get a new token";
                TokenStatusLabel.ForeColor = Color.Red;
                GoogleSheetsAccountToken locTok = new GoogleSheetsAccountToken();
                locTok.TokenName = "GetNewToken";
                googleSheetsAccountSettings.Tokens.Add(locTok);
                googleSheetsAccountSettings = NewTestAccount(googleSheetsAccountSettings);

                LinkToGetToken.Text = googleSheetsAccountSettings.Tokens.Last().RefreshToken;
                if (googleSheetsAccountSettings.Tokens.Count > 0)
                    googleSheetsAccountSettings.Tokens.RemoveAt(0);
                isNewToken = true;
            }
            else
            {
                TokenStatusLabel.ForeColor = Color.Green;
                TokenStatusLabel.Text = "You already have a token";
                UseSaveToken_Click(null, null);
            }
        }

        private void NewTemplateButton_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            RefreshMapSetting();
        }

        private void ActivateTemplateButton_Click(object sender, EventArgs e)
        {
            if (TemplateComboBox.SelectedItem != null) // допилить!
            {
                IAccountSettings result = userGoogleAccounts.SingleOrDefault(x => x.Name == accName);
                if (SettingsManager.GetDetailsForAccount(loggedUser, result.ID) != null)
                {
                    googleSheetsAccountSettings = (GoogleSheetsAccountSettings)SettingsManager.GetDetailsForAccount(loggedUser, result.ID);
                }
                // [a1-b1][a2-b2]...[an-bn]
                if (googleSheetsAccountSettings.Tokens.Count > 0)
                {
                    googleSheetsAccountTemplate = googleSheetsAccountSettings.Template.SingleOrDefault(x => x.TemplateName == TemplateComboBox.SelectedItem.ToString());
                    //googleSheetsAccountTemplate
                }
            }
        }
        private string accName = "";
        private void DeleteTemplateButton_Click(object sender, EventArgs e)
        {
            if (TemplateComboBox.SelectedItem != null)
            {
                IAccountSettings result = userGoogleAccounts.SingleOrDefault(x => x.Name == accName);
                if (SettingsManager.GetDetailsForAccount(loggedUser, result.ID) != null)
                {
                    googleSheetsAccountSettings = (GoogleSheetsAccountSettings)SettingsManager.GetDetailsForAccount(loggedUser, result.ID);
                }
                googleSheetsAccountSettings.Template.RemoveAt(TemplateComboBox.SelectedIndex);
                if (SettingsManager.SaveOrUpdateAccount(googleSheetsAccountSettings))
                {
                    RefreshMapSetting();
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            TemplateNameTextBox.Text = "";
            groupBox2.Visible = false;
        }

        private void RefreshMapSetting()
        {
            label13.Text = "";
            MappingDataView.DataSource = null;
            MappingDataView.SelectAll();
            MappingDataView.ClearSelection();
            TemplateComboBox.Items.Clear();
            IAccountSettings result = userGoogleAccounts.SingleOrDefault(x => x.Name == AccountsNameComboBox.SelectedItem.ToString());
            if (SettingsManager.GetDetailsForAccount(loggedUser, result.ID) != null)
            {
                googleSheetsAccountSettings = (GoogleSheetsAccountSettings)SettingsManager.GetDetailsForAccount(loggedUser, result.ID);
            }
            foreach (var item in googleSheetsAccountSettings.Template)
            {
                TemplateComboBox.Items.Add(item.TemplateName);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            String newTemplateName = TemplateNameTextBox.Text.Trim();
            if (newTemplateName != String.Empty && MappingDataView.Rows.Count > 0)
            {
                GoogleSheetsAccountTemplate googleSheetsAccountTemplate = new GoogleSheetsAccountTemplate();

                String mapstr = "";
                for (int i = 0; i < MappingDataView.Rows.Count - 1; i++)
                {
                    mapstr += "[" + MappingDataView.Rows[i].Cells[0].Value.ToString() + "-";
                    mapstr += MappingDataView.Rows[i].Cells[1].Value.ToString() + "]";
                }
                googleSheetsAccountTemplate.Mapping = mapstr;
                googleSheetsAccountTemplate.TemplateName = newTemplateName;
                googleSheetsAccountSettings.Template.Add(googleSheetsAccountTemplate);
                if (SettingsManager.SaveOrUpdateAccount(googleSheetsAccountSettings))
                {
                    RefreshMapSetting();
                }
                else
                {
                    label13.Text = "Error! Please try again";
                }
            }
            else
            {
                label13.Text = "Name can not be empty string";
                label13.ForeColor = Color.Red;
            }

            TemplateNameTextBox.Text = "";
            groupBox2.Visible = false;
        }

        //GoogleSheetsAccountSettings TestAccountSettings = new GoogleSheetsAccountSettings();
        private GoogleSheetsAccountSettings NewTestAccount(GoogleSheetsAccountSettings TestAccountSettings)
        {
            IAccountSettings ias;
            SettingsManager.AccountSettingsTest(TestAccountSettings, out ias);
            TestAccountSettings = (GoogleSheetsAccountSettings)ias;
            return TestAccountSettings;
        }
        // создание аккаунта
        private void AddAccountGBButton_Click(object sender, EventArgs e)
        {
            String newAccountName = NameNewAccountTextBox.Text.Trim();
            if (newAccountName != String.Empty)
            {
                if (CheckNewAccauntNameAlreadyExist(newAccountName))
                {
                    label10.Text = "Name already exist. Plese enter new name";
                    label10.ForeColor = Color.Red;
                }
                else
                {
                    newGoogleSheetsAccountSettings.Name = newAccountName;
                    newGoogleSheetsAccountSettings.Tokens = new List<GoogleSheetsAccountToken>();
                    newGoogleSheetsAccountSettings.Template = new List<GoogleSheetsAccountTemplate>();
                    if (loggedUser.CreateNewAccount(newGoogleSheetsAccountSettings))
                    {
                        NameNewAccountTextBox.Text = "";
                        RefreshSettings();
                        groupBox3.Visible = false;
                    }
                    else
                    {
                        label10.Text = "Please try again";
                        label10.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                label10.Text = "Name can not be empty string";
                label10.ForeColor = Color.Red;
            }
        }

        private void AddNewAccountButton_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox4.Visible = true;
            groupBox5.Visible = false;
            GR4ComboBox.Items.Clear();
            foreach (var item in userGoogleAccounts)
            {
                GR4ComboBox.Items.Add(item.Name);
            }

        }

        private void GR3CancelButton_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        private void GR4CancelButton_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }
        // удаление аккаунта
        private void DeleteAccountGBButton_Click(object sender, EventArgs e)
        {
            String selectedAccountName;
            IAccountSettings result = userGoogleAccounts.SingleOrDefault(x => x.Name == GR4ComboBox.SelectedItem.ToString());
            if (SettingsManager.GetDetailsForAccount(loggedUser, result.ID) != null)
            {
                googleSheetsAccountSettings = (GoogleSheetsAccountSettings)SettingsManager.GetDetailsForAccount(loggedUser, result.ID);
            }
            if (GR4ComboBox.SelectedItem != null && (GR4ComboBox.SelectedItem.ToString() == googleSheetsAccountSettings.Name))
            {
                selectedAccountName = GR4ComboBox.SelectedItem.ToString();
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
                    if (googleSheetsAccountSettings.Owner)
                    {
                        if (DialogResult.Yes == MessageBox.Show(
                        String.Format("Delete this account for all users?", selectedAccountName), "Confirm", MessageBoxButtons.YesNo))
                        {
                            deleteResult = loggedUser.DeleteAccount(googleSheetsAccountSettings, true);
                        }
                        else
                        {
                            deleteResult = loggedUser.DeleteAccount(googleSheetsAccountSettings, false);
                        }
                    }
                    else
                    {
                        deleteResult = loggedUser.DeleteAccount(googleSheetsAccountSettings, false);
                    }

                    if (deleteResult)
                    {
                        groupBox4.Visible = false;
                        RefreshSettings();
                    }
                    else
                    {
                        MessageBox.Show("Error. Try later");
                    }
                }
            }
        }
        private void RefreshSettings()
        {
            List<IAccountSettings> userAllAccounts = loggedUser.GetAllUserAccounts();
            sharedUserGSAccounts = loggedUser.GetAllSharedUserAccounts();
            userGoogleAccounts = SettingsManager.GetAllUserAccountsInSource(userAllAccounts, Sources.GoogleSheets);
            sharedUserGSAccounts = SettingsManager.GetAllUserAccountsInSource(sharedUserGSAccounts, Sources.GoogleSheets);

            AccountsNameComboBox.Items.Clear();
            foreach (var item in userGoogleAccounts)
            {
                AccountsNameComboBox.Items.Add(item.Name);
            }
            GR4ComboBox.Items.Clear();
            foreach (var item in userGoogleAccounts)
            {
                GR4ComboBox.Items.Add(item.Name);
            }
        }
        private Boolean CheckNewAccauntNameAlreadyExist(String name)
        {
            IAccountSettings account = userGoogleAccounts.Select(x => x).Where(acc => acc.Name == name).SingleOrDefault();
            if (account != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ShareAccountButton_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = true;
            PermitChangesCB.Checked = false;
            ShareAccountsComboBox.Items.Clear();
            foreach (var item in userGoogleAccounts)
            {
                ShareAccountsComboBox.Items.Add(item.Name);
            }
        }

        private void ShareButton_Click(object sender, EventArgs e)
        {
            String shareUserName = ShareUserNameTB.Text;
            IAccountSettings result = userGoogleAccounts.SingleOrDefault(x => x.Name == ShareAccountsComboBox.SelectedItem.ToString());
            if (SettingsManager.GetDetailsForAccount(loggedUser, result.ID) != null)
            {
                googleSheetsAccountSettings = (GoogleSheetsAccountSettings)SettingsManager.GetDetailsForAccount(loggedUser, result.ID);
            }
            if (shareUserName != String.Empty && shareUserName != loggedUser.UserLogin)
            {
                Boolean res = loggedUser.ShareTheSettingAccount(googleSheetsAccountSettings, shareUserName, PermitChangesCB.Checked);
                if (res)
                {
                    RefreshSettings();
                    groupBox5.Visible = false;
                    ShareUserNameTB.Text = null;
                }
                else
                {
                    label12.Text = "Please try later";
                }
            }
            else
            {
                MessageBox.Show("Error!");
                label12.Text = "Invalid user name!";
            }
        }

        private void GR5CancelButton_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            ShareUserNameTB.Text = null;
            ShareAccountsComboBox.Items.Clear(); ;
        }
    }
}