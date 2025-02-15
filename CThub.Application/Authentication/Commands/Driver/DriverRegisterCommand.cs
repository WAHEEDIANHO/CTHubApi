using CThub.Application.Common.CQRS;
using CThub.Contract.Authentication;
using CThub.Domain.Enums;

namespace CThub.Application.Authentication.Commands.Driver;

public record DriverRegisterCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string VehincleName,
    Vehincle VehincleType,
    string VehincleModel,
    int VehincleCapacity
    ): ICommand<AuthResponse>;