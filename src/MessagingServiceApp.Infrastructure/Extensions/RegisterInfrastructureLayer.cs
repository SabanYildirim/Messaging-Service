using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.Context;
using MessagingServiceApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Infrastructure.Extensions
{
    public static class RegisterInfrastructureLayer
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDBContext, MongoDBContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
        }
    }
}
