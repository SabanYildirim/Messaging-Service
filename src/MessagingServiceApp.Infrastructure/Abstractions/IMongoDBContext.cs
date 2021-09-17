using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Infrastructure.Abstractions
{
    public interface IMongoDBContext
    {
        IMongoDatabase _db { get; }
        MongoClient _mongoClient { get; }
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
