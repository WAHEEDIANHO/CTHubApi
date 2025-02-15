using CThub.Application.Stop.Repository;
using CThub.Domain.Events;
using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using MediatR;

namespace CThub.Application.Stop.EventHandler;

public class PrevStopAddEventHandler(INextStopRepository stopRepository): INotificationHandler<PrevStopAddEvent>
{
    public async Task Handle(PrevStopAddEvent command, CancellationToken cancellationToken)
    {
        var nextStop = NextStop.Create(command.StopId, command.NextStop.Id, command.NextStop.StopName);
        await stopRepository.Add(nextStop);
    }
}