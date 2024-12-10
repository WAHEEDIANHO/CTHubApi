using CThub.Application.Common.Authentication;
using CThub.Application.Common.CQRS;
using CThub.Application.Common.Persistence.Authentication;
using CThub.Contract.Authentication;
using CThub.Domain.Models;
using CThub.Domain.ValueObjects;

namespace CThub.Application.Authentication.Commands.Driver;

public class DriverRegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator): ICommandHandler<DriverRegisterCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(DriverRegisterCommand command, CancellationToken cancellationToken)
    {
        var userVehincle = Vehincle.Of(command.VehincleName, command.VehincleType, command.VehincleModel,
            command.VehincleCapacity);
        var user = User.CreateUser(
            command.FirstName,
            command.LastName,
            command.Email,
            userVehincle
        );
        await userRepository.AddUser(user, command.Password);
        var token = jwtTokenGenerator.GetToken(user);
        return new AuthResponse(user.FirstName, user.LastName, user.Email!, token);
    }
}