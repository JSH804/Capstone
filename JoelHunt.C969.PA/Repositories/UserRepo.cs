using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.C969.PA.Forms.ViewModels;
using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Services;
using JoelHunt.C969.PA.Services.ConfigurationService;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace JoelHunt.C969.PA.Repositories
{
    public class UserRepo : IUserService
    {
        private readonly MySqlConnection mySqlConnection;

        public UserRepo(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }

        public void AddTestUser()
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = $"INSERT INTO user(userName,password,active,createDate,createdBy,lastUpdate,lastUpdateBy)VALUES('test','test', true, @date, 'system', @date, 'system')";
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();

                mySqlConnection.Open();
                cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = $"INSERT INTO user(userName,password,active,createDate,createdBy,lastUpdate,lastUpdateBy)VALUES('wgu','wgu', true, @date, 'system', @date, 'system')";
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if(mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }

        public User VerifyAndGetUser(string username, string password)
        {
            try
            {
                mySqlConnection.Open();
                User user = null;
                string sql = $"SELECT * FROM user WHERE username = '{username}' AND password = '{password}'";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    int userId = (int)reader["userId"];
                    string userName = reader["userName"].ToString();
                    string userPassword = reader["password"].ToString();

                    user = new User(userId, userName, userPassword);
                }

                if(!ReferenceEquals(user, null))
                {
                    Console.WriteLine("User had a value");
                    return user;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("User did not exist");
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public List<UserDropDown> GetUserDropDown()
        {
            try
            {
                mySqlConnection.Open();

                string sql = "SELECT userId, userName FROM user";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<UserDropDown> customers = new List<UserDropDown>();

                while (reader.Read())
                {
                    customers.Add(new UserDropDown
                    {
                        Id = (int)reader["userId"],
                        Name = (string)reader["userName"]
                    });
                }

                return customers;
            }
            catch (Exception)
            {
                Console.WriteLine("Error getting user drop down.");
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }


    }
}
