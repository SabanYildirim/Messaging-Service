using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using Serilog.Sinks.Elasticsearch;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace MessagingServiceApp.Common.Utilities
{
    public static class SerilogHelper
    {    
        /// <summary>
        ///
        /// </summary>
        /// 
        public static Action<HostBuilderContext, LoggerConfiguration> Configure => (ctx, cfg) =>
        {
            var elasticSearchUri = ctx.Configuration.GetValue<string>("ElasticConfiguration:Uri");

            cfg.Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(
            new ElasticsearchSinkOptions(new Uri(elasticSearchUri))
            {
                IndexFormat = $"applog",
                AutoRegisterTemplate = true,
                NumberOfShards = 2,
                NumberOfReplicas = 1
            })
            .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName)
            .Enrich.WithProperty("Application", ctx.HostingEnvironment.ApplicationName)
            .ReadFrom.Configuration(ctx.Configuration);
        };
    }
}
