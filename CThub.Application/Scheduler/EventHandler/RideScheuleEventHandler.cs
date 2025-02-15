using CThub.Application.Hubs;
using CThub.Application.Scheduler.Repository;
using CThub.Domain.Enums;
using CThub.Domain.Events;
using MediatR;
// using Microsoft.AspNetCore.SignalR;

// using Microsoft.AspNetCore.SignalR;

namespace CThub.Application.Scheduler.EventHandler;

public class RideScheuleEventHandler(
    IScheduleRepository scheduleRepository,
    IPublisher publisher,
    INotificationHubServer notificationHubServer
    ): INotificationHandler<RideScheduleEvent>
{
    public async Task Handle(RideScheduleEvent notification, CancellationToken cancellationToken)
    {
        var result = await scheduleRepository.GetAll(null);
        // create  a dictionary
        var ScheduleIndexies = new Dictionary<string, List<string>>();
        foreach (var schedule in result)
        {
            List<string> usersId = new();
            foreach (var userInSchedule in schedule.User) usersId.Add(userInSchedule.Id);
            // var connectionId = await notificationHub.GetConnectionIdByUserId(usersId[0]);
            // Console.WriteLine(connectionId);
            ScheduleIndexies.Add(schedule.Path, usersId);
        }  
        
        
        
        var scheduleListValues  = ScheduleIndexies.Values.ToList();
        var scheduleListKeys = ScheduleIndexies.Keys.ToList();

        int idx = 0;
        foreach (var value in scheduleListValues)
        {
            var route = scheduleListKeys[idx];
            
            
            Vehincle vehincle = (Vehincle)Enum.Parse(typeof(Vehincle), route.Split("_")[0]);

            if(value.Count() == 3 && vehincle == Vehincle.TRICYCLE)
            {
                foreach (var userId in value)
                {
                    var connectionId = await notificationHubServer.GetConnectionIdByUserId(userId);
                    await notificationHubServer.JoinWaiterGroup(connectionId, scheduleListKeys[idx]);
                }
                Console.WriteLine($"start {value.First()} -> {value.Last()} - {scheduleListKeys[idx]}");
                await publisher.Publish(new GetDriverEvent(scheduleListKeys[idx], value));
            }
            else if (value.Count() == 4 && vehincle == Vehincle.CAR)
            {
                foreach (var userId in value)
                {
                    var connectionId = await notificationHubServer.GetConnectionIdByUserId(userId);
                    await notificationHubServer.JoinWaiterGroup(connectionId, scheduleListKeys[idx]);
                }
                Console.WriteLine($"start {value.First()} -> {value.Last()} - {scheduleListKeys[idx]}");
                await publisher.Publish(new GetDriverEvent(scheduleListKeys[idx], value));
            }
            idx++;
        }
    }
}