using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User VerifyAndGetUser(string username, string password)
        {
            mySqlConnection.Open();
            try
            {
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
    }
}
