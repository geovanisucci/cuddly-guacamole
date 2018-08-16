using guacamole.Domain.Iterfaces.IMigrations;

namespace guacamole.Infra.Data.Migrations {
    public class MainMigration : Migrations.Base.MigrationMaganer, IMainMigration {
        public override string DatabaseName {
            get { return "guacamoleDb"; }
        }
         public override string SettingNameConnectionString {
            get { return "MySqlConnectionString:MainConnection"; }
        }
    }
}