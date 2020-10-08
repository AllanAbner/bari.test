using Bari.Test.Domain.Core.Bus;
using Bari.Test.Domain.EventHandler;
using Bari.Test.Domain.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bari.Test.Subscriber.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQConfig>(configuration.GetSection("RabbitMq"));
            // domain bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetService<IServiceScopeFactory>();
                var opt = sp.GetRequiredService<IOptions<RabbitMQConfig>>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, opt);
            });


            //suscriptions
            services.AddTransient<MessageEventHandler>();
            //Doamin Events
            services.AddTransient<IEventHandler<MessageCreatedEvent>, MessageEventHandler>();
        }
    }
}