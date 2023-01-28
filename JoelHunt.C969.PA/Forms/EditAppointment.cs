using JoelHunt.C969.PA.Forms.ViewModels;
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

namespace JoelHunt.C969.PA.Forms
{
    public partial class EditAppointment : Form
    {
        private readonly IAppointmentService appointmentService;
        private readonly IUserService userService;
        private readonly ICustomerService customerService;
        private readonly User activeUser;
        private AppointmentEditModel appointment;

        public EditAppointment(RepoControl repo, User activeUser, int id)
        {
            this.appointmentService = repo.Appointments;
            this.userService = repo.Users;
            this.customerService = repo.Customers;
            this.activeUser = activeUser;
            InitializeComponent();
            GetAppointment(id);
            InitializeForm();
        }

        private void GetAppointment(int id)
        {
            try
            {
                appointment = this.appointmentService.GetAppointment(id);
                InitializeForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving the appointment to edit.");
                this.Close();
            }

        }

        private void InitializeForm()
        {
            this.startDatePicker.ShowUpDown = true;
            this.endDatePicker.ShowUpDown = true;

            this.startDatePicker.CustomFormat = "hh:mm tt";
            this.endDatePicker.CustomFormat = "hh:mm tt";

            this.startDatePicker.Format = DateTimePickerFormat.Custom;
            this.endDatePicker.Format = DateTimePickerFormat.Custom;

            this.appCalendar.SelectionStart = this.appointment.Start.Date;
            this.startDatePicker.Text = this.appointment.Start.ToString("hh:mm tt");
            this.endDatePicker.Text = this.appointment.End.ToString("hh:mm tt");

            string[] typeArray = new[] { "Presentation", "Scrum", "Car Talk" };
            this.appTypeComboBox.DataSource = typeArray;

            for (int x = 0; x <= typeArray.Length - 1; x++)
            {
                if(typeArray[x] == this.appointment.Type)
                {
                    this.appTypeComboBox.SelectedIndex = x;
                    break;
                }
            }

            GetDropDownList();
        }

        private void GetDropDownList()
        {
            try
            {
                this.customerComboBox.DataSource = this.customerService.GetCustomerDropDown();
                this.userComboBox.DataSource = this.userService.GetUserDropDown();

                this.customerComboBox.DisplayMember = "Name";
                this.customerComboBox.ValueMember = "Id";

                this.userComboBox.DisplayMember = "Name";
                this.userComboBox.ValueMember = "Id";

                this.customerComboBox.SelectedValue = this.appointment.CustomerId;
                this.userComboBox.SelectedValue = this.appointment.UserId;

            }
            catch (Exception)
            {

                MessageBox.Show("There was an error loading the page.");
            }
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            bool isDeleteSuccessful = this.appointmentService.DeleteAppointment(this.appointment.AppointmentId);

            if (isDeleteSuccessful)
            {
                MessageBox.Show("Delete was successful.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error will deleteing the appointment.");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime startTime = this.startDatePicker.Value.AddSeconds(-(this.startDatePicker.Value.Second));
                DateTime endTime = this.endDatePicker.Value.AddSeconds(-(this.endDatePicker.Value.Second));

                DateTime startTimeToSave = this.appCalendar.SelectionRange.Start.AddHours(startTime.Hour).AddMinutes(startTime.Minute);
                DateTime endTimeToSave = this.appCalendar.SelectionRange.Start.AddHours(endTime.Hour).AddMinutes(endTime.Minute);

                if (this.startDatePicker.Value > this.endDatePicker.Value)
                {
                    throw new ArgumentException("The end time cannot be before the start date!");
                }

                CheckIfInsideBusinessHours(startTime, endTime);
                CheckForOverlaps(startTimeToSave, endTimeToSave);

                int.TryParse(this.customerComboBox.SelectedValue.ToString(), out int customerId);
                int.TryParse(this.userComboBox.SelectedValue.ToString(), out int userId);

                Appointment app = new Appointment()
                {
                    AppointmentId = this.appointment.AppointmentId,
                    CustomerId = customerId,
                    UserId = userId,
                    Type = this.appTypeComboBox.Text,
                    Start = startTimeToSave.ToUniversalTime(),
                    Stop = endTimeToSave.ToUniversalTime(),
                    LastUpdate = DateTime.UtcNow,
                    LastUpdateBy = this.activeUser.UserName
                };



                bool isSaveSuccess = this.appointmentService.UpdateAppointment(app);

                if (isSaveSuccess)
                {
                    MessageBox.Show("Appointment updated successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error while updating the appointment.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckIfInsideBusinessHours(DateTime startTime, DateTime stopTime)
        {
            DateTime amInsideBusinessHoursStart = new DateTime(startTime.Year, startTime.Month, startTime.Day, 8, 0, 0);
            DateTime pmOutsideBusinessHoursEnd = new DateTime(startTime.Year, startTime.Month, startTime.Day, 17, 0, 0);
            if (!(amInsideBusinessHoursStart < startTime) || !(pmOutsideBusinessHoursEnd >= stopTime))
            {
                throw new ArgumentException("This appointment is outside business hours. Please schedule between 8am and 5pm.");
            }
        }

        private void CheckForOverlaps(DateTime start, DateTime end)
        {
            List<AppointmentIdentificationModel> apps = this.appointmentService.GetAppointmentIdentificationModels();
            int.TryParse(this.userComboBox.SelectedValue.ToString(), out int userId);
            foreach (var app in apps)
            {
                if (app.UserId == userId)
                {
                    if (app.Start <= end && start <= app.End)
                    {
                        throw new ArgumentException($"The appointment window of {app.Start.ToString("MM/dd/yy hh:mm")} - {app.End.ToString("MM/dd/yy hh:mm")} is already booked for user: {this.userComboBox.Text}");
                    }
                }
            }
        }
    }
}
