using Cronus.Contracts.Commands;
using Elders.Cronus;

namespace Cronus.Contracts
{
    public class SimpleMessageAggregateAppService : ApplicationService<SimpleMessageAggregate>,
       ICommandHandler<CreateSimpleMessage>
    {
        public SimpleMessageAggregateAppService(IAggregateRepository repository) : base(repository) { }

        public void Handle(CreateSimpleMessage command)
        {
            var arResult = repository.Load<SimpleMessageAggregate>(AggregateUrn.Parse(command.Id.Value));

            if (arResult.IsSuccess)
            {
                return;
            }
            else
            {
                var notFound = new SimpleMessageAggregate(command.Id, command.Timestamp);
                repository.Save(notFound);
            }
        }
    }
}
