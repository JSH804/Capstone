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

            this.startDatePicker.CustomFormat = "hh:mm tt";
            this.endDatePicker.CustomFormat = "hh:mm tt";

            this.startDatePicker.Format = DateTimePickerFormat.Custom;
            this.endDatePicker.Format = DateTimePickerFormat.Custom;

            string[] typeArray = new[] { "Presentation", "Scrum", "Car Talk" };

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

                if (this.startDatePicker.Value > this.endDatePicker.Value)
                {
                    throw new ArgumentException("The end time cannot be before the start date!");
                }

                int.TryParse(this.customerComboBox.SelectedValue.ToString(), out int customerId);
                int.TryParse(this.userComboBox.SelectedValue.ToString(), out int userId);

                Appointment appointment = new Appointment()
                {
                    CustomerId = customerId,
                    UserId = userId,
                    Type = this.appTypeComboBox.Text,
                    Start = this.appCalendar.SelectionStart.AddHours(startTime.Hour).AddMinutes(startTime.Minute),
                    Stop = this.appCalendar.SelectionStart.AddHours(endTime.Hour).AddMinutes(endTime.Minute),
                    CreatedBy = this.activeUser.UserName,
                    LastUpdateBy = this.activeUser.UserName
                };

                CheckIfInsideBusinessHours(startTime, endTime);
                CheckForOverlaps(appointment);

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

        private void CheckIfInsideBusinessHours(DateTimeOffset startTime, DateTimeOffset stopTime)
        {
            DateTimeOffset amInsideBusinessHoursStart = new DateTimeOffset(startTime.Year, startTime.Month, startTime.Day, 8, 0, 0, startTime.Offset);
            DateTimeOffset pmOutsideBusinessHoursEnd = new DateTimeOffset(startTime.Year, startTime.Month, startTime.Day, 17, 0, 0, startTime.Offset);
            if (!(amInsideBusinessHoursStart < startTime) || !(pmOutsideBusinessHoursEnd >= stopTime))
            {
                throw new ArgumentException("This appointment is outside business hours. Please schedule between 8am and 5pm.");
            }
        }

        private void CheckForOverlaps(Appointment appointment)
        {
            List<AppointmentIdentificationModel> apps = this.appointmentService.GetAppointmentIdentificationModels();
            int.TryParse(this.userComboBox.SelectedValue.ToString(), out int userId);
            foreach (var app in apps)
            {             
                if (app.UserId == userId)
                {
                    if (app.Start >= appointment.Start && app.End <= appointment.Stop)
                    {
                        throw new ArgumentException($"The appointment window of {app.Start.ToString("MM/dd/yy hh:mm")} - {app.End.ToString("MM/dd/yy hh:mm")} is already booked for user: {this.userComboBox.Text}");
                    }
                }
            }
        }
    }
}
