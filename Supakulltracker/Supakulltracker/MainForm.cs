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
        IssueService.TaskMainDTO[] Tasks;
        public AuthorizationResult AuthorizationResult { get; private set; }


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
                PrepareApplicationAsync();
            }
            else
            {
                Application.Exit();
            }
        }

        private async void PrepareApplicationAsync()
        {
            IssueService.GetTrackerServicesSoapClient trackerServices = new IssueService.GetTrackerServicesSoapClient();
            //await trackerServices.UpdateAsync();
            Tasks = trackerServices.GetAllTasks();
            Board.DataSource = Tasks;
        }

        private void Board_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NewTab(e.RowIndex);
        }

        private void NewTab(int index)
        {
            IssueService.TaskMainDTO task = Tasks[index];
            string title = (task.TaskID).ToString();
            TabPage newTabPage = new TabPage(title);

            IssueService.GetTrackerServicesSoapClient service = new IssueService.GetTrackerServicesSoapClient();
            ICollection<IssueService.TaskMainDTO> matchedTasks = service.GetMatchedTasks(task.TaskID, task.LinkToTracker);
            SuperTask superTask = new SuperTask(matchedTasks);
            SuperTaskControl newSuperTaskControl = new SuperTaskControl(superTask);

            var detail = new DetailPanel();
            detail.Dock = DockStyle.Fill;
            detail.Fill(task);
            //newTabPage.Controls.Add(detail);
            newTabPage.Controls.Add(newSuperTaskControl);
            taskDetailTabControl.TabPages.Add(newTabPage);
            taskDetailTabControl.SelectTab(taskDetailTabControl.TabCount-1);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog setingDialog = new SettingsDialog(AuthorizationResult.AuthorizedUser);
            setingDialog.Show();
        }
    }
}
