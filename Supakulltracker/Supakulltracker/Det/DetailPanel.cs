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

namespace Supakulltracker
{
    public partial class DetailPanel : UserControl
    {
        private static  Dictionary<String, String> test = new Dictionary<String, String>();
        public DetailPanel()
        {
            InitializeComponent();
        }

        private void DetailsPanel_Load(object sender, EventArgs e)
        {

        }
        internal void Fill(TaskMainDTO task)
        {
            this.textBoxTaskID.Text = task.TaskID;
            this.textBoxSubtaskType.Text = task.SubtaskType;
            this.textBoxSummary.Text = task.Summary;
            this.textBoxDescription.Text = task.Description;
            this.textBoxStatus.Text = task.Status;
            this.textBoxPriority.Text = task.Priority;
            this.textBoxProduct.Text = task.Product;
            this.textBoxProject.Text = task.Project;
            this.textBoxCreatedDate.Text = task.CreatedDate;
            this.textBoxCreatedBy.Text = task.CreatedBy;
            this.linkLabelLinkToTracker.Text = task.LinkToTracker;
            this.linkLabelLinkToTracker.Links.Add(0, 50, linkLabelLinkToTracker.Text);
            this.textBoxEstimation.Text = task.Estimation;
            this.textBoxTargetVersion.Text = task.TargetVersion;
            this.textBoxComments.Text = task.Comments;
            this.textBoxAssigned.Text = task.Assigned.ToString();
        }

        private void textBoxEstimation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(test);
            PopUp.ShowDialog();
        }

        private void textBoxTargetVersion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(test);
            PopUp.ShowDialog();
        }

        private void textBoxPriority_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(test);
            PopUp.ShowDialog();
        }

        private void textBoxStatus_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(test);
            PopUp.ShowDialog();
        }

        private void textBoxProject_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(test);
            PopUp.ShowDialog();
        }

        private void textBoxSubtaskType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(test);
            PopUp.ShowDialog();
        }

        private void textBoxProduct_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(test);
            PopUp.ShowDialog();
        }

        private void linkLabelLinkToTracker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
