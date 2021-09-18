using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.DTO.Response;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Common.Utilities;
using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
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

        public async Task<ServiceResponse<UserLoginResponse>> Login(UserLoginRequestModel userLoginReques)
        {
            try
            {
                var dbUser = await _userRepository.GetAll();

                var user = dbUser.FirstOrDefault(i => i.UserName == userLoginReques.username && i.Password == userLoginReques.password);

                if (user == null)
                    throw new Exception("User not found or given information is wrong");

                if (!user.IsActive)
                    throw new Exception("User state is Passive!");

                var token = new JwtToken().GenerateToken(userLoginReques.username, _configuration["JwtSecurityKey"].ToString(), _configuration["JwtExpireInDays"].ToString(), _configuration["JwtAudience"], _configuration["JwtIssuer"]);

                return new ServiceResponse<UserLoginResponse>()
                {
                    Value = new UserLoginResponse
                    {
                        token = token,
                    },
                };
            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
