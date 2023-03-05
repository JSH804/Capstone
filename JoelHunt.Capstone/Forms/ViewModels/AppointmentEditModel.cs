using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.Capstone.Forms.ViewModels
{
    public class AppointmentEditModel
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }

        public int TutorId { get; set; }

        public string Type { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string LastUpdateBy { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
