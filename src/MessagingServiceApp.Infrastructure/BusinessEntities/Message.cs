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
        public string ReceiverUsername { get; set; }
        public string SenderUsername { get; set; }
        public string UserMessage { get; set; }
    }
}
