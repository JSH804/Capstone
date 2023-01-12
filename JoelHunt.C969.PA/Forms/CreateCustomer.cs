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

            this.countryComboBox.DataSource = this.countryService.GetCountries();
            this.countryComboBox.DisplayMember = "country";
            this.countryComboBox.ValueMember = "countryId";
        }

        private void AddControls()
        {
            controlsList.Add(this.customerNameTextBox);
            controlsList.Add(this.addressOneTextBox);
            controlsList.Add(this.cityTextBox);
            controlsList.Add(this.postalCodeTextBox);
            controlsList.Add(this.countryComboBox);
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
                int cityId = ProcessCity();
                int addressId = ProcessAddress(cityId);

                Customer customer = new Customer
                {
                    CustomerName = this.customerNameTextBox.Text,
                    AddressId = addressId,
                    Active = this.activeCheckBox.Checked,
                    CreatedBy = this.activeUser.UserName
                };

                MessageBox.Show("Customer created successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error while saving the customer");
            }
        }

        private int ProcessCity()
        {
            int.TryParse(this.countryComboBox.SelectedValue.ToString(), out int countryId);
            int cityId = this.cityService.CityExist(this.cityTextBox.Text, countryId);

            if (cityId == 0)
            {
                City city = new City()
                {
                    CityName = this.cityTextBox.Text,
                    CountryId = countryId,
                    CreatedBy = this.activeUser.UserName,
                };

                cityId = this.cityService.CreateCity(city);
                return cityId;
            }

            return cityId;
        }

        private int ProcessAddress(int cityId)
        {
            Address address = new Address()
            {
                AddressOne = this.addressOneTextBox.Text,
                AddressTwo = this.addressTwoTextBox.Text,
                CityId = cityId,
                PostalCode = this.postalCodeTextBox.Text,
                Phone = this.phoneTextBox.Text,
                CreatedBy = this.activeUser.UserName,
            };

            return this.addressService.CreateAddress(address);
        }


        private void createCountryButton_Click(object sender, EventArgs e)
        {
            CreateCountry createCountry = new CreateCountry(countryService, activeUser);
            createCountry.Show();
        }

        private Customer customer;
        private City city;
        private Country country;
        private List<Control> controlsList = new List<Control>();
    }
}
