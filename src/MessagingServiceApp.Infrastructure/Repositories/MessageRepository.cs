using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Infrastructure.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(IMongoDBContext context) : base(context)
        {

        }
    }
}
