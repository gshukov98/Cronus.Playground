using Elders.Cronus;
using System;

namespace Cronus.Contracts
{
    public class SimpleMessageAggregateState : AggregateRootState<SimpleMessageAggregate, SimpleMessageId>
    {
        //Changed set to private set
        public override SimpleMessageId Id { get; set; }
        public DateTimeOffset Timestamp { get; private set; }

        public void When(SimpleMessageCreated @event)
        {
            this.Id = @event.Id;
            this.Timestamp = @event.Timestamp;
        }
    }
}
