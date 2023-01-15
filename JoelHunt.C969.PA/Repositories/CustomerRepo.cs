using JoelHunt.C969.PA.Forms.ViewModels;
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
    public class CustomerRepo : ICustomerService
    {
        private readonly MySqlConnection mySqlConnection;

        public CustomerRepo(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                this.mySqlConnection.Open();
                MySqlCommand cmd = mySqlConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO customer(customerName,addressId,active,createDate,createdBy,lastUpdate,lastUpdateBy)VALUES(@customerName,@addressId,@active,@date,@user,@date,@user)";
                cmd.Parameters.AddWithValue("@customerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@addressId", customer.AddressId);
                cmd.Parameters.AddWithValue("@active", customer.Active);
                cmd.Parameters.AddWithValue("@user", customer.CreatedBy);
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error while savng the customer");
                throw;
            }
            finally
            {
                this.mySqlConnection.Close();
            }
        }

        public List<CustomerListModel> GetCustomerList()
        {
            List<CustomerListModel> customers = new List<CustomerListModel>();

            try
            {
                mySqlConnection.Open();
                string sql = $"SELECT customerId,customerName,createDate FROM customer";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        customers.Add(new CustomerListModel
                        {
                            Id = (int)dataReader["customerId"],
                            Name = (string)dataReader["customerName"],
                            CreateDate = (DateTime)dataReader["createDate"]
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

            return customers;
        }

        public CustomerProfileModel GetCustomerProfile(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT customer.customerId, customer.customerName, ");
                sql.Append("address.addressId, address.address, address.postalCode, address.phone, ");
                sql.Append("city.cityId, city.city, ");
                sql.Append("country.countryId, country.country ");
                sql.Append("from customer ");
                sql.Append("INNER JOIN address ON address.addressId = customer.addressId ");
                sql.Append("INNER JOIN city ON city.cityId = address.cityId ");
                sql.Append("INNER JOIN country ON country.countryId = city.countryId ");
                sql.Append($"where customer.customerId = {id}");


                mySqlConnection.Open();

                MySqlCommand cmd = new MySqlCommand(sql.ToString(), mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                CustomerProfileModel customer = new CustomerProfileModel();

                while (reader.Read())
                {
                    customer.CustomerId = (int)reader["customerId"];
                    customer.CustomerName = (string)reader["customerName"];
                    customer.AddressId = (int)reader["addressId"];
                    customer.AddressOne = (string)reader["address"];
                    customer.PostalCode = (string)reader["postalCode"];
                    customer.Phone = (string)reader["phone"];
                    customer.CityId = (int)reader["cityId"];
                    customer.CityName = (string)reader["city"];
                    customer.CountryId = (int)reader["cityId"];
                    customer.CountryName = (string)reader["country"];
                }

                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting the customer profile {ex}");
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}
