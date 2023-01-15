using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Forms.ViewModels
{
    class AppointmentAddModel
    {
        public int CustomerId { get; set; }

        public int UserId { get; set; }

        public string Type { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
