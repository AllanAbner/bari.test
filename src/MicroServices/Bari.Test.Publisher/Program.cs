using Bari.Test.Domain.Core.Bus;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Bari.Test.Publisher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;

                    services.Configure<RabbitMQConfig>(configuration.GetSection("RabbitMq"));
                    // domain bus
                    services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
                    {
                        var scopeFactory = sp.GetService<IServiceScopeFactory>();
                        var opt = sp.GetRequiredService<IOptions<RabbitMQConfig>>();
                        return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, opt);
                    });

                    services.AddHostedService<Publisher>();
                });
    }
}