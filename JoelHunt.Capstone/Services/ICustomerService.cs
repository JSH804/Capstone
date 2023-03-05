using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Models;

namespace JoelHunt.Capstone.Services
{
    public interface ICustomerService
    {
        bool CreateCustomer(Customer customer);

        List<CustomerListModel> GetCustomerList();

        List<CustomerDropDown> GetCustomerDropDown();

        CustomerProfileModel GetCustomerProfile(int id);

        bool UpdateCustomer(CustomerProfileModel customer);

        bool DeleteAllCustomersRecords(int id);
    }
}
