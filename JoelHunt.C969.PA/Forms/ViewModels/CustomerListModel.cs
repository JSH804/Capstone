using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Forms.ViewModels
{
    public class CustomerListModel
    {
        [DisplayName("Id")]
        public int CustomerId { get; set; }
        [DisplayName("Name")]
        public string CustomerName { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [DisplayName("City")]
        public string CityName { get; set; }
        [DisplayName("Country")]
        public string CountryName { get; set; }
    }
}
