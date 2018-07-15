using System.Collections.Generic;
using guacamole.Domain.EntityModels.Main;

namespace guacamole.Domain.Iterfaces.IRepositories.Main
{
    public interface IUserRepository
    {
         List<user> Get();
    }
}