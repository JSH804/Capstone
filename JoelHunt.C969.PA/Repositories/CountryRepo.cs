using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            mySqlConnection.Open();
            try
            {
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO country(country,createDate,createdBy,lastUpdate,lastUpdateBy)VALUES(@country,@date,@user,@date,@user)";
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
            finally
            {
                mySqlConnection.Close();
            }

        }

/*        public int CountryExist(string countryName, out int countryId)
        {
            mySqlConnection.Open();
            countryId = 0;
            string sql = $"SELECT countryId WHERE country = {countryName} FROM country";

            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                countryId = (int)reader["countryId"];
            }

            mySqlConnection.Close();
            return countryId;
        }*/

        public Country GetCountry(int id)
        {
            mySqlConnection.Open();
            string sql = $"SELECT * WHERE countryId = {id} FROM country";

            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                Country country = new Country();

                while (reader.Read())
                {
                    country.CountryId = (int)reader["countryId"];
                    country.CountryName = (string)reader["country"];
                    country.CreateDate = (DateTime)reader["createDate"];
                    country.CreatedBy = (string)reader["createdBy"];
                    country.LastUpdate = (DateTime)reader["lastUpdate"];
                    country.LastUpdateBy = (string)reader["lastUpdateBy"];
                }
                return country;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

/*        public DataTable GetCountries()
        {
                mySqlConnection.Open();
                string sql = $"SELECT * FROM country";

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
