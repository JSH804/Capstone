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
    public partial class AppointmentByMonth : Form
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentByMonth(RepoControl repoControl)
        {
            this.appointmentService = repoControl.Appointments;
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
            string[] typeArray = new[] { "Presentation", "Scrum", "Car Talk" };
            this.typeComboBox.DataSource = typeArray;

            this.yearArray = new int[100];
            for (int x = 1; x < yearArray.Length; x++)
            {
                this.yearArray[x - 1] = 2000 + x;
            }
            this.yearComboBox.DataSource = this.yearArray;

            this.monthComboBox.DataSource = this.monthList;
            this.monthComboBox.DisplayMember = "MonthName";
            this.monthComboBox.ValueMember = "Id";
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string type = this.typeComboBox.Text;
            int.TryParse(this.monthComboBox.SelectedValue.ToString(), out int month);
            int year = Convert.ToInt32(this.yearComboBox.Text);

            List<AppointmentListReport> apps = new List<AppointmentListReport>();

            apps = this.appointments.Where(a => a.StartTime.Year == year && a.StartTime.Month == month && a.Type == type).ToList();

            this.resultDataGrid.DataSource = typeof(AppointmentListReport);
            this.resultDataGrid.DataSource = apps;
            this.resultDataGrid.Columns[0].Visible = false;
            this.resultDataGrid.Columns[2].Visible = false;
            this.resultDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.resultLabel.Text = $"The month of {this.monthComboBox.Text} has {apps.Count()} appointment(s) of type {typeComboBox.Text}";
            this.resultLabel.Visible = true;
        }

        private List<Month> monthList = new List<Month>()
        {
            new Month {Id = 1, MonthName = "January"},
            new Month {Id = 2, MonthName = "February"},
            new Month {Id = 3, MonthName = "March"},
            new Month {Id = 4, MonthName = "April"},
            new Month {Id = 5, MonthName = "May"},
            new Month {Id = 6, MonthName = "June"},
            new Month {Id = 7, MonthName = "July"},
            new Month {Id = 8, MonthName = "August"},
            new Month {Id = 9, MonthName = "September"},
            new Month {Id = 10, MonthName = "October"},
            new Month {Id = 11, MonthName = "November"},
            new Month {Id = 12, MonthName = "December"}
        };

        private List<AppointmentListReport> appointments;
        private int[] yearArray;
    }

    public class Month
    {
        public int Id { get; set; }
        public string MonthName { get; set; }
    }
}
