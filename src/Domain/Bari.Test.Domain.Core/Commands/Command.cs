﻿using Bari.Test.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bari.Test.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
