using JoelHunt.C969.PA.Forms;
using JoelHunt.C969.PA.Forms.ViewModels;
using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Repositories
{
    public class AppointmentRepo : IAppointmentService
    {
        private readonly MySqlConnection mySqlConnection;

        public AppointmentRepo(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }

        public bool AddAppointment(Appointment appointment)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateby)");
                builder.Append("VALUES(@customerId, @userId, 'not needed', 'not needed', 'not needed', 'not needed', @type, 'not needed', @start, @end, @date, @user, @date, @user)");

                mySqlConnection.Open();
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = builder.ToString();

                cmd.Parameters.AddWithValue("@customerId", appointment.CustomerId);
                cmd.Parameters.AddWithValue("@userId", appointment.UserId);
                cmd.Parameters.AddWithValue("@type", appointment.Type);
                cmd.Parameters.AddWithValue("@start", appointment.Start);
                cmd.Parameters.AddWithValue("@end", appointment.Stop);
                cmd.Parameters.AddWithValue("@date", DateTimeOffset.UtcNow);
                cmd.Parameters.AddWithValue("@user", appointment.CreatedBy);

                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while savng the appointment");
                return false;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public List<AppointmentListModel> GetAppointmentListModels(int userId = 0)
        {
            List<AppointmentListModel> appointments = new List<AppointmentListModel>();
            try
            {
                mySqlConnection.Open();
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT customer.customerName, appointment.appointmentId, appointment.type, appointment.start, appointment.end, user.userName ");
                sql.Append("FROM appointment ");
                sql.Append("INNER JOIN user on user.userId = appointment.userId ");
                sql.Append("INNER JOIN customer on customer.customerId = appointment.customerId");

                if(userId != 0)
                {
                    sql.Append($" WHERE appointment.userId = {userId}");
                }

                MySqlCommand cmd = new MySqlCommand(sql.ToString(), mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        appointments.Add(new AppointmentListModel

                        {
                            AppointmentId = (int)reader["appointmentId"],
                            CustomerName = (string)reader["customerName"],
                            UserName = (string)reader["userName"],
                            Type = (string)reader["type"],
                            StartTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)reader["start"], timeZoneInfo),
                            EndTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)reader["end"], timeZoneInfo) 
                        }); ;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting a collection of appointments");
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }

            return appointments;
        }

        public List<AppointmentListReport> GetAppointmentListReport(int userId = 0)
        {
            List<AppointmentListReport> appointments = new List<AppointmentListReport>();
            try
            {
                mySqlConnection.Open();
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT customer.customerName, appointment.appointmentId, appointment.userId, appointment.type, appointment.start, appointment.end, user.userName ");
                sql.Append("FROM appointment ");
                sql.Append("INNER JOIN user on user.userId = appointment.userId ");
                sql.Append("INNER JOIN customer on customer.customerId = appointment.customerId");

                if (userId != 0)
                {
                    sql.Append($" WHERE appointment.userId = {userId}");
                }

                MySqlCommand cmd = new MySqlCommand(sql.ToString(), mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        appointments.Add(new AppointmentListReport

                        {
                            AppointmentId = (int)reader["appointmentId"],
                            CustomerName = (string)reader["customerName"],
                            UserId = (int)reader["userId"],
                            UserName = (string)reader["userName"],
                            Type = (string)reader["type"],
                            StartTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)reader["start"], timeZoneInfo),
                            EndTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)reader["end"], timeZoneInfo)
                        }); ;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting a collection of appointments");
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }

            return appointments;
        }

        public List<AppointmentIdentificationModel> GetAppointmentIdentificationModels()
        {

            List<AppointmentIdentificationModel> appointments = new List<AppointmentIdentificationModel>();
            try
            {
                mySqlConnection.Open();
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT appointment.appointmentId, appointment.start, appointment.end, user.userId ");
                sql.Append("FROM appointment ");
                sql.Append("INNER JOIN user on user.userId = appointment.userId ");

                MySqlCommand cmd = new MySqlCommand(sql.ToString(), mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        appointments.Add(new AppointmentIdentificationModel

                        {
                            AppointmentId = (int)reader["appointmentId"],
                            UserId = (int)reader["userId"],
                            Start = TimeZoneInfo.ConvertTimeFromUtc((DateTime)reader["start"], timeZoneInfo),
                            End = TimeZoneInfo.ConvertTimeFromUtc((DateTime)reader["end"], timeZoneInfo)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting a collection of appointment indentifications");
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
            return appointments;
        }

        public bool UpdateAppointment(Appointment app)
        {
            try
            {
                mySqlConnection.Open();

                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append("UPDATE appointment");
                sqlBuilder.Append($" SET customerId = {app.CustomerId}, userId = {app.UserId}, type = '{app.Type}', start = '{app.Start}', end = '{app.Stop}', lastUpdate = '{app.LastUpdate}', lastUpdateBy = '{app.LastUpdateBy}'");
                sqlBuilder.Append($" WHERE appointmentId = {app.AppointmentId}");

                MySqlCommand cmd = new MySqlCommand(sqlBuilder.ToString(), mySqlConnection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                }

                reader.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating the appointment.");
                return false;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }


       public AppointmentEditModel GetAppointment(int id)
        {
            try
            {
                mySqlConnection.Open();
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT appointmentId, customerId, userId, type, start, end ");
                sql.Append("FROM appointment ");
                sql.Append($"WHERE appointmentId = {id}");


                MySqlCommand cmd = new MySqlCommand(sql.ToString(), mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
                AppointmentEditModel app = new AppointmentEditModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        app.AppointmentId = (int)reader["appointmentId"];
                        app.CustomerId = (int)reader["customerId"];
                        app.UserId = (int)reader["userId"];
                        app.Type = (string)reader["type"];
                        app.Start = TimeZoneInfo.ConvertTimeFromUtc((DateTime)reader["start"], timeZoneInfo);
                        app.End = TimeZoneInfo.ConvertTimeFromUtc((DateTime)reader["end"], timeZoneInfo);
                    }
                }

                return app;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting an appointment to edit");
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public bool DeleteAppointment(int id)
        {
            try
            {
                mySqlConnection.Open();
                string sql = $"DELETE FROM appointment WHERE appointmentId = {id}";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                };

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error deleting the appointment");
                return false;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}
