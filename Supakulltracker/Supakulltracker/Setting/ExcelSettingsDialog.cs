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

using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Supakulltracker
{
    public partial class ExcelSettingsDialog : UserControl
    {
        private UserProvider.UserDTO loggedUser;
        private List<IAccountSettings> userExcelAccounts;
        private List<IAccountSettings> sharedUserExcelAccounts;

        private ExcelAccountSettings userExcelFullAccount;
        private ExcelAccountSettings newAccountSetting;
        private String pathToFolder;
        private ExcelAccountToken newToken = new ExcelAccountToken();


        public ExcelSettingsDialog(UserProvider.UserDTO user, List<IAccountSettings> accounts, List<IAccountSettings> sharedAccounts)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.userExcelAccounts = SettingsManager.GetAllUserAccountsInSource(accounts, Sources.Excel);
            this.sharedUserExcelAccounts = SettingsManager.GetAllUserAccountsInSource(sharedAccounts, Sources.Excel);
            PrepareDialog();
        }

        private void PrepareDialog()
        {
            foreach (var item in userExcelAccounts)
            {
                cmbAccounts.Items.Add(item.Name);
            }
            if (sharedUserExcelAccounts.Count > 0)
            {
                comboBox_shared.Show();
                foreach (var item in sharedUserExcelAccounts)
                {
                    label_shared.Show();
                    comboBox_shared.Items.Add(item.Name);
                }
            }
            this.Dock = DockStyle.Fill;
            this.Show();
        }

        #region Account

        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccounts.SelectedItem != null)
            {
                groupBoxTokens.Visible = true;
                comboBox_shared.SelectedItem = null;
                btn_delete_account.Enabled = true;
                btn_share_account.Enabled = true;
                grpBox_Connect_setting.Hide();

                GetSelectedAccountAndFillTokensToControl();
                comboBox_ExcelTemplate.Items.Clear();
                if (userExcelFullAccount.Template.Count > 0)
                {
                    comboBox_ExcelTemplate.Items.Add(userExcelFullAccount.Template.First().TemplateName);
                }
                MakeFormEnabled();
            }
        }

        private void MakeFormReadOnly()
        {
            if (!userExcelFullAccount.Owner)
            {
                dataGrid_mapping.ReadOnly = true;
                btnAddToken.Enabled = false;
                btnChangeToken.Enabled = false;
                btnDeleteToken.Enabled = false;
                btn_AddNewExcelTemplate.Enabled = false;
                btn_delete_template.Enabled = false;
                btn_saveMapping.Enabled = false;
            }
        }

        private void MakeFormEnabled()
        {
            if (!userExcelFullAccount.Owner)
            {
                dataGrid_mapping.ReadOnly = false;
                btnAddToken.Enabled = true;
                btnChangeToken.Enabled = true;
                btnDeleteToken.Enabled = true;
                btn_AddNewExcelTemplate.Enabled = true;
                btn_delete_template.Enabled = true;
                btn_saveMapping.Enabled = true;

            }
        }

        private void GetSelectedAccountAndFillTokensToControl()
        {
            if (cmbAccounts.SelectedItem != null)
            {
                IAccountSettings selectedAccount = userExcelAccounts.FirstOrDefault(x => x.Name == cmbAccounts.SelectedItem.ToString());
                userExcelFullAccount = (ExcelAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID, selectedAccount.Owner);
                cmbTokens.Items.Clear();
                cmbTokens.Text = String.Empty;
                panelSelectFolderForFiles.Show();
                pathToFolder = userExcelFullAccount.GetPathToCurrentFolderForUserFromConfigFile(new AuthorizationResult(true, loggedUser));
                if (!String.IsNullOrEmpty(pathToFolder))
                {
                    txtCurrentFolder.Text = pathToFolder;
                    panelSelectFolderForFiles.Show();
                }

                foreach (var item in userExcelFullAccount.Tokens)
                {
                    cmbTokens.Items.Add(item.TokenName);
                }
            }
            else if (cmbAccounts.SelectedItem != null && dataGrid_mapping.Rows.Count > 1)
            {
                FillDataGridWithExistingMapping();
            }
        }

        private void RefreshMapSetting()
        {
            dataGrid_mapping.DataSource = null;
            dataGrid_mapping.SelectAll();
            dataGrid_mapping.ClearSelection();
            comboBox_ExcelTemplate.Items.Clear();

            IAccountSettings result = userExcelAccounts.SingleOrDefault(x => x.Name == cmbAccounts.SelectedItem.ToString());
            if (SettingsManager.GetDetailsForAccount(loggedUser, result.ID) != null)
            {
                userExcelFullAccount = (ExcelAccountSettings)SettingsManager.GetDetailsForAccount(loggedUser, result.ID);
            }

            if (userExcelFullAccount.Template.Count > 0)
            {
                comboBox_ExcelTemplate.Items.Add(userExcelFullAccount.Template.First().TemplateName);
            }
        }

        private void btnNewAccountForExcel_Click(object sender, EventArgs e)
        {
            panelNewAccount.Visible = true;
            textBox_NameNewAccountExcel.Text = String.Empty;
            newAccountSetting = new ExcelAccountSettings();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            String newNameAccount = textBox_NameNewAccountExcel.Text.Trim();
            label1.Text = "Please enter new account name";
            label1.ForeColor = Color.Black;
            if (newNameAccount != String.Empty)
            {
                if (CheckNewAccountNameAlreadyExist(newNameAccount))
                {
                    label1.Text = "Name already exist. Please enter new name";
                    label1.ForeColor = Color.Red;
                }
                else
                {
                    newAccountSetting.Name = newNameAccount;
                    newAccountSetting.Template = new List<ExcelAccountTemplate>();
                    newAccountSetting.Tokens = new List<ExcelAccountToken>();
                    if (loggedUser.CreateNewAccount(newAccountSetting))
                    {
                        RefreshSettingsAccountList();
                        panelNewAccount.Hide();
                    }
                    else
                    {
                        label1.Text = "Please try again";
                        label1.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                label1.Text = "Name can not be empty string";
                label1.ForeColor = Color.Red;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            panelNewAccount.Visible = false;
        }

        private void btn_delete_account_Click(object sender, EventArgs e)
        {
            String selectedAccountName;
            if (cmbAccounts.SelectedItem != null && (cmbAccounts.SelectedItem.ToString() == userExcelFullAccount.Name))
            {
                selectedAccountName = cmbAccounts.SelectedItem.ToString();
            }
            else if (comboBox_shared.SelectedItem != null && (comboBox_shared.SelectedItem.ToString() == userExcelFullAccount.Name))
            {
                selectedAccountName = comboBox_shared.SelectedItem.ToString();
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
                    if (userExcelFullAccount.Owner)
                    {
                        if (DialogResult.Yes == MessageBox.Show(
                        String.Format("Delete this account for all users?", selectedAccountName), "Confirm", MessageBoxButtons.YesNo))
                        {
                            deleteResult = loggedUser.DeleteAccount(userExcelFullAccount, true);
                        }
                        else
                        {
                            deleteResult = loggedUser.DeleteAccount(userExcelFullAccount, false);
                        }
                    }
                    else
                    {
                        deleteResult = loggedUser.DeleteAccount(userExcelFullAccount, false);
                    }

                    if (deleteResult)
                    {
                        RefreshSettingsAccountList();
                    }
                    else
                    {
                        MessageBox.Show("Oops! Error. Try later");
                    }
                }
            }
        }

        private void btn_share_account_Click(object sender, EventArgs e)
        {
            groupBox_shared.Show();
        }

        private void comboBox_shared_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_shared.SelectedItem != null)
            {
                IAccountSettings selectedAccount = sharedUserExcelAccounts.FirstOrDefault(x => x.Name == comboBox_shared.SelectedItem.ToString());
                userExcelFullAccount = (ExcelAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID, selectedAccount.Owner);
                cmbTokens.Text = String.Empty;

                if (userExcelFullAccount != null)
                {
                    cmbTokens.Items.Clear();
                    foreach (var item in userExcelFullAccount.Tokens)
                    {
                        cmbTokens.Items.Add(item.TokenName);
                    }
                    btn_delete_account.Enabled = true;
                    groupBoxTokens.Show();
                    MakeFormReadOnly();
                    comboBox_ExcelTemplate.Items.Clear();
                    if (userExcelFullAccount.Template.Count > 0)
                    {
                        comboBox_ExcelTemplate.Items.Add(userExcelFullAccount.Template.First().TemplateName);
                    }
                }
            }
        }
        #endregion

        #region Shared user

        private void btnSaveSharedAccount_Click(object sender, EventArgs e)
        {
            String shareUserName = txtShareUserName.Text.Trim();
            if (shareUserName != String.Empty && shareUserName != loggedUser.UserLogin)
            {
                Boolean result = loggedUser.ShareTheSettingAccount(userExcelFullAccount, shareUserName, chboxMakeUserOwner.Checked);
                if (result)
                {
                    RefreshSettingsAccountList();
                    groupBox_shared.Hide();
                }
                else
                {
                    lblSharedAccountError.Text = "Please, try later";
                    lblSharedAccountError.Show();
                }
            }
            else
            {
                lblSharedAccountError.Text = "Invalid user name!";
                lblSharedAccountError.Show();
            }
        }

        private void btnCancelSaveShareAccount_Click(object sender, EventArgs e)
        {
            groupBox_shared.Hide();
        }

        #endregion

        private Boolean CheckNewAccountNameAlreadyExist(String name)
        {
            IAccountSettings account = userExcelAccounts.Select(x => x).Where(acc => acc.Name == name).SingleOrDefault();
            if (account != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RefreshSettingsAccountList()
        {
            List<IAccountSettings> userAllAccounts = loggedUser.GetAllUserAccounts();
            sharedUserExcelAccounts = loggedUser.GetAllSharedUserAccounts();
            userExcelAccounts = SettingsManager.GetAllUserAccountsInSource(userAllAccounts, Sources.Excel);
            sharedUserExcelAccounts = SettingsManager.GetAllUserAccountsInSource(sharedUserExcelAccounts, Sources.Excel);
            panelSelectFolderForFiles.Hide();
            cmbAccounts.Items.Clear();
            foreach (var item in userExcelAccounts)
            {
                cmbAccounts.Items.Add(item.Name);
            }
            comboBox_shared.Items.Clear();
            if (sharedUserExcelAccounts.Count > 0)
            {
                comboBox_shared.Show();
                foreach (var item in sharedUserExcelAccounts)
                {
                    comboBox_shared.Items.Add(item.Name);
                }
            }
            else
            {
                comboBox_shared.Hide();
            }
        }

        #region Tokens

        private void cmbTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTokens.SelectedItem != null && dataGrid_mapping.RowCount > 1)
            {
                FillDataGridWithExistingMapping();
            }
            grpBox_Connect_setting.Visible = true;
        }


        // Добавление Excel через OpenFileDialog
        private void btnAddToken_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = "*.xlsx";
            openFileDialog.Filter = "File Excel (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Add_NewTokens(openFileDialog.SafeFileName);
            }
        }

        // Добавление нового токена
        private void Add_NewTokens(string path)
        {
            if (Check_FreshToken(path))
            {
                newToken = new ExcelAccountToken();
                newToken.TokenName = path;
                userExcelFullAccount.Tokens.Add(newToken);
                if (SettingsManager.SaveOrUpdateAccount(userExcelFullAccount))
                {
                    MessageBox.Show("Succesfully!!");
                    ReloadAllSettingFromDB();
                }
                else
                {
                    MessageBox.Show("Error!!");
                }
            }
            else
                MessageBox.Show("This file here!!");
        }

        private void ReloadAllSettingFromDB()
        {
            List<IAccountSettings> allAccounts = loggedUser.GetAllUserAccounts();
            List<IAccountSettings> allShareAccounts = loggedUser.GetAllSharedUserAccounts();
            userExcelAccounts = SettingsManager.GetAllUserAccountsInSource(allAccounts, Sources.Excel);
            sharedUserExcelAccounts = SettingsManager.GetAllUserAccountsInSource(allAccounts, Sources.Excel);
            if (cmbAccounts.SelectedItem != null)
            {
                GetSelectedAccountAndFillTokensToControl();
            }
        }

        // Проверка на существование такого же токена в базе
        private Boolean Check_FreshToken(string path_token)
        {
            if (userExcelFullAccount.Tokens.Count != 0)
            {
                for (int i = 0; i < userExcelFullAccount.Tokens.Count; i++)
                {
                    if (userExcelFullAccount.Tokens[i].TokenName == path_token)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnDeleteToken_Click(object sender, EventArgs e)
        {
            if (cmbTokens.SelectedItem != null)
            {
                if (DialogResult.Yes == MessageBox.Show(
                    String.Format("Delete this token: {0}", cmbTokens.SelectedItem.ToString()), "Confirm", MessageBoxButtons.YesNo))
                {
                    IAccountToken tokenToDelete = userExcelFullAccount.Tokens.SingleOrDefault(x => x.TokenName == cmbTokens.SelectedItem.ToString());
                    if (tokenToDelete != null)
                    {
                        Boolean result = SettingsManager.DeleteToken(tokenToDelete);
                        if (result)
                        {
                            UpdateExcelSettingForm();
                            ReloadAllSettingFromDB();
                        }
                    }
                }
            }
        }

        private void cmbTokens_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void cmbTokens_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false); // путь к файлу
            foreach (string file in files)
            {
                FileInfo fileInf = new FileInfo(file);
                if (fileInf.Extension == ".xls" || fileInf.Extension == ".xlsx")
                    Add_NewTokens(file);
                else
                    MessageBox.Show("Drag'Drop file with extension \".xls \" - \".xlsx\" ");

                GetSelectedAccountAndFillTokensToControl();
            }
        }

        #endregion

        #region Connections settings
        private void comboBox_ExcelTemplate_DragDrop(object sender, DragEventArgs e)
        {
            bool pp = false;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false); // путь к файлу

            foreach (var item in comboBox_ExcelTemplate.Items)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (item.ToString() == files[i])
                        pp = true;
                }
            }

            if (!pp)
            {
                foreach (string file in files)
                {
                    comboBox_ExcelTemplate.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
                }
            }

            if (comboBox_ExcelTemplate.Items != null)
                comboBox_ExcelTemplate.SelectedValue = files[0];
        }

        #endregion

        #region Template

        private void btn_AddNewExcelTemplate_Click(object sender, EventArgs e)
        {
            if (cmbTokens.SelectedItem != null && dataGrid_mapping.Rows.Count == 1)
            {
                btn_delete_template.Visible = true;
                FillDataGridWithExistingMapping();
            }
        }

        private void btn_delete_template_Click(object sender, EventArgs e)
        {
            if (comboBox_ExcelTemplate.SelectedItem != null)
            {
                ExcelAccountTemplate templateToDelete = userExcelFullAccount.Template.FirstOrDefault();
                if (templateToDelete != null)
                {
                    if (SettingsManager.DeleteTemplate(templateToDelete))
                    {
                        RefreshMapSetting();
                        comboBox_ExcelTemplate.Text = "";

                        btn_AddNewExcelTemplate.Enabled = true;
                        btn_delete_template.Enabled = false;
                    }
                }


                dataGrid_mapping.RowCount = 1;
                dataGrid_mapping.Rows[0].Visible = true;  //не обязательно (если в datagridview не скрывается срока)
                for (int i = 0; i < dataGrid_mapping.ColumnCount; i++)
                {
                    dataGrid_mapping[i, 0].Value = null;
                }
            }
        }

        private void comboBox_ExcelTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_ExcelTemplate.SelectedItem != null && dataGrid_mapping.Rows.Count == 1)
            {
                btn_delete_template.Visible = true;
                if (userExcelFullAccount.Template.First() != null)
                {
                    FillDataGridWithExistingMapping();
                    btn_saveMapping.Enabled = false;
                    btnSaveSettings.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Template Empty!!!");
                }
            }
        }

        private void FillDataGridWithExistingMapping()
        {
            Dictionary<String, String> templateMapping = new Dictionary<String, String>();
            ExcelAccountTemplate template = userExcelFullAccount.Template.FirstOrDefault();
            if (template == null)
            {
                template = new ExcelAccountTemplate();
                FillDataGridWithEmptyMapping(template.AllFieldsInTeemplate);
                return;
            }

            templateMapping = userExcelFullAccount.Template.FirstOrDefault().Mapping;
            List<string> field = templateMapping.Values.Select(value => value).Where(str => !String.IsNullOrEmpty(str)).ToList();

            for (int i = 0; i < templateMapping.Count; i++)
            {
                if (dataGrid_mapping.Rows.Count < templateMapping.Count)
                {
                    dataGrid_mapping.Rows.Add();
                }
                DataGridViewTextBoxCell Cell_Template =
                        (DataGridViewTextBoxCell)dataGrid_mapping.Rows[i].Cells[1];
                Cell_Template.Value = templateMapping.ElementAt(i).Key;

                if (templateMapping.Count > 0)
                {
                    DataGridViewComboBoxCell comboCell_ITask = (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[0];
                    comboCell_ITask.DataSource = field;
                    comboCell_ITask.Value = templateMapping.ElementAt(i).Value;
                }
                else
                {
                    DataGridViewComboBoxCell comboCell_ITask = (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[0];
                    comboCell_ITask.DataSource = field;
                    comboCell_ITask.Value = "";

                }
            }

        }

        private void FillDataGridWithEmptyMapping(List<String> allFieldsInTeemplate)
        {
            Dictionary<String, String> templateMapping = new Dictionary<String, String>();
            ExcelAccountSettings settingAccount;
            List<String> field = Import(cmbTokens.SelectedItem.ToString(), out settingAccount);
            if (settingAccount == null)
            {
                MessageBox.Show("Please select at least one file!");
                return;
            }
            templateMapping = settingAccount.Template.First<ExcelAccountTemplate>().Mapping;
            for (int i = 0; i < templateMapping.Count; i++)
            {
                if (dataGrid_mapping.Rows.Count < templateMapping.Count)
                {
                    dataGrid_mapping.Rows.Add();
                }
                DataGridViewTextBoxCell Cell_Template =
                        (DataGridViewTextBoxCell)dataGrid_mapping.Rows[i].Cells[1];
                Cell_Template.Value = templateMapping.ElementAt(i).Key;

                DataGridViewComboBoxCell comboCell_ITask = (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[0];
                comboCell_ITask.DataSource = field;
                comboCell_ITask.Value = "";
            }
        }

        private List<String> Import(string file, out ExcelAccountSettings result)
        {
            IAccountSettings setingForTest;
            ExcelAccountSettings testAcc = new ExcelAccountSettings();
            Byte[] fileInByteArray = testAcc.OpenExcelFileAndReturnByteArray(new AuthorizationResult(true, loggedUser), file);
            if (fileInByteArray == null)
            {
                result = null;
                return null;
            }
            SettingsManager.AccountSettingsTest(testAcc, fileInByteArray, out setingForTest);
            if (setingForTest != null)
            {
                ExcelAccountSettings resultFromServices = (ExcelAccountSettings)setingForTest;
                ExcelAccountTemplate template = new ExcelAccountTemplate();
                template = resultFromServices.Template.FirstOrDefault();
                result = (ExcelAccountSettings)setingForTest;
                return template.AllFieldsInFile;
            }
            result = null; ;
            return null;
        }


        private void dataGrid_mapping_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_saveMapping.Enabled = true;
        }

        private void btn_cancelMapping_Click(object sender, EventArgs e)
        {
            comboBox_ExcelTemplate.Text = "";
            dataGrid_mapping.Rows.Clear();
            grpBox_Connect_setting.Hide();
            groupBoxTokens.Hide();
            panelSelectFolderForFiles.Hide();
            cmbAccounts.Text = "";
        }

        private void btn_saveMapping_Click(object sender, EventArgs e)
        {
            ExcelTab.SelectTab(Mapping);
            Write_RichTextBox();
            btnChekMapping.Enabled = true;
        }

        private void Write_RichTextBox()
        {
            rtxtMapping.Text = "";
            for (int i = 0; i <= dataGrid_mapping.Rows.Count - 1; i++)
            {
                DataGridViewComboBoxCell comboCell_file =
                        (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[0]; // столбик file-Excel

                DataGridViewTextBoxCell comboCell_ITask =
                    (DataGridViewTextBoxCell)dataGrid_mapping.Rows[i].Cells[1];  // столбик Template
                                                                                 // --------------------------------------------------------------------------------------


                if (comboCell_file.Value == null || comboCell_file.Value.ToString() == "")
                {
                    rtxtMapping.Text += "#### - " + comboCell_ITask.Value + "\n";
                }
                else
                    rtxtMapping.Text += comboCell_file.Value + " - " + comboCell_ITask.Value + "\n";
            }

        }

        #endregion

        private void UpdateExcelSettingForm()
        {
            grpBox_Connect_setting.Hide();
            GetSelectedAccountAndFillTokensToControl();
        }

        #region Tab-Mapping

        private void btnChekMapping_Click(object sender, EventArgs e)
        {
            IAccountSettings testAccRessult;
            ExcelAccountSettings testAcc = new ExcelAccountSettings();
            ExcelAccountTemplate accEx_template = new ExcelAccountTemplate();

            accEx_template = Acc_ExcelMapping();
            accEx_template.TemplateName = txtNewTemplateName.Text.Trim();

            testAcc.Template.Add(accEx_template);
            if (SettingsManager.AccountSettingsTest(testAcc, testAcc.OpenExcelFileAndReturnByteArray(new AuthorizationResult(true, loggedUser),
                cmbTokens.SelectedItem.ToString()), out testAccRessult))
            {
                btnSaveSettings.Enabled = true;
                label5.Hide();
            }
            else
            {
                btnSaveSettings.Enabled = false;
                label5.Show();
                label5.Text = "Cant read from file!";
                label5.ForeColor = Color.Red;
            }
        }


        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (txtNewTemplateName.Text.Trim() != String.Empty && rtxtMapping.Text.Trim() != String.Empty)
            {
                ExcelAccountTemplate accEx_template = new ExcelAccountTemplate();

                accEx_template = Acc_ExcelMapping();
                accEx_template.TemplateName = txtNewTemplateName.Text.Trim();

                userExcelFullAccount.Template.Add(accEx_template);
                if (SettingsManager.SaveOrUpdateAccount(userExcelFullAccount))
                {
                    ExcelTab.SelectTab(Settings);
                    RefreshMapSetting();
                    btn_AddNewExcelTemplate.Enabled = false;
                    btn_delete_template.Enabled = true;

                    dataGrid_mapping.RowCount = 1;
                    dataGrid_mapping.Rows[0].Visible = true;  //не обязательно (если в datagridview не скрывается срока)
                    for (int i = 0; i < dataGrid_mapping.ColumnCount; i++)
                    {
                        dataGrid_mapping[i, 0].Value = null;
                    }
                }
            }
            else
            {
                label5.Show();
                label5.Text = "Please enter token name and mapping!";
                label5.ForeColor = Color.Red;
            }
        }

        private ExcelAccountTemplate Acc_ExcelMapping()
        {
            ExcelAccountTemplate accEx_template;
            if (userExcelFullAccount.Template.Count > 0)
            {
                accEx_template = userExcelFullAccount.Template.FirstOrDefault();
            }
            else
            {
                accEx_template = new ExcelAccountTemplate();
            }

            for (int i = 0; i < dataGrid_mapping.Rows.Count - 1; i++)
            {
                DataGridViewComboBoxCell comboCell_file =
                        (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[0];
                DataGridViewTextBoxCell combotxtCell =
                       (DataGridViewTextBoxCell)dataGrid_mapping.Rows[i].Cells[1];
                String cellValue = comboCell_file.Value.ToString();
                String fieldValue = combotxtCell.Value.ToString();
                cellValue = cellValue ?? "";

                if (fieldValue == "TaskID")
                {
                    accEx_template.TaskID = cellValue;
                    continue;
                }
                if (fieldValue == "SubtaskType")
                {
                    accEx_template.SubtaskType = cellValue;
                    continue;
                }
                if (fieldValue == "Summary")
                {
                    accEx_template.Summary = cellValue;
                    continue;
                }
                if (fieldValue == "Description")
                {
                    accEx_template.Description = cellValue;
                    continue;
                }
                if (fieldValue == "Status")
                {
                    accEx_template.Status = cellValue;
                    continue;
                }
                if (fieldValue == "Priority")
                {
                    accEx_template.Priority = cellValue;
                    continue;
                }
                if (fieldValue == "Project")
                {
                    accEx_template.Project = cellValue;
                    continue;
                }
                if (fieldValue == "CreatedDate")
                {
                    accEx_template.CreatedDate = cellValue;
                    continue;
                }
                if (fieldValue == "CreatedBy")
                {
                    accEx_template.CreatedBy = cellValue;
                    continue;
                }
                if (fieldValue == "LinkToTracker")
                {
                    accEx_template.LinkToTracker = Sources.Excel;
                    continue;
                }
                if (fieldValue == "Estimation")
                {
                    accEx_template.Estimation = cellValue;
                    continue;
                }
                if (fieldValue == "TargetVersion")
                {
                    accEx_template.TargetVersion = cellValue;
                    continue;
                }
                if (fieldValue == "Comments")
                {
                    accEx_template.Comments = cellValue;
                    continue;
                }
                if (fieldValue == "TaskParent")
                {
                    accEx_template.TaskParent = cellValue;
                    continue;
                }
                if (fieldValue == "Assigned")
                {
                    accEx_template.Assigned = cellValue;
                    continue;
                }
            }
            return accEx_template;
        }

    private void btnCancelSaveNewToken_Click(object sender, EventArgs e)
    {
        ExcelTab.SelectTab(Settings);
    }

    #endregion

    private void clearFieldToolStripMenuItem_Click(object sender, EventArgs e)
    {
        int index = dataGrid_mapping.CurrentCell.RowIndex;
        dataGrid_mapping.Rows[dataGrid_mapping.CurrentRow.Index].Cells[dataGrid_mapping.CurrentCell.ColumnIndex].Value = String.Empty;
        DataGridViewComboBoxCell comboCell_file =
                    (DataGridViewComboBoxCell)dataGrid_mapping.Rows[index].Cells[0];

        comboCell_file.Value = String.Empty;
        dataGrid_mapping.Refresh();
    }

    private void grpBox_Connect_setting_VisibleChanged(object sender, EventArgs e)
    {
        if (grpBox_Connect_setting.Visible == true)
        {
            if (comboBox_ExcelTemplate.Items.Count == 0 || !userExcelFullAccount.Owner)
            {
                btn_delete_template.Enabled = false;
            }
            else
            {
                btn_AddNewExcelTemplate.Enabled = false;
            }
        }
    }

    private void btnSelectFolder_Click(object sender, EventArgs e)
    {
        if (DialogResult.OK == folderBrouseForSync.ShowDialog())
        {
            ExcelSynchronizer.ChangeFolderForSync(folderBrouseForSync.SelectedPath, new AuthorizationResult(true, loggedUser));
            MessageBox.Show("New settings will apply after rerun application!");
        }
    }
}

}
