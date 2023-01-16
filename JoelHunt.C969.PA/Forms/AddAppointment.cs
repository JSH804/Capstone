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
            this.startDatePicker.Format = DateTimePickerFormat.Time;
            this.endDatePicker.Format = DateTimePickerFormat.Time;

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
            int.TryParse(this.customerComboBox.SelectedValue.ToString(), out int customerId);
            int.TryParse(this.userComboBox.SelectedValue.ToString(), out int userId);

            Appointment appointment = new Appointment()
            {
                CustomerId = customerId,
                UserId = userId,
                Type = this.appTypeTextBox.Text,
                Start = this.startDatePicker.Value,
                Stop = this.endDatePicker.Value,
                CreatedBy = this.activeUser.UserName,
                LastUpdateBy = this.activeUser.UserName
            };

            bool isSaveSuccess = this.appointmentService.AddAppointment(appointment);

            if (isSaveSuccess)
            {
                MessageBox.Show("Appointment saved successfully.");
            }
            else
            {
                MessageBox.Show("Error while saving the appointment.");
            }

        }
    }
}
