using System.Text;
using CThub.Application.Authentication.Repository;
using CThub.Application.Hubs;
using CThub.Application.Ride.Repository;
using CThub.Application.Scheduler.Repository;
using CThub.Application.Stop.Repository;
using CThub.Domain.Enums;
using CThub.Domain.Events;
using MediatR;

namespace CThub.Application.Scheduler.EventHandler;

record RiderWithPossibleRoutes(
        string RiderId,
        List<List<string>> routes,
        Vehincle VehincleType
    );

record RiderRoute(
    string RiderId,
    List<string> route,
    Vehincle VehincleType

);

public class RideCreateEventHandler(

    IRideRepository rideRepository,
    IStopRepository stopRepository,
    IScheduleRepository scheduleRepository,
    IUserRepository userRepository,
    IMediator mediator,
    INotificationHubServer notificationHubServer
): INotificationHandler<RideCreatedEvent>
{
    // private readonly IDatabase _redisDb = muxer.GetDatabase(); 
    
    public async Task Handle(RideCreatedEvent command, CancellationToken cancellationToken)
    {
        // command.ride.
        var query = new Dictionary<string, string>();
        var stops = await stopRepository.GetAll(query);
        var ride = await rideRepository.GetAll(query);
        
        if (command.ride.RideType == Domain.Enums.Ride.DROP)
        {
            var traceRiderRequestRoute = TraceRiderRequestRoute(stops.ToList(), command.ride);
            StringBuilder str = new();
            var route = traceRiderRequestRoute.routes[0];
            // foreach (var route in routes)
            for (int idx=0; idx<route.Count; idx++)
            {
                str.Append(route[idx]);
                if(idx < route.Count()-1) str.Append("->");
            }
            //appending rideType to generate rooute
            var newStr = $"{traceRiderRequestRoute.VehincleType.ToString()}_{str}";
            
            var connectionId = await notificationHubServer.GetConnectionIdByUserId(command.ride.RiderId);
            var startStop = await stopRepository.GetStopByIdAsync(command.ride.StartStopId);
            var endStop = await stopRepository.GetStopByIdAsync(command.ride.EndStopId);
            await notificationHubServer.JoinWaiterGroup(connectionId, $"{startStop.StopName}->{endStop.StopName}");
            await mediator.Publish(new GetDriverEvent(newStr, new List<string>() {traceRiderRequestRoute.RiderId}, Domain.Enums.Ride.DROP), cancellationToken);
            return;
        }
        var riderRequestRoute = SpreadRouteWithUser(stops.ToList().AsReadOnly(), command.ride);
        MathchPassenger(riderRequestRoute);
        // var d
        // Console.WriteLine(_redisDb);
        Console.WriteLine(ride.Count());
    }
    
    
    
    private RiderWithPossibleRoutes TraceRiderRequestRoute(IReadOnlyList<Domain.Models.Stop> stops, Domain.Models.Ride ride)
    {
        var start = ride.StartStopId.Value;
        var end = ride.EndStopId.Value;
        var userId = ride.RiderId;
        
        var riderRoute = FindRiderRoute(stops, start, end);

        return new RiderWithPossibleRoutes(
            userId,
            riderRoute,
            ride.VehincleType
        );
    }

    
    private List<List<string>> FindRiderRoute(
        IReadOnlyList<Domain.Models.Stop> stops, Guid start, Guid end, List<string>? currentRoutes = null
        )
    {
        if (currentRoutes is null)
        {
            currentRoutes = new List<string>();
            var stop = stops.First(x => x.Id.Value == end);
            currentRoutes.Add(stop.StopName.Value);
        };
        // List<string> routes = new();
        if (start == end)
        {
           var stop = stops.First(x => x.Id.Value == end);
           // currentRoutes.Add(stop.StopName.Value);
           currentRoutes.Reverse();
           var list = new List<List<string>> { currentRoutes };
           // list.Reverse();
           return list;
        };

        // routes.Add(currStop.StopName.Value);
        List<List<string>> routes = new();
        var currStop =  stops.First(x => x.Id.Value == end);
        
        foreach (var prevStop in currStop.PrevStops)
        {
            List<string> subRoute = new List<string>();
            subRoute.AddRange(currentRoutes);
            subRoute.Add(prevStop.PrevStopName.Value);
            
           routes.AddRange(FindRiderRoute(stops, start, prevStop.PrevStopId.Value, subRoute));
        }

        return routes;
    }

    private List<RiderRoute> SpreadRouteWithUser(IReadOnlyList<Domain.Models.Stop> stops, Domain.Models.Ride ride)
    {
        var riderWithPossibleRoutes = TraceRiderRequestRoute(stops, ride); //{userId, routes, rideType}
         
        
        List<RiderRoute> routes = new();
        foreach (var route in riderWithPossibleRoutes.routes)
        {
            List<string> subRoute = new();
            subRoute.AddRange(route);
            var riderRoute = new RiderRoute(
                riderWithPossibleRoutes.RiderId,
                subRoute,
                riderWithPossibleRoutes.VehincleType
            );
            routes.Add(riderRoute);
        }

        return routes;
    }
     
    private void MathchPassenger(IEnumerable<RiderRoute> riderRoutes) // [{RiderId: :55432eghgg, route: [], rideType }]
    {
        if(!riderRoutes.Any()) return;
        // Dictionary<string, List<string>> mapRoute = new();
        var schedulesFromDb = scheduleRepository.GetAll(new Dictionary<string, string>())
            .GetAwaiter().GetResult();
        //Create a Dictionary
        var ScheduleIndexies = new Dictionary<string, List<string>>();
        foreach (var schedule in schedulesFromDb)
        {
            List<string> usersId = new();
            foreach (var userInSchedule in schedule.User) usersId.Add(userInSchedule.Id);
            ScheduleIndexies.Add(schedule.Path, usersId);
        }

        List<Schedule> schedules = new();

        var user = userRepository.GetUserById((riderRoutes.ToList())[0].RiderId).GetAwaiter().GetResult();
        foreach (RiderRoute riderRoute in  riderRoutes)
        {
            StringBuilder str = new();
            var route = riderRoute.route;
            for (int idx=0; idx<route.Count; idx++)
            {
                str.Append(route[idx]);
                if(idx < route.Count()-1) str.Append("->");
            }
            //appending rideType to generate rooute
            var newStr = $"{riderRoutes.ToList()[0].VehincleType.ToString()}_{str}"; //from request
            IEnumerable<string> mapingIndexKey = ScheduleIndexies.Keys;
            if (mapingIndexKey.Any())
            {
                // var mapingIndexKeyLength = mapingIndexKey.Count();
                 // bool[] isChecked = new bool[mapingIndexKey.Count()];
                 var foundRoute = new List<string>();
                foreach (var mapKey in mapingIndexKey)
                {
                    var key = mapKey.Split("_")[1];
                    var vehincleType = mapKey.Split("_")[0];
                    var sch = scheduleRepository.GetByPath(mapKey).GetAwaiter().GetResult();
                    if (str.ToString().Contains(key) && riderRoute.VehincleType.ToString() == vehincleType)
                    {
                        sch.AdjustPath(newStr); //str.ToString()
                        sch.AddUser(user);
                        scheduleRepository.Update(sch);
                        foundRoute.Add(str.ToString());
                    }
                    else if (key.Contains(str.ToString()) && riderRoute.VehincleType.ToString() == vehincleType )
                    {
                        sch.AddUser(user);
                        scheduleRepository.Update(sch);
                        foundRoute.Add(mapKey);
                    }
                    // else
                    // {
                    //     var schedule = Schedule.Create(str.ToString());
                    //     schedule.AddUser(user);
                    //     schedules.Add(schedule);
                    // }
                }
                if(!foundRoute.Any()) 
                {
                    var schedule = Schedule.Create(newStr); //str.ToString()
                    schedule.AddUser(user);
                    schedules.Add(schedule);
                }
            }
            else
            {
                var schedule = Schedule.Create(newStr); //str.ToString()
                schedule.AddUser(user);
                schedules.Add(schedule);
            }
        }

        if(schedules.Any()) scheduleRepository.AddRangeAsync(schedules).GetAwaiter().GetResult();
        // str.Replace(" ", "");

       // List<string> mapKey = mapRoute.Keys;
       // if mapKe
    }
}