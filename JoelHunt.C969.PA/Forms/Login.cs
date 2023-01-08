using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Repositories;
using JoelHunt.C969.PA.Services;
using JoelHunt.C969.PA.Services.ConfigurationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoelHunt.C969.PA.Forms
{
    public partial class Login : Form
    {
        private readonly IUserService userService;
        private readonly Configurations configs;
        private readonly RepoControl repo;

        public Login(RepoControl repo, Configurations configs)
        {
            this.userService = repo.Users;
            this.configs = configs;
            this.repo = repo;
            InitializeComponent();
        }


        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = this.usernameTextBox.Text;
            string password = this.passwordTextBox.Text;
            if(username != "" && password != "")
            {
                User user = this.userService.VerifyAndGetUser(username, password);

                if(user != null)
                {
                    MainWindow main = new MainWindow(repo, configs, this, user);
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The username and password are incorrect. Try again.");
                }
            }
            else
            {
                MessageBox.Show("Username and Password are required!");
            }
        }
    }
}
