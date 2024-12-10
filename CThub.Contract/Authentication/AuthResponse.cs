namespace CThub.Contract.Authentication;

public record AuthResponse(
        string FirstName,
        string LastName,
        string Email,
        string Token
    );