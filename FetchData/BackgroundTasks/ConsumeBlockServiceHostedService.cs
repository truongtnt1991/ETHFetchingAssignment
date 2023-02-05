using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FetchData.BackgroundTasks
{
	public class ConsumeBlockServiceHostedService : BackgroundService
    {
        private readonly ILogger<ConsumeBlockServiceHostedService> _logger;
        public IServiceProvider Services { get; }
        public ConsumeBlockServiceHostedService(IServiceProvider services, ILogger<ConsumeBlockServiceHostedService> logger)
		{
            _logger = logger;
            Services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Block Service Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Block Service Hosted Service is working.");

            using (var scope = Services.CreateScope())
            {
                var processingService =
                    scope.ServiceProvider
                        .GetRequiredService<IBlockProcessingService>();

                await processingService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Block Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}

