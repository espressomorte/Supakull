using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloNet;

namespace TrelloTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var trelloManager = new TrelloManager("a6be1bf3e440e8bb2095c8c1519d8a43cd8cc5171e5d3997a27714bb3b68a1b6");
            var tasks = trelloManager.GetTasks();
        }
    }
}
