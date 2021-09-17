using Microsoft.Extensions.DependencyInjection;

namespace MessagingServiceApp.Common.Extensions
{
    public static class RegisterCommonLayer
    {
        public static void AddCommonLayer(this IServiceCollection services)
        {
            services.AddTransient<IMongoDbSettings, MongoDbSettings>();
        }
    }
}
