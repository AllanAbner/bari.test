using Bari.Test.Domain.Core.Bus;
using Bari.Test.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Bari.Test.Domain.EventHandler
{
    public class MessageEventHandler : IEventHandler<MessageCreatedEvent>
    {
        public Task Handle(MessageCreatedEvent @event)
        {
            Console.WriteLine($"Identificacao da mensagem: {@event.Id}");
            Console.WriteLine($"Mensagem criada em: {@event.TimeStamp}");
            Console.WriteLine($"Mensagem enviada por: {@event.Identifier}");
            Console.WriteLine($"Mensagem : {@event.Text}");
            Console.WriteLine();

            return Task.CompletedTask;
        }
    }
}