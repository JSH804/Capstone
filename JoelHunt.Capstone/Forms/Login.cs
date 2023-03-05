using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Properties;
using System;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using JoelHunt.Capstone.Models;
using JoelHunt.Capstone.Repositories;
using JoelHunt.Capstone.Services;
using JoelHunt.Capstone.Services.ConfigurationService;
using JoelHunt.Capstone.Services.FileService;

namespace JoelHunt.Capstone.Forms
{
    public partial class Login : Form
    {
        private readonly ITutorService tutorService;
        private readonly IAppointmentService appointmentService;
        private readonly Configurations configs;
        private readonly RepoControl repo;
        private FileManager fileManager;

        public Login(RepoControl repo, Configurations configs)
        {
            this.tutorService = repo.Tutors;
            this.tutorService.AddTestTutor();
            this.appointmentService = repo.Appointments;
            this.configs = configs;
            this.repo = repo;
            this.fileManager = new FileManager();
            InitializeComponent();
            SetLanguage();
        }
        

        private void loginButton_Click(object sender, EventArgs e)
        {
            string tutorname = this.tutornameTextBox.Text;
            string password = this.passwordTextBox.Text;
            if(tutorname != "" && password != "")
            {
                Tutor tutor = this.tutorService.VerifyAndGetTutor(tutorname, password);

                if(tutor != null)
                {
                    this.fileManager.AddLog(tutor.TutorName);
                    MainWindow main = new MainWindow(repo, configs, this, tutor);
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
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ci.Name);

            Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);
            Console.WriteLine(Thread.CurrentThread.CurrentUICulture.Name);

            ResourceManager rm = new ResourceManager("JoelHunt.Capstone.Properties.Login", Assembly.GetExecutingAssembly());
                this.loginTextHeader.Text = rm.GetString("loginTextHeader");
                this.loginHeaderTwo.Text = rm.GetString("loginHeaderTwo");
                this.tutornameText.Text = rm.GetString("tutornameText");
                this.passwordText.Text = rm.GetString("passwordText");
                this.loginIncorrect = rm.GetString("incorrectTutorname");
                this.loginButton.Text = rm.GetString("loginButton");
                this.loginIncorrect = rm.GetString("incorrectTutorname");
                this.loginRequired = rm.GetString("tutornameRequired");
            
        }

        private string loginIncorrect;
        private string loginRequired;
    }
}
