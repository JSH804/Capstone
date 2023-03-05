using JoelHunt.Capstone.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Models;
using JoelHunt.Capstone.Services;

namespace JoelHunt.Capstone.Repositories
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
                builder.Append("INSERT INTO appointment(customerId, tutorId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateby)");
                builder.Append("VALUES(@customerId, @tutorId, 'not needed', 'not needed', 'not needed', 'not needed', @type, 'not needed', @start, @end, @date, @tutor, @date, @tutor)");

                mySqlConnection.Open();
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = builder.ToString();

                cmd.Parameters.AddWithValue("@customerId", appointment.CustomerId);
                cmd.Parameters.AddWithValue("@tutorId", appointment.TutorId);
                cmd.Parameters.AddWithValue("@type", appointment.Type);
                cmd.Parameters.AddWithValue("@start", appointment.Start);
                cmd.Parameters.AddWithValue("@end", appointment.Stop);
                cmd.Parameters.AddWithValue("@date", DateTimeOffset.UtcNow);
                cmd.Parameters.AddWithValue("@tutor", appointment.CreatedBy);

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

        public List<AppointmentListModel> GetAppointmentListModels(int tutorId = 0)
        {
            List<AppointmentListModel> appointments = new List<AppointmentListModel>();
            try
            {
                mySqlConnection.Open();
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT customer.customerName, appointment.appointmentId, appointment.type, appointment.start, appointment.end, tutor.tutorName ");
                sql.Append("FROM appointment ");
                sql.Append("INNER JOIN tutor on tutor.tutorId = appointment.tutorId ");
                sql.Append("INNER JOIN customer on customer.customerId = appointment.customerId");

                if(tutorId != 0)
                {
                    sql.Append($" WHERE appointment.tutorId = {tutorId}");
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
                            TutorName = (string)reader["tutorName"],
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

        public List<AppointmentListReport> GetAppointmentListReport(int tutorId = 0)
        {
            List<AppointmentListReport> appointments = new List<AppointmentListReport>();
            try
            {
                mySqlConnection.Open();
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT customer.customerName, appointment.customerId, appointment.appointmentId, appointment.tutorId, appointment.type, appointment.start, appointment.end, tutor.tutorName ");
                sql.Append("FROM appointment ");
                sql.Append("INNER JOIN tutor on tutor.tutorId = appointment.tutorId ");
                sql.Append("INNER JOIN customer on customer.customerId = appointment.customerId");

                if (tutorId != 0)
                {
                    sql.Append($" WHERE appointment.tutorId = {tutorId}");
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
                            CustomerId = (int)reader["customerId"],
                            TutorId = (int)reader["tutorId"],
                            TutorName = (string)reader["tutorName"],
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

                sql.Append("SELECT appointment.appointmentId, appointment.start, appointment.end, tutor.tutorId ");
                sql.Append("FROM appointment ");
                sql.Append("INNER JOIN tutor on tutor.tutorId = appointment.tutorId ");

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
                            TutorId = (int)reader["tutorId"],
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
                sqlBuilder.Append($" SET customerId = {app.CustomerId}, tutorId = {app.TutorId}, type = '{app.Type}', start = '{app.Start}', end = '{app.Stop}', lastUpdate = '{app.LastUpdate}', lastUpdateBy = '{app.LastUpdateBy}'");
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

                sql.Append("SELECT appointmentId, customerId, tutorId, type, start, end ");
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
                        app.TutorId = (int)reader["tutorId"];
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
