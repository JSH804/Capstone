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
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Models;
using JoelHunt.Capstone.Repositories;
using JoelHunt.Capstone.Services;
using JoelHunt.Capstone.Services.ConfigurationService;

namespace JoelHunt.Capstone.Forms
{
    public partial class MainWindow : Form
    {
        private RepoControl repo;
        private Configurations configs;
        private Login login;
        private Tutor activeTutor;
        private readonly IAppointmentService appointmentService;

        public MainWindow(RepoControl repo, Configurations configs, Login login, Tutor tutor)
        {
            this.configs = configs;
            this.repo = repo;
            this.appointmentService = repo.Appointments;
            this.login = login;
            this.activeTutor = tutor;
            InitializeComponent();
            CheckForAppointments();
        }

        private void CheckForAppointments()
        {
            List<AppointmentListReport> appointments = new List<AppointmentListReport>();

            appointments = this.appointmentService.GetAppointmentListReport(activeTutor.TutorId);

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
            CreateCustomer create =new CreateCustomer(this.repo, this.activeTutor);
            create.Show();
        }

        private void viewCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers customersForm = new Customers(this.repo, activeTutor);
            customersForm.Show();
        }

        private void createAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments(this.repo, this.activeTutor);
            appointments.Show();
        }

        private void findAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment(this.repo, this.activeTutor);
            addAppointment.Show();
        }

        private void findAppointmentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TutorTypeReport report = new TutorTypeReport(this.repo);
            report.Show();
        }

        private void schedulePerTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TutorSchedule tutorSchedule = new TutorSchedule(repo);
            tutorSchedule.Show();
        }

        private void appointmentsForCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppointmentByMonth report = new AppointmentByMonth(repo);
            report.Show();
        }

        private void customerAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerSchedule report = new CustomerSchedule(repo);
            report.Show();
        }

        private void addTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.activeTutor.IsAdmin == true)
            {
                CreateTutor create = new CreateTutor(repo, activeTutor);
                create.Show();
            }
            else
            {
                MessageBox.Show("You must have administrative rights to access this feature.");
            }
        }

        private void viewTutorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.activeTutor.IsAdmin == true)
            {
                Tutors view = new Tutors(repo, activeTutor);
                view.Show();
            }
            else
            {
                MessageBox.Show("You must have administrative rights to access this feature.");
            }
        }

        private void empoyeeRevenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.activeTutor.IsAdmin == true)
            {
                EmployeeRevenueReport report = new EmployeeRevenueReport(repo);
                report.Show();
            }
        }
    }
}
