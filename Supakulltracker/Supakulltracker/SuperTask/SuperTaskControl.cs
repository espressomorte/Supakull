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
    public partial class SuperTaskControl: UserControl
    {
        public SuperTaskControl()
        {
            InitializeComponent();
        }

        public SuperTask SuperTask
        {
            set
            {
                this.SubtaskType.DataBindings.Add("Text", value, nameof(value.SubtaskType));
                this.TaskSummary.DataBindings.Add("Text", value, nameof(value.Summary));
            }
        }
    }
}
