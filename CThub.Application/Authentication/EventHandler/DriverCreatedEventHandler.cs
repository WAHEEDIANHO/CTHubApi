using CThub.Application.Authentication.Repository;
using CThub.Application.Common.Authentication;
using CThub.Domain.Events;
using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using MediatR;

namespace CThub.Application.Authentication.EventHandler;

public class DriverCreatedEventHandler(IUserRepository userRepository): INotificationHandler<DiverCreatedEvent>
{
    public async Task Handle(DiverCreatedEvent notification, CancellationToken cancellationToken)
    {
        var driver = Driver.Create(DriverNo.Of(1), notification.vehincle, notification.user.Id);
        await userRepository.AddDriver(notification.user, driver);
    }
}