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
        //private IssueService.TaskMainDTO[] tasks;
        public event EventHandler<EventArgs> FindButtonPressed; 

        public IssueService.TaskMainDTO[] Tasks
        {            
            set
            {
                Board.DataSource = value;
            }
        }

        public string SearchQuery
        {
            get
            {
                return this.SearchTextBox.Text;
            }
        }

        public SearchControl()
        {
            InitializeComponent();            
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            if(FindButtonPressed != null)
            {
                FindButtonPressed(this, EventArgs.Empty);
            }
        }

        //public event DataGridViewCellEventHandler BoardCellContentClick;


        //private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        Find(this.SearchTextBox.Text);
        //    }
        //}

        //private void Find(string textQuery)
        //{
        //    SearchProvider taskSearchProvider = new SearchProvider();
        //    Tasks = taskSearchProvider.FindTasks(textQuery);
        //}

        //private void Board_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewCellEventHandler handler = BoardCellContentClick;
        //    handler(sender, e);
        //}
    }
}
