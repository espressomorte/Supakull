using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]


namespace Supakulltracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm();
            PresenterMain presenterMain = new PresenterMain(mainForm);
            Application.Run(mainForm);                    
        }
    }
}
