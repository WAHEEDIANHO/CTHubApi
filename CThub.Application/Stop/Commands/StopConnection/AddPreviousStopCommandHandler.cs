using CThub.Application.Common.CQRS;
using CThub.Application.Stop.Repository;
using CThub.Domain.ValueObjects;

namespace CThub.Application.Stop.Commands.StopConnection;

public class AddPreviousStopCommandHandler(
    IPrevStopRepository prevStopRepository,
    IStopRepository stopRepository
    ): ICommandHandler<AddPreviousStopCommand, AddPreviousStopResult>
{
    public  async Task<AddPreviousStopResult> Handle(AddPreviousStopCommand command, CancellationToken cancellationToken)
    {
        // var stop = GetStopWithId(command.StopId);
        if (await GetStopWithId(command.StopId) is not Domain.Models.Stop stop)
        {
            throw new Exception("Id not found");
        }
        if (await GetStopWithId(command.PreviousStopId) is not Domain.Models.Stop prevStop)
        {
            throw new Exception("Id not found");
        }
        var createPrevStop = PrevStop.Create(stop, prevStop.Id, prevStop.StopName);
        await prevStopRepository.Add(createPrevStop);
        return new AddPreviousStopResult();
    }

    private async Task<Domain.Models.Stop> GetStopWithId(Guid id)
    {
        var stopId = StopId.Of(id);
        return await stopRepository.GetStopByIdAsync(stopId);
    }
}