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
        private ExcelAccountToken newToken = new ExcelAccountToken();

        private string[] array = { "TaskID", "SubtaskType", "Summary", "Description",
                "Status","Priority","Project", "CreatedDate", "CreatedBy", "LinkToTracker",
                "Estimation", "TargetVersion","Comments","Assigned","TaskParent" };

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
                RefreshMapSetting();
            }
        }

        private void GetSelectedAccountAndFillTokensToControl()
        {
            if (cmbAccounts.SelectedItem != null && dataGrid_mapping.Rows.Count == 1)
            {
                IAccountSettings selectedAccount = userExcelAccounts.FirstOrDefault(x => x.Name == cmbAccounts.SelectedItem.ToString());
                userExcelFullAccount = (ExcelAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID);
                userExcelFullAccount.Owner = true;
                cmbTokens.Items.Clear();
                cmbTokens.Text = String.Empty;

                foreach (var item in userExcelFullAccount.Tokens)
                {
                    cmbTokens.Items.Add(item.TokenName);
                }
            }
            else if (cmbAccounts.SelectedItem != null && dataGrid_mapping.Rows.Count > 1)
            {
                Write_DataInFile();
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
                cmbAccounts.SelectedItem = null;
                IAccountSettings selectedAccount = sharedUserExcelAccounts.FirstOrDefault(x => x.Name == comboBox_shared.SelectedItem.ToString());
                userExcelFullAccount = (ExcelAccountSettings)loggedUser.GetDetailsForAccount(selectedAccount.ID);
                userExcelFullAccount.Owner = false;
                cmbTokens.Text = String.Empty;

                if (userExcelFullAccount != null)
                {
                    cmbTokens.Items.Clear();
                    foreach (var item in userExcelFullAccount.Tokens)
                    {
                        cmbTokens.Items.Add(item.TokenName);
                    }
                    btn_delete_account.Enabled = true;
                }
                comboBox_shared.Enabled = false;
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
            if (cmbAccounts.SelectedItem != null && dataGrid_mapping.Rows.Count > 1)
            {
                Write_DataInFile(dataGrid_mapping.Rows.Count);
            }
            grpBox_Connect_setting.Visible = true;
        }

        private void Write_DataInFile(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                List<string> listFile = Import(cmbTokens.SelectedItem.ToString());

                DataGridViewComboBoxCell comboCell_file =
                        (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[0]; // данные file Excel

                comboCell_file.DataSource = listFile;
                comboCell_file.Value = ""; //  listFile[0];
            }
        }

        // Добавление Excel через OpenFileDialog
        private void btnAddToken_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = "*.xlsx";
            openFileDialog.Filter = "File Excel (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Add_NewTokens(openFileDialog.FileName);
            }
        }

        // Добавление нового токена
        private void Add_NewTokens(string path)
        {
            if (Check_FreshToken(path))
            {
                // newToken = new ExcelAccountToken();
                newToken.TokenName = path;
                userExcelFullAccount.Tokens.Add(newToken);
                if (SettingsManager.SaveOrUpdateAccount(userExcelFullAccount))
                {
                    MessageBox.Show("Succesfully!!");
                    GetSelectedAccountAndFillTokensToControl();
                }
                else
                {
                    MessageBox.Show("Error!!");
                }
            }
            else
                MessageBox.Show("This file here!!");
        }

        // Проверка на существование такого же токена в базе
        private Boolean Check_FreshToken(string path_token)
        {
            IAccountSettings result = userExcelAccounts.SingleOrDefault(x => x.Name == cmbAccounts.SelectedItem.ToString());
            if (SettingsManager.GetDetailsForAccount(loggedUser, result.ID) != null)
            {
                userExcelFullAccount = (ExcelAccountSettings)SettingsManager.GetDetailsForAccount(loggedUser, result.ID);
            }

            if (userExcelFullAccount.Tokens.Count != 0)
            {
                for (int i = 0; i < userExcelFullAccount.Tokens.Count; i++)
                {
                    if (userExcelFullAccount.Tokens[i].Token == path_token)
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
                Write_DataInITask();
                Write_DataInFile();
            }
        }

        private void btn_delete_template_Click(object sender, EventArgs e)
        {
            if (comboBox_ExcelTemplate.SelectedItem != null)
            {
                IAccountSettings result = userExcelAccounts.SingleOrDefault(x => x.Name == cmbAccounts.SelectedItem.ToString());
                if (SettingsManager.GetDetailsForAccount(loggedUser, result.ID) != null)
                {
                    userExcelFullAccount = (ExcelAccountSettings)SettingsManager.GetDetailsForAccount(loggedUser, result.ID);
                }
                userExcelFullAccount.Template.RemoveAt(comboBox_ExcelTemplate.SelectedIndex);
                if (SettingsManager.SaveOrUpdateAccount(userExcelFullAccount))
                {
                    RefreshMapSetting();
                    comboBox_ExcelTemplate.Text = "";

                    btn_AddNewExcelTemplate.Enabled = true;
                    btn_delete_template.Enabled = false;
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
                List<string> field = new List<string>();

                if (userExcelFullAccount.Template.First() != null)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        field = Switch_obj(i, field);
                    }

                    for (int i = 0; i < field.Count; i++)
                    {
                        dataGrid_mapping.Rows.Add();
                        DataGridViewTextBoxCell Cell_Template =
                                (DataGridViewTextBoxCell)dataGrid_mapping.Rows[i].Cells[1];
                        Cell_Template.Value = field[i];
                    }
                }
                else
                {
                    MessageBox.Show("Template Empty!!!");
                }
            }
        }

        private List<string> Switch_obj(int index, List<string> field)
        {
            //DataGridViewTextBoxCell Cell_Template =
            //        (DataGridViewTextBoxCell)dataGrid_mapping.Rows[index].Cells[1];
            //Cell_Template.ReadOnly = true;

            switch (index)
            {
                case 0:
                    if (userExcelFullAccount.Template.First().TaskID != null)
                    {
                        // dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().TaskID;
                        field.Add(userExcelFullAccount.Template.First().TaskID);
                    }
                    break;
                case 1:
                    if (userExcelFullAccount.Template.First().SubtaskType != null)
                    {
                        //dataGrid_mapping.Rows.Add();
                        //Cell_Template.Value = userExcelFullAccount.Template.First().SubtaskType;
                        field.Add(userExcelFullAccount.Template.First().SubtaskType);
                    }
                    break;
                case 2:
                    if (userExcelFullAccount.Template.First().Summary != null)
                    {
                        //dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().Summary;
                        field.Add(userExcelFullAccount.Template.First().Summary);
                    }
                    break;
                case 3:
                    if (userExcelFullAccount.Template.First().Description != null)
                    {
                        //dataGrid_mapping.Rows.Add();
                        //Cell_Template.Value = userExcelFullAccount.Template.First().Description;
                        field.Add(userExcelFullAccount.Template.First().Description);
                    }
                    break;
                case 4:
                    if (userExcelFullAccount.Template.First().Status != null)
                    {
                        //dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().Status;
                        field.Add(userExcelFullAccount.Template.First().Status);
                    }
                    break;
                case 6:
                    if (userExcelFullAccount.Template.First().Priority != null)
                    {
                        //dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().Priority;
                        field.Add(userExcelFullAccount.Template.First().Priority);
                    }
                    break;
                case 7:
                    if (userExcelFullAccount.Template.First().Product != null)
                    {
                        //dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().Product;
                        field.Add(userExcelFullAccount.Template.First().Product);
                    }
                    break;
                case 8:
                    if (userExcelFullAccount.Template.First().Project != null)
                    {
                        // dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().Project;
                        field.Add(userExcelFullAccount.Template.First().Project);
                    }
                    break;
                case 9:
                    if (userExcelFullAccount.Template.First().CreatedDate != null)
                    {
                        //dataGrid_mapping.Rows.Add();
                        //Cell_Template.Value = userExcelFullAccount.Template.First().CreatedDate;
                        field.Add(userExcelFullAccount.Template.First().CreatedDate);
                    }
                    break;
                case 11:
                    if (userExcelFullAccount.Template.First().CreatedBy != null)
                    {
                        //dataGrid_mapping.Rows.Add();
                        //Cell_Template.Value = userExcelFullAccount.Template.First().CreatedBy;
                        field.Add(userExcelFullAccount.Template.First().CreatedBy);
                    }
                    break;
                case 12:
                    if (userExcelFullAccount.Template.First().LinkToTracker.ToString() != null)
                    {
                        //  dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().LinkToTracker;
                        field.Add(userExcelFullAccount.Template.First().LinkToTracker.ToString());
                    }
                    break;
                case 13:
                    if (userExcelFullAccount.Template.First().Estimation != null)
                    {
                        // dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().Estimation;
                        field.Add(userExcelFullAccount.Template.First().Estimation);
                    }
                    break;
                case 14:
                    if (userExcelFullAccount.Template.First().TargetVersion != null)
                    {
                        // dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().TargetVersion;
                        field.Add(userExcelFullAccount.Template.First().TargetVersion);
                    }
                    break;
                case 15:
                    if (userExcelFullAccount.Template.First().Comments != null)
                    {
                        // dataGrid_mapping.Rows.Add();
                        // Cell_Template.Value = userExcelFullAccount.Template.First().Comments;
                        field.Add(userExcelFullAccount.Template.First().Comments);
                    }
                    break;
            }
            return field;
        }

        private List<string> Import(string file)
        {
            List<string> listFile = new List<string>();
            try
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    using (var stream = File.OpenRead(file))
                    {
                        pck.Load(stream);
                    }

                    ExcelWorksheet ws = pck.Workbook.Worksheets.First();
                    listFile = WorksheetToDataTable(ws);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Import failed. Original error: " + ex.Message);
            }
            return listFile;
        }

        private List<string> WorksheetToDataTable(ExcelWorksheet ws)
        {
            List<string> listFile = new List<string>();
            DataTable dt = new DataTable(ws.Name);
            int totalCols = ws.Dimension.End.Column;
            int totalRows = ws.Dimension.End.Row;

            foreach (var firstRowCell in ws.Cells[1, 1, 1, totalCols])
            {
                listFile.Add(firstRowCell.Text);
            }
            return listFile;
        }

        private void Write_DataInITask()
        {
            for (int i = 0; i < array.Length - 1; i++)  // listFile.Count
            {
                dataGrid_mapping.Rows.Add();

                // ---------------------------------------------------------------------

                DataGridViewComboBoxCell comboCell_ITask =
           (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[1];  // данные ITask

                comboCell_ITask.DataSource = array;
                comboCell_ITask.Value = array[i];
            }
        }

        private void Write_DataInFile()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                List<string> listFile = Import(cmbTokens.SelectedItem.ToString());

                DataGridViewComboBoxCell comboCell_file =
                        (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[0]; // данные file Excel

                comboCell_file.DataSource = listFile;
                comboCell_file.Value = ""; //  listFile[0];
            }
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

            cmbAccounts.Text = "";
        }

        private void btn_saveMapping_Click(object sender, EventArgs e)
        {
            ExcelTab.SelectTab(Mapping);
            Write_RichTextBox();
        }

        private void Write_RichTextBox()
        {
            rtxtMapping.Text = "";
            for (int i = 0; i < dataGrid_mapping.Rows.Count - 1; i++)
            {
                DataGridViewComboBoxCell comboCell_file =
                        (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[0]; // столбик file-Excel

                DataGridViewComboBoxCell comboCell_ITask =
                    (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[1];  // столбик ITask
                                                                                  // --------------------------------------------------------------------------------------


                if (comboCell_file.Value.ToString() == "")
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
            ExcelAccountTemplate accEx_template = new ExcelAccountTemplate();

            for (int i = 0; i < dataGrid_mapping.Rows.Count - 1; i++)
            {
                DataGridViewComboBoxCell comboCell_file =
                        (DataGridViewComboBoxCell)dataGrid_mapping.Rows[i].Cells[0];


                if (accEx_template.TaskID == null)
                {
                    accEx_template.TaskID = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.SubtaskType == null)
                {
                    accEx_template.SubtaskType = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.Summary == null)
                {
                    accEx_template.Summary = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.Description == null)
                {
                    accEx_template.Description = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.Status == null)
                {
                    accEx_template.Status = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.Priority == null)
                {
                    accEx_template.Priority = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.Project == null)
                {
                    accEx_template.Project = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.CreatedDate == null)
                {
                    accEx_template.CreatedDate = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.CreatedBy == null)
                {
                    accEx_template.CreatedBy = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.LinkToTracker.ToString() == null)
                {
                    accEx_template.LinkToTracker = Sources.Excel;
                    continue;
                }
                if (accEx_template.Estimation == null)
                {
                    accEx_template.Estimation = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.TargetVersion == null)
                {
                    accEx_template.TargetVersion = comboCell_file.Value.ToString();
                    continue;
                }
                if (accEx_template.Comments == null)
                {
                    accEx_template.Comments = comboCell_file.Value.ToString();
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

        private void dataGrid_mapping_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(dataGrid_mapping.SelectedCells.Count.ToString());
        }

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
                if (comboBox_ExcelTemplate.Items.Count == 0)
                {
                    btn_delete_template.Enabled = false;
                }
                else
                {
                    btn_AddNewExcelTemplate.Enabled = false;
                }
            }
        }
    }

}
