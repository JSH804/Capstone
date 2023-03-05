using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.Capstone.Models;

namespace JoelHunt.Capstone.Services
{
    public interface ICityService
    {
        int CreateCity(City city);
        City GetCity(int id);
        //int CityExist(string cityName, int countryId);
    }
}
