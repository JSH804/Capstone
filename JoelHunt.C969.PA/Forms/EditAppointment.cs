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

            this.appCalendar.SelectionStart = this.appointment.Start.LocalDateTime.Date;
            this.startDatePicker.Text = this.appointment.Start.LocalDateTime.ToString("hh:mm tt");
            this.endDatePicker.Text = this.appointment.End.LocalDateTime.ToString("hh:mm tt");

            string[] typeArray = new[] { "Presentation", "Scrum", "Car Talk" };
            this.appTypeComboBox.DataSource = typeArray;

            for (int x = 0; x <= typeArray.Length - 1; x++)
            {
                if(typeArray[0] == this.appointment.Type)
                {
                    this.appTypeComboBox.SelectedIndex = x;
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

            }
            catch (Exception)
            {

                MessageBox.Show("There was an error loading the page.");
            }
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
