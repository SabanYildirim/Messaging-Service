using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.DTO.Response;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities;
using System;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<SuccessResponse> Add(NewUserRequestModel newUserRequestModel)
        {
            var userEntity = await _userRepository.GetUserByUsername(newUserRequestModel.Username);
            if (userEntity != null)
            {
                throw new Exception("User found or given information is wrong");
            }

            User entity = new User();
            entity.Name = newUserRequestModel.Name;
            entity.Surname = newUserRequestModel.Surname;
            entity.UserName = newUserRequestModel.Username;
            entity.Password = newUserRequestModel.Password;
            entity.IsActive = true;
            entity.CreateDate = DateTime.Now;

            var user = await _userRepository.Add(entity);

            return new SuccessResponse()
            {
                Success = user != null,
            };
        }

        public async Task<UserModel> GetUserByUsername(string username)
        {
            var userEntity = await _userRepository.GetUserByUsername(username);

            if (userEntity == null)
            {
                return null;
            }

            UserModel userModel = new UserModel();

            userModel.Name = userEntity.Name;
            userModel.Surname = userEntity.Surname;
            userModel.Password = userEntity.Password;
            userModel.IsActive = userEntity.IsActive;

            return userModel;
        }
    }
}
