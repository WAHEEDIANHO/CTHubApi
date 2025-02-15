using CThub.Domain.Enums;

namespace CThub.Contract.Authentication;

public record AuthResponse(
        string FirstName,
        string LastName,
        string Email,
        string Token,
        string Role,
        string Id,
        Vehincle? Vehicle = null
    );