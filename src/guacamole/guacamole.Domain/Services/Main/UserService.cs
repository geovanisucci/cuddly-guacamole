using System.Collections.Generic;
using guacamole.Domain.EntityModels.Main;
using guacamole.Domain.Iterfaces.IRepositories.Main;
using guacamole.Domain.Iterfaces.IServices.Main;

namespace guacamole.Domain.Services.Main
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<user> Get()
        {
            return _userRepository.Get();
        }
    }
}