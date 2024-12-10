using CThub.Application.Common.Authentication;
using CThub.Application.Common.Persistence.Authentication;
using CThub.Contract.Authentication;
using CThub.Domain.Entities;
using CThub.Domain.Exceptions;
using MediatR;
using User = CThub.Domain.Models.User;

namespace CThub.Application.Authentication.Queries;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtToken): IRequestHandler<LoginQuery, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (userRepository.GetUserByEmail(request.Email).GetAwaiter().GetResult() is not User user)
        {
            throw new UnauthorizedException("Invalid login credential");
        }
        if(!userRepository.CheckPassword(user, request.Password).GetAwaiter().GetResult()) throw new UnauthorizedException("Invalid login credential");
        
        var token = jwtToken.GetToken(user);
        return new AuthResponse(user.FirstName, user.LastName, user.Email!, token);
    }
}