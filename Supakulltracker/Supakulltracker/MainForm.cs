﻿using System;
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

        public MainForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            IssueService.GetTrackerServicesSoapClient client = new IssueService.GetTrackerServicesSoapClient();
            client.StoreSources();
            Tasks = client.GetAllTasks();
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
            var detail = new DetailPanel();
            detail.Dock = DockStyle.Fill;
            detail.Fill(task);
            newTabPage.Controls.Add(detail);
            taskDetailTabControl.TabPages.Add(newTabPage);
            taskDetailTabControl.SelectTab(taskDetailTabControl.TabCount-1);
        }
    }
}
