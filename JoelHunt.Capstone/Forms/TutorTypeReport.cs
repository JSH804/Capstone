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
    public partial class TutorTypeReport : Form
    {
        private readonly ITutorService tutorService;
        private readonly IAppointmentService appointmentService;

        public TutorTypeReport(RepoControl repoControl)
        {
            this.tutorService = repoControl.Tutors;
            this.appointmentService = repoControl.Appointments;
            InitializeComponent();

            PopulateDropDowns();
            GetAppointmentList();
            this.resultLabel.Visible = false;
        }

        private void PopulateDropDowns()
        {
            this.tutorComboBox.DataSource = this.tutorService.GetTutorDropDown();

            this.tutorComboBox.DisplayMember = "Name";
            this.tutorComboBox.ValueMember = "Id";

            string[] typeArray = TutorTypes.TypesArray;

            this.appComboBox.DataSource = typeArray;
        }

        private void GetAppointmentList()
        {
            this.appointments = this.appointmentService.GetAppointmentListReport();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int.TryParse(this.tutorComboBox.SelectedValue.ToString(), out int tutorId);
            string type = this.appComboBox.Text;

            this.resultDataGrid.DataSource = typeof(AppointmentListReport);

            List<AppointmentListReport> apps = new List<AppointmentListReport>();

            apps = this.appointments.Where(a => a.Type == type && a.TutorId == tutorId).ToList();
            this.resultDataGrid.DataSource = apps;
            this.resultDataGrid.Columns[0].Visible = false;
            this.resultDataGrid.Columns[2].Visible = false;
            this.resultDataGrid.Columns[7].Visible = false;
            this.resultDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.resultLabel.Text = $"Tutor {this.tutorComboBox.Text} has {apps.Count().ToString()} appointments of type: {type}";
            this.resultLabel.Visible = true;


        }

        private List<AppointmentListReport> appointments;
    }
}
