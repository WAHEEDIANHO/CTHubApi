using CThub.Application.DriverQueueImpl.Repository;
using CThub.Application.Hubs;
using CThub.Application.Notification;
using CThub.Application.Scheduler.Repository;
using CThub.Domain.Enums;
using CThub.Domain.Events;
using MediatR;

namespace CThub.Application.Scheduler.EventHandler;

public class GetDriverEventHandler(
    INotificationHubServer notificationHubServer,
    IDriverQueueRepository driverQueueRepository,
    IScheduleRepository scheduleRepository,
    IFCMMessaging fcmMessaging
    ): INotificationHandler<GetDriverEvent>
{
    public async Task Handle(GetDriverEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var vehincleRoute = notification.route.Split("_");
        Vehincle vehincle = (Vehincle)Enum.Parse(typeof(Vehincle), vehincleRoute[0]);
        var stops = vehincleRoute[1].Split("->");

        var query = new Dictionary<string, object>();
        query.Add("Vehincle", vehincle);

        var driverQueue = await driverQueueRepository.GetAll(query);
        if(driverQueue == null) return;
        var selectDriver = driverQueue.First();
        var driverId = selectDriver.DriverId;
        var driverToken = selectDriver.Token;
        if (notification.rideType == Domain.Enums.Ride.DROP)
        {
            notificationHubServer.SendToGroup($"{stops.First()}->{stops.Last()}", $"You have been assign to {driverId}");
            await fcmMessaging.SendDirectNotification(driverToken);
        }
        else
        {
            await fcmMessaging.SendDirectNotification(driverToken);
            notificationHubServer.SendToGroup(notification.route, $"You have been assign to {driverId}");
        }
        Console.WriteLine("Getting Driver");
        Console.WriteLine($"Route start-{stops.First()} and stop-{stops.Last()} with {vehincle}");
        
        //deleting schedule and removing driver from queue as well.
        var schedule = await scheduleRepository.GetByPath(notification.route);
        scheduleRepository.Delete(schedule);

        var driver = await driverQueueRepository.GetByKey(driverId);
        driverQueueRepository.Delete(driver);
    }
}