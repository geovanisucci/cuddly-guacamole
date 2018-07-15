namespace guacamole.Infra.Data.Contexts
{
    public class MainContext : SharedContext
    {
        public override string ConnectionString
        {
            get{return GetConnectionString("MySqlConnectionString:MainConnection");}
        }
    }
}