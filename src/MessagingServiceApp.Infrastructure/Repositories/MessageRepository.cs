using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Infrastructure.Repositories
{
    public class MessageRepository : BaseRepository<MessageEntity>, IMessageRepository
    {
        protected IMongoCollection<MessageEntity> _dbCollection;

        public MessageRepository(IMongoDBContext context) : base(context)
        {
            _dbCollection = _mongoContext.GetCollection<MessageEntity>(typeof(MessageEntity).Name);
        }

        public async Task<IEnumerable<MessageEntity>> GetMessageHistory(string username, string targetUsername)
        {
            var entity = await _dbCollection.Find<MessageEntity>(m => (m.SenderUsername == username && m.ReceiverUsername == targetUsername) ||
                                                                (m.SenderUsername == targetUsername && m.ReceiverUsername == username)).ToListAsync();
            return entity;
        }
    }
}
