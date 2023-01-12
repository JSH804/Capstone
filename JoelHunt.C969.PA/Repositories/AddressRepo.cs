using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Services;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace JoelHunt.C969.PA.Repositories
{
    public class AddressRepo : IAddressService
    {
        private readonly MySqlConnection mySqlConnection;

        public AddressRepo(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }

        public int CreateAddress(Address address)
        {
            mySqlConnection.Open();
            try
            {
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO address(address,address2,cityId,postalCode,phone,createDate,createBy)VALUES(@country,@address,@addressTwo,@cityId,@postalCode,@phone,@user,@date)";
                cmd.Parameters.AddWithValue("@address", address.AddressOne);
                cmd.Parameters.AddWithValue("@addressTwo", address.AddressTwo);
                cmd.Parameters.AddWithValue("@cityId", address.CityId);
                cmd.Parameters.AddWithValue("@postalCode", address.PostalCode);
                cmd.Parameters.AddWithValue("@phone", address.Phone);
                cmd.Parameters.AddWithValue("@user", address.CreatedBy);
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);

                cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.LastInsertedId);
            }
            catch (Exception)
            {
                Console.WriteLine("Error while savng the address");
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}
