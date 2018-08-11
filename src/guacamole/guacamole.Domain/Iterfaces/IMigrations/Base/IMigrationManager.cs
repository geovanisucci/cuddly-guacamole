namespace guacamole.Domain.Iterfaces.IMigrations.Base
{
    public interface IMigrationManager
    {
         void Migrate();
         void CreateDatabase();
         void CreateHistory();
         void VerifyHistory(out bool canApply);
         string LoadScript(string path);
         void Dispose();
    }
}