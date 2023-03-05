using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.Capstone.Forms.ViewModels
{
    public class AppointmentListFinancialReport: AppointmentListReport
    {
        public AppointmentListFinancialReport(AppointmentListReport report) : base()
        {
            this.AppointmentId = report.AppointmentId;
            this.CustomerName = report.CustomerName;
            this.TutorId = report.TutorId;
            this.Type = report.Type;
            this.StartTime = report.StartTime;
            this.EndTime = report.EndTime;
        }

        [DisplayName("Duration")]
        public string Duration
        {
            get 
            {

                TimeSpan diff = EndTime.Subtract(StartTime);
                return $"{diff.TotalHours}"; 
            }
        }

        [DisplayName("Revenue")]
        public decimal Revenue
        {
            get { return revenue; }
            set { revenue = value * (Decimal)EndTime.Subtract(StartTime).TotalHours; }
        }

        private decimal revenue;
    }
}
