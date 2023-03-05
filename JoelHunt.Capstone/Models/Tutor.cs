using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.Capstone.Models
{
    public class Tutor
    {

        public Tutor()
        {
        }

        public Tutor(int tutorId, string userName, string password, string tutorName, bool isAdmin)
        {
            this.TutorId = TutorId;
            this.UserName = userName;
            this.Password = password;
            this.TutorName = tutorName;
            this.IsAdmin = isAdmin;
        }

        public int TutorId { get; set; }
        public string TutorName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal Rate { get; set; }
        public bool IsAdmin { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastUpdate { get; set;}
        public DateTimeOffset LastUpdateBy { get; set; }
    }
}
