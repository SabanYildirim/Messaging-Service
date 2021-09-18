using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.DTO.Request
{
    public class UserLoginRequestModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
