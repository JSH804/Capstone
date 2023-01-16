using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Forms.ViewModels
{
    public class AppointmentListModel
    {
        [DisplayName("Id")]
        public int AppointmentId { get; set; }
        [DisplayName("Customer")]
        public string CustomerName { get; set; }
        [DisplayName("User")]
        public string UserName { get; set; }
        [DisplayName("Type")]
        public string Type { get; set; }
        [DisplayName("Start Time")]
        public DateTime Start { get; set; }
        [DisplayName("End Time")]
        public DateTime End { get; set; }
    }
}
