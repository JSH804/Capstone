using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.Capstone.Forms.ViewModels
{
    public class AppointmentListModel
    {
        [DisplayName("Id")]
        public int AppointmentId { get; set; }
        [DisplayName("Customer")]
        public string CustomerName { get; set; }
        [DisplayName("Tutor")]
        public string TutorName { get; set; }
        [DisplayName("Type")]
        public string Type { get; set; }

        [DisplayName("Start Time")]
        public DateTime StartTime
        {
            get { return this.startTime; }
            set { this.startTime = TimeZone.CurrentTimeZone.ToLocalTime(value); }
        }

        [DisplayName("End Time")]
        public DateTime EndTime
        {
            get { return this.endTime; }
            set { this.endTime = TimeZone.CurrentTimeZone.ToLocalTime(value); }
        }

        private DateTime endTime;

        private DateTime startTime;
    }
}
