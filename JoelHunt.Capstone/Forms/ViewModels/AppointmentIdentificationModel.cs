using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.Capstone.Forms.ViewModels
{
    public class AppointmentIdentificationModel
    {
        public int AppointmentId { get; set; }
        public int TutorId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
