using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Repositories;
using JoelHunt.Capstone.Services;

namespace JoelHunt.Capstone.Forms
{
    public partial class TutorSchedule : Form
    {
        private readonly ITutorService tutorService;
        private readonly IAppointmentService appointmentService;

        public TutorSchedule(RepoControl repoControl)
        {
            this.tutorService = repoControl.Tutors;
            this.appointmentService = repoControl.Appointments;

            InitializeComponent();
            PopulateDropDowns();
            GetAppointmentList();

            this.resultDataGrid.DataSource = typeof(AppointmentListReport);
            this.resultLabel.Visible = false;
        }

        private void PopulateDropDowns()
        {
            this.tutorComboBox.DataSource = this.tutorService.GetTutorDropDown();

            this.tutorComboBox.DisplayMember = "Name";
            this.tutorComboBox.ValueMember = "Id";
        }

        private void GetAppointmentList()
        {
            this.appointments = this.appointmentService.GetAppointmentListReport();
        }

        private List<AppointmentListReport> appointments;

        private void updateButton_Click(object sender, EventArgs e)
        {
            int.TryParse(this.tutorComboBox.SelectedValue.ToString(), out int tutorId);

            this.resultDataGrid.DataSource = typeof(AppointmentListReport);

            List<AppointmentListReport> apps = new List<AppointmentListReport>();
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);

            //
            //I'm using a LINQ lambda query here so I don't have to query the database everytime a tutor would like to find a new result
            //I can also get the count of the list easily to display and filter for future appointments
            //LINQ lambda also gives me to ability to orderby start times in ascending order
            //
            apps = this.appointments.Where(a => a.StartTime >= currentDateTime && a.TutorId == tutorId).OrderBy(a => a.StartTime).ToList();
            this.resultDataGrid.DataSource = apps;
            this.resultDataGrid.Columns[0].Visible = false;
            this.resultDataGrid.Columns[2].Visible = false;
            this.resultDataGrid.Columns[7].Visible = false;
            this.resultDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.resultLabel.Text = $"Tutor {this.tutorComboBox.Text} has {apps.Count()} future appointments.";
            this.resultLabel.Visible = true;
        }
    }
}
