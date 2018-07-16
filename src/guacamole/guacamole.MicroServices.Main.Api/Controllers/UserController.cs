using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guacamole.Application.Interfaces.Main;
using Microsoft.AspNetCore.Mvc;

namespace guacamole.MicroServices.Main.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
    }
}