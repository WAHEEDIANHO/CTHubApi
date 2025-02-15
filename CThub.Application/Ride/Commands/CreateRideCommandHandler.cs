using CThub.Application.Common.CQRS;
using CThub.Application.Ride.Repository;
using CThub.Application.Stop.Repository;
using CThub.Domain.ValueObjects;

namespace CThub.Application.Ride.Commands;

public class CreateRideCommandHandler(IRideRepository repository): ICommandHandler<CreateRideCommand, CreateRideResult>
{
    public async Task<CreateRideResult> Handle(CreateRideCommand request, CancellationToken cancellationToken)
    {
        var ride = Domain.Models.Ride.Create(
            StopId.Of(request.StartStopId),
            StopId.Of(request.EndStopId),
            request.RiderId.ToString(),
            request.VehincleType,
            request.RideType
        );
        
        await repository.Add(ride);
        return new CreateRideResult(ride.Id.Value);
    }

   
}