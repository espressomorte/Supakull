using Supakulltracker.UserProvider;
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
    public partial class MainForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AuthorizationResult AuthorizationResult { get; private set; }
        private ExcelSynchronizer excelSynchronizer;

        public MainForm()
        {
            InitializeComponent();
            AuthorizationResult = new AuthorizationResult();
        }

        private void StartApplication_Load(object sender, EventArgs e)
        {
            IAuthorizer authorizer = new Authorizer();
            LoginProviderWinForm loginProvider = new LoginProviderWinForm(authorizer);

            AuthorizationResult = loginProvider.Login();
            if (AuthorizationResult.Authorized)
            {
                PrepareApplication();
            }
            else
            {
                Application.Exit();
            }
        }

        private void PrepareApplication()
        {
            IssueService.GetTrackerServicesSoapClient trackerServices = new IssueService.GetTrackerServicesSoapClient();
            IssueService.TaskMainDTO[] tasks = trackerServices.GetAllTasks();
            searchControl.Tasks = tasks;
            excelSynchronizer = new ExcelSynchronizer(AuthorizationResult);

        }

        private void Board_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SuperTask superTask = SuperTask.GetSuperTask(searchControl.Tasks[e.RowIndex]);
            CreateNewTab(superTask.TaskID, superTask);
        }

        private void CreateNewTab(string title, SuperTask superTask)
        {
            TabPage newTabPage = new TabPage(title);
            var detail = new DetailPanel();
            detail.Dock = DockStyle.Fill;
            detail.Bind(superTask);
            newTabPage.Controls.Add(detail);
            taskDetailTabControl.TabPages.Add(newTabPage);
            taskDetailTabControl.SelectTab(taskDetailTabControl.TabCount - 1);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog setingDialog = new SettingsDialog(AuthorizationResult.AuthorizedUser);
            setingDialog.ShowDialog();
        }


        private async void btnUdateAllTasks_Click(object sender, EventArgs e)
        {
            IssueService.GetTrackerServicesSoapClient trackerServices = new IssueService.GetTrackerServicesSoapClient();
            await trackerServices.UpdateAsync();
            IssueService.TaskMainDTO[] tasks = trackerServices.GetAllTasks();
            searchControl.Tasks = tasks;
        }

        private async void generateIndexesForSearchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateIndexesForm generateIndexesForm = new GenerateIndexesForm();
            DialogResult dialogResult = generateIndexesForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                IssueService.GetTrackerServicesSoapClient trackerServices = new IssueService.GetTrackerServicesSoapClient();
                await trackerServices.GenerateIndexesAsync();
            }
        }
    }
}
