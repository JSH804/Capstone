using JoelHunt.C969.PA.Models;
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
    public partial class CreateCountry : Form
    {
        private readonly ICountryService countryService;
        private readonly User activeUser;

        public CreateCountry(ICountryService countryService, User user)
        {
            this.countryService = countryService;
            this.activeUser = user;
            InitializeComponent();
        }

        private void createCountryButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(this.countryTextBox.Text))
            {
                Country newCountry = new Country()
                {
                    CountryName = this.countryTextBox.Text,
                    CreatedBy = this.activeUser.UserName,
                    CreateDate = DateTime.UtcNow
                };

                this.countryService.CountryExist(newCountry.CountryName, out int id);

                if (id != 0)
                {
                    try
                    {
                        this.countryService.CreateCountry(newCountry);
                        MessageBox.Show("Successfully added the country");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error adding the country");
                    }
                }
                else
                {
                    MessageBox.Show("That country already exist");
                }
            }
            else
            {
                MessageBox.Show("Country name is required!");
            }

        }
    }
}
