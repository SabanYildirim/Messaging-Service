using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<T> _dbCollection;

        protected BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<T>(typeof(T).Name);
        }

        public async virtual Task<T> Add(T entity)
        {
            _dbCollection.InsertOne(entity);
            return entity;
        }

        public virtual T GetById(Guid id)
        {
            return _dbCollection.Find<T>(m => m.Id == id).FirstOrDefault();
        }

        public virtual void Remove(Guid id)
        {
            _dbCollection.DeleteOne(m => m.Id == id);
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return _dbCollection.Find<T>(T => true).ToList();
        }

        public void Update(T entity)
        {
            _dbCollection.ReplaceOne(Builders<T>.Filter.Eq("_id", entity.Id), entity);
        }
    }
}
