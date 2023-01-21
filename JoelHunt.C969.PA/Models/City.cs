﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
