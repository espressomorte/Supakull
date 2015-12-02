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
            var trelloManager = new TrelloManager("4c298896003406f6fce126eec5b6830589ef1bbc63996b2853fee5925ee4701f");
            var tasks = trelloManager.GetTasks();
            Console.ReadLine();
        }
    }
}
