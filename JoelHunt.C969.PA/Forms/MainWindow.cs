using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using JoelHunt.C969.PA.Services.ConfigurationService;
using JoelHunt.C969.PA.Repositories;
using JoelHunt.C969.PA.Models;

namespace JoelHunt.C969.PA.Forms
{
    public partial class MainWindow : Form
    {
        private RepoControl repo;
        private Configurations configs;
        private Login login;
        private User activeUser;

        public MainWindow(RepoControl repo, Configurations configs, Login login, User user)
        {
            this.configs = configs;
            this.repo = repo;
            this.login = login;
            this.activeUser = user;
            InitializeComponent();
        }

        private ResourceManager ResourceManager { get; set; }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.repo.Dispose();
            this.login.Close();
        }

        private void createCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateCustomer create =new CreateCustomer(this.repo, this.activeUser);
            create.Show();
        }

        private void viewCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers customersForm = new Customers(this.repo, activeUser);
            customersForm.Show();
        }
    }
}
