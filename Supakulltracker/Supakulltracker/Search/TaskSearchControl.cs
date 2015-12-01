using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supakulltracker
{
    public partial class TaskSearchControl : UserControl
    {
        public TaskSearchControl()
        {
            InitializeComponent();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            TaskSearchProvider taskSearchProvider = new TaskSearchProvider();
            IssueService.TaskMainDTO[] tasks = taskSearchProvider.Find(this.SearchTextBox.Text);
        }
    }
}
