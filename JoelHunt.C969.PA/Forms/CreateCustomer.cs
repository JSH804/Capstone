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

        }

        private void AddControls()
        {
            controlsList.Add(this.customerNameTextBox);
            controlsList.Add(this.addressOneTextBox);
            controlsList.Add(this.cityTextBox);
            controlsList.Add(this.postalCodeTextBox);
        }

        private ErrorProvider ValidateControls()
        {
            ErrorProvider errorProvider = new ErrorProvider();
            foreach (Control control in controlsList)
            {
                if (String.IsNullOrWhiteSpace(control.Text))
                {

                    errorProvider.SetError(control, "Required");
                }
            }
            return errorProvider;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            ErrorProvider errorProvider = ValidateControls();

            foreach(Control control in controlsList)
            {
                if (!string.IsNullOrEmpty(errorProvider.GetError(control)))
                {
                    MessageBox.Show("You are missing required fields");
                    return;
                }
            }
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
                Phone = this.phoneLabel.Text,
                CreatedBy = this.activeUser.UserName,
            };

            return this.addressService.CreateAddress(address);
        }


        private Customer customer;
        private City city;
        private Country country;
        private List<Control> controlsList = new List<Control>();
    }
}
