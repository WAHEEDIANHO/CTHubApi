using CThub.Application.Common.CQRS;
using CThub.Application.DriverQueueImpl.Repository;
using CThub.Domain.ValueObjects;

namespace CThub.Application.DriverQueueImpl.Commands;

public class DriverQueueCommandHandler(IDriverQueueRepository repository): ICommandHandler<DriverQueueCommand, DriverQueueCommandResponse>
{
    public async Task<DriverQueueCommandResponse> Handle(DriverQueueCommand command, CancellationToken cancellationToken)
    {
        var location = Location.Of(command.Latitude, command.Longitude);
        var queue = DriverQueue.Create(command.DriverId, DateTime.Now, location, command.Vehincle, command.Token);

        var queueCount = await repository.Add(queue);
        return new DriverQueueCommandResponse(queue.Id, queueCount);
    }
}