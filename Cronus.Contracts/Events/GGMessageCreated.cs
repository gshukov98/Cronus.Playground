using Elders.Cronus;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cronus.Contracts.Events
{
    [DataContract(Name = "ee75efdd-cc80-4a88-8c65-02fa0a6819ba")]
    public class GGMessageCreated : IEvent
    {
        public GGMessageCreated(SimpleMessageId id, DateTimeOffset timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }

        [DataMember(Order = 1)]
        public SimpleMessageId Id { get; private set; }

        [DataMember(Order = 2)]
        public DateTimeOffset Timestamp { get; private set; }
    }
}
