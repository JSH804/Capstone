using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Repositories
{
    public class CustomerRepo : ICustomerService
    {
        private readonly MySqlConnection mySqlConnection;

        public CustomerRepo(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO customer(customerName,addressId,active,createDate,createBy)VALUES(@customerName,@addressId,@active,@user,@date)";
                cmd.Parameters.AddWithValue("@customerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@addressId", customer.AddressId);
                cmd.Parameters.AddWithValue("@active", customer.Active);
                cmd.Parameters.AddWithValue("@user", customer.CreatedBy);
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error while savng the customer");
                throw;
            }
        }
    }
}
