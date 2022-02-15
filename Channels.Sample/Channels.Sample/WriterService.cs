using System.Threading.Channels;

namespace Channels.Sample
{
    public class WriterService : BackgroundService
    {
        private readonly ChannelWriter<int> _channelWriter;
        public WriterService(ChannelWriter<int> channelWriter)
        {
            _channelWriter = channelWriter;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int count = 0;
            while(!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
                Console.WriteLine($"Writing data {count}");
                await _channelWriter.WriteAsync(count++, stoppingToken);
            }
        }
    }
}
