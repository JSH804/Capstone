using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using JoelHunt.Capstone.Forms;
using JoelHunt.Capstone.Repositories;
using JoelHunt.Capstone.Services.ConfigurationService;

namespace JoelHunt.Capstone
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
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Configurations configs = new Configurations();
            RepoControl repo = new RepoControl(configs);
            Application.Run(new Login(repo, configs));
        }
    }
}
