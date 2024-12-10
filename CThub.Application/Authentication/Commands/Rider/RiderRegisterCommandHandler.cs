using CThub.Application.Common.Authentication;
using CThub.Application.Common.CQRS;
using CThub.Application.Common.Persistence.Authentication;
using CThub.Contract.Authentication;
using User = CThub.Domain.Models.User;

namespace CThub.Application.Authentication.Commands.Rider;

public class RiderRegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtToken): ICommandHandler<RiderRegisterCommand, AuthResponse>
{
    
    public async Task<AuthResponse> Handle(RiderRegisterCommand command, CancellationToken cancellationToken)
    {
        // await Task.CompletedTask;
        // if(userRepository.GetUserByEmail(request.Email) is not null) throw new DuplicateEmailError();
        var user =  User.CreateUser(command.FirstName, command.LastName, command.Email);
        await userRepository.AddUser(user, command.Password);
        var token = jwtToken.GetToken(user);
        return new AuthResponse(user.FirstName, user.LastName, user.Email, token);
    }
}