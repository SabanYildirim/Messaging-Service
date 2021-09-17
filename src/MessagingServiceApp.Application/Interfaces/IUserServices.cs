using MessagingServiceApp.Application.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Interfaces
{
    public interface IUserServices
    {
        Task<bool> CreateUser(NewUserRequestModel newUserRequestModel);
    }
}
