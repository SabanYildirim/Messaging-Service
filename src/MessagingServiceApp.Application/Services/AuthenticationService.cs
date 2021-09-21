using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.DTO.Response;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Common.Utilities;
using MessagingServiceApp.Infrastructure.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserServices _userService;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserServices userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public async Task<UserLoginResponse> Login(string username,string password)
        {
            try
            {
                UserModel user = _userService.GetUserByUsername(username).GetAwaiter().GetResult();

                if (user == null || user.Password != password)
                    throw new Exception("User not found or given information is wrong");

                if (!user.IsActive)
                    throw new Exception("User state is Passive!");

                var token = new JwtToken().GenerateToken(username, _configuration["JwtSecurityKey"].ToString(), _configuration["JwtExpireInDays"].ToString(), _configuration["JwtAudience"], _configuration["JwtIssuer"]);

                return new UserLoginResponse()
                {
                    token = token
                };
            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
