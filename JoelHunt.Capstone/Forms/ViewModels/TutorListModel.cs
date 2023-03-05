using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.Capstone.Forms.ViewModels
{
    public class TutorListModel
    {
        public int TutorId { get; set; }
        [DisplayName("Tutor Name")]
        public string TutorName { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }
        [DisplayName("Hourly Rate")]
        public decimal Rate { get; set; }
    }
}
