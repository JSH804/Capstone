using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.Capstone.Models;
using JoelHunt.Capstone.Services;

namespace JoelHunt.Capstone.Repositories
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
            mySqlConnection.Open();
            try
            {
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO city(city,countryId,createDate,createdBy,lastUpdate,lastUpdateBy)VALUES(@city,@countryId,@date,@tutor,@date,@tutor)";
                cmd.Parameters.AddWithValue("@city", city.CityName);
                cmd.Parameters.AddWithValue("@countryId", city.CountryId);
                cmd.Parameters.AddWithValue("@tutor", city.CreatedBy);
                cmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);

                cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.LastInsertedId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving the city.");
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }

        }

/*        public int CityExist(string cityName, int countryId)
        {
            mySqlConnection.Open();
            int cityId = 0;
            string sql = $"SELECT cityId FROM city WHERE city = '{cityName}' AND countryId = '{countryId}'";

            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cityId = (int)reader["cityId"];
            }

            mySqlConnection.Close();

            return cityId;
        }*/

        public City GetCity(int id)
        {
            try
            {
                mySqlConnection.Open();
                string sql = $"SELECT * FROM city WHERE cityId = '{id}'";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = cmd.ExecuteReader();
                City city = new City();

                while (reader.Read())
                {
                    city.CityId = (int)reader["cityId"];
                    city.CityName = (string)reader["city"];
                    city.CountryId = (int)reader["countryId"];
                    city.CreateDate = (DateTime)reader["createDate"];
                    city.CreatedBy = (string)reader["createdBy"];
                    city.LastUpdate = (DateTime)reader["lastUpdate"];
                    city.LastUpdateBy = (string)reader["lastUpdateBy"];
                }

                return city;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

/*        public DataTable GetCities()
        {
            mySqlConnection.Open();
            string sql = $"SELECT * FROM city";

            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = cmd;

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            mySqlConnection.Close();
            return dataTable;


        }*/
    }
}
