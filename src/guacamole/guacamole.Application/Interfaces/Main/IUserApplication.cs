using System.Collections.Generic;
using guacamole.Domain.EntityModels.Main;

namespace guacamole.Application.Interfaces.Main
{
    public interface IUserApplication
    {
         List<user> Get();
    }
}