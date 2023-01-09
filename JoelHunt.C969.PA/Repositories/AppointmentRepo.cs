using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Repositories
{
    public class AppointmentRepo
    {
        private readonly MySqlConnection mySqlConnection;

        public AppointmentRepo(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }
    }
}
