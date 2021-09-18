using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.DTO.Request
{
    public class UserSenderMessageRequestModel
    {
        public string ReceiverUserName { get; set; }
        public string Message { get; set; }
    }
}
