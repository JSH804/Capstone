using JoelHunt.C969.PA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Services
{
    public interface ICustomerService
    {
        bool CreateCustomer(Customer customer);
    }
}
