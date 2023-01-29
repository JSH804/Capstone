using JoelHunt.C969.PA.Forms.ViewModels;
using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Properties;
using JoelHunt.C969.PA.Repositories;
using JoelHunt.C969.PA.Services;
using JoelHunt.C969.PA.Services.ConfigurationService;
using System;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using JoelHunt.C969.PA.Services.FileService;

namespace JoelHunt.C969.PA.Forms
{
    public partial class Login : Form
    {
        private readonly IUserService userService;
        private readonly IAppointmentService appointmentService;
        private readonly Configurations configs;
        private readonly RepoControl repo;
        private FileManager fileManager;

        public Login(RepoControl repo, Configurations configs)
        {
            this.userService = repo.Users;
            this.userService.AddTestUser();
            this.appointmentService = repo.Appointments;
            this.configs = configs;
            this.repo = repo;
            this.fileManager = new FileManager();
            InitializeComponent();
            SetLanguage();
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
                    this.fileManager.AddLog(user.UserName);
                    MainWindow main = new MainWindow(repo, configs, this, user);
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(loginIncorrect);
                }
            }
            else
            {
                MessageBox.Show(loginRequired);
            }
        }

        private void SetLanguage()
        {
            ResourceManager rm = new ResourceManager("JoelHunt.C969.PA.Properties.Login", Assembly.GetExecutingAssembly());
                this.loginTextHeader.Text = rm.GetString("loginTextHeader");
                this.loginHeaderTwo.Text = rm.GetString("loginHeaderTwo");
                this.usernameText.Text = rm.GetString("usernameText");
                this.passwordText.Text = rm.GetString("passwordText");
                this.loginIncorrect = rm.GetString("incorrectUsername");
                this.loginButton.Text = rm.GetString("loginButton");
                this.loginIncorrect = rm.GetString("incorrectUsername");
                this.loginRequired = rm.GetString("usernameRequired");
            
        }

        private string loginIncorrect;
        private string loginRequired;
    }
}
