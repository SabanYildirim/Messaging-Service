using MessagingServiceApp.Infrastructure.BusinessEntities.Base;

namespace MessagingServiceApp.Infrastructure.BusinessEntities
{
    public class MessageEntity : BaseEntity
    {
        public string ReceiverUsername { get; set; }
        public string SenderUsername { get; set; }
        public string UserMessage { get; set; }
    }
}
