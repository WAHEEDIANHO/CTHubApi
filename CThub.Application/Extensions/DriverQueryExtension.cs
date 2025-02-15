using CThub.Application.DriverQueueImpl.Dtos;

namespace CThub.Application.Extensions;

public static class DriverQueryExtension
{
    public static IEnumerable<DriverQueueDto> ToDriverQueueDtos(this IEnumerable<DriverQueue> driverQueues)
    {
        return driverQueues.Select(x => DtoFromDriverQueue(x));
    }

    public static DriverQueueDto ToDriverQueueDtos(this DriverQueue driverQueue)
    {
        return DtoFromDriverQueue(driverQueue);
    }

    private static DriverQueueDto DtoFromDriverQueue(DriverQueue driverQueue)
    {
        return new DriverQueueDto(
                driverQueue.DriverId,
                driverQueue.QueueTime,
                driverQueue.Location.Latitude,
                driverQueue.Location.Longitude,
                driverQueue.Vehincle.ToString()
            );
    }
}