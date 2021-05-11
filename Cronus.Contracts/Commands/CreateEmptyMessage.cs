using Cronus.Contracts.AggregateRootIDs;
using Elders.Cronus;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cronus.Contracts.Commands
{
    [DataContract(Name = "308c60e3-eec7-4c3c-b972-dcce81cc6127")]
    public class CreateEmptyMessage : ICommand
    {
        public CreateEmptyMessage()
        {
            Id = new EmptyMessageId(Guid.NewGuid().ToString(), "elders");
            Timestamp = DateTimeOffset.UtcNow;
        }

        public CreateEmptyMessage(EmptyMessageId id, DateTimeOffset timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }

        [DataMember(Order = 1)]
        public EmptyMessageId Id { get; private set; }

        [DataMember(Order = 2)]
        public DateTimeOffset Timestamp { get; private set; }
    }
}
