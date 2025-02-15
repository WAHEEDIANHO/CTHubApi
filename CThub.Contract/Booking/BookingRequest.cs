using CThub.Domain.Enums;

namespace CThub.Contract.Booking;

// public enum Vehincle
// {
//     TRICYCLE,
//     CAR
// }

// public enum Ride
// {
//     DROP,
//     SHARE
// }
public record BookingRequest(
        Guid StartStopId,
        Guid EndStopId,
        Ride RideType,
        Vehincle VehincleType,
        Guid RiderId
    );