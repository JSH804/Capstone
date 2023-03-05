using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Repositories;
using JoelHunt.Capstone.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoelHunt.Capstone.Forms
{
    public partial class CustomerSchedule : Form
    {
        private readonly IAppointmentService appointmentService;
        private readonly ICustomerService customerService;

        public CustomerSchedule(RepoControl repoControl)
        {
            this.appointmentService = repoControl.Appointments;
            this.customerService = repoControl.Customers;

            InitializeComponent();

            GetCustomerDropDown();
            GetAppointmentList();
        }

        private void GetCustomerDropDown()
        {
            this.customerComboBox.DataSource = this.customerService.GetCustomerDropDown();

            this.customerComboBox.DisplayMember = "Name";
            this.customerComboBox.ValueMember = "Id";
        }

        private void GetAppointmentList()
        {
            this.appointments = this.appointmentService.GetAppointmentListReport();
        }

        private List<AppointmentListReport> appointments;

        private void updateButton_Click(object sender, EventArgs e)
        {
            int.TryParse(this.customerComboBox.SelectedValue.ToString(), out int customerId);

            this.resultDataGrid.DataSource = typeof(AppointmentListReport);

            List<AppointmentListReport> apps = new List<AppointmentListReport>();
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);

            apps = this.appointments.Where(a => a.CustomerId == customerId).OrderBy(a => a.StartTime).ToList();
            this.resultDataGrid.DataSource = apps;
            this.resultDataGrid.Columns[0].Visible = false;
            this.resultDataGrid.Columns[2].Visible = false;
            this.resultDataGrid.Columns[7].Visible = false;
            this.resultDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.resultLabel.Text = $"Found a total of {apps.Count()} Appointments for Customer {this.customerComboBox.Text}.";
            this.resultLabel.Visible = true;
        }
    }
}
