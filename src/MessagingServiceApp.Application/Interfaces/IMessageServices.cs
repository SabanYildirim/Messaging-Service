using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Interfaces
{
    public interface IMessageServices
    {
        Task<ServiceResponse<bool>> SendMessage(UserSenderMessageRequestModel userSenderMessageRequestModel, string sender);
    }
}
