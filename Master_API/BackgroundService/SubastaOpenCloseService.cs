using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Master_API.Services.Interfaces;

namespace Master_API.Services
{
    public class SubastaOpenCloseService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public SubastaOpenCloseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CheckAndOpenCloseSubastasAsync();
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private async Task CheckAndOpenCloseSubastasAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var subastaService = scope.ServiceProvider.GetRequiredService<ISubastaService>();

                var subastasToOpen = await subastaService.GetSubastasToOpenAsync(DateTime.Now);
                foreach (var subasta in subastasToOpen)
                {
                    await subastaService.OpenSubastaAsync(subasta);
                }

                var subastasToClose = await subastaService.GetSubastasToCloseAsync(DateTime.Now);

                foreach (var subasta in subastasToClose)
                {
                    await subastaService.CloseSubastaAsync(subasta);
                }
            }
        }
    }
}
