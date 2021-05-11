using Cronus.Contracts.Aggregates;
using Cronus.Contracts.Commands;
using Elders.Cronus;

namespace Cronus.Contracts
{
    public class EmptyMessageAggregateAppService : ApplicationService<EmptyMessageAggregate>,
        ICommandHandler<CreateEmptyMessage>
    {
        public EmptyMessageAggregateAppService(IAggregateRepository repository) : base(repository) { }

        public void Handle(CreateEmptyMessage command)
        {

        }
    }
}
