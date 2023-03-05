using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.Capstone.Services.ConfigurationService;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Models;
using JoelHunt.Capstone.Services;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace JoelHunt.Capstone.Repositories
{
    public class TutorRepo : ITutorService
    {
        private readonly MySqlConnection mySqlConnection;

        public TutorRepo(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }

        public void AddTestTutor()
        {
            try
            {
                if (mySqlConnection.State != ConnectionState.Open)
                {
                    mySqlConnection.Open();
                }

                string sql = "SELECT tutorId FROM tutor";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<int> tutorCheck = new List<int>();

                while (reader.Read())
                {
                    tutorCheck.Add((int)reader["tutorId"]);
                }

                mySqlConnection.Close();

                if (!(tutorCheck.Count > 0))
                {
                    mySqlConnection.Open();
                    cmd = mySqlConnection.CreateCommand();
                    cmd.CommandText = $"INSERT INTO tutor(tutorName,userName,password,isAdmin,rate,createDate,createdBy,lastUpdate,lastUpdateBy)VALUES('John Doe','admin', 'admin', true, '20.00', @date, 'system', @date, 'system')";
                    cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);
                    cmd.ExecuteNonQuery();
                    mySqlConnection.Close();
                }
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

        public Tutor VerifyAndGetTutor(string username, string password)
        {
            try
            {
                mySqlConnection.Open();
                Tutor tutor = null;
                string sql = $"SELECT * FROM tutor WHERE userName = '{username}' AND password = '{password}'";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int tutorId = (int)reader["tutorId"];
                    string userName = reader["userName"].ToString();
                    string tutorName = (string)reader["tutorName"];
                    bool isAdmin = reader.GetBoolean(reader.GetOrdinal("isAdmin"));
                    string tutorPassword = reader["password"].ToString();

                    tutor = new Tutor(tutorId, username, tutorPassword , tutorName, isAdmin);
                }

                if(!ReferenceEquals(tutor, null))
                {
                    Console.WriteLine("Tutor had a value");
                    return tutor;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Tutor did not exist");
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public List<TutorDropDown> GetTutorDropDown()
        {
            try
            {
                mySqlConnection.Open();

                string sql = "SELECT tutorId, tutorName FROM tutor";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<TutorDropDown> customers = new List<TutorDropDown>();

                while (reader.Read())
                {
                    customers.Add(new TutorDropDown
                    {
                        Id = (int)reader["tutorId"],
                        Name = (string)reader["tutorName"]
                    });
                }

                return customers;
            }
            catch (Exception)
            {
                Console.WriteLine("Error getting tutor drop down.");
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public List<TutorListModel> GetTutors()
        {
            List<TutorListModel> tutors = new List<TutorListModel>();
            
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT * FROM tutor";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tutors.Add(new TutorListModel
                        {
                            TutorId = (int)reader["tutorId"],
                            TutorName = (string)reader["tutorName"],
                            UserName = (string)reader["userName"],
                            IsAdmin = reader.GetBoolean(reader.GetOrdinal("isAdmin")),
                            Rate = (decimal)reader["rate"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }

            return tutors;
        }

        public Tutor GetTutor(int id)
        {
            try
            {
                mySqlConnection.Open();
                string sql = $"SELECT * FROM tutor WHERE tutorId = {id}";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();
                Tutor tutor = new Tutor();
                while (reader.Read())
                {


                    tutor.TutorId = (int)reader["tutorId"];
                    tutor.TutorName = (string)reader["tutorName"];
                    tutor.UserName = (string)reader["userName"];
                    tutor.Password = (string)reader["password"];
                    tutor.IsAdmin = reader.GetBoolean(reader.GetOrdinal("isAdmin"));
                    tutor.Rate = (decimal)reader["rate"];

                }

                return tutor;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public void AddTutor(Tutor tutor)
        {
            try
            {

                mySqlConnection.Open();

                string sql = $"SELECT tutorId FROM tutor WHERE userName = '{tutor.UserName}'";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<int> tutorCheck = new List<int>();

                while (reader.Read())
                {
                    tutorCheck.Add((int)reader["tutorId"]);
                }

                this.mySqlConnection.Close();

                if((tutorCheck.Count == 0))
                {
                    this.mySqlConnection.Open();
                    cmd = mySqlConnection.CreateCommand();
                    cmd.CommandText = "INSERT INTO tutor(tutorName,userName,password,isAdmin,rate,createDate,createdBy,lastUpdate,lastUpdateBy)VALUES(@tutorName,@userName,@password, @isAdmin, @rate ,@date,@tutor,@date,@tutor)";
                    cmd.Parameters.AddWithValue("@tutorName", tutor.TutorName);
                    cmd.Parameters.AddWithValue("@userName", tutor.UserName);
                    cmd.Parameters.AddWithValue("@password", tutor.Password);
                    cmd.Parameters.AddWithValue("@rate", tutor.Rate);
                    cmd.Parameters.AddWithValue("@isAdmin", tutor.IsAdmin);
                    cmd.Parameters.AddWithValue("@tutor", tutor.CreatedBy);
                    cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new ArgumentException("The username already exist");
                }

            }
            catch(ArgumentException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while savng the tutor");
                throw;
            }
            finally
            {
                this.mySqlConnection.Close();
            }
        }

        public void EditTutor(Tutor tutor)
        {
            try
            {
                this.mySqlConnection.Open();

                string sql = $"UPDATE tutor SET tutorName = '{tutor.TutorName}', userName = '{tutor.UserName}', password = '{tutor.Password}', isAdmin = {tutor.IsAdmin}, rate = '{tutor.Rate}' WHERE tutorId = {tutor.TutorId}";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                }

                reader.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error while savng the tutor");
                throw;
            }
            finally
            {
                this.mySqlConnection.Close();
            }
        }

        public bool DeleteTutor(int tutorId)
        {
            try
            {
                this.mySqlConnection.Open();

                string sql = $"DELETE tutor FROM tutor WHERE tutorId = {tutorId}";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                }

                reader.Close();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error while deleting the tutor");
                return false;
            }
            finally
            {
                this.mySqlConnection.Close();
            }
        }

    }
}
