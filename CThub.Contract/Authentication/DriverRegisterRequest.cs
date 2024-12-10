namespace CThub.Contract.Authentication;

public record DriverRegisterRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string VehincleName,
    string VehincleType,
    string VehincleModel,
    int VehincleCapacity
    );