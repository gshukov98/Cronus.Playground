using Elders.Cronus;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cronus.Contracts.AggregateRootIDs
{
    [DataContract(Name = "50367279-754b-4412-b9f9-6d1384bd95af")]
    public class EmptyMessageId : AggregateRootId<EmptyMessageId>
    {
        const string RootName = "empty";

        public EmptyMessageId() { }

        public EmptyMessageId(string id, string tenant) : base(id, RootName, tenant) { }

        protected override EmptyMessageId Construct(string id, string tenant) => new EmptyMessageId(id, tenant);
    }
}
