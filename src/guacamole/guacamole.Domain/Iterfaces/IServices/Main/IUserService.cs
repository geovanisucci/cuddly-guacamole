using System.Collections.Generic;
using guacamole.Domain.EntityModels.Main;

namespace guacamole.Domain.Iterfaces.IServices.Main
{
    public interface IUserService
    {
         List<user> Get();
    }
}