using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Application.Mapping;
using MessagingServiceApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Extensions
{
    public static class RegisterApplicationLayer
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IMessageServices, MessageService>();
            services.AddSingleton<IMessagingMapper, AutoMapping>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
        }
    }
}
