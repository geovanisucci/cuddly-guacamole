using guacamole.Domain.Iterfaces.IMigrations;

namespace guacamole.Cross.Migration
{
    
    public class Migration
    {
        static IMainMigration _migration;

        public Migration(IMainMigration migration)
        {
            migration = _migration;
        }
        public static  void Run(){
            _migration.CreateDatabase();
        }
    }
}