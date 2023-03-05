using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.Capstone.Models;

namespace JoelHunt.Capstone.Services
{
    public interface IAddressService
    {
        int CreateAddress(Address address);
        Address GetAddress(int id);
    }
}
