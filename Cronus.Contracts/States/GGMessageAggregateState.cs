﻿using Cronus.Contracts.Aggregates;
using Cronus.Contracts.Events;
using Elders.Cronus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronus.Contracts.States
{
    public class GGMessageAggregateState : AggregateRootState<GGMessageAggregate, SimpleMessageId>
    {
        public override SimpleMessageId Id { get; set; }
        public DateTimeOffset Timestamp { get; private set; }

        public void When(GGMessageCreated @event)
        {
            this.Id = @event.Id;
            this.Timestamp = @event.Timestamp;
        }
    }
}
