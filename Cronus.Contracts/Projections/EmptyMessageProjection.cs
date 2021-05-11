using Cronus.Contracts.AggregateRootIDs;
using Cronus.Contracts.Events;
using Elders.Cronus;
using Elders.Cronus.Projections;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts.Projections
{
    [DataContract(Name = "c2568640-2136-4efb-9306-aef45bec3ab6")]
    public class EmptyMessageProjection : ProjectionDefinition<EmptyMessageProjectionState, EmptyMessageId>, IProjection,
        IEventHandler<EmptyMessageCreated>
    {
        public EmptyMessageProjection()
        {
            Subscribe<EmptyMessageCreated>(x => x.Id);
        }

        public void Handle(EmptyMessageCreated @event)
        {
            State.LastModificationDate = @event.Timestamp;
        }
    }

    public class EmptyMessageProjectionState
    {
        public DateTimeOffset LastModificationDate { get; set; }
    }
}
