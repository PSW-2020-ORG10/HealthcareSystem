using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Service;

namespace UserMicroserviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private LoginService loginService;

        public LoginController(IConfiguration config, MyDbContext dbContext)
        {
            _config = config;
            loginService = new LoginService(new PatientsRepository(dbContext), new AdministratorRepository(dbContext), config);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = loginService.AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = loginService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
    }
}
