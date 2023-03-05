using JoelHunt.Capstone.Forms.Helpers;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Models;
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
    public partial class EmployeeRevenueReport : Form
    {
        private readonly IAppointmentService appointmentService;
        private readonly ITutorService tutorService;
        public EmployeeRevenueReport(RepoControl repo)
        {
            this.appointmentService = repo.Appointments;
            this.tutorService = repo.Tutors;
            InitializeComponent();
            GetAppointmentList();
            PopulateDropDowns();
            this.resultLabel.Visible = false;
        }

        private void GetAppointmentList()
        {
            this.appointments = this.appointmentService.GetAppointmentListReport();
        }

        private void PopulateDropDowns()
        {
            this.tutorComboBox.DataSource = this.tutorService.GetTutorDropDown();
            this.tutorComboBox.DisplayMember = "Name";
            this.tutorComboBox.ValueMember = "Id";

            this.yearArray = new int[100];
            for (int x = 1; x < yearArray.Length; x++)
            {
                this.yearArray[x - 1] = 2000 + x;
            }
            this.yearComboBox.DataSource = this.yearArray;

            this.monthComboBox.DataSource = MonthHelper.monthList;
            this.monthComboBox.DisplayMember = "MonthName";
            this.monthComboBox.ValueMember = "Id";
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            monthlyRevenue = 0;
           int.TryParse(this.tutorComboBox.SelectedValue.ToString(), out int tutorId);

           int.TryParse(this.monthComboBox.SelectedValue.ToString(), out int month);
           int year = Convert.ToInt32(this.yearComboBox.Text);
            Tutor tutor = this.tutorService.GetTutor(tutorId);
            decimal rate = tutor.Rate;
            List<AppointmentListReport> apps = new List<AppointmentListReport>();

            List<AppointmentListFinancialReport> appsFinacial = new List<AppointmentListFinancialReport>();

            apps = this.appointments.Where(a => a.StartTime.Year == year && a.StartTime.Month == month && a.TutorId == tutorId).ToList();


            if(apps.Count > 0)
            {
                foreach(var app in apps)
                {
                    AppointmentListFinancialReport finApp = new AppointmentListFinancialReport(app);
                    finApp.Revenue = tutor.Rate;
                    finApp.TutorName = tutor.TutorName;
                    appsFinacial.Add(finApp);
                    this.monthlyRevenue += finApp.Revenue;
                }
            }

            this.resultDataGrid.DataSource = typeof(AppointmentListFinancialReport);
            this.resultDataGrid.DataSource = appsFinacial;
            this.resultDataGrid.Columns[2].Visible = false;
            this.resultDataGrid.Columns[4].Visible = false;
            this.resultDataGrid.Columns[9].Visible = false;
            this.resultDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.resultLabel.Text = $"{tutor.TutorName} generated ${monthlyRevenue} for the month of {this.monthComboBox.Text} {this.yearComboBox.Text}";
            this.resultLabel.Visible = true;
        }


        private List<AppointmentListReport> appointments;
        private int[] yearArray;
        private decimal monthlyRevenue;
    }
}
