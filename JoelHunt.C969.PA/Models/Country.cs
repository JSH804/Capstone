using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
