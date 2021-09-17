﻿using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingServiceApp.Infrastructure.Context
{
    public class MongoDBContext : IMongoDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }

        IMongoDatabase IMongoDBContext._db { get { return _db; } }

        MongoClient IMongoDBContext._mongoClient { get { return _mongoClient; } }

        public MongoDBContext(IOptions<MongoDbSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}