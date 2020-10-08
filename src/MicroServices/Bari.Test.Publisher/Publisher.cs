using Bari.Test.Domain.Core.Bus;
using Bari.Test.Domain.Core.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bari.Test.Publisher
{
    public class Publisher : BackgroundService
    {
        private readonly ILogger<Publisher> _logger;
        private readonly IEventBus _bus;

        public Publisher(ILogger<Publisher> logger, IEventBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = new MessageCreatedEvent()
                {
                    TimeStamp= DateTime.Now,
                    Text = "Hello World",
                    Identifier = Environment.MachineName
                };

                _bus.Publish(message);

                await Task.Delay(5000, stoppingToken);
            }
        }
    }

    public class MessageCreatedEvent : Event
    {
        public Guid Id { get; private set; }
        public string Text { get; set; }

        public MessageCreatedEvent()
        {
            Id = Guid.NewGuid();
        }
    }
}