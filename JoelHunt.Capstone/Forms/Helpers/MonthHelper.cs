using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.Capstone.Forms.Helpers
{
    public static class MonthHelper
    {
        public static List<Month> monthList = new List<Month>()
        {
            new Month {Id = 1, MonthName = "January"},
            new Month {Id = 2, MonthName = "February"},
            new Month {Id = 3, MonthName = "March"},
            new Month {Id = 4, MonthName = "April"},
            new Month {Id = 5, MonthName = "May"},
            new Month {Id = 6, MonthName = "June"},
            new Month {Id = 7, MonthName = "July"},
            new Month {Id = 8, MonthName = "August"},
            new Month {Id = 9, MonthName = "September"},
            new Month {Id = 10, MonthName = "October"},
            new Month {Id = 11, MonthName = "November"},
            new Month {Id = 12, MonthName = "December"}
        };

        public class Month
        {
            public int Id { get; set; }
            public string MonthName { get; set; }
        }
    }
}
