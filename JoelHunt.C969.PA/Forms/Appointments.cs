using JoelHunt.C969.PA.Models;
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
using JoelHunt.C969.PA.Helpers;
using System.Collections.ObjectModel;
using JoelHunt.C969.PA.Forms.ViewModels;

namespace JoelHunt.C969.PA.Forms
{
    public partial class Appointments : Form
    {
        private readonly IAppointmentService appointmentService;
        private readonly User activeUser;
        private readonly RepoControl repo;

        public Appointments(RepoControl repo, User activeUser)
        {
            this.repo = repo;
            this.appointmentService = repo.Appointments;
            this.activeUser = activeUser;
            InitializeComponent();
            GetListOfAppointmentsOnInit();
            this.allRadio.Checked = true;
        }

        private void GetListOfAppointmentsOnInit()
        {
            this.appointments = this.appointmentService.GetAppointmentListModels();
            this.dataGridAppointments = this.appointments;
            this.appointmentDataGrid.DataSource = this.dataGridAppointments;
            this.appointmentDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
         
        }

        private void addAppButton_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment(this.repo, this.activeUser);
            addAppointment.Show();
        }

        private void calendarUpdateButton_Click(object sender, EventArgs e)
        {
            if (this.weekRadio.Checked)
            {
                DateTime searchDate = this.searchCalender.SelectionStart;
                DateTime startOfWeek = this.searchCalender.SelectionRange.Start = searchDate.StartOfWeek();

                DateTime endOfWeek = searchDate.GetNextWeekday(DayOfWeek.Friday);

                this.searchCalender.SelectionRange.Start = startOfWeek;
                this.searchCalender.SelectionRange.End = endOfWeek;

                this.dataGridAppointments = this.appointments.Where(a => a.Start > startOfWeek && a.End < endOfWeek.AddMilliseconds(86399999)).ToList();
                this.appointmentDataGrid.DataSource = typeof(List<AppointmentListModel>);
                this.appointmentDataGrid.DataSource = this.dataGridAppointments;
            }
            else if (this.yearRadio.Checked)
            {
                DateTime searchDate = this.searchCalender.SelectionStart;
                DateTime startOfYear = searchDate.AddDays(-searchDate.DayOfYear + 1);
                DateTime endOfYear = new DateTime(this.searchCalender.SelectionStart.Year, 12, 31).AddMilliseconds(86399999);

                this.dataGridAppointments = this.appointments.Where(a => a.Start >= startOfYear && a.End <= endOfYear).ToList();
                this.appointmentDataGrid.DataSource = typeof(List<AppointmentListModel>);
                this.appointmentDataGrid.DataSource = this.dataGridAppointments;
            }
            else
            {
                this.dataGridAppointments = this.appointments;
                this.appointmentDataGrid.DataSource = typeof(List<AppointmentListModel>);
                this.appointmentDataGrid.DataSource = this.dataGridAppointments;
            }

        }

        private void searchCalender_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime searchDate = this.searchCalender.SelectionStart;
            DateTime startOfWeek = this.searchCalender.SelectionRange.Start = searchDate.StartOfWeek();

            DateTime endOfWeek = searchDate.GetNextWeekday(DayOfWeek.Friday);

            this.searchCalender.SelectionRange.Start = startOfWeek;
            this.searchCalender.SelectionRange.End = endOfWeek;
            this.searchCalender.SetSelectionRange(startOfWeek, endOfWeek.AddMilliseconds(86399999));
        }

        private List<AppointmentListModel> appointments;
        private List<AppointmentListModel> dataGridAppointments;
    }
}
