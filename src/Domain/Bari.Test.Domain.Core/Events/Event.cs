using System;

namespace Bari.Test.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime TimeStamp { get; set; }
        public string Identifier { get; set; }

        protected Event()
        {
          
        }
    }
}