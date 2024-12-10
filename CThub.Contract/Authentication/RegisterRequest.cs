namespace CThub.Contract.Authentication;

public record RegisterRequest(
        string Email,
        string FirstName,
        string LastName,
        string Password
    );
