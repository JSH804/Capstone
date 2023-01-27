using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public DateTime CreatedDate { get; set;}
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public DateTime ConvertedStartTimeZoneTime
        {
            get { return this.convertedStartTimeZoneTime;  }
            set { this.convertedStartTimeZoneTime = TimeZone.CurrentTimeZone.ToLocalTime(value); }
        }

        public DateTime ConvertedEndTimeZoneTime
        {
            get { return this.convertedStartTimeZoneTime; }
            set { this.convertedStartTimeZoneTime = TimeZone.CurrentTimeZone.ToLocalTime(value); }
        }

        private DateTime convertedEndTimeZoneTime;

        private DateTime convertedStartTimeZoneTime;
    }
}
