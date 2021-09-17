using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.DTO.Response;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserServices(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<bool>> Add(NewUserRequestModel newUserRequestModel)
        {
            try
            {
                User entity = new User();

                entity.Name = newUserRequestModel.Name;
                entity.SureName = newUserRequestModel.SureName;
                entity.UserName = newUserRequestModel.UserName;
                entity.Password = newUserRequestModel.Password;

                var user = await _userRepository.Add(entity);

                return new ServiceResponse<bool>()
                {
                     Value = user != null,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<ServiceResponse<string>> Login(string UserName, string Password)
        {
            //db user verify
            try
            {

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"].ToString()));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(int.Parse(_configuration["JwtExpireInDays"].ToString()));
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,UserName)
                };

                var token = new JwtSecurityToken(_configuration["JwtIssuer"], _configuration["JwtAudience"], claims, null, expiry, creds);
                String tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

                return Task.FromResult(new ServiceResponse<string>()
                {
                    Value = tokenStr,
                });
            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
