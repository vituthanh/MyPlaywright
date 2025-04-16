
namespace MyPlaywright.Services
{
    public class PlaywrightInitializer : IHostedService
    {
        private readonly IPlaywrightService _service;

        public PlaywrightInitializer(IPlaywrightService service)
        {
            _service = service;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _service.InitAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
