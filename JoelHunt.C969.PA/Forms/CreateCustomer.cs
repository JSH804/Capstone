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
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessAddress();
                ProcessCustomer();
            }
            catch (Exception)
            {

                throw;
            }

          
        }

        private void ProcessAddress()
        {
            ProcessCountry();
            ProcessCity();
        }

        private void ProcessCountry()
        {
            this.countryService.CountryExist(this.countryTextBox.Text, out int countryId);

            if(countryId == 0)
            {
                this.country = new Country
                {
                    CountryName = this.countryTextBox.Text,
                    CreatedBy = activeUser.UserName
                };

                this.country.CountryId = this.countryService.CreateCountry(this.country);
            }

        }

        private void ProcessCity()
        {

        }

        private void ProcessCustomer()
        {

        }

        private void RemoveAddress()
        {

        }

        private void RemoveCountry()
        {

        }

        private void RemoveCity()
        {

        }



        private Customer customer;
        private City city;
        private Country country;
    }
}
