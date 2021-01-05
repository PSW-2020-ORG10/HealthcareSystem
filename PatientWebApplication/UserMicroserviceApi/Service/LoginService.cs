﻿using Microsoft.Extensions.Configuration;
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

        public LoginService(MyDbContext context, IConfiguration config)
        {
            _patientRepository = new PatientsRepository(context);
            _administratorRepository = new AdministratorRepository(context);
            _config = config;
        }

        public UserModel AuthenticateUser(UserModel login)
        {
            var admin = _administratorRepository.GetByEmail(login.Email);
            if (admin != null) {
                login.Role = "admin";
                login.Id = admin.id;
                return login;
            }
            var patient = _patientRepository.GetByEmail(login.Email);
            if(patient != null)
            {
                login.Role = "patient";
                login.Id = patient.id;
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
