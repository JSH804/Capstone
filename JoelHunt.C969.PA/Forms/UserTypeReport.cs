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
    public partial class UserTypeReport : Form
    {
        private readonly IUserService userService;
        private readonly IAppointmentService appointmentService;

        public UserTypeReport(RepoControl repoControl)
        {
            this.userService = repoControl.Users;
            this.appointmentService = repoControl.Appointments;
            InitializeComponent();

            PopulateDropDowns();
            GetAppointmentList();
            this.resultLabel.Visible = false;
        }

        private void PopulateDropDowns()
        {
            this.userComboBox.DataSource = this.userService.GetUserDropDown();

            this.userComboBox.DisplayMember = "Name";
            this.userComboBox.ValueMember = "Id";

            string[] typeArray = new[] { "Presentation", "Scrum", "Car Talk" };

            this.appComboBox.DataSource = typeArray;
        }

        private void GetAppointmentList()
        {
            this.appointments = this.appointmentService.GetAppointmentListReport();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int.TryParse(this.userComboBox.SelectedValue.ToString(), out int userId);
            string type = this.appComboBox.Text;

            this.resultDataGrid.DataSource = typeof(AppointmentListReport);

            List<AppointmentListReport> apps = new List<AppointmentListReport>();

            //
            //I'm using a LINQ lambda query here so I don't have to query the database everytime a user would like to find a new result
            //I can also get the count of the list easily to display
            //
            apps = this.appointments.Where(a => a.Type == type && a.UserId == userId).ToList();
            this.resultDataGrid.DataSource = apps;
            this.resultDataGrid.Columns[0].Visible = false;
            this.resultDataGrid.Columns[2].Visible = false;
            this.resultDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.resultLabel.Text = $"User {this.userComboBox.Text} has {apps.Count().ToString()} appointments of type: {type}";
            this.resultLabel.Visible = true;


        }

        private List<AppointmentListReport> appointments;
    }
}
