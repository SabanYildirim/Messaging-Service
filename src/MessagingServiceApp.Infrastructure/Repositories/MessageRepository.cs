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
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        protected IMongoCollection<Message> _dbCollection;

        public MessageRepository(IMongoDBContext context) : base(context)
        {
            _dbCollection = _mongoContext.GetCollection<Message>(typeof(Message).Name);
        }

        public async Task<IEnumerable<Message>> GetMessageHistory(string username, string targetUsername)
        {
            var entity = await _dbCollection.Find<Message>(m => (m.SenderUsername == username && m.ReceiverUsername == targetUsername) ||
                                                                (m.SenderUsername == targetUsername && m.ReceiverUsername == username)).ToListAsync();
            return entity;
        }
    }
}
