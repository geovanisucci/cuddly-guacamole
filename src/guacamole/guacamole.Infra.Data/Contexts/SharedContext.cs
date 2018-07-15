using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.IO;

namespace guacamole.Infra.Data.Contexts
{

    public abstract class SharedContext : IDisposable
    {
        public abstract string ConnectionString { get; }

        public MySqlConnection Connection { get; set; }

        public SharedContext()
        {
            if(Connection == null)
            {
                Connection = new MySqlConnection(ConnectionString);
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
            }
        }

        internal string GetConnectionString(string settingName)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetings.json");
            var config = builder.Build();
            return config[settingName];
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if(Connection != null)
            {
                if(Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }
    }
}