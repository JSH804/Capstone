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
                cmd.CommandText = "INSERT INTO address(address,address2,cityId,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy)VALUES(@address,@addressTwo,@cityId,@postalCode,@phone,@date,@user,@date,@user)";
                cmd.Parameters.AddWithValue("@address", address.AddressOne);
                cmd.Parameters.AddWithValue("@addressTwo", "");
                cmd.Parameters.AddWithValue("@cityId", address.CityId);
                cmd.Parameters.AddWithValue("@postalCode", address.PostalCode);
                cmd.Parameters.AddWithValue("@phone", address.Phone);
                cmd.Parameters.AddWithValue("@user", address.CreatedBy);
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);

                cmd.ExecuteNonQuery();

                var lastId = cmd.LastInsertedId;

                return Convert.ToInt32(lastId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while savng the address");
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public Address GetAddress(int id)
        {
            this.mySqlConnection.Open();
            string sql = $"SELECT * FROM address WHERE addressId = '{id}'";

            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                Address address = new Address();

                while (reader.Read())
                {
                    address.AddressId = (int)reader["addressId"];
                    address.AddressOne = (string)reader["addressOne"];
                    address.CityId = (int)reader["cityId"];
                }

                return address;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                this.mySqlConnection.Close();
            }
        }
    }
}
