using Bari.Test.Domain.Core.Events;
using System;

namespace Bari.Test.Domain.Events
{
    public class MessageCreatedEvent : Event
    {
        public Guid Id { get; private set; }
        public string Text { get; set; }

        protected MessageCreatedEvent()
        {
            Id = Guid.NewGuid();
        }
    }
}