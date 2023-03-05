using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JoelHunt.Capstone.Helpers;
using System.Collections.ObjectModel;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Models;
using JoelHunt.Capstone.Repositories;
using JoelHunt.Capstone.Services;

namespace JoelHunt.Capstone.Forms
{
    public partial class Appointments : Form
    {
        private readonly IAppointmentService appointmentService;
        private readonly Tutor activeTutor;
        private readonly RepoControl repo;

        public Appointments(RepoControl repo, Tutor activeTutor)
        {
            this.repo = repo;
            this.appointmentService = repo.Appointments;
            this.activeTutor = activeTutor;
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
            this.appointmentDataGrid.Columns[0].Visible = false;

        }

        private void addAppButton_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment(this.repo, this.activeTutor);
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
            this.appointmentDataGrid.Columns[0].Visible = false;
        }

        private void RefreshTheAppointmentGrid()
        {
            this.appointments = this.appointmentService.GetAppointmentListModels();
            this.dataGridAppointments = this.appointments;
            this.appointmentDataGrid.DataSource = typeof(AppointmentListModel);
            this.appointmentDataGrid.DataSource = this.dataGridAppointments;
            this.appointmentDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentDataGrid.Columns[0].Visible = false;
        }

        private void calendarUpdateButton_Click(object sender, EventArgs e)
        {
            if (this.weekRadio.Checked)
            {
                DateTime searchDate = this.searchCalender.SelectionStart;
                DateTime startOfWeek = this.searchCalender.SelectionRange.Start = searchDate.StartOfWeek();

                DateTime endOfWeek = searchDate.GetNextWeekday(DayOfWeek.Saturday);

                this.searchCalender.SelectionRange.Start = startOfWeek;
                this.searchCalender.SelectionRange.End = endOfWeek;

                //Using a LINQ lamba here to filter the appoints by week
                //useful so you do not need to query the database multiple times
                this.dataGridAppointments = this.appointments.Where(a => a.StartTime > startOfWeek && a.EndTime < endOfWeek.AddMilliseconds(86499999)).ToList();
                this.appointmentDataGrid.DataSource = typeof(List<AppointmentListModel>);
                this.appointmentDataGrid.DataSource = this.dataGridAppointments;
                this.appointmentDataGrid.Columns[0].Visible = false;
            }
            else if (this.monthRadio.Checked)
            {
                DateTime searchDate = this.searchCalender.SelectionStart;
                DateTime startOfMonth = new DateTime(searchDate.Year, searchDate.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1).AddMilliseconds(86499999);

                //Using a LINQ lamba here to filter the appoints by month
                //useful so you do not need to query the database multiple times
                this.dataGridAppointments = this.appointments.Where(a => a.StartTime >= startOfMonth && a.EndTime <= endOfMonth).ToList();
                this.appointmentDataGrid.DataSource = typeof(List<AppointmentListModel>);
                this.appointmentDataGrid.DataSource = this.dataGridAppointments;
                this.appointmentDataGrid.Columns[0].Visible = false;
            }
            else
            {
                this.dataGridAppointments = this.appointments;
                this.appointmentDataGrid.DataSource = typeof(List<AppointmentListModel>);
                this.appointmentDataGrid.DataSource = this.dataGridAppointments;
                this.appointmentDataGrid.Columns[0].Visible = false;
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

        private void editButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.appointmentDataGrid.SelectedRows[0];
            int appointmentId = Convert.ToInt32(row.Cells["appointmentId"].Value);
            EditAppointment editForm = new EditAppointment(repo, activeTutor, appointmentId);
            editForm.Show();
            editForm.FormClosed += RefreshTheAppointmentGrid;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.appointmentDataGrid.SelectedRows[0];
            int appointmentId = Convert.ToInt32(row.Cells["appointmentId"].Value);

            bool isDeleteSuccessful = this.appointmentService.DeleteAppointment(appointmentId);

            if (isDeleteSuccessful)
            {
                MessageBox.Show("Delete was successful.");
                RefreshTheAppointmentGrid();
            }
            else
            {
                MessageBox.Show("Error will deleteing the appointment.");
            }
        }

        private List<AppointmentListModel> appointments;
        private List<AppointmentListModel> dataGridAppointments;
    }
}
