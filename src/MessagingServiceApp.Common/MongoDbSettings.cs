using MessagingServiceApp.Common.Interfaces;

namespace MessagingServiceApp.Common
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
