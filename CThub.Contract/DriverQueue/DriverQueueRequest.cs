using CThub.Domain.Enums;

namespace CThub.Contract.DriverQueue;



public record DriverQueueRequest(
    string DriverId,
    string Latitude,
    string Longitude,
    Vehincle Vehincle,
    string Token
    );