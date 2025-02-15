namespace CThub.Application.Scheduler.Dtos;

public record ScheduleDto(
        string Route,
        string Start,
        string Stop,
        string Vehicle,
        List<string> Riders
    );