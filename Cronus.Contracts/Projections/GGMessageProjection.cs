using Cronus.Contracts.Events;
using Elders.Cronus;
using Elders.Cronus.Projections;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cronus.Contracts.Projections
{
    [DataContract(Name = "c2568640-2136-4efb-9306-aef45bec3ab6")]
    public class GGMessageProjection : ProjectionDefinition<GGMessageProjectionState, SimpleMessageId>, IProjection,
        IEventHandler<GGMessageCreated>
    {
        public void Handle(GGMessageCreated @event)
        {
            State.LastModificationDate = @event.Timestamp;
        }
    }

    public class GGMessageProjectionState
    {
        public DateTimeOffset LastModificationDate { get; set; }
    }
}
