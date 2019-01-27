using Ariana.ECommerce.EventBus.EventBus.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Application.BackgroundServices
{
    public class DemoBackgroundService : BackgroundService
    {
        private readonly ILogger<DemoBackgroundService> _logger;
        private readonly IEventBus _eventBus;

        public DemoBackgroundService(IEventBus eventBus,
                                    ILogger<DemoBackgroundService> logger)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"DemoBackgroundService is starting.");

            stoppingToken.Register(() =>
                    _logger.LogDebug($" DemoBackgroundService task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"GracePeriod task doing background work.");

                //Do Something

                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }

            _logger.LogDebug($"GracePeriod background task is stopping.");

        }
    }
}
