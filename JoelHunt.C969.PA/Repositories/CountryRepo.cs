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
    public class CountryRepo : ICountryService
    {
        private readonly MySqlConnection mySqlConnection;

        public CountryRepo(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }

        public int CreateCountry(Country country)
        {
            try
            {
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO country(country,createDate,createBy)VALUES(@country,@user,@date)";
                cmd.Parameters.AddWithValue("@country", country.CountryName);
                cmd.Parameters.AddWithValue("@user", country.CreatedBy);
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);

                cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.LastInsertedId);
            }
            catch (Exception)
            {
                Console.WriteLine("Error while savng the country");
                throw;
            }
        }

        public int CountryExist(string countryName, out int countryId)
        {
            countryId = 0;
            string sql = $"SELECT countryId WHERE country = {countryName} FROM country";

            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                countryId = (int)reader["countryId"];
            }

            return countryId;
        }
    }
}
