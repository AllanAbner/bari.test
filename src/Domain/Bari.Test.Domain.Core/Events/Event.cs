using System;

namespace Bari.Test.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime TimeStamp { get; private set; }
        public string Identifier { get; set; }

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}