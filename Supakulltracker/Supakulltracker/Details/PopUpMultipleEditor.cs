using Supakulltracker.IssueService;
using System;
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
    public partial class PopUpMultipleEditor : Form
    {
        public PopUpMultipleEditor(List<DetailPanel.SuperTaskValue> values)
        {
            InitializeComponent();
            foreach (var value in values)
            {
                LabeledTextBox labeledTextBox = new LabeledTextBox(value.source,value.textBoxValue,value.linkToTracker);              
                this.popUpFLP.Controls.Add(labeledTextBox);
            }
        }
    }
}
