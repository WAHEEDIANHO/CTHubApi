using CThub.Application.Common.CQRS;
using CThub.Application.Stop.Repository;
using CThub.Domain.ValueObjects;

namespace CThub.Application.Stop.Commands.CreateStop;

public class CreateStopCommandHandler(IStopRepository stopRepository): ICommandHandler<CreateStopCommand, CreateStopResult>
{
    public async Task<CreateStopResult> Handle(CreateStopCommand request, CancellationToken cancellationToken)
    {

        var stop = Domain.Models.Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of(request.StopName));
        await stopRepository.Add(stop);
        return new CreateStopResult(stop.Id.Value);
    }
}