using Elders.Cronus;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "6eaca9e7-be24-4a9a-941e-6fae94e63e69")]
    public class SimpleMessageAggregate : AggregateRoot<SimpleMessageAggregateState>
    {
        public SimpleMessageAggregate() { }

        public SimpleMessageAggregate(SimpleMessageId userId, DateTimeOffset timestamp)
        {
            var evnt = new SimpleMessageCreated(userId, timestamp);
            Apply(evnt);
        }
    }
}
