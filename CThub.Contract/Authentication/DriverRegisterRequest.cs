using CThub.Domain.Enums;

namespace CThub.Contract.Authentication;

public record DriverRegisterRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string VehincleName,
    Vehincle VehincleType,
    string VehincleModel,
    int VehincleCapacity
    );