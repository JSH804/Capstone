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
using System.Drawing;
using System.Windows.Forms;

namespace JoelHunt.C969.PA.Forms
{
    public partial class CreateCustomer : Form
    {
        private readonly ICustomerService customerService;
        private readonly IAddressService addressService;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly User activeUser;
        
        public CreateCustomer(RepoControl repo, User activeUser)
        {
            this.customerService = repo.Customers;
            this.addressService = repo.Addresses;
            this.countryService = repo.Countries;
            this.cityService = repo.Cities;
            this.activeUser = activeUser;
            InitializeComponent();
            createButton.Enabled = false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                int countryId = ProcessCountry();
                int cityId = ProcessCity(countryId);
                int addressId = ProcessAddress(cityId);

                Customer customer = new Customer
                {
                    CustomerName = this.customerNameTextBox.Text,
                    AddressId = addressId,
                    CreatedBy = this.activeUser.UserName
                };

                this.customerService.CreateCustomer(customer);

                MessageBox.Show("Customer created successfully");
                this.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error while saving the customer");
            }
        }

        private int ProcessCountry()
        {
            Country country = new Country()
            {
                CountryName = this.countryTextBox.Text,
                CreatedBy = this.activeUser.UserName,
                LastUpdateBy = this.activeUser.UserName
            };

            return this.countryService.CreateCountry(country);
        }

        private int ProcessCity(int id)
        {
                City city = new City()
                {
                    CityName = this.cityTextBox.Text,
                    CountryId = id,
                    CreatedBy = this.activeUser.UserName,
                };
                return this.cityService.CreateCity(city);
        }

        private int ProcessAddress(int cityId)
        {
            Address address = new Address()
            {
                AddressOne = this.addressOneTextBox.Text,
                CityId = cityId,
                PostalCode = this.postalCodeTextBox.Text,
                Phone = this.phoneTextBox.Text,
                CreatedBy = this.activeUser.UserName,
            };

            return this.addressService.CreateAddress(address);
        }

        private bool CheckIfFormIsValid()
        {
            return !String.IsNullOrWhiteSpace(this.customerNameTextBox.Text) &&
                !String.IsNullOrWhiteSpace(this.addressOneTextBox.Text) &&
                !String.IsNullOrWhiteSpace(this.cityTextBox.Text) &&
                !String.IsNullOrWhiteSpace(this.postalCodeTextBox.Text) &&
                !String.IsNullOrWhiteSpace(this.countryTextBox.Text) &&
                !String.IsNullOrWhiteSpace(this.phoneTextBox.Text) &&
                !String.IsNullOrWhiteSpace(this.cityTextBox.Text);

        }

        private void customerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.customerNameTextBox.Text))
            {
                this.customerNameTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.customerNameTextBox.BackColor = Color.White;
            }

            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private void addressOneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.addressOneTextBox.Text))
            {
                this.addressOneTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.addressOneTextBox.BackColor = Color.White;
            }
            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private void cityTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.cityTextBox.Text))
            {
                this.cityTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.cityTextBox.BackColor = Color.White;
            }
            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private void postalCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.postalCodeTextBox.Text))
            {
                this.postalCodeTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.postalCodeTextBox.BackColor = Color.White;
            }
            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private void countryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.countryTextBox.Text))
            {
                this.countryTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.countryTextBox.BackColor = Color.White;
            }
            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.phoneTextBox.Text))
            {
                this.phoneTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                this.phoneTextBox.BackColor = Color.White;
            }
            this.createButton.Enabled = CheckIfFormIsValid();
        }

        private Customer customer;
        private City city;
        private Country country;
        private List<Control> controlsList = new List<Control>();
    }
}
