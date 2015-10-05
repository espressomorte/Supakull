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

       
        public MainForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {            
            IssueService.GetTrackerServicesSoapClient client = new IssueService.GetTrackerServicesSoapClient();
            client.StoreSources();
            Board.DataSource = client.GetAllTasks();
        }

        private void Board_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NewTab();
        }

        private void NewTab()
        {
            string title = "TabPage " + (taskDetailTabControl.TabCount + 1).ToString();
            TabPage newTabPage = new TabPage(title);
            taskDetailTabControl.TabPages.Add(newTabPage);
        }
    }
}
