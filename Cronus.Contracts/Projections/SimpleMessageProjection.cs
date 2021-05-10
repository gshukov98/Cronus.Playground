using Elders.Cronus;
using Elders.Cronus.Projections;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "398f646b-a8c0-4dad-a648-d936a70e43fe")]
    public class SimpleMessageProjection : ProjectionDefinition<SimpleMessageProjectionState, SimpleMessageId>, IProjection,
        IEventHandler<SimpleMessageCreated>
    {
        public void Handle(SimpleMessageCreated @event)
        {
            State.LastModificationDate = @event.Timestamp;
        }
    }

    public class SimpleMessageProjectionState
    {
        public DateTimeOffset LastModificationDate { get; set; }
    }
}
