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
        private readonly IMessagingMapper _mapper;

        public UserServices(IUserRepository userRepository,
            IMessagingMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<SuccessResponse> Add(NewUserRequestModel newUserRequestModel)
        {
            var userEntity = await _userRepository.GetUserByUsername(newUserRequestModel.Username);
            if (userEntity != null)
            {
                throw new Exception("User found or given information is wrong");
            }

            UserEntity entity = new UserEntity();
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

            var map = _mapper.Map<UserEntity, UserModel>(userEntity);

            return map;
        }
    }
}
