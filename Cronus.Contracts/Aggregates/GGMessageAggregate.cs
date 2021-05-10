using Cronus.Contracts.Events;
using Cronus.Contracts.States;
using Elders.Cronus;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cronus.Contracts.Aggregates
{
    [DataContract(Name = "11cbb7b8-254e-4995-a3c0-7268c1a8c65c")]
    public class GGMessageAggregate : AggregateRoot<GGMessageAggregateState>
    {
        public GGMessageAggregate() { }

        public GGMessageAggregate(SimpleMessageId messageId, DateTimeOffset timestamp)
        {
            var evnt = new GGMessageCreated(messageId, timestamp);
            Apply(evnt);
        }
    }
}
