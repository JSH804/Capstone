using JoelHunt.C969.PA.Forms.ViewModels;
using JoelHunt.C969.PA.Repositories;
using JoelHunt.C969.PA.Services;
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
    public partial class UserSchedule : Form
    {
        private readonly IUserService userService;
        private readonly IAppointmentService appointmentService;

        public UserSchedule(RepoControl repoControl)
        {
            this.userService = repoControl.Users;
            this.appointmentService = repoControl.Appointments;

            InitializeComponent();
            PopulateDropDowns();
            GetAppointmentList();

            this.resultDataGrid.DataSource = typeof(AppointmentListReport);
            this.resultLabel.Visible = false;
        }

        private void PopulateDropDowns()
        {
            this.userComboBox.DataSource = this.userService.GetUserDropDown();

            this.userComboBox.DisplayMember = "Name";
            this.userComboBox.ValueMember = "Id";
        }

        private void GetAppointmentList()
        {
            this.appointments = this.appointmentService.GetAppointmentListReport();
        }

        private List<AppointmentListReport> appointments;

        private void updateButton_Click(object sender, EventArgs e)
        {
            int.TryParse(this.userComboBox.SelectedValue.ToString(), out int userId);

            this.resultDataGrid.DataSource = typeof(AppointmentListReport);

            List<AppointmentListReport> apps = new List<AppointmentListReport>();
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);

            //
            //I'm using a LINQ lambda query here so I don't have to query the database everytime a user would like to find a new result
            //I can also get the count of the list easily to display and filter for future appointments
            //LINQ also gives me to ability to orderby start times in ascending order
            //
            apps = this.appointments.Where(a => a.StartTime >= currentDateTime && a.UserId == userId).OrderBy(a => a.StartTime).ToList();
            this.resultDataGrid.DataSource = apps;
            this.resultDataGrid.Columns[0].Visible = false;
            this.resultDataGrid.Columns[2].Visible = false;
            this.resultDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.resultLabel.Text = $"User {this.userComboBox.Text} has {apps.Count()} future appointments.";
            this.resultLabel.Visible = true;
        }
    }
}
