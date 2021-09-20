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
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        protected IMongoCollection<UserEntity> _dbCollection;

        public UserRepository(IMongoDBContext context) : base(context)
        {
            _dbCollection = _mongoContext.GetCollection<UserEntity>(typeof(UserEntity).Name);
        }

        public async Task<UserEntity> GetUserByUsername(string username)
        {
            var entity = await _dbCollection.Find<UserEntity>(m => m.UserName == username).FirstOrDefaultAsync();

            return entity;
        }
    }
}
