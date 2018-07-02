namespace guacamole.Infra.Data.Contexts
{
    public abstract class SharedContext
    {
        public abstract string ConnectionString { get; }
    }
}