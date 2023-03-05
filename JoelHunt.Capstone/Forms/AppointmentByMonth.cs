using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JoelHunt.Capstone.Forms.Helpers;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Repositories;
using JoelHunt.Capstone.Services;

namespace JoelHunt.Capstone.Forms
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
            string[] typeArray = TutorTypes.TypesArray;
            this.typeComboBox.DataSource = typeArray;

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
            string type = this.typeComboBox.Text;
            int.TryParse(this.monthComboBox.SelectedValue.ToString(), out int month);
            int year = Convert.ToInt32(this.yearComboBox.Text);

            List<AppointmentListReport> apps = new List<AppointmentListReport>();

            //using a LINQ Lambda here to filter the year, month, and type match the query
            //useful so you do not need to query the database multiple times

            apps = this.appointments.Where(a => a.StartTime.Year == year && a.StartTime.Month == month && a.Type == type).ToList();

            this.resultDataGrid.DataSource = typeof(AppointmentListReport);
            this.resultDataGrid.DataSource = apps;
            this.resultDataGrid.Columns[0].Visible = false;
            this.resultDataGrid.Columns[2].Visible = false;
            this.resultDataGrid.Columns[7].Visible = false;
            this.resultDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.resultLabel.Text = $"The month of {this.monthComboBox.Text} has {apps.Count()} appointment(s) of type {typeComboBox.Text}";
            this.resultLabel.Visible = true;
        }


        private List<AppointmentListReport> appointments;
        private int[] yearArray;
    }

    public class Month
    {
        public int Id { get; set; }
        public string MonthName { get; set; }
    }
}
