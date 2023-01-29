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
using JoelHunt.C969.PA.Services;
using JoelHunt.C969.PA.Forms.ViewModels;

namespace JoelHunt.C969.PA.Forms
{
    public partial class MainWindow : Form
    {
        private RepoControl repo;
        private Configurations configs;
        private Login login;
        private User activeUser;
        private readonly IAppointmentService appointmentService;

        public MainWindow(RepoControl repo, Configurations configs, Login login, User user)
        {
            this.configs = configs;
            this.repo = repo;
            this.appointmentService = repo.Appointments;
            this.login = login;
            this.activeUser = user;
            InitializeComponent();
            CheckForAppointments();
        }

        private void CheckForAppointments()
        {
            List<AppointmentListReport> appointments = new List<AppointmentListReport>();

            appointments = this.appointmentService.GetAppointmentListReport(activeUser.UserId);

            TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
            DateTime currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);

            TimeSpan fifteenMinutes = new TimeSpan( 0, 15, 0);
            List<AppointmentListReport> appsWithinFifteen = new List<AppointmentListReport>();

            foreach(var time in appointments)
            {
                TimeSpan span = time.StartTime.Subtract(currentTime);
                Console.WriteLine(span);
            }

            //
            //Using a LINQ Lamba here to easily compare appointment dates and filter for appointments with 15 minutes of login
            //I can resuse the same method to get appointments without creating a custom query in the database
            //
            appsWithinFifteen = appointments
                .Where(a => a.StartTime.Subtract(currentTime) < fifteenMinutes && a.StartTime.Subtract(currentTime) > TimeSpan.Zero)
                .ToList();

            StringBuilder notification = new StringBuilder();
            notification.Append($"You have {appsWithinFifteen.Count()} appointments within 15 minutes.");
            notification.AppendLine();
            foreach (var app in appsWithinFifteen)
            {
                if(appointments.Count > 0)
                {
                    notification.AppendLine($"Appointment with {app.CustomerName} starting at {app.StartTime.ToString("HH:mm")}");
                }
            }

            MessageBox.Show(notification.ToString());
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

        private void createAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments(this.repo, this.activeUser);
            appointments.Show();
        }

        private void findAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment(this.repo, this.activeUser);
            addAppointment.Show();
        }

        private void findAppointmentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTypeReport report = new UserTypeReport(this.repo);
            report.Show();
        }

        private void schedulePerUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSchedule userSchedule = new UserSchedule(repo);
            userSchedule.Show();
        }

        private void appointmentsForCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppointmentByMonth report = new AppointmentByMonth(repo);
            report.Show();
        }
    }
}
