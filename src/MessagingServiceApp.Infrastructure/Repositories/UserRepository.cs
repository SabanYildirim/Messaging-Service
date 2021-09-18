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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected IMongoCollection<User> _dbCollection;

        public UserRepository(IMongoDBContext context) : base(context)
        {
            _dbCollection = _mongoContext.GetCollection<User>(typeof(User).Name);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var entity = await _dbCollection.Find<User>(m => m.UserName == username).FirstOrDefaultAsync();

            return entity;
        }
    }
}
