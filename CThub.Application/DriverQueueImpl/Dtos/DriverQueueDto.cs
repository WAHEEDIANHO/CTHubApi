namespace CThub.Application.DriverQueueImpl.Dtos;

public record DriverQueueDto(
        string DriverId,
        DateTime QueueTime,
        string Latitude,
        string Longitude,
        string Vehincle
    );