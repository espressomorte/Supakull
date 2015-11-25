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
            this.linkLabelLinkToTracker.Text = task.LinkToTracker.ToString();
            this.textBoxEstimation.Text = task.Estimation;
            this.textBoxTargetVersion.Text = task.TargetVersion;
            this.textBoxComments.Text = task.Comments;
            this.textBoxAssigned.Text = task.Assigned.ToString();
        }

        internal void Fill(SuperTask superTask)
        {
            this.textBoxTaskID.DataBindings.Add("Text", superTask, nameof(superTask.TaskID));
            this.textBoxSubtaskType.DataBindings.Add("Text", superTask, nameof(superTask.SubtaskType));
            this.textBoxSummary.DataBindings.Add("Text", superTask, nameof(superTask.Summary));
            this.textBoxDescription.DataBindings.Add("Text", superTask, nameof(superTask.Description));
            this.textBoxStatus.DataBindings.Add("Text", superTask, nameof(superTask.Status));
            this.textBoxPriority.DataBindings.Add("Text", superTask, nameof(superTask.Priority));
            this.textBoxProject.DataBindings.Add("Text", superTask, nameof(superTask.Project));
            this.textBoxCreatedDate.DataBindings.Add("Text", superTask, nameof(superTask.CreatedDate));
            this.textBoxCreatedBy.DataBindings.Add("Text", superTask, nameof(superTask.CreatedBy));
            this.linkLabelLinkToTracker.DataBindings.Add("Text", superTask, nameof(superTask.LinkToTracker));
            this.textBoxEstimation.DataBindings.Add("Text", superTask, nameof(superTask.Estimation));
            this.textBoxTargetVersion.DataBindings.Add("Text", superTask, nameof(superTask.TargetVersion));
            this.textBoxComments.DataBindings.Add("Text", superTask, nameof(superTask.Comments));
            this.textBoxAssigned.DataBindings.Add("Text", superTask, nameof(superTask.Assigned));
        }

    }
}
