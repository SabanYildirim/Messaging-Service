using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Interfaces
{
    public interface IMongoServices
    {
        bool AddDocument(BsonDocument document);
        bool AddDocuments(List<BsonDocument> documents);
    }
}
