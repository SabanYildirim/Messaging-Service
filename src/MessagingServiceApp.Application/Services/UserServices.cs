using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Services
{
    public class UserServices : IUserServices
    {
        public UserServices()
        {

        }

        public Task<bool> CreateUser(NewUserRequestModel newUserRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}
