﻿using System;
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

        private SuperTask superTask;
        //private static  Dictionary<String, String> test = new Dictionary<String, String>();
        public DetailPanel()
        {
            InitializeComponent();
        }

        private void DetailsPanel_Load(object sender, EventArgs e)
        {

        }
      
        internal void Bind(SuperTask superTask)
        {
            this.superTask = superTask;
            this.textBoxTaskID.DataBindings.Add("Text", superTask, nameof(superTask.TaskID));
            this.textBoxSubtaskType.DataBindings.Add("Text", superTask, nameof(superTask.SubtaskType));
            this.textBoxSummary.DataBindings.Add("Text", superTask, nameof(superTask.Summary));
            this.textBoxDescription.DataBindings.Add("Text", superTask, nameof(superTask.Description));
            this.textBoxStatus.DataBindings.Add("Text", superTask, nameof(superTask.Status));
            this.textBoxPriority.DataBindings.Add("Text", superTask, nameof(superTask.Priority));
            this.textBoxProduct.DataBindings.Add("Text", superTask, nameof(superTask.Product));
            this.textBoxProject.DataBindings.Add("Text", superTask, nameof(superTask.Project));
            this.textBoxCreatedDate.DataBindings.Add("Text", superTask, nameof(superTask.CreatedDate));
            this.textBoxCreatedBy.DataBindings.Add("Text", superTask, nameof(superTask.CreatedBy));
            this.textBoxEstimation.DataBindings.Add("Text", superTask, nameof(superTask.Estimation));
            this.textBoxTargetVersion.DataBindings.Add("Text", superTask, nameof(superTask.TargetVersion));
            this.textBoxComments.DataBindings.Add("Text", superTask, nameof(superTask.Comments));
            this.textBoxAssigned.DataBindings.Add("Text", superTask, nameof(superTask.Assigned));
        }

        private List<SuperTaskValue> SuperMethod(object sender, string[] field)
        {
            TextBox textBox = sender as TextBox;
            List<SuperTaskValue> Values = new List<SuperTaskValue>();

            for (int i = 0; i < superTask.linkToTrackers.Count<string>(); i++)
            {
                SuperTaskValue newValue = new SuperTaskValue();
                newValue.linkToTracker = superTask.linkToTrackers[i].ToString();
                newValue.textBoxValue = field[i];
                newValue.source = superTask.source[i];
                Values.Add(newValue);
            }
            return Values;
        }


        private void textBoxEstimation_DoubleClick(object sender, EventArgs e)
        {
            string[] field = superTask.estimations;
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(SuperMethod(sender, field));
            PopUp.ShowDialog();
        }



        private void textBoxTargetVersion_DoubleClick(object sender, EventArgs e)
        {
            string[] field = superTask.targetVersions;
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(SuperMethod(sender, field));
            PopUp.ShowDialog();
        }

        private void textBoxPriority_DoubleClick(object sender, EventArgs e)
        {
            string[] field = superTask.priorities;
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(SuperMethod(sender, field));
            PopUp.ShowDialog();
        }

        private void textBoxStatus_DoubleClick(object sender, EventArgs e)
        {
            string[] field = superTask.statuses;
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(SuperMethod(sender, field));
            PopUp.ShowDialog();
        }

        private void textBoxProject_DoubleClick(object sender, EventArgs e)
        {
            string[] field = superTask.projects;
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(SuperMethod(sender, field));
            PopUp.ShowDialog();
        }

        private void textBoxSubtaskType_DoubleClick(object sender, EventArgs e)
        {
            string[] field = superTask.subtaskTypes;
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(SuperMethod(sender, field));
            PopUp.ShowDialog();
        }

        private void textBoxProduct_DoubleClick(object sender, EventArgs e)
        {
            string[] field = superTask.products;
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(SuperMethod(sender, field));
            PopUp.ShowDialog();
        }

        private void linkLabelLinkToTracker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string[] field = superTask.linkToTrackers;
            PopUpMultipleEditor PopUp = new PopUpMultipleEditor(SuperMethod(sender, field));
        }
        public struct SuperTaskValue
        {
            public string linkToTracker { get; set; }
            public string textBoxValue { get; set; }
            public Sources source { get; set; }
        } 

    }
}
