using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Models
{
    public class User
    {

        public User(int userId, string userName, string password)
        {
            this.UserId = UserId;
            this.UserName = userName;
            this.Password = password;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set;}
        public DateTime LastUpdateBy { get; set; }
    }
}
