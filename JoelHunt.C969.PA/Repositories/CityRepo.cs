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
    public class CityRepo : ICityService
    {
        private readonly MySqlConnection mySqlConnection;

        public CityRepo(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }

        public int CreateCity(City city)
        {

            try
            {
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO city(city,countryId,createDate,createBy)VALUES(@city,@countryId,@user,@date)";
                cmd.Parameters.AddWithValue("@city", city.CityName);
                cmd.Parameters.AddWithValue("@countryId", city.CountryId);
                cmd.Parameters.AddWithValue("@user", city.CreatedBy);
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);

                cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.LastInsertedId);
            }
            catch (Exception)
            {
                Console.WriteLine("Error while saving the city.");
                throw;
            }

        }

        public int CityExist(string cityName, int countryId)
        {
            int cityId = 0;
            string sql = $"SELECT cityId WHERE city = {cityName} AND countryId = {countryId} FROM city";

            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cityId = (int)reader["cityId"];
            }

            return cityId;
        }
    }
}
