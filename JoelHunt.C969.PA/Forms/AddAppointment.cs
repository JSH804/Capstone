using JoelHunt.C969.PA.Forms.ViewModels;
using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Repositories;
using JoelHunt.C969.PA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoelHunt.C969.PA.Forms
{
    public partial class AddAppointment : Form
    {
        private readonly IAppointmentService appointmentService;
        private readonly IUserService userService;
        private readonly ICustomerService customerService;
        private readonly User activeUser;

        public AddAppointment(RepoControl repo, User activeUser)
        {
            this.appointmentService = repo.Appointments;
            this.userService = repo.Users;
            this.customerService = repo.Customers;
            this.activeUser = activeUser;
            InitializeComponent();

            InitializeForm();
        }

        private void InitializeForm()
        {
            this.startDatePicker.ShowUpDown = true;
            this.endDatePicker.ShowUpDown = true;

            this.startDatePicker.CustomFormat = "HH:mm";
            this.endDatePicker.CustomFormat = "HH:mm";

            this.startDatePicker.Format = DateTimePickerFormat.Custom;
            this.endDatePicker.Format = DateTimePickerFormat.Custom;

            string[] typeArray = new[] { "Presentation", "Scrum", "Hardware" };

            this.appTypeComboBox.DataSource = typeArray;

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

            }
            catch (Exception)
            {

                MessageBox.Show("There was an error loading the page.");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startTime = this.startDatePicker.Value.AddSeconds(-(this.startDatePicker.Value.Second));
                DateTime endTime = this.endDatePicker.Value.AddSeconds(-(this.endDatePicker.Value.Second));

                DateTime startTimeToSave = this.appCalendar.SelectionRange.Start.AddHours(startTime.Hour).AddMinutes(startTime.Minute);
                DateTime endTimeToSave = this.appCalendar.SelectionRange.Start.AddHours(endTime.Hour).AddMinutes(endTime.Minute);

                TimeZoneInfo timeInfo = TimeZoneInfo.Local;
                DateTime currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeInfo);

                if (startTimeToSave < currentTime)
                {
                    throw new ArgumentException("The appointment date cannot be in the past.");
                }

                if (this.startDatePicker.Value > this.endDatePicker.Value)
                {
                    throw new ArgumentException("The end time cannot be before the start date!");
                }



                CheckIfInsideBusinessHours(startTime, endTime);
                CheckForOverlaps(startTimeToSave, endTimeToSave);

                int.TryParse(this.customerComboBox.SelectedValue.ToString(), out int customerId);
                int.TryParse(this.userComboBox.SelectedValue.ToString(), out int userId);

                Appointment appointment = new Appointment()
                {
                    CustomerId = customerId,
                    UserId = userId,
                    Type = this.appTypeComboBox.Text,
                    Start = startTimeToSave.ToUniversalTime(),
                    Stop = endTimeToSave.ToUniversalTime(),
                    CreatedBy = this.activeUser.UserName,
                    LastUpdateBy = this.activeUser.UserName
                };

                bool isSaveSuccess = this.appointmentService.AddAppointment(appointment);

                if (isSaveSuccess)
                {
                    MessageBox.Show("Appointment saved successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error while saving the appointment.");
                }
            }
            catch(ArgumentException ex)
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
                throw new ArgumentException("This appointment is outside business hours. Please schedule between 08:00 and 17:00.");
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
                            throw new ArgumentException($"The appointment window of {app.Start.ToString("MM/dd/yy HH:mm")} - {app.End.ToString("MM/dd/yy HH:mm")} is already booked for user: {this.userComboBox.Text}");
                        }
                }
            }
        }

    }
}
