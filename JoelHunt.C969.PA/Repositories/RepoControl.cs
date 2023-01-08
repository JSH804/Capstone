using JoelHunt.C969.PA.Services.ConfigurationService;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
        }

        private void CreateRepos()
        {
            this.Users = new UserRepo(this.mySqlConnection);
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
        private bool disposed = false;
        private MySqlConnection mySqlConnection;
    }
}
