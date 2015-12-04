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
        private IssueService.TaskMainDTO[] tasks;

        public IssueService.TaskMainDTO[] Tasks
        {
            get
            {
                return tasks;
            }
            set
            {
                tasks = value;
                Board.DataSource = value;
            }
        }

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
            Tasks = taskSearchProvider.FindTasks(textQuery);
        }

        private void Board_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellEventHandler handler = BoardCellContentClick;
            handler(sender, e);
        }
    }
}
