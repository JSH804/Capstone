using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.C969.PA.Models;

namespace JoelHunt.C969.PA.Services
{
    public interface IAddressService
    {
        int CreateAddress(Address address, int cityId, User user);
    }
}
