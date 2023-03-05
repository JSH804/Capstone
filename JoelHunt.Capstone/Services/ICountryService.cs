using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.Capstone.Models;

namespace JoelHunt.Capstone.Services
{
    public interface ICountryService
    {
        int CreateCountry(Country country);
        //int CountryExist(string countryName, out int countryId);
        //DataTable GetCountries();
    }
}
