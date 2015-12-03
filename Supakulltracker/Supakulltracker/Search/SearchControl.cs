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
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();            
        }

        public event DataGridViewCellEventHandler BoardCellContentClick;

        private void FindButton_Click(object sender, EventArgs e)
        {
            Find(this.SearchTextBox.Text);
        }        

        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Find(this.SearchTextBox.Text);
            }
        }

        private void Find(string textQuery)
        {
            SearchProvider taskSearchProvider = new SearchProvider();
            IssueService.TaskMainDTO[] tasks = taskSearchProvider.FindTasks(textQuery);
            this.LoadTasksToBoard(tasks);
        }

        private void Board_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellEventHandler handler = BoardCellContentClick;
            handler(sender, e);
        }

        public void LoadTasksToBoard(IssueService.TaskMainDTO[] tasks)
        {
            Board.DataSource = tasks;
        }
    }
}
