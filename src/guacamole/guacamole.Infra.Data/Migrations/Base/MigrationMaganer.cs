using System;
using System.Data;
using System.IO;
using guacamole.Domain.Iterfaces.IMigrations;
using guacamole.Domain.Iterfaces.IMigrations.Base;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace guacamole.Infra.Data.Migrations.Base {
    public abstract class MigrationMaganer : IMigrationManager, IDisposable {

        private MySqlConnection _connection;
        public abstract string SettingNameConnectionString { get; }
        public abstract string DatabaseName { get; }

        public MigrationMaganer () {
            if (_connection == null) {
                _connection = new MySqlConnection (GetConnectionString (SettingNameConnectionString));
                if (_connection.State != ConnectionState.Open) {
                    _connection.Open ();
                }
            }
        }
        public virtual void CreateDatabase () {
            using (var cmd = _connection.CreateCommand ()) {
                cmd.CommandText = $"create database if not exists `{DatabaseName}`";
                cmd.ExecuteNonQuery ();
            }
        }

        public virtual void CreateHistory () {
            throw new System.NotImplementedException ();
        }

        public virtual string LoadScript (string path) {
            throw new System.NotImplementedException ();
        }

        public virtual void Migrate () {
            throw new System.NotImplementedException ();
        }

        public  virtual void VerifyHistory (out bool canApply) {
            throw new System.NotImplementedException ();
        }

        internal string GetConnectionString (string settingName) {
            var builder = new ConfigurationBuilder ().SetBasePath (Directory.GetCurrentDirectory ()).AddJsonFile ("appsettings.json");
            var config = builder.Build ();
            return config[settingName];
        }

        public virtual void Dispose () {
            GC.SuppressFinalize (this);
            if (_connection != null) {
                if (_connection.State != ConnectionState.Closed) {
                    _connection.Close ();
                }
            }
        }
    }
}