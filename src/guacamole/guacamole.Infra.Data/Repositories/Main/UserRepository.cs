using System.Collections.Generic;
using guacamole.Domain.EntityModels.Main;
using guacamole.Domain.Iterfaces.IRepositories.Main;
using guacamole.Infra.Data.Contexts;
using Dapper;

namespace guacamole.Infra.Data.Repositories.Main
{
    public class UserRepository : IUserRepository
    {
        MainContext _context;

        public UserRepository(MainContext context)
        {
            _context = context;
        }
        public List<user> Get()
        {
           return   _context
                    .Connection
                    .Query<user>("Select * From user")
                    .AsList();
        }
    }
}