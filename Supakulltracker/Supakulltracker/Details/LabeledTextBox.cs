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
    public partial class LabeledTextBox : UserControl
    {
        public LabeledTextBox(Sources source , string value, string linkToTracker)
        {
            InitializeComponent();
            valueTextBox.Text = value;
            linkToTrackerTextBox.Hide();
            if (source == Sources.DataBase || source == Sources.Excel)
            {
                SourceLabel.Text = source.ToString() + ": "+ linkToTracker;
                linkToTrackerTextBox.Hide();
            }
            else
            {
                SourceLabel.Text = source.ToString();
                linkToTrackerTextBox.Show();
                linkToTrackerTextBox.Links.Add(0, 50, linkToTracker);
                linkToTrackerTextBox.Text = "Click to see this task in Source";
            }
            
        }
        public LabeledTextBox()
        {

        }

        private void linkToTrackerTextBox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
