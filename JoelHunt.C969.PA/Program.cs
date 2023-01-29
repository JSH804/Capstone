using JoelHunt.C969.PA.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using JoelHunt.C969.PA.Services.ConfigurationService;
using JoelHunt.C969.PA.Repositories;

namespace JoelHunt.C969.PA
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
            Configurations configs = new Configurations();
            RepoControl repo = new RepoControl(configs);
            Application.Run(new Login(repo, configs));
        }
    }
}
