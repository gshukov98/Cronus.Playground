using Cronus.Contracts.AggregateRootIDs;
using Cronus.Contracts.Events;
using Cronus.Contracts.States;
using Elders.Cronus;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts.Aggregates
{
    [DataContract(Name = "11cbb7b8-254e-4995-a3c0-7268c1a8c65c")]
    public class EmptyMessageAggregate : AggregateRoot<EmptyMessageAggregateState>
    {
        public EmptyMessageAggregate() { }

        public EmptyMessageAggregate(EmptyMessageId messageId, DateTimeOffset timestamp)
        {
            var evnt = new EmptyMessageCreated(messageId, timestamp);
            Apply(evnt);
        }
    }
}
