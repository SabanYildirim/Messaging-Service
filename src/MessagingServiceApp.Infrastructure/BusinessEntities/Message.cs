using MessagingServiceApp.Infrastructure.BusinessEntities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Infrastructure.BusinessEntities
{
    public class Message : BaseEntity
    {
        public string ReceiverUserName { get; set; }
        public string SenderUserName { get; set; }
        public string UserMessage { get; set; }
    }
}
