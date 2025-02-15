using CThub.Application.Scheduler.Dtos;
using CThub.Domain.Enums;

namespace CThub.Application.Extensions;

public static class ScheduleExtension
{
    public static IEnumerable<ScheduleDto> ScheduleToDto(this IEnumerable<Schedule> schedule)
    {
       return schedule.Select(x => DtoFormSchedule(x));
    }

    public static IEnumerable<ScheduleDto> DtoUserSpecSchedule(this IEnumerable<Schedule> schedule, Vehincle vehincleType)
    {
        return ScheduleToDto(schedule).Where(x => x.Vehicle == vehincleType.ToString());
    }

    private static ScheduleDto DtoFormSchedule(Schedule schedule)
    {
        var routeVehincle = schedule.Path;
        var riders = schedule.User;

        var path = routeVehincle.Split("_")[1];
        var vehincle = routeVehincle.Split("_")[0];
        var stops = path.Split("->");

        var users = new List<string>();
        foreach (var rider in riders) users.Add(rider.Id);
        
        
        return new ScheduleDto(
                path,
                stops.First(),
                stops.Last(),
                vehincle,
                users
            );
    }
}