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
            addAppointment.FormClosed += RefreshTheAppointmentGrid;
        }

        private void RefreshTheAppointmentGrid(object sender, EventArgs args)
        {
            this.appointments = this.appointmentService.GetAppointmentListModels();
            this.dataGridAppointments = this.appointments;
            this.appointmentDataGrid.DataSource = typeof(AppointmentListModel);
            this.appointmentDataGrid.DataSource = this.dataGridAppointments;
            this.appointmentDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                this.dataGridAppointments = this.appointments.Where(a => a.StartTime > startOfWeek && a.EndTime < endOfWeek.AddMilliseconds(86399999)).ToList();
                this.appointmentDataGrid.DataSource = typeof(List<AppointmentListModel>);
                this.appointmentDataGrid.DataSource = this.dataGridAppointments;
            }
            else if (this.monthRadio.Checked)
            {
                DateTime searchDate = this.searchCalender.SelectionStart;
                DateTime startOfMonth = new DateTime(searchDate.Year, searchDate.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1).AddMilliseconds(86399999);

                this.dataGridAppointments = this.appointments.Where(a => a.StartTime >= startOfMonth && a.EndTime <= endOfMonth).ToList();
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
            if (weekRadio.Checked)
            {
                this.searchCalender.RemoveAllBoldedDates();
                int searchDateInt = Convert.ToInt32(this.searchCalender.SelectionStart.DayOfWeek);
                DateTime startOfWeek = this.searchCalender.SelectionStart.AddDays(-searchDateInt);

                for(int x = 0; x < 7; x++)
                {
                    this.searchCalender.AddBoldedDate(startOfWeek.AddDays(x));
                }
                this.searchCalender.UpdateBoldedDates();
            }
        }


        private List<AppointmentListModel> appointments;
        private List<AppointmentListModel> dataGridAppointments;

        private void allRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.allRadio.Checked)
            {
                this.searchCalender.Hide();
            }
        }

        private void weekRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(this.weekRadio.Checked || this.monthRadio.Checked)
            {
                this.searchCalender.Show();
            }
        }

        private void monthRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.weekRadio.Checked || this.monthRadio.Checked)
            {
                this.searchCalender.Show();
            }
        }
    }
}
