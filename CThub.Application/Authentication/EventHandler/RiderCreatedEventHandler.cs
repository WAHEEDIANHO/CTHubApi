using CThub.Application.Authentication.Repository;
using CThub.Application.Common.Authentication;
using CThub.Domain.Events;
using CThub.Domain.Models;
using MediatR;

namespace CThub.Application.Authentication.EventHandler;

public class RiderCreatedEventHandler(IUserRepository userRepository): INotificationHandler<RiderCreatedEvent>
{
    public async Task Handle(RiderCreatedEvent notification, CancellationToken cancellationToken)
    {
        var rider = Rider.Create(notification.user.Id);
        await userRepository.AddRider(notification.user, rider);
    }
}