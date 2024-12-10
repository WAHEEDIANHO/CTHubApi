using CThub.Application.Common.CQRS;
using CThub.Contract.Authentication;
using MediatR;

namespace CThub.Application.Authentication.Commands.Rider;

public record RiderRegisterCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName
    ) : ICommand<AuthResponse>;