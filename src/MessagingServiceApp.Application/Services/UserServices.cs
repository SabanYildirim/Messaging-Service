using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<bool> Add(NewUserRequestModel newUserRequestModel)
        {
            try
            {
                User entity = new User();

                entity.Name = newUserRequestModel.Name;
                entity.SureName = newUserRequestModel.SurName;
                entity.UserName = newUserRequestModel.UserName;
                entity.Password = newUserRequestModel.Password;

                var user = _userRepository.Add(entity);

                return Task.FromResult(user != null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
