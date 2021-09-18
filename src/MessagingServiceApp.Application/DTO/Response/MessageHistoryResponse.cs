using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.DTO.Response
{
    public class MessageHistoryResponse
    {
        public string ReceiverUserName { get; set; }
        public string SenderUserName { get; set; }
        public string UserMessage { get; set; }
        public DateTime SendDate { get; set; }
    }
}
