using System;
using Supakulltracker.IssueService;

namespace Supakulltracker
{
    partial class DetailPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TaskIDlabel = new System.Windows.Forms.Label();
            this.textBoxTaskID = new System.Windows.Forms.TextBox();
            this.textBoxSubtaskType = new System.Windows.Forms.TextBox();
            this.labelSubtaskType = new System.Windows.Forms.Label();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            this.labelSummary = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxPriority = new System.Windows.Forms.TextBox();
            this.labelPriority = new System.Windows.Forms.Label();
            this.textBoxTargetVersion = new System.Windows.Forms.TextBox();
            this.labelTargetVersion = new System.Windows.Forms.Label();
            this.textBoxEstimation = new System.Windows.Forms.TextBox();
            this.labelEstimation = new System.Windows.Forms.Label();
            this.textBoxProject = new System.Windows.Forms.TextBox();
            this.labelProject = new System.Windows.Forms.Label();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.labelProduct = new System.Windows.Forms.Label();
            this.textBoxCreatedBy = new System.Windows.Forms.TextBox();
            this.labelCreatedBy = new System.Windows.Forms.Label();
            this.textBoxCreatedDate = new System.Windows.Forms.TextBox();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.linkLabelLinkToTracker = new System.Windows.Forms.LinkLabel();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.textBoxAssigned = new System.Windows.Forms.TextBox();
            this.labelAssigned = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TaskIDlabel
            // 
            this.TaskIDlabel.AutoSize = true;
            this.TaskIDlabel.Location = new System.Drawing.Point(11, 8);
            this.TaskIDlabel.Name = "TaskIDlabel";
            this.TaskIDlabel.Size = new System.Drawing.Size(42, 13);
            this.TaskIDlabel.TabIndex = 0;
            this.TaskIDlabel.Text = "TaskID";
            // 
            // textBoxTaskID
            // 
            this.textBoxTaskID.Location = new System.Drawing.Point(14, 24);
            this.textBoxTaskID.Name = "textBoxTaskID";
            this.textBoxTaskID.Size = new System.Drawing.Size(113, 20);
            this.textBoxTaskID.TabIndex = 1;
            // 
            // textBoxSubtaskType
            // 
            this.textBoxSubtaskType.Location = new System.Drawing.Point(148, 24);
            this.textBoxSubtaskType.Name = "textBoxSubtaskType";
            this.textBoxSubtaskType.Size = new System.Drawing.Size(113, 20);
            this.textBoxSubtaskType.TabIndex = 3;
            this.textBoxSubtaskType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxSubtaskType_MouseDoubleClick);
            // 
            // labelSubtaskType
            // 
            this.labelSubtaskType.AutoSize = true;
            this.labelSubtaskType.Location = new System.Drawing.Point(145, 8);
            this.labelSubtaskType.Name = "labelSubtaskType";
            this.labelSubtaskType.Size = new System.Drawing.Size(70, 13);
            this.labelSubtaskType.TabIndex = 2;
            this.labelSubtaskType.Text = "SubtaskType";
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.Location = new System.Drawing.Point(14, 124);
            this.textBoxSummary.Multiline = true;
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.Size = new System.Drawing.Size(542, 83);
            this.textBoxSummary.TabIndex = 5;
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Location = new System.Drawing.Point(11, 108);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(50, 13);
            this.labelSummary.TabIndex = 4;
            this.labelSummary.Text = "Summary";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(14, 226);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(542, 42);
            this.textBoxDescription.TabIndex = 7;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(11, 210);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "Description";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(288, 24);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(113, 20);
            this.textBoxStatus.TabIndex = 9;
            this.textBoxStatus.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxStatus_MouseDoubleClick);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(285, 8);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 13);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Status";
            // 
            // textBoxPriority
            // 
            this.textBoxPriority.Location = new System.Drawing.Point(425, 24);
            this.textBoxPriority.Name = "textBoxPriority";
            this.textBoxPriority.Size = new System.Drawing.Size(113, 20);
            this.textBoxPriority.TabIndex = 11;
            this.textBoxPriority.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxPriority_MouseDoubleClick);
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Location = new System.Drawing.Point(422, 8);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(38, 13);
            this.labelPriority.TabIndex = 10;
            this.labelPriority.Text = "Priority";
            // 
            // textBoxTargetVersion
            // 
            this.textBoxTargetVersion.Location = new System.Drawing.Point(425, 73);
            this.textBoxTargetVersion.Name = "textBoxTargetVersion";
            this.textBoxTargetVersion.Size = new System.Drawing.Size(113, 20);
            this.textBoxTargetVersion.TabIndex = 19;
            this.textBoxTargetVersion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxTargetVersion_MouseDoubleClick);
            // 
            // labelTargetVersion
            // 
            this.labelTargetVersion.AutoSize = true;
            this.labelTargetVersion.Location = new System.Drawing.Point(422, 57);
            this.labelTargetVersion.Name = "labelTargetVersion";
            this.labelTargetVersion.Size = new System.Drawing.Size(73, 13);
            this.labelTargetVersion.TabIndex = 18;
            this.labelTargetVersion.Text = "TargetVersion";
            // 
            // textBoxEstimation
            // 
            this.textBoxEstimation.Location = new System.Drawing.Point(288, 73);
            this.textBoxEstimation.Name = "textBoxEstimation";
            this.textBoxEstimation.Size = new System.Drawing.Size(113, 20);
            this.textBoxEstimation.TabIndex = 17;
            this.textBoxEstimation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxEstimation_MouseDoubleClick);
            // 
            // labelEstimation
            // 
            this.labelEstimation.AutoSize = true;
            this.labelEstimation.Location = new System.Drawing.Point(285, 57);
            this.labelEstimation.Name = "labelEstimation";
            this.labelEstimation.Size = new System.Drawing.Size(55, 13);
            this.labelEstimation.TabIndex = 16;
            this.labelEstimation.Text = "Estimation";
            // 
            // textBoxProject
            // 
            this.textBoxProject.Location = new System.Drawing.Point(148, 73);
            this.textBoxProject.Name = "textBoxProject";
            this.textBoxProject.Size = new System.Drawing.Size(113, 20);
            this.textBoxProject.TabIndex = 15;
            this.textBoxProject.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxProject_MouseDoubleClick);
            // 
            // labelProject
            // 
            this.labelProject.AutoSize = true;
            this.labelProject.Location = new System.Drawing.Point(145, 57);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(40, 13);
            this.labelProject.TabIndex = 14;
            this.labelProject.Text = "Project";
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Location = new System.Drawing.Point(14, 73);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(113, 20);
            this.textBoxProduct.TabIndex = 13;
            this.textBoxProduct.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxProduct_MouseDoubleClick);
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(11, 57);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(44, 13);
            this.labelProduct.TabIndex = 12;
            this.labelProduct.Text = "Product";
            // 
            // textBoxCreatedBy
            // 
            this.textBoxCreatedBy.Location = new System.Drawing.Point(156, 293);
            this.textBoxCreatedBy.Name = "textBoxCreatedBy";
            this.textBoxCreatedBy.Size = new System.Drawing.Size(113, 20);
            this.textBoxCreatedBy.TabIndex = 23;
            // 
            // labelCreatedBy
            // 
            this.labelCreatedBy.AutoSize = true;
            this.labelCreatedBy.Location = new System.Drawing.Point(153, 277);
            this.labelCreatedBy.Name = "labelCreatedBy";
            this.labelCreatedBy.Size = new System.Drawing.Size(56, 13);
            this.labelCreatedBy.TabIndex = 22;
            this.labelCreatedBy.Text = "CreatedBy";
            // 
            // textBoxCreatedDate
            // 
            this.textBoxCreatedDate.Location = new System.Drawing.Point(19, 293);
            this.textBoxCreatedDate.Name = "textBoxCreatedDate";
            this.textBoxCreatedDate.Size = new System.Drawing.Size(113, 20);
            this.textBoxCreatedDate.TabIndex = 21;
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(16, 277);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(67, 13);
            this.labelCreatedDate.TabIndex = 20;
            this.labelCreatedDate.Text = "CreatedDate";
            // 
            // linkLabelLinkToTracker
            // 
            this.linkLabelLinkToTracker.AutoSize = true;
            this.linkLabelLinkToTracker.Location = new System.Drawing.Point(16, 332);
            this.linkLabelLinkToTracker.Name = "linkLabelLinkToTracker";
            this.linkLabelLinkToTracker.Size = new System.Drawing.Size(0, 13);
            this.linkLabelLinkToTracker.TabIndex = 24;
            // 
            // textBoxComments
            // 
            this.textBoxComments.Location = new System.Drawing.Point(288, 293);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(268, 52);
            this.textBoxComments.TabIndex = 26;
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(285, 277);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(56, 13);
            this.labelComments.TabIndex = 25;
            this.labelComments.Text = "Comments";
            // 
            // textBoxAssigned
            // 
            this.textBoxAssigned.Location = new System.Drawing.Point(19, 366);
            this.textBoxAssigned.Name = "textBoxAssigned";
            this.textBoxAssigned.Size = new System.Drawing.Size(537, 20);
            this.textBoxAssigned.TabIndex = 28;
            // 
            // labelAssigned
            // 
            this.labelAssigned.AutoSize = true;
            this.labelAssigned.Location = new System.Drawing.Point(16, 350);
            this.labelAssigned.Name = "labelAssigned";
            this.labelAssigned.Size = new System.Drawing.Size(50, 13);
            this.labelAssigned.TabIndex = 27;
            this.labelAssigned.Text = "Assigned";
            // 
            // DetailPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxAssigned);
            this.Controls.Add(this.labelAssigned);
            this.Controls.Add(this.textBoxComments);
            this.Controls.Add(this.labelComments);
            this.Controls.Add(this.linkLabelLinkToTracker);
            this.Controls.Add(this.textBoxCreatedBy);
            this.Controls.Add(this.labelCreatedBy);
            this.Controls.Add(this.textBoxCreatedDate);
            this.Controls.Add(this.labelCreatedDate);
            this.Controls.Add(this.textBoxTargetVersion);
            this.Controls.Add(this.labelTargetVersion);
            this.Controls.Add(this.textBoxEstimation);
            this.Controls.Add(this.labelEstimation);
            this.Controls.Add(this.textBoxProject);
            this.Controls.Add(this.labelProject);
            this.Controls.Add(this.textBoxProduct);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.textBoxPriority);
            this.Controls.Add(this.labelPriority);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxSummary);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.textBoxSubtaskType);
            this.Controls.Add(this.labelSubtaskType);
            this.Controls.Add(this.textBoxTaskID);
            this.Controls.Add(this.TaskIDlabel);
            this.Name = "DetailPanel";
            this.Size = new System.Drawing.Size(575, 423);
            this.Load += new System.EventHandler(this.DetailsPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label TaskIDlabel;
        private System.Windows.Forms.TextBox textBoxTaskID;
        private System.Windows.Forms.TextBox textBoxSubtaskType;
        private System.Windows.Forms.Label labelSubtaskType;
        private System.Windows.Forms.TextBox textBoxSummary;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxPriority;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.TextBox textBoxTargetVersion;
        private System.Windows.Forms.Label labelTargetVersion;
        private System.Windows.Forms.TextBox textBoxEstimation;
        private System.Windows.Forms.Label labelEstimation;
        private System.Windows.Forms.TextBox textBoxProject;
        private System.Windows.Forms.Label labelProject;
        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.TextBox textBoxCreatedBy;
        private System.Windows.Forms.Label labelCreatedBy;
        private System.Windows.Forms.TextBox textBoxCreatedDate;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.LinkLabel linkLabelLinkToTracker;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.TextBox textBoxAssigned;
        private System.Windows.Forms.Label labelAssigned;
    }
}
