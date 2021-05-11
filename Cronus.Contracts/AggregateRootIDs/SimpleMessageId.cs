using Elders.Cronus;
using System.Runtime.Serialization;

namespace Cronus.Contracts
{
    [DataContract(Name = "d4889cbb-aa8d-4b6b-b10d-93cc88d51cc4")]
    public class SimpleMessageId : AggregateRootId<SimpleMessageId>
    {
        const string RootName = "simple";

        private SimpleMessageId() { }

        public SimpleMessageId(string id, string tenant) : base(id, RootName, tenant) { }

        protected override SimpleMessageId Construct(string id, string tenant) => new SimpleMessageId(id, tenant);
    }
}
