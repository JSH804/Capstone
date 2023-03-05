using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.Capstone.Forms.ViewModels
{
    public class CustomerProfileModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool Active { get; set; }

        public int AddressId { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
