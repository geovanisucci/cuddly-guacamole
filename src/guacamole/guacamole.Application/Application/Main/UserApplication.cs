using System.Collections.Generic;
using guacamole.Application.Interfaces.Main;
using guacamole.Domain.EntityModels.Main;
using guacamole.Domain.Iterfaces.IServices.Main;

namespace guacamole.Application.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _userService;

        public UserApplication(IUserService userService)
        {
            _userService = userService;
        }
 

        public List<user> Get()
        {
            return _userService.Get();
        }
    }
}