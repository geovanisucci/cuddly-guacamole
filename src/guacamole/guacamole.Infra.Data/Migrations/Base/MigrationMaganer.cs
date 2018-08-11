using System;
using System.Data;
using System.IO;
using guacamole.Domain.Iterfaces.IMigrations;
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
        public void CreateDatabase () {
            using (var cmd = _connection.CreateCommand ()) {
                cmd.CommandText = $"create database if not exists `{DatabaseName}`";
                cmd.ExecuteNonQuery ();
            }
        }

        public void CreateHistory () {
            throw new System.NotImplementedException ();
        }

        public string LoadScript (string path) {
            throw new System.NotImplementedException ();
        }

        public void Migrate () {
            throw new System.NotImplementedException ();
        }

        public void VerifyHistory (out bool canApply) {
            throw new System.NotImplementedException ();
        }

        internal string GetConnectionString (string settingName) {
            var builder = new ConfigurationBuilder ().SetBasePath (Directory.GetCurrentDirectory ()).AddJsonFile ("appsettings.json");
            var config = builder.Build ();
            return config[settingName];
        }

        public void Dispose () {
            GC.SuppressFinalize (this);
            if (_connection != null) {
                if (_connection.State != ConnectionState.Closed) {
                    _connection.Close ();
                }
            }
        }
    }
}