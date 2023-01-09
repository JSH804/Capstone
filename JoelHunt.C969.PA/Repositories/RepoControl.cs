using JoelHunt.C969.PA.Services.ConfigurationService;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace JoelHunt.C969.PA.Repositories
{
    public class RepoControl : IDisposable
    {
        public RepoControl(Configurations configs)
        {
            InitDbConnection(configs);
            CreateRepos();
        }

        ~RepoControl()
        {
            Dispose(false);
        }

        protected void InitDbConnection(Configurations configs)
        {
            this.mySqlConnection = new MySqlConnection(configs.SqlDBConnectionString);
            try
            {
                Console.WriteLine("Opening connection to the database");
                this.mySqlConnection.Open();
                Console.WriteLine("Successfully connected to the database");
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured trying to connect to the database.");
            }

        }

        private void CreateRepos()
        {
            this.Users = new UserRepo(this.mySqlConnection);
            this.Addresses = new AddressRepo(this.mySqlConnection);
            this.Customers = new CustomerRepo(this.mySqlConnection);
            this.Cities = new CityRepo(this.mySqlConnection);
            this.Countries = new CountryRepo(this.mySqlConnection);
            this.Appointments = new AppointmentRepo(this.mySqlConnection);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if (disposing)
                {
                    CloseDbConnection();
                }

                disposed = true;
            }

        }

        private void CloseDbConnection()
        {
            if(this.mySqlConnection.State == ConnectionState.Open)
            {
                this.mySqlConnection.Close();
            }
        }

        public UserRepo Users { get; private set; }
        public CustomerRepo Customers { get; set; }
        public AddressRepo Addresses { get; set; }
        public CityRepo Cities { get; set; }
        public CountryRepo Countries { get; set; }
        public AppointmentRepo Appointments { get; set; }

        private bool disposed = false;
        private MySqlConnection mySqlConnection;
    }
}
