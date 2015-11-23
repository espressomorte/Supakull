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
        public SuperTaskControl(SuperTask superTask)
        {
            InitializeComponent();

            this.SubtaskType.DataBindings.Add("Text", superTask, nameof(superTask.SubtaskType));
            this.TaskSummary.DataBindings.Add("Text", superTask, nameof(superTask.Summary));

            superTask.InvokePropertyChanged();
        }
    }
}
