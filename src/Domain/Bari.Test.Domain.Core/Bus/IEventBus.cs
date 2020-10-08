using Bari.Test.Domain.Core.Events;

namespace Bari.Test.Domain.Core.Bus
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}