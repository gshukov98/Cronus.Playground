using Elders.Cronus;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "050a0d2b-7d01-41e6-bb48-0b8f9ef1aba7")]
    public class SimpleMessageCreated : IEvent
    {
        public SimpleMessageCreated(SimpleMessageId id, DateTimeOffset timestamp)
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
