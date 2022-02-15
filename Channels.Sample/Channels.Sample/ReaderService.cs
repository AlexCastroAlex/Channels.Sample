using System.Threading.Channels;

namespace Channels.Sample
{
    public class ReaderService : BackgroundService
    {
        private readonly ChannelReader<int> _channelReader;
        public ReaderService(ChannelReader<int> channelReader)
        {
            _channelReader = channelReader;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);

                try
                {
                    var datasToRead = await _channelReader.ReadAsync(stoppingToken);
                    Console.WriteLine($"Reading Data : {datasToRead}");
                }
                catch (ChannelClosedException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
