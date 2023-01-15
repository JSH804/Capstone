﻿using JoelHunt.C969.PA.Forms.ViewModels;
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
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT customer.customerId, customer.customerName, ");
                sql.Append("address.phone, ");
                sql.Append("city.city, ");
                sql.Append("country.country ");
                sql.Append("from customer ");
                sql.Append("INNER JOIN address ON address.addressId = customer.addressId ");
                sql.Append("INNER JOIN city ON city.cityId = address.cityId ");
                sql.Append("INNER JOIN country ON country.countryId = city.countryId ");

                MySqlCommand cmd = new MySqlCommand(sql.ToString(), mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customers.Add(new CustomerListModel
                        {
                            CustomerId = (int)reader["customerId"],
                            CustomerName = (string)reader["customerName"],
                            Phone = (string)reader["phone"],
                            CityName = (string)reader["city"],
                            CountryName = (string)reader["country"]
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

        public List<CustomerDropDown> GetCustomerDropDown()
        {
            try
            {
                mySqlConnection.Open();

                string sql = "SELECT customerId, customerName FROM customer";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<CustomerDropDown> customers = new List<CustomerDropDown>();

                while (reader.Read())
                {
                    customers.Add(new CustomerDropDown
                    {
                        Id = (int)reader["customerId"],
                        Name = (string)reader["customerName"]
                    });
                }

                return customers;
            }
            catch (Exception)
            {
                Console.WriteLine("Error getting customer drop down.");
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
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
                    customer.CountryId = (int)reader["countryId"];
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

        public bool UpdateCustomer(CustomerProfileModel customer)
        {
            try
            {
                mySqlConnection.Open();

                string sql = $"UPDATE customer SET customerName = '{customer.CustomerName}' WHERE customerId = {customer.CustomerId};";

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                }

                reader.Close();

                sql = $"UPDATE address SET address = '{customer.AddressOne}', postalCode = '{customer.PostalCode}', phone = '{customer.Phone}' WHERE addressId = {customer.AddressId};";

                cmd = new MySqlCommand(sql, mySqlConnection);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                }

                reader.Close();

                sql = $"UPDATE city SET city = '{customer.CityName}' WHERE cityId = {customer.CityId};";

                cmd = new MySqlCommand(sql, mySqlConnection);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                }

                reader.Close();

                sql = $"UPDATE country SET country = '{customer.CountryName}' WHERE countryId = {customer.CountryId};";

                cmd = new MySqlCommand(sql, mySqlConnection);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                }

                reader.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updateint the customer: {ex}");
                return false;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}
