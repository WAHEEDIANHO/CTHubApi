using CThub.Contract.Authentication;
using MediatR;

namespace CThub.Application.Authentication.Queries;

public record LoginQuery(
    string Email,
    string Password
    ): IRequest<AuthResponse>;