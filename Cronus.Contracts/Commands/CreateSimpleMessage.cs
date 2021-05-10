using Elders.Cronus;
using System;
using System.Runtime.Serialization;

namespace Cronus.Contracts.Commands
{
    [DataContract(Name = "bb194628-bee6-402e-8c12-e688b3675da1")]
    public class CreateSimpleMessage : ICommand
    {
        public CreateSimpleMessage()
        {
            Id = new SimpleMessageId(Guid.NewGuid().ToString(), "elders");
            Timestamp = DateTimeOffset.UtcNow;
        }

        public CreateSimpleMessage(SimpleMessageId id, DateTimeOffset timestamp)
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
