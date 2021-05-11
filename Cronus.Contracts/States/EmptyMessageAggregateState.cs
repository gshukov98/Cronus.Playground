using Cronus.Contracts.AggregateRootIDs;
using Cronus.Contracts.Aggregates;
using Cronus.Contracts.Events;
using Elders.Cronus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronus.Contracts.States
{
    public class EmptyMessageAggregateState : AggregateRootState<EmptyMessageAggregate, EmptyMessageId>
    {
        public override EmptyMessageId Id { get; set; }
        public DateTimeOffset Timestamp { get; private set; }

        public void When(EmptyMessageCreated @event)
        {
            this.Id = @event.Id;
            this.Timestamp = @event.Timestamp;
        }
    }
}
