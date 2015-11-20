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


namespace Supakulltracker
{
    public partial class TrelloSettingDialog : UserControl
    {
        private UserProvider.UserDTO loggedUser;
        private List<IAccountSettings> userTrelloAccounts;
        private List<IAccountSettings> sharedUserTrelloAccounts;
        private TrelloAccountSettings userTrelloFullAccount;
        private TrelloAccountSettings newAccountSetting;
        private TrelloAccountToken newToken;


        public TrelloSettingDialog(UserProvider.UserDTO user, List<IAccountSettings> accounts, List<IAccountSettings> sharedAccounts)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.userTrelloAccounts = SettingsManager.GetAllUserAccountsInSource(accounts, Sources.Trello);
            this.sharedUserTrelloAccounts = SettingsManager.GetAllUserAccountsInSource(sharedAccounts, Sources.Trello);
            PrepareDialog();
        }
        private void PrepareDialog()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
            if (userTrelloAccounts != null)
            {
                foreach (var trelloAccount in userTrelloAccounts)
                {
                    activeTrelloAccounts.Items.Add(trelloAccount.Name);
                }
            }
            urlTrello.Links.Add(0, 40, "https://trello.com/1/connect?key=f82892a94916ced8f28b2f6496d4ba53&name=f82892a94916ced8f28b2f6496d4ba53&response_type=token&scope=read,write&expiration=never");
            if (sharedUserTrelloAccounts.Count > 0)
            {
                sharedLabel.Show();
                sharedTrelloAccountsBox.Show();
                foreach (var item in sharedUserTrelloAccounts)
                {
                    sharedTrelloAccountsBox.Items.Add(item.Name);
                }
            }
            else
            {
                sharedLabel.Hide();
                sharedTrelloAccountsBox.Hide();
            }
        }

        private void addingTrelloToken_Click(object sender, EventArgs e)
        {
            shearingGroupBox.Visible = false;
            addingToken.Visible =true;
            informationGroupBox.Visible = false;
            addingAccount.Visible = false;
            tokenCheckingBox.Text = String.Empty;
            //urlTrello.Links.Add(0,40,"https://trello.com/1/connect?key=f82892a94916ced8f28b2f6496d4ba53&name=f82892a94916ced8f28b2f6496d4ba53&response_type=token&scope=read,write&expiration=never");
        }

        private void checkingAccount_Click(object sender, EventArgs e)
        {
            //var trello = new Trello("f82892a94916ced8f28b2f6496d4ba53");
            //string name = trello.Members.ForToken(tokenCheckingBox.Text).FullName;
            //userFullName.Text =name;
            ////"https://trello.com/1/connect?key=f82892a94916ced8f28b2f6496d4ba53&name=f82892a94916ced8f28b2f6496d4ba53&response_type=token&scope=read,write&expiration=never"
        }

        private void activeTrelloAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            trelloToken.Enabled = true;
            trelloToken.Items.Clear();
            trelloToken.SelectedItem = null;
            addingTrelloToken.Enabled = true;
            trelloTokenGroup.Enabled = true;
            addingToken.Visible = false;
            addingAccount.Visible = false;
            informationGroupBox.Visible = false;
            if (activeTrelloAccounts.SelectedItem != null)
            {
                IAccountSettings account = userTrelloAccounts.FirstOrDefault(x => x.Name == activeTrelloAccounts.SelectedItem.ToString());
                if (account != null)
                {
                    userTrelloFullAccount =(TrelloAccountSettings)loggedUser.GetDetailsForAccount(account.ID);
                    if (userTrelloAccounts!=null)
                    {
                        trelloToken.Items.Clear();
                        foreach (var token in userTrelloFullAccount.Tokens)
                        {
                            trelloToken.Items.Add(token.TokenName);
                        }
                    }
                }
            }
        }

        private void trelloToken_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trelloToken.SelectedItem !=null)
            {
                TrelloAccountToken token = userTrelloFullAccount.Tokens.FirstOrDefault(x => x.TokenName == trelloToken.SelectedItem.ToString());
                if (token != null)
                {
                    addingToken.Hide();
                    informationGroupBox.Location = new Point(9, 187);
                    informationGroupBox.Visible = true;
                    infTokenName.Text = token.TokenName;
                    infTokenDateCreation.Text = token.DateCreation;
                    infTrelloUserToken.Text = token.UserToken;
                }
            }
            
        }

        private void AddAcountTrello_Click(object sender, EventArgs e)
        {
            addingToken.Visible = false;
            addingAccount.Visible =true;
            shearingGroupBox.Visible = false;
            addingAccount.Enabled = true;
            trelloTokenGroup.Enabled = false;

            //newAccountSetting = new TrelloAccountSettings();
            
            //SettingsManager.SaveOrUpdateAccount();
        }

        private void urlTrello_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void addTrelloAccountButton_Click(object sender, EventArgs e)
        {

            newAccountSetting = new TrelloAccountSettings();
            shearingGroupBox.Visible = false;
            newAccountSetting.Source =Sources.Trello;
            newAccountSetting.Name =accountNameBox.Text.ToString();
            newAccountSetting.Tokens = null;
            loggedUser.CreateNewAccount(newAccountSetting);
            RefreshSettingsAccountList();
            ClearAllForm();
        }
        //ded104e76f80e7dbe0c3f9ecc8f3591ee32af8fdfa90d32441380ccb1fcd35ee
        private void RefreshSettingsAccountList()
        {
            List<IAccountSettings> userAllAccounts = loggedUser.GetAllUserAccounts();
            sharedUserTrelloAccounts = loggedUser.GetAllSharedUserAccounts();
            userTrelloAccounts = SettingsManager.GetAllUserAccountsInSource(userAllAccounts, Sources.Trello);
            sharedUserTrelloAccounts = SettingsManager.GetAllUserAccountsInSource(sharedUserTrelloAccounts, Sources.Trello);

            activeTrelloAccounts.Items.Clear();
            foreach (var item in userTrelloAccounts)
            {
                activeTrelloAccounts.Items.Add(item.Name);
            }
            sharedTrelloAccountsBox.Items.Clear();
            if (sharedUserTrelloAccounts.Count > 0)
            {
                //label13.Show();
                sharedTrelloAccountsBox.Show();
                foreach (var item in sharedUserTrelloAccounts)
                {
                    sharedTrelloAccountsBox.Items.Add(item.Name);
                }
            }
            else
            {
                //label13.Hide();
                sharedTrelloAccountsBox.Visible=false;
            }
        }
        private void ClearAllForm()
        {
           // panelChoseDBProvider.Hide();
            //panelConStrDiteils.Hide();
            addingAccount.Hide();
            addingToken.Hide();
            trelloToken.Items.Clear();
            //txtNewNameForAccount.Text = String.Empty;
            trelloToken.Text = String.Empty;
            //txtShareUserName.Text = String.Empty;
        }
        private void tokenSave_Click(object sender, EventArgs e)
        {
            newToken = new TrelloAccountToken();
            newToken.TokenName = tokenNameBox.Text.Trim();
            newToken.UserToken = tokenCheckingBox.Text;
            newToken.DateCreation = DateTime.Today.ToString("d");
            userTrelloFullAccount.Tokens.Add(newToken);
            if (SettingsManager.SaveOrUpdateAccount(userTrelloFullAccount))
            {
                GetSelectedAccountAndFillTokensToControl();
            }
            addingToken.Visible = false;
        }
        private void GetSelectedAccountAndFillTokensToControl()
        {
            if (activeTrelloAccounts.SelectedItem != null)
            {
                IAccountSettings selectedAccount = userTrelloAccounts.FirstOrDefault(x => x.Name == activeTrelloAccounts.SelectedItem.ToString());
                userTrelloFullAccount = (TrelloAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID);
                userTrelloFullAccount.Owner = true;
                trelloToken.Items.Clear();
                trelloToken.Text = String.Empty;

                foreach (var item in userTrelloFullAccount.Tokens)
                {
                    trelloToken.Items.Add(item.TokenName);
                }
            }
        }

        private void shareAccountButton_Click(object sender, EventArgs e)
        {
            shearingGroupBox.Visible = true;
            shareUserNameBox.Text = String.Empty;
            labelSharedAccountError.Visible = false;
        }

        private void saveSharedAccountButton_Click(object sender, EventArgs e)
        {
            String shareUserName = shareUserNameBox.Text.Trim();
            if (shareUserName != String.Empty && shareUserName != loggedUser.UserLogin)
            {
                Boolean result = loggedUser.ShareTheSettingAccount(userTrelloFullAccount, shareUserName, makeUserOwnerCheckBox.Checked);
                if (result)
                {
                    RefreshSettingsAccountList();
                    ClearAllForm();
                    shearingGroupBox.Hide();
                }
                else
                {
                    labelSharedAccountError.Text = "Please try later";
                    labelSharedAccountError.Visible =true;
                }
            }
            else
            {
                labelSharedAccountError.Text = "Envalid user name!";
                labelSharedAccountError.Visible = true;
            }
        }

        private void btnCancelSaveShareAccount_Click(object sender, EventArgs e)
        {
            shareUserNameBox.Text = String.Empty;
            labelSharedAccountError.Visible = false;
            shearingGroupBox.Visible = false;
        }
    }
}
