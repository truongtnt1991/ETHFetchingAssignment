using System;
using FetchData.APIProcessing;
using FetchData.BackgroundTasks;
using FetchData.Mapper;
using FetchData.Repositories;
using FetchEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace FetchData
{
	public static class ServiceSetup
	{

		public static IServiceProvider AddServices(this IServiceCollection services)
		{
            services.AddConfigs()
                .AddPlusProductDB()
                .AddDataHelpers()
                .AddAutoMapper()
                .AddHostedService()
                .AddLogging();
            return services.BuildServiceProvider();
        }

        private static IServiceCollection AddConfigs(this IServiceCollection services)
        {
            IConfiguration config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .AddEnvironmentVariables()
             .Build();
    
            services.Configure<Settings>(config.GetSection("Settings"));

            return services;
        }

        private static IServiceCollection AddPlusProductDB(this IServiceCollection services)
        {
            IConfiguration config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .AddEnvironmentVariables()
             .Build();

            Settings settings = config.GetSection("Settings").Get<Settings>();

            services.AddDbContext<BlockContext>
                   (options => options
                   .UseMySql(settings.ConnectionString.ETH, ServerVersion.AutoDetect(settings.ConnectionString.ETH)));

            return services;
        }

        private static IServiceCollection AddDataHelpers(this IServiceCollection services)
        {
            services.AddScoped<IBlockRepository, BlockRepository>();
            services.AddScoped<IBlockProcessingService, BlockProcessingService>();
            services.AddScoped<IBlockAPIProcessing, BlockAPIProcessing>();
            return services;
        }

        private static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper((typeof(AutoMapperProfile).Assembly));
            return services;
        }

        private static IServiceCollection AddHostedService(this IServiceCollection services)
        {
            services.AddHostedService<ConsumeBlockServiceHostedService>();
            return services;
        }

        private static IServiceCollection AddLogging(this IServiceCollection services)
        {
            var serilogLogger = new LoggerConfiguration()
           .WriteTo.File("Block.txt")
           .CreateLogger();
            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddSerilog(logger: serilogLogger, dispose: true);
            });
            return services;
        }
    }
}

