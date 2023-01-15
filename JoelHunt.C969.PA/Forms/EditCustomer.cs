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
    public partial class EditCustomer : Form
    {

        private readonly ICustomerService customerService;
        private readonly User activeUser;
        private CustomerProfileModel customer;

        public EditCustomer(RepoControl repo, User activeUser, int id)
        {
            this.customerService = repo.Customers;
            this.activeUser = activeUser;

            InitializeComponent();
            GetCustomerForForm(id);
        }

        private void GetCustomerForForm(int id)
        {
            this.customer = this.customerService.GetCustomerProfile(id);

            this.customerNameTextBox.Text =  this.customer.CustomerName;

            this.addressOneTextBox.Text = this.customer.AddressOne;
            this.cityTextBox.Text = this.customer.CityName;
            this.postalCodeTextBox.Text = this.customer.PostalCode;
            this.countryTextBox.Text = this.customer.CountryName;
            this.phoneTextBox.Text = this.customer.Phone;
            this.activeCheckBox.Checked = this.customer.Active;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.customer.CustomerName = this.customerNameTextBox.Text;
            this.customer.AddressOne = this.addressOneTextBox.Text;
            this.customer.CityName = this.cityTextBox.Text;
            this.customer.PostalCode = this.postalCodeTextBox.Text;
            this.customer.CountryName = this.countryTextBox.Text;
            this.customer.Phone = this.phoneTextBox.Text;
            this.customer.Active = this.activeCheckBox.Checked;


        }
    }
}
