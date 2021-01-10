using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;

namespace UserMicroserviceApi.Service
{
    public class LoginService
    {
        private IPatientsRepository _patientRepository;
        private IAdministratorRepository _administratorRepository;
        private IConfiguration _config;

        public LoginService(IPatientsRepository patientRepository, IAdministratorRepository administratorRepository, IConfiguration config)
        {
            _patientRepository = patientRepository;
            _administratorRepository = administratorRepository;
            _config = config;
        }

        public LoginService(IPatientsRepository patientRepository, IAdministratorRepository administratorRepository)
        {
            _patientRepository = patientRepository;
            _administratorRepository = administratorRepository;
        }

        public LoginService(MyDbContext context, IConfiguration config)
        {
            _patientRepository = new PatientsRepository(context);
            _administratorRepository = new AdministratorRepository(context);
            _config = config;
        }

        public UserModel AuthenticateUser(UserModel login)
        {
            var admin = FindAdmin(login);
            return admin == null ? FindPatient(login) : admin;
        }

        private UserModel FindAdmin(UserModel login)
        {
            var admin = _administratorRepository.GetByLoginInfo(login);
            if (admin != null)
            {
                login.Role = "admin";
                login.Id = admin.Id;
                return login;
            }
            return null;
        }

        private UserModel FindPatient(UserModel login)
        {
            var patient = _patientRepository.GetByLoginInfo(login);
            if (patient != null)
            {
                login.Role = "patient";
                login.Id = patient.Id;
                return login;
            }
            return null;
        }

        public string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("user_id", userInfo.Id.ToString()),
                new Claim("role", userInfo.Role),
                new Claim (ClaimTypes.Role, userInfo.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
